using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Data
{
    public class Symbol : BaseData<string>
    {
        public override IElement Copy()
        {
            return this;
        }

        public override void OnRecieveChildFromParse(IElement element)
        {
            throw new NotImplementedException();
        }
    }
}
