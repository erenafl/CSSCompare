﻿using System;
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
            css_text = ParseAtRules(css_text);
            ParseRuleSets(css_text, css.rulesets);
			MergeRulesets(css.rulesets);
            return css;
        }

		private void MergeRulesets(List<Ruleset> rulesets)
		{
			for(int i =0 ; i< rulesets.Count(); i++) 
			{
				var duplicates = rulesets.FindAll(a => a.selector.value == rulesets[i].selector.value).Where(a => a != rulesets[i]);
				foreach (Ruleset duplicate in duplicates)
				{
					foreach(Decleration dec in duplicate.declerations) 
					{
						rulesets[i].AddDecleration(dec);
					}
					rulesets.Remove(duplicate);
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



        private void ParseRuleSets(string css_text, List<Ruleset> rulesets)
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
                        List<string> declerations = SelectorsAndDeclerations[1].Split(';').ToList();
                        foreach (string selector in selectors)
                        {
                            if (selector != "")
                            {
                                var rule = new Ruleset();
                                Selector slctr = new Selector(selector.Trim());
                                rule.selector = slctr;
                                for(int i = 0; i < declerations.Count ; i++)
                                {
                                    var decleration = declerations[i];
                                    if (decleration != "")
                                    {
                                        if (decleration.Contains("url") && decleration.Contains("(") && !decleration.Contains(")"))
                                        {
                                            decleration += ";" + declerations[i + 1];
                                            declerations.Remove(declerations[i + 1]);
                                            decleration = decleration.Trim();
                                        }
                                        
                                        string[] PropertyAndValue = decleration.Split(":".ToCharArray(), 2);
                                        var property = new Property(PropertyAndValue[0].Trim());
                                        var value = new Value(PropertyAndValue[1].Trim());
                                        var dec = new Decleration(property, value);
                                        rule.AddDecleration(dec);
                                    }
                                }
                                rulesets.Add(rule);
                            }

                        }
                    }
                    else
                    {
                        var rule = new Ruleset();
                        Selector slctr = new Selector(SelectorsAndDeclerations[0].Trim());
                        rule.selector = slctr;
                        List<string> declerations = SelectorsAndDeclerations[1].Split(';').ToList();
                        for (int i = 0; i < declerations.Count; i++)
                        {
                            var decleration = declerations[i];
                            if (decleration != "")
                            {
                                if (decleration.Contains("url") && decleration.Contains("(") && !decleration.Contains(")"))
                                {
                                    decleration += ";" +  declerations[i + 1];
                                    declerations.Remove(declerations[i + 1]);
                                    decleration = decleration.Trim();
                                }

                                string[] PropertyAndValue = decleration.Split(":".ToCharArray(), 2);
                                var property = new Property(PropertyAndValue[0].Trim());
                                var value = new Value(PropertyAndValue[1].Trim());
                                var dec = new Decleration(property, value);
                                rule.AddDecleration(dec);
                            }
                        }
                        rulesets.Add(rule);
                    }
                }

            }
        }

        private string ParseAtRules(string css_text)
        {
            
            #region @Rule Test Section
            int i = 0;
            int j = 0;
            int k = 0;
            while ((i = css_text.IndexOf("@charset", i)) != -1)
            {
                j = css_text.IndexOf(";", i);
                var charsetRule_Text = css_text.Substring(i, (j - i + 1));

                var charsetRule = new AtCharsetRule();
                var charsetRule_TrimmedText = charsetRule_Text.Substring(0, charsetRule_Text.Length - 1);
                charsetRule.Charset = charsetRule_TrimmedText.Split(' ')[1].Trim();
                css.AddAtRule(charsetRule);

                css_text = css_text.Replace(charsetRule_Text, "");
                i = 0; j = 0;
            }

            i = 0; j = 0;
            while ((i = css_text.IndexOf("@import", i)) != -1)
            {
                j = css_text.IndexOf(";", i);
                var importRule_Text = css_text.Substring(i, (j - i + 1));

                var importRule = new AtImportRule();
                var importRule_TrimmedText = importRule_Text.Substring(0, importRule_Text.Length - 1);
                importRule.Url = importRule_TrimmedText.Split(' ')[1].Trim();
                if (importRule_TrimmedText.Split(' ').Count() > 2)
                {
                    importRule.ListOfMediaQueries = importRule_TrimmedText.Substring(importRule_TrimmedText.IndexOf(importRule.Url) + importRule.Url.Length + 1).Trim();
                }
                css.AddAtRule(importRule);
                

                css_text = css_text.Replace(importRule_Text, "");
                i = 0; j = 0;
            }

            i = 0; j = 0;
            while ((i = css_text.IndexOf("@namespace", i)) != -1)
            {
                j = css_text.IndexOf(";", i);
                var namespaceRule_Text = css_text.Substring(i, (j - i + 1));

                var namespaceRule = new AtNamespaceRule();
                var namespaceRule_TrimmedText = namespaceRule_Text.Substring(0, namespaceRule_Text.Length - 1);
                if (namespaceRule_TrimmedText.Split(' ').Count() > 2)
                {
                    namespaceRule.Prefix = namespaceRule_TrimmedText.Split(' ')[1].Trim();
                    namespaceRule.Url = namespaceRule_TrimmedText.Split(' ')[2].Trim();
                }
                else namespaceRule.Url = namespaceRule_TrimmedText.Split(' ')[1].Trim();
                css.AddAtRule(namespaceRule);

                css_text = css_text.Replace(namespaceRule_Text, "");
                i = 0; j = 0;
            }

            i = 0; j = 0;
            while ((i = css_text.IndexOf("@font-face", i)) != -1)
            {
                j = css_text.IndexOf("}", i);
                var font_faceRule_Text = css_text.Substring(i, (j - i + 1));

                var font_faceRule = new AtFont_FaceRule();
                var font_faceRule_TrimmedText = font_faceRule_Text.Substring(0, font_faceRule_Text.Length - 1);
                string[] declerations = font_faceRule_TrimmedText.Split('{')[1].Split(';');
                foreach (string decleration_raw in declerations)
                {
                    var decleration = decleration_raw.Trim();
                    if (decleration != "")
                    {
                        string[] PropertyAndValue = decleration.Split(':');
                        var property = new Property(PropertyAndValue[0].Trim());
                        var value = new Value(PropertyAndValue[1].Trim());
                        var dec = new Decleration(property, value);
                        font_faceRule.Declerations.Add(dec);
                    }

                }
                css.AddAtRule(font_faceRule);


                css_text = css_text.Replace(font_faceRule_Text, "");
                i = 0; j = 0;
            }

            i = 0; j = 0; k = 0;
            while ((i = css_text.IndexOf("@media", i)) != -1)
            {
                j = i;
                k = css_text.IndexOf("}", i);
                bool isFound = true;
                while( isFound ){
                    if (css_text.Substring(j + 1, k - j - 1).Trim() == "")
                    {
                        isFound = false;
                        j = k;
                        continue;
                    }
                    j = k;
                    k++;
                    k = css_text.IndexOf("}", k);
                }

                var mediaRule_Text = css_text.Substring(i, (j - i + 1));

                var mediaRule = new AtMediaRule();
                var mediaRule_TrimmedText = mediaRule_Text.Substring(0, mediaRule_Text.Length - 1);
                mediaRule.MediaQueries = mediaRule_TrimmedText.Split('{')[0].Substring("@media".Length + 1);
                ParseRuleSets(mediaRule_TrimmedText.Substring(mediaRule_TrimmedText.IndexOf("{",0) + 1), mediaRule.MediaSpecificRulesets);
                MergeRulesets(mediaRule.MediaSpecificRulesets);
                css.AddAtRule(mediaRule);

                css_text = css_text.Replace(mediaRule_Text, "");
                i = 0; j = 0; k = 0;
            }


            i = 0; j = 0; k = 0 ;
            while (i <= (css_text.Length - 1) && ((i = css_text.IndexOf("@supports", i)) != -1))
            {
                j = i;
                k = css_text.IndexOf("}", i);
                bool isFound = true;
                while (isFound)
                {
                    if (css_text.Substring(j + 1, k - j - 1).Trim() == "")
                    {
                        isFound = false;
                        j = k;
                        continue;
                    }
                    j = k;
                    k++;
                    k = css_text.IndexOf("}", k);
                }

                var supportsRule_Text = css_text.Substring(i, (j - i + 1));

                var supportsRule = new AtSupportsRule();
                var supportsRule_TrimmedText = supportsRule_Text.Substring(0, supportsRule_Text.Length - 1);
                supportsRule.Conditions = supportsRule_TrimmedText.Split('{')[0].Substring("@supports".Length + 1);
                ParseRuleSets(supportsRule_TrimmedText.Substring(supportsRule_TrimmedText.IndexOf("{", 0) + 1), supportsRule.SupportSpecificRulesets);
                MergeRulesets(supportsRule.SupportSpecificRulesets);
                css.AddAtRule(supportsRule);

                css_text = css_text.Replace(supportsRule_Text, "");
                i = 0; j = 0; k = 0;
            }

            i = 0; j = 0; k = 0;
            while ((i = css_text.IndexOf("@keyframes", i)) != -1)
            {
                j = i;
                k = css_text.IndexOf("}", i);
                bool isFound = true;
                while (isFound)
                {
                    if (css_text.Substring(j + 1, k - j - 1).Trim() == "")
                    {
                        isFound = false;
                        j = k;
                        continue;
                    }
                    j = k;
                    k++;
                    k = css_text.IndexOf("}", k);
                }

                var keyframesRule_Text = css_text.Substring(i, (j - i + 1));
                
                var keyframesRule = new AtKeyframesRule();
                var keyframesRule_TrimmedText = keyframesRule_Text.Substring(0, keyframesRule_Text.Length - 1);
                keyframesRule.Identifier = keyframesRule_TrimmedText.Split('{')[0].Substring("@keyframes".Length + 1);
                ParseRuleSets(keyframesRule_TrimmedText.Substring(keyframesRule_TrimmedText.IndexOf("{", 0) + 1), keyframesRule.Rulesets);
                //MergeRulesets(keyframesRule.Rulesets);
                css.AddAtRule(keyframesRule);
                
                css_text = css_text.Replace(keyframesRule_Text, "");
                i = 0; j = 0; k = 0;
            }

            i = 0; j = 0; k = 0;
            while ((i = css_text.IndexOf("@-webkit-keyframes", i)) != -1)
            {
                j = i;
                k = css_text.IndexOf("}", i);
                bool isFound = true;
                while (isFound)
                {
                    if (css_text.Substring(j + 1, k - j - 1).Trim() == "")
                    {
                        isFound = false;
                        j = k;
                        continue;
                    }
                    j = k;
                    k++;
                    k = css_text.IndexOf("}", k);
                }

                var webkit_keyframesRule_Text = css_text.Substring(i, (j - i + 1));
                
                var webkit_keyframesRule = new AtWebkit_KeyframesRule();
                var webkit_keyframesRule_TrimmedText = webkit_keyframesRule_Text.Substring(0, webkit_keyframesRule_Text.Length - 1);
                webkit_keyframesRule.Identifier = webkit_keyframesRule_TrimmedText.Split('{')[0].Substring("@-webkit-keyframes".Length + 1);
                ParseRuleSets(webkit_keyframesRule_TrimmedText.Substring(webkit_keyframesRule_TrimmedText.IndexOf("{", 0) + 1), webkit_keyframesRule.Rulesets);
                //MergeRulesets(webkit_keyframesRule.Rulesets);
                css.AddAtRule(webkit_keyframesRule);
                css_text = css_text.Replace(webkit_keyframesRule_Text, "");
                i = 0; j = 0; k = 0;
            }

            i = 0; j = 0; k = 0;
            while ((i = css_text.IndexOf("@-moz-keyframes", i)) != -1)
            {
                j = i;
                k = css_text.IndexOf("}", i);
                bool isFound = true;
                while (isFound)
                {
                    if (css_text.Substring(j + 1, k - j - 1).Trim() == "")
                    {
                        isFound = false;
                        j = k;
                        continue;
                    }
                    j = k;
                    k++;
                    k = css_text.IndexOf("}", k);
                }

                var moz_keyframesRule_Text = css_text.Substring(i, (j - i + 1));

                var moz_keyframesRule = new AtMoz_KeyframesRule();
                var moz_keyframesRule_TrimmedText = moz_keyframesRule_Text.Substring(0, moz_keyframesRule_Text.Length - 1);
                moz_keyframesRule.Identifier = moz_keyframesRule_TrimmedText.Split('{')[0].Substring("@-moz-keyframes".Length + 1);
                ParseRuleSets(moz_keyframesRule_TrimmedText.Substring(moz_keyframesRule_TrimmedText.IndexOf("{", 0) + 1), moz_keyframesRule.Rulesets);
                //MergeRulesets(moz_keyframesRule.Rulesets);
                css.AddAtRule(moz_keyframesRule);
                css_text = css_text.Replace(moz_keyframesRule_Text, "");
                i = 0; j = 0; k = 0;
            }

            i = 0; j = 0; k = 0;
            while ((i = css_text.IndexOf("@-o-keyframes", i)) != -1)
            {
                j = i;
                k = css_text.IndexOf("}", i);
                bool isFound = true;
                while (isFound)
                {
                    if (css_text.Substring(j + 1, k - j - 1).Trim() == "")
                    {
                        isFound = false;
                        j = k;
                        continue;
                    }
                    j = k;
                    k++;
                    k = css_text.IndexOf("}", k);
                }

                var o_keyframesRule_Text = css_text.Substring(i, (j - i + 1));

                var o_keyframesRule = new AtO_KeyframesRule();
                var o_keyframesRule_TrimmedText = o_keyframesRule_Text.Substring(0, o_keyframesRule_Text.Length - 1);
                o_keyframesRule.Identifier = o_keyframesRule_TrimmedText.Split('{')[0].Substring("@-o-keyframes".Length + 1);
                ParseRuleSets(o_keyframesRule_TrimmedText.Substring(o_keyframesRule_TrimmedText.IndexOf("{", 0) + 1), o_keyframesRule.Rulesets);
                //MergeRulesets(moz_keyframesRule.Rulesets);
                css.AddAtRule(o_keyframesRule);
                css_text = css_text.Replace(o_keyframesRule_Text, "");
                i = 0; j = 0; k = 0;
            }

            i = 0; j = 0;
            while ((i = css_text.IndexOf("@page", i)) != -1)
            {
                j = css_text.IndexOf("}", i);
                var pageRule_Text = css_text.Substring(i, (j - i + 1));
                var pageRule = new AtPageRule();
                var pageRule_TrimmedText = pageRule_Text.Substring(0, pageRule_Text.Length - 1);
                pageRule.PseudoClass = pageRule_TrimmedText.Split('{')[0].Substring("@page".Length + 1);

                string[] declerations = pageRule_TrimmedText.Split('{')[1].Split(';');
                foreach (string decleration_raw in declerations)
                {
                    var decleration = decleration_raw.Trim();
                    if (decleration != "")
                    {
                        string[] PropertyAndValue = decleration.Split(':');
                        var property = new Property(PropertyAndValue[0].Trim());
                        var value = new Value(PropertyAndValue[1].Trim());
                        var dec = new Decleration(property, value);
                        pageRule.Declerations.Add(dec);
                    }

                }
                css.AddAtRule(pageRule);

                css_text = css_text.Replace(pageRule_Text, "");
                i = 0; j = 0;
            }

            i = 0; j = 0; k = 0;
            while ((i = css_text.IndexOf("@document", i)) != -1)
            {
                j = i;
                k = css_text.IndexOf("}", i);
                bool isFound = true;
                while (isFound)
                {
                    if (css_text.Substring(j + 1, k - j - 1).Trim() == "")
                    {
                        isFound = false;
                        j = k;
                        continue;
                    }
                    j = k;
                    k++;
                    k = css_text.IndexOf("}", k);
                }

                var documentRule_Text = css_text.Substring(i, (j - i + 1));

                var documentRule = new AtDocumentRule();
                var documentRule_TrimmedText = documentRule_Text.Substring(0, documentRule_Text.Length - 1);
                documentRule.Identifier = documentRule_TrimmedText.Split('{')[0].Substring("@document".Length + 1);
                ParseRuleSets(documentRule_TrimmedText.Substring(documentRule_TrimmedText.IndexOf("{", 0) + 1), documentRule.Rulesets);
                MergeRulesets(documentRule.Rulesets);
                css.AddAtRule(documentRule);

                css_text = css_text.Replace(documentRule_Text, "");
                i = 0; j = 0; k = 0;
            }

            i = 0; j = 0; k = 0;
            while ((i = css_text.IndexOf("@-moz-document", i)) != -1)
            {
                j = i;
                k = css_text.IndexOf("}", i);
                bool isFound = true;
                while (isFound)
                {
                    if (css_text.Substring(j + 1, k - j - 1).Trim() == "")
                    {
                        isFound = false;
                        j = k;
                        continue;
                    }
                    j = k;
                    k++;
                    k = css_text.IndexOf("}", k);
                }

                var moz_documentRule_Text = css_text.Substring(i, (j - i + 1));

                var moz_documentRule = new AtMoz_DocumentRule();
                var moz_documentRule_TrimmedText = moz_documentRule_Text.Substring(0, moz_documentRule_Text.Length - 1);
                moz_documentRule.Identifier = moz_documentRule_TrimmedText.Split('{')[0].Substring("@-moz-document".Length + 1);
                ParseRuleSets(moz_documentRule_TrimmedText.Substring(moz_documentRule_TrimmedText.IndexOf("{", 0) + 1), moz_documentRule.Rulesets);
                MergeRulesets(moz_documentRule.Rulesets);
                css.AddAtRule(moz_documentRule);

                css_text = css_text.Replace(moz_documentRule_Text, "");
                i = 0; j = 0; k = 0;
            }

            i = 0; j = 0; k = 0;
            while ((i = css_text.IndexOf("@-webkit-document", i)) != -1)
            {
                j = i;
                k = css_text.IndexOf("}", i);
                bool isFound = true;
                while (isFound)
                {
                    if (css_text.Substring(j + 1, k - j - 1).Trim() == "")
                    {
                        isFound = false;
                        j = k;
                        continue;
                    }
                    j = k;
                    k++;
                    k = css_text.IndexOf("}", k);
                }

                var webkit_documentRule_Text = css_text.Substring(i, (j - i + 1));

                var webkit_documentRule = new AtWebkit_DocumentRule();
                var webkit_documentRule_TrimmedText = webkit_documentRule_Text.Substring(0, webkit_documentRule_Text.Length - 1);
                webkit_documentRule.Identifier = webkit_documentRule_TrimmedText.Split('{')[0].Substring("@-webkit-document".Length + 1);
                ParseRuleSets(webkit_documentRule_TrimmedText.Substring(webkit_documentRule_TrimmedText.IndexOf("{", 0) + 1), webkit_documentRule.Rulesets);
                MergeRulesets(webkit_documentRule.Rulesets);
                css.AddAtRule(webkit_documentRule);

                css_text = css_text.Replace(webkit_documentRule_Text, "");
                i = 0; j = 0; k = 0;
            }

            #endregion
            return css_text;
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
