using LEWD.src.Elements.Data;
using LEWD.src.Elements.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Action.List
{
    public class Cons : BaseAction
    {
        public static string Symbol = "cons";

        protected override string[] Signature => new[] { REST };

        public override IElement Action(ArgumentContainer Args)
        {
            var args = Args.GetVisitedRestArguments().Value;
            var output = new List<IElement>();

            foreach(var item in args)
            {
                if (item is IManyData many)
                {
                    output.AddRange(many.GetInnerValues());
                }
                else
                {
                    output.Add(item);
                }
            }
            return new Collection().Initialize(output);
        }
    }
}
