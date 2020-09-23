using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using DEGtoDMSdll;

namespace Main
{
    public partial class Form2 : Form
    {
        public string[] angles = new string[8];
        public string[] variance = new string[8];
        public double[] weight = new double[8];
        public string[] station = new string[5];
        public string angle_format;
        public Form2()
        {
            InitializeComponent();
            RegistryKey reg = Registry.LocalMachine.OpenSubKey(@"Software\Triangulator");
            if(reg!=null)
            {
                //Angel data

                angles[0] = reg.GetValue("T1").ToString();
                angles[1] = reg.GetValue("T2").ToString();
                angles[2] = reg.GetValue("T3").ToString();
                angles[3] = reg.GetValue("T4").ToString();
                angles[4] = reg.GetValue("T5").ToString();
                angles[5] = reg.GetValue("T6").ToString();
                angles[6] = reg.GetValue("T7").ToString();
                angles[7] = reg.GetValue("T8").ToString();

                //Variance Data
                variance[0] = reg.GetValue("Var1").ToString();
                variance[1] = reg.GetValue("Var2").ToString();
                variance[2] = reg.GetValue("Var3").ToString();
                variance[3] = reg.GetValue("Var4").ToString();
                variance[4] = reg.GetValue("Var5").ToString();
                variance[5] = reg.GetValue("Var6").ToString();
                variance[6] = reg.GetValue("Var7").ToString();
                variance[7] = reg.GetValue("Var8").ToString();

                //Station data

                station[0] = reg.GetValue("s1").ToString();
                station[1] = reg.GetValue("s2").ToString();
                station[2] = reg.GetValue("s3").ToString();
                station[3] = reg.GetValue("s4").ToString();
                station[4] = reg.GetValue("s5").ToString();
                reg.Close();
            }
        }

       

        private void Form2_Load(object sender, EventArgs e)
        {
            //Put Stations


            a1.Text = station[1] + station[0] + station[2];
            a2.Text = station[0] + station[1] + station[3];
            a3.Text = station[2] + station[1] + station[3];
            a4.Text = station[0] + station[2] + station[1];
            a5.Text = station[3] + station[2] + station[0];
            a6.Text = station[1] + station[3] + station[2];
            a7.Text = station[0] + station[3] + station[1];
            a8.Text = station[2] + station[0] + station[3];

      
            //Put Angles


                t1.Text = angles[2];
                t2.Text = angles[3];
                t3.Text = angles[4];
                t4.Text = angles[5];
                t5.Text = angles[6];
                t6.Text = angles[7];
                t7.Text = angles[0];
                t8.Text = angles[1];

            //Calculate Weight
            weight[0] = 1 / double.Parse(variance[0]);
            weight[1] = 1 / double.Parse(variance[1]);
            weight[2] = 1 / double.Parse(variance[2]);
            weight[3] = 1 / double.Parse(variance[3]);
            weight[4] = 1 / double.Parse(variance[4]);
            weight[5] = 1 / double.Parse(variance[5]);
            weight[6] = 1 / double.Parse(variance[6]);
            weight[7] = 1 / double.Parse(variance[7]);

            //Put Weight
            w1.Text = weight[2].ToString();
            w2.Text = weight[3].ToString();
            w3.Text = weight[4].ToString();
            w4.Text = weight[5].ToString();
            w5.Text = weight[6].ToString();
            w6.Text = weight[7].ToString();
            w7.Text = weight[0].ToString();
            w8.Text = weight[1].ToString();


        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            DEGtoDMS obj = new DEGtoDMS();
            t1.Text = obj.deg2dms(angles[2]);
            t2.Text = obj.deg2dms(angles[3]);
            t3.Text = obj.deg2dms(angles[4]);
            t4.Text = obj.deg2dms(angles[5]);
            t5.Text = obj.deg2dms(angles[6]);
            t6.Text = obj.deg2dms(angles[7]);
            t7.Text = obj.deg2dms(angles[0]);
            t8.Text = obj.deg2dms(angles[1]);

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            t1.Text = angles[2];
            t2.Text = angles[3];
            t3.Text = angles[4];
            t4.Text = angles[5];
            t5.Text = angles[6];
            t6.Text = angles[7];
            t7.Text = angles[0];
            t8.Text = angles[1];

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form3 save_from = new Main.Form3();
            save_from.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
