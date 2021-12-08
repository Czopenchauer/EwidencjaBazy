using Ewidencja.Database.Enums;
using Ewidencja.Interfaces;
using System;
using System.Windows.Forms;

namespace Ewidencja
{
    public partial class LoginForm : Form
    {
        private readonly ILoginManager loginManager;

        public LoginState UserSuccessfullyAuthenticated { get; set; }

        public LoginForm(ILoginManager loginManager)
        {
            this.loginManager = loginManager ?? throw new ArgumentNullException(nameof(loginManager));
            InitializeComponent();

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

            textBoxPassword.PasswordChar = '*';
            textBoxPassword.MaxLength = 20;
            textBoxUsername.MaxLength = 20;
        }



        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            SetButtonState(false);


            var username = textBoxUsername.Text;
            var password = textBoxPassword.Text;

            if (!ValidateInput(username, password))
            {
                SetButtonState(true);

                return;
            }
            var result = await loginManager.LoginAsync(username, password);
            if (result == LoginState.NotCorrect)
            {
                SetButtonState(true);
                labelFeedback.Visible = true;
                labelFeedback.Text = "Incorrect username or password!";
                return;
            }

            UserSuccessfullyAuthenticated = result;

            this.Close();
        }

        private async void buttonRegister_Click(object sender, EventArgs e)
        {
            SetButtonState(false);

            var username = textBoxUsername.Text;
            var password = textBoxPassword.Text;

            if (!ValidateInput(username, password))
            {
                SetButtonState(true);
                return;
            }
            var result = await loginManager.RegisterAsync(username, password);

            if (result == LoginState.NotCorrect)
            {
                SetButtonState(true);
                labelFeedback.Visible = true;
                labelFeedback.Text = "User already exist!";
                return;
            }

            UserSuccessfullyAuthenticated = result;

            this.Close();
        }


        private bool ValidateInput(string username, string password)
        {
            if (String.IsNullOrEmpty(password) && String.IsNullOrEmpty(username))
            {
                errorProvider1.SetError(textBoxUsername, "Username can't be empty.");
                errorProvider2.SetError(textBoxPassword, "Password can't be empty.");
                return false;
            }

            if (String.IsNullOrEmpty(password))
            {
                errorProvider1.SetError(textBoxPassword, "Password can't be empty.");
                return false;
            }

            if (String.IsNullOrEmpty(username))
            {
                errorProvider1.SetError(textBoxUsername, "Username can't be empty.");
                return false;
            }

            return true;
        }

        private void SetButtonState(bool state)
        {
            buttonLogin.Enabled = state;
            buttonRegister.Enabled = state;
        }
    }
}
