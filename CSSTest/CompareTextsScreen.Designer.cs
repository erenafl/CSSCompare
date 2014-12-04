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
            this.diffCSSFiles = new System.Windows.Forms.Button();
            this.StylesheetAlgorithm_checkBox2 = new System.Windows.Forms.CheckBox();
            this.StylesheetAlgorithm_checkBox1 = new System.Windows.Forms.CheckBox();
            this.RulesetAlgorithm_checkBox2 = new System.Windows.Forms.CheckBox();
            this.RulesetAlgorithm_checkBox1 = new System.Windows.Forms.CheckBox();
            this.ChooseAlgorithm_label = new System.Windows.Forms.Label();
            this.CSSAnalyzing_label = new System.Windows.Forms.Label();
            this.RulesetAnalyzing_label = new System.Windows.Forms.Label();
            this.ComparisonAlgorithmPanel = new System.Windows.Forms.Panel();
            this.ComparisonAlgorithmPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CompareCSSTextstextBox1
            // 
            this.CompareCSSTextstextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CompareCSSTextstextBox1.Location = new System.Drawing.Point(2, 29);
            this.CompareCSSTextstextBox1.MaxLength = 9999999;
            this.CompareCSSTextstextBox1.Multiline = true;
            this.CompareCSSTextstextBox1.Name = "CompareCSSTextstextBox1";
            this.CompareCSSTextstextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.CompareCSSTextstextBox1.Size = new System.Drawing.Size(178, 224);
            this.CompareCSSTextstextBox1.TabIndex = 0;
            this.CompareCSSTextstextBox1.TextChanged += new System.EventHandler(this.CompareCSSTextstextBox1_TextChanged);
            // 
            // CompareCSSTextstextBox2
            // 
            this.CompareCSSTextstextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CompareCSSTextstextBox2.Location = new System.Drawing.Point(186, 29);
            this.CompareCSSTextstextBox2.MaxLength = 9999999;
            this.CompareCSSTextstextBox2.Multiline = true;
            this.CompareCSSTextstextBox2.Name = "CompareCSSTextstextBox2";
            this.CompareCSSTextstextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.CompareCSSTextstextBox2.Size = new System.Drawing.Size(179, 224);
            this.CompareCSSTextstextBox2.TabIndex = 1;
            this.CompareCSSTextstextBox2.TextChanged += new System.EventHandler(this.CompareCSSTextstextBox2_TextChanged);
            // 
            // CompareCSSTextLabel_1
            // 
            this.CompareCSSTextLabel_1.AutoSize = true;
            this.CompareCSSTextLabel_1.Location = new System.Drawing.Point(78, 9);
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
            this.CompareCSSTextLabel_2.Location = new System.Drawing.Point(257, 9);
            this.CompareCSSTextLabel_2.Name = "CompareCSSTextLabel_2";
            this.CompareCSSTextLabel_2.Size = new System.Drawing.Size(61, 13);
            this.CompareCSSTextLabel_2.TabIndex = 3;
            this.CompareCSSTextLabel_2.Text = "CSS Text 2";
            // 
            // compareCSSTexts
            // 
            this.compareCSSTexts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.compareCSSTexts.Enabled = false;
            this.compareCSSTexts.Location = new System.Drawing.Point(126, 423);
            this.compareCSSTexts.Name = "compareCSSTexts";
            this.compareCSSTexts.Size = new System.Drawing.Size(103, 23);
            this.compareCSSTexts.TabIndex = 5;
            this.compareCSSTexts.Text = "Compare";
            this.compareCSSTexts.UseVisualStyleBackColor = true;
            this.compareCSSTexts.Click += new System.EventHandler(this.compareCSSTexts_Click);
            // 
            // diffCSSFiles
            // 
            this.diffCSSFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.diffCSSFiles.Enabled = false;
            this.diffCSSFiles.Location = new System.Drawing.Point(126, 259);
            this.diffCSSFiles.Name = "diffCSSFiles";
            this.diffCSSFiles.Size = new System.Drawing.Size(103, 23);
            this.diffCSSFiles.TabIndex = 6;
            this.diffCSSFiles.Text = "Diff";
            this.diffCSSFiles.UseVisualStyleBackColor = true;
            this.diffCSSFiles.Click += new System.EventHandler(this.diffCSSFiles_Click);
            // 
            // StylesheetAlgorithm_checkBox2
            // 
            this.StylesheetAlgorithm_checkBox2.AutoSize = true;
            this.StylesheetAlgorithm_checkBox2.Location = new System.Drawing.Point(190, 105);
            this.StylesheetAlgorithm_checkBox2.Name = "StylesheetAlgorithm_checkBox2";
            this.StylesheetAlgorithm_checkBox2.Size = new System.Drawing.Size(103, 17);
            this.StylesheetAlgorithm_checkBox2.TabIndex = 19;
            this.StylesheetAlgorithm_checkBox2.Text = "#Common / #All";
            this.StylesheetAlgorithm_checkBox2.UseVisualStyleBackColor = true;
            // 
            // StylesheetAlgorithm_checkBox1
            // 
            this.StylesheetAlgorithm_checkBox1.AutoSize = true;
            this.StylesheetAlgorithm_checkBox1.Location = new System.Drawing.Point(190, 71);
            this.StylesheetAlgorithm_checkBox1.Name = "StylesheetAlgorithm_checkBox1";
            this.StylesheetAlgorithm_checkBox1.Size = new System.Drawing.Size(127, 17);
            this.StylesheetAlgorithm_checkBox1.TabIndex = 18;
            this.StylesheetAlgorithm_checkBox1.Text = "#Common / #Distinct";
            this.StylesheetAlgorithm_checkBox1.UseVisualStyleBackColor = true;
            // 
            // RulesetAlgorithm_checkBox2
            // 
            this.RulesetAlgorithm_checkBox2.AutoSize = true;
            this.RulesetAlgorithm_checkBox2.Location = new System.Drawing.Point(11, 105);
            this.RulesetAlgorithm_checkBox2.Name = "RulesetAlgorithm_checkBox2";
            this.RulesetAlgorithm_checkBox2.Size = new System.Drawing.Size(103, 17);
            this.RulesetAlgorithm_checkBox2.TabIndex = 17;
            this.RulesetAlgorithm_checkBox2.Text = "#Common / #All";
            this.RulesetAlgorithm_checkBox2.UseVisualStyleBackColor = true;
            // 
            // RulesetAlgorithm_checkBox1
            // 
            this.RulesetAlgorithm_checkBox1.AutoSize = true;
            this.RulesetAlgorithm_checkBox1.Location = new System.Drawing.Point(11, 71);
            this.RulesetAlgorithm_checkBox1.Name = "RulesetAlgorithm_checkBox1";
            this.RulesetAlgorithm_checkBox1.Size = new System.Drawing.Size(127, 17);
            this.RulesetAlgorithm_checkBox1.TabIndex = 16;
            this.RulesetAlgorithm_checkBox1.Text = "#Common / #Distinct";
            this.RulesetAlgorithm_checkBox1.UseVisualStyleBackColor = true;
            // 
            // ChooseAlgorithm_label
            // 
            this.ChooseAlgorithm_label.AutoSize = true;
            this.ChooseAlgorithm_label.Location = new System.Drawing.Point(79, 11);
            this.ChooseAlgorithm_label.Name = "ChooseAlgorithm_label";
            this.ChooseAlgorithm_label.Size = new System.Drawing.Size(165, 13);
            this.ChooseAlgorithm_label.TabIndex = 15;
            this.ChooseAlgorithm_label.Text = "Choose Algorithm For Comparison";
            // 
            // CSSAnalyzing_label
            // 
            this.CSSAnalyzing_label.AutoSize = true;
            this.CSSAnalyzing_label.Location = new System.Drawing.Point(216, 43);
            this.CSSAnalyzing_label.Name = "CSSAnalyzing_label";
            this.CSSAnalyzing_label.Size = new System.Drawing.Size(77, 13);
            this.CSSAnalyzing_label.TabIndex = 14;
            this.CSSAnalyzing_label.Text = "STYLESHEET";
            // 
            // RulesetAnalyzing_label
            // 
            this.RulesetAnalyzing_label.AutoSize = true;
            this.RulesetAnalyzing_label.Location = new System.Drawing.Point(27, 43);
            this.RulesetAnalyzing_label.Name = "RulesetAnalyzing_label";
            this.RulesetAnalyzing_label.Size = new System.Drawing.Size(64, 13);
            this.RulesetAnalyzing_label.TabIndex = 13;
            this.RulesetAnalyzing_label.Text = "RULESETS";
            // 
            // ComparisonAlgorithmPanel
            // 
            this.ComparisonAlgorithmPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ComparisonAlgorithmPanel.Controls.Add(this.ChooseAlgorithm_label);
            this.ComparisonAlgorithmPanel.Controls.Add(this.StylesheetAlgorithm_checkBox2);
            this.ComparisonAlgorithmPanel.Controls.Add(this.RulesetAnalyzing_label);
            this.ComparisonAlgorithmPanel.Controls.Add(this.StylesheetAlgorithm_checkBox1);
            this.ComparisonAlgorithmPanel.Controls.Add(this.CSSAnalyzing_label);
            this.ComparisonAlgorithmPanel.Controls.Add(this.RulesetAlgorithm_checkBox2);
            this.ComparisonAlgorithmPanel.Controls.Add(this.RulesetAlgorithm_checkBox1);
            this.ComparisonAlgorithmPanel.Location = new System.Drawing.Point(12, 286);
            this.ComparisonAlgorithmPanel.Name = "ComparisonAlgorithmPanel";
            this.ComparisonAlgorithmPanel.Size = new System.Drawing.Size(323, 131);
            this.ComparisonAlgorithmPanel.TabIndex = 20;
            // 
            // CompareTextsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 458);
            this.Controls.Add(this.ComparisonAlgorithmPanel);
            this.Controls.Add(this.diffCSSFiles);
            this.Controls.Add(this.compareCSSTexts);
            this.Controls.Add(this.CompareCSSTextLabel_2);
            this.Controls.Add(this.CompareCSSTextLabel_1);
            this.Controls.Add(this.CompareCSSTextstextBox2);
            this.Controls.Add(this.CompareCSSTextstextBox1);
            this.Name = "CompareTextsScreen";
            this.Text = "CompareTexts";
            this.SizeChanged += new System.EventHandler(this.CompareTextsScreen_SizeChanged);
            this.ComparisonAlgorithmPanel.ResumeLayout(false);
            this.ComparisonAlgorithmPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CompareCSSTextstextBox1;
        private System.Windows.Forms.TextBox CompareCSSTextstextBox2;
        private System.Windows.Forms.Label CompareCSSTextLabel_1;
        private System.Windows.Forms.Label CompareCSSTextLabel_2;
        private System.Windows.Forms.Button compareCSSTexts;
        private System.Windows.Forms.Button diffCSSFiles;
        private System.Windows.Forms.CheckBox StylesheetAlgorithm_checkBox2;
        private System.Windows.Forms.CheckBox StylesheetAlgorithm_checkBox1;
        private System.Windows.Forms.CheckBox RulesetAlgorithm_checkBox2;
        private System.Windows.Forms.CheckBox RulesetAlgorithm_checkBox1;
        private System.Windows.Forms.Label ChooseAlgorithm_label;
        private System.Windows.Forms.Label CSSAnalyzing_label;
        private System.Windows.Forms.Label RulesetAnalyzing_label;
        private System.Windows.Forms.Panel ComparisonAlgorithmPanel;
    }
}