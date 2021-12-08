using Ewidencja.Database.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ewidencja.Infrastructure.Interfaces
{
    public interface IUrzednikManager
    {
        ICollection<string> ReadWniosek(string wniosek);

        Task<bool> WydajDecyzjeAsync(Wniosek wniosek, bool decision, User user);

    }
}
