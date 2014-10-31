using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public class AtViewportRule : AtRule
    {
        public List<Decleration> Declerations { get; set; }
        public string BrowserPrefix { get; private set; }
        public AtViewportRule(string browserPrefix)
        {
            RuleType = AtRuleType.Viewport;
            Declerations = new List<Decleration>();
            BrowserPrefix = browserPrefix;
        }
        public override string OutAsString()
        {
            var XMLtext = "<" + "@" + BrowserPrefix + "viewport" + ">\n";
            foreach (Decleration dec in Declerations)
            {
                XMLtext += "     <" + dec.property.value + ">\n";
                XMLtext += "          " + dec.value.value + "\n";
                XMLtext += "     </" + dec.property.value + ">\n";
            }
            XMLtext += "</" + "@" + BrowserPrefix + "viewport" + ">\n";
            return XMLtext;
        }
    }
}
