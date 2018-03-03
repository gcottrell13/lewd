using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Data
{
    public class RecordEntry : BaseElement
    {
        public string Key;
        public IElement Value;
        
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
