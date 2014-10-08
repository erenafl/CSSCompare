using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;

namespace CSSParser
{
    public class CSSDocument
    {
        public List<Selector> selectors;
        public CSSDocument()
        {
            selectors = new List<Selector>();
        }
        public void addSelector(Selector s)
        {
            selectors.Add(s);
        }
        public void writetoXML(string filename)
        {
            var sr = new StreamWriter(filename, false, System.Text.Encoding.UTF8);
            foreach (Selector s in selectors)
            {
                sr.WriteLine("<" + s.getTag() + ">");
                foreach (Property p in s.properties)
                {
                    sr.WriteLine("     <" + p.getTag() + ">");
                    sr.WriteLine("          " + p.getValue());
                    sr.WriteLine("     </" + p.getTag() + ">");
                }
                sr.WriteLine("</" + s.tag + ">");

            }
            sr.Close();
        }

        public string generateXML()
        {
            string XMLtext=null;
            foreach (Selector s in selectors)
            {
                XMLtext += "<" + s.getTag() + ">\n";
                foreach (Property p in s.properties)
                {
                    XMLtext += "     <" + p.getTag() + ">\n";
                    XMLtext += "          " + p.getValue() + "\n";
                    XMLtext += "     </" + p.getTag() + ">\n";
                }
                XMLtext += "</" + s.tag + ">\n";

            }
            return XMLtext;
        }
    }
}
