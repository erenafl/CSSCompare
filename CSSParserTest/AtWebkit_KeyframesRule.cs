using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{

    public class AtWebkit_KeyframesRule : AtRule
    {
        public List<Ruleset> Rulesets { get; set; }
        public string Identifier { get; set; }
        public AtWebkit_KeyframesRule() 
        {
            RuleType = AtRuleType.Webkit_Keyframes;
            Rulesets = new List<Ruleset>();
        }
        public override void OutAsString()
        {

        }
    }
}
