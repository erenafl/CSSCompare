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
        private ResultScreen rs;
        private CSSDocument css1;
        private CSSDocument css2;
        public CompareFilesScreen()
        {
            InitializeComponent();
        }

        private void chooseCSSFiles_1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSS files|*.css";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!String.IsNullOrEmpty(ChooseCSSFilestextBox2.Text.Trim())) compareCSSFiles.Enabled = true;
                ChooseCSSFilestextBox1.Text = ofd.FileName;
                var parser = new Parser();
                css1 = new CSSDocument();
                var raw_text = parser.getTextfromFile(ofd.FileName);
                css1 = parser.ParseText(raw_text);
            }
        }

        private void chooseCSSFiles_2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSS files|*.css";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!String.IsNullOrEmpty(ChooseCSSFilestextBox1.Text.Trim())) compareCSSFiles.Enabled = true;
                ChooseCSSFilestextBox2.Text = ofd.FileName;
                var parser = new Parser();
                css2 = new CSSDocument();
                var raw_text = parser.getTextfromFile(ofd.FileName);
                css2 = parser.ParseText(raw_text);
            }
        }

        private void compareCSSFiles_Click(object sender, EventArgs e) 
        {
            rs = new ResultScreen(css1, css2);
            rs.Show();
        }
    }
}
