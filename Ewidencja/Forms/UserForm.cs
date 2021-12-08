using Ewidencja.Database.Entities;
using Ewidencja.Infrastructure.Interfaces;
using Ewidencja.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ewidencja
{
    public partial class UserForm : Form
    {
        private readonly ILoginManager loginManager;
        private readonly IUserManager userManager;
        private IEnumerable<Wniosek> wnioski;

        public UserForm(ILoginManager loginManager, IUserManager userManager)
        {
            InitializeComponent();
            this.loginManager = loginManager ?? throw new ArgumentNullException(nameof(loginManager));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(loginManager));
        }

        private async void tabPageWnioski_Click(object sender, EventArgs e)
        {
            dataGridViewWnioski.DataSource = await userManager.GetUserWnioskiAsync(loginManager.SignInUser.Id);

        }

        private void UserForm_Load(object sender, EventArgs e)
        {

        }
    }
}
