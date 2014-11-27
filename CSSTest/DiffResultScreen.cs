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
    public partial class DiffResultScreen : Form
    {
        private diff_match_patch diffOperator;
        public DiffResultScreen(string text1, string text2)
        {
            InitializeComponent();
            diffOperator = new diff_match_patch();
            List<Diff> diffs = diffOperator.diff_main(text1, text2);
            VisualizeDiff(diffs);
        }
        private void VisualizeDiff(List<Diff> diffs)
        {
            foreach(var diff in diffs )
            {
                Color color = new Color();
                if (diff.operation == Operation.EQUAL) color = Color.White;
                if (diff.operation == Operation.INSERT) color = Color.LightGreen;
                if (diff.operation == Operation.EQUAL) color = Color.LightPink;
                DiffResult_richTextBox1.SelectionBackColor = color;
                DiffResult_richTextBox1.AppendText(diff.text);
                DiffResult_richTextBox1.AppendText("\n");
            }
        }
    }
}
