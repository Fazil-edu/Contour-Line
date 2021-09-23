using System;

namespace HillCalculation
{
    public class Line
    {
        private Vector directionVector;
        private Vector supportVector;
        private double maxHeight;
        private double minHeight;

        public Vector DirectionVector { get => directionVector; }
        public Vector SupportVector { get => supportVector;}
        public double MaxHeight { get => maxHeight;}
        public double MinHeight { get => minHeight;}

        public Line(Vector directionVector, Vector supportVector) 
        {
            this.directionVector = directionVector;
            this.supportVector = supportVector;
            this.maxHeight = Math.Max(supportVector.Z + directionVector.Z, supportVector.Z);
            this.minHeight = Math.Min(supportVector.Z + directionVector.Z, supportVector.Z);
        }
    }
}
