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
        public override string OutAsString()
        {
            var XMLtext = "<" + "@charset " + Charset +  ">\n";
            XMLtext += "</" + "@charset " + Charset + ">\n";
            return XMLtext;
        }
    }
}
