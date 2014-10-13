using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public class AtImportRule : AtRule
    {
        public AtImportRule()
        {
            RuleType = AtRuleType.Import;
        }
        public string Url { get; set; }
        public string ListOfMediaQueries { get; set; }
        public override string OutAsString()
        {
            var XMLtext = "<" + "@import " + Url + ListOfMediaQueries + ">\n";
            XMLtext += "</" + "@import " + Url + ListOfMediaQueries + ">\n";
            return XMLtext;
        }
    }
}
