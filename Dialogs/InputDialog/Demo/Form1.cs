using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CustomNETlib.Dialogs.InputDialog;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data = button1.Text;

            DialogResult result = InputDialog.Show("A Title", "Enter a string:", ref data);

            if(result == DialogResult.OK)
            {
                button1.Text = data;
            }
        }
    }
}
