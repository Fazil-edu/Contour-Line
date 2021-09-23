using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace HillCalculation
{
    public static class Calculation
    {
        public static void CatmullRomSplines(LineSeries contourLineLineSeries, LineSeries splineLineSeries)
        {
            

            for (float t = 0; t <= contourLineLineSeries.Points.Count; t += 0.01f)
            {
                int p1 = (int)t;
                int p2 = (p1 + 1) % (contourLineLineSeries.Points.Count);
                int p3 = (p2 + 1) % (contourLineLineSeries.Points.Count);
                int p0 = p1 >= 1 ? p1 - 1 : contourLineLineSeries.Points.Count - 1;

                float tmp = t - (int)t;
                float tt = tmp * tmp;
                float ttt = tmp * tmp * tmp;

                float q1 = -ttt + 2.0f * tt - tmp;
                float q2 = 3.0f * ttt - 5.0f * tt + 2;
                float q3 = -3.0f * ttt + 4.0f * tt + tmp;
                float q4 = ttt - tt;

                double x = 0.5 * (contourLineLineSeries.Points[p0].X * q1 + contourLineLineSeries.Points[p1].X * q2 + contourLineLineSeries.Points[p2].X * q3 + contourLineLineSeries.Points[p3].X * q4);
                double y = 0.5 * (contourLineLineSeries.Points[p0].Y * q1 + contourLineLineSeries.Points[p1].Y * q2 + contourLineLineSeries.Points[p2].Y * q3 + contourLineLineSeries.Points[p3].Y * q4);

                splineLineSeries.Points.Add(new DataPoint(x, y));
            }


        }
        public static double Volume(Vector[,] measuringPoints, int numberOfRows, int numberOfColumns )
        {
            double meshSize = measuringPoints[0, 1].X - measuringPoints[0, 0].X;
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

        public static void SetTransportTimeDGV( double volume, int numberOfExistingTrucks, DataGridView TransportTimeDGV)
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

        public static void FindMaxHeightOfHill( Vector[,] measuringPoints, int numberOfRows, int numberOfColumns, ref double maxHeightOfHill)
        {
            maxHeightOfHill = measuringPoints[0, 0].Z;
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    if (measuringPoints[i,j].Z > maxHeightOfHill)
                    {
                        
                        maxHeightOfHill = measuringPoints[i, j].Z;
                    }
                }
            }
        }

        public static void FindMinHeightOfHill(Vector[,] measuringPoints, int numberOfRows, int numberOfColumns, ref double minHeightOfHill)
        {
            minHeightOfHill = measuringPoints[0, 0].Z;
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 1; j < numberOfColumns; j++)
                {
                    if (measuringPoints[i, j].Z < minHeightOfHill)
                    {
                        minHeightOfHill = measuringPoints[i, j].Z;
                    }
                }
            }

        }

        public static LinesSortedByAllHeights SortLinesByAllHeights(Vector[,] measuringPoints, int numberOfRows, int numberOfColumns, double maxHeightOfHill, double minHeightOfHill)
        {
            int maxHeightOfHillInt = Convert.ToInt16(Math.Ceiling(maxHeightOfHill));
            int minHeightOfHillInt = Convert.ToInt16(Math.Floor(minHeightOfHill));
            LinesSortedByAllHeights linesSortedByAllHeights = new LinesSortedByAllHeights(maxHeightOfHillInt-minHeightOfHillInt, minHeightOfHillInt);
           

            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    Vector support = new Vector(measuringPoints[i, j].X, measuringPoints[i, j].Y, measuringPoints[i, j].Z);

                    if (j != numberOfColumns - 1)
                    {
                        Vector rightDirection = new Vector(measuringPoints[i, j + 1].X - measuringPoints[i, j].X, measuringPoints[i, j + 1].Y - measuringPoints[i, j].Y, measuringPoints[i, j + 1].Z - measuringPoints[i, j].Z);
                        Line lineRitgh = new Line(rightDirection, support);
                        AddTheLineInTheAppropriatePlace(linesSortedByAllHeights, lineRitgh);
                    }

                    if (i != numberOfRows - 1)
                    {
                        Vector downDirection = new Vector(measuringPoints[i + 1, j].X - measuringPoints[i, j].X, measuringPoints[i + 1, j].Y - measuringPoints[i, j].Y, measuringPoints[i + 1, j].Z - measuringPoints[i, j].Z);
                        Line lineDown = new Line(downDirection, support);
                        AddTheLineInTheAppropriatePlace(linesSortedByAllHeights, lineDown);
                    }
                    /*
                     It is to interpolate diagonal 
                     
                    if (j != numberOfColumns - 1 && i != numberOfRows - 1)
                    {
                        Vector rightDownDirection = new Vector(measuringPoints[i + 1, j + 1].X - measuringPoints[i, j].X, measuringPoints[i + 1, j + 1].Y - measuringPoints[i, j].Y, measuringPoints[i + 1, j + 1].Z - measuringPoints[i, j].Z);
                        Line lineDownRight = new Line(rightDownDirection, support);
                        AddTheLineInTheAppropriatePlace(linesSortedByAllHeights, lineDownRight);
                    }

                    if (j != 0 && i != numberOfRows - 1)
                    {
                        Vector leftDownDirection = new Vector(measuringPoints[i + 1, j - 1].X - measuringPoints[i, j].X, measuringPoints[i + 1, j - 1].Y - measuringPoints[i, j].Y, measuringPoints[i + 1, j - 1].Z - measuringPoints[i, j].Z);
                        Line lineDownLeft = new Line(leftDownDirection, support);
                        AddTheLineInTheAppropriatePlace(linesSortedByAllHeights, lineDownLeft);
                    }
                     
                 */

                }
            }
            return linesSortedByAllHeights;
        }

        public static void AddTheLineInTheAppropriatePlace(LinesSortedByAllHeights linesSortedByAllHeights, Line lineRightOrDown)
        {
            for (int i = 0; i < linesSortedByAllHeights.LinesOfAllSortedHeights.Length; i++)
            {
                if (lineRightOrDown.MinHeight <= linesSortedByAllHeights.LinesOfAllSortedHeights[i].Height && linesSortedByAllHeights.LinesOfAllSortedHeights[i].Height <= lineRightOrDown.MaxHeight)
                {
                    linesSortedByAllHeights.LinesOfAllSortedHeights[i].LnsOfTheHeight.Add(lineRightOrDown);
                }
            }
        }

        public static AllInterpolatedPoints FindInterpolationPoints(LinesSortedByAllHeights linesSortedByAllHeights, double maxHeightOfHill)
        {
            AllInterpolatedPoints allInterpolatedPoints = new AllInterpolatedPoints(linesSortedByAllHeights.LinesOfAllSortedHeights.Length);
            int maxHeightOfHillInt = Convert.ToInt16(Math.Ceiling(maxHeightOfHill));
            int cnt = 0;
            foreach (LinesOfTheHeight linesOfTheHeight in linesSortedByAllHeights.LinesOfAllSortedHeights)
            {
                foreach (Line line in linesOfTheHeight.LnsOfTheHeight)
                {
                    double t = (linesOfTheHeight.Height - line.SupportVector.Z) / line.DirectionVector.Z;

                    Vector xYCoornatesOfTheInterpolatedPointByTheHeight;

                    if (Double.IsNaN(t))
                    {
                        xYCoornatesOfTheInterpolatedPointByTheHeight = new Vector(Math.Abs(line.DirectionVector.X - line.SupportVector.X) / 2, Math.Abs(line.DirectionVector.Y - line.SupportVector.Y) / 2, linesOfTheHeight.Height);
                    }
                    else
                    {
                        xYCoornatesOfTheInterpolatedPointByTheHeight = new Vector(line.SupportVector.X + t * line.DirectionVector.X, line.SupportVector.Y + t * line.DirectionVector.Y, linesOfTheHeight.Height);
                    }
                    allInterpolatedPoints.AllIntrpltdPoints[cnt].Points.Add(xYCoornatesOfTheInterpolatedPointByTheHeight);
                }
                cnt++;
            }
            
            return allInterpolatedPoints;
        }
        public static AllContourLines FindAllContourLines(AllInterpolatedPoints allInterpolatedPoints)
        {
            AllContourLines allContourLinesWithDiferentHeights = new AllContourLines();
            int cnt = 0;
            List<OxyColor> myColors = new List<OxyColor>()
            {

                OxyColors.Yellow,OxyColors.Black, OxyColors.Blue, OxyColors.Green, OxyColors.Red, OxyColors.Orange
            };
            foreach (InterpolatedPointsAtTheSameHeight interpolatedPointsAtTheSameHeight in allInterpolatedPoints.AllIntrpltdPoints)
            {
                ContourLinesAtTheSameHeight currenHeight = new ContourLinesAtTheSameHeight(myColors[cnt]);
                SeparateTheContourLine(interpolatedPointsAtTheSameHeight, ref currenHeight);
                allContourLinesWithDiferentHeights.AllCntrLines.Add(currenHeight);
                if (cnt == 5)
                {
                    cnt = 0;
                }
                cnt ++;
            }
            return allContourLinesWithDiferentHeights;
        }

        public static void SeparateTheContourLine(InterpolatedPointsAtTheSameHeight interpolatedPointsAtTheSameHeight, ref ContourLinesAtTheSameHeight currenHeight)
        {
            ContourLine currentContourLine = new ContourLine(currenHeight.ColorOfTheHeight);

            if (interpolatedPointsAtTheSameHeight.Points.Count > 3)
            {
                List<Vector> contain = new List<Vector>();
                Vector first = interpolatedPointsAtTheSameHeight.Points[0];
                contain.Add(first);
                currentContourLine.LineSeries.Points.Add(new DataPoint(first.X, first.Y));

                Vector second = FindShortestConnection(first, interpolatedPointsAtTheSameHeight, contain);
                contain.Add(second);
                currentContourLine.LineSeries.Points.Add(new DataPoint(second.X, second.Y));

                Vector third = FindShortestConnection(second, interpolatedPointsAtTheSameHeight, contain);
                contain.Add(third);
                contain.RemoveAt(0);
                currentContourLine.LineSeries.Points.Add(new DataPoint(third.X, third.Y));

                Vector currentShortesDistance = FindShortestConnection(third, interpolatedPointsAtTheSameHeight, contain);

                while (currentShortesDistance != first)
                {
                    contain.Add(currentShortesDistance);
                    currentContourLine.LineSeries.Points.Add(new DataPoint(currentShortesDistance.X, currentShortesDistance.Y));
                    currentShortesDistance = FindShortestConnection(currentShortesDistance, interpolatedPointsAtTheSameHeight, contain);
                }
                
                contain.Add(first);
                currentContourLine.LineSeries.Points.Add(new DataPoint(currentShortesDistance.X, currentShortesDistance.Y)); // last one is the first point. It is neccesary to loop the lineseries
                currenHeight.CntrLinesAtTheSameHeight.Add(currentContourLine);
                RemoveTheOccupiedPoints(contain, interpolatedPointsAtTheSameHeight);
                SeparateTheContourLine(interpolatedPointsAtTheSameHeight, ref currenHeight);

            }
            else
            {
                if (interpolatedPointsAtTheSameHeight.Points.Count > 0)
                {
                    Vector first = interpolatedPointsAtTheSameHeight.Points[0];
                    if (interpolatedPointsAtTheSameHeight.Points.Count > 1)
                    {
                        Vector second = interpolatedPointsAtTheSameHeight.Points[1];

                        currentContourLine.LineSeries.Points.Add(new DataPoint(first.X, first.Y));
                        currentContourLine.LineSeries.Points.Add(new DataPoint(second.X, second.Y));
                        currenHeight.CntrLinesAtTheSameHeight.Add(currentContourLine);
                        interpolatedPointsAtTheSameHeight.Points.Remove(first);
                        interpolatedPointsAtTheSameHeight.Points.Remove(second);
                    }
                    else
                    {
                        currentContourLine.LineSeries.Points.Add(new DataPoint(first.X, first.Y));
                        currenHeight.CntrLinesAtTheSameHeight.Add(currentContourLine);
                        interpolatedPointsAtTheSameHeight.Points.Remove(first);
                    }
                }
                return;
            }
        }

        public static void RemoveTheOccupiedPoints(List<Vector> contain, InterpolatedPointsAtTheSameHeight interpolatedPointsAtTheSameHeight)
        {
            foreach (Vector item in contain)
            {
                interpolatedPointsAtTheSameHeight.Points.Remove(item);
            }
        }

        public static Vector FindShortestConnection(Vector currentVector, InterpolatedPointsAtTheSameHeight interpolatedPointsAtTheSameHeight, List<Vector> contain)
        {

            List<Vector> allDistance = new List<Vector>();
            foreach (Vector item in interpolatedPointsAtTheSameHeight.Points)
            {
                if (!contain.Contains(item))
                {
                    allDistance.Add(item);

                }
            }

            Vector vectorWithTheShortesDistance = allDistance[0];

            double shortestDistance = Math.Sqrt(Math.Pow(vectorWithTheShortesDistance.X - currentVector.X, 2) + Math.Pow(vectorWithTheShortesDistance.Y - currentVector.Y, 2));
            foreach (Vector item in allDistance)
            {
                double currentDistance = Math.Sqrt(Math.Pow(item.X - currentVector.X, 2) + Math.Pow(item.Y - currentVector.Y, 2));
                if (currentDistance < shortestDistance)
                {
                    vectorWithTheShortesDistance = item;
                    shortestDistance = currentDistance;
                }
            }

            return vectorWithTheShortesDistance;
        }

        #region Area

        //public static Tuple<List<LineSeries>, List<LineSeries>> FindRedAreaConnection(ref Vector[,] measuringPoints, int numberOfRows, int numberOfColumns, int height)
        //{
        //    List<LineSeries> xAxisLineSeries = new List<LineSeries>();
        //    List<LineSeries> yAxisLineSeries = new List<LineSeries>();
        //    //myPlotView.Model.Series.Clear();
        //    int breackC;
        //    for (int i = 0; i < measuringPoints.GetLength(0); i++)
        //    {
        //        breackC = 0;
        //        for (int j = breackC; j < measuringPoints.GetLength(1); j++)
        //        {
        //            if (measuringPoints[i, j].Z < height && breackC < measuringPoints.GetLength(1))
        //            {
        //                LineSeries currentXAxisLineSeries = new LineSeries()
        //                {
        //                    MarkerType = MarkerType.Circle,
        //                    //LineStyle = LineStyle.None,
        //                    Color = OxyColors.Red
        //                };

        //                for (int column = j; column < measuringPoints.GetLength(1); column++)
        //                {
        //                    if (measuringPoints[i, column].Z < height)
        //                    {
        //                        DataPoint a = new DataPoint(measuringPoints[i, column].X, measuringPoints[i, column].Y);
        //                        currentXAxisLineSeries.Points.Add(a);
        //                        breackC = column;
        //                    }
        //                    else
        //                    {
        //                        breackC = column;
        //                        column = measuringPoints.GetLength(1);
        //                    }

        //                }
        //                xAxisLineSeries.Add(currentXAxisLineSeries);
        //            }
        //        }
        //    }

        //    int breackR;
        //    for (int j = 0; j < measuringPoints.GetLength(1); j++)
        //    {
        //        breackR = 0;
        //        for (int i = breackR; i < measuringPoints.GetLength(0); i++)
        //        {
        //            if (measuringPoints[i, j].Z < height && breackR < measuringPoints.GetLength(0))
        //            {
        //                LineSeries currentYAxisLineSeries = new LineSeries()
        //                {
        //                    MarkerType = MarkerType.Circle,
        //                    //LineStyle = LineStyle.None,
        //                    Color = OxyColors.Red
        //                };

        //                for (int row = i; row < measuringPoints.GetLength(1); row++)
        //                {
        //                    if (measuringPoints[row, j].Z < height)
        //                    {
        //                        DataPoint a = new DataPoint(measuringPoints[row, j].X, measuringPoints[row, j].Y);
        //                        currentYAxisLineSeries.Points.Add(a);
        //                        breackR = row;
        //                    }
        //                    else
        //                    {
        //                        breackR = row;
        //                        row = measuringPoints.GetLength(0);
        //                    }

        //                }
        //                yAxisLineSeries.Add(currentYAxisLineSeries);
        //            }
        //        }
        //    }
        //    Tuple<List<LineSeries>, List<LineSeries>> allLineSeries = Tuple.Create(xAxisLineSeries, yAxisLineSeries);
        //    return allLineSeries;
        //}

        //public static Tuple<List<LineSeries>, List<LineSeries>> FindGreenAreaConnection(ref Vector[,] measuringPoints, int numberOfRows, int numberOfColumns, int height)
        //{
        //    List<LineSeries> xAxisLineSeries = new List<LineSeries>();
        //    List<LineSeries> yAxisLineSeries = new List<LineSeries>();
        //    //myPlotView.Model.Series.Clear();
        //    int breackC;
        //    for (int i = 0; i < measuringPoints.GetLength(0); i++)
        //    {
        //        breackC = 0;
        //        for (int j = breackC; j < measuringPoints.GetLength(1); j++)
        //        {
        //            if (measuringPoints[i, j].Z > height && breackC < measuringPoints.GetLength(1))
        //            {
        //                LineSeries currentXAxisLineSeries = new LineSeries()
        //                {
        //                    MarkerType = MarkerType.Circle,
        //                    //LineStyle = LineStyle.None,
        //                    Color = OxyColors.Green
        //                };

        //                for (int column = j; column < measuringPoints.GetLength(1); column++)
        //                {
        //                    if (measuringPoints[i, column].Z > height)
        //                    {
        //                        DataPoint a = new DataPoint(measuringPoints[i, column].X, measuringPoints[i, column].Y);
        //                        currentXAxisLineSeries.Points.Add(a);
        //                        breackC = column;
        //                    }
        //                    else
        //                    {
        //                        breackC = column;
        //                        column = measuringPoints.GetLength(1);
        //                    }
        //                }
        //                xAxisLineSeries.Add(currentXAxisLineSeries);
        //            }
        //        }
        //    }

        //    int breackR;
        //    for (int j = 0; j < measuringPoints.GetLength(1); j++)
        //    {
        //        breackR = 0;
        //        for (int i = breackR; i < measuringPoints.GetLength(0); i++)
        //        {
        //            if (measuringPoints[i, j].Z > height && breackR < measuringPoints.GetLength(0))
        //            {
        //                LineSeries currentYAxisLineSeries = new LineSeries()
        //                {
        //                    MarkerType = MarkerType.Circle,
        //                    //LineStyle = LineStyle.None,
        //                    Color = OxyColors.Green
        //                };

        //                for (int row = i; row < measuringPoints.GetLength(1); row++)
        //                {
        //                    if (measuringPoints[row, j].Z > height)
        //                    {
        //                        DataPoint a = new DataPoint(measuringPoints[row, j].X, measuringPoints[row, j].Y);
        //                        currentYAxisLineSeries.Points.Add(a);
        //                        breackR = row;
        //                    }
        //                    else
        //                    {
        //                        breackR = row;
        //                        row = measuringPoints.GetLength(0);
        //                    }

        //                }
        //                yAxisLineSeries.Add(currentYAxisLineSeries);
        //            }
        //        }
        //    }
        //    Tuple<List<LineSeries>, List<LineSeries>> allLineSeries = Tuple.Create(xAxisLineSeries, yAxisLineSeries);
        //    return allLineSeries;
        //}

        #endregion
    }
}
