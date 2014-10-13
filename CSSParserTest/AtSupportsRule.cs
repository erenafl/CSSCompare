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
        public AtSupportsRule()
        {
            RuleType = AtRuleType.Supports;
            SupportSpecificRulesets = new List<Ruleset>();
        }
        public override void OutAsString()
        {

        }
    }
}
