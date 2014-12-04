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
        private int RulesetAnalyzingChoice;
        private int StylesheetAnalyzingChoice;
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

            if (RulesetAlgorithm_checkBox1.Checked || RulesetAlgorithm_checkBox2.Checked)
            {
                if (StylesheetAlgorithm_checkBox1.Checked || StylesheetAlgorithm_checkBox2.Checked)
                {
                    if (RulesetAlgorithm_checkBox1.Checked) RulesetAnalyzingChoice = 1;
                    else RulesetAnalyzingChoice = 2;
                    if (StylesheetAlgorithm_checkBox1.Checked) StylesheetAnalyzingChoice = 1;
                    else StylesheetAnalyzingChoice = 2;

                    css1 = parser.ParseText(CompareCSSTextstextBox1.Text);
                    css2 = parser.ParseText(CompareCSSTextstextBox2.Text);
                    rs = new ResultScreen(css1, css2, RulesetAnalyzingChoice, StylesheetAnalyzingChoice);
                    rs.Show();
                }
            }
            
            
            
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

            compareCSSTexts.Left = CompareCSSTextstextBox2.Left - compareCSSTexts.Width / 2;
            diffCSSFiles.Left = CompareCSSTextstextBox2.Left - diffCSSFiles.Width / 2;
            ComparisonAlgorithmPanel.Left = CompareCSSTextstextBox2.Left - ComparisonAlgorithmPanel.Width / 2;
        }

        private void diffCSSFiles_Click(object sender, EventArgs e)
        {
            drs = new DiffResultScreen(CompareCSSTextstextBox1.Text, CompareCSSTextstextBox2.Text);
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
