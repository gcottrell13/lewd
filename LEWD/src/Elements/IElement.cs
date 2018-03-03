using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements
{
    public interface IElement
    {
        /// <summary>
        /// Copies an element
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        IElement Copy();

        /// <summary>
        /// Returns the scope that the object lives under
        /// </summary>
        StaticScope Scope { get; set; }

        bool Compare(IElement other);

        /// <summary>
        /// Return a string representation of this object
        /// </summary>
        /// <returns></returns>
        string Repr();

        void OnRecieveChildFromParse(IElement element);
    }
}
