using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public class Property
    {
        public string value;
        public string tag;
        public Property()
        { }
        public string getValue()
        {
            return value;
        }
        public void setValue(string _value)
        {
            value = _value;
        }
        public string getTag()
        {
            return tag;
        }
        public void setTag(string _tag)
        {
            tag = _tag;
        }
    }
}
