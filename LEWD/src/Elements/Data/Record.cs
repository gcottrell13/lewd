using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Data
{
    public class Record : BaseData<List<RecordEntry>>
    {
        public override IElement Copy()
        {
            throw new NotImplementedException();
        }

        public override void OnRecieveChildFromParse(IElement element)
        {
            throw new NotImplementedException();
        }
    }
}
