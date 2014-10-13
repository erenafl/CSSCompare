using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public class Value
    {
        public Value() { }
        public Value(string _value) 
        {
            value = _value;
        }
        public string value{get; private set;}
    }
}
