using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Data
{
    public abstract class BaseData<TObject> : BaseElement, IData<TObject>
    {
        public Type ObjectType => typeof(TObject);

        TObject val;

        public TObject Value => val;

        public object ObjValue => val;

        protected bool init = false;

        public IData Initialize(TObject value)
        {
            if (init == false)
            {
                val = value;
                init = true;
                return this;
            }
            throw new Exception("Cannot re-initialize an element!");
        }
    }
}
