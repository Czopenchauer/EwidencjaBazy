using Ewidencja.Database.Entities;
using Ewidencja.Database.Enums;
using Ewidencja.Infrastructure.Interfaces;
using Ewidencja.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ewidencja.Helper;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Drawing;
using Ewidencja.Models;

namespace Ewidencja
{
    public partial class UserForm : Form
    {
        private readonly ILoginManager loginManager;
        private readonly IUserManager userManager;

        public UserForm(ILoginManager loginManager, IUserManager userManager)
        {
            InitializeComponent();
            this.loginManager = loginManager ?? throw new ArgumentNullException(nameof(loginManager));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(loginManager));
        }

        private async void tabPageWnioski_Click(object sender, EventArgs e)
        {
            dataGridViewWnioski.DataSource = await userManager.GetUserWnioskiAsync(loginManager.SignInUser.Id);
            dataGridViewWnioski.Columns[dataGridViewWnioski.Columns.Count - 1].Visible = false;
        }

        private async void UserForm_LoadAsync(object sender, EventArgs e)
        {
            var types = await userManager.GetTypesAsync();
            foreach(var typ in types)
            {
                comboBoxTyp.Items.Add(typ.TypName);
            }
        }

        private async void dataGridViewWnioski_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var value = dataGridViewWnioski.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            
        }

        private async void buttonZloz_Click(object sender, EventArgs e)
        {
            var template = richTextBoxZloz.Text;

            if (String.IsNullOrEmpty(template))
            {
                return;
            }

            var wniosek = new WniosekModel
            {
                Data = DateTime.Now,
                Wniosek = template,
                Typ = (string)comboBoxTyp.SelectedItem,
                Status = StatusTyp.Oczekujacy.GetNameOfType()
            };

            if(!(await userManager.AddWniosekAsync(wniosek, loginManager.SignInUser)))
            {
                MessageBox.Show("Nie udało się złożyć wniosku");
            }

            // shit do dodawania formularzy do bazy
/*            var formularz =
                "Imię: \n" +
                "Drugie imię: \n" +
                "Nazwisko: \n" +
                "Płeć: \n" +
                "Data urodzenia: \n" +
                "Kraj miejsca zamieszkania: \n";

            var formularz2 =
                "Imię: \n" +
                "Drugie imię: \n" +
                "Nazwisko: \n" +
                "Nr PESEL: \n" +
                "Kraj urodzenia: \n" +
                "Data urodzenia: \n" +
                "Kraj poprzedniego miejsca zamieszkania: \n" +
                "Ulica: \n" +
                "Nr domu: \n" +
                "Nr lokalu: \n" +
                "Kod pocztowy: \n" +
                "Miejscowość: ";

            await userManager.AddFormularz(formularz2, 1);

            await userManager.AddFormularz(formularz, 2);*/
        }
        
        // TODO do ogarniecia switch
        // 1. Ogarnac enum WniosekTyp do stringa za pomoca extension method
        // 2. Lub suchy string tez w EnumExtension
        private async void comboBoxTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = (string)comboBoxTyp.SelectedItem;
            switch (comboBoxTyp.SelectedItem)
            {
                case "Nadanie numeru PESEL":
                    var text = await userManager.GetFormularzAsync(selected);
                    richTextBoxZloz.Text = text.Template;
                    ProtectMySelectedText(text.Template);
                    richTextBoxZloz.Visible = true;
                    break;
                    
            }
        }

        private void ProtectMySelectedText(string text)
        {
            var rgx = new Regex(@":");
            int index = 0;
            foreach (Match match in rgx.Matches(text))
            {
                richTextBoxZloz.Select(index, match.Index - index + 1);
                richTextBoxZloz.SelectionProtected = true;
                index = match.Index + 2;
            }
        }
    }
}
