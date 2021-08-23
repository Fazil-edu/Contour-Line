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
    static class DataHandling
    {
        public static List<HillPoint> CheckTheFile(string path, ref bool fileSelected)
        {
            List<HillPoint> rawData = new List<HillPoint>();
            if (path.Length != 0)
            {
                if (!path.EndsWith(".txt"))
                {
                    MessageBox.Show("Please select only a text file");
                }
                else
                {
                    fileSelected = true;
                    StreamReader stream = new StreamReader(path);
                    string line;
                    while ((line = stream.ReadLine()) != null)
                    {
                        line = line.Remove(line.Length - 1);
                        string[] tuple = line.Split(',');
                        try
                        {
                            rawData.Add(new HillPoint(Convert.ToInt32(tuple[1]), Convert.ToInt32(tuple[0]), Convert.ToDouble(tuple[2])));
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("The given file is not correct, not all the data is a point");
                            fileSelected = false;
                            break;
                        }
                    }
                }
            }

            return rawData;
        }
        public static void TransformData(ref List<HillPoint> rawData, ref HillPoint[,] measuringPoints, ref int numberOfRows, ref int numberOfColumns)
        {
            for (int i = 1; i < rawData.Count; i++)
            {
                if (rawData[0].Y == rawData[i].Y)
                {
                    numberOfColumns = i;
                    break;
                }
            }

            numberOfRows = Convert.ToInt32(rawData.Count / numberOfColumns);
            measuringPoints = new HillPoint[numberOfRows, numberOfColumns];
            int cnt = 0;
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    measuringPoints[i, j] = rawData[cnt];
                    cnt++;
                }
            }
        }
        public static void SetDataGridViewDGW(ref DataGridView measuringPointsDGV, ref HillPoint[,] measuringPoints, int numberOfRows, int numberOfColumns)
        {
            measuringPointsDGV.ClearSelection();
            measuringPointsDGV.RowCount = measuringPoints.GetLength(0) + 1;
            measuringPointsDGV.ColumnCount = measuringPoints.GetLength(1) + 1;

            for (int i = 0; i < numberOfRows; i++)
            {
                measuringPointsDGV.Columns[i].ReadOnly = true;
                measuringPointsDGV[0, i + 1].Value = "  y" + Convert.ToString(i + 1);
                for (int j = 0; j < numberOfColumns; j++)
                {
                    measuringPointsDGV[j + 1, 0].Value = "   x" + Convert.ToString(j + 1);
                    measuringPointsDGV[i + 1, j + 1].Value = measuringPoints[j, i].Z;
                }
            }
            measuringPointsDGV.Visible = true;
        }
    }
}
