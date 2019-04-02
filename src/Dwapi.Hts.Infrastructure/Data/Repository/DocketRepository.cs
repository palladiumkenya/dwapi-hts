using System.Threading.Tasks;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.Core.Interfaces.Repository;
using Dwapi.Hts.SharedKernel.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Dwapi.Hts.Infrastructure.Data.Repository
{
    public class DocketRepository : BaseRepository<Docket, string>, IDocketRepository
    {
        public DocketRepository(HtsContext context) : base(context)
        {
        }
        public Task<Docket> FindAsync(string docket)
        {
           var ctx=Context as HtsContext;
            return ctx.Dockets.Include(x => x.Subscribers).AsTracking().FirstOrDefaultAsync(x => x.Id == docket);
        }
    }
}
