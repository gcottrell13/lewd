using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Structure
{
    public class Document : BaseElement, IBlockDefiner
    {
        public StaticScope InnerScope { get; set; }
        public List<IElement> Children;

        public Document()
        {
            Children = new List<IElement>();
        }

        public override IElement Copy()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, IElement> OnEnterBlock()
        {
            throw new NotImplementedException();
        }

        public override void OnRecieveChildFromParse(IElement element)
        {
            Children.Add(element);
        }
    }
}
