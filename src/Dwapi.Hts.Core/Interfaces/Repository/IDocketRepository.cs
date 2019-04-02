using System.Threading.Tasks;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.SharedKernel.Interfaces;

namespace Dwapi.Hts.Core.Interfaces.Repository
{
    public interface IDocketRepository : IRepository<Docket, string>
    {
       Task<Docket> FindAsync(string docket);
    }
}