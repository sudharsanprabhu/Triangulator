using System;
using Microsoft.Win32;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Configure_Window
{
    public partial class Configure : Form
    {
        RegistryKey regx = Registry.LocalMachine.OpenSubKey(@"Software\Triangulator");
       


        public Configure()
        {
            InitializeComponent();
             
        }
        
        private void Configure_Load(object sender, EventArgs e)
        {
            if (regx!=null && regx.GetValue("dont_ask_again") != null && regx.GetValue("dont_ask_again").ToString() == "1")
            {
                regx.Close();
                Process.Start("Main.exe");
                Application.Exit();
            }
            
        }

        private void ok_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey reg = Registry.LocalMachine.CreateSubKey(@"Software\Triangulator");
                reg.SetValue("s1", s1.Text);
                reg.SetValue("s2", s2.Text);
                reg.SetValue("s3", s3.Text);
                reg.SetValue("s4", s4.Text);
                reg.SetValue("s5", s5.Text);


                if (dms_button.Checked == true)
                {
                    reg.SetValue("angle_format", "dms");
                }
                else
                {
                    reg.SetValue("angle_format", "deg");
                }

                if (anti_clockwise_button.Checked == true)
                {
                    reg.SetValue("direction", "anti_clockwise");
                }
                else
                {
                    reg.SetValue("direction", "clockwise");
                }

                if (dont_ask_again.Checked == true)
                {
                    reg.SetValue("dont_ask_again", "1");
                }
                else
                {
                    reg.SetValue("dont_ask_again", "0");
                }



                reg.SetValue("Open", "false");
                reg.SetValue("Project_Name", "Untitled Project");
                reg.Close();
              
                Process.Start("Main.exe");
                Application.Exit();
            }
          catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
