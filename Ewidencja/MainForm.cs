using Ewidencja.Interfaces;
using System;
using System.Windows.Forms;

namespace Ewidencja
{
    public partial class MainForm : Form
    {
        private readonly ILoginManager loginManager;

        public MainForm(ILoginManager loginManager)
        {
            InitializeComponent();
            this.loginManager = loginManager ?? throw new ArgumentNullException(nameof(loginManager));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Rejestracja
        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            var username = textBox1.Text;
            var password = textBox2.Text;

            var result = await loginManager.RegisterAsync(username, password);

            if (result)
                textBox3.Text = loginManager.SignInUser.Username;

            button1.Enabled = true;
        }

        // Login
        private async void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            var username = textBox1.Text;
            var password = textBox2.Text;

            var result = await loginManager.LoginAsync(username, password);

            if (result)
                textBox3.Text = loginManager.SignInUser.Username;

            button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;


            var result = loginManager.LogOut();

            if (result)
                textBox3.Text = "Wylogowano";

            button1.Enabled = true;
        }
    }
}
