using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSSParser;

namespace CSSTest
{
    public partial class CompareTextsScreen : Form
    {
        private ResultScreen rs;
        private CSSDocument css1;
        private CSSDocument css2;
        private Parser parser;
        public CompareTextsScreen()
        {
            InitializeComponent();
            css1 = new CSSDocument();
            css2 = new CSSDocument();
            parser = new Parser();
        }

        private void compareCSSTexts_Click(object sender, EventArgs e)
        {
            css1 = parser.ParseText(CompareCSSTextstextBox1.Text);
            css2 = parser.ParseText(CompareCSSTextstextBox2.Text);
            rs = new ResultScreen(css1, css2);
            rs.Show();
        }

        private void CompareCSSTextstextBox1_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(CompareCSSTextstextBox2.Text.Trim()))
            {
                compareCSSTexts.Enabled = true;
                
            }

        }

        private void CompareCSSTextstextBox2_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(CompareCSSTextstextBox1.Text.Trim()))
            {
                compareCSSTexts.Enabled = true;
                
            }
        }

    }
}
