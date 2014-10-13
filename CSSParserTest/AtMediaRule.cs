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
            RuleType = AtRuleType.Media;
        }
        public List<Ruleset> MediaSpecificRulesets{ get; set; }
        public string MediaQueries;
        public void AddRuleset(Ruleset rule)
        {
            MediaSpecificRulesets.Add(rule);
        }
        public override void OutAsString()
        {

        }
    }
}
