
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
            this.dataGridViewWnioski = new System.Windows.Forms.DataGridView();
            this.tabPageZloz = new System.Windows.Forms.TabPage();
            this.tabControlUser.SuspendLayout();
            this.tabPageWnioski.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWnioski)).BeginInit();
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
            this.tabControlUser.Size = new System.Drawing.Size(849, 555);
            this.tabControlUser.TabIndex = 0;
            // 
            // tabPageWnioski
            // 
            this.tabPageWnioski.Controls.Add(this.dataGridViewWnioski);
            this.tabPageWnioski.Location = new System.Drawing.Point(4, 35);
            this.tabPageWnioski.Name = "tabPageWnioski";
            this.tabPageWnioski.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWnioski.Size = new System.Drawing.Size(841, 516);
            this.tabPageWnioski.TabIndex = 0;
            this.tabPageWnioski.Text = "Wnioski";
            this.tabPageWnioski.UseVisualStyleBackColor = true;
            this.tabPageWnioski.Click += new System.EventHandler(this.tabPageWnioski_Click);
            // 
            // dataGridViewWnioski
            // 
            this.dataGridViewWnioski.AllowUserToAddRows = false;
            this.dataGridViewWnioski.AllowUserToDeleteRows = false;
            this.dataGridViewWnioski.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWnioski.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridViewWnioski.Location = new System.Drawing.Point(214, 3);
            this.dataGridViewWnioski.Name = "dataGridViewWnioski";
            this.dataGridViewWnioski.ReadOnly = true;
            this.dataGridViewWnioski.RowHeadersWidth = 51;
            this.dataGridViewWnioski.RowTemplate.Height = 29;
            this.dataGridViewWnioski.Size = new System.Drawing.Size(624, 510);
            this.dataGridViewWnioski.TabIndex = 0;
            // 
            // tabPageZloz
            // 
            this.tabPageZloz.Location = new System.Drawing.Point(4, 35);
            this.tabPageZloz.Name = "tabPageZloz";
            this.tabPageZloz.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageZloz.Size = new System.Drawing.Size(841, 516);
            this.tabPageZloz.TabIndex = 1;
            this.tabPageZloz.Text = "Złóż wniosek";
            this.tabPageZloz.UseVisualStyleBackColor = true;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 555);
            this.Controls.Add(this.tabControlUser);
            this.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserForm";
            this.Text = "UserForm";
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.tabControlUser.ResumeLayout(false);
            this.tabPageWnioski.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWnioski)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlUser;
        private System.Windows.Forms.TabPage tabPageWnioski;
        private System.Windows.Forms.DataGridView dataGridViewWnioski;
        private System.Windows.Forms.TabPage tabPageZloz;
    }
}

