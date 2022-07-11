using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Data;
using Dwapi.Hts.Core.Interfaces.Repository;
using Dwapi.Hts.Core.Interfaces.Service;
using Dwapi.Hts.Core.Service;
using Dwapi.Hts.Infrastructure.Data;
using Dwapi.Hts.Infrastructure.Data.Repository;
using Dwapi.Hts.SharedKernel.Infrastructure.Data;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using Z.Dapper.Plus;
using StructureMap;
using Dwapi.Hts.Filters;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.OpenApi.Models;

namespace Dwapi.Hts
{
    public class Startup
    {
          public IConfiguration Configuration { get; }
        public static IServiceProvider ServiceProvider { get; private set; }
        public static bool AllowSnapshot { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var assemblyNames = Assembly.GetEntryAssembly().GetReferencedAssemblies();
            List<Assembly> assemblies = new List<Assembly>();
            foreach (var assemblyName in assemblyNames)
            {
                assemblies.Add(Assembly.Load(assemblyName));
            }
            services.AddMediatR(assemblies.ToArray());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var connectionString = Configuration["ConnectionStrings:DwapiConnection"];

            var liveSync= Configuration["LiveSync"];
            var allowSnapshot= Configuration["AllowSnapshot"];
            try
            {
                services.AddDbContext<HtsContext>(o => o.UseSqlServer(connectionString, x => x.MigrationsAssembly(typeof(HtsContext).GetTypeInfo().Assembly.GetName().Name)));
                services.AddHangfire(o => o.UseSqlServerStorage(connectionString));
            }
            catch (Exception e)
            {
                Log.Error(e,"Startup error");
            }

            services.AddScoped<IDocketRepository, DocketRepository>();
            services.AddScoped<IMasterFacilityRepository, MasterFacilityRepository>();

            services.AddScoped<IFacilityRepository, FacilityRepository>();
            services.AddScoped<IManifestRepository, ManifestRepository>();
            services.AddScoped<IHtsClientRepository, HtsClientRepository>();
            services.AddScoped<IHtsClientLinkageRepository, HtsClientLinkageRepository>();
            services.AddScoped<IHtsClientPartnerRepository, HtsClientPartnerRepository>();

            //services.AddScoped<IHtsClientRepository, HtsClientRepository>();
            services.AddScoped<IHtsClientTestsRepository, HtsClientTestsRepository>();
            services.AddScoped<IHtsClientTracingRepository, HtsClientTracingRepository>();
            services.AddScoped<IHtsPartnerTracingRepository, HtsPartnerTracingRepository>();
            services.AddScoped<IHtsPartnerNotificationServicesRepository, HtsPartnerNotificationServicesRepository>();
            services.AddScoped<IHtsClientLinkageRepository, HtsClientLinkageRepository>();
            services.AddScoped<IHtsHtsTestKitsRepository, HtsHtsTestKitsRepository>();
            services.AddScoped<IHtsEligibilityExtractRepository, HtsEligibilityExtractRepository>();


            services.AddScoped<IManifestService, ManifestService>();
            services.AddScoped<IHtsService, HtsService>();
            services.AddScoped<ILiveSyncService, LiveSyncService>();
            if (!string.IsNullOrWhiteSpace(liveSync))
            {
                Uri endPointA = new Uri(liveSync); // this is the endpoint HttpClient will hit
                HttpClient httpClient = new HttpClient()
                {
                    BaseAddress = endPointA,
                };
                services.AddSingleton<HttpClient>(httpClient);
            }
            if (!string.IsNullOrWhiteSpace(allowSnapshot))
                AllowSnapshot = Convert.ToBoolean(allowSnapshot);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DWAPI Central HTS API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            var container = new Container();
            container.Populate(services);
            ServiceProvider = container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            { app.UseHsts();
            }
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DWAPI Central HTS API");
                c.SupportedSubmitMethods(new Swashbuckle.AspNetCore.SwaggerUI.SubmitMethod[] { });
            });

            // app.UseHttpsRedirection();
            app.UseMvc();

            EnsureMigrationOfContext<HtsContext>();
            Mapper.Initialize(cfg =>
                {
                    cfg.AddDataReaderMapping();
                }
            );

            #region HangFire
            try
            {
                app.UseHangfireDashboard();

                var options = new BackgroundJobServerOptions { WorkerCount = 1 };
                app.UseHangfireServer(options);
                GlobalJobFilters.Filters.Add(new ProlongExpirationTimeAttribute());
                GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute() { Attempts = 3 });
            }
            catch (Exception e)
            {
                Log.Fatal(e, "Hangfire is down !");
            }
            #endregion

            try
            {
                DapperPlusManager.AddLicense("1755;700-ThePalladiumGroup", "2073303b-0cfc-fbb9-d45f-1723bb282a3c");
                if (!Z.Dapper.Plus.DapperPlusManager.ValidateLicense(out var licenseErrorMessage))
                {
                    throw new Exception(licenseErrorMessage);
                }
            }
            catch (Exception e)
            {
                Log.Debug($"{e}");
                throw;
            }

            Log.Debug(@"initializing Database [Complete]");
            Log.Debug(
                @"---------------------------------------------------------------------------------------------------");
            Log.Debug(@"

                        ________                        .__    _________                __                .__
                        \______ \__  _  _______  ______ |__|   \_   ___ \  ____   _____/  |_____________  |  |
                         |    |  \ \/ \/ /\__  \ \____ \|  |   /    \  \/_/ __ \ /    \   __\_  __ \__  \ |  |
                         |    `   \     /  / __ \|  |_> >  |   \     \___\  ___/|   |  \  |  |  | \// __ \|  |__
                        /_______  /\/\_/  (____  /   __/|__| /\ \______  /\___  >___|  /__|  |__|  (____  /____/
                                \/             \/|__|        \/        \/     \/     \/                 \/

            ");
            Log.Debug(
                @"---------------------------------------------------------------------------------------------------");
            Log.Debug("Dwapi Central started !");
        }

        public static void EnsureMigrationOfContext<T>() where T : BaseContext
        {
            var contextName = typeof(T).Name;
            Log.Debug($"initializing Database context: {contextName}");
            var context = ServiceProvider.GetService<T>();
            try
            {
                context.Database.Migrate();
                context.EnsureSeeded();
                Log.Debug($"initializing Database context: {contextName} [OK]");
            }
            catch (Exception e)
            {
                Log.Debug($"initializing Database context: {contextName} Error");
                Log.Debug($"{e}");
            }
        }
    }
}
