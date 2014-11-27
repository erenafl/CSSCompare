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
    public partial class CompareFilesScreen : Form
    {
        private diff_match_patch diffOperator;
        private DiffResultScreen drs;
        private ResultScreen rs;
        private CSSDocument css1;
        private CSSDocument css2;
        private string filename1;
        private string filename2;
        private Parser parser;
        public CompareFilesScreen()
        {
            InitializeComponent();
            css1 = new CSSDocument();
            css2 = new CSSDocument();
            parser = new Parser();
            diffOperator = new diff_match_patch();
        }

        private void chooseCSSFiles_1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSS files|*.css";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!String.IsNullOrEmpty(ChooseCSSFilestextBox1.Text.Trim()))
                {
                    compareCSSFiles.Enabled = true;
                    diffCSSFiles.Enabled = true;
                }
                ChooseCSSFilestextBox1.Text = ofd.FileName;
                filename1 = ofd.FileName;
            }
        }

        private void chooseCSSFiles_2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSS files|*.css";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!String.IsNullOrEmpty(ChooseCSSFilestextBox1.Text.Trim()))
                {
                    compareCSSFiles.Enabled = true;
                    diffCSSFiles.Enabled = true;
                }
                ChooseCSSFilestextBox2.Text = ofd.FileName;
                filename2 = ofd.FileName;
            }
        }

        private void compareCSSFiles_Click(object sender, EventArgs e) 
        {
            var raw_text1 = parser.getTextfromFile(filename1);
            css1 = parser.ParseText(raw_text1);

            var raw_text2 = parser.getTextfromFile(filename2);
            css2 = parser.ParseText(raw_text2);

            rs = new ResultScreen(css1, css2);
            rs.Show();
        }

        private void diffCSSFiles_Click(object sender, EventArgs e)
        {
            drs = new DiffResultScreen(parser.getTextfromFile(filename1), parser.getTextfromFile(filename2));
            drs.Show();
        }
    }
}
