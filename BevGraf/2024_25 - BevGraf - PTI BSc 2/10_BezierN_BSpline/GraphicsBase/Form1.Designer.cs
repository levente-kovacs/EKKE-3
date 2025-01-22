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
            canvas = new PictureBox();
            sbLambda = new HScrollBar();
            cbIsClosed = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            SuspendLayout();
            // 
            // canvas
            // 
            canvas.BackColor = Color.White;
            canvas.Location = new Point(26, 30);
            canvas.Margin = new Padding(6, 7, 6, 7);
            canvas.Name = "canvas";
            canvas.Size = new Size(1804, 1034);
            canvas.TabIndex = 0;
            canvas.TabStop = false;
            canvas.Paint += canvas_Paint;
            canvas.MouseDown += canvas_MouseDown;
            canvas.MouseMove += canvas_MouseMove;
            canvas.MouseUp += canvas_MouseUp;
            // 
            // sbLambda
            // 
            sbLambda.Location = new Point(26, 1087);
            sbLambda.Maximum = 500;
            sbLambda.Minimum = 100;
            sbLambda.Name = "sbLambda";
            sbLambda.Size = new Size(1804, 86);
            sbLambda.TabIndex = 1;
            sbLambda.Value = 300;
            sbLambda.ValueChanged += sbLambda_ValueChanged;
            // 
            // cbIsClosed
            // 
            cbIsClosed.AutoSize = true;
            cbIsClosed.Location = new Point(26, 1203);
            cbIsClosed.Name = "cbIsClosed";
            cbIsClosed.Size = new Size(200, 41);
            cbIsClosed.TabIndex = 2;
            cbIsClosed.Text = "Closed curve";
            cbIsClosed.UseVisualStyleBackColor = true;
            cbIsClosed.CheckedChanged += cbIsClosed_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1856, 1299);
            Controls.Add(cbIsClosed);
            Controls.Add(sbLambda);
            Controls.Add(canvas);
            Margin = new Padding(6, 7, 6, 7);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)canvas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox canvas;
        private HScrollBar sbLambda;
        private CheckBox cbIsClosed;
    }
}
