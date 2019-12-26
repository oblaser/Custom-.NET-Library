using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CustomNETlib.Controls.CharacterDisplay;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            characterDisplay1.SetEndOfLineSequenceChar('\n');

            button_ColorScheme_BackColor.BackColor = Color.FromArgb(71, 71, 71);
            button_ColorScheme_ForeColor.BackColor = Color.Goldenrod;
            button_ColorScheme_DotOffColor.BackColor = Color.FromArgb(82, 82, 82);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            characterDisplay1.Text = "Hello!\nThis is a Demo Project";
            characterDisplay1.SetText("Have fun!", new CursorPosition(3, characterDisplay1.nColumns - 9));
        }

        private void button_ShowAsciiField_Click(object sender, EventArgs e)
        {
            // the ascii field is from 0 to 127. 4 * 32 chars can represent this field.

            char[][] ascii = new char[4][];

            for(int ri=0;ri<4;++ri)
            {
                ascii[ri] = new char[32];

                for (int ci = 0; ci < 32; ++ci) ascii[ri][ci] = (char)(ri * 32 + ci);
            }

            characterDisplay1.SetDisplayArray(ascii);
        }

        private void radioButton_ColorScheme_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_ColorScheme_GreenOnGray.Checked) characterDisplay1.LoadColorScheme(ColorScheme.GreenOnGray);
            if (radioButton_ColorScheme_WhiteOnBlue.Checked) characterDisplay1.LoadColorScheme(ColorScheme.WhiteOnBlue);
            if (radioButton_ColorScheme_Windows.Checked) characterDisplay1.LoadColorScheme(ColorScheme.Windows);

            if (radioButton_ColorScheme_Custom.Checked)
            {
                characterDisplay1.BackColor = button_ColorScheme_BackColor.BackColor;
                characterDisplay1.ForeColor = button_ColorScheme_ForeColor.BackColor;
                characterDisplay1.DotOffColor = button_ColorScheme_DotOffColor.BackColor;
            }
        }

        private void button_ColorScheme_BackColor_Click(object sender, EventArgs e)
        {
            ColorDialog d = new ColorDialog();
            d.SolidColorOnly = false;

            if (d.ShowDialog() == DialogResult.OK)
            {
                button_ColorScheme_BackColor.BackColor = d.Color;
                characterDisplay1.BackColor = d.Color;
            }
        }

        private void button_ColorScheme_ForeColor_Click(object sender, EventArgs e)
        {
            ColorDialog d = new ColorDialog();
            d.SolidColorOnly = false;

            if (d.ShowDialog() == DialogResult.OK)
            {
                button_ColorScheme_ForeColor.BackColor = d.Color;
                characterDisplay1.ForeColor = d.Color;
            }
        }

        private void button_ColorScheme_DotOffColor_Click(object sender, EventArgs e)
        {
            ColorDialog d = new ColorDialog();
            d.SolidColorOnly = false;

            if (d.ShowDialog() == DialogResult.OK)
            {
                button_ColorScheme_DotOffColor.BackColor = d.Color;
                characterDisplay1.DotOffColor = d.Color;
            }
        }

        private void button_setTextAt_Click(object sender, EventArgs e)
        {
            try { characterDisplay1.SetText(textBox1.Text, new CursorPosition(Convert.ToInt32(numericUpDown_curPosY.Value), Convert.ToInt32(numericUpDown_curPosX.Value))); }
            catch(Exception ex) { MessageBox.Show(ex.ToString()); }
        }
    }
}
