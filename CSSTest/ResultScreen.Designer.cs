namespace CSSTest
{
    partial class ResultScreen
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
            this.parsedCSStreeView1 = new System.Windows.Forms.TreeView();
            this.parsedCSStreeView2 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // parsedCSStreeView1
            // 
            this.parsedCSStreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.parsedCSStreeView1.Location = new System.Drawing.Point(12, 12);
            this.parsedCSStreeView1.Name = "parsedCSStreeView1";
            this.parsedCSStreeView1.Size = new System.Drawing.Size(162, 286);
            this.parsedCSStreeView1.TabIndex = 0;
            // 
            // parsedCSStreeView2
            // 
            this.parsedCSStreeView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parsedCSStreeView2.Location = new System.Drawing.Point(180, 12);
            this.parsedCSStreeView2.Name = "parsedCSStreeView2";
            this.parsedCSStreeView2.Size = new System.Drawing.Size(160, 286);
            this.parsedCSStreeView2.TabIndex = 1;
            // 
            // ResultScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 378);
            this.Controls.Add(this.parsedCSStreeView2);
            this.Controls.Add(this.parsedCSStreeView1);
            this.Name = "ResultScreen";
            this.Text = "ResultScreen";
            this.SizeChanged += new System.EventHandler(this.ResultScreen_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView parsedCSStreeView1;
        private System.Windows.Forms.TreeView parsedCSStreeView2;
    }
}