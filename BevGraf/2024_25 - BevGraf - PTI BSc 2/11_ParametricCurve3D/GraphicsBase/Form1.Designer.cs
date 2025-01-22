namespace GraphicsBase
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            canvas = new PictureBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label2 = new Label();
            sbParallelVZ = new HScrollBar();
            lblParallelVZ = new Label();
            sbParallelVY = new HScrollBar();
            lblParallelVY = new Label();
            sbParallelVX = new HScrollBar();
            lblParallelVX = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            timer = new System.Windows.Forms.Timer(components);
            sbCentral = new HScrollBar();
            lblCentral = new Label();
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // canvas
            // 
            canvas.BackColor = Color.White;
            canvas.Location = new Point(26, 30);
            canvas.Margin = new Padding(6, 7, 6, 7);
            canvas.Name = "canvas";
            canvas.Size = new Size(1804, 1263);
            canvas.TabIndex = 0;
            canvas.TabStop = false;
            canvas.Paint += canvas_Paint;
            canvas.MouseDown += canvas_MouseDown;
            canvas.MouseMove += canvas_MouseMove;
            canvas.MouseUp += canvas_MouseUp;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(1839, 30);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(819, 1263);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(sbCentral);
            tabPage1.Controls.Add(lblCentral);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(sbParallelVZ);
            tabPage1.Controls.Add(lblParallelVZ);
            tabPage1.Controls.Add(sbParallelVY);
            tabPage1.Controls.Add(lblParallelVY);
            tabPage1.Controls.Add(sbParallelVX);
            tabPage1.Controls.Add(lblParallelVX);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(10, 55);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(799, 1198);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Projection";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 284);
            label2.Name = "label2";
            label2.Size = new Size(102, 37);
            label2.TabIndex = 41;
            label2.Text = "Central";
            // 
            // sbParallelVZ
            // 
            sbParallelVZ.Location = new Point(165, 214);
            sbParallelVZ.Minimum = -100;
            sbParallelVZ.Name = "sbParallelVZ";
            sbParallelVZ.Size = new Size(598, 37);
            sbParallelVZ.TabIndex = 6;
            sbParallelVZ.Value = -57;
            sbParallelVZ.ValueChanged += sbParallelVX_ValueChanged;
            // 
            // lblParallelVZ
            // 
            lblParallelVZ.AutoSize = true;
            lblParallelVZ.Location = new Point(31, 214);
            lblParallelVZ.Name = "lblParallelVZ";
            lblParallelVZ.Size = new Size(142, 37);
            lblParallelVZ.TabIndex = 5;
            lblParallelVZ.Text = "v.z = -0.57";
            // 
            // sbParallelVY
            // 
            sbParallelVY.Location = new Point(165, 148);
            sbParallelVY.Minimum = -100;
            sbParallelVY.Name = "sbParallelVY";
            sbParallelVY.Size = new Size(598, 37);
            sbParallelVY.TabIndex = 40;
            sbParallelVY.Value = 40;
            sbParallelVY.ValueChanged += sbParallelVX_ValueChanged;
            // 
            // lblParallelVY
            // 
            lblParallelVY.AutoSize = true;
            lblParallelVY.Location = new Point(31, 148);
            lblParallelVY.Name = "lblParallelVY";
            lblParallelVY.Size = new Size(132, 37);
            lblParallelVY.TabIndex = 3;
            lblParallelVY.Text = "v.y = 0.40";
            // 
            // sbParallelVX
            // 
            sbParallelVX.Location = new Point(165, 78);
            sbParallelVX.Minimum = -100;
            sbParallelVX.Name = "sbParallelVX";
            sbParallelVX.Size = new Size(598, 37);
            sbParallelVX.TabIndex = 2;
            sbParallelVX.Value = 40;
            sbParallelVX.ValueChanged += sbParallelVX_ValueChanged;
            // 
            // lblParallelVX
            // 
            lblParallelVX.AutoSize = true;
            lblParallelVX.Location = new Point(31, 78);
            lblParallelVX.Name = "lblParallelVX";
            lblParallelVX.Size = new Size(131, 37);
            lblParallelVX.TabIndex = 1;
            lblParallelVX.Text = "v.x = 0.40";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 24);
            label1.Name = "label1";
            label1.Size = new Size(103, 37);
            label1.TabIndex = 0;
            label1.Text = "Parallel";
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(10, 55);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(799, 1198);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Transformation";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 10;
            timer.Tick += timer_Tick;
            // 
            // sbCentral
            // 
            sbCentral.Location = new Point(165, 346);
            sbCentral.Maximum = 1000;
            sbCentral.Minimum = 100;
            sbCentral.Name = "sbCentral";
            sbCentral.Size = new Size(598, 37);
            sbCentral.TabIndex = 43;
            sbCentral.Value = 500;
            sbCentral.ValueChanged += sbCentral_ValueChanged;
            // 
            // lblCentral
            // 
            lblCentral.AutoSize = true;
            lblCentral.Location = new Point(31, 346);
            lblCentral.Name = "lblCentral";
            lblCentral.Size = new Size(105, 37);
            lblCentral.TabIndex = 42;
            lblCentral.Text = "s = 500";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2670, 1318);
            Controls.Add(tabControl1);
            Controls.Add(canvas);
            Margin = new Padding(6, 7, 6, 7);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)canvas).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox canvas;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
        private HScrollBar sbParallelVX;
        private Label lblParallelVX;
        private HScrollBar sbParallelVZ;
        private Label lblParallelVZ;
        private HScrollBar sbParallelVY;
        private Label lblParallelVY;
        private System.Windows.Forms.Timer timer;
        private Label label2;
        private HScrollBar sbCentral;
        private Label lblCentral;
    }
}
