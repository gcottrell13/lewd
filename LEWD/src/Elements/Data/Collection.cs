using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Data
{
    public class Collection : BaseData<List<IElement>>, IManyData
    {
        /// <summary>
        /// Performs a shallow copy
        /// </summary>
        /// <returns></returns>
        public override IElement Copy()
        {
            return new Collection().Initialize(Value.ToList());
        }

        public IElement CreateNewWithValues(List<IElement> values)
        {
            return new Collection().Initialize(values);
        }

        public IElement DeepCopy()
        {
            return new Collection().Initialize(Value.Select(c => c.Copy()).ToList());
        }

        public List<IElement> GetInnerValues()
        {
            return Value;
        }

        public override void OnRecieveChildFromParse(IElement element)
        {
            // Console.WriteLine($"Collection child: {element.GetType().Name}");
            Value.Add(element);
        }

        public override string Repr()
        {
            return $"[{String.Join(" ", Value.Select(c => c.Repr()))}]";
        }

        public override bool Compare(IElement other)
        {
            if (other is Collection o)
            {
                if (Value.Count != o.Value.Count)
                {
                    return false;
                }

                var enumerator = Value.GetEnumerator();
                return o.Value.All(ov =>
                {
                    enumerator.MoveNext();
                    return ov.Compare(enumerator.Current);
                });
            }
            return false;
        }
    }
}
