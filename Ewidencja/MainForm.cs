using Ewidencja.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ewidencja
{
    public partial class MainForm : Form
    {
        private readonly ApplicationDbContext ctx;

        public MainForm(ApplicationDbContext ctx)
        {
            this.ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async Task<PESEL> Test()
        {
            var pes = new PESEL
            {
                NrPESEL = "11111111111",
                Imie1 = "Jony",
                Imie2 = "Kod",
                DataUrodzenia = new DateTime(1999, 3, 12),
                Plec = true,
                Nazwisko = "Bravo",
                MiejsceUrodzenia = "Sito",
                KrajUrodzenia = "Litwa"
            };
            ctx.PESELs.Add(pes);
            await ctx.SaveChangesAsync();

            var tess = ctx.PESELs.Where(x => x.PESELID == 1).FirstOrDefault();

            return tess;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var task = await Test();
            Console.WriteLine(task.ToString());
        }
    }
}
