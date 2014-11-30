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
        private diff_match_patch diffOperator;
        private DiffResultScreen drs;
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
            diffOperator = new diff_match_patch();
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
            if ((!String.IsNullOrEmpty(CompareCSSTextstextBox2.Text.Trim())) && (!String.IsNullOrEmpty(CompareCSSTextstextBox1.Text.Trim())))
            {
                compareCSSTexts.Enabled = true;
                diffCSSFiles.Enabled = true;
            }
            else
            {
                compareCSSTexts.Enabled = false;
                diffCSSFiles.Enabled = false;
            }

        }

        private void CompareCSSTextstextBox2_TextChanged(object sender, EventArgs e)
        {
            if ((!String.IsNullOrEmpty(CompareCSSTextstextBox2.Text.Trim())) && (!String.IsNullOrEmpty(CompareCSSTextstextBox1.Text.Trim())))
            {
                compareCSSTexts.Enabled = true;
                diffCSSFiles.Enabled = true;
            }
            else
            {
                compareCSSTexts.Enabled = false;
                diffCSSFiles.Enabled = false;
            }
        }

        private void CompareTextsScreen_SizeChanged(object sender, EventArgs e)
        {
            CompareCSSTextstextBox1.Width = this.Width / 2 - 6;
            CompareCSSTextstextBox2.Left = CompareCSSTextstextBox1.Width + 2;
            CompareCSSTextstextBox2.Width = this.Width / 2 - 10;

            CompareCSSTextLabel_1.Left= this.Width / 4 - 6;
            CompareCSSTextLabel_2.Left = this.Width / 2 + this.Width / 4 - 6;

            compareCSSTexts.Left = this.Width / 4 - 6;
            diffCSSFiles.Left = this.Width / 2 + this.Width / 4 - 6;
        }

        private void diffCSSFiles_Click(object sender, EventArgs e)
        {
            drs = new DiffResultScreen(CompareCSSTextstextBox1.Text, CompareCSSTextstextBox2.Text);
            drs.Show();
        }
    }
}
