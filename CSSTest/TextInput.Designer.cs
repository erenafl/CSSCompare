namespace CSSTest
{
    partial class TextInput
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
            this.parsetext_textbox = new System.Windows.Forms.TextBox();
            this.parsetext_button = new System.Windows.Forms.Button();
            this.cleartext_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // parsetext_textbox
            // 
            this.parsetext_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parsetext_textbox.Location = new System.Drawing.Point(12, 12);
            this.parsetext_textbox.MaxLength = 9999999;
            this.parsetext_textbox.Multiline = true;
            this.parsetext_textbox.Name = "parsetext_textbox";
            this.parsetext_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.parsetext_textbox.Size = new System.Drawing.Size(260, 216);
            this.parsetext_textbox.TabIndex = 0;
            // 
            // parsetext_button
            // 
            this.parsetext_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.parsetext_button.Location = new System.Drawing.Point(166, 234);
            this.parsetext_button.Name = "parsetext_button";
            this.parsetext_button.Size = new System.Drawing.Size(75, 23);
            this.parsetext_button.TabIndex = 1;
            this.parsetext_button.Text = "OK";
            this.parsetext_button.UseVisualStyleBackColor = true;
            this.parsetext_button.Click += new System.EventHandler(this.parsetext_button_Click);
            // 
            // cleartext_button
            // 
            this.cleartext_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cleartext_button.Location = new System.Drawing.Point(29, 234);
            this.cleartext_button.Name = "cleartext_button";
            this.cleartext_button.Size = new System.Drawing.Size(75, 23);
            this.cleartext_button.TabIndex = 2;
            this.cleartext_button.Text = "Clear";
            this.cleartext_button.UseVisualStyleBackColor = true;
            this.cleartext_button.Click += new System.EventHandler(this.cleartext_button_Click);
            // 
            // TextInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.cleartext_button);
            this.Controls.Add(this.parsetext_button);
            this.Controls.Add(this.parsetext_textbox);
            this.Name = "TextInput";
            this.Text = "TextInput";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox parsetext_textbox;
        private System.Windows.Forms.Button parsetext_button;
        private System.Windows.Forms.Button cleartext_button;
    }
}