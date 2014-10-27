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
                    /*
                    if (rulesets[i].declerations.FindAll(x => x.property.value == rulesets[i].declerations[j].property.value).Where(x => x != rulesets[i].declerations[j]).Count() != 0)
                    {
                        rulesets[i].declerations.Remove(rulesets[i].declerations[j]);
                    }
                    */
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


        private string ParseSpecificAtRule(string atRuleType, string atRuleText, List<AtRule> atrules, bool parseToEnd) 
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
                        parsedText = ParseAtMediaRule(atRuleText, atrules, parseToEnd);
                        break;
                    }
                case "@font-face":
                    {
                        parsedText = ParseAtFont_FaceRule(atRuleText, atrules, parseToEnd);
                        break;
                    }
                case "@page":
                    {
                        parsedText = ParseAtPageRule(atRuleText, atrules, parseToEnd);
                        break;
                    }
                case "@supports":
                    {
                        parsedText = ParseAtSupportsRule(atRuleText, atrules, parseToEnd);
                        break;
                    }
                case "@document":
                    {
                        parsedText = ParseAtDocumentRule(atRuleText, atrules, parseToEnd);
                        break;
                    }
                case "@keyframes":
                    {
                        parsedText = ParseAtKeyframesRule(atRuleText, atrules, parseToEnd);
                        break;
                    }
                case "@-moz-document":
                    {
                        parsedText = ParseAtMoz_DocumentRule(atRuleText, atrules, parseToEnd);
                        break;
                    }
                case "@-webkit-document":
                    {
                        parsedText = ParseAtWebkit_DocumentRule(atRuleText, atrules, parseToEnd);
                        break;
                    }
                case "@-o-keyframes":
                    {
                        parsedText = ParseAtO_KeyframesRule(atRuleText, atrules, parseToEnd);
                        break;
                    }
                case "@-moz-keyframes":
                    {
                        parsedText = ParseAtMoz_KeyframesRule(atRuleText, atrules, parseToEnd);
                        break;
                    }
                case "@-webkit-keyframes":
                    {
                        parsedText = ParseAtWebkit_KeyframesRule(atRuleText, atrules, parseToEnd);
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
                        endPoint = startIndex + i - 1;
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
        private string ParseAtFont_FaceRule(string css_text, List<AtRule> atrules, bool parseAll)
        {
            int i = 0;
            int j = 0;
            bool parseToEnd = true;
            while (parseToEnd && (i = css_text.IndexOf("@font-face", i)) != -1)
            {
                parseToEnd = parseAll;
                j = css_text.IndexOf("}", i);
                var font_faceRule_Text = css_text.Substring(i, (j - i + 1));

                var font_faceRule = new AtFont_FaceRule();
                var font_faceRule_TrimmedText = font_faceRule_Text.Substring(0, font_faceRule_Text.Length - 1);
                List<string> declerations = font_faceRule_TrimmedText.Split('{')[1].Split(';').ToList();
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
                        font_faceRule.Declerations.Add(dec);
                    }

                }
                atrules.Add(font_faceRule);


                css_text = css_text.Replace(font_faceRule_Text, "");
                i = 0; j = 0;
            }
            return css_text;
        }
        private string ParseAtPageRule(string css_text, List<AtRule> atrules, bool parseAll)
        {
            int i = 0;
            int j = 0;
            bool parseToEnd = true;
            while (parseToEnd && (i = css_text.IndexOf("@page", i)) != -1)
            {
                parseToEnd = parseAll;
                j = css_text.IndexOf("}", i);
                var pageRule_Text = css_text.Substring(i, (j - i + 1));
                var pageRule = new AtPageRule();
                var pageRule_TrimmedText = pageRule_Text.Substring(0, pageRule_Text.Length - 1);
                pageRule.PseudoClass = pageRule_TrimmedText.Split('{')[0].Substring("@page".Length + 1);

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
            }
            return css_text;
        }
        private string ParseAtMediaRule(string css_text, List<AtRule> atrules, bool parseAll)
        {
            int i = 0;
            int l = 0;
            int endPoint = 0;
            bool parseToEnd = true;
            while (parseToEnd && (i = css_text.IndexOf("@media", i)) != -1)
            {
                endPoint = FindEndOfConditinonalGroupRule(i, css_text);
                var mediaRule = new AtMediaRule();
                foreach (string atRuleType in AtRuleTypeExplicit.AtRuleTypeExplicitNames)
                {
                    while ((l = css_text.IndexOf(atRuleType, i + "@media".Length, endPoint - i - "@media".Length + 1)) != -1)
                    {
                        var parsedText = ParseSpecificAtRule(atRuleType, css_text.Substring(l), mediaRule.MediaSpecificAtrules, false);
                        endPoint -= css_text.Length - css_text.Substring(0, l).Length - parsedText.Length;
                        css_text = css_text.Substring(0, l) + parsedText;
                    }
                }

                parseToEnd = parseAll;
                var mediaRule_Text = css_text.Substring(i, endPoint - i + 1);

                var mediaRule_TrimmedText = mediaRule_Text.Substring(0, mediaRule_Text.Length - 1);
                mediaRule.MediaQueries = mediaRule_TrimmedText.Split('{')[0].Substring("@media".Length + 1);
                //var mediaRule_RulesetsText = ParseAtRules(mediaRule_TrimmedText.Substring(mediaRule_TrimmedText.IndexOf("{", 0) + 1), mediaRule.MediaSpecificAtrules);
                ParseRuleSets(mediaRule_TrimmedText.Substring(mediaRule_TrimmedText.IndexOf("{", 0) + 1), mediaRule.MediaSpecificRulesets);
                MergeRulesets(mediaRule.MediaSpecificRulesets);
                atrules.Add(mediaRule);

                css_text = css_text.Replace(mediaRule_Text, "");
                i = 0;
            }

            return css_text;
        }

        private string ParseAtSupportsRule(string css_text, List<AtRule> atrules, bool parseAll)
        {
            int i = 0;
            int l = 0;
            int endPoint = 0;
            bool parseToEnd = true;
            while (parseToEnd && ((i = css_text.IndexOf("@supports", i)) != -1))
            {
                endPoint = FindEndOfConditinonalGroupRule(i, css_text);
                var supportsRule = new AtSupportsRule();
                foreach (string atRuleType in AtRuleTypeExplicit.AtRuleTypeExplicitNames)
                {
                    while ((l = css_text.IndexOf(atRuleType, i + "@supports".Length, endPoint - i - "@supports".Length + 1)) != -1)
                    {
                        var parsedText = ParseSpecificAtRule(atRuleType, css_text.Substring(l), supportsRule.SupportSpecificAtrules, false);
                        endPoint -= css_text.Length - css_text.Substring(0, l).Length - parsedText.Length;
                        css_text = css_text.Substring(0, l) + parsedText;
                    }
                }

                parseToEnd = parseAll;
                var supportsRule_Text = css_text.Substring(i, endPoint - i + 1);

                var supportsRule_TrimmedText = supportsRule_Text.Substring(0, supportsRule_Text.Length - 1);
                supportsRule.Conditions = supportsRule_TrimmedText.Split('{')[0].Substring("@supports".Length + 1);
                ParseRuleSets(supportsRule_TrimmedText.Substring(supportsRule_TrimmedText.IndexOf("{", 0) + 1), supportsRule.SupportSpecificRulesets);
                MergeRulesets(supportsRule.SupportSpecificRulesets);
                atrules.Add(supportsRule);

                css_text = css_text.Replace(supportsRule_Text, "");
                i = 0; 
            }
            return css_text;
        }
        private string ParseAtDocumentRule(string css_text, List<AtRule> atrules, bool parseAll)
        {
            int i = 0;
            int l = 0;
            int endPoint = 0;
            bool parseToEnd = true;
            while (parseToEnd && (i = css_text.IndexOf("@document", i)) != -1)
            {
                endPoint = FindEndOfConditinonalGroupRule(i, css_text);
                var documentRule = new AtDocumentRule();
                foreach (string atRuleType in AtRuleTypeExplicit.AtRuleTypeExplicitNames)
                {
                    while ((l = css_text.IndexOf(atRuleType, i + "@document".Length, endPoint - i - "@document".Length + 1)) != -1)
                    {
                        var parsedText = ParseSpecificAtRule(atRuleType, css_text.Substring(l), documentRule.DocumentSpecificAtrules, false);
                        endPoint -= css_text.Length - css_text.Substring(0, l).Length - parsedText.Length;
                        css_text = css_text.Substring(0, l) + parsedText;
                    }
                }

                parseToEnd = parseAll;
                var documentRule_Text = css_text.Substring(i, endPoint - i + 1);

                var documentRule_TrimmedText = documentRule_Text.Substring(0, documentRule_Text.Length - 1);
                documentRule.Identifier = documentRule_TrimmedText.Split('{')[0].Substring("@document".Length + 1);
                ParseRuleSets(documentRule_TrimmedText.Substring(documentRule_TrimmedText.IndexOf("{", 0) + 1), documentRule.DocumentSpecificRulesets);
                MergeRulesets(documentRule.DocumentSpecificRulesets);
                atrules.Add(documentRule);

                css_text = css_text.Replace(documentRule_Text, "");
                i = 0;
            }
            return css_text;
        }
        private string ParseAtWebkit_DocumentRule(string css_text, List<AtRule> atrules, bool parseAll)
        {
            int i = 0;
            int l = 0;
            int endPoint = 0;
            bool parseToEnd = true;
            while (parseToEnd && (i = css_text.IndexOf("@-webkit-document", i)) != -1)
            {
                endPoint = FindEndOfConditinonalGroupRule(i, css_text);
                var webkit_documentRule = new AtWebkit_DocumentRule();
                foreach (string atRuleType in AtRuleTypeExplicit.AtRuleTypeExplicitNames)
                {
                    while ((l = css_text.IndexOf(atRuleType, i + "@-webkit-document".Length, endPoint - i - "@-webkit-document".Length + 1)) != -1)
                    {
                        var parsedText = ParseSpecificAtRule(atRuleType, css_text.Substring(l), webkit_documentRule.DocumentSpecificAtrules, false);
                        endPoint -= css_text.Length - css_text.Substring(0, l).Length - parsedText.Length;
                        css_text = css_text.Substring(0, l) + parsedText;
                    }
                }

                parseToEnd = parseAll;
                var webkit_documentRule_Text = css_text.Substring(i, endPoint - i + 1);


                var webkit_documentRule_TrimmedText = webkit_documentRule_Text.Substring(0, webkit_documentRule_Text.Length - 1);
                webkit_documentRule.Identifier = webkit_documentRule_TrimmedText.Split('{')[0].Substring("@-webkit-document".Length + 1);
                ParseRuleSets(webkit_documentRule_TrimmedText.Substring(webkit_documentRule_TrimmedText.IndexOf("{", 0) + 1), webkit_documentRule.DocumentSpecificRulesets);
                MergeRulesets(webkit_documentRule.DocumentSpecificRulesets);
                atrules.Add(webkit_documentRule);

                css_text = css_text.Replace(webkit_documentRule_Text, "");
                i = 0; 
            }
            return css_text;
        }
        private string ParseAtMoz_DocumentRule(string css_text, List<AtRule> atrules, bool parseAll)
        {
            int i = 0;
            int l = 0;
            int endPoint = 0;
            bool parseToEnd = true;
            while (parseToEnd && (i = css_text.IndexOf("@-moz-document", i)) != -1)
            {
                endPoint = FindEndOfConditinonalGroupRule(i, css_text);
                var moz_documentRule = new AtMoz_DocumentRule();
                foreach (string atRuleType in AtRuleTypeExplicit.AtRuleTypeExplicitNames)
                {
                    while ((l = css_text.IndexOf(atRuleType, i + "@-moz-document".Length, endPoint - i - "@-moz-document".Length + 1)) != -1)
                    {
                        var parsedText = ParseSpecificAtRule(atRuleType, css_text.Substring(l), moz_documentRule.DocumentSpecificAtrules, false);
                        endPoint -= css_text.Length - css_text.Substring(0, l).Length - parsedText.Length;
                        css_text = css_text.Substring(0, l) + parsedText;
                    }
                }

                parseToEnd = parseAll;
                var moz_documentRule_Text = css_text.Substring(i, endPoint - i + 1);


                var moz_documentRule_TrimmedText = moz_documentRule_Text.Substring(0, moz_documentRule_Text.Length - 1);
                moz_documentRule.Identifier = moz_documentRule_TrimmedText.Split('{')[0].Substring("@-moz-document".Length + 1);
                ParseRuleSets(moz_documentRule_TrimmedText.Substring(moz_documentRule_TrimmedText.IndexOf("{", 0) + 1), moz_documentRule.DocumentSpesificRulesets);
                MergeRulesets(moz_documentRule.DocumentSpesificRulesets);
                atrules.Add(moz_documentRule);

                css_text = css_text.Replace(moz_documentRule_Text, "");
                i = 0;
            }
            return css_text;
        }
        private string ParseAtKeyframesRule(string css_text, List<AtRule> atrules, bool parseAll)
        {
            int i = 0;
            int endPoint = 0;
            bool parseToEnd = true;
            while (parseToEnd && (i = css_text.IndexOf("@keyframes", i)) != -1)
            {
                endPoint = FindEndOfConditinonalGroupRule(i, css_text);
                parseToEnd = parseAll;
                var keyframesRule_Text = css_text.Substring(i, (endPoint - i + 1));

                var keyframesRule = new AtKeyframesRule();
                var keyframesRule_TrimmedText = keyframesRule_Text.Substring(0, keyframesRule_Text.Length - 1);
                keyframesRule.Identifier = keyframesRule_TrimmedText.Split('{')[0].Substring("@keyframes".Length + 1);
                ParseRuleSets(keyframesRule_TrimmedText.Substring(keyframesRule_TrimmedText.IndexOf("{", 0) + 1), keyframesRule.Rulesets);
                //MergeRulesets(keyframesRule.Rulesets);
                atrules.Add(keyframesRule);

                css_text = css_text.Replace(keyframesRule_Text, "");
                i = 0;
            }
            return css_text;
        }
        private string ParseAtO_KeyframesRule(string css_text, List<AtRule> atrules, bool parseAll)
        {
            int i = 0; 
            int endPoint = 0;
            bool parseToEnd = true;
            while (parseToEnd && (i = css_text.IndexOf("@-o-keyframes", i)) != -1)
            {
                endPoint = FindEndOfConditinonalGroupRule(i, css_text);
                parseToEnd = parseAll;
                var o_keyframesRule_Text = css_text.Substring(i, (endPoint - i + 1));

                var o_keyframesRule = new AtO_KeyframesRule();
                var o_keyframesRule_TrimmedText = o_keyframesRule_Text.Substring(0, o_keyframesRule_Text.Length - 1);
                o_keyframesRule.Identifier = o_keyframesRule_TrimmedText.Split('{')[0].Substring("@-o-keyframes".Length + 1);
                ParseRuleSets(o_keyframesRule_TrimmedText.Substring(o_keyframesRule_TrimmedText.IndexOf("{", 0) + 1), o_keyframesRule.Rulesets);
                //MergeRulesets(moz_keyframesRule.Rulesets);
                atrules.Add(o_keyframesRule);
                css_text = css_text.Replace(o_keyframesRule_Text, "");
                i = 0; 
            }
            return css_text;
        }
        private string ParseAtMoz_KeyframesRule(string css_text, List<AtRule> atrules, bool parseAll)
        {
            int i = 0;
            int endPoint = 0;
            bool parseToEnd = true;
            while (parseToEnd && (i = css_text.IndexOf("@-moz-keyframes", i)) != -1)
            {
                endPoint = FindEndOfConditinonalGroupRule(i, css_text);
                parseToEnd = parseAll;
                var moz_keyframesRule_Text = css_text.Substring(i, (endPoint - i + 1));

                var moz_keyframesRule = new AtMoz_KeyframesRule();
                var moz_keyframesRule_TrimmedText = moz_keyframesRule_Text.Substring(0, moz_keyframesRule_Text.Length - 1);
                moz_keyframesRule.Identifier = moz_keyframesRule_TrimmedText.Split('{')[0].Substring("@-moz-keyframes".Length + 1);
                ParseRuleSets(moz_keyframesRule_TrimmedText.Substring(moz_keyframesRule_TrimmedText.IndexOf("{", 0) + 1), moz_keyframesRule.Rulesets);
                //MergeRulesets(moz_keyframesRule.Rulesets);
                atrules.Add(moz_keyframesRule);
                css_text = css_text.Replace(moz_keyframesRule_Text, "");
                i = 0; 
            }
            return css_text;
        }
        private string ParseAtWebkit_KeyframesRule(string css_text, List<AtRule> atrules, bool parseAll)
        {
            int i = 0;
            int endPoint = 0;
            bool parseToEnd = true;
            while (parseToEnd && (i = css_text.IndexOf("@-webkit-keyframes", i)) != -1)
            {
                endPoint = FindEndOfConditinonalGroupRule(i, css_text);
                parseToEnd = parseAll;
                var webkit_keyframesRule_Text = css_text.Substring(i, (endPoint - i + 1));

                var webkit_keyframesRule = new AtWebkit_KeyframesRule();
                var webkit_keyframesRule_TrimmedText = webkit_keyframesRule_Text.Substring(0, webkit_keyframesRule_Text.Length - 1);
                webkit_keyframesRule.Identifier = webkit_keyframesRule_TrimmedText.Split('{')[0].Substring("@-webkit-keyframes".Length + 1);
                ParseRuleSets(webkit_keyframesRule_TrimmedText.Substring(webkit_keyframesRule_TrimmedText.IndexOf("{", 0) + 1), webkit_keyframesRule.Rulesets);
                //MergeRulesets(webkit_keyframesRule.Rulesets);
                atrules.Add(webkit_keyframesRule);
                css_text = css_text.Replace(webkit_keyframesRule_Text, "");
                i = 0;
            }
            return css_text;
        }

        

        private string ParseAtRules(string css_text, List<AtRule> atrules)
        {
            #region @Rule Test Section

            int i = 0;
            string selectedAtRuleType = null;
            List<int> unrecognized = new List<int>();
            while ( ((i = css_text.IndexOf("@")) != -1) && unrecognized.Contains(i) )
            {
                foreach (string atRuleType in AtRuleTypeExplicit.AtRuleTypeExplicitNames)
                {
                    if (css_text.IndexOf(atRuleType, i, atRuleType.Length + 1) != -1)
                    {
                        selectedAtRuleType = atRuleType;
                    }
                }
                if(selectedAtRuleType == null)
                {
                    //Unrecognized at rules
                    if ( i == 0 || ( css_text[i - 1] == '}' || css_text[i - 1] == ' ' ) )
                    {
                        css_text = css_text.Replace(css_text.Substring(i, FindEndOfConditinonalGroupRule(i, css_text) - i + 1), "");
                    }
                    //Unrecognized '@' characters(not an atrule)
                    else unrecognized.Add(i);
                }
                else 
                {
                    var parsedText = ParseSpecificAtRule(selectedAtRuleType, css_text.Substring(i), atrules, false);
                    css_text = css_text.Substring(0, i) + parsedText;
                }
                selectedAtRuleType = null;
            }
            
            return css_text;

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
