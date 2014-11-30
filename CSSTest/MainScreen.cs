using System;
using System.Windows;
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
        private Searcher searcher;
        private CSSDocument css;
        private TextInput ti;
        private CompareFilesScreen cfs;
        private CompareTextsScreen cts;
        private int LastResultIndex;
        private List<int> SearchResultIndexes;
        public MainScreen()
        {
            InitializeComponent();
            SearchResultIndexes = new List<int>();
            LastResultIndex = 0;
            searcher = new Searcher();
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
                parsedCSSTreeView.Nodes.Clear();
                FillTree(parsedCSSTreeView);
                if (parsedCSSTreeView.Nodes.Count != 0)
                {
                    saveAsToolStripMenuItem.Enabled = true;
                    Search_panel.Enabled = true;
                }
            }
            
        }

        private void parseTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ti == null) { ti = new TextInput(); }
            if (ti.ShowDialog() == DialogResult.OK)
            {

                var parser = new Parser();
                css = new CSSDocument();
                css = parser.ParseText(ti.RawText);
                parsedCSSTreeView.Nodes.Clear();
                FillTree(parsedCSSTreeView);
                if(parsedCSSTreeView.Nodes.Count != 0)saveAsToolStripMenuItem.Enabled = true;
            }
            
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
        private void FillTree(TreeView tv)
        {
            FillAtRules(tv, css.atrules);
            FillRuleSets(tv, css.rulesets);
        }

        private void FillRuleSets(TreeView tv, List<Ruleset> rulesets)
        {
            foreach (Ruleset rule in rulesets)
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

        private void FillAtRules(TreeView tv, List<AtRule> atrules)
        {
            foreach (AtRule atrule in atrules)
            {
                string RuleName;
                switch (atrule.RuleType)
                {
                    case AtRuleType.Charset: 
                        { 
                            RuleName = "@charset";
                            AtCharsetRule acr = (AtCharsetRule)atrule;
                            TreeNode parent = new TreeNode(RuleName + " " +  acr.Charset);
                            tv.Nodes.Add(parent);
                            break; 
                        }
                    case AtRuleType.Namespace:
                        {
                            RuleName = "@namespace";
                            AtNamespaceRule anr = (AtNamespaceRule)atrule;
                            TreeNode parent = new TreeNode(RuleName + " " + anr.Prefix + anr.Url);
                            tv.Nodes.Add(parent);
                            break;
                        }
                    case AtRuleType.Import:
                        {
                            RuleName = "@import";
                            AtImportRule air = (AtImportRule)atrule;
                            TreeNode parent = new TreeNode(RuleName + " " + air.Url + air.ListOfMediaQueries);
                            tv.Nodes.Add(parent);
                            break;
                        }
                    case AtRuleType.Font_face:
                        {
                            RuleName = "@font-face";
                            AtFont_FaceRule affr = (AtFont_FaceRule)atrule;
                            TreeNode parent = new TreeNode(RuleName);
                            foreach (Decleration dec in affr.Declerations)
                            {
                                TreeNode child = new TreeNode(dec.property.value);
                                child.Nodes.Add(new TreeNode(dec.value.value));
                                parent.Nodes.Add(child);
                            }
                            tv.Nodes.Add(parent);
                            break;
                        }
                    case AtRuleType.Page:
                        {
                            RuleName = "@page";
                            AtPageRule apr = (AtPageRule)atrule;
                            TreeNode parent = new TreeNode(RuleName + " " +  apr.PseudoClass);
                            foreach (Decleration dec in apr.Declerations)
                            {
                                TreeNode child = new TreeNode(dec.property.value);
                                child.Nodes.Add(new TreeNode(dec.value.value));
                                parent.Nodes.Add(child);
                            }
                            tv.Nodes.Add(parent);
                            break;
                        }
                    case AtRuleType.Viewport:
                        {
                            
                            AtViewportRule avr = (AtViewportRule)atrule;
                            RuleName = "@" + avr.BrowserPrefix + "viewport";
                            TreeNode parent = new TreeNode(RuleName);
                            foreach (Decleration dec in avr.Declerations)
                            {
                                TreeNode child = new TreeNode(dec.property.value);
                                child.Nodes.Add(new TreeNode(dec.value.value));
                                parent.Nodes.Add(child);
                            }
                            tv.Nodes.Add(parent);
                            break;
                        }
                    case AtRuleType.Media:
                        {
                            RuleName = "@media";
                            AtMediaRule amr = (AtMediaRule)atrule;
                            TreeNode parent = new TreeNode(RuleName + " " + amr.MediaQueries);
                            var tv2 = new TreeView();
                            var tv3 = new TreeView();
                            FillAtRules(tv2, amr.MediaSpecificAtrules);
                            foreach(TreeNode node in tv2.Nodes) 
                            {
                                parent.Nodes.Add((TreeNode)node.Clone());
                            }
                            FillRuleSets(tv3, amr.MediaSpecificRulesets);
                            foreach (TreeNode node in tv3.Nodes)
                            {
                                parent.Nodes.Add((TreeNode)node.Clone());
                            }
                            tv.Nodes.Add(parent);
                            break;
                        }
                    case AtRuleType.Supports:
                        {
                            RuleName = "@supports";
                            AtSupportsRule asr = (AtSupportsRule)atrule;
                            TreeNode parent = new TreeNode(RuleName + " " + asr.Conditions);
                            var tv2 = new TreeView();
                            var tv3 = new TreeView();
                            FillAtRules(tv2, asr.SupportSpecificAtrules);
                            foreach (TreeNode node in tv2.Nodes)
                            {
                                parent.Nodes.Add((TreeNode)node.Clone());
                            }
                            FillRuleSets(tv3, asr.SupportSpecificRulesets);
                            foreach (TreeNode node in tv3.Nodes)
                            {
                                parent.Nodes.Add((TreeNode)node.Clone());
                            }
                            tv.Nodes.Add(parent);
                            break;
                        }
                    case AtRuleType.Document:
                        {
                            
                            AtDocumentRule adr = (AtDocumentRule)atrule;
                            RuleName = "@" + adr.BrowserPrefix + "document";
                            TreeNode parent = new TreeNode(RuleName + " " + adr.Identifier);
                            var tv2 = new TreeView();
                            var tv3 = new TreeView();
                            FillAtRules(tv2, adr.DocumentSpecificAtrules);
                            foreach (TreeNode node in tv2.Nodes)
                            {
                                parent.Nodes.Add((TreeNode)node.Clone());
                            }
                            FillRuleSets(tv3, adr.DocumentSpecificRulesets);
                            foreach (TreeNode node in tv3.Nodes)
                            {
                                parent.Nodes.Add((TreeNode)node.Clone());
                            }
                            tv.Nodes.Add(parent);
                            break;
                        }
                    case AtRuleType.Keyframes:
                        {
                            
                            AtKeyframesRule akr = (AtKeyframesRule)atrule;
                            RuleName = "@" + akr.BrowserPrefix + "keyframes";
                            TreeNode parent = new TreeNode(RuleName + " " + akr.Identifier);
                            foreach (Ruleset rule in akr.Rulesets)
                            {
                                TreeNode child = new TreeNode(rule.selector.value);
                                foreach (Decleration dec in rule.declerations)
                                {
                                    TreeNode grandchild = new TreeNode(dec.property.value);
                                    grandchild.Nodes.Add(new TreeNode(dec.value.value));
                                    child.Nodes.Add(grandchild);
                                }
                                parent.Nodes.Add(child);
                            }
                            tv.Nodes.Add(parent);
                            break;
                        }
                }
                    
                
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

        private void Search_button_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(SearchQuery_textBox.Text.Trim()))
            {
                SearchResultIndexes = searcher.FindInTreeView(SearchQuery_textBox.Text, parsedCSSTreeView);
                LastResultIndex = 0;
                if(SearchResultIndexes.Count != 0)
                {
                    NextResult_button.Enabled = true;
                    Cancel_button.Enabled = true;
                    HighLightResults();
                }
            }
        }

        private void NextResult_button_Click(object sender, EventArgs e)
        {
            ShowNextParticularResult();
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            NextResult_button.Enabled = false;
            Cancel_button.Enabled = false;
            RemoveHighLights();
        }

        private void SearchQuery_textBox_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(SearchQuery_textBox.Text.Trim()))
            {
                Search_button.Enabled = true;
            }
            else Search_button.Enabled = false;
        }

        private void MainScreen_SizeChanged(object sender, EventArgs e)
        {
            Search_panel.Left = this.Width - Search_panel.Width - 34;
        }

        private void HighLightResults()
        {
            foreach(var index in SearchResultIndexes)
            {
                parsedCSSTreeView.Nodes[index].BackColor = Color.LightBlue;
            }
        }
        private void ShowNextParticularResult()
        {
            if (LastResultIndex != 0)
            {
                parsedCSSTreeView.Nodes[SearchResultIndexes.ElementAt(LastResultIndex - 1)].BackColor = Color.LightBlue;
            }
            if (LastResultIndex == SearchResultIndexes.Count) LastResultIndex = 0;
            parsedCSSTreeView.Nodes[SearchResultIndexes.ElementAt(LastResultIndex)].BackColor = Color.Orange;
            parsedCSSTreeView.Nodes[SearchResultIndexes.ElementAt(LastResultIndex)].EnsureVisible();
            LastResultIndex++;
        }
        private void RemoveHighLights()
        {
            foreach (var index in SearchResultIndexes)
            {
                parsedCSSTreeView.Nodes[index].BackColor = Color.Transparent;
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                Search_panel.Visible = true;
            }
            if (keyData == (Keys.Enter))
            {
                if(Search_button.Enabled)
                {
                    if (!String.IsNullOrEmpty(SearchQuery_textBox.Text.Trim()))
                    {
                        SearchResultIndexes = searcher.FindInTreeView(SearchQuery_textBox.Text, parsedCSSTreeView);
                        LastResultIndex = 0;
                        if (SearchResultIndexes.Count != 0)
                        {
                            NextResult_button.Enabled = true;
                            Cancel_button.Enabled = true;
                            HighLightResults();
                        }
                    }
                }
            }
            if (keyData == (Keys.Right))
            {
                if (NextResult_button.Enabled)
                {
                    ShowNextParticularResult(); 
                }
            }
            if (keyData == (Keys.Escape))
            {
                RemoveHighLights();
                Search_panel.Visible = false;
                NextResult_button.Enabled = false;
                Cancel_button.Enabled = false;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
