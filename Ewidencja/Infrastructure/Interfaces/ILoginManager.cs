using Ewidencja.Database.Entities;
using Ewidencja.Database.Enums;
using System.Threading.Tasks;

namespace Ewidencja.Interfaces
{
    public interface ILoginManager
    {
        User SignInUser { get; set; }
        Task<bool> CreateUserAsync(string username, string password);
        Task<LoginState> RegisterAsync(string username, string password);
        Task<LoginState> LoginAsync(string username, string password);
        bool LogOut();
    }
}
