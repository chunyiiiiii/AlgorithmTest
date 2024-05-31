namespace ChessboardCovering
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.NumericUpDown numericUpDownSize;
        private System.Windows.Forms.Button buttonRandomSpecial;
        private System.Windows.Forms.TextBox textBoxSpecialX;
        private System.Windows.Forms.TextBox textBoxSpecialY;
        private System.Windows.Forms.Button buttonSetSpecial;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel panelBoard;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.buttonStart = new System.Windows.Forms.Button();
            this.numericUpDownSize = new System.Windows.Forms.NumericUpDown();
            this.buttonRandomSpecial = new System.Windows.Forms.Button();
            this.textBoxSpecialX = new System.Windows.Forms.TextBox();
            this.textBoxSpecialY = new System.Windows.Forms.TextBox();
            this.buttonSetSpecial = new System.Windows.Forms.Button();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.panelBoard = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).BeginInit();
            this.SuspendLayout();

            // splitContainer
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // splitContainer.Panel1
            this.splitContainer.Panel1.Controls.Add(this.buttonStart);
            this.splitContainer.Panel1.Controls.Add(this.numericUpDownSize);
            this.splitContainer.Panel1.Controls.Add(this.buttonRandomSpecial);
            this.splitContainer.Panel1.Controls.Add(this.textBoxSpecialX);
            this.splitContainer.Panel1.Controls.Add(this.textBoxSpecialY);
            this.splitContainer.Panel1.Controls.Add(this.buttonSetSpecial);
            this.splitContainer.Panel1.Controls.Add(this.labelX);
            this.splitContainer.Panel1.Controls.Add(this.labelY);
            // splitContainer.Panel2
            this.splitContainer.Panel2.Controls.Add(this.panelBoard);
            this.splitContainer.Size = new System.Drawing.Size(800, 800);
            this.splitContainer.SplitterDistance = 100;
            this.splitContainer.TabIndex = 0;

            // buttonStart
            this.buttonStart.Location = new System.Drawing.Point(12, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);

            // numericUpDownSize
            this.numericUpDownSize.Location = new System.Drawing.Point(93, 15);
            this.numericUpDownSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSize.Name = "numericUpDownSize";
            this.numericUpDownSize.Size = new System.Drawing.Size(45, 20);
            this.numericUpDownSize.TabIndex = 1;
            this.numericUpDownSize.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownSize.ValueChanged += new System.EventHandler(this.numericUpDownSize_ValueChanged);

            // buttonRandomSpecial
            this.buttonRandomSpecial.Location = new System.Drawing.Point(144, 12);
            this.buttonRandomSpecial.Name = "buttonRandomSpecial";
            this.buttonRandomSpecial.Size = new System.Drawing.Size(128, 23);
            this.buttonRandomSpecial.TabIndex = 2;
            this.buttonRandomSpecial.Text = "Random Special Point";
            this.buttonRandomSpecial.UseVisualStyleBackColor = true;
            this.buttonRandomSpecial.Click += new System.EventHandler(this.buttonRandomSpecial_Click);

            // textBoxSpecialX
            this.textBoxSpecialX.Location = new System.Drawing.Point(278, 14);
            this.textBoxSpecialX.Name = "textBoxSpecialX";
            this.textBoxSpecialX.Size = new System.Drawing.Size(30, 20);
            this.textBoxSpecialX.TabIndex = 3;

            // textBoxSpecialY
            this.textBoxSpecialY.Location = new System.Drawing.Point(334, 14);
            this.textBoxSpecialY.Name = "textBoxSpecialY";
            this.textBoxSpecialY.Size = new System.Drawing.Size(30, 20);
            this.textBoxSpecialY.TabIndex = 4;

            // buttonSetSpecial
            this.buttonSetSpecial.Location = new System.Drawing.Point(370, 12);
            this.buttonSetSpecial.Name = "buttonSetSpecial";
            this.buttonSetSpecial.Size = new System.Drawing.Size(75, 23);
            this.buttonSetSpecial.TabIndex = 5;
            this.buttonSetSpecial.Text = "Set Special";
            this.buttonSetSpecial.UseVisualStyleBackColor = true;
            this.buttonSetSpecial.Click += new System.EventHandler(this.buttonSetSpecial_Click);

            // labelX
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(266, 17);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(14, 13);
            this.labelX.TabIndex = 6;
            this.labelX.Text = "X";

            // labelY
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(318, 17);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(14, 13);
            this.labelY.TabIndex = 7;
            this.labelY.Text = "Y";

            // panelBoard
            this.panelBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBoard.Location = new System.Drawing.Point(0, 0);
            this.panelBoard.Name = "panelBoard";
            this.panelBoard.Size = new System.Drawing.Size(800, 696);
            this.panelBoard.TabIndex = 0;
            this.panelBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBoard_Paint);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Controls.Add(this.splitContainer);
            this.Name = "MainForm";
            this.Text = "Chessboard Covering";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).EndInit();
            this.ResumeLayout(false);
        }
    }
}