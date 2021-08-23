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
    static class Drawing
    {
        public static TabControl BarShapeXPerspective(ref TabControl Profiles, ref HillPoint[,] measuringPoints,string xOrYPerspective, int numberOfRows, int numberOfColumns , double maxHeight)
        {


            PlotView[] myPlotVIew = new PlotView[numberOfRows];

            for (int i = numberOfRows - 1; i > -1; i--)
            {
                PlotView currentPlottView = new PlotView()
                {
                    Width = 850,
                    Height = 480,
                    BackColor = Color.White,
                    Location = new Point(8, 6),
                    Model = new PlotModel(),
                };

                LinearAxis yAxis = new LinearAxis { Minimum = 0, Maximum = maxHeight + 10};
                yAxis.IsZoomEnabled = false;
                currentPlottView.Model.Axes.Add(yAxis);

                CategoryAxis xAxis = new CategoryAxis ();
                xAxis.IsZoomEnabled = false;
                currentPlottView.Model.Axes.Add(xAxis);

                
                Profiles.TabPages.Add(xOrYPerspective + (i + 1).ToString());
                Profiles.TabPages[numberOfRows - i - 1].Controls.Add(currentPlottView);
                ColumnSeries columnSeries = new ColumnSeries();
                columnSeries.FillColor = OxyColors.Blue;
                for (int j = 0; j < numberOfColumns; j++)
                {
                    columnSeries.Items.Add(new ColumnItem(measuringPoints[i, j].Z));
                }

                currentPlottView.Model.Series.Add(columnSeries);
                
                myPlotVIew[numberOfRows - i - 1] = currentPlottView;
            }
            return Profiles;
        }
        public static TabControl BarShapeYPerspective(ref TabControl Profiles, ref HillPoint[,] measuringPoints, string xOrYPerspective, int numberOfRows , int numberOfColumns, double maxHeight)
        {
            PlotView[] myPlotVIew = new PlotView[numberOfColumns];

            for (int i = numberOfColumns - 1; i > -1; i--)
            {
                PlotView currentPlottView = new PlotView()
                {
                    Width = 850,
                    Height = 480,
                    BackColor = Color.White,
                    Location = new Point(8, 6),
                    Model = new PlotModel(),
                };

                //CategoryAxis yAxis = new CategoryAxis { };
                //yAxis.IsZoomEnabled = false;
                //currentPlottView.Model.Axes.Add(yAxis);


                //LinearAxis xAxis = new LinearAxis { Minimum = 0, Maximum = maxHeight + 10 };
                //xAxis.IsZoomEnabled = false;
                //currentPlottView.Model.Axes.Add(xAxis);


                Profiles.TabPages.Add(xOrYPerspective + (i + 1).ToString());
                Profiles.TabPages[numberOfColumns - i - 1].Controls.Add(currentPlottView);
                BarSeries barSeries = new BarSeries();

                barSeries.FillColor = OxyColors.Blue;
                for (int j = 0; j < numberOfRows; j++)
                {
                    barSeries.Items.Add(new BarItem(measuringPoints[i, j].Z));
                }

                currentPlottView.Model.Series.Add(barSeries);

                myPlotVIew[numberOfColumns - i - 1] = currentPlottView;
            }
            return Profiles;
        }
    }
}
