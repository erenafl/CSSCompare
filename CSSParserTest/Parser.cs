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
        public Parser() { }

        public CSSDocument ParseText(string raw_text)
        {
            css = new CSSDocument();
            var css_text = RemoveComments(raw_text);
            css_text = ParseAtRules(css_text, css.atrules);
            ParseRuleSets(css_text, css.rulesets);
			MergeRulesets(css.rulesets);
            return css;
        }

		private void MergeRulesets(List<Ruleset> rulesets)
		{
			for(int i =0 ; i< rulesets.Count(); i++) 
			{
				var duplicates = rulesets.FindAll(a => a.selector.value == rulesets[i].selector.value).Where(a => a != rulesets[i]).ToList();
				foreach (Ruleset duplicate in duplicates)
				{
                    foreach (Decleration dec in duplicate.declerations)
                    {
                        rulesets[i].AddDecleration(dec);
                    }   
					rulesets.Remove(duplicate);
				}
                for (int j = 0; j < rulesets[i].declerations.Count(); j++) 
                {
                    var duplicateDeclerations = rulesets[i].declerations.FindAll(x => x.property.value == rulesets[i].declerations[j].property.value).Where(x => x != rulesets[i].declerations[j]).ToList();
                    if(duplicateDeclerations.Count() != 0) 
                    {
                        foreach(Decleration dec in duplicateDeclerations)
                        {
                            rulesets[i].declerations.Remove(dec);
                        }
                        
                    }
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
                                            //declerations.Remove(declerations[i + 1]);
                                            i++;
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
                                    //declerations.Remove(declerations[i + 1]);
                                    i++;
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

        private string ParseAtRules(string css_text, List<AtRule> atrules)
        {
            #region @Rule Test Section

            int i = 0;
            string selectedAtRuleType = null;
            while (((i = css_text.IndexOf("@", i)) != -1))
            {
                foreach (string atRuleType in AtRuleTypeExplicit.AtRuleTypeExplicitNames)
                {
                    if (css_text.IndexOf(atRuleType, i, atRuleType.Length + 1) != -1)
                    {
                        selectedAtRuleType = atRuleType;
                    }
                }
                if (selectedAtRuleType == null)
                {
                    //Unrecognized at rules
                    if (i == 0 || (css_text[i - 1] == '}' || css_text[i - 1] == ' '))
                    {
                        css_text = css_text.Replace(css_text.Substring(i, FindEndOfConditinonalGroupRule(i, css_text) - i + 1), "");
                    }
                    //Unrecognized '@' characters(not an atrule)
                    else i++;
                }
                else
                {
                    var parsedText = ParseSpecificAtRule(selectedAtRuleType, css_text.Substring(i), atrules);
                    css_text = css_text.Substring(0, i) + parsedText;
                }
                selectedAtRuleType = null;
            }

            return css_text;

            #endregion
        }

        private string ParseSpecificAtRule(string atRuleType, string atRuleText, List<AtRule> atrules) 
        {
            string parsedText = "";
            switch (atRuleType)
            {
                case "@charset":
                    {
                        parsedText = ParseAtCharsetRule(atRuleText, atrules);
                        break;
                    }
                case "@import":
                    {
                        parsedText = ParseAtImportRule(atRuleText, atrules);
                        break;
                    }
                case "@namespace":
                    {
                        parsedText = ParseAtNamespaceRule(atRuleText, atrules);
                        break;
                    }
                case "@media":
                    {
                        parsedText = ParseAtMediaRule(atRuleText, atrules);
                        break;
                    }
                case "@font-face":
                    {
                        parsedText = ParseAtFont_FaceRule(atRuleText, atrules);
                        break;
                    }
                case "@page":
                    {
                        parsedText = ParseAtPageRule(atRuleText, atrules);
                        break;
                    }
                case "@supports":
                    {
                        parsedText = ParseAtSupportsRule(atRuleText, atrules);
                        break;
                    }
                case "@document":
                    {
                        parsedText = ParseAtDocumentRule(atRuleText, atrules, "");
                        break;
                    }
                case "@-moz-document":
                    {
                        parsedText = ParseAtDocumentRule(atRuleText, atrules, "-moz-");
                        break;
                    }
                case "@-webkit-document":
                    {
                        parsedText = ParseAtDocumentRule(atRuleText, atrules, "-webkit-");
                        break;
                    }
                case "@-ms-document":
                    {
                        parsedText = ParseAtDocumentRule(atRuleText, atrules, "-ms-");
                        break;
                    }
                case "@-o-document":
                    {
                        parsedText = ParseAtDocumentRule(atRuleText, atrules, "-o-");
                        break;
                    }

                case "@keyframes":
                    {
                        parsedText = ParseAtKeyframesRule(atRuleText, atrules, "");
                        break;
                    }
                case "@-o-keyframes":
                    {
                        parsedText = ParseAtKeyframesRule(atRuleText, atrules, "-o-");
                        break;
                    }
                case "@-moz-keyframes":
                    {
                        parsedText = ParseAtKeyframesRule(atRuleText, atrules, "-moz-");
                        break;
                    }
                case "@-webkit-keyframes":
                    {
                        parsedText = ParseAtKeyframesRule(atRuleText, atrules, "-webkit-");
                        break;
                    }
                case "@-ms-keyframes":
                    {
                        parsedText = ParseAtKeyframesRule(atRuleText, atrules, "-ms-");
                        break;
                    }
                case "@viewport":
                    {
                        parsedText = ParseAtViewportRule(atRuleText, atrules, "");
                        break;
                    }
                case "@-o-viewport":
                    {
                        parsedText = ParseAtViewportRule(atRuleText, atrules, "-o-");
                        break;
                    }
                case "@-moz-viewport":
                    {
                        parsedText = ParseAtViewportRule(atRuleText, atrules, "-moz-");
                        break;
                    }
                case "@-ms-viewport":
                    {
                        parsedText = ParseAtViewportRule(atRuleText, atrules, "-ms-");
                        break;
                    }
                case "@-webkit-viewport":
                    {
                        parsedText = ParseAtViewportRule(atRuleText, atrules, "-webkit-");
                        break;
                    }
            }
            return parsedText;
        }

        private int FindEndOfConditinonalGroupRule(int startIndex, string css_text)
        {
            int endPoint = 0;
            bool isReached = true;
            var remainingText = css_text.Substring(startIndex);
            int countOfNormalCurlyBraces = 0;
            int countOfInverseCurlyBraces = 0;
            for (int i = 0; i < remainingText.Length && isReached; i++ )
            {
                if (remainingText[i] == '{') countOfNormalCurlyBraces++;
                if (remainingText[i] == '}') countOfInverseCurlyBraces++;
                if (countOfInverseCurlyBraces != 0 && countOfNormalCurlyBraces != 0)
                {
                    if (countOfNormalCurlyBraces == countOfInverseCurlyBraces)
                    {
                        endPoint = startIndex + i;
                        isReached = false;
                    }
                }
            }
            return endPoint;
        }

        private string ParseAtCharsetRule(string css_text, List<AtRule> atrules)
        {
            int i = 0;
            int j = 0;
            while ((i = css_text.IndexOf("@charset", i)) != -1)
            {
                j = css_text.IndexOf(";", i);
                var charsetRule_Text = css_text.Substring(i, (j - i + 1));
                var charsetRule = new AtCharsetRule();
                var charsetRule_TrimmedText = charsetRule_Text.Substring(0, charsetRule_Text.Length - 1);
                charsetRule.Charset = charsetRule_TrimmedText.Split(' ')[1].Trim();
                atrules.Add(charsetRule);

                css_text = css_text.Replace(charsetRule_Text, "");
                i = 0; j = 0;
            }
            return css_text;
        }
        private string ParseAtImportRule(string css_text, List<AtRule> atrules)
        {
            int i = 0;
            int j = 0;
            while ((i = css_text.IndexOf("@import", i)) != -1)
            {
                j = css_text.IndexOf(";", i);
                var importRule_Text = css_text.Substring(i, (j - i + 1));

                var importRule = new AtImportRule();
                var importRule_TrimmedText = importRule_Text.Substring(0, importRule_Text.Length - 1);
                if (importRule_TrimmedText.Contains(" "))
                {
                    importRule.Url = importRule_TrimmedText.Split(' ')[1].Trim();
                    if (importRule_TrimmedText.Split(' ').Count() > 2)
                    {
                        importRule.ListOfMediaQueries = importRule_TrimmedText.Substring(importRule_TrimmedText.IndexOf(importRule.Url) + importRule.Url.Length + 1).Trim();
                    }
                }
                else importRule.Url = importRule_TrimmedText.Substring("@import".Length - 1);
                
                atrules.Add(importRule);


                css_text = css_text.Replace(importRule_Text, "");
                i = 0; j = 0;
            }
            return css_text;
        }
        private string ParseAtNamespaceRule(string css_text, List<AtRule> atrules)
        {
            int i = 0;
            int j = 0;
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
                atrules.Add(namespaceRule);

                css_text = css_text.Replace(namespaceRule_Text, "");
                i = 0; j = 0;
            }
            return css_text;
        }
        private string ParseAtFont_FaceRule(string css_text, List<AtRule> atrules)
        {
            int i = 0;
            var j = css_text.IndexOf("}", i);
            var font_faceRule_Text = css_text.Substring(i, (j - i + 1));

            var font_faceRule = new AtFont_FaceRule();
            var font_faceRule_TrimmedText = font_faceRule_Text.Substring(0, font_faceRule_Text.Length - 1);
            List<string> declerations = font_faceRule_TrimmedText.Split('{')[1].Split(';').ToList();
            for (i = 0; i < declerations.Count; i++)
            {
                var decleration = declerations[i].Trim();
                if (decleration != "")
                {
                    if (decleration.Contains("url"))
                    {
                        if (decleration.Count(c => c == '(') != decleration.Count(c => c == ')'))
                        {
                            decleration += ";" + declerations[i + 1];
                            i++;
                            decleration = decleration.Trim();
                        }
                    }
                    string[] PropertyAndValue = decleration.Split(":".ToCharArray(), 2);
                    var property = new Property(PropertyAndValue[0].Trim());
                    var value = new Value(PropertyAndValue[1].Trim());
                    var dec = new Decleration(property, value);
                    font_faceRule.Declerations.Add(dec);
                }
            }
            atrules.Add(font_faceRule);


            css_text = css_text.Replace(font_faceRule_Text, "");
            i = 0; j = 0;
            return css_text;
        }
        private string ParseAtPageRule(string css_text, List<AtRule> atrules)
        {
            int i = 0;
            var j = css_text.IndexOf("}", i);
            var pageRule_Text = css_text.Substring(i, (j - i + 1));
            var pageRule = new AtPageRule();
            var pageRule_TrimmedText = pageRule_Text.Substring(0, pageRule_Text.Length - 1);
            if (pageRule_TrimmedText.Split('{')[0].TrimEnd().Length > "@page".Length)
            {
                pageRule.PseudoClass = pageRule_TrimmedText.Split('{')[0].Substring("@page".Length).Trim();
            }
            else pageRule.PseudoClass = "";

            List<string> declerations = pageRule_TrimmedText.Split('{')[1].Split(';').ToList();
            foreach (string decleration_raw in declerations)
            {
                var decleration = decleration_raw.Trim();
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
                    pageRule.Declerations.Add(dec);
                }

            }
            atrules.Add(pageRule);

            css_text = css_text.Replace(pageRule_Text, "");
            i = 0; j = 0;
            return css_text;
        }
        private string ParseAtViewportRule(string css_text, List<AtRule> atrules, string browserPrefix)
        {
            int i = 0;
            var j = css_text.IndexOf("}", i);
            var viewportRule_Text = css_text.Substring(i, (j - i + 1));
            var viewportRule = new AtViewportRule(browserPrefix);
            var viewportRule_TrimmedText = viewportRule_Text.Substring(0, viewportRule_Text.Length - 1);

            List<string> declerations = viewportRule_TrimmedText.Split('{')[1].Split(';').ToList();
            foreach (string decleration_raw in declerations)
            {
                var decleration = decleration_raw.Trim();
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
                    viewportRule.Declerations.Add(dec);
                }

            }
            atrules.Add(viewportRule);

            css_text = css_text.Replace(viewportRule_Text, "");
            i = 0; j = 0;
            return css_text;
        }
        private string ParseAtMediaRule(string css_text, List<AtRule> atrules)
        {
            var endPoint = FindEndOfConditinonalGroupRule(0, css_text);
            var formerEnd = css_text.Substring(endPoint + 1);
            var mediaRule = new AtMediaRule();
            var parsedText = ParseAtRules(css_text.Substring("@media".Length, endPoint - "@media".Length + 1), mediaRule.MediaSpecificAtrules);
            css_text = css_text.Substring(0, "@media".Length) + parsedText + formerEnd;
            var mediaRule_Text = css_text.Substring(0, "@media".Length) + parsedText;

            var mediaRule_TrimmedText = mediaRule_Text.Substring(0, mediaRule_Text.Length - 1);
            mediaRule.MediaQueries = mediaRule_TrimmedText.Split('{')[0].Substring("@media".Length + 1);
            ParseRuleSets(mediaRule_TrimmedText.Substring(mediaRule_TrimmedText.IndexOf("{", 0) + 1), mediaRule.MediaSpecificRulesets);
            MergeRulesets(mediaRule.MediaSpecificRulesets);
            atrules.Add(mediaRule);

            css_text = css_text.Replace(mediaRule_Text, "");
            
            return css_text;
        }
        private string ParseAtSupportsRule(string css_text, List<AtRule> atrules)
        {
            var endPoint = FindEndOfConditinonalGroupRule(0, css_text);
            var formerEnd = css_text.Substring(endPoint + 1);
            var supportsRule = new AtSupportsRule();
            var parsedText = ParseAtRules(css_text.Substring("@supports".Length, endPoint - "@supports".Length + 1), supportsRule.SupportSpecificAtrules);
            css_text = css_text.Substring(0, "@supports".Length) + parsedText + formerEnd;
            var supportsRule_Text = css_text.Substring(0, "@supports".Length) + parsedText;

            var supportsRule_TrimmedText = supportsRule_Text.Substring(0, supportsRule_Text.Length - 1);
            supportsRule.Conditions = supportsRule_TrimmedText.Split('{')[0].Substring("@supports".Length + 1);
            ParseRuleSets(supportsRule_TrimmedText.Substring(supportsRule_TrimmedText.IndexOf("{", 0) + 1), supportsRule.SupportSpecificRulesets);
            MergeRulesets(supportsRule.SupportSpecificRulesets);
            atrules.Add(supportsRule);

            css_text = css_text.Replace(supportsRule_Text, "");
            return css_text;
        }
        private string ParseAtDocumentRule(string css_text, List<AtRule> atrules, string browserPrefix)
        {
            var endPoint = FindEndOfConditinonalGroupRule(0, css_text);
            var formerEnd = css_text.Substring(endPoint + 1);
            var documentRule = new AtDocumentRule(browserPrefix);
            var parsedText = ParseAtRules(css_text.Substring( ("@" + browserPrefix + "document").Length, endPoint - ("@" + browserPrefix + "document").Length + 1), documentRule.DocumentSpecificAtrules);
            css_text = css_text.Substring(0, ("@" + browserPrefix + "document").Length) + parsedText + formerEnd;
            var documentRule_Text = css_text.Substring(0, ("@" + browserPrefix + "document").Length) + parsedText;

            var documentRule_TrimmedText = documentRule_Text.Substring(0, documentRule_Text.Length - 1);
            documentRule.Identifier = documentRule_TrimmedText.Split('{')[0].Substring(("@" + browserPrefix + "document").Length + 1);
            ParseRuleSets(documentRule_TrimmedText.Substring(documentRule_TrimmedText.IndexOf("{", 0) + 1), documentRule.DocumentSpecificRulesets);
            MergeRulesets(documentRule.DocumentSpecificRulesets);
            atrules.Add(documentRule);

            css_text = css_text.Replace(documentRule_Text, "");
            return css_text;
        }
        private string ParseAtKeyframesRule(string css_text, List<AtRule> atrules, string browserPrefix)
        {
            int i = 0;
            var endPoint = FindEndOfConditinonalGroupRule(i, css_text);
            var keyframesRule_Text = css_text.Substring(i, (endPoint - i + 1));

            var keyframesRule = new AtKeyframesRule(browserPrefix);
            var keyframesRule_TrimmedText = keyframesRule_Text.Substring(0, keyframesRule_Text.Length - 1);
            keyframesRule.Identifier = keyframesRule_TrimmedText.Split('{')[0].Substring(("@" + browserPrefix + "keyframes").Length + 1);
            ParseRuleSets(keyframesRule_TrimmedText.Substring(keyframesRule_TrimmedText.IndexOf("{", 0) + 1), keyframesRule.Rulesets);
            //MergeRulesets(keyframesRule.Rulesets);
            atrules.Add(keyframesRule);

            css_text = css_text.Replace(keyframesRule_Text, "");
            return css_text;
        }

        public string getTextfromFile(string filename)
        {
            string rawText = File.ReadAllText(filename);
            return rawText;
        }

    }
}
