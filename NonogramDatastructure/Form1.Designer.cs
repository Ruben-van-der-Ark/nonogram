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
            this.numGridSize = new System.Windows.Forms.NumericUpDown();
            this.lblRows = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numGridSize)).BeginInit();
            this.SuspendLayout();
            // 
            // numRows
            // 
            this.numGridSize.Location = new System.Drawing.Point(244, 111);
            this.numGridSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numGridSize.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numGridSize.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numGridSize.Name = "numRows";
            this.numGridSize.Size = new System.Drawing.Size(120, 26);
            this.numGridSize.TabIndex = 0;
            this.numGridSize.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Location = new System.Drawing.Point(148, 113);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(90, 20);
            this.lblRows.TabIndex = 2;
            this.lblRows.Text = "Gridgrootte";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(152, 142);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(213, 35);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Genereer grid";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(1060, 586);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(213, 35);
            this.btnCheck.TabIndex = 5;
            this.btnCheck.Text = "Check antwoord";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Visible = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1060, 102);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(213, 35);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Reset grid";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1802, 795);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblRows);
            this.Controls.Add(this.numGridSize);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.numGridSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numGridSize;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnClear;
    }
}

