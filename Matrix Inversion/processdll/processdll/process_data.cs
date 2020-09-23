using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace processdll
{
    public class process_data
    {
        public double[,,] data = new double[2, 4, 5];
        public double[,,] angle = new double[2, 4, 4];
        public double[] mean = new double[4];
        public double[] var = new double[4];
        public double[] corrected_angles = new double[4];
        public double[,] inc_corrections = new double[8,1];
        public double[] inc_corrected_angles = new double[8];
        
        public double correction;
       
        public double max(double a,double b,double c,double d,double e,double f,double g,double h)
        {
            double max;
            double[] max_data = new double[8];
            max_data[0] = a;
            max_data[1] = b;
            max_data[2] = c;
            max_data[3] = d;
            max_data[4] = e;
            max_data[5] = f;
            max_data[6] = g;
            max_data[7] = h;

            max = max_data[0];
            for(int i=0;i<8;i++)
            {
                if (max_data[i] >= max)
                    max = max_data[i];
            }
            return max;
        }


        public double min(double a, double b, double c, double d, double e, double f, double g, double h)
        {
            double min;
            double[] min_data = new double[8];
            min_data[0] = a;
            min_data[1] = b;
            min_data[2] = c;
            min_data[3] = d;
            min_data[4] = e;
            min_data[5] = f;
            min_data[6] = g;
            min_data[7] = h;

            min = min_data[0];
            for (int i = 0; i < 8; i++)
            {
                if (min_data[i] <= min)
                    min = min_data[i];
            }
            return min;
        }



        public double mean_calc(double a, double b, double c, double d, double e, double f, double g, double h)
        {

            return (a + b + c + d + e + f + g + h) / 8;

        }

        public double var_calc(double a, double b, double c, double d, double e, double f, double g, double h)
        {
            double sq=0;
            double[] var_data = { a, b, c, d, e, f, g, h };
            double mean = (a + b + c + d + e + f + g + h) / 8;

            for(int i=0;i<8;i++)
            {
                sq=sq+(var_data[i]*var_data[i]);
            }

            return (sq - (mean * mean * 8)) / 8;

        }

        public double[,] conditional_equation(double theta1, double theta2,double theta3, double theta4, double theta5, double theta6, double theta7, double theta8, double variance1,double variance2,double variance3,double variance4,double variance5,double variance6,double variance7,double variance8)
        {
            double logsin1 = Math.Log10(Math.Sin(theta1 * Math.PI / 180));
            double logsin2 = Math.Log10(Math.Sin(theta2 * Math.PI / 180));
            double logsin3 = Math.Log10(Math.Sin(theta3 * Math.PI / 180));
            double logsin4 = Math.Log10(Math.Sin(theta4 * Math.PI / 180));
            double logsin5 = Math.Log10(Math.Sin(theta5 * Math.PI / 180));
            double logsin6 = Math.Log10(Math.Sin(theta6 * Math.PI / 180));
            double logsin7 = Math.Log10(Math.Sin(theta7 * Math.PI / 180));
            double logsin8 = Math.Log10(Math.Sin(theta8 * Math.PI / 180));

            double ftheta1 = theta1 + 1 / (double)3600;
            double ftheta2 = theta2 + 1 / (double)3600;
            double ftheta3 = theta3 + 1 / (double)3600;
            double ftheta4 = theta4 + 1 / (double)3600;
            double ftheta5 = theta5 + 1 / (double)3600;
            double ftheta6 = theta6 + 1 / (double)3600;
            double ftheta7 = theta7 + 1 / (double)3600;
            double ftheta8 = theta8 + 1 / (double)3600;


            double f1 = (Math.Log10(Math.Sin(ftheta1 * Math.PI / 180))) - logsin1;
            double f2 = (Math.Log10(Math.Sin(ftheta2 * Math.PI / 180))) - logsin2;
            double f3 = (Math.Log10(Math.Sin(ftheta3 * Math.PI / 180))) - logsin3;
            double f4 = (Math.Log10(Math.Sin(ftheta4 * Math.PI / 180))) - logsin4;
            double f5 = (Math.Log10(Math.Sin(ftheta5 * Math.PI / 180))) - logsin5;
            double f6 = (Math.Log10(Math.Sin(ftheta6 * Math.PI / 180))) - logsin6;
            double f7 = (Math.Log10(Math.Sin(ftheta7 * Math.PI / 180))) - logsin7;
            double f8 = (Math.Log10(Math.Sin(ftheta8 * Math.PI / 180))) - logsin8;


            double E1 = 360 - (theta1 + theta2 + theta3 + theta4 + theta5 + theta6 + theta7 + theta8);
            double E2 = (theta5 + theta6) - (theta1 + theta2);
            double E3 = (theta7 + theta8) - (theta3 + theta4);
            double E4 = (logsin2 + logsin4 + logsin6 + logsin8) - (logsin1 + logsin3 + logsin5 + logsin7);

            double[,] matA = new double[4, 8];
            double[,] matA_Transpose = new double[8, 4];
            double[,] matCrc = new double[8,1];
            double[,] matF = new double[4,1];
            double[,] matQ = new double[8, 8];
            double[,] matQE = new double[4, 4];
            double[,] matWE = new double[4, 4];
            double[,] matAQ = new double[4, 8];
            double[,] matK = new double[4, 1];
            double[,] matQAT = new double[8, 4];
           
           
            double sum = 0;

            //Matrix A:
            matA[0, 0] = 1;
            matA[0, 1] = 1;
            matA[0, 2] = 1;
            matA[0, 3] = 1;
            matA[0, 4] = 1;
            matA[0, 5] = 1;
            matA[0, 6] = 1;
            matA[0, 7] = 1;

            matA[1, 0] = 1;
            matA[1, 1] = 1;
            matA[1, 2] = 0;
            matA[1, 3] = 0;
            matA[1, 4] = -1;
            matA[1, 5] = -1;
            matA[1, 6] = 0;
            matA[1, 7] = 0;

            matA[2, 0] = 0;
            matA[2, 1] = 0;
            matA[2, 2] = 1;
            matA[2, 3] = 1;
            matA[2, 4] = 0;
            matA[2, 5] = 0;
            matA[2, 6] = -1;
            matA[2, 7] = -1;

            matA[3, 0] = f1;
            matA[3, 1] = f2;
            matA[3, 2] = f3;
            matA[3, 3] = f4;
            matA[3, 4] = f5;
            matA[3, 5] = f6;
            matA[3, 6] = f7;
            matA[3, 7] = f8;

            //Matrix F:
            matF[0,0] = E1;
            matF[1,0] = E2;
            matF[2,0] = E3;
            matF[3,0] = E4;

            //Matrix Q:
            matQ[0, 0] = variance1;
            matQ[1, 1] = variance2;
            matQ[2, 2] = variance3;
            matQ[3, 3] = variance4;
            matQ[4, 4] = variance5;
            matQ[5, 5] = variance6;
            matQ[6, 6] = variance7;
            matQ[7, 7] = variance8;

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (i != j)
                        matQ[i, j] = 0;

           //Matrix Multiplication: Matrix AQ

            for(int i=0;i<4;i++)
            {
                for(int j=0;j<8;j++)
                {
                    for(int k=0;k<8;k++)
                    {
                        sum = sum + matA[i, k] * matQ[k, j];
                    }
                    matAQ[i, j] = sum;
                    sum = 0;
                }
            }


            //Matrix Transpose: A Transpose
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 8; j++)
                    matA_Transpose[j, i] = matA[i, j];

            //Matrix Multiplication: Matrix QE (AQ*A_Transpose)
            sum = 0;
            for(int i=0;i<4;i++)
            {
                for(int j=0;j<4;j++)
                {
                    for(int k=0;k<8;k++)
                    {
                        sum = sum + matAQ[i, k] * matA_Transpose[k, j];
                    }
                    matQE[i, j] = sum;
                    sum = 0;
                }
            }

            //Inverse Matrix: We=Inverse of Qe
            Matrix<double> QE=DenseMatrix.OfArray(matQE);
            Matrix<double> WE;
            WE = QE.Inverse();
            
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    matWE[i, j] = WE[i, j];


            //Matrix K=We*f
            sum = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        sum = sum + matWE[i, k] * matF[k,j];
                    }
                    matK[i, j] = sum;
                    sum = 0;
                }
            }

     /////////Matrix Crc: crc

            //Q*A_transpose
            sum = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        sum = sum + matQ[i, k] * matA_Transpose[k,j];
                    }
                    matQAT[i, j] = sum;
                    sum = 0;
                }
            }

            //QAT*K
            sum = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        sum = sum + matQAT[i, k] * matK[k,j];
                    }
                    matCrc[i, j] = sum;
                    sum = 0;
                }
            }
            /////////End of matrix correction


            return matCrc;

        }




    }
}
