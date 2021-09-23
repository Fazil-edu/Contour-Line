using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HillCalculation
{
    public static class Drawing
    {
        public static void BarShapeXPerspective(TabControl Profiles, Vector[,] measuringPoints,string xOrYPerspective, int numberOfRows, int numberOfColumns , double maxHeight)
        {
            Profiles.TabPages.Clear();
            for (int i = numberOfRows - 1; i > -1; i--)
            {
                PlotView currentPlottView = new PlotView()
                {
                    Width = 850,
                    Height = 480,
                    BackColor = Color.White,
                    Location = new System.Drawing.Point(8, 6),
                    Model = new PlotModel(),
                };

                LinearAxis yAxis = new LinearAxis { Minimum = 0, Maximum = maxHeight + maxHeight*0.1};
                yAxis.IsZoomEnabled = false;
                currentPlottView.Model.Axes.Add(yAxis);

                CategoryAxis xAxis = new CategoryAxis ();
                xAxis.IsZoomEnabled = false;
                currentPlottView.Model.Axes.Add(xAxis);

                
                Profiles.TabPages.Add(xOrYPerspective + (numberOfRows - i).ToString());
                Profiles.TabPages[numberOfRows - i - 1].Controls.Add(currentPlottView);
                ColumnSeries columnSeries = new ColumnSeries();
                columnSeries.FillColor = OxyColors.Blue;
                for (int j = 0; j < numberOfColumns; j++)
                {
                    columnSeries.Items.Add(new ColumnItem(measuringPoints[i, j].Z));
                }

                currentPlottView.Model.Series.Add(columnSeries);
            }
            Profiles.Visible = true;
        }
        public static void BarShapeYPerspective(TabControl Profiles, Vector[,] measuringPoints, string xOrYPerspective, int numberOfRows , int numberOfColumns, double maxHeight)
        {
            Profiles.TabPages.Clear();
            for (int j = 0; j < numberOfColumns; j++)
            {
                PlotView currentPlottView = new PlotView()
                {
                    Width = 850,
                    Height = 480,
                    BackColor = Color.White,
                    Location = new System.Drawing.Point(8, 6),
                    Model = new PlotModel(),
                };


                Profiles.TabPages.Add(xOrYPerspective + (j + 1).ToString());
                Profiles.TabPages[j].Controls.Add(currentPlottView);
                BarSeries barSeries = new BarSeries();

                barSeries.FillColor = OxyColors.Blue;
                for (int i = numberOfRows-1; i > -1; i--)
                {
                    barSeries.Items.Add(new BarItem(measuringPoints[i, j].Z));
                }

                currentPlottView.Model.Series.Add(barSeries);
            }
            Profiles.Visible = true;
        }

        public static void DrawContourLines(PlotView myPlotView, AllContourLines allCntrLines)
        {
            foreach (ContourLinesAtTheSameHeight contourLinesAtTheSameHeight in allCntrLines.AllCntrLines)
            {
                foreach (ContourLine currentContourLine in contourLinesAtTheSameHeight.CntrLinesAtTheSameHeight)
                {
                    LineSeries splineLineSeries = new LineSeries()
                    {
                        MarkerSize = 2.5,
                        Color = currentContourLine.LineSeries.Color
                    };
                    Calculation.CatmullRomSplines(currentContourLine.LineSeries, splineLineSeries);
                    myPlotView.Model.Series.Add(currentContourLine.LineSeries);
                    myPlotView.Model.Series.Add(splineLineSeries);
                }
            }
            myPlotView.Visible = true;
            myPlotView.Model.InvalidatePlot(true);
        }

        #region Area

        //public static void DrawRedAreaConnection(Tuple<List<LineSeries>, List<LineSeries>> allLineSeries , ref PlotView myPlotView)
        //{
        //    foreach (var xAxisLineSeries in allLineSeries.Item1)
        //    {
        //        myPlotView.Model.Series.Add(xAxisLineSeries);
        //    }

        //    foreach (var yAxisLineSeries in allLineSeries.Item2)
        //    {
        //        myPlotView.Model.Series.Add(yAxisLineSeries);
        //    }
        //}
        //public static void DrawGreenAreaConnection(Tuple<List<LineSeries>, List<LineSeries>> allLineSeries, ref PlotView myPlotView)
        //{
        //    foreach (var xAxisLineSeries in allLineSeries.Item1)
        //    {
        //        myPlotView.Model.Series.Add(xAxisLineSeries);
        //    }

        //    foreach (var yAxisLineSeries in allLineSeries.Item2)
        //    {
        //        myPlotView.Model.Series.Add(yAxisLineSeries);
        //    }
        //}
        #endregion
    }
}
