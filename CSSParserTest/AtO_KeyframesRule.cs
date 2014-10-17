using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public class AtO_KeyframesRule : AtRule
    {
        public List<Ruleset> Rulesets { get; set; }
        public string Identifier { get; set; }
        public AtO_KeyframesRule()
        {
            RuleType = AtRuleType.O_Keyframes;
            Rulesets = new List<Ruleset>();
        }
        public override string OutAsString()
        {
            var XMLtext = "<" + "@-o-keyframes " + Identifier + ">\n";
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
            XMLtext += "</" + "@-o-keyframes " + Identifier + ">\n";
            return XMLtext;
        }
    }
}
