using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public class AtFont_FaceRule : AtRule
    {
        public List<Decleration> Declerations { get; set; }
        public AtFont_FaceRule()
        {
            RuleType = AtRuleType.Font_face;
            Declerations = new List<Decleration>();
        }
        public override string OutAsString()
        {
            var XMLtext = "<" + "@font-face " + ">\n";
            foreach (Decleration dec in Declerations)
            {
                XMLtext += "     <" + dec.property.value + ">\n";
                XMLtext += "          " + dec.value.value + "\n";
                XMLtext += "     </" + dec.property.value + ">\n";
            }
            XMLtext += "</" + "@font-face " + ">\n";
            return XMLtext;
        }
    }
}
