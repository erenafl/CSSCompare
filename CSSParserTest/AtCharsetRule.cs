using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public class AtCharsetRule : AtRule
    {
        public AtCharsetRule()
        {
            RuleType = AtRuleType.Charset;
        }
        public string Charset { get; set; }
        public override void OutAsString()
        {

        }
    }
}
