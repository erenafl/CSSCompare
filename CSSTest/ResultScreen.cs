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

    public partial class ResultScreen : Form
    {
        public ResultScreen(CSSDocument css1, CSSDocument css2)
        {
            InitializeComponent();
            fillTree(parsedCSStreeView1, css1);
            fillTree(parsedCSStreeView2, css2);
        }
        private void fillTree(TreeView tv, CSSDocument css)
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
    }

}
