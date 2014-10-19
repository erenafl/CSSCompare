using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public static class AtRuleTypeExplicit
    {
        public static List<string> AtRuleTypeExplicitNames = new List<string> {
            "@media",
            "@font-face", 
            "@page",
            "@supports", 
            "@keyframes", 
            "@-moz-keyframes", 
            "@-o-keyframes", 
            "@-webkit-keyframes", 
            "@document", 
            "@-moz-document", 
            "@-webkit-document" 
            };
    }
}
