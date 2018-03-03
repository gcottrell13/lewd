using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Data
{
    public interface IManyData : IData
    {
        IElement DeepCopy();
        List<IElement> GetInnerValues();
        IElement CreateNewWithValues(List<IElement> values);
    }
}
