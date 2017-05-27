namespace OpenGL
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxIsOpenGl = new System.Windows.Forms.CheckBox();
            this.greenTextBox = new System.Windows.Forms.TextBox();
            this.greenTrackBar = new System.Windows.Forms.TrackBar();
            this.blueTextBox = new System.Windows.Forms.TextBox();
            this.blueTrackBar = new System.Windows.Forms.TrackBar();
            this.redTextBox = new System.Windows.Forms.TextBox();
            this.redTrackBar = new System.Windows.Forms.TrackBar();
            this.rectangleButton = new System.Windows.Forms.Button();
            this.lineButton = new System.Windows.Forms.Button();
            this.pointButton = new System.Windows.Forms.Button();
            this.addLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raznToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new OpenTK.GLControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.checkBoxIsOpenGl);
            this.panel1.Controls.Add(this.greenTextBox);
            this.panel1.Controls.Add(this.greenTrackBar);
            this.panel1.Controls.Add(this.blueTextBox);
            this.panel1.Controls.Add(this.blueTrackBar);
            this.panel1.Controls.Add(this.redTextBox);
            this.panel1.Controls.Add(this.redTrackBar);
            this.panel1.Controls.Add(this.rectangleButton);
            this.panel1.Controls.Add(this.lineButton);
            this.panel1.Controls.Add(this.pointButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(857, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 692);
            this.panel1.TabIndex = 1;
            // 
            // checkBoxIsOpenGl
            // 
            this.checkBoxIsOpenGl.AutoSize = true;
            this.checkBoxIsOpenGl.Location = new System.Drawing.Point(156, 31);
            this.checkBoxIsOpenGl.Name = "checkBoxIsOpenGl";
            this.checkBoxIsOpenGl.Size = new System.Drawing.Size(62, 17);
            this.checkBoxIsOpenGl.TabIndex = 12;
            this.checkBoxIsOpenGl.Text = "OpenGl";
            this.checkBoxIsOpenGl.UseVisualStyleBackColor = true;
            this.checkBoxIsOpenGl.CheckedChanged += new System.EventHandler(this.checkBoxIsOpenGl_CheckedChanged);
            // 
            // greenTextBox
            // 
            this.greenTextBox.Location = new System.Drawing.Point(156, 258);
            this.greenTextBox.Name = "greenTextBox";
            this.greenTextBox.Size = new System.Drawing.Size(100, 20);
            this.greenTextBox.TabIndex = 11;
            this.greenTextBox.Text = "0";
            this.greenTextBox.TextChanged += new System.EventHandler(this.greenTextBox_TextChanged);
            // 
            // greenTrackBar
            // 
            this.greenTrackBar.Location = new System.Drawing.Point(25, 258);
            this.greenTrackBar.Maximum = 255;
            this.greenTrackBar.Name = "greenTrackBar";
            this.greenTrackBar.Size = new System.Drawing.Size(104, 45);
            this.greenTrackBar.TabIndex = 10;
            this.greenTrackBar.ValueChanged += new System.EventHandler(this.greenTrackBar_ValueChanged);
            // 
            // blueTextBox
            // 
            this.blueTextBox.Location = new System.Drawing.Point(156, 312);
            this.blueTextBox.Name = "blueTextBox";
            this.blueTextBox.Size = new System.Drawing.Size(100, 20);
            this.blueTextBox.TabIndex = 9;
            this.blueTextBox.Text = "0";
            this.blueTextBox.TextChanged += new System.EventHandler(this.blueTextBox_TextChanged);
            // 
            // blueTrackBar
            // 
            this.blueTrackBar.Location = new System.Drawing.Point(25, 312);
            this.blueTrackBar.Maximum = 255;
            this.blueTrackBar.Name = "blueTrackBar";
            this.blueTrackBar.Size = new System.Drawing.Size(104, 45);
            this.blueTrackBar.TabIndex = 8;
            this.blueTrackBar.ValueChanged += new System.EventHandler(this.blueTrackBar_ValueChanged);
            // 
            // redTextBox
            // 
            this.redTextBox.Location = new System.Drawing.Point(156, 207);
            this.redTextBox.Name = "redTextBox";
            this.redTextBox.Size = new System.Drawing.Size(100, 20);
            this.redTextBox.TabIndex = 7;
            this.redTextBox.Text = "0";
            this.redTextBox.TextChanged += new System.EventHandler(this.redTextBox_TextChanged);
            // 
            // redTrackBar
            // 
            this.redTrackBar.Location = new System.Drawing.Point(25, 207);
            this.redTrackBar.Maximum = 255;
            this.redTrackBar.Name = "redTrackBar";
            this.redTrackBar.Size = new System.Drawing.Size(104, 45);
            this.redTrackBar.TabIndex = 6;
            this.redTrackBar.ValueChanged += new System.EventHandler(this.redTrackBar_ValueChanged);
            // 
            // rectangleButton
            // 
            this.rectangleButton.Location = new System.Drawing.Point(25, 132);
            this.rectangleButton.Name = "rectangleButton";
            this.rectangleButton.Size = new System.Drawing.Size(75, 23);
            this.rectangleButton.TabIndex = 5;
            this.rectangleButton.Text = "rectangle";
            this.rectangleButton.UseVisualStyleBackColor = true;
            this.rectangleButton.Click += new System.EventHandler(this.rectangleButton_Click);
            // 
            // lineButton
            // 
            this.lineButton.Location = new System.Drawing.Point(25, 85);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(75, 23);
            this.lineButton.TabIndex = 4;
            this.lineButton.Text = "line";
            this.lineButton.UseVisualStyleBackColor = true;
            this.lineButton.Click += new System.EventHandler(this.lineButton_Click);
            // 
            // pointButton
            // 
            this.pointButton.Location = new System.Drawing.Point(25, 31);
            this.pointButton.Name = "pointButton";
            this.pointButton.Size = new System.Drawing.Size(75, 23);
            this.pointButton.TabIndex = 3;
            this.pointButton.Text = "point";
            this.pointButton.UseVisualStyleBackColor = true;
            this.pointButton.Click += new System.EventHandler(this.pointButton_Click);
            // 
            // addLineToolStripMenuItem
            // 
            this.addLineToolStripMenuItem.Name = "addLineToolStripMenuItem";
            this.addLineToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // sumToolStripMenuItem
            // 
            this.sumToolStripMenuItem.Name = "sumToolStripMenuItem";
            this.sumToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // raznToolStripMenuItem
            // 
            this.raznToolStripMenuItem.Name = "raznToolStripMenuItem";
            this.raznToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(851, 692);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.VSync = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 692);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem addLineToolStripMenuItem;
        private OpenTK.GLControl pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem sumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raznToolStripMenuItem;
        private System.Windows.Forms.Button rectangleButton;
        private System.Windows.Forms.Button lineButton;
        private System.Windows.Forms.Button pointButton;
        private System.Windows.Forms.TextBox greenTextBox;
        private System.Windows.Forms.TrackBar greenTrackBar;
        private System.Windows.Forms.TextBox blueTextBox;
        private System.Windows.Forms.TrackBar blueTrackBar;
        private System.Windows.Forms.TextBox redTextBox;
        private System.Windows.Forms.TrackBar redTrackBar;
        private System.Windows.Forms.CheckBox checkBoxIsOpenGl;
    }
}

