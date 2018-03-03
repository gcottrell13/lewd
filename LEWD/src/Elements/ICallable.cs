using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements
{
    public interface ICallable : IElement
    {
        /// <summary>
        /// Calls an element (if possible)
        /// </summary>
        /// <returns></returns>
        IElement Invoke();

        List<IElement> GetArguments();
    }
}
