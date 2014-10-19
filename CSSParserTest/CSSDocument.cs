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
        public List<Ruleset> rulesets { get; set; }
        public List<AtRule> atrules { get; set; }
        public CSSDocument()
        {
            rulesets = new List<Ruleset>();
            atrules = new List<AtRule>();
        }
        public void writetoXML(string filename)
        {
            var sr = new StreamWriter(filename, false, System.Text.Encoding.UTF8);
            foreach (Ruleset rule in rulesets)
            {
                sr.WriteLine("<" + rule.selector.value + ">");
                foreach (Decleration dec in rule.declerations)
                {
                    sr.WriteLine("     <" + dec.property.value + ">");
                    sr.WriteLine("          " + dec.value.value);
                    sr.WriteLine("     </" + dec.property.value + ">");
                }
                sr.WriteLine("</" + rule.selector.value + ">");

            }
            sr.Close();
        }

        public string generateXML()
        {
            string XMLtext=null;
            foreach (AtRule atrule in atrules)
            {
                XMLtext += atrule.OutAsString();
            }
            foreach (Ruleset rule in rulesets)
            {
                XMLtext += rule.OutAsString();
            }
            return XMLtext;
        }
    }
}
