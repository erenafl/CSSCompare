using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public class AtNamespaceRule : AtRule
    {
        public AtNamespaceRule()
        {
            RuleType = AtRuleType.Namespace;
        }
        public string Prefix { get; set; }
        public string Url { get; set; }
        public override string OutAsString()
        {
            var XMLtext = "<" + "@namespace " + Prefix + Url + ">\n";
            XMLtext += "</" + "@namespace " + Prefix + Url + ">\n";
            return XMLtext;

        }
    }
}
