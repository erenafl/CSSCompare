﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public class Property
    {
        public string value { get; set; }
        public Property(string val)
        {
            value = val;
        }
    }
}
