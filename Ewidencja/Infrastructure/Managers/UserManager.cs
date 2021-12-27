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

        // Rozszerzam funkcjonalnosc o dodawanie typu, statusu i przypisywanie usera do wniosku
        // Zamiast argumentu Wniosek jest jego DTO WniosekModel
        public async Task<bool> AddWniosekAsync(WniosekModel wniosekModel, User user)
        {
            if (wniosekModel is null)
                return false;

            var status = await ctx.Status.FirstOrDefaultAsync(x => x.Stan.Equals(wniosekModel.Status));
            var typ = await ctx.Typ.FirstOrDefaultAsync(x => x.Rodzaj.Equals(wniosekModel.Typ));

            if (status == null || typ == null)
                return false;

            var wniosek = new Wniosek
            {
                Formularz = wniosekModel.Wniosek,
                Data = wniosekModel.Data,
                User = user,
                Status = status,
                Typ = typ,              
            };

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

        public async Task<Formularz> GetFormularzAsync(string typ)
        {
            return await ctx.Formularze
                .FirstOrDefaultAsync(x => x.FormularzTyp.Rodzaj.Equals(typ));
        }

        public async Task<IEnumerable<WniosekModel>> GetUserWnioskiAsync(int id)
        {
            return await ctx.Wnioski
                .Where(x => x.UserId == id)
                .Select(x => new WniosekModel
                {
                    Typ = x.Typ.Rodzaj,
                    Status = x.Status.Stan,
                    Data = x.Data
                })
                .ToArrayAsync();
        }

        public async Task<IEnumerable<TypModel>> GetTypesAsync()
        {
            return await ctx.Typ
                .Select(x => new TypModel
                {
                    TypName = x.Rodzaj
                }).ToArrayAsync();
        }

        public async Task<bool> AddFormularz(string formularz, int id)
        {
            var typ = await ctx.Typ.Where(x => x.Id == id).FirstOrDefaultAsync();
            var toCreate = new Formularz
            {
                TypId = typ.Id,
                FormularzTyp = typ,
                Template = formularz
            };
            ctx.Formularze.Add(toCreate);

            if ((await ctx.SaveChangesAsync() > 0))
                return true;

            return false;
        }
    }
}
