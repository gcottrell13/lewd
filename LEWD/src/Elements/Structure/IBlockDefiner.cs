using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Structure
{
    public interface IBlockDefiner : IElement
    {
        StaticScope InnerScope { get; set; }
    }
}
