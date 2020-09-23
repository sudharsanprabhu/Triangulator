using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
namespace Main
{
    public partial class Form4 : Form
    {

      
        RegistryKey reg = Registry.LocalMachine.CreateSubKey(@"Software\Triangulator");

        public string[] projects;
        public string open_project;

        public Form4()
        {
            InitializeComponent();
            projects = reg.GetSubKeyNames();
            listBox1.Items.AddRange(projects);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            open_project = listBox1.GetItemText(listBox1.SelectedItem);
            string project_location = "Software\\Triangulator\\" + open_project;
            RegistryKey src = Registry.LocalMachine.OpenSubKey(@project_location);


            foreach(var key in src.GetValueNames())
            {
                reg.SetValue(key, src.GetValue(key));
            }
            reg.SetValue("Open", "true");
            reg.SetValue("Project_Name", open_project);
            Process.Start("Main.exe");
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            open_project = listBox1.GetItemText(listBox1.SelectedItem);

            if (open_project != "")
            {
                DialogResult dia = MessageBox.Show("Are you sure that you want to delete this project", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dia == DialogResult.Yes)
                {
                    reg.DeleteSubKey(open_project);
                    listBox1.Items.Remove(open_project);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
