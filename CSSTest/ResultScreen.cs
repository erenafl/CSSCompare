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
        private StylesheetComparer _comparer;
        public ResultScreen(CSSDocument css1, CSSDocument css2)
        {
            InitializeComponent();
            FillTree(parsedCSStreeView1, css1);
            FillTree(parsedCSStreeView2, css2);

            #region @StyleSheet Anaysis Test Section

            _comparer = new StylesheetComparer(css1, css2);
            _comparer.Analyze();
            rulesetSimilarity_textBox.Text = Math.Round(_comparer.RulesetSimilarity * 100, 3, MidpointRounding.AwayFromZero).ToString() + "%";

            #endregion
        }
        private void FillTree(TreeView tv, CSSDocument css)
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
                            TreeNode parent = new TreeNode(RuleName + " " + acr.Charset);
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
                            TreeNode parent = new TreeNode(RuleName + " " + apr.PseudoClass);
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
                            foreach (TreeNode node in tv2.Nodes)
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
                            RuleName = "@document";
                            AtDocumentRule adr = (AtDocumentRule)atrule;
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
                    case AtRuleType.Moz_Document:
                        {
                            RuleName = "@-moz-document";
                            AtMoz_DocumentRule amdr = (AtMoz_DocumentRule)atrule;
                            TreeNode parent = new TreeNode(RuleName + " " + amdr.Identifier);
                            var tv2 = new TreeView();
                            var tv3 = new TreeView();
                            FillAtRules(tv2, amdr.DocumentSpecificAtrules);
                            foreach (TreeNode node in tv2.Nodes)
                            {
                                parent.Nodes.Add((TreeNode)node.Clone());
                            }
                            FillRuleSets(tv3, amdr.DocumentSpesificRulesets);
                            foreach (TreeNode node in tv3.Nodes)
                            {
                                parent.Nodes.Add((TreeNode)node.Clone());
                            }
                            tv.Nodes.Add(parent);
                            break;
                        }
                    case AtRuleType.Webkit_Document:
                        {
                            RuleName = "@-webkit-document";
                            AtWebkit_DocumentRule awdr = (AtWebkit_DocumentRule)atrule;
                            TreeNode parent = new TreeNode(RuleName + " " + awdr.Identifier);
                            var tv2 = new TreeView();
                            var tv3 = new TreeView();
                            FillAtRules(tv2, awdr.DocumentSpecificAtrules);
                            foreach (TreeNode node in tv2.Nodes)
                            {
                                parent.Nodes.Add((TreeNode)node.Clone());
                            }
                            FillRuleSets(tv3, awdr.DocumentSpecificRulesets);
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

                }


            }
        }

        private void ResultScreen_SizeChanged(object sender, EventArgs e)
        {
            parsedCSStreeView1.Width = this.Width / 2 - 22;
            parsedCSStreeView2.Left = parsedCSStreeView1.Width + 12;
            parsedCSStreeView2.Width = this.Width / 2 - 22;
        }

    }

}
