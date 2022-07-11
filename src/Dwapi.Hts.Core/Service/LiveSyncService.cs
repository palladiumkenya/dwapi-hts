using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.Core.Domain.Dto;
using Dwapi.Hts.Core.Exchange;
using Dwapi.Hts.Core.Interfaces.Repository;
using Dwapi.Hts.Core.Interfaces.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using Serilog.Formatting.Json;

namespace Dwapi.Hts.Core.Service
{
    public class LiveSyncService:ILiveSyncService
    {
        private readonly HttpClient _httpClient;
        private readonly IFacilityRepository _facilityRepository;
        private readonly JsonSerializerSettings _serializerSettings;

        public LiveSyncService(HttpClient httpClient, IFacilityRepository facilityRepository)
        {
            _httpClient = httpClient;

            _facilityRepository = facilityRepository;
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public async void SyncManifest(Manifest manifest,int clientCount)
        {
            string requestEndpoint = "manifest";
            try
            {
                var dto = new ManifestDto(manifest,clientCount);
                var content = JsonConvert.SerializeObject(dto,_serializerSettings);
                var toSend=new StringContent(content, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(requestEndpoint,toSend);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
               Log.Error(e.Message);
            }
        }

        public async void SyncStats(List<Guid> facilityId)
        {
            string requestEndpoint = "stats";

            var stats = _facilityRepository.GetFacStats(facilityId);
            foreach (var stat in stats)
            {
                try
                {
                    var content = JsonConvert.SerializeObject(stat,_serializerSettings);
                    var toSend=new StringContent(content, Encoding.UTF8, "application/json");
                    var response = await _httpClient.PostAsync(requestEndpoint,toSend);
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception e)
                {
                    Log.Error(e.Message);
                }
            }
        }

        public async void SyncMetrics(List<MetricDto> metrics)
        {

            string requestEndpoint = "metric";

            try
            {
                var content = JsonConvert.SerializeObject(metrics, _serializerSettings);

                var toSend = new StringContent(content, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(requestEndpoint, toSend
                );
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Log.Error($"{requestEndpoint} POST...");
                Log.Error(e.Message);
            }
        }

        public async Task SyncHandshake(List<HandshakeDto> dto)
        {
            string requestEndpoint = "handshake";

            try
            {
                var content = JsonConvert.SerializeObject(dto,_serializerSettings);
                var toSend=new StringContent(content, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(requestEndpoint,toSend);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Log.Error($"{requestEndpoint} POST...");
                Log.Error(e.Message);
            }
        }
    }
}
