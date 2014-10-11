using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;

namespace CSSParser
{
    public class Parser
    {
		private CSSDocument css;
        char[] delimiterChars = { '{', '}' };
        public Parser() { }

        public CSSDocument ParseText(string raw_text)
        {
            css = new CSSDocument();
            var css_text = RemoveComments(raw_text);
            ParseAtRules(css_text);
            ParseRuleSets(css_text);
			MergeRulesets();
            return css;
        }

		private void MergeRulesets()
		{
			for(int i =0 ; i< css.rulesets.Count(); i++) 
			{
				var duplicates = css.rulesets.FindAll(a => a.selector.value == css.rulesets[i].selector.value).Where(a => a != css.rulesets[i]);
				foreach (Ruleset duplicate in duplicates)
				{
					foreach(Decleration dec in duplicate.declerations) 
					{
						css.rulesets[i].AddDecleration(dec);
					}
					css.rulesets.Remove(duplicate);
				}
			}
		}

        private string RemoveComments(string raw_text)
        {
            string css_text = raw_text.Replace("\n", "").Replace("\r", "").Replace("\t", "");
            var blockComments = @"/\*(.*?)\*/";
            css_text = Regex.Replace(css_text,
                blockComments,
                me =>
                {
                    if (me.Value.StartsWith("/*") || me.Value.StartsWith("//"))
                        return me.Value.StartsWith("//") ? Environment.NewLine : "";
                    // Keep the literal strings
                    return me.Value;
                }, RegexOptions.Singleline);
            return css_text;
        }



        private void ParseRuleSets(string css_text)
        {
            string[] Rulesets = css_text.Split('}');
            foreach (string ruleset_raw in Rulesets)
            {
                var ruleset = ruleset_raw.Trim();
                if (ruleset != "")
                {
                    string[] SelectorsAndDeclerations = ruleset.Split('{');
                    if (SelectorsAndDeclerations[0].Contains(","))
                    {
                        string[] selectors = SelectorsAndDeclerations[0].Split(',');
                        string[] declerations = SelectorsAndDeclerations[1].Split(';');
                        foreach (string selector in selectors)
                        {
                            if (selector != "")
                            {
                                var rule = new Ruleset();
                                Selector slctr = new Selector(selector.Trim());
                                rule.selector = slctr;
                                foreach (string decleration_raw in declerations)
                                {
                                    var decleration = decleration_raw.Trim();
                                    if (decleration != "")
                                    {
                                        string[] PropertyAndValue = decleration.Split(':');
                                        var property = new Property(PropertyAndValue[0].Trim());
                                        var value = new Value(PropertyAndValue[1].Trim());
                                        var dec = new Decleration(property, value);
                                        rule.AddDecleration(dec);


                                        /*
										p.setTag(PropertyAndValue[0].Trim());
										p.setValue(PropertyAndValue[1].Trim());
										slctr.addProperty(p);
                                         */
                                    }
                                }
                                //css.AddSelector(slctr);
                                css.AddRuleset(rule);
                            }

                        }
                    }
                    else
                    {
                        var rule = new Ruleset();
                        Selector slctr = new Selector(SelectorsAndDeclerations[0].Trim());
                        rule.selector = slctr;
                        //slctr.setTag(SelectorsAndDeclerations[0].Trim());
                        string[] declerations = SelectorsAndDeclerations[1].Split(';');
                        foreach (string decleration_raw in declerations)
                        {
                            var decleration = decleration_raw.Trim();
                            if (decleration != "")
                            {
                                string[] PropertyAndValue = decleration.Split(':');
                                var property = new Property(PropertyAndValue[0].Trim());
                                var value = new Value(PropertyAndValue[1].Trim());
                                var dec = new Decleration(property, value);
                                rule.AddDecleration(dec);
                                /*
								Property p = new Property();
                                p.setTag(PropertyAndValue[0].Trim());
                                p.setValue(PropertyAndValue[1].Trim());
								slctr.addProperty(p);
                                 */
                            }

                        }
                        //css.AddSelector(slctr);
                        css.AddRuleset(rule);
                    }
                }

            }
        }

        private void ParseAtRules(string css_text)
        {
            #region @Rule Test Section
            int i = 0;
            int j = 0;
            while ((i = css_text.IndexOf("@charset", i)) != -1)
            {
                j = css_text.IndexOf(";", i);
                var charsetRule = css_text.Substring(i, (j - i + 1));
                css_text = css_text.Replace(charsetRule, "");
                i = i + "@charset".Length;
            }
            i = 0; j = 0;
            while ((i = css_text.IndexOf("@import", i)) != -1)
            {
                j = css_text.IndexOf(";", i);
                var importRule = css_text.Substring(i, (j - i + 1));
                css_text = css_text.Replace(importRule, "");
                i = i + "@import".Length;
            }
            i = 0; j = 0;
            while ((i = css_text.IndexOf("@namespace", i)) != -1)
            {
                j = css_text.IndexOf(";", i);
                var namespaceRule = css_text.Substring(i, (j - i + 1));
                css_text = css_text.Replace(namespaceRule, "");
                i = i + "@namespace".Length;
            }
            i = 0; j = 0;
            while ((i = css_text.IndexOf("@font-face", i)) != -1)
            {
                j = css_text.IndexOf("}", i);
                var font_faceRule = css_text.Substring(i, (j - i + 1));
                css_text = css_text.Replace(font_faceRule, "");
                i = i + "@font-face".Length;
            }
            /*
            i = 0; j = 0;
            while ((i = css_text.IndexOf("@media", i)) != -1)
            {
                j = css_text.IndexOf("}", i);
                var mediaRule = css_text.Substring(i, (j - i + 1));
                css_text = css_text.Replace(mediaRule, "");
                i = i + "@media".Length;
            }
            */
            css_text = Regex.Replace(css_text, @"/@media[^{]+\{([\s\S]+?})\s*}/g", "");

            i = 0; j = 0;
            while ((i = css_text.IndexOf("@support", i)) != -1)
            {
                j = css_text.IndexOf("}", i);
                var supportRule = css_text.Substring(i, (j - i + 1));
                css_text = css_text.Replace(supportRule, "");
                i = i + "@support".Length;
            }
            i = 0; j = 0;
            while ((i = css_text.IndexOf("@page", i)) != -1)
            {
                j = css_text.IndexOf("}", i);
                var pageRule = css_text.Substring(i, (j - i + 1));
                css_text = css_text.Replace(pageRule, "");
                i = i + "@page".Length;
            }

            #endregion
        }
        public string getTextfromFile(string filename)
        {
            string rawText = File.ReadAllText(filename);
            return rawText;
        }

        public string handleNewline(string raw_text)
        {
            string result = Regex.Replace(raw_text, @"\r\n?|\n", "");
            return result;
        }
    }
}
