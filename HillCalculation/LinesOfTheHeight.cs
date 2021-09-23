using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillCalculation
{
    public class LinesOfTheHeight
    {
        private int height;
        private List<Line> lnsOfTheHeight;

        public int Height { get => height; set => height = value; }
        public List<Line> LnsOfTheHeight { get => lnsOfTheHeight; set => lnsOfTheHeight = value; }

        public LinesOfTheHeight()
        {
            LnsOfTheHeight = new List<Line>();
        }
    }
}
