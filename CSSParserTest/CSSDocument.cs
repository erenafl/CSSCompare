﻿using System;
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
        //public List<Selector> selectors { get; private set; }
        public List<Ruleset> rulesets { get; private set; }
        public List<AtRule> atrules { get; private set; }
        public CSSDocument()
        {
            //selectors = new List<Selector>();
            rulesets = new List<Ruleset>();
            atrules = new List<AtRule>();
        }
        /*
        public void AddSelector(Selector s)
        {
            selectors.Add(s);
        }
         */
        public void AddRuleset(Ruleset rule)
        {
            rulesets.Add(rule);
        }
        public void AddAtRule(AtRule atrule)
        {
            atrules.Add(atrule);
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
            foreach (Ruleset rule in rulesets)
            {
                XMLtext += "<" + rule.selector.value + ">\n";
                foreach (Decleration dec in rule.declerations)
                {
                    XMLtext += "     <" + dec.property.value + ">\n";
                    XMLtext += "          " + dec.value.value + "\n";
                    XMLtext += "     </" + dec.property.value + ">\n";
                }
                XMLtext += "</" + rule.selector.value + ">\n";

            }
            return XMLtext;
        }
    }
}
