using Ewidencja.Database;
using Ewidencja.Database.Entities;
using Ewidencja.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Ewidencja.Helper;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ewidencja.ResourceParameters;
using Ewidencja.Models;

namespace Ewidencja.Infrastructure.Managers
{
    public class UrzednikManager : IUrzednikManager
    {
        private readonly ApplicationDbContext ctx;

        public UrzednikManager(ApplicationDbContext ctx)
        {
            this.ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        private List<string> ReadWniosek(string wniosek)
        {
            var input = new List<string>();
            StringReader strReader = new StringReader(wniosek);
            while (true)
            {
                var aLine = strReader.ReadLine();
                if (aLine != null)
                {
                    
                    if(aLine.Count(c => c == ':') > 2)
                    {
                        return null;
                    }

                    var values = aLine.Split(':');

                    try
                    {
                        if (String.IsNullOrEmpty(values[1]) || String.IsNullOrWhiteSpace(values[1]))
                        {
                            input.Add(null);
                        }
                        else
                        {
                            input.Add(values[1].Trim());

                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        input.Add(null);
                    }
                }
                else
                {
                    break;
                }
            }
            return input;
        }
    
        private string RandomPesel()
        {
            var chars = "0123456789";
            var result = new char[11];
            var random = new Random();
            do
            {
                for (int i = 0; i < result.Length; i++)
                    result[i] = chars[random.Next(chars.Length)];

            } while (ctx.PESELs.FirstOrDefault(x => x.NrPESEL.Equals(new string(result))) != null);


            return new string(result);
        }

        // true - przyjeta, false - odrzucona
        public async Task<bool> WydajDecyzjeAsync(WniosekModel wniosekModel, bool decision, User user)
        {
            if (wniosekModel is null || user is null)
                return false;

            try
            {
                using (var transaction = ctx.Database.BeginTransaction())
                {
                    var wniosek = await ctx.Wnioski
                        .Include(x => x.Status)
                        .Include(x => x.Typ)
                        .FirstOrDefaultAsync(x => x.Id == wniosekModel.Id);

                    if(wniosek is null)
                        return false;

                    if (!decision)
                    {
                        wniosek.Status = await ctx.Status
                                    .FirstOrDefaultAsync(x => x.Stan.Equals(StringConstants.Odrzucono));
                        await ctx.SaveChangesAsync();

                        await transaction.CommitAsync();
                        return true;
                    }
                    var input = ReadWniosek(wniosek.Formularz);

                    if(input.All(x => x is null))
                    {                       
                        return false;
                    }
                    var edycja = new Edycja
                    {
                        DataEdycji = DateTime.Now,
                        User = user,
                    };

                    switch (wniosek.Typ.Rodzaj)
                    {
                        case StringConstants.NadajPesel:
                            
                            var pesel = new PESEL
                            {
                                NrPESEL = RandomPesel(),
                                Imie1 = input[0],
                                Imie2 = input[1],
                                Nazwisko = input[2],
                                Plec = input[3].ToUpper().Equals("M") ? true : false,
                                DataUrodzenia = DateTime.Parse(input[4]),
                                MiejsceUrodzenia = input[5],
                                KrajUrodzenia = input[6]
                            };

                            ctx.PESELs.Add(pesel);
                            edycja.PESEL = pesel;
                            ctx.Edycjas.Add(edycja);

                            break;
                        case StringConstants.Zameldowanie:
                            var nrpesel = await ctx.PESELs
                                .FirstOrDefaultAsync(x => x.NrPESEL.Equals(input[3]));
                                
                            if(nrpesel is null)
                            {
                                return false;
                                throw new ArgumentNullException(nameof(nrpesel));
                            }

                            var zameldowanie = new Zameldowanie
                            {
                                PESEL = nrpesel,
                                Kraj = input[4],
                                Ulica = input[5],
                                NrDomu = input[6],
                                NrLokalu = input[7],
                                KodPocztowy = input[8],
                                Miejscowosc = input[9]
                            };
                            edycja.PESEL = nrpesel;
                            ctx.Zameldowanies.Add(zameldowanie);
                            ctx.Edycjas.Add(edycja);

                            break;
                        case StringConstants.Wyjazd:

                            nrpesel = await ctx.PESELs
                                .FirstOrDefaultAsync(x => x.NrPESEL.Equals(input[3]));

                            if (nrpesel is null)
                            {
                                return false;

                                throw new ArgumentNullException(nameof(nrpesel));
                            }

                            var wyjazd = new Wyjazd
                            {
                                PESEL = nrpesel,
                                DataWyjazdu = DateTime.Parse(input[4]),
                                KrajWyjazdu = input[5],
                                Od = DateTime.Parse(input[6]),
                                Do = DateTime.Parse(input[7])
                            };
                            edycja.PESEL = nrpesel;
                            ctx.Edycjas.Add(edycja);

                            break;
                        case StringConstants.DanePesel:
                            var dane = await ctx.PESELs
                                    .Where(x => x.NrPESEL.Equals(input[3]))
                                    .Select(y => new string(
                                        "Pańskie dane\n" +
                                        $"Imię: {y.Imie1}\n" +
                                        $"Nazwisko: {y.Nazwisko}\n" +
                                        $"Nr PESEL: {y.NrPESEL}\n" +
                                        $"Imie = {y.Imie1}\n" +
                                        $"Nazwisko = {y.Nazwisko}\n" +
                                        $"NrPesel: {y.NrPESEL}\n" +
                                        $"DataUrodzenia: {y.DataUrodzenia}\n" +
                                        $"MiejsceUrodzenia: {y.MiejsceUrodzenia}\n" +
                                        $"Ulica: {y.Zameldowanies.OrderByDescending(x => x.Id).Last().Ulica}\n" +
                                        $"NrDomu: {y.Zameldowanies.OrderByDescending(x => x.Id).Last().NrDomu}\n" +
                                        $"NrLokalu: {y.Zameldowanies.OrderByDescending(x => x.Id).Last().NrLokalu}\n" +
                                        $"KodPocztowy: {y.Zameldowanies.OrderByDescending(x => x.Id).Last().KodPocztowy}\n" +
                                        $"Miejscowosc: {y.Zameldowanies.OrderByDescending(x => x.Id).Last().Miejscowosc}\n" +
                                        $"Kraj: {y.Zameldowanies.OrderByDescending(x => x.Id).Last().Kraj}\n"
                                        )).FirstOrDefaultAsync();

                            wniosek.Formularz = dane;
                            break;
                    }

                    wniosek.Status = await ctx.Status
                        .FirstOrDefaultAsync(x => x.Stan.Equals(StringConstants.Przyjeto));
                    
                    //ctx.Edycjas.Add(edycja);
                    await ctx.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
            }
            catch (Exception e)
            {
                //Debug.WriteLine(e.Message);

                return false;
            }

            return true;
        }

        public async Task<PagedList<WniosekModel>> GetWnioskiAsync(ResourceParameter resourceParameters)
        {
            var query = ctx.Wnioski
                .Where(s => s.Status.Stan.Equals(StringConstants.Oczekujacy))
                .Select(y => new WniosekModel
                {
                    Id = y.Id,
                    Typ = y.Typ.Rodzaj,
                    Data = y.Data,
                    Wniosek = y.Formularz,
                    Status = y.Status.Stan
                });

            return await PagedList<WniosekModel>.Create(query, resourceParameters.PageNumber, resourceParameters.PageSize);
        }

        public async Task<WniosekModel> GetWniosekDetailsAsync(int id)
        {
            return await ctx.Wnioski
                    .Where(x => x.Id == id)
                    .Select(y => new WniosekModel
                    { 
                        Id = id,
                        Typ = y.Typ.Rodzaj,
                        Data = y.Data,
                        Wniosek = y.Formularz,
                        Status = y.Status.Stan
                    })
                    .SingleOrDefaultAsync();
        }
    }
}
