namespace Demo
{
    partial class Form1
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
            this.comboBox_Direction = new System.Windows.Forms.ComboBox();
            this.comboBox_Perspective = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_Minimum = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Maximum = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown_Value = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown_BorderWidth = new System.Windows.Forms.NumericUpDown();
            this.button_BorderColor = new System.Windows.Forms.Button();
            this.button_BackColor = new System.Windows.Forms.Button();
            this.button_ForeColor = new System.Windows.Forms.Button();
            this.cProgressBar2 = new CustomNETlib.Controls.CustomProgressBar.CustomProgressBar();
            this.cProgressBar1 = new CustomNETlib.Controls.CustomProgressBar.CustomProgressBar();
            this.cProgressBar3 = new CustomNETlib.Controls.CustomProgressBar.CustomProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Minimum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Maximum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_BorderWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_Direction
            // 
            this.comboBox_Direction.FormattingEnabled = true;
            this.comboBox_Direction.Location = new System.Drawing.Point(12, 25);
            this.comboBox_Direction.Name = "comboBox_Direction";
            this.comboBox_Direction.Size = new System.Drawing.Size(88, 21);
            this.comboBox_Direction.TabIndex = 0;
            this.comboBox_Direction.SelectedIndexChanged += new System.EventHandler(this.comboBox_Direction_SelectedIndexChanged);
            // 
            // comboBox_Perspective
            // 
            this.comboBox_Perspective.FormattingEnabled = true;
            this.comboBox_Perspective.Location = new System.Drawing.Point(106, 25);
            this.comboBox_Perspective.Name = "comboBox_Perspective";
            this.comboBox_Perspective.Size = new System.Drawing.Size(95, 21);
            this.comboBox_Perspective.TabIndex = 1;
            this.comboBox_Perspective.SelectedIndexChanged += new System.EventHandler(this.comboBox_Perspective_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Direction";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Perspective";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Minimum";
            // 
            // numericUpDown_Minimum
            // 
            this.numericUpDown_Minimum.Location = new System.Drawing.Point(12, 86);
            this.numericUpDown_Minimum.Name = "numericUpDown_Minimum";
            this.numericUpDown_Minimum.Size = new System.Drawing.Size(66, 20);
            this.numericUpDown_Minimum.TabIndex = 5;
            this.numericUpDown_Minimum.ValueChanged += new System.EventHandler(this.numericUpDown_Minimum_ValueChanged);
            // 
            // numericUpDown_Maximum
            // 
            this.numericUpDown_Maximum.Location = new System.Drawing.Point(84, 86);
            this.numericUpDown_Maximum.Name = "numericUpDown_Maximum";
            this.numericUpDown_Maximum.Size = new System.Drawing.Size(66, 20);
            this.numericUpDown_Maximum.TabIndex = 7;
            this.numericUpDown_Maximum.ValueChanged += new System.EventHandler(this.numericUpDown_Maximum_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Maximum";
            // 
            // numericUpDown_Value
            // 
            this.numericUpDown_Value.Location = new System.Drawing.Point(158, 86);
            this.numericUpDown_Value.Name = "numericUpDown_Value";
            this.numericUpDown_Value.Size = new System.Drawing.Size(66, 20);
            this.numericUpDown_Value.TabIndex = 9;
            this.numericUpDown_Value.ValueChanged += new System.EventHandler(this.numericUpDown_Value_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(158, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Value";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "BorderWidth";
            // 
            // numericUpDown_BorderWidth
            // 
            this.numericUpDown_BorderWidth.Location = new System.Drawing.Point(12, 146);
            this.numericUpDown_BorderWidth.Name = "numericUpDown_BorderWidth";
            this.numericUpDown_BorderWidth.Size = new System.Drawing.Size(66, 20);
            this.numericUpDown_BorderWidth.TabIndex = 11;
            this.numericUpDown_BorderWidth.ValueChanged += new System.EventHandler(this.numericUpDown_BorderWidth_ValueChanged);
            // 
            // button_BorderColor
            // 
            this.button_BorderColor.Location = new System.Drawing.Point(12, 191);
            this.button_BorderColor.Name = "button_BorderColor";
            this.button_BorderColor.Size = new System.Drawing.Size(50, 50);
            this.button_BorderColor.TabIndex = 12;
            this.button_BorderColor.Text = "Border Color";
            this.button_BorderColor.UseVisualStyleBackColor = true;
            this.button_BorderColor.Click += new System.EventHandler(this.button_BorderColor_Click);
            // 
            // button_BackColor
            // 
            this.button_BackColor.Location = new System.Drawing.Point(68, 191);
            this.button_BackColor.Name = "button_BackColor";
            this.button_BackColor.Size = new System.Drawing.Size(50, 50);
            this.button_BackColor.TabIndex = 13;
            this.button_BackColor.Text = "Back Color";
            this.button_BackColor.UseVisualStyleBackColor = true;
            this.button_BackColor.Click += new System.EventHandler(this.button_BackColor_Click);
            // 
            // button_ForeColor
            // 
            this.button_ForeColor.Location = new System.Drawing.Point(124, 191);
            this.button_ForeColor.Name = "button_ForeColor";
            this.button_ForeColor.Size = new System.Drawing.Size(50, 50);
            this.button_ForeColor.TabIndex = 14;
            this.button_ForeColor.Text = "Fore Color";
            this.button_ForeColor.UseVisualStyleBackColor = true;
            this.button_ForeColor.Click += new System.EventHandler(this.button_ForeColor_Click);
            // 
            // cProgressBar2
            // 
            this.cProgressBar2.BorderWidth = 2;
            this.cProgressBar2.Direction = CustomNETlib.Controls.CustomProgressBar.Direction.Right;
            this.cProgressBar2.Location = new System.Drawing.Point(259, 12);
            this.cProgressBar2.Maximum = 100;
            this.cProgressBar2.Minimum = 0;
            this.cProgressBar2.Name = "cProgressBar2";
            this.cProgressBar2.Perspective = CustomNETlib.Controls.CustomProgressBar.Perspective.Normal;
            this.cProgressBar2.Size = new System.Drawing.Size(316, 23);
            this.cProgressBar2.Step = 1;
            this.cProgressBar2.TabIndex = 16;
            this.cProgressBar2.Text = "cProgressBar2";
            this.cProgressBar2.Value = 0;
            // 
            // cProgressBar1
            // 
            this.cProgressBar1.BorderWidth = 2;
            this.cProgressBar1.Direction = CustomNETlib.Controls.CustomProgressBar.Direction.Right;
            this.cProgressBar1.Location = new System.Drawing.Point(230, 41);
            this.cProgressBar1.Maximum = 100;
            this.cProgressBar1.Minimum = 0;
            this.cProgressBar1.Name = "cProgressBar1";
            this.cProgressBar1.Perspective = CustomNETlib.Controls.CustomProgressBar.Perspective.Normal;
            this.cProgressBar1.Size = new System.Drawing.Size(23, 235);
            this.cProgressBar1.Step = 1;
            this.cProgressBar1.TabIndex = 15;
            this.cProgressBar1.Text = "cProgressBar1";
            this.cProgressBar1.Value = 0;
            // 
            // cProgressBar3
            // 
            this.cProgressBar3.BorderWidth = 2;
            this.cProgressBar3.Direction = CustomNETlib.Controls.CustomProgressBar.Direction.Right;
            this.cProgressBar3.Location = new System.Drawing.Point(259, 41);
            this.cProgressBar3.Maximum = 100;
            this.cProgressBar3.Minimum = 0;
            this.cProgressBar3.Name = "cProgressBar3";
            this.cProgressBar3.Perspective = CustomNETlib.Controls.CustomProgressBar.Perspective.Normal;
            this.cProgressBar3.Size = new System.Drawing.Size(316, 235);
            this.cProgressBar3.Step = 1;
            this.cProgressBar3.TabIndex = 17;
            this.cProgressBar3.Text = "cProgressBar3";
            this.cProgressBar3.Value = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 288);
            this.Controls.Add(this.cProgressBar3);
            this.Controls.Add(this.cProgressBar2);
            this.Controls.Add(this.cProgressBar1);
            this.Controls.Add(this.button_ForeColor);
            this.Controls.Add(this.button_BackColor);
            this.Controls.Add(this.button_BorderColor);
            this.Controls.Add(this.numericUpDown_BorderWidth);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDown_Value);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDown_Maximum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown_Minimum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Perspective);
            this.Controls.Add(this.comboBox_Direction);
            this.Name = "Form1";
            this.Text = "CustomProgressBar Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Minimum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Maximum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_BorderWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Direction;
        private System.Windows.Forms.ComboBox comboBox_Perspective;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_Minimum;
        private System.Windows.Forms.NumericUpDown numericUpDown_Maximum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown_Value;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown_BorderWidth;
        private System.Windows.Forms.Button button_BorderColor;
        private System.Windows.Forms.Button button_BackColor;
        private System.Windows.Forms.Button button_ForeColor;
        private CustomNETlib.Controls.CustomProgressBar.CustomProgressBar cProgressBar1;
        private CustomNETlib.Controls.CustomProgressBar.CustomProgressBar cProgressBar2;
        private CustomNETlib.Controls.CustomProgressBar.CustomProgressBar cProgressBar3;
    }
}
