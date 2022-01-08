using Ewidencja.Database.Entities;
using Ewidencja.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ewidencja.Infrastructure.Interfaces
{
    public interface IUserManager
    {

        Task<IEnumerable<Typ>> GetAvailableWnioskiAsync();
        Task<IEnumerable<WniosekModel>> GetUserWnioskiAsync(int id);
        Task<IEnumerable<TypModel>> GetTypesAsync();

        Task<Formularz> GetFormularzAsync(string typ);
        Task<bool> AddWniosekAsync(WniosekModel wniosekModel, User user);

        Task<bool> AddFormularz(string formularz, int id);
        Task<string> GetUserFormularzAsync(int id);
    }
}
