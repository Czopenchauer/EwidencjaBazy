using Ewidencja.Database.Entities;
using Ewidencja.Helper;
using Ewidencja.Models;
using Ewidencja.ResourceParameters;
using System.Threading.Tasks;

namespace Ewidencja.Infrastructure.Interfaces
{
    public interface IUrzednikManager
    {
        Task<PagedList<WniosekModel>> GetWnioskiAsync(ResourceParameter resourceParameter);

        Task<bool> WydajDecyzjeAsync(WniosekModel wniosek, bool decision, User user);

        Task<WniosekModel> GetWniosekDetailsAsync(int id);
    }
}
