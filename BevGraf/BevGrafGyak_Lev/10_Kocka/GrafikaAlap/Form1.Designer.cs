namespace GrafikaAlap
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.canvas = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbAxonometry = new System.Windows.Forms.CheckBox();
            this.sbParallelZ = new System.Windows.Forms.HScrollBar();
            this.sbParallelY = new System.Windows.Forms.HScrollBar();
            this.sbParallelX = new System.Windows.Forms.HScrollBar();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.sbRotateX = new System.Windows.Forms.HScrollBar();
            this.sbScale = new System.Windows.Forms.HScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.Location = new System.Drawing.Point(6, 7);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(622, 477);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(635, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(243, 477);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbAxonometry);
            this.tabPage1.Controls.Add(this.sbParallelZ);
            this.tabPage1.Controls.Add(this.sbParallelY);
            this.tabPage1.Controls.Add(this.sbParallelX);
            this.tabPage1.Controls.Add(this.radioButton2);
            this.tabPage1.Controls.Add(this.radioButton1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(235, 451);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Projection";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbAxonometry
            // 
            this.cbAxonometry.AutoSize = true;
            this.cbAxonometry.Location = new System.Drawing.Point(8, 204);
            this.cbAxonometry.Name = "cbAxonometry";
            this.cbAxonometry.Size = new System.Drawing.Size(102, 17);
            this.cbAxonometry.TabIndex = 5;
            this.cbAxonometry.Text = "Use axonometry";
            this.cbAxonometry.UseVisualStyleBackColor = true;
            // 
            // sbParallelZ
            // 
            this.sbParallelZ.Location = new System.Drawing.Point(8, 125);
            this.sbParallelZ.Minimum = -100;
            this.sbParallelZ.Name = "sbParallelZ";
            this.sbParallelZ.Size = new System.Drawing.Size(212, 28);
            this.sbParallelZ.TabIndex = 4;
            this.sbParallelZ.Value = -84;
            this.sbParallelZ.ValueChanged += new System.EventHandler(this.sbParallel_ValueChanged);
            // 
            // sbParallelY
            // 
            this.sbParallelY.Location = new System.Drawing.Point(8, 82);
            this.sbParallelY.Minimum = -100;
            this.sbParallelY.Name = "sbParallelY";
            this.sbParallelY.Size = new System.Drawing.Size(212, 28);
            this.sbParallelY.TabIndex = 3;
            this.sbParallelY.Value = 70;
            this.sbParallelY.ValueChanged += new System.EventHandler(this.sbParallel_ValueChanged);
            // 
            // sbParallelX
            // 
            this.sbParallelX.Location = new System.Drawing.Point(8, 41);
            this.sbParallelX.Minimum = -100;
            this.sbParallelX.Name = "sbParallelX";
            this.sbParallelX.Size = new System.Drawing.Size(212, 28);
            this.sbParallelX.TabIndex = 2;
            this.sbParallelX.Value = 80;
            this.sbParallelX.ValueChanged += new System.EventHandler(this.sbParallel_ValueChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(8, 168);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(58, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Central";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 17);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(59, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Parallel";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.sbRotateX);
            this.tabPage2.Controls.Add(this.sbScale);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(235, 451);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Transformation";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Rotate X";
            // 
            // sbRotateX
            // 
            this.sbRotateX.Location = new System.Drawing.Point(10, 106);
            this.sbRotateX.Maximum = 628;
            this.sbRotateX.Name = "sbRotateX";
            this.sbRotateX.Size = new System.Drawing.Size(213, 28);
            this.sbRotateX.TabIndex = 2;
            this.sbRotateX.ValueChanged += new System.EventHandler(this.sbTransformations_ValueChanged);
            // 
            // sbScale
            // 
            this.sbScale.Location = new System.Drawing.Point(10, 33);
            this.sbScale.Maximum = 1000;
            this.sbScale.Minimum = 1;
            this.sbScale.Name = "sbScale";
            this.sbScale.Size = new System.Drawing.Size(213, 28);
            this.sbScale.TabIndex = 1;
            this.sbScale.Value = 500;
            this.sbScale.ValueChanged += new System.EventHandler(this.sbTransformations_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scale";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 501);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.canvas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.HScrollBar sbParallelZ;
        private System.Windows.Forms.HScrollBar sbParallelY;
        private System.Windows.Forms.HScrollBar sbParallelX;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox cbAxonometry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.HScrollBar sbRotateX;
        private System.Windows.Forms.HScrollBar sbScale;
        private System.Windows.Forms.Label label1;
    }
}

