using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HillCalculation
{
    public class HillPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double Z { get; set; }

        public HillPoint(int x, int y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static HillPoint operator +(HillPoint a) => a;
        public static HillPoint operator +(HillPoint a, HillPoint b)
        {
            if (a == null && b == null)
            {
                return null;
            }
            else if (a == null && b != null)
            {
                return b;
            }
            else if (a != null && b == null)
            {
                return a;
            }
            else
            {
                return new HillPoint(a.X + b.X, a.Y + b.Y, a.Z + a.Y);
            }
        }
        public static HillPoint operator -(HillPoint a)
        {
            if (a == null)
            {
                return null;
            }

            return new HillPoint(-a.X, -a.Y, -a.Z);
        }
        public static HillPoint operator -(HillPoint a, HillPoint b) => a + (-b);
        public static HillPoint operator *(HillPoint a, double b)
        {
            if (b == 0)
            {
                return null;
            }

            if (a == null)
            {
                return null;
            }

            return new HillPoint(a.X , a.Y , a.Z * b);
        }

        public static HillPoint operator *(double b, HillPoint a) => a * b;
        public static HillPoint operator /(HillPoint a, double b) => new HillPoint(a.X , a.Y , a.Z / b);
    }
}
