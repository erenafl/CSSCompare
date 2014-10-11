using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public class Selector
    {
        //public List<Property> properties;
        //public string tag;
        public string value { get; private set; }
        public List<Decleration> declerations { get; private set; }

        public Selector(string val)
        {
            //properties = new List<Property>();
            declerations = new List<Decleration>();
            value = val;
        }
        /*
        public void addProperty(Property p)
        {
            properties.Add(p);
        }
         */
        public void AddDecleration(Decleration dec)
        {
            declerations.Add(dec);
        }
        /*
        public string getTag()
        {
            return tag;
        }
        public void setTag(string _tag)
        {
            tag = _tag;
        }
         */

    }
}
