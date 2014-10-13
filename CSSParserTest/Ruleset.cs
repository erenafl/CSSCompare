using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public class Ruleset : IStatement
    {
        public Ruleset() 
        {
            declerations = new List<Decleration>();
        }
        public List<Decleration> declerations { get; private set; }
        public Selector selector { get; set; }
        public void AddDecleration(Decleration dec)
        {
            declerations.Add(dec);
        }
        public void OutAsString()
        {

        }

    }
}
