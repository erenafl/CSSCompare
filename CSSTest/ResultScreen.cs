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
            foreach (Ruleset rule in css.rulesets)
            {
                TreeNode parent = new TreeNode(rule.selector.value);
                foreach (Decleration dec in rule.declerations)
                {
                    TreeNode child = new TreeNode(dec.property.value);
                    child.Nodes.Add(new TreeNode(dec.value.value));
                    parent.Nodes.Add(child);
                }
                tv.Nodes.Add(parent);
            }
        }
    }

}
