using LEWD.src.Elements.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Action.Arithmetic
{
    public class Eq : BaseAction
    {
        public static string Symbol = "eq";

        protected override string[] Signature => new[] { "first", REST };

        public override IElement Action(ArgumentContainer Args)
        {
            var first = Args.GetVisitedArgument("first");
            var rest = Args.GetVisitedRestArguments().Value;

            if (first == null || rest.Count == 0)
            {
                return new TrueFalse().Initialize(true);
            }
            
            foreach(var p in rest)
            {
                if (!p.Compare(first))
                {
                    return new TrueFalse().Initialize(false);
                }
            }
            return new TrueFalse().Initialize(true);
        }
    }
}
