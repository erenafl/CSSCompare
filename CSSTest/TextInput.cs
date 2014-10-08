using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSSTest
{
    public partial class TextInput : Form
    {
        public TextInput()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        public string RawText
        {
            get { return parsetext_textbox.Text; }
            set { parsetext_textbox.Text = value; }
        }

        private void parsetext_button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }
    }
}
