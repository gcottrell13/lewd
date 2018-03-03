using LEWD.src.Elements.Data;
using LEWD.src.Elements.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Action.List
{
    public class Head : BaseAction
    {
        public const string Symbol = "head";

        protected override string[] Signature => new[] { "alist" };

        public override IElement Action(ArgumentContainer Args)
        {
            var collection = Args.GetVisitedArgumentAs<Collection>("alist");
            if (collection != null)
            {
                var first = collection.GetInnerValues().FirstOrDefault();
                if (first != null) return first;
            }
            return new Noop();
        }
    }
}
