using System.Collections.Generic;
using OxyPlot.Series;
using OxyPlot;
namespace HillCalculation
{
    public class ContourLine
    {
        private LineSeries lineSeries;
        public LineSeries LineSeries { get => lineSeries; set => lineSeries = value; }

        public ContourLine(OxyColor color)
        {
            this.LineSeries = new LineSeries()
            {
                MarkerSize = 2.5,
                MarkerType = MarkerType.Circle,
                LineStyle = LineStyle.None,
                Color = color
            };
        }
    }
}



