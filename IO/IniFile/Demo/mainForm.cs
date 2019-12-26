using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CustomNETlib.IO.IniFile;

namespace Demo
{
    public partial class mainForm : Form
    {
        private IniFile testFile;
        private IniFile testFileSection;

        public mainForm()
        {
            InitializeComponent();

            testFile = new IniFile("TestFile.scite", false);
            testFileSection = new IniFile("TestFileSection.scite", true);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try { MessageBox.Show(testFile.Get("keyX", true, "yxcv")); }
            catch (Exception ex) { var x = 0; }
            
            FillIniToForm();
        }

        private void FillIniToForm()
        {
            List<tTableDataKeys> KeyData = new List<tTableDataKeys>();

            for (int i = 0; i < testFile.GetKeys().Count; i++)
            {
                KeyData.Add(new tTableDataKeys(testFile.GetKey(i).Name, testFile.GetKey(i).Value));
            }

            dataGridView_KeyPairs.DataSource = KeyData;
            dataGridView_KeyPairs.AutoResizeColumns();

            List<tTableDataSection> SectionData = new List<tTableDataSection>();

            for (int sIndex = 0; sIndex < testFileSection.GetSections().Count; sIndex++)
            {
                SectionData.Add(new tTableDataSection(testFileSection.GetSection(sIndex).Name, "", ""));

                for (int kIndex = 0; kIndex < testFileSection.GetSection(sIndex).Key.Count; kIndex++)
                {
                    SectionData.Add(new tTableDataSection("", testFileSection.GetSection(sIndex).Key[kIndex].Name, testFileSection.GetSection(sIndex).Key[kIndex].Value));
                }
            }

            dataGridView_Sections.DataSource = SectionData;
            dataGridView_Sections.AutoResizeColumns();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FillIniToForm();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try { testFileSection.Set("Section0", "key0", "some other content..."); }
            catch (Exception ex) { throw ex; }

            FillIniToForm();
        }
    }
}

namespace Demo
{
    partial class mainForm
    {
        public class tTableDataKeys
        {
            public string Key { get; private set; }
            public string Value { get; private set; }

            public tTableDataKeys(string Key, string Value)
            {
                this.Key = Key;
                this.Value = Value;
            }
        }

        public class tTableDataSection
        {
            public string Section { get; private set; }
            public string Key { get; private set; }
            public string Value { get; private set; }

            public tTableDataSection(string Section, string Key, string Value)
            {
                this.Section = Section;
                this.Key = Key;
                this.Value = Value;
            }
        }
    }
}
