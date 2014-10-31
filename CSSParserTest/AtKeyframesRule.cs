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
        public string BrowserPrefix { get; private set; }
        public AtKeyframesRule(string browserPrefix) 
        {
            RuleType = AtRuleType.Keyframes;
            Rulesets = new List<Ruleset>();
            BrowserPrefix = browserPrefix;
        }
        public override string OutAsString()
        {
            var XMLtext = "<" + "@" + BrowserPrefix + "keyframes" + Identifier + ">\n";
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
            XMLtext += "</" + "@" + BrowserPrefix + "keyframes" + Identifier + ">\n";
            return XMLtext;
        }
    }
}
