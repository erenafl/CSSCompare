using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public class AtKeyframesRule : AtRule
    {
        public List<Ruleset> Rulesets { get; set; }
        public string Identifier { get; set; }
        public AtKeyframesRule() 
        {
            RuleType = AtRuleType.Keyframes;
            Rulesets = new List<Ruleset>();
        }
        public override string OutAsString()
        {
            var XMLtext = "<" + "@keyframes " + Identifier + ">\n";
            foreach (Ruleset rule in Rulesets)
            {
                foreach (Decleration dec in rule.declerations)
                {
                    XMLtext += "     <" + dec.property.value + ">\n";
                    XMLtext += "          " + dec.value.value + "\n";
                    XMLtext += "     </" + dec.property.value + ">\n";
                }
            }
            XMLtext += "</" + "@keyframes " + Identifier + ">\n";
            return XMLtext;
        }
    }
}
