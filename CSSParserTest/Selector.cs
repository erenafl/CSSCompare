﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public class Selector
    {
        public string value { get; private set; }
        public List<Decleration> declerations { get; private set; }

        public Selector(string val)
        {
            declerations = new List<Decleration>();
            value = val;
        }
        public void AddDecleration(Decleration dec)
        {
            declerations.Add(dec);
        }

    }
}
