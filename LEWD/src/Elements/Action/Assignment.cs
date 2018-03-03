using LEWD.src.Elements.Data;
using LEWD.src.Elements.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Action
{
    public class Assignment : BaseElement, INameDefiner
    {
        public Symbol Name;
        public IElement Value;

        public override IElement Copy()
        {
            return this;
        }

        public Dictionary<string, IElement> NamesForParent()
        {
            return new Dictionary<string, IElement>
            {
                { Name.Value, Value },
            };
        }

        public override void OnRecieveChildFromParse(IElement element)
        {
            if (Name == null && element is Symbol symbol)
            {
                Name = symbol;
            }
            else
            {
                Value = element;
            }
        }
    }
}
