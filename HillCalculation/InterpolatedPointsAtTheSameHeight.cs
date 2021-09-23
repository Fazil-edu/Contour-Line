using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot.Series;
using OxyPlot;


namespace HillCalculation
{
    public class InterpolatedPointsAtTheSameHeight
    {

        public List<Vector> Points { get => points; set => points = value; }
       
        private List<Vector> points;    

        public InterpolatedPointsAtTheSameHeight()
        {
            this.Points =  new List<Vector>();
        }
    }
}
