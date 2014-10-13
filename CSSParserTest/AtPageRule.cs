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
        public override void OutAsString()
        {

        }
    }
}
