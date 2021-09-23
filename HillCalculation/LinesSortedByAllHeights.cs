using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillCalculation
{
    public class LinesSortedByAllHeights
    {
        private LinesOfTheHeight[] linesOfAllSortedHeights;
        public LinesOfTheHeight[] LinesOfAllSortedHeights { get => linesOfAllSortedHeights; set => linesOfAllSortedHeights = value; }
        public LinesSortedByAllHeights(int numberOfTheHeightOfContourLines, int minHeightOfHillInt)
        {
            LinesOfAllSortedHeights = new LinesOfTheHeight[numberOfTheHeightOfContourLines];
            for (int i = 0; i < numberOfTheHeightOfContourLines; i++)
            {
                LinesOfAllSortedHeights[i] = new LinesOfTheHeight();
                linesOfAllSortedHeights[i].Height = minHeightOfHillInt + i;
            }
        }
    }
}
