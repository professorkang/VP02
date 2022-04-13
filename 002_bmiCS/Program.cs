// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("체중(kg) : ");
            string s = Console.ReadLine();
            double weight = Double.Parse(s);

            Console.Write("키(cm) : ");
            s = Console.ReadLine();
            double height = Double.Parse(s);

            double bmi = weight / (height / 100 * height / 100);
            Console.WriteLine("BMI = " + bmi);

        }
    }
}
