using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Action
{
    public interface IAction : IElement
    {
        IElement OnAction(List<IElement> Arguments);
    }
}
