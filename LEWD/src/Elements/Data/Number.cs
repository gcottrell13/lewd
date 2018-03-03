using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Data
{
    class Number : BaseData<double>
    {
        public override IElement Copy()
        {
            return this;
        }

        public override string Repr()
        {
            return Value.ToString();
        }

        public override bool Compare(IElement other)
        {
            if (other is Number n)
            {
                return n.Value == Value;
            }
            return false;
        }
    }
}
