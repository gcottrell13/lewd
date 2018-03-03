using LEWD.src.Elements.Data;
using LEWD.src.Elements.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Action.List
{
    public class Tail : BaseAction
    {
        public const string Symbol = "tail";
        
        protected override string[] Signature => new[] { "alist" };

        public override IElement Action(ArgumentContainer Args)
        {
            var collection = Args.GetVisitedArgumentAs<Collection>("alist");
            return new Collection().Initialize(collection.GetInnerValues().Skip(1).ToList());
        }
    }
}
