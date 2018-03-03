using LEWD.src.Elements.Data;
using LEWD.src.Elements.Structure;
using LEWD.src.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Action
{
    public class Add : BaseAction
    {
        public const string Symbol = "+";

        protected override string[] Signature => new[] { REST };

        public override IElement Action(ArgumentContainer Args)
        {
            var args = Args.GetVisitedRestArguments();

            double sum = 0;

            foreach(var p in args.Value)
            {
                if (p is Number num)
                {
                    sum += num.Value;
                }
                else
                {
                    throw new TypeException($"'+' only accepts {nameof(Number)}, not {p.GetType().Name}");
                }
            }
            return new Number().Initialize(sum);
        }
    }
}
