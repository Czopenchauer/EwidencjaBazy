using Ewidencja.Database;
using Ewidencja.Database.Enums;
using Ewidencja.Infrastructure.Interfaces;
using Ewidencja.Infrastructure.Managers;
using Ewidencja.Interfaces;
using Ewidencja.Managers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows.Forms;

namespace Ewidencja
{
    static class Program
    {

        public static IConfiguration Configuration;

        [STAThread]
        static void Main()
        {
            var devEnvironmentVariable = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
            var isDevelopment = string.IsNullOrEmpty(devEnvironmentVariable) || devEnvironmentVariable.ToLower() == "development";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            if (isDevelopment)
            {
                //builder.AddUserSecrets<ConnectionHandler>();
                builder.AddUserSecrets("41109e72-b7d9-4ca3-8c8d-5e84e98ab64a"); // to sekret!! PROSZE NIE CZYTAC!!!1!!1

            }
            Configuration = builder.Build();

            //ConnectionHandler = Configuration.GetSection("ConnectionHandler").Get<ConnectionHandler>();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            var services = new ServiceCollection();


            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var userForm = serviceProvider.GetRequiredService<UserForm>();
                var urzednikForm = serviceProvider.GetRequiredService<UrzednikForm>();
                var loginForm = serviceProvider.GetRequiredService<LoginForm>();

                Application.Run(loginForm);

                switch (loginForm.UserSuccessfullyAuthenticated) 
                {
                    case LoginState.NotCorrect: return;
                    case LoginState.User: 
                        Application.Run(userForm);
                        break;
                    case LoginState.Urzednik:
                        Application.Run(urzednikForm);
                        break;
                }
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<ILoginManager, LoginManager>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IUrzednikManager, UrzednikManager>();

            //services.Configure<ConnectionHandler>(Configuration.GetSection(nameof(ConnectionHandler)));
            services.AddScoped<UrzednikForm>();
            services.AddScoped<UserForm>();
            services.AddScoped<LoginForm>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["DatabaseConnection"]));
            //services.AddSingleton(Configuration);
            //services.AddSingleton(ConnectionHandler);
        }
    }
}
