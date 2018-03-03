﻿using LEWD.src.Elements.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Structure
{
    public class Noop : BaseElement
    {
        public const string Symbol = "None";

        public override IElement Copy()
        {
            return this;
        }

        public override string Repr()
        {
            return "None";
        }
    }
}
