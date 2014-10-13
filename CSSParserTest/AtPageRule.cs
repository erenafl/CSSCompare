using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public class AtPageRule : AtRule
    {
        public string PseudoClass { get; set; }
        public List<Decleration> Declerations { get; set; }
        public AtPageRule()
        {
            RuleType = AtRuleType.Page;
            Declerations = new List<Decleration>();
        }
        public override string OutAsString()
        {
            var XMLtext = "<" + "@page " + PseudoClass +  ">\n";
            foreach (Decleration dec in Declerations)
            {
                XMLtext += "     <" + dec.property.value + ">\n";
                XMLtext += "          " + dec.value.value + "\n";
                XMLtext += "     </" + dec.property.value + ">\n";
            }
            XMLtext += "</" + "@page " + PseudoClass + ">\n";
            return XMLtext;
        }
    }
}
