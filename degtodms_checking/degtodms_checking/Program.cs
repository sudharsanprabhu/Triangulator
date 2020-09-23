using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DEGtoDMSdll;
namespace degtodms_checking
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter angle in degree decimal format...");
            string deg = Console.ReadLine();

            DEGtoDMS obj = new DEGtoDMS();
            Console.WriteLine("Angle in DMS format is " + obj.deg2dms(deg));

            Console.WriteLine("Enter an angle to calculate log sine value:");
            double num = Double.Parse(Console.ReadLine());
            Console.WriteLine("Log sine value is " + Math.Log10(Math.Sin(num*3.14/180))+" PI : "+Math.PI);
            Console.ReadKey();
        }
    }
}
