using System;
using System.Collections.Generic;
using System.Text;

namespace AzimuthCalculator
{
    class Data
    {
        double[,] AP;
        double[,] CPE;
        public void readFile()
        {
            string[] lines = System.IO.File.ReadAllLines("GPS/gps.txt");
            AP = new double[1, 2];
            string[] temp = lines[0].Split(',');
            AP[0,0] = double.Parse(temp[0]);
            AP[0,1] = double.Parse(temp[1]);
            // set up CPE array
            int c = lines.Length;
            CPE = new double[c - 2, 2];

            for (int i = 1; i < c-2; i++)
            {
                temp = lines[i].Split(',');
                CPE[i - 1, 0] = double.Parse(temp[0]);
                CPE[i - 1, 1] = double.Parse(temp[1]);
            }
        }
        public void saveNewAP(string apn, double avg, double med)
        {
            string[] lines = new string[] { apn, "Average AZ: " + avg.ToString(), "Median AZ: " + med.ToString() };
            string filename = "Azimuth/" + apn + ".txt";
            System.IO.File.WriteAllLines(filename, lines);
        }
        public double[,] getAP()
        {
            return AP;
        }
        public double[,] getCPE()
        {
            return CPE;
        }
    }
}
