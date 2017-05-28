using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using System.Linq;
using OpenTK.Graphics.OpenGL;
using Paint;

namespace OpenGL
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        private ChartManager _chartManager;
        private bool _loaded;
        Color selectedColor = Color.Red;
        ChartPoint selectedPoint;
        ChartPoint startPoint;
        ChartData.ChartTypes drawingType = ChartData.ChartTypes.Point;
        bool isOpenGl;

        public Form1()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            initWindow();
            _chartManager = new ChartManager();
            List<ChartData> chartData;
            //FileManager.InputFromFile("Resources/input.txt", out chartData);
            //_chartManager.ChartDataList.AddRange(chartData);
            CenterToScreen();         
        }

        private void initWindow()
        {
            int height = ClientSize.Height;
            pictureBox1.Height = height;
            pictureBox1.Width = ClientSize.Width * 2 / 3;
            panel1.Width = ClientSize.Width / 3;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (isOpenGl)
            {
                if (_loaded)
                {
                    e.Graphics.Clear(Color.White);
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.LoadIdentity();
                    if (_chartManager.ChartDataList.Count != 0)
                    {
                        DrawChart();
                    }
                    pictureBox1.SwapBuffers();
                }
            }
            else
            {
                graphics = e.Graphics;
                graphics.Clear(Color.White);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                if (_chartManager.ChartDataList.Count != 0)
                {
                    DrawChart(e.Graphics);
                }
            }
        }

        private void DrawChart(Graphics graphics)
        {
            foreach (var chartData in _chartManager.ChartDataList)
            {
                var pen = new Pen(chartData.ChartColor);
                var brush = new SolidBrush(chartData.ChartColor);
                var points = chartData.Points;

                graphics.TranslateTransform(chartData.CenterX, chartData.CenterY);
                graphics.RotateTransform(chartData.angle);
                graphics.ScaleTransform(chartData.Scale, chartData.Scale);
                graphics.TranslateTransform(-chartData.CenterX, -chartData.CenterY);

                if (chartData.ChartType == ChartData.ChartTypes.Point)
                {
                    var x1 = points[0].X;
                    var y1 = points[0].Y;
                    graphics.FillRectangle(brush, (float)x1 - 2.5f, (float)y1 - 2.5f, 5, 5);
                }
                else if (chartData.ChartType == ChartData.ChartTypes.Line)
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
                else if (chartData.ChartType == ChartData.ChartTypes.Rectangle)
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
                graphics.TranslateTransform(chartData.CenterX, chartData.CenterY);
                graphics.RotateTransform(-chartData.angle);
                graphics.ScaleTransform(1 / chartData.Scale, 1 / chartData.Scale);
                graphics.TranslateTransform(-chartData.CenterX, -chartData.CenterY);
            }
        }

        private void DrawChart()
        {
            foreach (var chartData in _chartManager.ChartDataList)
            {
                var pen = new Pen(chartData.ChartColor);
                var brush = new SolidBrush(chartData.ChartColor);
                var points = chartData.Points;

                GL.Color3(chartData.ChartColor);
                GL.Translate(chartData.CenterX, chartData.CenterY, 0);
                GL.Rotate(chartData.angle, 0, 0, 1);
                GL.Scale(chartData.Scale, chartData.Scale, 1);
                GL.Translate(-chartData.CenterX, -chartData.CenterY, 0);
                if (chartData.ChartType == ChartData.ChartTypes.Point)
                {
                    GL.PointSize(5);
                    GL.Begin(PrimitiveType.Points);
                    var x1 = points[0].X;
                    var y1 = points[0].Y;
                    GL.Vertex2(x1, y1);
                    GL.End();
                }
                else if (chartData.ChartType == ChartData.ChartTypes.Line)
                {
                    if (points.Count > 1)
                    {
                        GL.Begin(PrimitiveType.LineStrip);
                        var x1 = points[0].X;
                        var y1 = points[0].Y;
                        var x2 = points[1].X;
                        var y2 = points[1].Y;
                        GL.Rotate(chartData.angle, 0, 1, 0);
                        GL.Vertex2(x1, y1);
                        GL.Vertex2(x2, y2);
                        GL.End();
                    }
                }
                else if (chartData.ChartType == ChartData.ChartTypes.Rectangle)
                {
                    if (points.Count > 1)
                    {
                        var x1 = chartData.MinX;
                        var y1 = chartData.MinY;
                        var x2 = chartData.MaxX;
                        var y2 = chartData.MaxY;
                        GL.Begin(PrimitiveType.Polygon);
                        GL.Vertex2(x1, y1);
                        GL.Vertex2(x1, y2);
                        GL.Vertex2(x2, y2);
                        GL.Vertex2(x2, y1);
                        GL.End();
                    }
                }
                GL.Translate(chartData.CenterX, chartData.CenterY, 0);
                GL.Rotate(-chartData.angle, 0, 0, 1);
                GL.Scale(1 / chartData.Scale, 1 / chartData.Scale, 1);
                GL.Translate(-chartData.CenterX, -chartData.CenterY, 0);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (_loaded)
            {
                SetupViewport();
            }
            initWindow();
            pictureBox1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _loaded = true;
            GL.ClearColor(Color.White);
            SetupViewport();
        }

        private void SetupViewport()
        {
            var w = pictureBox1.Width;
            var h = pictureBox1.Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, w, h, 0, -1, 1);
            GL.Viewport(0, 0, w, h);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (startPoint != null)
            {
                if (drawingType == ChartData.ChartTypes.Line || drawingType == ChartData.ChartTypes.Rectangle)
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

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Color color = Color.FromArgb(redTrackBar.Value, greenTrackBar.Value, blueTrackBar.Value);
            ChartPoint point = new ChartPoint(e.X, e.Y);
            if (drawingType == ChartData.ChartTypes.Point)
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
            if (startPoint != null)
            {
                if (drawingType == ChartData.ChartTypes.Line || drawingType == ChartData.ChartTypes.Rectangle)
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

        private ChartPoint getNearClickPoint(double x, double y)
        {
            foreach(ChartData chartData in _chartManager.ChartDataList)
            {
                foreach(ChartPoint chartPoint in chartData.Points)
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

        private void raznToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _chartManager.CreateRaznChart();
            pictureBox1.Invalidate();
        }

        private void pointButton_Click(object sender, EventArgs e)
        {
            drawingType = ChartData.ChartTypes.Point;
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            drawingType = ChartData.ChartTypes.Line;
        }

        private void rectangleButton_Click(object sender, EventArgs e)
        {
            drawingType = ChartData.ChartTypes.Rectangle;
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

        private void checkBoxIsOpenGl_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            isOpenGl = (checkBox.CheckState == CheckState.Checked);
            pictureBox1.Invalidate();
        }

        private void pictureBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ChartData data = _chartManager.ChartDataList.Last();
            switch (e.KeyChar)
            {
                case (char)Keys.Escape:
                    Application.Exit();
                    break;

                case 'q':
                    data.angle += 10;
                    break;

                case 'e':
                    data.angle -= 10;
                    break;

                case 'z':
                    data.Scale *= 2;
                    break;

                case 'x':
                    data.Scale /= 2;
                    break;
            }
            pictureBox1.Invalidate();
        }
    }
}
