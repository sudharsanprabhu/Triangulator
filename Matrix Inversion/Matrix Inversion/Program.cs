using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
namespace Matrix_Inversion
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] data = new double[,] { { 3.92,1,1.25,4 }, { 1,5,1.67,1 }, {-1.25,1.67,5.09,8 }, {5,3,5,3} };
            Matrix<double> m = DenseMatrix.OfArray(data);
            Matrix<double> inv;
            double[,] out_mat = new double[4,4];
            inv = m.Inverse();

            
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.WriteLine(inv[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Multiplication");
            Matrix<double> mul;
            mul=m*inv;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.WriteLine(mul[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
