using Ewidencja.Database.Entities;
using Ewidencja.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ewidencja.Infrastructure.Interfaces
{
    public interface IUserManager
    {

        Task<IEnumerable<Typ>> GetAvailableWnioskiAsync();
        Task<IEnumerable<WniosekModel>> GetUserWnioskiAsync(int id);

        Task<Formularz> GetFormularzAsync(Typ typ);
        Task<bool> AddWniosekAsync(Wniosek wniosek);
    }
}
