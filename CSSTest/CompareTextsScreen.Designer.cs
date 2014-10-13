namespace CSSTest
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
            this.CompareCSSTextstextBox1 = new System.Windows.Forms.TextBox();
            this.CompareCSSTextstextBox2 = new System.Windows.Forms.TextBox();
            this.CompareCSSTextLabel_1 = new System.Windows.Forms.Label();
            this.CompareCSSTextLabel_2 = new System.Windows.Forms.Label();
            this.compareCSSTexts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CompareCSSTextstextBox1
            // 
            this.CompareCSSTextstextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CompareCSSTextstextBox1.Location = new System.Drawing.Point(2, 43);
            this.CompareCSSTextstextBox1.MaxLength = 9999999;
            this.CompareCSSTextstextBox1.Multiline = true;
            this.CompareCSSTextstextBox1.Name = "CompareCSSTextstextBox1";
            this.CompareCSSTextstextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.CompareCSSTextstextBox1.Size = new System.Drawing.Size(178, 285);
            this.CompareCSSTextstextBox1.TabIndex = 0;
            this.CompareCSSTextstextBox1.TextChanged += new System.EventHandler(this.CompareCSSTextstextBox1_TextChanged);
            // 
            // CompareCSSTextstextBox2
            // 
            this.CompareCSSTextstextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CompareCSSTextstextBox2.Location = new System.Drawing.Point(186, 43);
            this.CompareCSSTextstextBox2.MaxLength = 9999999;
            this.CompareCSSTextstextBox2.Multiline = true;
            this.CompareCSSTextstextBox2.Name = "CompareCSSTextstextBox2";
            this.CompareCSSTextstextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.CompareCSSTextstextBox2.Size = new System.Drawing.Size(179, 285);
            this.CompareCSSTextstextBox2.TabIndex = 1;
            this.CompareCSSTextstextBox2.TextChanged += new System.EventHandler(this.CompareCSSTextstextBox2_TextChanged);
            // 
            // CompareCSSTextLabel_1
            // 
            this.CompareCSSTextLabel_1.AutoSize = true;
            this.CompareCSSTextLabel_1.Location = new System.Drawing.Point(71, 13);
            this.CompareCSSTextLabel_1.Name = "CompareCSSTextLabel_1";
            this.CompareCSSTextLabel_1.Size = new System.Drawing.Size(61, 13);
            this.CompareCSSTextLabel_1.TabIndex = 2;
            this.CompareCSSTextLabel_1.Text = "CSS Text 1";
            // 
            // CompareCSSTextLabel_2
            // 
            this.CompareCSSTextLabel_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.compareCSSTexts.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.compareCSSTexts.Enabled = false;
            this.compareCSSTexts.Location = new System.Drawing.Point(127, 331);
            this.compareCSSTexts.Name = "compareCSSTexts";
            this.compareCSSTexts.Size = new System.Drawing.Size(103, 23);
            this.compareCSSTexts.TabIndex = 5;
            this.compareCSSTexts.Text = "Compare";
            this.compareCSSTexts.UseVisualStyleBackColor = true;
            this.compareCSSTexts.Click += new System.EventHandler(this.compareCSSTexts_Click);
            // 
            // CompareTextsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 366);
            this.Controls.Add(this.compareCSSTexts);
            this.Controls.Add(this.CompareCSSTextLabel_2);
            this.Controls.Add(this.CompareCSSTextLabel_1);
            this.Controls.Add(this.CompareCSSTextstextBox2);
            this.Controls.Add(this.CompareCSSTextstextBox1);
            this.Name = "CompareTextsScreen";
            this.Text = "CompareTexts";
            this.SizeChanged += new System.EventHandler(this.CompareTextsScreen_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CompareCSSTextstextBox1;
        private System.Windows.Forms.TextBox CompareCSSTextstextBox2;
        private System.Windows.Forms.Label CompareCSSTextLabel_1;
        private System.Windows.Forms.Label CompareCSSTextLabel_2;
        private System.Windows.Forms.Button compareCSSTexts;
    }
}