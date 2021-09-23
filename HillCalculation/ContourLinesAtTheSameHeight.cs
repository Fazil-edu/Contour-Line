using OxyPlot;
using System.Collections.Generic;
using OxyPlot.Series;

namespace HillCalculation
{
    public class ContourLinesAtTheSameHeight
    {
        private List<ContourLine> cntrLinesOfTheSameHeight;
        public List<ContourLine> CntrLinesAtTheSameHeight { get => cntrLinesOfTheSameHeight; set => cntrLinesOfTheSameHeight = value; }
        public OxyColor ColorOfTheHeight { get => colorOfTheHeight; set => colorOfTheHeight = value; }

        private OxyColor colorOfTheHeight;


        public ContourLinesAtTheSameHeight(OxyColor oxyColor)
        {
            this.CntrLinesAtTheSameHeight = new List<ContourLine>();
            this.ColorOfTheHeight = oxyColor;
        }
    }
}
