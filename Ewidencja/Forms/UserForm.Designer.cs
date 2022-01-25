
namespace Ewidencja
{
    partial class UserForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlUser = new System.Windows.Forms.TabControl();
            this.tabPageWnioski = new System.Windows.Forms.TabPage();
            this.textBoxWniosek = new System.Windows.Forms.RichTextBox();
            this.dataGridViewWnioski = new System.Windows.Forms.DataGridView();
            this.tabPageZloz = new System.Windows.Forms.TabPage();
            this.buttonZloz = new System.Windows.Forms.Button();
            this.richTextBoxZloz = new System.Windows.Forms.RichTextBox();
            this.comboBoxTyp = new System.Windows.Forms.ComboBox();
            this.tabControlUser.SuspendLayout();
            this.tabPageWnioski.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWnioski)).BeginInit();
            this.tabPageZloz.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlUser
            // 
            this.tabControlUser.Controls.Add(this.tabPageWnioski);
            this.tabControlUser.Controls.Add(this.tabPageZloz);
            this.tabControlUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlUser.Location = new System.Drawing.Point(0, 0);
            this.tabControlUser.Name = "tabControlUser";
            this.tabControlUser.SelectedIndex = 0;
            this.tabControlUser.Size = new System.Drawing.Size(817, 551);
            this.tabControlUser.TabIndex = 0;
            // 
            // tabPageWnioski
            // 
            this.tabPageWnioski.Controls.Add(this.textBoxWniosek);
            this.tabPageWnioski.Controls.Add(this.dataGridViewWnioski);
            this.tabPageWnioski.Location = new System.Drawing.Point(4, 35);
            this.tabPageWnioski.Name = "tabPageWnioski";
            this.tabPageWnioski.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWnioski.Size = new System.Drawing.Size(809, 512);
            this.tabPageWnioski.TabIndex = 0;
            this.tabPageWnioski.Text = "Wnioski";
            this.tabPageWnioski.UseVisualStyleBackColor = true;
            // 
            // textBoxWniosek
            // 
            this.textBoxWniosek.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBoxWniosek.Enabled = false;
            this.textBoxWniosek.Location = new System.Drawing.Point(3, 3);
            this.textBoxWniosek.Name = "textBoxWniosek";
            this.textBoxWniosek.ReadOnly = true;
            this.textBoxWniosek.Size = new System.Drawing.Size(354, 506);
            this.textBoxWniosek.TabIndex = 1;
            this.textBoxWniosek.Text = "";
            this.textBoxWniosek.Visible = false;
            // 
            // dataGridViewWnioski
            // 
            this.dataGridViewWnioski.AllowUserToAddRows = false;
            this.dataGridViewWnioski.AllowUserToDeleteRows = false;
            this.dataGridViewWnioski.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWnioski.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridViewWnioski.Location = new System.Drawing.Point(364, 3);
            this.dataGridViewWnioski.Name = "dataGridViewWnioski";
            this.dataGridViewWnioski.ReadOnly = true;
            this.dataGridViewWnioski.RowHeadersWidth = 51;
            this.dataGridViewWnioski.RowTemplate.Height = 29;
            this.dataGridViewWnioski.Size = new System.Drawing.Size(442, 506);
            this.dataGridViewWnioski.TabIndex = 0;
            this.dataGridViewWnioski.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewWnioski_CellContentClick);
            // 
            // tabPageZloz
            // 
            this.tabPageZloz.Controls.Add(this.buttonZloz);
            this.tabPageZloz.Controls.Add(this.richTextBoxZloz);
            this.tabPageZloz.Controls.Add(this.comboBoxTyp);
            this.tabPageZloz.Location = new System.Drawing.Point(4, 35);
            this.tabPageZloz.Name = "tabPageZloz";
            this.tabPageZloz.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageZloz.Size = new System.Drawing.Size(841, 516);
            this.tabPageZloz.TabIndex = 1;
            this.tabPageZloz.Text = "Złóż wniosek";
            this.tabPageZloz.UseVisualStyleBackColor = true;
            // 
            // buttonZloz
            // 
            this.buttonZloz.Location = new System.Drawing.Point(28, 82);
            this.buttonZloz.Name = "buttonZloz";
            this.buttonZloz.Size = new System.Drawing.Size(151, 41);
            this.buttonZloz.TabIndex = 2;
            this.buttonZloz.Text = "Złóż";
            this.buttonZloz.UseVisualStyleBackColor = true;
            this.buttonZloz.Click += new System.EventHandler(this.buttonZloz_Click);
            // 
            // richTextBoxZloz
            // 
            this.richTextBoxZloz.Dock = System.Windows.Forms.DockStyle.Right;
            this.richTextBoxZloz.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.richTextBoxZloz.Location = new System.Drawing.Point(266, 3);
            this.richTextBoxZloz.Name = "richTextBoxZloz";
            this.richTextBoxZloz.Size = new System.Drawing.Size(572, 510);
            this.richTextBoxZloz.TabIndex = 1;
            this.richTextBoxZloz.Text = "";
            this.richTextBoxZloz.Visible = false;
            // 
            // comboBoxTyp
            // 
            this.comboBoxTyp.FormattingEnabled = true;
            this.comboBoxTyp.Location = new System.Drawing.Point(28, 16);
            this.comboBoxTyp.Name = "comboBoxTyp";
            this.comboBoxTyp.Size = new System.Drawing.Size(151, 34);
            this.comboBoxTyp.TabIndex = 0;
            this.comboBoxTyp.SelectedIndexChanged += new System.EventHandler(this.comboBoxTyp_SelectedIndexChanged);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 551);
            this.Controls.Add(this.tabControlUser);
            this.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserForm";
            this.Text = "UserForm";
            this.Load += new System.EventHandler(this.UserForm_LoadAsync);
            this.tabControlUser.ResumeLayout(false);
            this.tabPageWnioski.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWnioski)).EndInit();
            this.tabPageZloz.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlUser;
        private System.Windows.Forms.TabPage tabPageWnioski;
        private System.Windows.Forms.DataGridView dataGridViewWnioski;
        private System.Windows.Forms.TabPage tabPageZloz;
        private System.Windows.Forms.RichTextBox textBoxWniosek;
        private System.Windows.Forms.Button buttonZloz;
        private System.Windows.Forms.RichTextBox richTextBoxZloz;
        private System.Windows.Forms.ComboBox comboBoxTyp;
    }
}

