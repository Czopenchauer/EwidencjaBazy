using Ewidencja.Database;
using Ewidencja.Database.Entities;
using Ewidencja.Database.Enums;
using Ewidencja.Infrastructure.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ewidencja.Infrastructure.Managers
{
    public class UrzednikManager : IUrzednikManager
    {
        private readonly ApplicationDbContext ctx;

        public UrzednikManager(ApplicationDbContext ctx)
        {
            this.ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        public ArrayList ReadWniosek(string wniosek)
        {
            var input = new ArrayList();
            StringReader strReader = new StringReader(wniosek);
            while (true)
            {
                var aLine = strReader.ReadLine();
                if (aLine != null)
                {
                    input.Add(aLine);
                }
                else
                {
                    break;
                }
            }
            return input;
        }
    

        // true - przyjeta, false - odrzucona
        public async Task<bool> WydajDecyzjeAsync(Wniosek wniosek, bool decision, User user)
        {
            if (wniosek is null || user is null)
                return false;

            switch (wniosek.Typ.Rodzaj)
            {
                case WniosekTyp.NadajPesel:
                    if (decision)
                    {
                        var input = ReadWniosek(wniosek.Formularz);

                        using (var transaction = ctx.Database.BeginTransaction())
                        {
                            ctx.Users.Add(user);

                            var edycja = new Edycja
                            {
                                DataEdycji = DateTime.Now,
                                User = user,
                                UserId = user.Id
                            };

                            await ctx.SaveChangesAsync();

                            await transaction.CommitAsync();
                        }
                    }
                    break;
            }

            return true;
        }

        ICollection<string> IUrzednikManager.ReadWniosek(string wniosek)
        {
            throw new NotImplementedException();
        }
    }
}
