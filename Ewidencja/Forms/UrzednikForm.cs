using Ewidencja.Infrastructure.Interfaces;
using Ewidencja.Interfaces;
using Ewidencja.Models;
using Ewidencja.ResourceParameters;
using System;
using System.Windows.Forms;

namespace Ewidencja
{
    public partial class UrzednikForm : Form
    {
        private readonly ILoginManager loginManager;
        private readonly IUrzednikManager urzednikManager;
        private readonly ResourceParameter resourceParameter = new ResourceParameter { PageNumber = 1, PageSize = 10 };
        private WniosekModel SelectedWniosek;

        public UrzednikForm(ILoginManager loginManager, IUrzednikManager urzednikManager)
        {
            InitializeComponent();
            this.loginManager = loginManager ?? throw new ArgumentNullException(nameof(loginManager));
            this.urzednikManager = urzednikManager ?? throw new ArgumentNullException(nameof(urzednikManager));
        }

        private async void UrzednikForm_Load(object sender, EventArgs e)
        {
            var source = await urzednikManager.GetWnioskiAsync(resourceParameter);
            dataGridViewWnioski.Invoke(new Action(() => {
                dataGridViewWnioski.DataSource = source;
                dataGridViewWnioski.Columns[0].Visible = false;
                dataGridViewWnioski.Columns[dataGridViewWnioski.Columns.Count - 1].Visible = false;
            }));
        }

        private async void dataGridViewWnioski_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var value = (WniosekModel)dataGridViewWnioski.CurrentRow.DataBoundItem;

            var res = await urzednikManager.GetWniosekDetailsAsync(value.Id);

            if (String.IsNullOrEmpty(res.Wniosek))
            {
                MessageBox.Show("Wystąpił błąd podczas pobierania formularza.");
                return;
            }

            SelectedWniosek = res;
            richTextBoxWniosek.Text = res.Wniosek;
            richTextBoxWniosek.Visible = true;

        }

        private async void buttonDecision_Click(object sender, EventArgs e)
        {
            if (SelectedWniosek is null)
                return;

            if (!radioButtonAccept.Checked && !radioButtonDecline.Checked)
                return;

            var res = await urzednikManager
                .WydajDecyzjeAsync(SelectedWniosek, radioButtonAccept.Checked, loginManager.SignInUser);

            if (!res)
            {
                MessageBox.Show("Wystąpił błąd podczas podejmowania decyzji.");
                return;
            }

            SelectedWniosek = null;
            richTextBoxWniosek.Visible = false;
            dataGridViewWnioski.DataSource = await urzednikManager.GetWnioskiAsync(resourceParameter);
        }

        private async void buttonNext_Click(object sender, EventArgs e)
        {
            resourceParameter.PageNumber += 1;
            var res = await urzednikManager.GetWnioskiAsync(resourceParameter);

            if (res.Count == 0)
            {
                resourceParameter.PageNumber -= 1;
                return;
            }
            dataGridViewWnioski.DataSource = await urzednikManager.GetWnioskiAsync(resourceParameter);

        }

        private async void buttonPrev_Click(object sender, EventArgs e)
        {
            if (resourceParameter.PageNumber == 1)
                return;

            resourceParameter.PageNumber -= 1;
            dataGridViewWnioski.DataSource = await urzednikManager.GetWnioskiAsync(resourceParameter);
        }
    }
}
