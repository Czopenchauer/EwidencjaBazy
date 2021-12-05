using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
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
                var form = serviceProvider.GetRequiredService<MainForm>();
                Application.Run(form);
            }

        }

        private static void ConfigureServices(ServiceCollection services)
        {
            //services.Configure<ConnectionHandler>(Configuration.GetSection(nameof(ConnectionHandler)));
            services.AddScoped<MainForm>();
            //services.AddSingleton(Configuration);
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["DatabaseConnection"]));
            //services.AddSingleton(ConnectionHandler);

        }
    }
}
