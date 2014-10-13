using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public abstract class AtRule : IStatement
    {
        public AtRule() { }
        public AtRuleType RuleType;
        public abstract string OutAsString();

    }
}
