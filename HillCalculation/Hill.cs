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
    public partial class Hill : Form
    {
        public Hill()
        {
            InitializeComponent();
        }
        private int numberOfRows;
        private int numberOfColumns;
        private bool fileSelected;
        private Vector[,] measuringPoints;
        TabControl Profiles = new TabControl()
        {
            Location = new System.Drawing.Point(0, 394),
            Width = 880,
            Height = 511
        };
        PlotView myPlotView = new PlotView()
        {
            //Width = 758,
            //Height = 758,
              Dock = DockStyle.Fill,
              BackColor = Color.White,
              Location = new System.Drawing.Point(12, 16),
              Model = new PlotModel(),
        };

        double maxHeightOfHill = 0;
        double minHeightOfHill = 0;

        public Vector[,] MeasuringPoints { get => measuringPoints; set => measuringPoints = value; }


        private void SelectFileToolStripMenu_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog() {};
            openDlg.ShowDialog();
            string path = openDlg.FileName;
            List<Vector> rawData = DataHandling.CheckTheFile(path, ref fileSelected,  this.MeasuringPoints);
            if (fileSelected)
            {
                this.Profiles.TabPages.Clear();
                this.Profiles.Visible = false;
                this.myPlotView.Model.Series.Clear();
                this.myPlotView.Visible = false;
                this.volumeNumberLabel.Text = "";
                this.volumeNumberLabel.Visible = false;
                this.volumeWordLabel.Visible = false;
                this.NumberOfTrucksTextBox.Text = "";
                this.TransportTimeDGV.Visible = false;
                textBoxFilePath.Text = path;
                textBoxFilePath.Show();
                PathOfTheFile.Show();
                CalculateStripMenu.Enabled = true;
                DrawToolStripMenu.Enabled = true;
                this.MeasuringPoints  = DataHandling.TransformData(rawData, ref numberOfRows, ref numberOfColumns);
                DataHandling.SetDataGridViewDGW(this.measuringPointsDGV, this.MeasuringPoints, this.numberOfRows, this.numberOfColumns);
                fileSelected = false;
            }
        }
        private void VolumeToolStripMenu_Click(object sender, EventArgs e)
        {
            volumeNumberLabel.Text = Convert.ToString(Calculation.Volume(this.MeasuringPoints, this.numberOfRows, this.numberOfColumns)) + " m^3";
            volumeNumberLabel.Show();
            volumeWordLabel.Show();
        }
        private void NumberOfTrucksTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberOfTrucksTextBox.MaxLength = 3;
            if (!(('0' <= e.KeyChar && e.KeyChar <= '9') || e.KeyChar == (char)Keys.Back)) // 48 == 0 keycode and 57= 9 keycode
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13) // it is enter
            {
                int numberOfExistingTrucks = Convert.ToInt32(NumberOfTrucksTextBox.Text);
                double volume = Calculation.Volume(this.MeasuringPoints, this.numberOfRows, this.numberOfColumns);

                Calculation.SetTransportTimeDGV(volume, numberOfExistingTrucks, this.TransportTimeDGV);
                volumeNumberLabel.Text = Convert.ToString(Calculation.Volume(this.MeasuringPoints, this.numberOfRows, this.numberOfColumns)) + " m^3";
            }
        }
        private void XPerspectiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profiles.TabPages.Clear();
            Calculation.FindMaxHeightOfHill(this.MeasuringPoints, this.numberOfRows, this.numberOfColumns, ref this.maxHeightOfHill);
            Drawing.BarShapeXPerspective(Profiles, this.MeasuringPoints, "y", numberOfRows, numberOfColumns, this.maxHeightOfHill);
            this.splitContainer.Panel1.Controls.Add(this.Profiles);


        }
        private void YPerspectiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profiles.TabPages.Clear();
            Calculation.FindMaxHeightOfHill( this.MeasuringPoints, this.numberOfRows, this.numberOfColumns, ref this.maxHeightOfHill);
            Drawing.BarShapeYPerspective(Profiles,this.MeasuringPoints, "x", numberOfRows, numberOfColumns, this.maxHeightOfHill);
            this.splitContainer.Panel1.Controls.Add(this.Profiles);
        }
        private void DrawContourLinesToolStripMenuItem(object sender, EventArgs e)
        {
            Calculation.FindMaxHeightOfHill(MeasuringPoints, numberOfRows, numberOfColumns, ref this.maxHeightOfHill);
            Calculation.FindMinHeightOfHill(MeasuringPoints, numberOfRows, numberOfColumns, ref this.minHeightOfHill);
            LinesSortedByAllHeights linesSortedByAllHeights = Calculation.SortLinesByAllHeights(MeasuringPoints, numberOfRows, numberOfColumns, this.maxHeightOfHill,this.minHeightOfHill);
            AllInterpolatedPoints allInterpolatedPoints = Calculation.FindInterpolationPoints(linesSortedByAllHeights, this.maxHeightOfHill);
            AllContourLines allHeightsWithAllContourLines = Calculation.FindAllContourLines(allInterpolatedPoints);
            Drawing.DrawContourLines(this.myPlotView, allHeightsWithAllContourLines);
            this.splitContainer.Panel2.Controls.Add(this.myPlotView);
        }

        #region Area

        //private void DrawRedAreaClick(object sender, EventArgs e)
        //{
        //    Tuple<List<LineSeries>, List<LineSeries>> allLineSeries = Calculation.FindRedAreaConnection(ref measuringPoints, numberOfRows, numberOfColumns, 1);
        //    Drawing.DrawRedAreaConnection(allLineSeries, ref myPlotView);
        //    this.splitContainer.Panel2.Controls.Add(this.myPlotView);
        //    myPlotView.Model.InvalidatePlot(true);
        //}

        //private void DrawGreenAreaToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Tuple<List<LineSeries>, List<LineSeries>> allLineSeries = Calculation.FindGreenAreaConnection(ref measuringPoints, numberOfRows, numberOfColumns, 1);
        //    Drawing.DrawGreenAreaConnection(allLineSeries, ref myPlotView);
        //    this.splitContainer.Panel2.Controls.Add(this.myPlotView);
        //    myPlotView.Model.InvalidatePlot(true);
        //}

        #endregion
    }
}
