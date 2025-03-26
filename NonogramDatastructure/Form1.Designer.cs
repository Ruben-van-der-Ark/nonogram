namespace NonogramDatastructure
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
            this.numRows = new System.Windows.Forms.NumericUpDown();
            this.numCols = new System.Windows.Forms.NumericUpDown();
            this.lblRows = new System.Windows.Forms.Label();
            this.lblCols = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCols)).BeginInit();
            this.SuspendLayout();
            // 
            // numRows
            // 
            this.numRows.Location = new System.Drawing.Point(244, 111);
            this.numRows.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numRows.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numRows.Name = "numRows";
            this.numRows.Size = new System.Drawing.Size(120, 26);
            this.numRows.TabIndex = 0;
            this.numRows.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // numCols
            // 
            this.numCols.Location = new System.Drawing.Point(244, 143);
            this.numCols.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numCols.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numCols.Name = "numCols";
            this.numCols.Size = new System.Drawing.Size(120, 26);
            this.numCols.TabIndex = 1;
            this.numCols.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Location = new System.Drawing.Point(187, 113);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(49, 20);
            this.lblRows.TabIndex = 2;
            this.lblRows.Text = "Rows";
            // 
            // lblCols
            // 
            this.lblCols.AutoSize = true;
            this.lblCols.Location = new System.Drawing.Point(167, 145);
            this.lblCols.Name = "lblCols";
            this.lblCols.Size = new System.Drawing.Size(71, 20);
            this.lblCols.TabIndex = 3;
            this.lblCols.Text = "Columns";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(191, 175);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(145, 35);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate grid";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1802, 795);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblCols);
            this.Controls.Add(this.lblRows);
            this.Controls.Add(this.numCols);
            this.Controls.Add(this.numRows);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numRows;
        private System.Windows.Forms.NumericUpDown numCols;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.Label lblCols;
        private System.Windows.Forms.Button btnGenerate;
    }
}

