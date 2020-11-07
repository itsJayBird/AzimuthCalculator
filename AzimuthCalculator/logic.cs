using System;
using System.Collections.Generic;
using System.Text;

namespace AzimuthCalculator
{
    class logic
    {
        List<double> azm = new List<double>();
        double azAvg;
        double azMed;

        public logic() { }
        public void getAzimuth(double[,] AP, double[,] CPE)
        {
            // lambda to convert degrees to radians which 
            // we need for the formula to work
            Func<double, double> rad = x => x * (Math.PI / 180);     
            // length of CPE list
            int len = CPE.GetLength(0);
            // loop to find the azimuth for each CPE
            for (int i = 0; i < len; i++)
            {
                var y = Math.Sin(rad(CPE[i, 1] - AP[0, 1])) * Math.Cos(rad(CPE[i, 0]));
                var x = Math.Cos(rad(AP[0, 0])) * Math.Sin(rad(CPE[i, 0])) -
                        Math.Sin(rad(AP[0, 0])) * Math.Cos(rad(CPE[i, 0])) *
                        Math.Cos(rad(CPE[i, 1] - AP[0, 1]));
                var t = Math.Atan2(y, x);
                var az = (t * 180 / Math.PI + 360) % 360;
                // add each value to list
                azm.Add(az);
            }
            azAvg = getAverage();
            azMed = getMedian();
        }
        
        private double getAverage()
        {
            double sum = 0;
            foreach (var num in azm)
            {
                sum += num;
            }
            return sum / azm.Count;
        }
        private double getMedian()
        {
            azm.Sort();
            int c = azm.Count % 2;
            if (c != 0)
            {
                c = (azm.Count / 2) + 1;
                return azm[c];
            }
            else
            {
                c = azm.Count / 2;
                return (azm[c] + azm[c + 1]) / 2; 
            }
        }
        public double getAZAvg()
        {
            return azAvg;
        }
        public double getAZMed()
        {
            return azMed;
        }
    }
}
