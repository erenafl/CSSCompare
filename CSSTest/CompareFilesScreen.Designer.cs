﻿namespace CSSTest
{
    partial class CompareFilesScreen
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
            this.chooseCSSFiles_1 = new System.Windows.Forms.Button();
            this.chooseCSSFiles_2 = new System.Windows.Forms.Button();
            this.ChooseCSSFilestextBox1 = new System.Windows.Forms.TextBox();
            this.ChooseCSSFilestextBox2 = new System.Windows.Forms.TextBox();
            this.compareCSSFiles = new System.Windows.Forms.Button();
            this.diffCSSFiles = new System.Windows.Forms.Button();
            this.RulesetAnalyzing_label = new System.Windows.Forms.Label();
            this.CSSAnalyzing_label = new System.Windows.Forms.Label();
            this.ChooseAlgorithm_label = new System.Windows.Forms.Label();
            this.RulesetAlgorithm_checkBox1 = new System.Windows.Forms.CheckBox();
            this.RulesetAlgorithm_checkBox2 = new System.Windows.Forms.CheckBox();
            this.StylesheetAlgorithm_checkBox2 = new System.Windows.Forms.CheckBox();
            this.StylesheetAlgorithm_checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chooseCSSFiles_1
            // 
            this.chooseCSSFiles_1.Location = new System.Drawing.Point(31, 12);
            this.chooseCSSFiles_1.Name = "chooseCSSFiles_1";
            this.chooseCSSFiles_1.Size = new System.Drawing.Size(75, 23);
            this.chooseCSSFiles_1.TabIndex = 0;
            this.chooseCSSFiles_1.Text = "File 1";
            this.chooseCSSFiles_1.UseVisualStyleBackColor = true;
            this.chooseCSSFiles_1.Click += new System.EventHandler(this.chooseCSSFiles_1_Click);
            // 
            // chooseCSSFiles_2
            // 
            this.chooseCSSFiles_2.Location = new System.Drawing.Point(31, 51);
            this.chooseCSSFiles_2.Name = "chooseCSSFiles_2";
            this.chooseCSSFiles_2.Size = new System.Drawing.Size(75, 23);
            this.chooseCSSFiles_2.TabIndex = 1;
            this.chooseCSSFiles_2.Text = "File 2";
            this.chooseCSSFiles_2.UseVisualStyleBackColor = true;
            this.chooseCSSFiles_2.Click += new System.EventHandler(this.chooseCSSFiles_2_Click);
            // 
            // ChooseCSSFilestextBox1
            // 
            this.ChooseCSSFilestextBox1.Location = new System.Drawing.Point(157, 12);
            this.ChooseCSSFilestextBox1.Name = "ChooseCSSFilestextBox1";
            this.ChooseCSSFilestextBox1.ReadOnly = true;
            this.ChooseCSSFilestextBox1.Size = new System.Drawing.Size(100, 20);
            this.ChooseCSSFilestextBox1.TabIndex = 2;
            // 
            // ChooseCSSFilestextBox2
            // 
            this.ChooseCSSFilestextBox2.Location = new System.Drawing.Point(157, 54);
            this.ChooseCSSFilestextBox2.Name = "ChooseCSSFilestextBox2";
            this.ChooseCSSFilestextBox2.ReadOnly = true;
            this.ChooseCSSFilestextBox2.Size = new System.Drawing.Size(100, 20);
            this.ChooseCSSFilestextBox2.TabIndex = 3;
            // 
            // compareCSSFiles
            // 
            this.compareCSSFiles.Enabled = false;
            this.compareCSSFiles.Location = new System.Drawing.Point(116, 272);
            this.compareCSSFiles.Name = "compareCSSFiles";
            this.compareCSSFiles.Size = new System.Drawing.Size(103, 23);
            this.compareCSSFiles.TabIndex = 4;
            this.compareCSSFiles.Text = "Compare";
            this.compareCSSFiles.UseVisualStyleBackColor = true;
            this.compareCSSFiles.Click += new System.EventHandler(this.compareCSSFiles_Click);
            // 
            // diffCSSFiles
            // 
            this.diffCSSFiles.Enabled = false;
            this.diffCSSFiles.Location = new System.Drawing.Point(116, 112);
            this.diffCSSFiles.Name = "diffCSSFiles";
            this.diffCSSFiles.Size = new System.Drawing.Size(103, 23);
            this.diffCSSFiles.TabIndex = 5;
            this.diffCSSFiles.Text = "Diff";
            this.diffCSSFiles.UseVisualStyleBackColor = true;
            this.diffCSSFiles.Click += new System.EventHandler(this.diffCSSFiles_Click);
            // 
            // RulesetAnalyzing_label
            // 
            this.RulesetAnalyzing_label.AutoSize = true;
            this.RulesetAnalyzing_label.Location = new System.Drawing.Point(28, 185);
            this.RulesetAnalyzing_label.Name = "RulesetAnalyzing_label";
            this.RulesetAnalyzing_label.Size = new System.Drawing.Size(64, 13);
            this.RulesetAnalyzing_label.TabIndex = 6;
            this.RulesetAnalyzing_label.Text = "RULESETS";
            // 
            // CSSAnalyzing_label
            // 
            this.CSSAnalyzing_label.AutoSize = true;
            this.CSSAnalyzing_label.Location = new System.Drawing.Point(217, 185);
            this.CSSAnalyzing_label.Name = "CSSAnalyzing_label";
            this.CSSAnalyzing_label.Size = new System.Drawing.Size(77, 13);
            this.CSSAnalyzing_label.TabIndex = 7;
            this.CSSAnalyzing_label.Text = "STYLESHEET";
            // 
            // ChooseAlgorithm_label
            // 
            this.ChooseAlgorithm_label.AutoSize = true;
            this.ChooseAlgorithm_label.Location = new System.Drawing.Point(80, 153);
            this.ChooseAlgorithm_label.Name = "ChooseAlgorithm_label";
            this.ChooseAlgorithm_label.Size = new System.Drawing.Size(165, 13);
            this.ChooseAlgorithm_label.TabIndex = 8;
            this.ChooseAlgorithm_label.Text = "Choose Algorithm For Comparison";
            // 
            // RulesetAlgorithm_checkBox1
            // 
            this.RulesetAlgorithm_checkBox1.AutoSize = true;
            this.RulesetAlgorithm_checkBox1.Location = new System.Drawing.Point(12, 213);
            this.RulesetAlgorithm_checkBox1.Name = "RulesetAlgorithm_checkBox1";
            this.RulesetAlgorithm_checkBox1.Size = new System.Drawing.Size(127, 17);
            this.RulesetAlgorithm_checkBox1.TabIndex = 9;
            this.RulesetAlgorithm_checkBox1.Text = "#Common / #Distinct";
            this.RulesetAlgorithm_checkBox1.UseVisualStyleBackColor = true;
            this.RulesetAlgorithm_checkBox1.CheckedChanged += new System.EventHandler(this.RulesetAlgorithm_checkBox1_CheckedChanged);
            // 
            // RulesetAlgorithm_checkBox2
            // 
            this.RulesetAlgorithm_checkBox2.AutoSize = true;
            this.RulesetAlgorithm_checkBox2.Location = new System.Drawing.Point(12, 247);
            this.RulesetAlgorithm_checkBox2.Name = "RulesetAlgorithm_checkBox2";
            this.RulesetAlgorithm_checkBox2.Size = new System.Drawing.Size(103, 17);
            this.RulesetAlgorithm_checkBox2.TabIndex = 10;
            this.RulesetAlgorithm_checkBox2.Text = "#Common / #All";
            this.RulesetAlgorithm_checkBox2.UseVisualStyleBackColor = true;
            this.RulesetAlgorithm_checkBox2.CheckedChanged += new System.EventHandler(this.RulesetAlgorithm_checkBox2_CheckedChanged);
            // 
            // StylesheetAlgorithm_checkBox2
            // 
            this.StylesheetAlgorithm_checkBox2.AutoSize = true;
            this.StylesheetAlgorithm_checkBox2.Location = new System.Drawing.Point(191, 247);
            this.StylesheetAlgorithm_checkBox2.Name = "StylesheetAlgorithm_checkBox2";
            this.StylesheetAlgorithm_checkBox2.Size = new System.Drawing.Size(103, 17);
            this.StylesheetAlgorithm_checkBox2.TabIndex = 12;
            this.StylesheetAlgorithm_checkBox2.Text = "#Common / #All";
            this.StylesheetAlgorithm_checkBox2.UseVisualStyleBackColor = true;
            this.StylesheetAlgorithm_checkBox2.CheckedChanged += new System.EventHandler(this.StylesheetAlgorithm_checkBox2_CheckedChanged);
            // 
            // StylesheetAlgorithm_checkBox1
            // 
            this.StylesheetAlgorithm_checkBox1.AutoSize = true;
            this.StylesheetAlgorithm_checkBox1.Location = new System.Drawing.Point(191, 213);
            this.StylesheetAlgorithm_checkBox1.Name = "StylesheetAlgorithm_checkBox1";
            this.StylesheetAlgorithm_checkBox1.Size = new System.Drawing.Size(127, 17);
            this.StylesheetAlgorithm_checkBox1.TabIndex = 11;
            this.StylesheetAlgorithm_checkBox1.Text = "#Common / #Distinct";
            this.StylesheetAlgorithm_checkBox1.UseVisualStyleBackColor = true;
            this.StylesheetAlgorithm_checkBox1.CheckedChanged += new System.EventHandler(this.StylesheetAlgorithm_checkBox1_CheckedChanged);
            // 
            // CompareFilesScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 318);
            this.Controls.Add(this.StylesheetAlgorithm_checkBox2);
            this.Controls.Add(this.StylesheetAlgorithm_checkBox1);
            this.Controls.Add(this.RulesetAlgorithm_checkBox2);
            this.Controls.Add(this.RulesetAlgorithm_checkBox1);
            this.Controls.Add(this.ChooseAlgorithm_label);
            this.Controls.Add(this.CSSAnalyzing_label);
            this.Controls.Add(this.RulesetAnalyzing_label);
            this.Controls.Add(this.diffCSSFiles);
            this.Controls.Add(this.compareCSSFiles);
            this.Controls.Add(this.ChooseCSSFilestextBox2);
            this.Controls.Add(this.ChooseCSSFilestextBox1);
            this.Controls.Add(this.chooseCSSFiles_2);
            this.Controls.Add(this.chooseCSSFiles_1);
            this.Name = "CompareFilesScreen";
            this.Text = "CompareScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chooseCSSFiles_1;
        private System.Windows.Forms.Button chooseCSSFiles_2;
        private System.Windows.Forms.TextBox ChooseCSSFilestextBox1;
        private System.Windows.Forms.TextBox ChooseCSSFilestextBox2;
        private System.Windows.Forms.Button compareCSSFiles;
        private System.Windows.Forms.Button diffCSSFiles;
        private System.Windows.Forms.Label RulesetAnalyzing_label;
        private System.Windows.Forms.Label CSSAnalyzing_label;
        private System.Windows.Forms.Label ChooseAlgorithm_label;
        private System.Windows.Forms.CheckBox RulesetAlgorithm_checkBox1;
        private System.Windows.Forms.CheckBox RulesetAlgorithm_checkBox2;
        private System.Windows.Forms.CheckBox StylesheetAlgorithm_checkBox2;
        private System.Windows.Forms.CheckBox StylesheetAlgorithm_checkBox1;
    }
}