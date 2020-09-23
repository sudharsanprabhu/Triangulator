using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeanAndVariance

{

    class process
    {

        public double[] mean = new double[4];
        public double[] var = new double[4];
        public double[] corrected_angles = new double[4];
        



        public double mean_calc(double a, double b, double c, double d, double e, double f, double g, double h)
        {

            return (a + b + c + d + e + f + g + h) / 8;

        }

        public double var_calc(double a, double b, double c, double d, double e, double f, double g, double h)
        {
            double sq = 0;
            double[] var_data = { a, b, c, d, e, f, g, h };
            double mean = (a + b + c + d + e + f + g + h) / 8;

            for (int i = 0; i < 8; i++)
            {
                sq = sq + (var_data[i] * var_data[i]);
            }

            return (sq - (mean * mean * 8)) / 7;

        }
    }


    class Program
    {
       

        static void Main(string[] args)
        {
            double a, b, c, d, e, f, g, h;
            process obj = new process();
            Console.WriteLine("Enter 8 data: ");
            a = double.Parse(Console.ReadLine());
            b = double.Parse(Console.ReadLine());
            c = double.Parse(Console.ReadLine());
            d = double.Parse(Console.ReadLine());
            e = double.Parse(Console.ReadLine());
            f = double.Parse(Console.ReadLine());
            g = double.Parse(Console.ReadLine());
            h = double.Parse(Console.ReadLine());
            double mean = obj.mean_calc(a, b, c, d, e, f, g, h);
            double variance=obj.var_calc(a, b, c, d, e, f, g, h);
            Console.WriteLine("Mean: " + mean.ToString());
            Console.WriteLine("Variance: " + variance.ToString());
            Console.ReadKey();
        }
            
      

       





    }
    }

