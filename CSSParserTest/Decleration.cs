using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public class Decleration
    {
        public Decleration() { }
        public Decleration(Property p, Value v) 
        {
            property = p;
            value = v;
        }
        public Property property { get; private set; }
        public Value value { get; private set; }
    }
}
