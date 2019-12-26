using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CustomNETlib.Controls.CustomProgressBar;

namespace Demo
{
    public partial class Form1 : Form
    {
        object[] directions =
        {
            "Right",
            "Left",
            "Up",
            "Down"
        };

        private object[] perspectives =
        {
            "Normal",
            "Reversed"
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox_Direction.Items.Clear();
            comboBox_Direction.Items.AddRange(directions);
            comboBox_Direction.SelectedIndex = 0;

            comboBox_Perspective.Items.Clear();
            comboBox_Perspective.Items.AddRange(perspectives);
            comboBox_Perspective.SelectedIndex = 0;

            numericUpDown_Minimum.Maximum = Int32.MaxValue;
            numericUpDown_Minimum.Minimum = Int32.MinValue;
            numericUpDown_Minimum.Value = 0;

            numericUpDown_Maximum.Maximum = Int32.MaxValue;
            numericUpDown_Maximum.Minimum = Int32.MinValue;
            numericUpDown_Maximum.Value = 100;

            numericUpDown_Value.Maximum = Int32.MaxValue;
            numericUpDown_Value.Minimum = Int32.MinValue;
            numericUpDown_Value.Value = 25;

            numericUpDown_BorderWidth.Maximum = Int32.MaxValue;
            numericUpDown_BorderWidth.Minimum = Int32.MinValue;
            numericUpDown_BorderWidth.Value = 2;

            button_BorderColor.BackColor = Color.FromKnownColor(KnownColor.ControlDarkDark);
            button_BackColor.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
            button_ForeColor.BackColor = Color.FromKnownColor(KnownColor.Highlight);
        }

        private void comboBox_Direction_SelectedIndexChanged(object sender, EventArgs e)
        {
            cProgressBar1.Direction = (Direction)Enum.Parse(typeof(Direction), comboBox_Direction.Text);
            cProgressBar2.Direction = (Direction)Enum.Parse(typeof(Direction), comboBox_Direction.Text);
            cProgressBar3.Direction = (Direction)Enum.Parse(typeof(Direction), comboBox_Direction.Text);
        }

        private void comboBox_Perspective_SelectedIndexChanged(object sender, EventArgs e)
        {
            cProgressBar1.Perspective = (Perspective)Enum.Parse(typeof(Perspective), comboBox_Perspective.Text);
            cProgressBar2.Perspective = (Perspective)Enum.Parse(typeof(Perspective), comboBox_Perspective.Text);
            cProgressBar3.Perspective = (Perspective)Enum.Parse(typeof(Perspective), comboBox_Perspective.Text);
        }

        private void numericUpDown_Minimum_ValueChanged(object sender, EventArgs e)
        {
            cProgressBar1.Minimum = Convert.ToInt32(numericUpDown_Minimum.Value);
            cProgressBar2.Minimum = Convert.ToInt32(numericUpDown_Minimum.Value);
            cProgressBar3.Minimum = Convert.ToInt32(numericUpDown_Minimum.Value);
        }

        private void numericUpDown_Maximum_ValueChanged(object sender, EventArgs e)
        {
            cProgressBar1.Maximum = Convert.ToInt32(numericUpDown_Maximum.Value);
            cProgressBar2.Maximum = Convert.ToInt32(numericUpDown_Maximum.Value);
            cProgressBar3.Maximum = Convert.ToInt32(numericUpDown_Maximum.Value);
        }

        private void numericUpDown_Value_ValueChanged(object sender, EventArgs e)
        {
            cProgressBar1.Value = Convert.ToInt32(numericUpDown_Value.Value);
            cProgressBar2.Value = Convert.ToInt32(numericUpDown_Value.Value);
            cProgressBar3.Value = Convert.ToInt32(numericUpDown_Value.Value);
        }

        private void numericUpDown_BorderWidth_ValueChanged(object sender, EventArgs e)
        {
            cProgressBar1.BorderWidth = Convert.ToInt32(numericUpDown_BorderWidth.Value);
            cProgressBar2.BorderWidth = Convert.ToInt32(numericUpDown_BorderWidth.Value);
            cProgressBar3.BorderWidth = Convert.ToInt32(numericUpDown_BorderWidth.Value);
        }

        private void button_BorderColor_Click(object sender, EventArgs e)
        {
            ColorDialog d = new ColorDialog();
            d.SolidColorOnly = false;

            if (d.ShowDialog() == DialogResult.OK)
            {
                button_BorderColor.BackColor = d.Color;

                cProgressBar1.BorderColor = new SolidBrush(d.Color);
                cProgressBar2.BorderColor = new SolidBrush(d.Color);
                cProgressBar3.BorderColor = new SolidBrush(d.Color);
            }
        }

        private void button_BackColor_Click(object sender, EventArgs e)
        {
            ColorDialog d = new ColorDialog();
            d.SolidColorOnly = false;

            if (d.ShowDialog() == DialogResult.OK)
            {
                button_BackColor.BackColor = d.Color;

                cProgressBar1.BackColor = new SolidBrush(d.Color);
                cProgressBar2.BackColor = new SolidBrush(d.Color);
                cProgressBar3.BackColor = new SolidBrush(d.Color);
            }
        }

        private void button_ForeColor_Click(object sender, EventArgs e)
        {
            ColorDialog d = new ColorDialog();
            d.SolidColorOnly = false;

            if (d.ShowDialog() == DialogResult.OK)
            {
                button_ForeColor.BackColor = d.Color;

                cProgressBar1.ForeColor = new SolidBrush(d.Color);
                cProgressBar2.ForeColor = new SolidBrush(d.Color);
                cProgressBar3.ForeColor = new SolidBrush(d.Color);
            }
        }
    }
}
