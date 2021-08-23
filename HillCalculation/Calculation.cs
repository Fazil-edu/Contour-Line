using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace HillCalculation
{
    public static class Calculation
    {
        public static double Volume(ref HillPoint[,] measuringPoints, int numberOfRows, int numberOfColumns )
        {
            double meshSize = measuringPoints[0, 1].Y - measuringPoints[0, 0].Y;
            double heigths = 0;

            for (int i = 0; i < numberOfRows - 1; i++)
            {
                for (int j = 0; j < numberOfColumns-1; j++)
                {
                    heigths = heigths + measuringPoints[i, j].Z + measuringPoints[i, j + 1].Z + measuringPoints[i + 1, j].Z + measuringPoints[i + 1, j + 1].Z;
                }
            }

            return heigths * meshSize * meshSize; // it is the volume of hill
        }
        public static void SetTransportTimeDGV( double volume, int numberOfExistingTrucks, ref DataGridView TransportTimeDGV)
        {
            TransportTimeDGV.RowCount = numberOfExistingTrucks + 2;
            TransportTimeDGV.ColumnCount = 3;

            TransportTimeDGV[0, 0].Value = "Trucks";
            TransportTimeDGV[1, 0].Value = "Hours";
            TransportTimeDGV[2, 0].Value = "Days";
            for (int i = 1; i < numberOfExistingTrucks+1; i++)
            {
                TransportTimeDGV[0, i].Value = Convert.ToInt32(i);
                TransportTimeDGV[1, i].Value = Convert.ToInt32(30 * volume / (14 * (i)));
                TransportTimeDGV[2, i].Value = Convert.ToInt32(30 * volume / (336 * (i)));
            }
            TransportTimeDGV.Visible = true;
        }
        public static double FindMaxHeight(ref HillPoint[,] measuringPoints, int numberOfRows, int numberOfColumns)
        {
            double maxHeight = measuringPoints[0, 0].Z;
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 1; j < numberOfColumns; j++)
                {
                    if (measuringPoints[i,j].Z > maxHeight)
                    {
                        maxHeight = measuringPoints[i, j].Z;
                    }
                }
            }
            return maxHeight;
        }
    }
}
