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
        public override void OutAsString()
        {

        }
    }
}
