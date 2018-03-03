using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Data
{
    public class Time : BaseData<DateTime>
    {
        public override IElement Copy()
        {
            return this;
        }

        public override string Repr()
        {
            return Value.ToShortDateString();
        }
    }
}
