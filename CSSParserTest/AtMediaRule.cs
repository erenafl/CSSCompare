using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public class AtMediaRule : AtRule
    {
        public AtMediaRule()
        {
            MediaSpecificRulesets = new List<Ruleset>();
            MediaSpecificAtrules = new List<AtRule>();
            RuleType = AtRuleType.Media;
        }
        public List<Ruleset> MediaSpecificRulesets{ get; set; }
        public List<AtRule> MediaSpecificAtrules { get; set; }
        public string MediaQueries;
        public void AddRuleset(Ruleset rule)
        {
            MediaSpecificRulesets.Add(rule);
        }
        public void AtRule(AtRule atRule)
        {
            MediaSpecificAtrules.Add(atRule);
        }
        public override string OutAsString()
        {
            var XMLtext = "<" + "@media " + MediaQueries +  ">\n";
            foreach (AtRule atRule in MediaSpecificAtrules)
            {
                XMLtext += atRule.OutAsString();
            }
            foreach (Ruleset rule in MediaSpecificRulesets) {
                XMLtext += "     <" + rule.selector.value + ">\n";
                foreach (Decleration dec in rule.declerations)
                {
                    XMLtext += "          <" + dec.property.value + ">\n";
                    XMLtext += "               " + dec.value.value + "\n";
                    XMLtext += "          </" + dec.property.value + ">\n";
                }
                XMLtext += "     </" + rule.selector.value + ">\n";
            }
            XMLtext += "</" + "@media " + MediaQueries + ">\n";
            return XMLtext;
        }
    }
}
