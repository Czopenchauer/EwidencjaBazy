using Ewidencja.Infrastructure.Interfaces;
using Ewidencja.Interfaces;
using System;
using System.Windows.Forms;
using Ewidencja.Helper;
using System.Text.RegularExpressions;
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

        private async void UserForm_LoadAsync(object sender, EventArgs e)
        {
            var types = await userManager.GetTypesAsync();
            foreach(var typ in types)
            {
                comboBoxTyp.Items.Add(typ.TypName);
            }

            dataGridViewWnioski.Invoke(new Action(async () => { 
                dataGridViewWnioski.DataSource = await userManager.GetUserWnioskiAsync(loginManager.SignInUser.Id);
                dataGridViewWnioski.Columns[0].Visible = false;
                dataGridViewWnioski.Columns[dataGridViewWnioski.Columns.Count - 1].Visible = false;
            }));
        }

        private async void dataGridViewWnioski_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var value = (WniosekModel)dataGridViewWnioski.CurrentRow.DataBoundItem;

            var res = await userManager.GetUserFormularzAsync(value.Id);

            if (String.IsNullOrEmpty(res))
            {
                MessageBox.Show("Wystąpił błąd podczas pobierania formularza.");
                return;
            }

            textBoxWniosek.Text = res;
            textBoxWniosek.Visible = true;
        }

        private async void buttonZloz_Click(object sender, EventArgs e)
        {
            var template = richTextBoxZloz.Text;

            if (String.IsNullOrEmpty(template))
            {
                MessageBox.Show("Nie wybrano formularza.");
                return;
            }

            var wniosek = new WniosekModel
            {
                Data = DateTime.Now,
                Wniosek = template,
                Typ = (string)comboBoxTyp.SelectedItem,
                Status = StringConstants.Oczekujacy
            };

            if(!(await userManager.AddWniosekAsync(wniosek, loginManager.SignInUser)))
            {
                MessageBox.Show("Nie udało się złożyć wniosku");
                return;
            }

            dataGridViewWnioski.DataSource = await userManager.GetUserWnioskiAsync(loginManager.SignInUser.Id);

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
        
        private async void comboBoxTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = (string)comboBoxTyp.SelectedItem;
            var text = await userManager.GetFormularzAsync(selected);

            if(text == null)
            {
                MessageBox.Show($"Nie udało się znaleźć formularza {selected}");
                return;
            }

            richTextBoxZloz.Text = text.Template;
            ProtectMySelectedText(text.Template);
            richTextBoxZloz.Visible = true;                  
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
