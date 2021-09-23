using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot.Series;
using OxyPlot;

namespace HillCalculation
{
    public class AllInterpolatedPoints
    {
        private InterpolatedPointsAtTheSameHeight[] allIntrpltdPoints;
        public InterpolatedPointsAtTheSameHeight[] AllIntrpltdPoints { get => allIntrpltdPoints; set => allIntrpltdPoints = value; }

        public AllInterpolatedPoints(int numberOfThePointsAtTheSameHeight)
        {
            this.AllIntrpltdPoints = new InterpolatedPointsAtTheSameHeight[numberOfThePointsAtTheSameHeight];
            for (int i = 0; i < numberOfThePointsAtTheSameHeight; i++)
            {
                this.AllIntrpltdPoints[i] = new InterpolatedPointsAtTheSameHeight();

            }
        }
    }
}
