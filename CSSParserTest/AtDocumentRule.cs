using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public class AtDocumentRule : AtRule
    {
        public List<Ruleset> DocumentSpecificRulesets { get; set; }
        public List<AtRule> DocumentSpecificAtrules { get; set; }
        public string Identifier { get; set; }
        public string BrowserPrefix { get; private set; }
        public AtDocumentRule(string browserPrefix)
        {
            RuleType = AtRuleType.Document;
            DocumentSpecificRulesets = new List<Ruleset>();
            DocumentSpecificAtrules = new List<AtRule>();
            BrowserPrefix = browserPrefix;
        }
        public override string OutAsString()
        {
            var XMLtext = "<" + "@" + BrowserPrefix + "document " + Identifier + ">\n";
            foreach (Ruleset rule in DocumentSpecificRulesets)
            {
                XMLtext += "     <" + rule.selector.value + ">\n";
                foreach (Decleration dec in rule.declerations)
                {
                    XMLtext += "          <" + dec.property.value + ">\n";
                    XMLtext += "               " + dec.value.value + "\n";
                    XMLtext += "          </" + dec.property.value + ">\n";
                }
                XMLtext += "     </" + rule.selector.value + ">\n";
            }
            XMLtext += "</" + "@" + BrowserPrefix + "document " + Identifier + ">\n";
            return XMLtext;
        }
    }
}
