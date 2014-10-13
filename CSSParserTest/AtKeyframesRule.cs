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
        public override void OutAsString()
        {

        }
    }
}
