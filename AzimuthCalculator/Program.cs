using System;
using System.Collections.Generic;

namespace AzimuthCalculator
{
    class Program
    {           
        static void Main(string[] args)
        {
            Data a = new Data();
            logic b = new logic();
            a.readFile();
            b.getAzimuth(a.getAP(), a.getCPE());
            Console.WriteLine("Name this AP: ");
            string apn = Console.ReadLine();
            Console.WriteLine("Average Azimuth: " + b.getAZAvg());
            Console.WriteLine("Median Azimuth: " + b.getAZMed());
            a.saveNewAP(apn, b.getAZAvg(), b.getAZMed());
        }


    }
}
