using Ewidencja.Database;
using Ewidencja.Database.Entities;
using Ewidencja.Helper;
using Ewidencja.Infrastructure.Interfaces;
using Ewidencja.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ewidencja.Infrastructure.Managers
{
    public class UserManager : IUserManager
    {
        private readonly ApplicationDbContext ctx;

        public UserManager(ApplicationDbContext ctx)
        {
            this.ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        public async Task<bool> AddWniosekAsync(Wniosek wniosek)
        {
            if (wniosek is null)
                return false;

            ctx.Wnioski.Add(wniosek);

            if ((await ctx.SaveChangesAsync() > 0))
                return true;

            return false;
        }

        public async Task<IEnumerable<Typ>> GetAvailableWnioskiAsync()
        {
            return await ctx.Typ
                .ToArrayAsync();
        }

        public async Task<Formularz> GetFormularzAsync(Typ typ)
        {
            return await ctx.Formularze
                .FirstOrDefaultAsync(x => x.FormularzTyp.Equals(typ));
        }

        public async Task<IEnumerable<WniosekModel>> GetUserWnioskiAsync(int id)
        {
            return await ctx.Wnioski
                .Where(x => x.UserId == id)
                .Select(x => new WniosekModel
                {
                    Typ = x.Typ.GetNameOfType(),
                    Status = x.Status.GetNameOfType()
                })
                .ToArrayAsync();
        }
    }
}
