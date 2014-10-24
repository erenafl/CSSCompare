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
        public AtDocumentRule()
        {
            RuleType = AtRuleType.Document;
            DocumentSpecificRulesets = new List<Ruleset>();
            DocumentSpecificAtrules = new List<AtRule>();
        }
        public override string OutAsString()
        {
            var XMLtext = "<" + "@document " + Identifier + ">\n";
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
            XMLtext += "</" + "@document " + Identifier + ">\n";
            return XMLtext;
        }
    }
}
