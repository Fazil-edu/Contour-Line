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
        private HillPoint[,] measuringPoints;
        TabControl Profiles = new TabControl()
        {
            Location = new Point(0, 394),
            Width = 880,
            Height = 511
        };
        private void SelectFileToolStripMenu_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog() {};
            openDlg.ShowDialog();
            string path = openDlg.FileName;
            List<HillPoint> rawData = DataHandling.CheckTheFile(path, ref fileSelected);
            if (fileSelected)
            {
                textBoxFilePath.Text = path;
                textBoxFilePath.Show();
                PathOfTheFile.Show();
                CalculateStripMenu.Enabled = true;
                DrawToolStripMenu.Enabled = true;
                DataHandling.TransformData(ref rawData, ref measuringPoints, ref numberOfRows, ref numberOfColumns);
                DataHandling.SetDataGridViewDGW(ref measuringPointsDGV, ref measuringPoints, this.numberOfRows, this.numberOfColumns);
            }
        }
        private void VolumeToolStripMenu_Click(object sender, EventArgs e)
        {
            if (fileSelected)
            {
                volumeNumberLabel.Text = Convert.ToString(Calculation.Volume(ref this.measuringPoints,this.numberOfRows, this.numberOfColumns)) + " m^3";
                volumeNumberLabel.Show();
                volumeWordLabel.Show();
            }
            else
            {
                MessageBox.Show("You did not selected a file");
            }
        }
        private void NumberOfTrucksTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberOfTrucksTextBox.MaxLength = 3;
            if (fileSelected)
            {
                if (!(('0' <= e.KeyChar && e.KeyChar <= '9') || e.KeyChar == (char)Keys.Back)) // 48 == 0 keycode and 57= 9 keycode
                {
                    e.Handled = true;
                }
                if (e.KeyChar == 13) // it is enter
                {
                    int numberOfExistingTrucks = Convert.ToInt32(NumberOfTrucksTextBox.Text);
                    double volume = Calculation.Volume(ref this.measuringPoints, this.numberOfRows, this.numberOfColumns);

                    Calculation.SetTransportTimeDGV(volume, numberOfExistingTrucks, ref this.TransportTimeDGV);
                }
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("You did not selected a file");
            }
        }
        private void XPerspectiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profiles.TabPages.Clear();
            double maxHeight = Calculation.FindMaxHeight(ref this.measuringPoints, this.numberOfRows, this.numberOfColumns);
            this.Controls.Add(Drawing.BarShapeXPerspective(ref Profiles ,ref this.measuringPoints, "y", numberOfRows, numberOfColumns, maxHeight));

        }
        private void YPerspectiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profiles.TabPages.Clear();
            double maxHeight = Calculation.FindMaxHeight(ref this.measuringPoints, this.numberOfRows, this.numberOfColumns);
            this.Controls.Add(Drawing.BarShapeYPerspective(ref Profiles, ref this.measuringPoints, "x", numberOfRows, numberOfColumns, maxHeight));
        }
    }
}
