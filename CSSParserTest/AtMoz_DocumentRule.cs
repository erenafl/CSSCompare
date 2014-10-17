using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public class AtMoz_DocumentRule : AtRule
    {
        public List<Ruleset> Rulesets { get; set; }
        public string Identifier { get; set; }
        public AtMoz_DocumentRule()
        {
            RuleType = AtRuleType.Moz_Document;
            Rulesets = new List<Ruleset>();
        }
        public override string OutAsString()
        {
            var XMLtext = "<" + "@-moz-document " + Identifier + ">\n";
            foreach (Ruleset rule in Rulesets)
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
            XMLtext += "</" + "@-moz-document " + Identifier + ">\n";
            return XMLtext;
        }
    }
}
