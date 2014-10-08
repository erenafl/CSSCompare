namespace CSSParser_Test
{
    partial class MainScreen
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.parseCSSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parseFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parseTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cSSFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cSSTextsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parsedText = new System.Windows.Forms.RichTextBox();
            this.errorText = new System.Windows.Forms.RichTextBox();
            this.parsedtextTreeView = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parseCSSToolStripMenuItem,
            this.compareToolStripMenuItem,
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(319, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // parseCSSToolStripMenuItem
            // 
            this.parseCSSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parseFromFileToolStripMenuItem,
            this.parseTextToolStripMenuItem});
            this.parseCSSToolStripMenuItem.Name = "parseCSSToolStripMenuItem";
            this.parseCSSToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.parseCSSToolStripMenuItem.Text = "Parse CSS";
            // 
            // parseFromFileToolStripMenuItem
            // 
            this.parseFromFileToolStripMenuItem.Name = "parseFromFileToolStripMenuItem";
            this.parseFromFileToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.parseFromFileToolStripMenuItem.Text = "Parse From File";
            this.parseFromFileToolStripMenuItem.Click += new System.EventHandler(this.parseFromFileToolStripMenuItem_Click);
            // 
            // parseTextToolStripMenuItem
            // 
            this.parseTextToolStripMenuItem.Name = "parseTextToolStripMenuItem";
            this.parseTextToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.parseTextToolStripMenuItem.Text = "Parse Text";
            this.parseTextToolStripMenuItem.Click += new System.EventHandler(this.parseTextToolStripMenuItem_Click);
            // 
            // compareToolStripMenuItem
            // 
            this.compareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cSSFilesToolStripMenuItem,
            this.cSSTextsToolStripMenuItem});
            this.compareToolStripMenuItem.Name = "compareToolStripMenuItem";
            this.compareToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.compareToolStripMenuItem.Text = "Compare";
            // 
            // cSSFilesToolStripMenuItem
            // 
            this.cSSFilesToolStripMenuItem.Name = "cSSFilesToolStripMenuItem";
            this.cSSFilesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cSSFilesToolStripMenuItem.Text = "CSS Files";
            this.cSSFilesToolStripMenuItem.Click += new System.EventHandler(this.cSSFilesToolStripMenuItem_Click);
            // 
            // cSSTextsToolStripMenuItem
            // 
            this.cSSTextsToolStripMenuItem.Name = "cSSTextsToolStripMenuItem";
            this.cSSTextsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cSSTextsToolStripMenuItem.Text = "CSS Texts";
            this.cSSTextsToolStripMenuItem.Click += new System.EventHandler(this.cSSTextsToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // parsedText
            // 
            this.parsedText.Location = new System.Drawing.Point(0, 24);
            this.parsedText.Name = "parsedText";
            this.parsedText.ReadOnly = true;
            this.parsedText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.parsedText.Size = new System.Drawing.Size(319, 294);
            this.parsedText.TabIndex = 1;
            this.parsedText.Text = "";
            // 
            // errorText
            // 
            this.errorText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.errorText.Location = new System.Drawing.Point(0, 246);
            this.errorText.Name = "errorText";
            this.errorText.Size = new System.Drawing.Size(319, 72);
            this.errorText.TabIndex = 2;
            this.errorText.Text = "";
            // 
            // parsedtextTreeView
            // 
            this.parsedtextTreeView.Location = new System.Drawing.Point(156, 24);
            this.parsedtextTreeView.Name = "parsedtextTreeView";
            this.parsedtextTreeView.Size = new System.Drawing.Size(163, 222);
            this.parsedtextTreeView.TabIndex = 3;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 318);
            this.Controls.Add(this.parsedtextTreeView);
            this.Controls.Add(this.errorText);
            this.Controls.Add(this.parsedText);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainScreen";
            this.Text = "CSS Parse & Compare";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem parseCSSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parseFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parseTextToolStripMenuItem;
        private System.Windows.Forms.RichTextBox parsedText;
        private System.Windows.Forms.RichTextBox errorText;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem compareToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cSSFilesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cSSTextsToolStripMenuItem;
        private System.Windows.Forms.TreeView parsedtextTreeView;

    }
}

