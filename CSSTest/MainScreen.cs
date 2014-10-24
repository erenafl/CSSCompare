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
                parsedCSSTreeView.Nodes.Clear();
                FillTree(parsedCSSTreeView);
                if (parsedCSSTreeView.Nodes.Count != 0) saveAsToolStripMenuItem.Enabled = true;
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
                            /*
                            foreach (Ruleset rule in asr.SupportSpecificRulesets)
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
                             */
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
                    case AtRuleType.Keyframes:
                        {
                            RuleName = "@keyframes";
                            AtKeyframesRule akr = (AtKeyframesRule)atrule;
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
                    case AtRuleType.Webkit_Keyframes:
                        {
                            RuleName = "@-webkit-keyframes";
                            AtWebkit_KeyframesRule awkr = (AtWebkit_KeyframesRule)atrule;
                            TreeNode parent = new TreeNode(RuleName + " " + awkr.Identifier);
                            foreach (Ruleset rule in awkr.Rulesets)
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
                    case AtRuleType.Moz_Keyframes:
                        {
                            RuleName = "@-moz-keyframes";
                            AtMoz_KeyframesRule amkr = (AtMoz_KeyframesRule)atrule;
                            TreeNode parent = new TreeNode(RuleName + " " + amkr.Identifier);
                            foreach (Ruleset rule in amkr.Rulesets)
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
                    case AtRuleType.O_Keyframes:
                        {
                            RuleName = "@-o-keyframes";
                            AtO_KeyframesRule aokr = (AtO_KeyframesRule)atrule;
                            TreeNode parent = new TreeNode(RuleName + " " + aokr.Identifier);
                            foreach (Ruleset rule in aokr.Rulesets)
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
                    case AtRuleType.Document:
                        {
                            RuleName = "@document";
                            AtDocumentRule adr = (AtDocumentRule)atrule;
                            TreeNode parent = new TreeNode(RuleName + " " + adr.Identifier);
                            foreach (Ruleset rule in adr.DocumentSpecificRulesets)
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
                    case AtRuleType.Moz_Document:
                        {
                            RuleName = "@-moz-document";
                            AtMoz_DocumentRule amdr = (AtMoz_DocumentRule)atrule;
                            TreeNode parent = new TreeNode(RuleName + " " + amdr.Identifier);
                            foreach (Ruleset rule in amdr.DocumentSpesificRulesets)
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
                    case AtRuleType.Webkit_Document:
                        {
                            RuleName = "@-webkit-document";
                            AtWebkit_DocumentRule awdr = (AtWebkit_DocumentRule)atrule;
                            TreeNode parent = new TreeNode(RuleName + " " + awdr.Identifier);
                            foreach (Ruleset rule in awdr.DocumentSpecificRulesets)
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


    }
}
