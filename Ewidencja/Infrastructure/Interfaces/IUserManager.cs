using Ewidencja.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ewidencja.Infrastructure.Interfaces
{
    public interface IUserManager
    {

        Task<IEnumerable<Typ>> GetAvailableWnioskiAsync();
        Task<IEnumerable<Wniosek>> GetUserWnioskiAsync(int id);

        Task<Formularz> GetFormularzAsync(Typ typ);
        Task<bool> AddWniosekAsync(Wniosek wniosek);
    }
}
