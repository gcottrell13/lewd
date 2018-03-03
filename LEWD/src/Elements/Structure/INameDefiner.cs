using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Structure
{
    public interface INameDefiner : IElement
    {
        /// <summary>
        /// A list of names that should be put into the parent's scope
        /// </summary>
        /// <returns></returns>
        Dictionary<string, IElement> NamesForParent();
    }
}
