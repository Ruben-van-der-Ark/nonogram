﻿namespace NonogramDatastructure
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
            this.lblRows = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).BeginInit();
            this.SuspendLayout();
            // 
            // numRows
            // 
            this.numRows.Location = new System.Drawing.Point(244, 111);
            this.numRows.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numRows.Minimum = new decimal(new int[] {
            5,
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
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Location = new System.Drawing.Point(167, 113);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(71, 20);
            this.lblRows.TabIndex = 2;
            this.lblRows.Text = "Grid size";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(171, 143);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(193, 35);
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
            this.Controls.Add(this.lblRows);
            this.Controls.Add(this.numRows);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numRows;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.Button btnGenerate;
    }
}

