using Ewidencja.Database;
using Ewidencja.Database.Entities;
using Ewidencja.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ewidencja.Managers
{
    public class LoginManager : ILoginManager
    {
        private readonly ApplicationDbContext ctx;

        public User SignInUser { get; set; }

        public LoginManager(ApplicationDbContext ctx)
        {
            this.ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        /// <summary>
        /// Do "administracyjnego" tworzenia konta. Np. tworzenie konta urzednika
        /// </summary>
        /// <param name="user"></param>
        /// <returns>True jesli user zostal stworzony prawidlowo w przeciwnym razie false</returns>
        public async Task<bool> CreateUserAsync(string username, string password)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
                return false;

            var existingUser = await ctx.Users.Where(x => x.Username.Equals(username) && x.Password.Equals(password)).FirstOrDefaultAsync();
            if (existingUser is not null)
                return false;

            var user = new User
            {
                Username = username,
                Password = password,
                Rola = true
            };
            ctx.Users.Add(user);

            if ((await ctx.SaveChangesAsync() > 0))
                return true;

            return false;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            if (SignInUser is not null || (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password)))
                return false;

            var existingUser = await ctx.Users.Where(x => x.Username.Equals(username) && x.Password.Equals(password)).FirstOrDefaultAsync();
            if (existingUser is null)
                return false;

            SignInUser = existingUser;
            return true;
        }

        public async Task<bool> RegisterAsync(string username, string password)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
                return false;

            var existingUser = await ctx.Users.Where(x => x.Username.Equals(username) && x.Password.Equals(password)).FirstOrDefaultAsync();
            if (existingUser is not null)
                return false;

            var user = new User 
            {
                Username = username,
                Password = password,
                Rola = false
            };

            ctx.Users.Add(user);

            if ((await ctx.SaveChangesAsync() > 0))
            {
                SignInUser = user;
                return true;
            }

            return false;
        }

        public bool LogOut()
        {
            if (SignInUser is null)
                return false;

            SignInUser = null;
            return true;
        }
    }
}
