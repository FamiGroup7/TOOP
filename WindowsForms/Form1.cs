﻿using System;
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
        ChartPoint selectedPoint;
        double zoomX = 0.0, zoomY = 0.0;
        double stepZoomX = 0.0, stepZoomY = 0.0;

        public Form1()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            initWindow();
            _chartManager = new ChartManager();
            SetupPanel();      
        }

        private void initWindow()
        {
            int height = ClientSize.Height - MainMenuStrip.Height;
            panel1.Height = height;
            pictureBox1.Height = height;
            pictureBox1.Width = ClientSize.Width * 2 / 3;
            panel1.Width = ClientSize.Width / 3;
        }

        private void SetupPanel()
        {
            return;
            if (_chartManager == null)
            {
                return;
            }
            panel1.Controls.Clear();
            for (int i = 0, k = 0; i < _chartManager.ChartDataList.Count; i++, k++)
            {
                List<MyColor> colors = new List<MyColor>
                {
                    new MyColor {color = Color.Black, Name = "Black" },
                    new MyColor {color = Color.Blue, Name = "Blue" },
                    new MyColor {color = Color.Red, Name = "Red" },
                    new MyColor {color = Color.Green, Name = "Green" }
                };

                ChartData chartData = _chartManager.ChartDataList[i];
                chartData.ChartColor = colors[i % colors.Count].color;

                Button buttonColor = new Button();
                buttonColor.Size = new Size(60, 20);
                buttonColor.Name = "" + i + "";
                buttonColor.Location = new Point(20, 20 + (k * 40));
                buttonColor.BackColor = chartData.ChartColor;
                panel1.Controls.Add(buttonColor);

                Button buttonShowPoints = new Button();
                buttonShowPoints.Size = new Size(160, 20);
                buttonShowPoints.Name = "" + i + "";
                buttonShowPoints.Text = "Show points";
                buttonShowPoints.Click += buttonShowPoints_Click;
                buttonShowPoints.Location = new Point(100, 20 + (k * 40));
                panel1.Controls.Add(buttonShowPoints);

                ComboBox comboBox = new ComboBox();
                comboBox.Name = "" + i + "";
                comboBox.DataSource = colors;
                comboBox.Size = new Size(75, 20);
                comboBox.DisplayMember = "Name";
                comboBox.Location = new Point(buttonColor.Location.X, buttonColor.Location.Y);
                comboBox.SelectedIndexChanged += comboBox_SelectedIndexChanged;
                panel1.Controls.Add(comboBox);

                if (chartData.ShowPoints)
                {
                    Button buttonUpdate = new Button();
                    buttonUpdate.Size = new Size(160, 20);
                    buttonUpdate.Name = "" + i + "";
                    buttonUpdate.Text = "Update";
                    buttonUpdate.Click += buttonUpdate_Click;
                    buttonUpdate.Location = new Point(280, 20 + (k * 40));
                    panel1.Controls.Add(buttonUpdate);

                    for (int j = 0; j < chartData.Points.Count; j++, k++)
                    {
                        TextBox textBoxX = new TextBox();
                        textBoxX.Size = new Size(60, 20);
                        textBoxX.Name = "Line" + i + "X" + j + "";
                        textBoxX.Location = new Point(100, 20 + ((k + 1) * 40));
                        textBoxX.Text = "" + chartData.Points[j].X + "";
                        textBoxX.TextChanged += textBox_TextChanged;
                        panel1.Controls.Add(textBoxX);

                        TextBox textBoxY = new TextBox();
                        textBoxY.Size = new Size(60, 20);
                        textBoxY.Name = "Line" + i + "Y" + j + "";
                        textBoxY.Location = new Point(180, 20 + ((k + 1) * 40));
                        textBoxY.Text = "" + chartData.Points[j].Y + "";
                        textBoxY.TextChanged += textBox_TextChanged;
                        panel1.Controls.Add(textBoxY);
                    }
                }
            }
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

                if (points.Count == 1)
                {
                    var x1 = points[0].X;
                    var y1 = points[0].Y;
                    graphics.FillRectangle(brush, (float)x1 - 2.5f, (float)y1 - 2.5f, 5, 5);
                }
            }
        }

        private void buttonShowPoints_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ChartData chartData = _chartManager.ChartDataList[Convert.ToInt32(button.Name)];
            chartData.ShowPoints = !chartData.ShowPoints;
            SetupPanel();
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
                SetupPanel();
                pictureBox1.Invalidate();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            initWindow();
            pictureBox1.Invalidate();
            SetupPanel();
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_chartManager == null)
            {
                return;
            }
            if (_chartManager.ChartDataList.Count != 0)
            {
                double x, y;
                getWindowCoordinates(out x, out y, e);
                InfoTextBox.Text = "(" + Math.Round(x, 2) + ", " + Math.Round(y, 2) + ")";
                Invalidate();
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
            double x, y;
            getWindowCoordinates(out x, out y, e);
            ChartPoint point = new ChartPoint(e.X, e.Y);
            ChartData data = new ChartData(point);
            _chartManager.ChartDataList.Add(data);
            //selectedPoint = getNearClickPoint(x, y);
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
            SetupPanel();
        }

        private void raznToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _chartManager.CreateRaznChart();
            pictureBox1.Invalidate();
            SetupPanel();
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
