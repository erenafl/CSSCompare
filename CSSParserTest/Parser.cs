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
                    },RegexOptions.Singleline);

            
            string[] selectorsAndProperties = css_text.Split('}');
            foreach (string s_raw in selectorsAndProperties)
            {
                var s = s_raw.Trim();
                if (s != "")
                {
                    string[] temp2 = s.Split('{');
					if(temp2[0].Contains(",")) 
					{
						string[] temp5 = temp2[0].Split(',');
						string[] temp3 = temp2[1].Split(';');
						foreach (string s3 in temp5)
						{
							if (s3 != "")
							{
								Selector slctr = new Selector();
								slctr.setTag(s3.Trim());
								foreach (string s2_raw in temp3)
								{
									var s2 = s2_raw.Trim();
									if (s2 != "")
									{
										string[] temp4 = s2.Split(':');
										Property p = new Property();
										p.setTag(temp4[0].Trim());
										p.setValue(temp4[1].Trim());
										slctr.addProperty(p);
									}
								}
								css.addSelector(slctr);
							}

						}
					}
					else
					{
						Selector slctr = new Selector();
						slctr.setTag(temp2[0].Trim());
						string[] temp3 = temp2[1].Split(';');
						foreach (string s2_raw in temp3)
						{
							var s2 = s2_raw.Trim();
							if (s2 != "")
							{
								string[] temp4 = s2.Split(':');
								Property p = new Property();
								p.setTag(temp4[0].Trim());
								p.setValue(temp4[1].Trim());
								slctr.addProperty(p);
							}

						}
						css.addSelector(slctr);
					}
                }

            }
			_mergeSelectors();
            return css;
        }

		private void _mergeSelectors()
		{
			for(int i =0 ; i< css.selectors.Count(); i++) 
			{
				var duplicates = css.selectors.FindAll(a => a.tag == css.selectors[i].tag).Where(a => a != css.selectors[i]);
				foreach (Selector duplicate in duplicates)
				{
					foreach(Property p in duplicate.properties) 
					{
						css.selectors[i].properties.Add(p);
					}
					css.selectors.Remove(duplicate);
				}
			}
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
