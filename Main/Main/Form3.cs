using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Main
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    string name = "Software\\Triangulator\\" + textBox1.Text;

                    RegistryKey reg = Registry.LocalMachine.CreateSubKey(@name);
                    RegistryKey getData = Registry.LocalMachine.OpenSubKey(@"Software\Triangulator");

                    

                    //copy main registry to local file registry
                   foreach (var key in getData.GetValueNames())
                    {
                        reg.SetValue(key, getData.GetValue(key));
                    }

                    RegistryKey check = Registry.LocalMachine.OpenSubKey(@name);

                    if (check != null)
                        MessageBox.Show("Save Successful", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Error Saving your Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    reg.Close();
                    getData.Close();
                    check.Close();
                    this.Close();
                }
                else
                    MessageBox.Show("Name cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
