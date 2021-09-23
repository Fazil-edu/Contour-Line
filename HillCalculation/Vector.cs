using System;


namespace HillCalculation
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public bool occupied = false;

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public Vector() { }

        public static Vector operator +(Vector a) => a;
        public static Vector operator +(Vector a, Vector b)
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
                return new Vector(a.X + b.X, a.Y + b.Y, a.Z + a.Y);
            }
        }
        public static Vector operator -(Vector a)
        {
            if (a == null)
            {
                return null;
            }

            return new Vector(-a.X, -a.Y, -a.Z);
        }
        public static Vector operator -(Vector a, Vector b) => a + (-b);
        public static Vector operator *(Vector a, double b)
        {
            if (b == 0)
            {
                return null;
            }

            if (a == null)
            {
                return null;
            }

            return new Vector(a.X , a.Y , a.Z * b);
        }

        public static Vector operator *(double b, Vector a) => a * b;
        public static Vector operator /(Vector a, double b) => new Vector(a.X , a.Y , a.Z / b);
    }
}
