using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Data
{
    public class TrueFalse : BaseData<bool>
    {
        public override bool Compare(IElement other)
        {
            if (other is TrueFalse tf)
            {
                return tf.Value == Value;
            }
            return false;
        }

        public override IElement Copy()
        {
            return this;
        }

        public override string Repr()
        {
            return Value.ToString();
        }
    }
}
