using LEWD.src.Elements.Data;
using LEWD.src.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Action.List
{
    public class Len : BaseAction
    {
        public const string Symbol = "len";

        protected override string[] Signature => new[] { "alist" };

        public override IElement Action(ArgumentContainer Args)
        {
            var p = Args.GetVisitedArgumentAs<Collection>("alist");
            return new Number().Initialize(p.GetInnerValues().Count);
        }
    }
}
