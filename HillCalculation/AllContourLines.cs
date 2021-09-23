using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;


namespace HillCalculation
{
    public class AllContourLines
    {
        private List<ContourLinesAtTheSameHeight> allCntrLines;

        public List<ContourLinesAtTheSameHeight> AllCntrLines { get => allCntrLines; set => allCntrLines = value; }

        public AllContourLines()
        {
            this.AllCntrLines = new List<ContourLinesAtTheSameHeight>();
        }
    }
}
