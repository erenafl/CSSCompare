namespace CSSTest
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
            this.errorText = new System.Windows.Forms.RichTextBox();
            this.parsedCSSTreeView = new System.Windows.Forms.TreeView();
            this.Search_panel = new System.Windows.Forms.Panel();
            this.SearchQuery_textBox = new System.Windows.Forms.TextBox();
            this.Cancel_button = new System.Windows.Forms.Button();
            this.NextResult_button = new System.Windows.Forms.Button();
            this.Search_button = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.Search_panel.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(406, 24);
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
            this.cSSFilesToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.cSSFilesToolStripMenuItem.Text = "CSS Files";
            this.cSSFilesToolStripMenuItem.Click += new System.EventHandler(this.cSSFilesToolStripMenuItem_Click);
            // 
            // cSSTextsToolStripMenuItem
            // 
            this.cSSTextsToolStripMenuItem.Name = "cSSTextsToolStripMenuItem";
            this.cSSTextsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
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
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // errorText
            // 
            this.errorText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.errorText.Enabled = false;
            this.errorText.Location = new System.Drawing.Point(0, 298);
            this.errorText.Name = "errorText";
            this.errorText.Size = new System.Drawing.Size(406, 72);
            this.errorText.TabIndex = 2;
            this.errorText.Text = "";
            // 
            // parsedCSSTreeView
            // 
            this.parsedCSSTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parsedCSSTreeView.Location = new System.Drawing.Point(0, 24);
            this.parsedCSSTreeView.Name = "parsedCSSTreeView";
            this.parsedCSSTreeView.Size = new System.Drawing.Size(406, 274);
            this.parsedCSSTreeView.TabIndex = 3;
            // 
            // Search_panel
            // 
            this.Search_panel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Search_panel.Controls.Add(this.Cancel_button);
            this.Search_panel.Controls.Add(this.NextResult_button);
            this.Search_panel.Controls.Add(this.Search_button);
            this.Search_panel.Controls.Add(this.SearchQuery_textBox);
            this.Search_panel.Location = new System.Drawing.Point(216, 24);
            this.Search_panel.Name = "Search_panel";
            this.Search_panel.Size = new System.Drawing.Size(173, 34);
            this.Search_panel.TabIndex = 4;
            this.Search_panel.Visible = false;
            // 
            // SearchQuery_textBox
            // 
            this.SearchQuery_textBox.Location = new System.Drawing.Point(3, 11);
            this.SearchQuery_textBox.Name = "SearchQuery_textBox";
            this.SearchQuery_textBox.Size = new System.Drawing.Size(78, 20);
            this.SearchQuery_textBox.TabIndex = 0;
            this.SearchQuery_textBox.TextChanged += new System.EventHandler(this.SearchQuery_textBox_TextChanged);
            // 
            // Cancel_button
            // 
            this.Cancel_button.Enabled = false;
            this.Cancel_button.Image = global::CSSTest.Properties.Resources.cancel2_s;
            this.Cancel_button.Location = new System.Drawing.Point(148, 6);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(25, 25);
            this.Cancel_button.TabIndex = 3;
            this.Cancel_button.UseVisualStyleBackColor = true;
            this.Cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // NextResult_button
            // 
            this.NextResult_button.Enabled = false;
            this.NextResult_button.Image = global::CSSTest.Properties.Resources.next_s;
            this.NextResult_button.Location = new System.Drawing.Point(117, 6);
            this.NextResult_button.Name = "NextResult_button";
            this.NextResult_button.Size = new System.Drawing.Size(25, 25);
            this.NextResult_button.TabIndex = 2;
            this.NextResult_button.UseVisualStyleBackColor = true;
            this.NextResult_button.Click += new System.EventHandler(this.NextResult_button_Click);
            // 
            // Search_button
            // 
            this.Search_button.Enabled = false;
            this.Search_button.Image = global::CSSTest.Properties.Resources.search_s;
            this.Search_button.Location = new System.Drawing.Point(87, 6);
            this.Search_button.Name = "Search_button";
            this.Search_button.Size = new System.Drawing.Size(25, 25);
            this.Search_button.TabIndex = 1;
            this.Search_button.UseVisualStyleBackColor = true;
            this.Search_button.Click += new System.EventHandler(this.Search_button_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(406, 370);
            this.Controls.Add(this.Search_panel);
            this.Controls.Add(this.parsedCSSTreeView);
            this.Controls.Add(this.errorText);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainScreen";
            this.Text = "CSS Parser";
            this.SizeChanged += new System.EventHandler(this.MainScreen_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Search_panel.ResumeLayout(false);
            this.Search_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem parseCSSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parseFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parseTextToolStripMenuItem;
        private System.Windows.Forms.RichTextBox errorText;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem compareToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cSSFilesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cSSTextsToolStripMenuItem;
        private System.Windows.Forms.TreeView parsedCSSTreeView;
        private System.Windows.Forms.Panel Search_panel;
        private System.Windows.Forms.Button Cancel_button;
        private System.Windows.Forms.Button NextResult_button;
        private System.Windows.Forms.Button Search_button;
        private System.Windows.Forms.TextBox SearchQuery_textBox;

    }
}

