using Ewidencja.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ewidencja.Interfaces
{
    public interface ILoginManager
    {
        User SignInUser { get; set; }
        Task<bool> CreateUserAsync(string username, string password);
        Task<bool> RegisterAsync(string username, string password);
        Task<bool> LoginAsync(string username, string password);
        bool LogOut();
    }
}
