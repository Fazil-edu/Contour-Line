using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


namespace HillCalculation
{
    public static class DataHandling
    {
        public static List<Vector> CheckTheFile(string path, ref bool fileSelected, Vector[,] measuringPoints)
        {
            List<Vector> rawData = new List<Vector>();
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
                            tuple[2] = tuple[2].Replace(".", ",");   // Dezimaltrennzeichen vom Komma zu Punkt konvertieren

                            rawData.Add(new Vector(Convert.ToInt32(tuple[0]), Convert.ToInt32(tuple[1]), Convert.ToDouble(tuple[2])));
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
        public static Vector[,] TransformData(List<Vector> rawData, ref int numberOfRows, ref int numberOfColumns)
        {
            for (int i = 1; i < rawData.Count; i++)
            {
                if (rawData[0].X == rawData[i].X)
                {
                    numberOfColumns = i;
                    break;
                }
            }

            numberOfRows = Convert.ToInt32(rawData.Count / numberOfColumns);
            Vector[,] measuringPoints = new Vector[numberOfRows, numberOfColumns];
            int cnt = 0;
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    Vector a = rawData[cnt];
                    measuringPoints[numberOfRows - 1 - i, j] = rawData[cnt];
                    if (rawData[cnt].Z == 20)
                    {

                    }
                    cnt++;
                }
            }
            return measuringPoints;
        }
        public static void SetDataGridViewDGW(DataGridView measuringPointsDGV, Vector[,] measuringPoints, int numberOfRows, int numberOfColumns)
        {
            measuringPointsDGV.ClearSelection();
            measuringPointsDGV.RowCount = measuringPoints.GetLength(0) + 1;
            measuringPointsDGV.ColumnCount = measuringPoints.GetLength(1) + 1;

            for (int i = 0; i < numberOfRows; i++)
            {
                
                measuringPointsDGV[0, i + 1].Value = "  y" + Convert.ToString(numberOfRows - i);
                for (int j = 0; j < numberOfColumns; j++)
                {
                    measuringPointsDGV.Columns[j].ReadOnly = true;
                    measuringPointsDGV[j + 1, 0].Value = "   x" + Convert.ToString(j + 1);
                    measuringPointsDGV[j + 1, i + 1].Value = measuringPoints[i, j].Z;
                }
            }
            measuringPointsDGV.Visible = true;
        }
    }
}
