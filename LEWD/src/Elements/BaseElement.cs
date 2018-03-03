using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements
{
    public abstract class BaseElement : IElement
    {
        public StaticScope Scope { get; set; }

        public abstract IElement Copy();

        public virtual string Repr()
        {
            return GetType().Name;
        }

        public virtual void OnRecieveChildFromParse(IElement element) { }

        public virtual bool Compare(IElement other)
        {
            return other == this;
        }
    }
}
