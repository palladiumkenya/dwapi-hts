using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Dwapi.Hts.Core.Command;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.Core.Interfaces.Repository;
using Hangfire.Logging;
using MediatR;
using Serilog;


namespace Dwapi.Hts.Core.Command
{
    public class SaveManifest : IRequest<MasterFacility>
    {
        public Manifest Manifest { get; set; }
        public bool AllowSnapshot { get; set; }

        public SaveManifest()
        {
        }

        public SaveManifest(Manifest manifest)
        {
            Manifest = manifest;
        }
    }
}

// public class SaveManifestHandler : IRequestHandler<SaveManifest, MasterFacility>
//         {
//             // private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
//             private readonly IHtsClientRepository _htsClientRepository;
//             private readonly IFacilityRepository _facilityRepository;
//
//             public SaveManifestHandler(IHtsClientRepository htsClientRepository,
//                 IFacilityRepository facilityRepository)
//             {
//                 _htsClientRepository = htsClientRepository;
//                 _facilityRepository = facilityRepository;
//             }
//
//             public async Task<MasterFacility> Handle(SaveManifest request, CancellationToken cancellationToken)
//             {
//                 var manifest = request.Manifest;
//
//                 try
//                 {
//                     manifest.Validate();
//
//                     var masterFacility = await _htsClientRepository.VerifyFacility(manifest.SiteCode);
//                     if (null == masterFacility)
//                         throw new Exception($"SiteCode [{manifest.SiteCode}] NOT FOUND in Master Facility List");
//
//                     // _facilityRepository.Enroll(masterFacility, manifest.EmrName, request.AllowSnapshot);
//
//                     return masterFacility;
//                 }
//                 catch (Exception e)
//                 {
//                     Log.Error(e, "Error at save manifest");
//                     throw;
//                 }
//             }
//         }
    

