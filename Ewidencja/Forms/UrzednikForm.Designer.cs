
namespace Ewidencja
{
    partial class UrzednikForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewWnioski = new System.Windows.Forms.DataGridView();
            this.richTextBoxWniosek = new System.Windows.Forms.RichTextBox();
            this.buttonDecision = new System.Windows.Forms.Button();
            this.groupBoxDecision = new System.Windows.Forms.GroupBox();
            this.radioButtonDecline = new System.Windows.Forms.RadioButton();
            this.radioButtonAccept = new System.Windows.Forms.RadioButton();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWnioski)).BeginInit();
            this.groupBoxDecision.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewWnioski
            // 
            this.dataGridViewWnioski.AllowUserToAddRows = false;
            this.dataGridViewWnioski.AllowUserToDeleteRows = false;
            this.dataGridViewWnioski.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWnioski.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridViewWnioski.Location = new System.Drawing.Point(395, 0);
            this.dataGridViewWnioski.Name = "dataGridViewWnioski";
            this.dataGridViewWnioski.ReadOnly = true;
            this.dataGridViewWnioski.RowHeadersWidth = 51;
            this.dataGridViewWnioski.RowTemplate.Height = 29;
            this.dataGridViewWnioski.Size = new System.Drawing.Size(405, 450);
            this.dataGridViewWnioski.TabIndex = 0;
            this.dataGridViewWnioski.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewWnioski_CellContentClick);
            // 
            // richTextBoxWniosek
            // 
            this.richTextBoxWniosek.Dock = System.Windows.Forms.DockStyle.Left;
            this.richTextBoxWniosek.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxWniosek.Name = "richTextBoxWniosek";
            this.richTextBoxWniosek.ReadOnly = true;
            this.richTextBoxWniosek.Size = new System.Drawing.Size(258, 450);
            this.richTextBoxWniosek.TabIndex = 1;
            this.richTextBoxWniosek.Text = "";
            // 
            // buttonDecision
            // 
            this.buttonDecision.Location = new System.Drawing.Point(278, 373);
            this.buttonDecision.Name = "buttonDecision";
            this.buttonDecision.Size = new System.Drawing.Size(94, 65);
            this.buttonDecision.TabIndex = 2;
            this.buttonDecision.Text = "Wydaj decyzje";
            this.buttonDecision.UseVisualStyleBackColor = true;
            this.buttonDecision.Click += new System.EventHandler(this.buttonDecision_Click);
            // 
            // groupBoxDecision
            // 
            this.groupBoxDecision.Controls.Add(this.radioButtonDecline);
            this.groupBoxDecision.Controls.Add(this.radioButtonAccept);
            this.groupBoxDecision.Location = new System.Drawing.Point(278, 303);
            this.groupBoxDecision.Name = "groupBoxDecision";
            this.groupBoxDecision.Size = new System.Drawing.Size(94, 64);
            this.groupBoxDecision.TabIndex = 3;
            this.groupBoxDecision.TabStop = false;
            // 
            // radioButtonDecline
            // 
            this.radioButtonDecline.AutoSize = true;
            this.radioButtonDecline.Location = new System.Drawing.Point(6, 10);
            this.radioButtonDecline.Name = "radioButtonDecline";
            this.radioButtonDecline.Size = new System.Drawing.Size(77, 24);
            this.radioButtonDecline.TabIndex = 5;
            this.radioButtonDecline.TabStop = true;
            this.radioButtonDecline.Text = "Odrzuć";
            this.radioButtonDecline.UseVisualStyleBackColor = true;
            // 
            // radioButtonAccept
            // 
            this.radioButtonAccept.AutoSize = true;
            this.radioButtonAccept.Location = new System.Drawing.Point(6, 40);
            this.radioButtonAccept.Name = "radioButtonAccept";
            this.radioButtonAccept.Size = new System.Drawing.Size(88, 24);
            this.radioButtonAccept.TabIndex = 4;
            this.radioButtonAccept.TabStop = true;
            this.radioButtonAccept.Text = "Akceptuj";
            this.radioButtonAccept.UseVisualStyleBackColor = true;
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(278, 28);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(94, 62);
            this.buttonNext.TabIndex = 4;
            this.buttonNext.Text = "Kolejna strona";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.Location = new System.Drawing.Point(278, 105);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(94, 56);
            this.buttonPrev.TabIndex = 5;
            this.buttonPrev.Text = "Poprzednia strona";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // UrzednikForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.groupBoxDecision);
            this.Controls.Add(this.buttonDecision);
            this.Controls.Add(this.richTextBoxWniosek);
            this.Controls.Add(this.dataGridViewWnioski);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "UrzednikForm";
            this.Text = "UrzednikForm";
            this.Load += new System.EventHandler(this.UrzednikForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWnioski)).EndInit();
            this.groupBoxDecision.ResumeLayout(false);
            this.groupBoxDecision.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewWnioski;
        private System.Windows.Forms.RichTextBox richTextBoxWniosek;
        private System.Windows.Forms.Button buttonDecision;
        private System.Windows.Forms.GroupBox groupBoxDecision;
        private System.Windows.Forms.RadioButton radioButtonAccept;
        private System.Windows.Forms.RadioButton radioButtonDecline;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrev;
    }
}