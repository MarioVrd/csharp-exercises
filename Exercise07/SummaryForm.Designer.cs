namespace Labs
{
    partial class SummaryForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fromSplitLabel = new System.Windows.Forms.Label();
            this.fromZagrebLabel = new System.Windows.Forms.Label();
            this.fromRijekaLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Persons from Split: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Persons from Zagreb: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Persons from Rijeka: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fromSplitLabel
            // 
            this.fromSplitLabel.AutoSize = true;
            this.fromSplitLabel.Location = new System.Drawing.Point(162, 29);
            this.fromSplitLabel.Name = "fromSplitLabel";
            this.fromSplitLabel.Size = new System.Drawing.Size(13, 13);
            this.fromSplitLabel.TabIndex = 3;
            this.fromSplitLabel.Text = "0";
            this.fromSplitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fromZagrebLabel
            // 
            this.fromZagrebLabel.AutoSize = true;
            this.fromZagrebLabel.Location = new System.Drawing.Point(162, 62);
            this.fromZagrebLabel.Name = "fromZagrebLabel";
            this.fromZagrebLabel.Size = new System.Drawing.Size(13, 13);
            this.fromZagrebLabel.TabIndex = 4;
            this.fromZagrebLabel.Text = "0";
            this.fromZagrebLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fromRijekaLabel
            // 
            this.fromRijekaLabel.AutoSize = true;
            this.fromRijekaLabel.Location = new System.Drawing.Point(162, 94);
            this.fromRijekaLabel.Name = "fromRijekaLabel";
            this.fromRijekaLabel.Size = new System.Drawing.Size(13, 13);
            this.fromRijekaLabel.TabIndex = 5;
            this.fromRijekaLabel.Text = "0";
            this.fromRijekaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 180);
            this.Controls.Add(this.fromRijekaLabel);
            this.Controls.Add(this.fromZagrebLabel);
            this.Controls.Add(this.fromSplitLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SummaryForm";
            this.Text = "SummaryForm";
            this.Load += new System.EventHandler(this.SummaryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label fromSplitLabel;
        private System.Windows.Forms.Label fromZagrebLabel;
        private System.Windows.Forms.Label fromRijekaLabel;
    }
}