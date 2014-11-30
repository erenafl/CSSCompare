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
        private int RulesetAnalyzingChoice;
        private int StylesheetAnalyzingChoice;
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
            if (RulesetAlgorithm_checkBox1.Checked || RulesetAlgorithm_checkBox2.Checked)
            {
                if (StylesheetAlgorithm_checkBox1.Checked || StylesheetAlgorithm_checkBox2.Checked)
                {
                    var raw_text1 = parser.getTextfromFile(filename1);
                    css1 = parser.ParseText(raw_text1);

                    var raw_text2 = parser.getTextfromFile(filename2);
                    css2 = parser.ParseText(raw_text2);

                    if (RulesetAlgorithm_checkBox1.Checked) RulesetAnalyzingChoice = 1;
                    else RulesetAnalyzingChoice = 2;
                    if (StylesheetAlgorithm_checkBox1.Checked) StylesheetAnalyzingChoice = 1;
                    else StylesheetAnalyzingChoice = 2;

                    rs = new ResultScreen(css1, css2, RulesetAnalyzingChoice, StylesheetAnalyzingChoice);
                    rs.Show();
                }
            }
        }

        private void diffCSSFiles_Click(object sender, EventArgs e)
        {
            drs = new DiffResultScreen(parser.getTextfromFile(filename1), parser.getTextfromFile(filename2));
            drs.Show();
        }

        private void RulesetAlgorithm_checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            RulesetAlgorithm_checkBox2.Checked = !RulesetAlgorithm_checkBox1.Checked;
        }

        private void RulesetAlgorithm_checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            RulesetAlgorithm_checkBox1.Checked = !RulesetAlgorithm_checkBox2.Checked;
        }

        private void StylesheetAlgorithm_checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            StylesheetAlgorithm_checkBox2.Checked = !StylesheetAlgorithm_checkBox1.Checked;
        }

        private void StylesheetAlgorithm_checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            StylesheetAlgorithm_checkBox1.Checked = !StylesheetAlgorithm_checkBox2.Checked;
        }

    }
}
