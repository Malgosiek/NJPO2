using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testy1
{
    public class RownanieKwadratowe
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public RownanieKwadratowe(double a = 0, double b = 0, double c = 0)
        {
            A = a;
            B = b;
            C = c;
        }

        public double Delta()
        {
            return (B * B) - (4 * A * C);
        }

        public List<double> MiejscaZerowe()
        {
            double delta = Delta();
            List<double> miejscaZerowe = new List<double>();

            if (delta == 0)
            {
                double x = (-B) / (2 * A);
                miejscaZerowe.Add(x);

                return miejscaZerowe;
            }

            if (delta > 0)
            {
                double x1 = (-B - Math.Sqrt(delta)) / (2 * A);
                double x2 = (-B + Math.Sqrt(delta)) / (2 * A);

                miejscaZerowe.Add(x1);
                miejscaZerowe.Add(x2);

                return miejscaZerowe;
            }

            return null;
        }
    }
}
