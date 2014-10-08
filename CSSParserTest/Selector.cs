using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public class Selector
    {
        public List<Property> properties;
        public string tag;
        public Selector()
        {
            properties = new List<Property>();
        }
        public void addProperty(Property p)
        {
            properties.Add(p);
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
