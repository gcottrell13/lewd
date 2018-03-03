using LEWD.src.Elements.Data;
using LEWD.src.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Action.LString
{
    public class Join : BaseAction
    {
        public const string Symbol = "join";

        protected override string[] Signature => new[] { "separator", "alist" };

        public override IElement Action(ArgumentContainer Args)
        {
            var joining = Args.GetVisitedArgumentAs<Str>("separator");
            var list = Args.GetVisitedArgumentAs<Collection>("alist");
            var items = list.Value.Select(item => item.Repr());
            return new Str().Initialize(String.Join(joining.Value, items));
        }
    }
}
