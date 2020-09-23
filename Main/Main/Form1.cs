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
using DMStoDEGdll;
using processdll;
namespace Main
{
    public partial class Form1 : Form
    {
        public string[] station = new string[5];
        public string direction, angle_format;
        public double lambda;
        public string project_name;






        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            RegistryKey reg = Registry.LocalMachine.OpenSubKey(@"Software\Triangulator");
            if (reg == null)
            {
                Process.Start("Configure_Window.exe");
                Application.Exit();
            }
            
            if (reg.GetValue("angle_fromat") != null && reg.GetValue("angle_fromat").ToString() == "deg")
                angle_format = "deg";
            else
                angle_format = "dms";

            if (reg.GetValue("direction") != null && reg.GetValue("direction").ToString() == "clockwise")
                direction = "clockwise";
            else
                direction = "anti_clockwise";


            //Put Data
            station[0] = reg.GetValue("s1").ToString();
            station[1] = reg.GetValue("s2").ToString();
            station[2] = reg.GetValue("s3").ToString();
            station[3] = reg.GetValue("s4").ToString();
            station[4] = reg.GetValue("s5").ToString();
            direction = reg.GetValue("direction").ToString();
            angle_format = reg.GetValue("angle_format").ToString();


            tabPage1.Text = "Instrument at: " + station[0];
            tabPage2.Text = "Instrument at: " + station[1];
            tabPage3.Text = "Instrument at: " + station[2];
            tabPage4.Text = "Instrument at: " + station[3];



            sight_to_1a.Text = "Reference: " + station[4];
            sight_to_2a.Text = station[1];
            sight_to_3a.Text = station[2];
            sight_to_4a.Text = station[3];
            sight_to_5a.Text = "Reference: " + station[4];



            sight_to_1b.Text = "Reference: " + station[4];
            sight_to_2b.Text = station[2];
            sight_to_3b.Text = station[3];
            sight_to_4b.Text = station[0];
            sight_to_5b.Text = "Reference: " + station[4];



            sight_to_1c.Text = "Reference: " + station[4];
            sight_to_2c.Text = station[3];
            sight_to_3c.Text = station[0];
            sight_to_4c.Text = station[1];
            sight_to_5c.Text = "Reference: " + station[4];



            sight_to_1d.Text = "Reference: " + station[4];
            sight_to_2d.Text = station[0];
            sight_to_3d.Text = station[1];
            sight_to_4d.Text = station[2];
            sight_to_5d.Text = "Reference: " + station[4];

            //Put Data
            //Put angles

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            //Check and Reset Registry
            RegistryKey reset = Registry.LocalMachine.CreateSubKey(@"Software\Triangulator");

            if (reg.GetValue("Open") != null)
            {
                if (reg.GetValue("Open").ToString() == "true")
                {
                    
                    reset.SetValue("Open", "false");
                    
                    n11a.Text = reg.GetValue("n11a").ToString();
                    n21a.Text = reg.GetValue("n21a").ToString();
                    n31a.Text = reg.GetValue("n31a").ToString();
                    n41a.Text = reg.GetValue("n41a").ToString();
                    n51a.Text = reg.GetValue("n51a").ToString();

                    n12a.Text = reg.GetValue("n12a").ToString();
                    n22a.Text = reg.GetValue("n22a").ToString();
                    n32a.Text = reg.GetValue("n32a").ToString();
                    n42a.Text = reg.GetValue("n42a").ToString();
                    n52a.Text = reg.GetValue("n52a").ToString();

                    n13a.Text = reg.GetValue("n13a").ToString();
                    n23a.Text = reg.GetValue("n23a").ToString();
                    n33a.Text = reg.GetValue("n33a").ToString();
                    n43a.Text = reg.GetValue("n43a").ToString();
                    n53a.Text = reg.GetValue("n53a").ToString();

                    n14a.Text = reg.GetValue("n14a").ToString();
                    n24a.Text = reg.GetValue("n24a").ToString();
                    n34a.Text = reg.GetValue("n34a").ToString();
                    n44a.Text = reg.GetValue("n44a").ToString();
                    n54a.Text = reg.GetValue("n54a").ToString();

                    //Reverse
                    r11a.Text = reg.GetValue("r11a").ToString();
                    r21a.Text = reg.GetValue("r21a").ToString();
                    r31a.Text = reg.GetValue("r31a").ToString();
                    r41a.Text = reg.GetValue("r41a").ToString();
                    r51a.Text = reg.GetValue("r51a").ToString();

                    r12a.Text = reg.GetValue("r12a").ToString();
                    r22a.Text = reg.GetValue("r22a").ToString();
                    r32a.Text = reg.GetValue("r32a").ToString();
                    r42a.Text = reg.GetValue("r42a").ToString();
                    r52a.Text = reg.GetValue("r52a").ToString();

                    r13a.Text = reg.GetValue("r13a").ToString();
                    r23a.Text = reg.GetValue("r23a").ToString();
                    r33a.Text = reg.GetValue("r33a").ToString();
                    r43a.Text = reg.GetValue("r43a").ToString();
                    r53a.Text = reg.GetValue("r53a").ToString();

                    r14a.Text = reg.GetValue("r14a").ToString();
                    r24a.Text = reg.GetValue("r24a").ToString();
                    r34a.Text = reg.GetValue("r34a").ToString();
                    r44a.Text = reg.GetValue("r44a").ToString();
                    r54a.Text = reg.GetValue("r54a").ToString();

                    //Inst Station B
                    n11b.Text = reg.GetValue("n11b").ToString();
                    n21b.Text = reg.GetValue("n21b").ToString();
                    n31b.Text = reg.GetValue("n31b").ToString();
                    n41b.Text = reg.GetValue("n41b").ToString();
                    n51b.Text = reg.GetValue("n51b").ToString();

                    n12b.Text = reg.GetValue("n12b").ToString();
                    n22b.Text = reg.GetValue("n22b").ToString();
                    n32b.Text = reg.GetValue("n32b").ToString();
                    n42b.Text = reg.GetValue("n42b").ToString();
                    n52b.Text = reg.GetValue("n52b").ToString();

                    n13b.Text = reg.GetValue("n13b").ToString();
                    n23b.Text = reg.GetValue("n23b").ToString();
                    n33b.Text = reg.GetValue("n33b").ToString();
                    n43b.Text = reg.GetValue("n43b").ToString();
                    n53b.Text = reg.GetValue("n53b").ToString();

                    n14b.Text = reg.GetValue("n14b").ToString();
                    n24b.Text = reg.GetValue("n24b").ToString();
                    n34b.Text = reg.GetValue("n34b").ToString();
                    n44b.Text = reg.GetValue("n44b").ToString();
                    n54b.Text = reg.GetValue("n54b").ToString();

                    //Reverse
                    r11b.Text = reg.GetValue("r11b").ToString();
                    r21b.Text = reg.GetValue("r21b").ToString();
                    r31b.Text = reg.GetValue("r31b").ToString();
                    r41b.Text = reg.GetValue("r41b").ToString();
                    r51b.Text = reg.GetValue("r51b").ToString();

                    r12b.Text = reg.GetValue("r12b").ToString();
                    r22b.Text = reg.GetValue("r22b").ToString();
                    r32b.Text = reg.GetValue("r32b").ToString();
                    r42b.Text = reg.GetValue("r42b").ToString();
                    r52b.Text = reg.GetValue("r52b").ToString();

                    r13b.Text = reg.GetValue("r13b").ToString();
                    r23b.Text = reg.GetValue("r23b").ToString();
                    r33b.Text = reg.GetValue("r33b").ToString();
                    r43b.Text = reg.GetValue("r43b").ToString();
                    r53b.Text = reg.GetValue("r53b").ToString();

                    r14b.Text = reg.GetValue("r14b").ToString();
                    r24b.Text = reg.GetValue("r24b").ToString();
                    r34b.Text = reg.GetValue("r34b").ToString();
                    r44b.Text = reg.GetValue("r44b").ToString();
                    r54b.Text = reg.GetValue("r54b").ToString();

                    //Inst Station C

                    n11c.Text = reg.GetValue("n11c").ToString();
                    n21c.Text = reg.GetValue("n21c").ToString();
                    n31c.Text = reg.GetValue("n31c").ToString();
                    n41c.Text = reg.GetValue("n41c").ToString();
                    n51c.Text = reg.GetValue("n51c").ToString();

                    n12c.Text = reg.GetValue("n12c").ToString();
                    n22c.Text = reg.GetValue("n22c").ToString();
                    n32c.Text = reg.GetValue("n32c").ToString();
                    n42c.Text = reg.GetValue("n42c").ToString();
                    n52c.Text = reg.GetValue("n52c").ToString();

                    n13c.Text = reg.GetValue("n13c").ToString();
                    n23c.Text = reg.GetValue("n23c").ToString();
                    n33c.Text = reg.GetValue("n33c").ToString();
                    n43c.Text = reg.GetValue("n43c").ToString();
                    n53c.Text = reg.GetValue("n53c").ToString();

                    n14c.Text = reg.GetValue("n14c").ToString();
                    n24c.Text = reg.GetValue("n24c").ToString();
                    n34c.Text = reg.GetValue("n34c").ToString();
                    n44c.Text = reg.GetValue("n44c").ToString();
                    n54c.Text = reg.GetValue("n54c").ToString();

                    //Reverse
                    r11c.Text = reg.GetValue("r11c").ToString();
                    r21c.Text = reg.GetValue("r21c").ToString();
                    r31c.Text = reg.GetValue("r31c").ToString();
                    r41c.Text = reg.GetValue("r41c").ToString();
                    r51c.Text = reg.GetValue("r51c").ToString();

                    r12c.Text = reg.GetValue("r12c").ToString();
                    r22c.Text = reg.GetValue("r22c").ToString();
                    r32c.Text = reg.GetValue("r32c").ToString();
                    r42c.Text = reg.GetValue("r42c").ToString();
                    r52c.Text = reg.GetValue("r52c").ToString();

                    r13c.Text = reg.GetValue("r13c").ToString();
                    r23c.Text = reg.GetValue("r23c").ToString();
                    r33c.Text = reg.GetValue("r33c").ToString();
                    r43c.Text = reg.GetValue("r43c").ToString();
                    r53c.Text = reg.GetValue("r53c").ToString();

                    r14c.Text = reg.GetValue("r14c").ToString();
                    r24c.Text = reg.GetValue("r24c").ToString();
                    r34c.Text = reg.GetValue("r34c").ToString();
                    r44c.Text = reg.GetValue("r44c").ToString();
                    r54c.Text = reg.GetValue("r54c").ToString();

                    //Inst Station D

                    n11d.Text = reg.GetValue("n11d").ToString();
                    n21d.Text = reg.GetValue("n21d").ToString();
                    n31d.Text = reg.GetValue("n31d").ToString();
                    n41d.Text = reg.GetValue("n41d").ToString();
                    n51d.Text = reg.GetValue("n51d").ToString();

                    n12d.Text = reg.GetValue("n12d").ToString();
                    n22d.Text = reg.GetValue("n22d").ToString();
                    n32d.Text = reg.GetValue("n32d").ToString();
                    n42d.Text = reg.GetValue("n42d").ToString();
                    n52d.Text = reg.GetValue("n52d").ToString();

                    n13d.Text = reg.GetValue("n13d").ToString();
                    n23d.Text = reg.GetValue("n23d").ToString();
                    n33d.Text = reg.GetValue("n33d").ToString();
                    n43d.Text = reg.GetValue("n43d").ToString();
                    n53d.Text = reg.GetValue("n53d").ToString();

                    n14d.Text = reg.GetValue("n14d").ToString();
                    n24d.Text = reg.GetValue("n24d").ToString();
                    n34d.Text = reg.GetValue("n34d").ToString();
                    n44d.Text = reg.GetValue("n44d").ToString();
                    n54d.Text = reg.GetValue("n54d").ToString();

                    //Reverse

                    r11d.Text = reg.GetValue("r11d").ToString();
                    r21d.Text = reg.GetValue("r21d").ToString();
                    r31d.Text = reg.GetValue("r31d").ToString();
                    r41d.Text = reg.GetValue("r41d").ToString();
                    r51d.Text = reg.GetValue("r51d").ToString();

                    r12d.Text = reg.GetValue("r12d").ToString();
                    r22d.Text = reg.GetValue("r22d").ToString();
                    r32d.Text = reg.GetValue("r32d").ToString();
                    r42d.Text = reg.GetValue("r42d").ToString();
                    r52d.Text = reg.GetValue("r52d").ToString();

                    r13d.Text = reg.GetValue("r13d").ToString();
                    r23d.Text = reg.GetValue("r23d").ToString();
                    r33d.Text = reg.GetValue("r33d").ToString();
                    r43d.Text = reg.GetValue("r43d").ToString();
                    r53d.Text = reg.GetValue("r53d").ToString();

                    r14d.Text = reg.GetValue("r14d").ToString();
                    r24d.Text = reg.GetValue("r24d").ToString();
                    r34d.Text = reg.GetValue("r34d").ToString();
                    r44d.Text = reg.GetValue("r44d").ToString();
                    r54d.Text = reg.GetValue("r54d").ToString();
                }
            }
            //End of put angles
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if(reg.GetValue("Project_Name")!=null)
            {
                project_name = reg.GetValue("Project_Name").ToString();
                reset.SetValue("Project_Name", "Untitled Project");
                prj_name.Text = project_name;
                reg.Close();
                reset.Close();
            }
        }



















        //Move around tab pages

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[2];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[3];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        
        
        //New

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            project_name = "Untitled Project";
            prj_name.Text=project_name;
            
            n11a.Text = "";
            n21a.Text = "";
            n31a.Text = "";
            n41a.Text = "";
            n51a.Text = "";

            n12a.Text = "";
            n22a.Text = "";
            n32a.Text = "";
            n42a.Text = "";
            n52a.Text = "";

            n13a.Text = "";
            n23a.Text = "";
            n33a.Text = "";
            n43a.Text = "";
            n53a.Text = "";

            n14a.Text = "";
            n24a.Text = "";
            n34a.Text = "";
            n44a.Text = "";
            n54a.Text = "";

            //Reverse Angles
            r11a.Text = "";
            r21a.Text = "";
            r31a.Text = "";
            r41a.Text = "";
            r51a.Text = "";

            r12a.Text = "";
            r22a.Text = "";
            r32a.Text = "";
            r42a.Text = "";
            r52a.Text = "";

            r13a.Text = "";
            r23a.Text = "";
            r33a.Text = "";
            r43a.Text = "";
            r53a.Text = "";

            r14a.Text = "";
            r24a.Text = "";
            r34a.Text = "";
            r44a.Text = "";
            r54a.Text = "";

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Inst_Station: B
            //Normal Angles
            n11b.Text = "";
            n21b.Text = "";
            n31b.Text = "";
            n41b.Text = "";
            n51b.Text = "";

            n12b.Text = "";
            n22b.Text = "";
            n32b.Text = "";
            n42b.Text = "";
            n52b.Text = "";

            n13b.Text = "";
            n23b.Text = "";
            n33b.Text = "";
            n43b.Text = "";
            n53b.Text = "";

            n14b.Text = "";
            n24b.Text = "";
            n34b.Text = "";
            n44b.Text = "";
            n54b.Text = "";

            //Reverse Angles
            r11b.Text = "";
            r21b.Text = "";
            r31b.Text = "";
            r41b.Text = "";
            r51b.Text = "";

            r12b.Text = "";
            r22b.Text = "";
            r32b.Text = "";
            r42b.Text = "";
            r52b.Text = "";

            r13b.Text = "";
            r23b.Text = "";
            r33b.Text = "";
            r43b.Text = "";
            r53b.Text = "";

            r14b.Text = "";
            r24b.Text = "";
            r34b.Text = "";
            r44b.Text = "";
            r54b.Text = "";


            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //Inst_Station: c
            //Normal Angles
            n11c.Text = "";
            n21c.Text = "";
            n31c.Text = "";
            n41c.Text = "";
            n51c.Text = "";

            n12c.Text = "";
            n22c.Text = "";
            n32c.Text = "";
            n42c.Text = "";
            n52c.Text = "";

            n13c.Text = "";
            n23c.Text = "";
            n33c.Text = "";
            n43c.Text = "";
            n53c.Text = "";

            n14c.Text = "";
            n24c.Text = "";
            n34c.Text = "";
            n44c.Text = "";
            n54c.Text = "";

            //Reverse Angles
            r11c.Text = "";
            r21c.Text = "";
            r31c.Text = "";
            r41c.Text = "";
            r51c.Text = "";

            r12c.Text = "";
            r22c.Text = "";
            r32c.Text = "";
            r42c.Text = "";
            r52c.Text = "";

            r13c.Text = "";
            r23c.Text = "";
            r33c.Text = "";
            r43c.Text = "";
            r53c.Text = "";

            r14c.Text = "";
            r24c.Text = "";
            r34c.Text = "";
            r44c.Text = "";
            r54c.Text = "";


            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



            //Inst_Station: D
            //Normal Angles
            n11d.Text = "";
            n21d.Text = "";
            n31d.Text = "";
            n41d.Text = "";
            n51d.Text = "";

            n12d.Text = "";
            n22d.Text = "";
            n32d.Text = "";
            n42d.Text = "";
            n52d.Text = "";

            n13d.Text = "";
            n23d.Text = "";
            n33d.Text = "";
            n43d.Text = "";
            n53d.Text = "";

            n14d.Text = "";
            n24d.Text = "";
            n34d.Text = "";
            n44d.Text = "";
            n54d.Text = "";

            //Reverse Angles
            r11d.Text = "";
            r21d.Text = "";
            r31d.Text = "";
            r41d.Text = "";
            r51d.Text = "";

            r12d.Text = "";
            r22d.Text = "";
            r32d.Text = "";
            r42d.Text = "";
            r52d.Text = "";

            r13d.Text = "";
            r23d.Text = "";
            r33d.Text = "";
            r43d.Text = "";
            r53d.Text = "";

            r14d.Text = "";
            r24d.Text = "";
            r34d.Text = "";
            r44d.Text = "";
            r54d.Text = "";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Main.Form4();
            f4.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistryKey saveData = Registry.LocalMachine.CreateSubKey(@"Software\Triangulator");
            
            if (project_name=="Untitled Project")
            {
                Form3 f3 = new Form3();
                f3.ShowDialog();
            }
            else
            {
                try
                {
                    //Save new values...
                    saveData.SetValue("n11a", n11a.Text);
                    saveData.SetValue("n21a", n21a.Text);
                    saveData.SetValue("n31a", n31a.Text);
                    saveData.SetValue("n41a", n41a.Text);
                    saveData.SetValue("n51a", n51a.Text);

                    saveData.SetValue("n12a", n12a.Text);
                    saveData.SetValue("n22a", n22a.Text);
                    saveData.SetValue("n32a", n32a.Text);
                    saveData.SetValue("n42a", n42a.Text);
                    saveData.SetValue("n52a", n52a.Text);

                    saveData.SetValue("n13a", n13a.Text);
                    saveData.SetValue("n23a", n23a.Text);
                    saveData.SetValue("n33a", n33a.Text);
                    saveData.SetValue("n43a", n43a.Text);
                    saveData.SetValue("n53a", n53a.Text);

                    saveData.SetValue("n14a", n14a.Text);
                    saveData.SetValue("n24a", n24a.Text);
                    saveData.SetValue("n34a", n34a.Text);
                    saveData.SetValue("n44a", n44a.Text);
                    saveData.SetValue("n54a", n54a.Text);

                    //Reverse

                    saveData.SetValue("r11a", r11a.Text);
                    saveData.SetValue("r21a", r21a.Text);
                    saveData.SetValue("r31a", r31a.Text);
                    saveData.SetValue("r41a", r41a.Text);
                    saveData.SetValue("r51a", r51a.Text);

                    saveData.SetValue("r12a", r12a.Text);
                    saveData.SetValue("r22a", r22a.Text);
                    saveData.SetValue("r32a", r32a.Text);
                    saveData.SetValue("r42a", r42a.Text);
                    saveData.SetValue("r52a", r52a.Text);

                    saveData.SetValue("r13a", r13a.Text);
                    saveData.SetValue("r23a", r23a.Text);
                    saveData.SetValue("r33a", r33a.Text);
                    saveData.SetValue("r43a", r43a.Text);
                    saveData.SetValue("r53a", r53a.Text);

                    saveData.SetValue("r14a", r14a.Text);
                    saveData.SetValue("r24a", r24a.Text);
                    saveData.SetValue("r34a", r34a.Text);
                    saveData.SetValue("r44a", r44a.Text);
                    saveData.SetValue("r54a", r54a.Text);

                    //Inst Station B

                    saveData.SetValue("n11b", n11b.Text);
                    saveData.SetValue("n21b", n21b.Text);
                    saveData.SetValue("n31b", n31b.Text);
                    saveData.SetValue("n41b", n41b.Text);
                    saveData.SetValue("n51b", n51b.Text);

                    saveData.SetValue("n12b", n12b.Text);
                    saveData.SetValue("n22b", n22b.Text);
                    saveData.SetValue("n32b", n32b.Text);
                    saveData.SetValue("n42b", n42b.Text);
                    saveData.SetValue("n52b", n52b.Text);

                    saveData.SetValue("n13b", n13b.Text);
                    saveData.SetValue("n23b", n23b.Text);
                    saveData.SetValue("n33b", n33b.Text);
                    saveData.SetValue("n43b", n43b.Text);
                    saveData.SetValue("n53b", n53b.Text);

                    saveData.SetValue("n14b", n14b.Text);
                    saveData.SetValue("n24b", n24b.Text);
                    saveData.SetValue("n34b", n34b.Text);
                    saveData.SetValue("n44b", n44b.Text);
                    saveData.SetValue("n54b", n54b.Text);

                    //Reverse

                    saveData.SetValue("r11b", r11b.Text);
                    saveData.SetValue("r21b", r21b.Text);
                    saveData.SetValue("r31b", r31b.Text);
                    saveData.SetValue("r41b", r41b.Text);
                    saveData.SetValue("r51b", r51b.Text);

                    saveData.SetValue("r12b", r12b.Text);
                    saveData.SetValue("r22b", r22b.Text);
                    saveData.SetValue("r32b", r32b.Text);
                    saveData.SetValue("r42b", r42b.Text);
                    saveData.SetValue("r52b", r52b.Text);

                    saveData.SetValue("r13b", r13b.Text);
                    saveData.SetValue("r23b", r23b.Text);
                    saveData.SetValue("r33b", r33b.Text);
                    saveData.SetValue("r43b", r43b.Text);
                    saveData.SetValue("r53b", r53b.Text);

                    saveData.SetValue("r14b", r14b.Text);
                    saveData.SetValue("r24b", r24b.Text);
                    saveData.SetValue("r34b", r34b.Text);
                    saveData.SetValue("r44b", r44b.Text);
                    saveData.SetValue("r54b", r54b.Text);

                    //Inst Station C

                    saveData.SetValue("n11c", n11c.Text);
                    saveData.SetValue("n21c", n21c.Text);
                    saveData.SetValue("n31c", n31c.Text);
                    saveData.SetValue("n41c", n41c.Text);
                    saveData.SetValue("n51c", n51c.Text);

                    saveData.SetValue("n12c", n12c.Text);
                    saveData.SetValue("n22c", n22c.Text);
                    saveData.SetValue("n32c", n32c.Text);
                    saveData.SetValue("n42c", n42c.Text);
                    saveData.SetValue("n52c", n52c.Text);

                    saveData.SetValue("n13c", n13c.Text);
                    saveData.SetValue("n23c", n23c.Text);
                    saveData.SetValue("n33c", n33c.Text);
                    saveData.SetValue("n43c", n43c.Text);
                    saveData.SetValue("n53c", n53c.Text);

                    saveData.SetValue("n14c", n14c.Text);
                    saveData.SetValue("n24c", n24c.Text);
                    saveData.SetValue("n34c", n34c.Text);
                    saveData.SetValue("n44c", n44c.Text);
                    saveData.SetValue("n54c", n54c.Text);

                    //Reverse            

                    saveData.SetValue("r11c", r11c.Text);
                    saveData.SetValue("r21c", r21c.Text);
                    saveData.SetValue("r31c", r31c.Text);
                    saveData.SetValue("r41c", r41c.Text);
                    saveData.SetValue("r51c", r51c.Text);

                    saveData.SetValue("r12c", r12c.Text);
                    saveData.SetValue("r22c", r22c.Text);
                    saveData.SetValue("r32c", r32c.Text);
                    saveData.SetValue("r42c", r42c.Text);
                    saveData.SetValue("r52c", r52c.Text);

                    saveData.SetValue("r13c", r13c.Text);
                    saveData.SetValue("r23c", r23c.Text);
                    saveData.SetValue("r33c", r33c.Text);
                    saveData.SetValue("r43c", r43c.Text);
                    saveData.SetValue("r53c", r53c.Text);

                    saveData.SetValue("r14c", r14c.Text);
                    saveData.SetValue("r24c", r24c.Text);
                    saveData.SetValue("r34c", r34c.Text);
                    saveData.SetValue("r44c", r44c.Text);
                    saveData.SetValue("r54c", r54c.Text);

                    //Inst Staion D

                    saveData.SetValue("n11d", n11d.Text);
                    saveData.SetValue("n21d", n21d.Text);
                    saveData.SetValue("n31d", n31d.Text);
                    saveData.SetValue("n41d", n41d.Text);
                    saveData.SetValue("n51d", n51d.Text);

                    saveData.SetValue("n12d", n12d.Text);
                    saveData.SetValue("n22d", n22d.Text);
                    saveData.SetValue("n32d", n32d.Text);
                    saveData.SetValue("n42d", n42d.Text);
                    saveData.SetValue("n52d", n52d.Text);

                    saveData.SetValue("n13d", n13d.Text);
                    saveData.SetValue("n23d", n23d.Text);
                    saveData.SetValue("n33d", n33d.Text);
                    saveData.SetValue("n43d", n43d.Text);
                    saveData.SetValue("n53d", n53d.Text);

                    saveData.SetValue("n14d", n14d.Text);
                    saveData.SetValue("n24d", n24d.Text);
                    saveData.SetValue("n34d", n34d.Text);
                    saveData.SetValue("n44d", n44d.Text);
                    saveData.SetValue("n54d", n54d.Text);

                    //Reverse

                    saveData.SetValue("r11d", r11d.Text);
                    saveData.SetValue("r21d", r21d.Text);
                    saveData.SetValue("r31d", r31d.Text);
                    saveData.SetValue("r41d", r41d.Text);
                    saveData.SetValue("r51d", r51d.Text);

                    saveData.SetValue("r12d", r12d.Text);
                    saveData.SetValue("r22d", r22d.Text);
                    saveData.SetValue("r32d", r32d.Text);
                    saveData.SetValue("r42d", r42d.Text);
                    saveData.SetValue("r52d", r52d.Text);

                    saveData.SetValue("r13d", r13d.Text);
                    saveData.SetValue("r23d", r23d.Text);
                    saveData.SetValue("r33d", r33d.Text);
                    saveData.SetValue("r43d", r43d.Text);
                    saveData.SetValue("r53d", r53d.Text);

                    saveData.SetValue("r14d", r14d.Text);
                    saveData.SetValue("r24d", r24d.Text);
                    saveData.SetValue("r34d", r34d.Text);
                    saveData.SetValue("r44d", r44d.Text);
                    saveData.SetValue("r54d", r54d.Text);


                    //End of save new values








                    string location = "Software\\Triangulator\\" + project_name;
                    RegistryKey dest = Registry.LocalMachine.CreateSubKey(@location);
                    RegistryKey src = Registry.LocalMachine.OpenSubKey(@"Software\Triangulator");
                    foreach (var key in src.GetValueNames())
                    {
                        if (src.GetValue(key) != null)
                        {
                            dest.SetValue(key, src.GetValue(key));
                            
                        }
                    }
                    dest.Close();
                    src.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Main.Form3();
            f3.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey dontaskagain = Registry.LocalMachine.CreateSubKey(@"Software\Triangulator");
                dontaskagain.SetValue("dont_ask_again", 0);
                dontaskagain.Close();
                Process.Start("Configure_Window.exe");
                Application.Exit();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[2];
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //End of move around tab pages





        private void n41c_TextChanged(object sender, EventArgs e)
        {

        }



//Calculate:

        private void button1_Click(object sender, EventArgs e)
        {

            DMStoDEG dms2degConverter = new DMStoDEG();
            process_data[] inst_station = new process_data[4];
            process_data process = new process_data();
            inst_station[0] = new process_data();
            inst_station[1] = new process_data();
            inst_station[2] = new process_data();
            inst_station[3] = new process_data();


            process_data output_angles = new process_data();
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            //Save readings to registry
            RegistryKey setData = Registry.LocalMachine.CreateSubKey(@"Software\Triangulator");
            setData.SetValue("n11a", n11a.Text);
            setData.SetValue("n21a", n21a.Text);
            setData.SetValue("n31a", n31a.Text);
            setData.SetValue("n41a", n41a.Text);
            setData.SetValue("n51a", n51a.Text);

            setData.SetValue("n12a", n12a.Text);
            setData.SetValue("n22a", n22a.Text);
            setData.SetValue("n32a", n32a.Text);
            setData.SetValue("n42a", n42a.Text);
            setData.SetValue("n52a", n52a.Text);

            setData.SetValue("n13a", n13a.Text);
            setData.SetValue("n23a", n23a.Text);
            setData.SetValue("n33a", n33a.Text);
            setData.SetValue("n43a", n43a.Text);
            setData.SetValue("n53a", n53a.Text);

            setData.SetValue("n14a", n14a.Text);
            setData.SetValue("n24a", n24a.Text);
            setData.SetValue("n34a", n34a.Text);
            setData.SetValue("n44a", n44a.Text);
            setData.SetValue("n54a", n54a.Text);

            //Reverse

            setData.SetValue("r11a", r11a.Text);
            setData.SetValue("r21a", r21a.Text);
            setData.SetValue("r31a", r31a.Text);
            setData.SetValue("r41a", r41a.Text);
            setData.SetValue("r51a", r51a.Text);

            setData.SetValue("r12a", r12a.Text);
            setData.SetValue("r22a", r22a.Text);
            setData.SetValue("r32a", r32a.Text);
            setData.SetValue("r42a", r42a.Text);
            setData.SetValue("r52a", r52a.Text);

            setData.SetValue("r13a", r13a.Text);
            setData.SetValue("r23a", r23a.Text);
            setData.SetValue("r33a", r33a.Text);
            setData.SetValue("r43a", r43a.Text);
            setData.SetValue("r53a", r53a.Text);

            setData.SetValue("r14a", r14a.Text);
            setData.SetValue("r24a", r24a.Text);
            setData.SetValue("r34a", r34a.Text);
            setData.SetValue("r44a", r44a.Text);
            setData.SetValue("r54a", r54a.Text);

            //Inst Station B

            setData.SetValue("n11b", n11b.Text);
            setData.SetValue("n21b", n21b.Text);
            setData.SetValue("n31b", n31b.Text);
            setData.SetValue("n41b", n41b.Text);
            setData.SetValue("n51b", n51b.Text);

            setData.SetValue("n12b", n12b.Text);
            setData.SetValue("n22b", n22b.Text);
            setData.SetValue("n32b", n32b.Text);
            setData.SetValue("n42b", n42b.Text);
            setData.SetValue("n52b", n52b.Text);

            setData.SetValue("n13b", n13b.Text);
            setData.SetValue("n23b", n23b.Text);
            setData.SetValue("n33b", n33b.Text);
            setData.SetValue("n43b", n43b.Text);
            setData.SetValue("n53b", n53b.Text);

            setData.SetValue("n14b", n14b.Text);
            setData.SetValue("n24b", n24b.Text);
            setData.SetValue("n34b", n34b.Text);
            setData.SetValue("n44b", n44b.Text);
            setData.SetValue("n54b", n54b.Text);

            //Reverse

            setData.SetValue("r11b", r11b.Text);
            setData.SetValue("r21b", r21b.Text);
            setData.SetValue("r31b", r31b.Text);
            setData.SetValue("r41b", r41b.Text);
            setData.SetValue("r51b", r51b.Text);

            setData.SetValue("r12b", r12b.Text);
            setData.SetValue("r22b", r22b.Text);
            setData.SetValue("r32b", r32b.Text);
            setData.SetValue("r42b", r42b.Text);
            setData.SetValue("r52b", r52b.Text);

            setData.SetValue("r13b", r13b.Text);
            setData.SetValue("r23b", r23b.Text);
            setData.SetValue("r33b", r33b.Text);
            setData.SetValue("r43b", r43b.Text);
            setData.SetValue("r53b", r53b.Text);

            setData.SetValue("r14b", r14b.Text);
            setData.SetValue("r24b", r24b.Text);
            setData.SetValue("r34b", r34b.Text);
            setData.SetValue("r44b", r44b.Text);
            setData.SetValue("r54b", r54b.Text);

            //Inst Station C

            setData.SetValue("n11c", n11c.Text);
            setData.SetValue("n21c", n21c.Text);
            setData.SetValue("n31c", n31c.Text);
            setData.SetValue("n41c", n41c.Text);
            setData.SetValue("n51c", n51c.Text);

            setData.SetValue("n12c", n12c.Text);
            setData.SetValue("n22c", n22c.Text);
            setData.SetValue("n32c", n32c.Text);
            setData.SetValue("n42c", n42c.Text);
            setData.SetValue("n52c", n52c.Text);

            setData.SetValue("n13c", n13c.Text);
            setData.SetValue("n23c", n23c.Text);
            setData.SetValue("n33c", n33c.Text);
            setData.SetValue("n43c", n43c.Text);
            setData.SetValue("n53c", n53c.Text);

            setData.SetValue("n14c", n14c.Text);
            setData.SetValue("n24c", n24c.Text);
            setData.SetValue("n34c", n34c.Text);
            setData.SetValue("n44c", n44c.Text);
            setData.SetValue("n54c", n54c.Text);

            //Reverse            

            setData.SetValue("r11c", r11c.Text);
            setData.SetValue("r21c", r21c.Text);
            setData.SetValue("r31c", r31c.Text);
            setData.SetValue("r41c", r41c.Text);
            setData.SetValue("r51c", r51c.Text);

            setData.SetValue("r12c", r12c.Text);
            setData.SetValue("r22c", r22c.Text);
            setData.SetValue("r32c", r32c.Text);
            setData.SetValue("r42c", r42c.Text);
            setData.SetValue("r52c", r52c.Text);

            setData.SetValue("r13c", r13c.Text);
            setData.SetValue("r23c", r23c.Text);
            setData.SetValue("r33c", r33c.Text);
            setData.SetValue("r43c", r43c.Text);
            setData.SetValue("r53c", r53c.Text);

            setData.SetValue("r14c", r14c.Text);
            setData.SetValue("r24c", r24c.Text);
            setData.SetValue("r34c", r34c.Text);
            setData.SetValue("r44c", r44c.Text);
            setData.SetValue("r54c", r54c.Text);

            //Inst Staion D

            setData.SetValue("n11d", n11d.Text);
            setData.SetValue("n21d", n21d.Text);
            setData.SetValue("n31d", n31d.Text);
            setData.SetValue("n41d", n41d.Text);
            setData.SetValue("n51d", n51d.Text);

            setData.SetValue("n12d", n12d.Text);
            setData.SetValue("n22d", n22d.Text);
            setData.SetValue("n32d", n32d.Text);
            setData.SetValue("n42d", n42d.Text);
            setData.SetValue("n52d", n52d.Text);

            setData.SetValue("n13d", n13d.Text);
            setData.SetValue("n23d", n23d.Text);
            setData.SetValue("n33d", n33d.Text);
            setData.SetValue("n43d", n43d.Text);
            setData.SetValue("n53d", n53d.Text);

            setData.SetValue("n14d", n14d.Text);
            setData.SetValue("n24d", n24d.Text);
            setData.SetValue("n34d", n34d.Text);
            setData.SetValue("n44d", n44d.Text);
            setData.SetValue("n54d", n54d.Text);

            //Reverse

            setData.SetValue("r11d", r11d.Text);
            setData.SetValue("r21d", r21d.Text);
            setData.SetValue("r31d", r31d.Text);
            setData.SetValue("r41d", r41d.Text);
            setData.SetValue("r51d", r51d.Text);

            setData.SetValue("r12d", r12d.Text);
            setData.SetValue("r22d", r22d.Text);
            setData.SetValue("r32d", r32d.Text);
            setData.SetValue("r42d", r42d.Text);
            setData.SetValue("r52d", r52d.Text);

            setData.SetValue("r13d", r13d.Text);
            setData.SetValue("r23d", r23d.Text);
            setData.SetValue("r33d", r33d.Text);
            setData.SetValue("r43d", r43d.Text);
            setData.SetValue("r53d", r53d.Text);

            setData.SetValue("r14d", r14d.Text);
            setData.SetValue("r24d", r24d.Text);
            setData.SetValue("r34d", r34d.Text);
            setData.SetValue("r44d", r44d.Text);
            setData.SetValue("r54d", r54d.Text);

            

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////           
            try {
                if (angle_format == "deg")
                {
                    //Inst_Station A:  
                    //Normal Angles

                    inst_station[0].data[0, 0, 0] = double.Parse(n11a.Text);
                    inst_station[0].data[0, 0, 1] = double.Parse(n21a.Text);
                    inst_station[0].data[0, 0, 2] = double.Parse(n31a.Text);
                    inst_station[0].data[0, 0, 3] = double.Parse(n41a.Text);
                    inst_station[0].data[0, 0, 4] = double.Parse(n51a.Text);

                    inst_station[0].data[0, 1, 0] = double.Parse(n12a.Text);
                    inst_station[0].data[0, 1, 1] = double.Parse(n22a.Text);
                    inst_station[0].data[0, 1, 2] = double.Parse(n32a.Text);
                    inst_station[0].data[0, 1, 3] = double.Parse(n42a.Text);
                    inst_station[0].data[0, 1, 4] = double.Parse(n52a.Text);

                    inst_station[0].data[0, 2, 0] = double.Parse(n13a.Text);
                    inst_station[0].data[0, 2, 1] = double.Parse(n23a.Text);
                    inst_station[0].data[0, 2, 2] = double.Parse(n33a.Text);
                    inst_station[0].data[0, 2, 3] = double.Parse(n43a.Text);
                    inst_station[0].data[0, 2, 4] = double.Parse(n53a.Text);

                    inst_station[0].data[0, 3, 0] = double.Parse(n14a.Text);
                    inst_station[0].data[0, 3, 1] = double.Parse(n24a.Text);
                    inst_station[0].data[0, 3, 2] = double.Parse(n34a.Text);
                    inst_station[0].data[0, 3, 3] = double.Parse(n44a.Text);
                    inst_station[0].data[0, 3, 4] = double.Parse(n54a.Text);

                    //Reverse Angles
                    inst_station[0].data[1, 0, 0] = double.Parse(r11a.Text);
                    inst_station[0].data[1, 0, 1] = double.Parse(r21a.Text);
                    inst_station[0].data[1, 0, 2] = double.Parse(r31a.Text);
                    inst_station[0].data[1, 0, 3] = double.Parse(r41a.Text);
                    inst_station[0].data[1, 0, 4] = double.Parse(r51a.Text);

                    inst_station[0].data[1, 1, 0] = double.Parse(r12a.Text);
                    inst_station[0].data[1, 1, 1] = double.Parse(r22a.Text);
                    inst_station[0].data[1, 1, 2] = double.Parse(r32a.Text);
                    inst_station[0].data[1, 1, 3] = double.Parse(r42a.Text);
                    inst_station[0].data[1, 1, 4] = double.Parse(r52a.Text);

                    inst_station[0].data[1, 2, 0] = double.Parse(r13a.Text);
                    inst_station[0].data[1, 2, 1] = double.Parse(r23a.Text);
                    inst_station[0].data[1, 2, 2] = double.Parse(r33a.Text);
                    inst_station[0].data[1, 2, 3] = double.Parse(r43a.Text);
                    inst_station[0].data[1, 2, 4] = double.Parse(r53a.Text);

                    inst_station[0].data[1, 3, 0] = double.Parse(r14a.Text);
                    inst_station[0].data[1, 3, 1] = double.Parse(r24a.Text);
                    inst_station[0].data[1, 3, 2] = double.Parse(r34a.Text);
                    inst_station[0].data[1, 3, 3] = double.Parse(r44a.Text);
                    inst_station[0].data[1, 3, 4] = double.Parse(r54a.Text);

                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //Inst_Station: B
                    //Normal Angles
                    inst_station[1].data[0, 0, 0] = double.Parse(n11b.Text);
                    inst_station[1].data[0, 0, 1] = double.Parse(n21b.Text);
                    inst_station[1].data[0, 0, 2] = double.Parse(n31b.Text);
                    inst_station[1].data[0, 0, 3] = double.Parse(n41b.Text);
                    inst_station[1].data[0, 0, 4] = double.Parse(n51b.Text);

                    inst_station[1].data[0, 1, 0] = double.Parse(n12b.Text);
                    inst_station[1].data[0, 1, 1] = double.Parse(n22b.Text);
                    inst_station[1].data[0, 1, 2] = double.Parse(n32b.Text);
                    inst_station[1].data[0, 1, 3] = double.Parse(n42b.Text);
                    inst_station[1].data[0, 1, 4] = double.Parse(n52b.Text);

                    inst_station[1].data[0, 2, 0] = double.Parse(n13b.Text);
                    inst_station[1].data[0, 2, 1] = double.Parse(n23b.Text);
                    inst_station[1].data[0, 2, 2] = double.Parse(n33b.Text);
                    inst_station[1].data[0, 2, 3] = double.Parse(n43b.Text);
                    inst_station[1].data[0, 2, 4] = double.Parse(n53b.Text);

                    inst_station[1].data[0, 3, 0] = double.Parse(n14b.Text);
                    inst_station[1].data[0, 3, 1] = double.Parse(n24b.Text);
                    inst_station[1].data[0, 3, 2] = double.Parse(n34b.Text);
                    inst_station[1].data[0, 3, 3] = double.Parse(n44b.Text);
                    inst_station[1].data[0, 3, 4] = double.Parse(n54b.Text);

                    //Reverse Angles
                    inst_station[1].data[1, 0, 0] = double.Parse(r11b.Text);
                    inst_station[1].data[1, 0, 1] = double.Parse(r21b.Text);
                    inst_station[1].data[1, 0, 2] = double.Parse(r31b.Text);
                    inst_station[1].data[1, 0, 3] = double.Parse(r41b.Text);
                    inst_station[1].data[1, 0, 4] = double.Parse(r51b.Text);

                    inst_station[1].data[1, 1, 0] = double.Parse(r12b.Text);
                    inst_station[1].data[1, 1, 1] = double.Parse(r22b.Text);
                    inst_station[1].data[1, 1, 2] = double.Parse(r32b.Text);
                    inst_station[1].data[1, 1, 3] = double.Parse(r42b.Text);
                    inst_station[1].data[1, 1, 4] = double.Parse(r52b.Text);

                    inst_station[1].data[1, 2, 0] = double.Parse(r13b.Text);
                    inst_station[1].data[1, 2, 1] = double.Parse(r23b.Text);
                    inst_station[1].data[1, 2, 2] = double.Parse(r33b.Text);
                    inst_station[1].data[1, 2, 3] = double.Parse(r43b.Text);
                    inst_station[1].data[1, 2, 4] = double.Parse(r53b.Text);

                    inst_station[1].data[1, 3, 0] = double.Parse(r14b.Text);
                    inst_station[1].data[1, 3, 1] = double.Parse(r24b.Text);
                    inst_station[1].data[1, 3, 2] = double.Parse(r34b.Text);
                    inst_station[1].data[1, 3, 3] = double.Parse(r44b.Text);
                    inst_station[1].data[1, 3, 4] = double.Parse(r54b.Text);


                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    //Inst_Station: c
                    //Normal Angles
                    inst_station[2].data[0, 0, 0] = double.Parse(n11c.Text);
                    inst_station[2].data[0, 0, 1] = double.Parse(n21c.Text);
                    inst_station[2].data[0, 0, 2] = double.Parse(n31c.Text);
                    inst_station[2].data[0, 0, 3] = double.Parse(n41c.Text);
                    inst_station[2].data[0, 0, 4] = double.Parse(n51c.Text);

                    inst_station[2].data[0, 1, 0] = double.Parse(n12c.Text);
                    inst_station[2].data[0, 1, 1] = double.Parse(n22c.Text);
                    inst_station[2].data[0, 1, 2] = double.Parse(n32c.Text);
                    inst_station[2].data[0, 1, 3] = double.Parse(n42c.Text);
                    inst_station[2].data[0, 1, 4] = double.Parse(n52c.Text);

                    inst_station[2].data[0, 2, 0] = double.Parse(n13c.Text);
                    inst_station[2].data[0, 2, 1] = double.Parse(n23c.Text);
                    inst_station[2].data[0, 2, 2] = double.Parse(n33c.Text);
                    inst_station[2].data[0, 2, 3] = double.Parse(n43c.Text);
                    inst_station[2].data[0, 2, 4] = double.Parse(n53c.Text);

                    inst_station[2].data[0, 3, 0] = double.Parse(n14c.Text);
                    inst_station[2].data[0, 3, 1] = double.Parse(n24c.Text);
                    inst_station[2].data[0, 3, 2] = double.Parse(n34c.Text);
                    inst_station[2].data[0, 3, 3] = double.Parse(n44c.Text);
                    inst_station[2].data[0, 3, 4] = double.Parse(n54c.Text);

                    //Reverse Angles
                    inst_station[2].data[1, 0, 0] = double.Parse(r11c.Text);
                    inst_station[2].data[1, 0, 1] = double.Parse(r21c.Text);
                    inst_station[2].data[1, 0, 2] = double.Parse(r31c.Text);
                    inst_station[2].data[1, 0, 3] = double.Parse(r41c.Text);
                    inst_station[2].data[1, 0, 4] = double.Parse(r51c.Text);

                    inst_station[2].data[1, 1, 0] = double.Parse(r12c.Text);
                    inst_station[2].data[1, 1, 1] = double.Parse(r22c.Text);
                    inst_station[2].data[1, 1, 2] = double.Parse(r32c.Text);
                    inst_station[2].data[1, 1, 3] = double.Parse(r42c.Text);
                    inst_station[2].data[1, 1, 4] = double.Parse(r52c.Text);

                    inst_station[2].data[1, 2, 0] = double.Parse(r13c.Text);
                    inst_station[2].data[1, 2, 1] = double.Parse(r23c.Text);
                    inst_station[2].data[1, 2, 2] = double.Parse(r33c.Text);
                    inst_station[2].data[1, 2, 3] = double.Parse(r43c.Text);
                    inst_station[2].data[1, 2, 4] = double.Parse(r53c.Text);

                    inst_station[2].data[1, 3, 0] = double.Parse(r14c.Text);
                    inst_station[2].data[1, 3, 1] = double.Parse(r24c.Text);
                    inst_station[2].data[1, 3, 2] = double.Parse(r34c.Text);
                    inst_station[2].data[1, 3, 3] = double.Parse(r44c.Text);
                    inst_station[2].data[1, 3, 4] = double.Parse(r54c.Text);


                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



                    //Inst_Station: D
                    //Normal Angles
                    inst_station[3].data[0, 0, 0] = double.Parse(n11d.Text);
                    inst_station[3].data[0, 0, 1] = double.Parse(n21d.Text);
                    inst_station[3].data[0, 0, 2] = double.Parse(n31d.Text);
                    inst_station[3].data[0, 0, 3] = double.Parse(n41d.Text);
                    inst_station[3].data[0, 0, 4] = double.Parse(n51d.Text);

                    inst_station[3].data[0, 1, 0] = double.Parse(n12d.Text);
                    inst_station[3].data[0, 1, 1] = double.Parse(n22d.Text);
                    inst_station[3].data[0, 1, 2] = double.Parse(n32d.Text);
                    inst_station[3].data[0, 1, 3] = double.Parse(n42d.Text);
                    inst_station[3].data[0, 1, 4] = double.Parse(n52d.Text);

                    inst_station[3].data[0, 2, 0] = double.Parse(n13d.Text);
                    inst_station[3].data[0, 2, 1] = double.Parse(n23d.Text);
                    inst_station[3].data[0, 2, 2] = double.Parse(n33d.Text);
                    inst_station[3].data[0, 2, 3] = double.Parse(n43d.Text);
                    inst_station[3].data[0, 2, 4] = double.Parse(n53d.Text);

                    inst_station[3].data[0, 3, 0] = double.Parse(n14d.Text);
                    inst_station[3].data[0, 3, 1] = double.Parse(n24d.Text);
                    inst_station[3].data[0, 3, 2] = double.Parse(n34d.Text);
                    inst_station[3].data[0, 3, 3] = double.Parse(n44d.Text);
                    inst_station[3].data[0, 3, 4] = double.Parse(n54d.Text);

                    //Reverse Angles
                    inst_station[3].data[1, 0, 0] = double.Parse(r11d.Text);
                    inst_station[3].data[1, 0, 1] = double.Parse(r21d.Text);
                    inst_station[3].data[1, 0, 2] = double.Parse(r31d.Text);
                    inst_station[3].data[1, 0, 3] = double.Parse(r41d.Text);
                    inst_station[3].data[1, 0, 4] = double.Parse(r51d.Text);

                    inst_station[3].data[1, 1, 0] = double.Parse(r12d.Text);
                    inst_station[3].data[1, 1, 1] = double.Parse(r22d.Text);
                    inst_station[3].data[1, 1, 2] = double.Parse(r32d.Text);
                    inst_station[3].data[1, 1, 3] = double.Parse(r42d.Text);
                    inst_station[3].data[1, 1, 4] = double.Parse(r52d.Text);

                    inst_station[3].data[1, 2, 0] = double.Parse(r13d.Text);
                    inst_station[3].data[1, 2, 1] = double.Parse(r23d.Text);
                    inst_station[3].data[1, 2, 2] = double.Parse(r33d.Text);
                    inst_station[3].data[1, 2, 3] = double.Parse(r43d.Text);
                    inst_station[3].data[1, 2, 4] = double.Parse(r53d.Text);

                    inst_station[3].data[1, 3, 0] = double.Parse(r14d.Text);
                    inst_station[3].data[1, 3, 1] = double.Parse(r24d.Text);
                    inst_station[3].data[1, 3, 2] = double.Parse(r34d.Text);
                    inst_station[3].data[1, 3, 3] = double.Parse(r44d.Text);
                    inst_station[3].data[1, 3, 4] = double.Parse(r54d.Text);

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                }
                else if (angle_format == "dms")
                {
                    //Inst_Station A:  
                    //Normal Angles

                    inst_station[0].data[0, 0, 0] = dms2degConverter.dms2deg(n11a.Text);
                    inst_station[0].data[0, 0, 1] = dms2degConverter.dms2deg(n21a.Text);
                    inst_station[0].data[0, 0, 2] = dms2degConverter.dms2deg(n31a.Text);
                    inst_station[0].data[0, 0, 3] = dms2degConverter.dms2deg(n41a.Text);
                    inst_station[0].data[0, 0, 4] = dms2degConverter.dms2deg(n51a.Text);

                    inst_station[0].data[0, 1, 0] = dms2degConverter.dms2deg(n12a.Text);
                    inst_station[0].data[0, 1, 1] = dms2degConverter.dms2deg(n22a.Text);
                    inst_station[0].data[0, 1, 2] = dms2degConverter.dms2deg(n32a.Text);
                    inst_station[0].data[0, 1, 3] = dms2degConverter.dms2deg(n42a.Text);
                    inst_station[0].data[0, 1, 4] = dms2degConverter.dms2deg(n52a.Text);

                    inst_station[0].data[0, 2, 0] = dms2degConverter.dms2deg(n13a.Text);
                    inst_station[0].data[0, 2, 1] = dms2degConverter.dms2deg(n23a.Text);
                    inst_station[0].data[0, 2, 2] = dms2degConverter.dms2deg(n33a.Text);
                    inst_station[0].data[0, 2, 3] = dms2degConverter.dms2deg(n43a.Text);
                    inst_station[0].data[0, 2, 4] = dms2degConverter.dms2deg(n53a.Text);

                    inst_station[0].data[0, 3, 0] = dms2degConverter.dms2deg(n14a.Text);
                    inst_station[0].data[0, 3, 1] = dms2degConverter.dms2deg(n24a.Text);
                    inst_station[0].data[0, 3, 2] = dms2degConverter.dms2deg(n34a.Text);
                    inst_station[0].data[0, 3, 3] = dms2degConverter.dms2deg(n44a.Text);
                    inst_station[0].data[0, 3, 4] = dms2degConverter.dms2deg(n54a.Text);

                    //Reverse Angles
                    inst_station[0].data[1, 0, 0] = dms2degConverter.dms2deg(r11a.Text);
                    inst_station[0].data[1, 0, 1] = dms2degConverter.dms2deg(r21a.Text);
                    inst_station[0].data[1, 0, 2] = dms2degConverter.dms2deg(r31a.Text);
                    inst_station[0].data[1, 0, 3] = dms2degConverter.dms2deg(r41a.Text);
                    inst_station[0].data[1, 0, 4] = dms2degConverter.dms2deg(r51a.Text);

                    inst_station[0].data[1, 1, 0] = dms2degConverter.dms2deg(r12a.Text);
                    inst_station[0].data[1, 1, 1] = dms2degConverter.dms2deg(r22a.Text);
                    inst_station[0].data[1, 1, 2] = dms2degConverter.dms2deg(r32a.Text);
                    inst_station[0].data[1, 1, 3] = dms2degConverter.dms2deg(r42a.Text);
                    inst_station[0].data[1, 1, 4] = dms2degConverter.dms2deg(r52a.Text);

                    inst_station[0].data[1, 2, 0] = dms2degConverter.dms2deg(r13a.Text);
                    inst_station[0].data[1, 2, 1] = dms2degConverter.dms2deg(r23a.Text);
                    inst_station[0].data[1, 2, 2] = dms2degConverter.dms2deg(r33a.Text);
                    inst_station[0].data[1, 2, 3] = dms2degConverter.dms2deg(r43a.Text);
                    inst_station[0].data[1, 2, 4] = dms2degConverter.dms2deg(r53a.Text);

                    inst_station[0].data[1, 3, 0] = dms2degConverter.dms2deg(r14a.Text);
                    inst_station[0].data[1, 3, 1] = dms2degConverter.dms2deg(r24a.Text);
                    inst_station[0].data[1, 3, 2] = dms2degConverter.dms2deg(r34a.Text);
                    inst_station[0].data[1, 3, 3] = dms2degConverter.dms2deg(r44a.Text);
                    inst_station[0].data[1, 3, 4] = dms2degConverter.dms2deg(r54a.Text);

                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //Inst_Station: B
                    //Normal Angles
                    inst_station[1].data[0, 0, 0] = dms2degConverter.dms2deg(n11b.Text);
                    inst_station[1].data[0, 0, 1] = dms2degConverter.dms2deg(n21b.Text);
                    inst_station[1].data[0, 0, 2] = dms2degConverter.dms2deg(n31b.Text);
                    inst_station[1].data[0, 0, 3] = dms2degConverter.dms2deg(n41b.Text);
                    inst_station[1].data[0, 0, 4] = dms2degConverter.dms2deg(n51b.Text);

                    inst_station[1].data[0, 1, 0] = dms2degConverter.dms2deg(n12b.Text);
                    inst_station[1].data[0, 1, 1] = dms2degConverter.dms2deg(n22b.Text);
                    inst_station[1].data[0, 1, 2] = dms2degConverter.dms2deg(n32b.Text);
                    inst_station[1].data[0, 1, 3] = dms2degConverter.dms2deg(n42b.Text);
                    inst_station[1].data[0, 1, 4] = dms2degConverter.dms2deg(n52b.Text);

                    inst_station[1].data[0, 2, 0] = dms2degConverter.dms2deg(n13b.Text);
                    inst_station[1].data[0, 2, 1] = dms2degConverter.dms2deg(n23b.Text);
                    inst_station[1].data[0, 2, 2] = dms2degConverter.dms2deg(n33b.Text);
                    inst_station[1].data[0, 2, 3] = dms2degConverter.dms2deg(n43b.Text);
                    inst_station[1].data[0, 2, 4] = dms2degConverter.dms2deg(n53b.Text);

                    inst_station[1].data[0, 3, 0] = dms2degConverter.dms2deg(n14b.Text);
                    inst_station[1].data[0, 3, 1] = dms2degConverter.dms2deg(n24b.Text);
                    inst_station[1].data[0, 3, 2] = dms2degConverter.dms2deg(n34b.Text);
                    inst_station[1].data[0, 3, 3] = dms2degConverter.dms2deg(n44b.Text);
                    inst_station[1].data[0, 3, 4] = dms2degConverter.dms2deg(n54b.Text);

                    //Reverse Angles
                    inst_station[1].data[1, 0, 0] = dms2degConverter.dms2deg(r11b.Text);
                    inst_station[1].data[1, 0, 1] = dms2degConverter.dms2deg(r21b.Text);
                    inst_station[1].data[1, 0, 2] = dms2degConverter.dms2deg(r31b.Text);
                    inst_station[1].data[1, 0, 3] = dms2degConverter.dms2deg(r41b.Text);
                    inst_station[1].data[1, 0, 4] = dms2degConverter.dms2deg(r51b.Text);

                    inst_station[1].data[1, 1, 0] = dms2degConverter.dms2deg(r12b.Text);
                    inst_station[1].data[1, 1, 1] = dms2degConverter.dms2deg(r22b.Text);
                    inst_station[1].data[1, 1, 2] = dms2degConverter.dms2deg(r32b.Text);
                    inst_station[1].data[1, 1, 3] = dms2degConverter.dms2deg(r42b.Text);
                    inst_station[1].data[1, 1, 4] = dms2degConverter.dms2deg(r52b.Text);

                    inst_station[1].data[1, 2, 0] = dms2degConverter.dms2deg(r13b.Text);
                    inst_station[1].data[1, 2, 1] = dms2degConverter.dms2deg(r23b.Text);
                    inst_station[1].data[1, 2, 2] = dms2degConverter.dms2deg(r33b.Text);
                    inst_station[1].data[1, 2, 3] = dms2degConverter.dms2deg(r43b.Text);
                    inst_station[1].data[1, 2, 4] = dms2degConverter.dms2deg(r53b.Text);

                    inst_station[1].data[1, 3, 0] = dms2degConverter.dms2deg(r14b.Text);
                    inst_station[1].data[1, 3, 1] = dms2degConverter.dms2deg(r24b.Text);
                    inst_station[1].data[1, 3, 2] = dms2degConverter.dms2deg(r34b.Text);
                    inst_station[1].data[1, 3, 3] = dms2degConverter.dms2deg(r44b.Text);
                    inst_station[1].data[1, 3, 4] = dms2degConverter.dms2deg(r54b.Text);


                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    //Inst_Station: c
                    //Normal Angles
                    inst_station[2].data[0, 0, 0] = dms2degConverter.dms2deg(n11c.Text);
                    inst_station[2].data[0, 0, 1] = dms2degConverter.dms2deg(n21c.Text);
                    inst_station[2].data[0, 0, 2] = dms2degConverter.dms2deg(n31c.Text);
                    inst_station[2].data[0, 0, 3] = dms2degConverter.dms2deg(n41c.Text);
                    inst_station[2].data[0, 0, 4] = dms2degConverter.dms2deg(n51c.Text);

                    inst_station[2].data[0, 1, 0] = dms2degConverter.dms2deg(n12c.Text);
                    inst_station[2].data[0, 1, 1] = dms2degConverter.dms2deg(n22c.Text);
                    inst_station[2].data[0, 1, 2] = dms2degConverter.dms2deg(n32c.Text);
                    inst_station[2].data[0, 1, 3] = dms2degConverter.dms2deg(n42c.Text);
                    inst_station[2].data[0, 1, 4] = dms2degConverter.dms2deg(n52c.Text);

                    inst_station[2].data[0, 2, 0] = dms2degConverter.dms2deg(n13c.Text);
                    inst_station[2].data[0, 2, 1] = dms2degConverter.dms2deg(n23c.Text);
                    inst_station[2].data[0, 2, 2] = dms2degConverter.dms2deg(n33c.Text);
                    inst_station[2].data[0, 2, 3] = dms2degConverter.dms2deg(n43c.Text);
                    inst_station[2].data[0, 2, 4] = dms2degConverter.dms2deg(n53c.Text);

                    inst_station[2].data[0, 3, 0] = dms2degConverter.dms2deg(n14c.Text);
                    inst_station[2].data[0, 3, 1] = dms2degConverter.dms2deg(n24c.Text);
                    inst_station[2].data[0, 3, 2] = dms2degConverter.dms2deg(n34c.Text);
                    inst_station[2].data[0, 3, 3] = dms2degConverter.dms2deg(n44c.Text);
                    inst_station[2].data[0, 3, 4] = dms2degConverter.dms2deg(n54c.Text);

                    //Reverse Angles
                    inst_station[2].data[1, 0, 0] = dms2degConverter.dms2deg(r11c.Text);
                    inst_station[2].data[1, 0, 1] = dms2degConverter.dms2deg(r21c.Text);
                    inst_station[2].data[1, 0, 2] = dms2degConverter.dms2deg(r31c.Text);
                    inst_station[2].data[1, 0, 3] = dms2degConverter.dms2deg(r41c.Text);
                    inst_station[2].data[1, 0, 4] = dms2degConverter.dms2deg(r51c.Text);

                    inst_station[2].data[1, 1, 0] = dms2degConverter.dms2deg(r12c.Text);
                    inst_station[2].data[1, 1, 1] = dms2degConverter.dms2deg(r22c.Text);
                    inst_station[2].data[1, 1, 2] = dms2degConverter.dms2deg(r32c.Text);
                    inst_station[2].data[1, 1, 3] = dms2degConverter.dms2deg(r42c.Text);
                    inst_station[2].data[1, 1, 4] = dms2degConverter.dms2deg(r52c.Text);

                    inst_station[2].data[1, 2, 0] = dms2degConverter.dms2deg(r13c.Text);
                    inst_station[2].data[1, 2, 1] = dms2degConverter.dms2deg(r23c.Text);
                    inst_station[2].data[1, 2, 2] = dms2degConverter.dms2deg(r33c.Text);
                    inst_station[2].data[1, 2, 3] = dms2degConverter.dms2deg(r43c.Text);
                    inst_station[2].data[1, 2, 4] = dms2degConverter.dms2deg(r53c.Text);

                    inst_station[2].data[1, 3, 0] = dms2degConverter.dms2deg(r14c.Text);
                    inst_station[2].data[1, 3, 1] = dms2degConverter.dms2deg(r24c.Text);
                    inst_station[2].data[1, 3, 2] = dms2degConverter.dms2deg(r34c.Text);
                    inst_station[2].data[1, 3, 3] = dms2degConverter.dms2deg(r44c.Text);
                    inst_station[2].data[1, 3, 4] = dms2degConverter.dms2deg(r54c.Text);


                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



                    //Inst_Station: D
                    //Normal Angles
                    inst_station[3].data[0, 0, 0] = dms2degConverter.dms2deg(n11d.Text);
                    inst_station[3].data[0, 0, 1] = dms2degConverter.dms2deg(n21d.Text);
                    inst_station[3].data[0, 0, 2] = dms2degConverter.dms2deg(n31d.Text);
                    inst_station[3].data[0, 0, 3] = dms2degConverter.dms2deg(n41d.Text);
                    inst_station[3].data[0, 0, 4] = dms2degConverter.dms2deg(n51d.Text);

                    inst_station[3].data[0, 1, 0] = dms2degConverter.dms2deg(n12d.Text);
                    inst_station[3].data[0, 1, 1] = dms2degConverter.dms2deg(n22d.Text);
                    inst_station[3].data[0, 1, 2] = dms2degConverter.dms2deg(n32d.Text);
                    inst_station[3].data[0, 1, 3] = dms2degConverter.dms2deg(n42d.Text);
                    inst_station[3].data[0, 1, 4] = dms2degConverter.dms2deg(n52d.Text);

                    inst_station[3].data[0, 2, 0] = dms2degConverter.dms2deg(n13d.Text);
                    inst_station[3].data[0, 2, 1] = dms2degConverter.dms2deg(n23d.Text);
                    inst_station[3].data[0, 2, 2] = dms2degConverter.dms2deg(n33d.Text);
                    inst_station[3].data[0, 2, 3] = dms2degConverter.dms2deg(n43d.Text);
                    inst_station[3].data[0, 2, 4] = dms2degConverter.dms2deg(n53d.Text);

                    inst_station[3].data[0, 3, 0] = dms2degConverter.dms2deg(n14d.Text);
                    inst_station[3].data[0, 3, 1] = dms2degConverter.dms2deg(n24d.Text);
                    inst_station[3].data[0, 3, 2] = dms2degConverter.dms2deg(n34d.Text);
                    inst_station[3].data[0, 3, 3] = dms2degConverter.dms2deg(n44d.Text);
                    inst_station[3].data[0, 3, 4] = dms2degConverter.dms2deg(n54d.Text);

                    //Reverse Angles
                    inst_station[3].data[1, 0, 0] = dms2degConverter.dms2deg(r11d.Text);
                    inst_station[3].data[1, 0, 1] = dms2degConverter.dms2deg(r21d.Text);
                    inst_station[3].data[1, 0, 2] = dms2degConverter.dms2deg(r31d.Text);
                    inst_station[3].data[1, 0, 3] = dms2degConverter.dms2deg(r41d.Text);
                    inst_station[3].data[1, 0, 4] = dms2degConverter.dms2deg(r51d.Text);

                    inst_station[3].data[1, 1, 0] = dms2degConverter.dms2deg(r12d.Text);
                    inst_station[3].data[1, 1, 1] = dms2degConverter.dms2deg(r22d.Text);
                    inst_station[3].data[1, 1, 2] = dms2degConverter.dms2deg(r32d.Text);
                    inst_station[3].data[1, 1, 3] = dms2degConverter.dms2deg(r42d.Text);
                    inst_station[3].data[1, 1, 4] = dms2degConverter.dms2deg(r52d.Text);

                    inst_station[3].data[1, 2, 0] = dms2degConverter.dms2deg(r13d.Text);
                    inst_station[3].data[1, 2, 1] = dms2degConverter.dms2deg(r23d.Text);
                    inst_station[3].data[1, 2, 2] = dms2degConverter.dms2deg(r33d.Text);
                    inst_station[3].data[1, 2, 3] = dms2degConverter.dms2deg(r43d.Text);
                    inst_station[3].data[1, 2, 4] = dms2degConverter.dms2deg(r53d.Text);

                    inst_station[3].data[1, 3, 0] = dms2degConverter.dms2deg(r14d.Text);
                    inst_station[3].data[1, 3, 1] = dms2degConverter.dms2deg(r24d.Text);
                    inst_station[3].data[1, 3, 2] = dms2degConverter.dms2deg(r34d.Text);
                    inst_station[3].data[1, 3, 3] = dms2degConverter.dms2deg(r44d.Text);
                    inst_station[3].data[1, 3, 4] = dms2degConverter.dms2deg(r54d.Text);


                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                }
            

            //calculate angles

           
                if (direction == "clockwise")
                {
                    //ClockWise
                    for (int o = 0; o < 4; o++)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                for (int k = 0; k < 4; k++)
                                {
                                    if (inst_station[o].data[i, j, k + 1] - inst_station[o].data[i, j, k] < 0)
                                    {
                                        inst_station[o].angle[i, j, k] = inst_station[o].data[i, j, k + 1] - inst_station[o].data[i, j, k] + 360;
                                    }
                                    else
                                    {
                                        inst_station[o].angle[i, j, k] = inst_station[o].data[i, j, k + 1] - inst_station[o].data[i, j, k];
                                    }
                                }

                            }
                        }
                    }
                }

                else
                {
                    //anticlockwise
                    for (int o = 0; o < 4; o++)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                for (int k = 0; k < 4; k++)
                                {
                                    if (inst_station[o].data[i, j, k] - inst_station[o].data[i, j, k + 1] < 0)
                                    {
                                        inst_station[o].angle[i, j, k] = inst_station[o].data[i, j, k] - inst_station[o].data[i, j, k + 1] + 360;
                                    }
                                    else
                                    {
                                        inst_station[o].angle[i, j, k] = inst_station[o].data[i, j, k] - inst_station[o].data[i, j, k + 1];
                                    }
                                }

                            }
                        }
                    }
                }
               
                //Mean and Variance
                for (int o = 0; o < 4; o++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        inst_station[o].mean[k] = process.mean_calc(inst_station[o].angle[0, 0, k], inst_station[o].angle[0, 1, k], inst_station[o].angle[0, 2, k], inst_station[o].angle[0, 3, k], inst_station[o].angle[1, 0, k], inst_station[o].angle[1, 1, k], inst_station[o].angle[1, 2, k], inst_station[o].angle[1, 3, k]);
                        inst_station[o].var[k] = process.var_calc(inst_station[o].angle[0, 0, k], inst_station[o].angle[0, 1, k], inst_station[o].angle[0, 2, k], inst_station[o].angle[0, 3, k], inst_station[o].angle[1, 0, k], inst_station[o].angle[1, 1, k], inst_station[o].angle[1, 2, k], inst_station[o].angle[1, 3, k]);
                        
                    }
                }


                //Check Horizon Closing Error
                for (int o = 0; o < 4; o++)
                {
                    inst_station[o].correction = 360 - (inst_station[o].mean[0] + inst_station[o].mean[1] + inst_station[o].mean[2] + inst_station[o].mean[3]);

                    if (inst_station[o].correction != 0)
                    {
                        if (inst_station[o].var[0] != 0 || inst_station[o].var[1] != 0 || inst_station[o].var[2] != 0 || inst_station[o].var[3] != 0)
                        {
                            lambda = inst_station[o].correction / (inst_station[o].var[0] + inst_station[o].var[1] + inst_station[o].var[2] + inst_station[o].var[3]);
                            for (int k = 0; k < 4; k++)
                            {
                                inst_station[o].corrected_angles[k] = inst_station[o].mean[k] + lambda * inst_station[o].var[k];
                            }
                        }
                        else
                        {
                            for (int k = 0; k < 4; k++)
                            {
                                inst_station[o].corrected_angles[k] = inst_station[o].mean[k];
                            }
                        }

                    }
                    else
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            inst_station[o].corrected_angles[k] = inst_station[o].mean[k];
                        }
                    }

                }
                
                //End of Check Horizon and Closing Error

                /////////Included angle Correction: 
                double ltheta1 = inst_station[3].corrected_angles[1];
                double ltheta2 = inst_station[0].corrected_angles[2];
                double ltheta3 = inst_station[0].corrected_angles[1];
                double ltheta4 = inst_station[1].corrected_angles[2];
                double ltheta5 = inst_station[1].corrected_angles[1];
                double ltheta6 = inst_station[2].corrected_angles[2];
                double ltheta7 = inst_station[2].corrected_angles[1];
                double ltheta8 = inst_station[3].corrected_angles[2];

                double lvar1 = inst_station[3].var[1];
                double lvar2 = inst_station[0].var[2];
                double lvar3 = inst_station[0].var[1];
                double lvar4 = inst_station[1].var[2];
                double lvar5 = inst_station[1].var[1];
                double lvar6 = inst_station[2].var[2];
                double lvar7 = inst_station[2].var[1];
                double lvar8 = inst_station[3].var[2];

                //Calculate Corrections for 8 included angles and apply them:

                output_angles.inc_corrections = output_angles.conditional_equation(ltheta1, ltheta2, ltheta3, ltheta4, ltheta5, ltheta6, ltheta7, ltheta8, lvar1, lvar2, lvar3, lvar4, lvar5, lvar6, lvar7, lvar8);

                output_angles.inc_corrected_angles[0] = ltheta1 + output_angles.inc_corrections[0, 0];
                output_angles.inc_corrected_angles[1] = ltheta2 + output_angles.inc_corrections[1, 0];
                output_angles.inc_corrected_angles[2] = ltheta3 + output_angles.inc_corrections[2, 0];
                output_angles.inc_corrected_angles[3] = ltheta4 + output_angles.inc_corrections[3, 0];
                output_angles.inc_corrected_angles[4] = ltheta5 + output_angles.inc_corrections[4, 0];
                output_angles.inc_corrected_angles[5] = ltheta6 + output_angles.inc_corrections[5, 0];
                output_angles.inc_corrected_angles[6] = ltheta7 + output_angles.inc_corrections[6, 0];
                output_angles.inc_corrected_angles[7] = ltheta8 + output_angles.inc_corrections[7, 0];




                //Save the corrected included angles to registry:
                setData.SetValue("T1", output_angles.inc_corrected_angles[0]);
                setData.SetValue("T2", output_angles.inc_corrected_angles[1]);
                setData.SetValue("T3", output_angles.inc_corrected_angles[2]);
                setData.SetValue("T4", output_angles.inc_corrected_angles[3]);
                setData.SetValue("T5", output_angles.inc_corrected_angles[4]);
                setData.SetValue("T6", output_angles.inc_corrected_angles[5]);
                setData.SetValue("T7", output_angles.inc_corrected_angles[6]);
                setData.SetValue("T8", output_angles.inc_corrected_angles[7]);

                setData.SetValue("Var1", lvar1);
                setData.SetValue("Var2", lvar2);
                setData.SetValue("Var3", lvar3);
                setData.SetValue("Var4", lvar4);
                setData.SetValue("Var5", lvar5);
                setData.SetValue("Var6", lvar6);
                setData.SetValue("Var7", lvar7);
                setData.SetValue("Var8", lvar8);

                setData.Close();
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        
            
            

    }
}
