using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CustomNETlib.Windows.TaskbarProgressBar;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar1.Maximum = 100;

            comboBox1.Items.Clear();
            comboBox1.Items.Add(TaskbarProgressBar.TaskbarStates.NoProgress.ToString());
            comboBox1.Items.Add(TaskbarProgressBar.TaskbarStates.Indeterminate.ToString());
            comboBox1.Items.Add(TaskbarProgressBar.TaskbarStates.Normal.ToString());
            comboBox1.Items.Add(TaskbarProgressBar.TaskbarStates.Error.ToString());
            comboBox1.Items.Add(TaskbarProgressBar.TaskbarStates.Paused.ToString());
            comboBox1.SelectedIndex = 2;

            customProgressBar1.Maximum = trackBar1.Maximum;
            customProgressBar1.ForeColor = new SolidBrush(Color.DarkViolet);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            customProgressBar1.Value = trackBar1.Value;
            TaskbarProgressBar.SetValue(this.Handle, trackBar1.Value, trackBar1.Maximum);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaskbarProgressBar.SetState(this.Handle, (TaskbarProgressBar.TaskbarStates)Enum.Parse(typeof(TaskbarProgressBar.TaskbarStates), comboBox1.Text));
        }
    }
}
