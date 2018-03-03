using LEWD.src.Elements.Data;
using LEWD.src.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Action.LString
{
    public class SplitStr : BaseAction
    {
        public const string Symbol = "split";

        protected override string[] Signature => new[] { "string", "splitter" };

        public override IElement Action(ArgumentContainer Args)
        {
            var str = Args.GetVisitedArgumentAs<Str>("string");
            var splitter = Args.GetVisitedArgumentAs<Str>("splitter", true);
            if (splitter != null)
            {
                if (splitter.Value != "")
                {
                    return new Collection().Initialize(str.Value.Split(splitter.Value[0]).Select(s => new Str().Initialize(s) as IElement).ToList());
                }
                else
                {
                    throw new TypeException($"{Symbol} must recieve a non-empty str as a splitter");
                }
            }
            else
            {
                return new Collection().Initialize(str.Value.Split().Select(s => new Str().Initialize(s) as IElement).ToList());
            }
        }
    }
}
