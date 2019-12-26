namespace Demo
{
    partial class mainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView_KeyPairs = new System.Windows.Forms.DataGridView();
            this.dataGridView_Sections = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_KeyPairs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Sections)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_KeyPairs
            // 
            this.dataGridView_KeyPairs.AllowUserToAddRows = false;
            this.dataGridView_KeyPairs.AllowUserToDeleteRows = false;
            this.dataGridView_KeyPairs.AllowUserToOrderColumns = true;
            this.dataGridView_KeyPairs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_KeyPairs.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_KeyPairs.Name = "dataGridView_KeyPairs";
            this.dataGridView_KeyPairs.ReadOnly = true;
            this.dataGridView_KeyPairs.Size = new System.Drawing.Size(545, 627);
            this.dataGridView_KeyPairs.TabIndex = 0;
            // 
            // dataGridView_Sections
            // 
            this.dataGridView_Sections.AllowUserToAddRows = false;
            this.dataGridView_Sections.AllowUserToDeleteRows = false;
            this.dataGridView_Sections.AllowUserToOrderColumns = true;
            this.dataGridView_Sections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Sections.Location = new System.Drawing.Point(563, 12);
            this.dataGridView_Sections.Name = "dataGridView_Sections";
            this.dataGridView_Sections.ReadOnly = true;
            this.dataGridView_Sections.Size = new System.Drawing.Size(545, 627);
            this.dataGridView_Sections.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 645);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(563, 645);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 694);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView_Sections);
            this.Controls.Add(this.dataGridView_KeyPairs);
            this.Name = "mainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_KeyPairs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Sections)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_KeyPairs;
        private System.Windows.Forms.DataGridView dataGridView_Sections;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

