namespace WindowsForms
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.greenTextBox = new System.Windows.Forms.TextBox();
            this.greenTrackBar = new System.Windows.Forms.TrackBar();
            this.blueTextBox = new System.Windows.Forms.TextBox();
            this.blueTrackBar = new System.Windows.Forms.TrackBar();
            this.redTextBox = new System.Windows.Forms.TextBox();
            this.redTrackBar = new System.Windows.Forms.TrackBar();
            this.rectangleButton = new System.Windows.Forms.Button();
            this.lineButton = new System.Windows.Forms.Button();
            this.pointButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(861, 692);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            this.pictureBox1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseWheel);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
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
            // greenTextBox
            // 
            this.greenTextBox.Location = new System.Drawing.Point(175, 255);
            this.greenTextBox.Name = "greenTextBox";
            this.greenTextBox.Size = new System.Drawing.Size(100, 20);
            this.greenTextBox.TabIndex = 17;
            this.greenTextBox.Text = "0";
            this.greenTextBox.TextChanged += new System.EventHandler(this.greenTextBox_TextChanged);
            // 
            // greenTrackBar
            // 
            this.greenTrackBar.Location = new System.Drawing.Point(44, 255);
            this.greenTrackBar.Maximum = 255;
            this.greenTrackBar.Name = "greenTrackBar";
            this.greenTrackBar.Size = new System.Drawing.Size(104, 45);
            this.greenTrackBar.TabIndex = 16;
            this.greenTrackBar.ValueChanged += new System.EventHandler(this.greenTrackBar_ValueChanged);
            // 
            // blueTextBox
            // 
            this.blueTextBox.Location = new System.Drawing.Point(175, 309);
            this.blueTextBox.Name = "blueTextBox";
            this.blueTextBox.Size = new System.Drawing.Size(100, 20);
            this.blueTextBox.TabIndex = 15;
            this.blueTextBox.Text = "0";
            this.blueTextBox.TextChanged += new System.EventHandler(this.blueTextBox_TextChanged);
            // 
            // blueTrackBar
            // 
            this.blueTrackBar.Location = new System.Drawing.Point(44, 309);
            this.blueTrackBar.Maximum = 255;
            this.blueTrackBar.Name = "blueTrackBar";
            this.blueTrackBar.Size = new System.Drawing.Size(104, 45);
            this.blueTrackBar.TabIndex = 14;
            this.blueTrackBar.ValueChanged += new System.EventHandler(this.blueTrackBar_ValueChanged);
            // 
            // redTextBox
            // 
            this.redTextBox.Location = new System.Drawing.Point(175, 204);
            this.redTextBox.Name = "redTextBox";
            this.redTextBox.Size = new System.Drawing.Size(100, 20);
            this.redTextBox.TabIndex = 13;
            this.redTextBox.Text = "0";
            this.redTextBox.TextChanged += new System.EventHandler(this.redTextBox_TextChanged);
            // 
            // redTrackBar
            // 
            this.redTrackBar.Location = new System.Drawing.Point(44, 204);
            this.redTrackBar.Maximum = 255;
            this.redTrackBar.Name = "redTrackBar";
            this.redTrackBar.Size = new System.Drawing.Size(104, 45);
            this.redTrackBar.TabIndex = 12;
            this.redTrackBar.ValueChanged += new System.EventHandler(this.redTrackBar_ValueChanged);
            // 
            // rectangleButton
            // 
            this.rectangleButton.Location = new System.Drawing.Point(44, 121);
            this.rectangleButton.Name = "rectangleButton";
            this.rectangleButton.Size = new System.Drawing.Size(75, 23);
            this.rectangleButton.TabIndex = 18;
            this.rectangleButton.Text = "Rectangle";
            this.rectangleButton.Click += new System.EventHandler(this.rectangleButton_Click);
            // 
            // lineButton
            // 
            this.lineButton.Location = new System.Drawing.Point(44, 76);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(75, 23);
            this.lineButton.TabIndex = 19;
            this.lineButton.Text = "Line";
            this.lineButton.Click += new System.EventHandler(this.lineButton_Click);
            // 
            // pointButton
            // 
            this.pointButton.Location = new System.Drawing.Point(44, 30);
            this.pointButton.Name = "pointButton";
            this.pointButton.Size = new System.Drawing.Size(75, 23);
            this.pointButton.TabIndex = 0;
            this.pointButton.Text = "point";
            this.pointButton.UseVisualStyleBackColor = true;
            this.pointButton.Click += new System.EventHandler(this.pointButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 692);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button rectangleButton;
        private System.Windows.Forms.Button lineButton;
        private System.Windows.Forms.Button pointButton;
        private System.Windows.Forms.TextBox greenTextBox;
        private System.Windows.Forms.TrackBar greenTrackBar;
        private System.Windows.Forms.TextBox blueTextBox;
        private System.Windows.Forms.TrackBar blueTrackBar;
        private System.Windows.Forms.TextBox redTextBox;
        private System.Windows.Forms.TrackBar redTrackBar;
    }
}

