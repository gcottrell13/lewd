using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements
{
    public abstract class BaseCallable : BaseElement, ICallable
    {
        public abstract List<IElement> GetArguments();
        public abstract IElement Invoke();
    }
}
