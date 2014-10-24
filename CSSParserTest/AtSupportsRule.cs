using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public class AtSupportsRule : AtRule
    {
        public string Conditions;
        public List<Ruleset> SupportSpecificRulesets { get; set; }
        public List<AtRule> SupportSpecificAtrules { get; set; }
        public AtSupportsRule()
        {
            RuleType = AtRuleType.Supports;
            SupportSpecificRulesets = new List<Ruleset>();
            SupportSpecificAtrules = new List<AtRule>();
        }
        public override string OutAsString()
        {
            var XMLtext = "<" + "@supports " + Conditions + ">\n";
            foreach (Ruleset rule in SupportSpecificRulesets)
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
            XMLtext += "</" + "@supports " + Conditions + ">\n";
            return XMLtext;
        }
    }
}
