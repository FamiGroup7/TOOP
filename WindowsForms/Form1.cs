using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using System.Linq;
using Paint;

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        private ChartManager _chartManager;
        public const double ChartMargin = 15;
        Color selectedColor = Color.Red;
        ChartPoint startPoint;
        double zoomX = 0.0, zoomY = 0.0;
        double stepZoomX = 0.0, stepZoomY = 0.0;
        int drawingType = 1; //1 - point, 2 - line, 3 - rectangle

        public Form1()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            initWindow();
            _chartManager = new ChartManager();
        }

        private void initWindow()
        {
            int height = ClientSize.Height;
            panel1.Height = height;
            pictureBox1.Height = height;
            pictureBox1.Width = ClientSize.Width * 2 / 3;
            panel1.Width = ClientSize.Width / 3;
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            if (_chartManager.ChartDataList.Count != 0)
            {
                DrawChart(e.Graphics);
            }
        }

        private void DrawChart(Graphics graphics)
        {
            foreach (var chartData in _chartManager.ChartDataList)
            {
                var pen = new Pen(chartData.ChartColor);
                var brush = new SolidBrush(chartData.ChartColor);
                var points = chartData.Points;

                if (chartData.ChartType == 1)
                {
                    var x1 = points[0].X;
                    var y1 = points[0].Y;
                    graphics.FillRectangle(brush, (float)x1 - 2.5f, (float)y1 - 2.5f, 5, 5);
                }
                else if (chartData.ChartType == 2)
                {
                    if (points.Count > 1)
                    {
                        var x1 = points[0].X;
                        var y1 = points[0].Y;
                        var x2 = points[1].X;
                        var y2 = points[1].Y;
                        graphics.DrawLine(pen, (float)x1, (float)y1, (float)x2, (float)y2);
                    }
                }
                else if (chartData.ChartType == 3)
                {
                    if (points.Count > 1)
                    {
                        var x1 = chartData.MinX;
                        var y1 = chartData.MinY;
                        var x2 = chartData.MaxX;
                        var y2 = chartData.MaxY;
                        graphics.FillRectangle(brush, (float)x1, (float)y1, (float)(x2 - x1), (float)(y2 - y1));
                    }
                }
            }
        }

        private void buttonShowPoints_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ChartData chartData = _chartManager.ChartDataList[Convert.ToInt32(button.Name)];
            chartData.ShowPoints = !chartData.ShowPoints;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int i = Convert.ToInt32(button.Name);
            ChartData chartData = _chartManager.ChartDataList[i];
            for (int j = 0; j < chartData.Points.Count; j++)
            {
                ChartPoint point = chartData.Points[j];
                TextBox textBoxX = (TextBox)panel1.Controls.Find("Line" + i + "X" + j + "", false).FirstOrDefault();
                TextBox textBoxY = (TextBox)panel1.Controls.Find("Line" + i + "Y" + j + "", false).FirstOrDefault();
                point.X = Convert.ToDouble(textBoxX.Text);
                point.Y = Convert.ToDouble(textBoxY.Text);
            }
            pictureBox1.Invalidate();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combox = (ComboBox)sender;
            MyColor color = (MyColor)combox.SelectedItem;
            Button button = (Button)panel1.Controls[combox.Name];
            button.BackColor = color.color;
            _chartManager.ChartDataList[Convert.ToInt32(combox.Name)].ChartColor = color.color;
            pictureBox1.Invalidate();
        }

        private void addLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();


            OFD.Filter = "TXT files (*.txt)|*.txt|All files (*.*)|*.*";
            OFD.RestoreDirectory = true;
            string fileName;

            if (OFD.ShowDialog() == DialogResult.OK)
            {
                fileName = OFD.FileName;   //Путь файла с начальным приближением
                ChartData chartData = new ChartData();
                FileManager.InputLineFromFile(fileName, out chartData);
                _chartManager.ChartDataList.Add(chartData);
                pictureBox1.Invalidate();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            initWindow();
            pictureBox1.Invalidate();
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (startPoint != null)
            {
                if (drawingType == 2 || drawingType == 3)
                {
                    ChartData data = _chartManager.ChartDataList.Last();
                    ChartPoint point = new ChartPoint(e.X, e.Y);
                    List<ChartPoint> list = data.Points;
                    if (list.Count > 1)
                    {
                        list.RemoveAt(1);
                    }
                    list.Add(point);
                    pictureBox1.Invalidate();
                }
            }
        }

        private void getWindowCoordinates(out double x, out double y, MouseEventArgs e)
        {
            var width = pictureBox1.Width;
            var height = pictureBox1.Height;
            var margin = ChartMargin;
            var minX = Math.Floor(_chartManager.MinX);
            var maxX = Math.Ceiling(_chartManager.MaxX);
            var minY = Math.Floor(_chartManager.MinY);
            var maxY = Math.Ceiling(_chartManager.MaxY);
            x = (e.X - margin) / (width - margin) * (maxX - minX) + minX;
            y = (height - margin - e.Y) / (height - margin) * (maxY - minY) + minY;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Color color = Color.FromArgb(redTrackBar.Value, greenTrackBar.Value, blueTrackBar.Value);
            double x, y;
            getWindowCoordinates(out x, out y, e);
            ChartPoint point = new ChartPoint(e.X, e.Y);
            if (drawingType == 1)
            {
                ChartData data = new ChartData(point);
                data.ChartColor = color;
                data.ChartType = drawingType;
                _chartManager.ChartDataList.Add(data);
            }
            else
            {
                if (startPoint != null)
                {
                    ChartData data = _chartManager.ChartDataList.Last();
                    List<ChartPoint> list = data.Points;
                    if (list.Count > 1)
                    {
                        list.RemoveAt(1);
                    }
                    list.Add(point);
                    startPoint = null;
                }
                else
                {
                    List<ChartPoint> list = new List<ChartPoint>();
                    list.Add(point);
                    ChartData data = new ChartData(list);
                    data.ChartColor = color;
                    data.ChartType = drawingType;
                    _chartManager.ChartDataList.Add(data);
                    startPoint = point;
                }
            }
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            double x, y;
            getWindowCoordinates(out x, out y, e);
        }

        private ChartPoint getNearClickPoint(double x, double y)
        {
            foreach (ChartData chartData in _chartManager.ChartDataList)
            {
                foreach (ChartPoint chartPoint in chartData.Points)
                {
                    var minY = Math.Floor(_chartManager.MinY);
                    var maxY = Math.Ceiling(_chartManager.MaxY);
                    var lengthY = maxY - minY;
                    var stepY = (lengthY / 10) / 10;

                    var minX = Math.Floor(_chartManager.MinX);
                    var maxX = Math.Ceiling(_chartManager.MaxX);
                    var lengthX = maxX - minX;
                    var stepX = (lengthX / 10) / 10;

                    if (chartPoint.X < x + stepX &&
                        chartPoint.X > x - stepX &&
                        chartPoint.Y < y + stepY &&
                        chartPoint.Y > y - stepY)
                    {
                        return chartPoint;
                    }
                }
            }
            return null;
        }

        private void sumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _chartManager.CreateSumChart();
            pictureBox1.Invalidate();
        }

        private void pointButton_Click(object sender, EventArgs e)
        {
            drawingType = 1;
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            drawingType = 2;
        }

        private void rectangleButton_Click(object sender, EventArgs e)
        {
            drawingType = 3;
        }

        private void redTrackBar_ValueChanged(object sender, EventArgs e)
        {
            redTextBox.Text = Convert.ToString(redTrackBar.Value);
        }

        private void greenTrackBar_ValueChanged(object sender, EventArgs e)
        {
            greenTextBox.Text = Convert.ToString(greenTrackBar.Value);
        }

        private void blueTrackBar_ValueChanged(object sender, EventArgs e)
        {
            blueTextBox.Text = Convert.ToString(blueTrackBar.Value);
        }

        private void redTextBox_TextChanged(object sender, EventArgs e)
        {
            if (redTextBox.Text != "")
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(redTextBox.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    redTextBox.Text = redTextBox.Text.Remove(redTextBox.Text.Length - 1);
                }
                else
                {
                    redTrackBar.Value = Convert.ToInt16(redTextBox.Text);
                }
            }
            else
            {
                redTextBox.Text = "0";
            }
        }

        private void greenTextBox_TextChanged(object sender, EventArgs e)
        {
            if (greenTextBox.Text != "")
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(greenTextBox.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    greenTextBox.Text = greenTextBox.Text.Remove(greenTextBox.Text.Length - 1);
                }
                else
                {
                    greenTrackBar.Value = Convert.ToInt16(greenTextBox.Text);
                }
            }
            else
            {
                greenTextBox.Text = "0";
            }
        }

        private void blueTextBox_TextChanged(object sender, EventArgs e)
        {
            if (blueTextBox.Text != "")
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(blueTextBox.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    blueTrackBar.Text = blueTextBox.Text.Remove(blueTextBox.Text.Length - 1);
                }
                else
                {
                    blueTrackBar.Value = Convert.ToInt16(blueTextBox.Text);
                }
            }
            else
            {
                blueTextBox.Text = "0";
            }
        }

        private void raznToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _chartManager.CreateRaznChart();
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {

            if (e.Delta > 0)
            {
                zoomX += stepZoomX;
                zoomY += stepZoomY;
            }
            else
            {
                zoomX -= stepZoomX;
                zoomY -= stepZoomY;
            }
            pictureBox1.Invalidate();

        }
    }
}
