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

            for (int i = 0; i < result.Length; i++)
                result[i] = chars[random.Next(chars.Length)];

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

                    var input = ReadWniosek(wniosek.Formularz);

                    var edycja = new Edycja
                    {
                        DataEdycji = DateTime.Now,
                        User = user,
                    };

                    if (!decision)
                    {
                        wniosek.Status = await ctx.Status
                                    .FirstOrDefaultAsync(x => x.Stan.Equals(StringConstants.Odrzucono));
                    }
                    else
                    {
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
                                ctx.Edycjas.Add(edycja);

                                break;
                            case StringConstants.Zameldowanie:
                                var nrpesel = await ctx.PESELs
                                    .FirstOrDefaultAsync(x => x.NrPESEL.Equals(input[2]));
                                
                                if(nrpesel is null)
                                {
                                    throw new ArgumentNullException(nameof(nrpesel));
                                }

                                var zameldowanie = new Zameldowanie
                                {
                                    PESEL = nrpesel,
                                    Kraj = input[4],
                                    Ulica = input[6],
                                    NrDomu = input[7],
                                    NrLokalu = input[8],
                                    KodPocztowy = input[9],
                                    Miejscowosc = input[10]
                                };

                                ctx.Zameldowanies.Add(zameldowanie);
                                ctx.Edycjas.Add(edycja);

                                break;
                            case StringConstants.Wyjazd:

                                nrpesel = await ctx.PESELs
                                    .FirstOrDefaultAsync(x => x.NrPESEL.Equals(input[2]));

                                if (nrpesel is null)
                                {
                                    throw new ArgumentNullException(nameof(nrpesel));
                                }

                                var wyjazd = new Wyjazd
                                {
                                    PESEL = nrpesel,
                                    DataWyjazdu = DateTime.Parse(input[7]),
                                    KrajWyjazdu = input[8],
                                    Od = DateTime.Parse(input[9]),
                                    Do = DateTime.Parse(input[10])
                                };
                                ctx.Edycjas.Add(edycja);

                                break;
                            case StringConstants.DanePesel:
                                var dane = await ctx.PESELs
                                        .Where(x => x.NrPESEL.Equals(input[2]))
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
                                            $"Ulica: {y.Zameldowanies.Last().Ulica}\n" +
                                            $"NrDomu: {y.Zameldowanies.Last().NrDomu}\n" +
                                            $"NrLokalu: {y.Zameldowanies.Last().NrLokalu}\n" +
                                            $"KodPocztowy: {y.Zameldowanies.Last().KodPocztowy}\n" +
                                            $"Miejscowosc: {y.Zameldowanies.Last().Miejscowosc}\n" +
                                            $"Kraj: {y.Zameldowanies.Last().Kraj}\n"
                                            )).FirstOrDefaultAsync();

                                wniosek.Formularz = dane;
                                break;
                        }

                        wniosek.Status = await ctx.Status
                            .FirstOrDefaultAsync(x => x.Stan.Equals(StringConstants.Przyjeto));
                    }

                    await ctx.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);

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
