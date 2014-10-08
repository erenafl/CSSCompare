namespace CSSParserTest
{
    partial class CompareTextsScreen
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.CompareCSSTextLabel_1 = new System.Windows.Forms.Label();
            this.CompareCSSTextLabel_2 = new System.Windows.Forms.Label();
            this.compareCSSTexts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(2, 43);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(178, 285);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(186, 43);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(179, 285);
            this.textBox2.TabIndex = 1;
            // 
            // CompareCSSTextLabel_1
            // 
            this.CompareCSSTextLabel_1.AutoSize = true;
            this.CompareCSSTextLabel_1.Location = new System.Drawing.Point(71, 13);
            this.CompareCSSTextLabel_1.Name = "CompareCSSTextLabel_1";
            this.CompareCSSTextLabel_1.Size = new System.Drawing.Size(61, 13);
            this.CompareCSSTextLabel_1.TabIndex = 2;
            this.CompareCSSTextLabel_1.Text = "CSS Text 1";
            this.CompareCSSTextLabel_1.Click += new System.EventHandler(this.label1_Click);
            // 
            // CompareCSSTextLabel_2
            // 
            this.CompareCSSTextLabel_2.AutoSize = true;
            this.CompareCSSTextLabel_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CompareCSSTextLabel_2.Location = new System.Drawing.Point(257, 13);
            this.CompareCSSTextLabel_2.Name = "CompareCSSTextLabel_2";
            this.CompareCSSTextLabel_2.Size = new System.Drawing.Size(61, 13);
            this.CompareCSSTextLabel_2.TabIndex = 3;
            this.CompareCSSTextLabel_2.Text = "CSS Text 2";
            // 
            // compareCSSTexts
            // 
            this.compareCSSTexts.Enabled = false;
            this.compareCSSTexts.Location = new System.Drawing.Point(127, 331);
            this.compareCSSTexts.Name = "compareCSSTexts";
            this.compareCSSTexts.Size = new System.Drawing.Size(103, 23);
            this.compareCSSTexts.TabIndex = 5;
            this.compareCSSTexts.Text = "Compare";
            this.compareCSSTexts.UseVisualStyleBackColor = true;
            // 
            // CompareTextsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 366);
            this.Controls.Add(this.compareCSSTexts);
            this.Controls.Add(this.CompareCSSTextLabel_2);
            this.Controls.Add(this.CompareCSSTextLabel_1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "CompareTextsScreen";
            this.Text = "CompareTexts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label CompareCSSTextLabel_1;
        private System.Windows.Forms.Label CompareCSSTextLabel_2;
        private System.Windows.Forms.Button compareCSSTexts;
    }
}