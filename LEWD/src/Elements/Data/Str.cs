using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Data
{
    /// <summary>
    /// Represents the LEWD "string" type
    /// </summary>
    public class Str : BaseData<string>
    {
        public override IElement Copy()
        {
            return new Str().Initialize(Value);
        }

        public override string Repr()
        {
            return Value;
        }

        public override bool Compare(IElement other)
        {
            if (other is Str s)
            {
                return s.Value == Value;
            }
            return false;
        }
    }
}
