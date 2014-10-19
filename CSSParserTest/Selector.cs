using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public class Selector
    {
        public string value { get; private set; }

        public Selector(string val)
        {
            value = val;
        }

    }
}
