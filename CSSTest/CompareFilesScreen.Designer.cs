namespace CSSTest
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
            this.compareCSSFiles.Location = new System.Drawing.Point(116, 120);
            this.compareCSSFiles.Name = "compareCSSFiles";
            this.compareCSSFiles.Size = new System.Drawing.Size(103, 23);
            this.compareCSSFiles.TabIndex = 4;
            this.compareCSSFiles.Text = "Compare";
            this.compareCSSFiles.UseVisualStyleBackColor = true;
            this.compareCSSFiles.Click += new System.EventHandler(this.compareCSSFiles_Click);
            // 
            // CompareFilesScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 318);
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
    }
}