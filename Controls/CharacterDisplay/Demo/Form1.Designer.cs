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
            this.characterDisplay1 = new CustomNETlib.Controls.CharacterDisplay.CharacterDisplay();
            this.button_ShowAsciiField = new System.Windows.Forms.Button();
            this.groupBox_ColorScheme = new System.Windows.Forms.GroupBox();
            this.button_ColorScheme_DotOffColor = new System.Windows.Forms.Button();
            this.button_ColorScheme_ForeColor = new System.Windows.Forms.Button();
            this.radioButton_ColorScheme_Custom = new System.Windows.Forms.RadioButton();
            this.button_ColorScheme_BackColor = new System.Windows.Forms.Button();
            this.radioButton_ColorScheme_Windows = new System.Windows.Forms.RadioButton();
            this.radioButton_ColorScheme_WhiteOnBlue = new System.Windows.Forms.RadioButton();
            this.radioButton_ColorScheme_GreenOnGray = new System.Windows.Forms.RadioButton();
            this.numericUpDown_curPosX = new System.Windows.Forms.NumericUpDown();
            this.button_setTextAt = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.numericUpDown_curPosY = new System.Windows.Forms.NumericUpDown();
            this.groupBox_ColorScheme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_curPosX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_curPosY)).BeginInit();
            this.SuspendLayout();
            // 
            // characterDisplay1
            // 
            this.characterDisplay1.BorderSpace = 3;
            this.characterDisplay1.DigitSpace = 3;
            this.characterDisplay1.DotOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.characterDisplay1.DotShape = CustomNETlib.Controls.CharacterDisplay.DotShape.Square;
            this.characterDisplay1.DotSize = 5;
            this.characterDisplay1.DotSpace = 1;
            this.characterDisplay1.EndOfLineSequence = "\r\n";
            this.characterDisplay1.Location = new System.Drawing.Point(12, 12);
            this.characterDisplay1.Name = "characterDisplay1";
            this.characterDisplay1.nColumns = 32;
            this.characterDisplay1.nRows = 4;
            this.characterDisplay1.Size = new System.Drawing.Size(899, 155);
            this.characterDisplay1.TabIndex = 0;
            this.characterDisplay1.TabStop = false;
            this.characterDisplay1.Text = "characterDisplay1";
            // 
            // button_ShowAsciiField
            // 
            this.button_ShowAsciiField.Location = new System.Drawing.Point(117, 178);
            this.button_ShowAsciiField.Name = "button_ShowAsciiField";
            this.button_ShowAsciiField.Size = new System.Drawing.Size(75, 45);
            this.button_ShowAsciiField.TabIndex = 1;
            this.button_ShowAsciiField.Text = "show ascii field";
            this.button_ShowAsciiField.UseVisualStyleBackColor = true;
            this.button_ShowAsciiField.Click += new System.EventHandler(this.button_ShowAsciiField_Click);
            // 
            // groupBox_ColorScheme
            // 
            this.groupBox_ColorScheme.Controls.Add(this.button_ColorScheme_DotOffColor);
            this.groupBox_ColorScheme.Controls.Add(this.button_ColorScheme_ForeColor);
            this.groupBox_ColorScheme.Controls.Add(this.radioButton_ColorScheme_Custom);
            this.groupBox_ColorScheme.Controls.Add(this.button_ColorScheme_BackColor);
            this.groupBox_ColorScheme.Controls.Add(this.radioButton_ColorScheme_Windows);
            this.groupBox_ColorScheme.Controls.Add(this.radioButton_ColorScheme_WhiteOnBlue);
            this.groupBox_ColorScheme.Controls.Add(this.radioButton_ColorScheme_GreenOnGray);
            this.groupBox_ColorScheme.Location = new System.Drawing.Point(12, 173);
            this.groupBox_ColorScheme.Name = "groupBox_ColorScheme";
            this.groupBox_ColorScheme.Size = new System.Drawing.Size(99, 200);
            this.groupBox_ColorScheme.TabIndex = 2;
            this.groupBox_ColorScheme.TabStop = false;
            this.groupBox_ColorScheme.Text = "ColorScheme";
            // 
            // button_ColorScheme_DotOffColor
            // 
            this.button_ColorScheme_DotOffColor.Location = new System.Drawing.Point(6, 169);
            this.button_ColorScheme_DotOffColor.Name = "button_ColorScheme_DotOffColor";
            this.button_ColorScheme_DotOffColor.Size = new System.Drawing.Size(75, 23);
            this.button_ColorScheme_DotOffColor.TabIndex = 6;
            this.button_ColorScheme_DotOffColor.Text = "DotOffColor";
            this.button_ColorScheme_DotOffColor.UseVisualStyleBackColor = true;
            this.button_ColorScheme_DotOffColor.Click += new System.EventHandler(this.button_ColorScheme_DotOffColor_Click);
            // 
            // button_ColorScheme_ForeColor
            // 
            this.button_ColorScheme_ForeColor.Location = new System.Drawing.Point(6, 140);
            this.button_ColorScheme_ForeColor.Name = "button_ColorScheme_ForeColor";
            this.button_ColorScheme_ForeColor.Size = new System.Drawing.Size(75, 23);
            this.button_ColorScheme_ForeColor.TabIndex = 5;
            this.button_ColorScheme_ForeColor.Text = "ForeColor";
            this.button_ColorScheme_ForeColor.UseVisualStyleBackColor = true;
            this.button_ColorScheme_ForeColor.Click += new System.EventHandler(this.button_ColorScheme_ForeColor_Click);
            // 
            // radioButton_ColorScheme_Custom
            // 
            this.radioButton_ColorScheme_Custom.AutoSize = true;
            this.radioButton_ColorScheme_Custom.Location = new System.Drawing.Point(6, 88);
            this.radioButton_ColorScheme_Custom.Name = "radioButton_ColorScheme_Custom";
            this.radioButton_ColorScheme_Custom.Size = new System.Drawing.Size(60, 17);
            this.radioButton_ColorScheme_Custom.TabIndex = 4;
            this.radioButton_ColorScheme_Custom.TabStop = true;
            this.radioButton_ColorScheme_Custom.Text = "Custom";
            this.radioButton_ColorScheme_Custom.UseVisualStyleBackColor = true;
            this.radioButton_ColorScheme_Custom.CheckedChanged += new System.EventHandler(this.radioButton_ColorScheme_CheckedChanged);
            // 
            // button_ColorScheme_BackColor
            // 
            this.button_ColorScheme_BackColor.Location = new System.Drawing.Point(6, 111);
            this.button_ColorScheme_BackColor.Name = "button_ColorScheme_BackColor";
            this.button_ColorScheme_BackColor.Size = new System.Drawing.Size(75, 23);
            this.button_ColorScheme_BackColor.TabIndex = 3;
            this.button_ColorScheme_BackColor.Text = "BackColor";
            this.button_ColorScheme_BackColor.UseVisualStyleBackColor = true;
            this.button_ColorScheme_BackColor.Click += new System.EventHandler(this.button_ColorScheme_BackColor_Click);
            // 
            // radioButton_ColorScheme_Windows
            // 
            this.radioButton_ColorScheme_Windows.AutoSize = true;
            this.radioButton_ColorScheme_Windows.Location = new System.Drawing.Point(6, 65);
            this.radioButton_ColorScheme_Windows.Name = "radioButton_ColorScheme_Windows";
            this.radioButton_ColorScheme_Windows.Size = new System.Drawing.Size(69, 17);
            this.radioButton_ColorScheme_Windows.TabIndex = 2;
            this.radioButton_ColorScheme_Windows.TabStop = true;
            this.radioButton_ColorScheme_Windows.Text = "Windows";
            this.radioButton_ColorScheme_Windows.UseVisualStyleBackColor = true;
            this.radioButton_ColorScheme_Windows.CheckedChanged += new System.EventHandler(this.radioButton_ColorScheme_CheckedChanged);
            // 
            // radioButton_ColorScheme_WhiteOnBlue
            // 
            this.radioButton_ColorScheme_WhiteOnBlue.AutoSize = true;
            this.radioButton_ColorScheme_WhiteOnBlue.Location = new System.Drawing.Point(6, 42);
            this.radioButton_ColorScheme_WhiteOnBlue.Name = "radioButton_ColorScheme_WhiteOnBlue";
            this.radioButton_ColorScheme_WhiteOnBlue.Size = new System.Drawing.Size(88, 17);
            this.radioButton_ColorScheme_WhiteOnBlue.TabIndex = 1;
            this.radioButton_ColorScheme_WhiteOnBlue.TabStop = true;
            this.radioButton_ColorScheme_WhiteOnBlue.Text = "WhiteOnBlue";
            this.radioButton_ColorScheme_WhiteOnBlue.UseVisualStyleBackColor = true;
            this.radioButton_ColorScheme_WhiteOnBlue.CheckedChanged += new System.EventHandler(this.radioButton_ColorScheme_CheckedChanged);
            // 
            // radioButton_ColorScheme_GreenOnGray
            // 
            this.radioButton_ColorScheme_GreenOnGray.AutoSize = true;
            this.radioButton_ColorScheme_GreenOnGray.Location = new System.Drawing.Point(6, 19);
            this.radioButton_ColorScheme_GreenOnGray.Name = "radioButton_ColorScheme_GreenOnGray";
            this.radioButton_ColorScheme_GreenOnGray.Size = new System.Drawing.Size(90, 17);
            this.radioButton_ColorScheme_GreenOnGray.TabIndex = 0;
            this.radioButton_ColorScheme_GreenOnGray.TabStop = true;
            this.radioButton_ColorScheme_GreenOnGray.Text = "GreenOnGray";
            this.radioButton_ColorScheme_GreenOnGray.UseVisualStyleBackColor = true;
            this.radioButton_ColorScheme_GreenOnGray.CheckedChanged += new System.EventHandler(this.radioButton_ColorScheme_CheckedChanged);
            // 
            // numericUpDown_curPosX
            // 
            this.numericUpDown_curPosX.Location = new System.Drawing.Point(565, 202);
            this.numericUpDown_curPosX.Name = "numericUpDown_curPosX";
            this.numericUpDown_curPosX.Size = new System.Drawing.Size(57, 20);
            this.numericUpDown_curPosX.TabIndex = 3;
            // 
            // button_setTextAt
            // 
            this.button_setTextAt.Location = new System.Drawing.Point(628, 190);
            this.button_setTextAt.Name = "button_setTextAt";
            this.button_setTextAt.Size = new System.Drawing.Size(85, 42);
            this.button_setTextAt.TabIndex = 4;
            this.button_setTextAt.Text = "set text at cursor position";
            this.button_setTextAt.UseVisualStyleBackColor = true;
            this.button_setTextAt.Click += new System.EventHandler(this.button_setTextAt_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(297, 202);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(201, 20);
            this.textBox1.TabIndex = 5;
            // 
            // numericUpDown_curPosY
            // 
            this.numericUpDown_curPosY.Location = new System.Drawing.Point(504, 202);
            this.numericUpDown_curPosY.Name = "numericUpDown_curPosY";
            this.numericUpDown_curPosY.Size = new System.Drawing.Size(57, 20);
            this.numericUpDown_curPosY.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 385);
            this.Controls.Add(this.numericUpDown_curPosY);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_setTextAt);
            this.Controls.Add(this.numericUpDown_curPosX);
            this.Controls.Add(this.groupBox_ColorScheme);
            this.Controls.Add(this.button_ShowAsciiField);
            this.Controls.Add(this.characterDisplay1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_ColorScheme.ResumeLayout(false);
            this.groupBox_ColorScheme.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_curPosX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_curPosY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomNETlib.Controls.CharacterDisplay.CharacterDisplay characterDisplay1;
        private System.Windows.Forms.Button button_ShowAsciiField;
        private System.Windows.Forms.GroupBox groupBox_ColorScheme;
        private System.Windows.Forms.Button button_ColorScheme_DotOffColor;
        private System.Windows.Forms.Button button_ColorScheme_ForeColor;
        private System.Windows.Forms.RadioButton radioButton_ColorScheme_Custom;
        private System.Windows.Forms.Button button_ColorScheme_BackColor;
        private System.Windows.Forms.RadioButton radioButton_ColorScheme_Windows;
        private System.Windows.Forms.RadioButton radioButton_ColorScheme_WhiteOnBlue;
        private System.Windows.Forms.RadioButton radioButton_ColorScheme_GreenOnGray;
        private System.Windows.Forms.NumericUpDown numericUpDown_curPosX;
        private System.Windows.Forms.Button button_setTextAt;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown_curPosY;
    }
}

