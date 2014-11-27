namespace CSSTest
{
    partial class DiffResultScreen
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
            this.DiffResult_richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // DiffResult_richTextBox1
            // 
            this.DiffResult_richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DiffResult_richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.DiffResult_richTextBox1.Name = "DiffResult_richTextBox1";
            this.DiffResult_richTextBox1.Size = new System.Drawing.Size(371, 303);
            this.DiffResult_richTextBox1.TabIndex = 0;
            this.DiffResult_richTextBox1.Text = "";
            // 
            // DiffResultScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 327);
            this.Controls.Add(this.DiffResult_richTextBox1);
            this.Name = "DiffResultScreen";
            this.Text = "DiffResultScreen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox DiffResult_richTextBox1;
    }
}