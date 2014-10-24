﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSParser
{
    public enum AtRuleType
    {
        Media,
        Font_face,
        Charset,
        Import,
        Namespace,
        Supports,
        Page,
        Keyframes,
        Webkit_Keyframes,
        Moz_Keyframes,
        //TODO: Ms_Keyframes,
        O_Keyframes,
        Document,
        Moz_Document,
        Webkit_Document,
        //TODO: Ms_Document,
        //TODO: O_Keyframes,
        Other

    }
}
