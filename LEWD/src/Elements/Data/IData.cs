using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Data
{
    public interface IData : IElement
    {
        object ObjValue { get; }
    }

    public interface IData<TObject> : IData
    {
        /// <summary>
        /// Initializes the element with a value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        IData Initialize(TObject value);

        TObject Value { get; }
    }
}
