using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CSSParser;

namespace CSSTest
{
    public partial class MainScreen : Form
    {
        private CSSDocument css;
        private TextInput ti;
        private CompareFilesScreen cfs;
        private CompareTextsScreen cts;
        public MainScreen()
        {
            InitializeComponent();
        }

        private void parseFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSS files|*.css";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var parser = new Parser();
                css = new CSSDocument();
                string raw_text = parser.getTextfromFile(ofd.FileName);
                css = parser.ParseText(raw_text);
                fillTree(parsedCSSTreeView);
            }
            saveAsToolStripMenuItem.Enabled = true;
        }

        private void parseTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ti == null) { ti = new TextInput(); }
            if (ti.ShowDialog() == DialogResult.OK)
            {

                var parser = new Parser();
                css = new CSSDocument();
                css = parser.ParseText(ti.RawText);
                fillTree(parsedCSSTreeView);
            }
            saveAsToolStripMenuItem.Enabled = true;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "TXT files|*.txt | XML files | *.xml";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, css.generateXML());
            }
        }
        private void fillTree(TreeView tv)
        {
            foreach (Selector s in css.selectors) 
            {
                TreeNode parent = new TreeNode(s.tag);
                foreach (Property p in s.properties) 
                {
                    TreeNode child = new TreeNode(p.tag);
                    child.Nodes.Add(new TreeNode(p.value));
                    parent.Nodes.Add(child);
                }
                tv.Nodes.Add(parent);
            }
        }

        private void cSSFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cfs = new CompareFilesScreen();
            cfs.Show();
        }

        private void cSSTextsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cts = new CompareTextsScreen();
            cts.Show();
        }


    }
}
