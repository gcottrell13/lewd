using LEWD.src.Elements.Data;
using LEWD.src.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Action
{
    public class TimeActions
    {
        public class FromString : BaseAction
        {
            public const string Symbol = "time";
            
            protected override string[] Signature => new[] {
                "in",
            };

            public override IElement Action(ArgumentContainer Args)
            {
                var arg = Args.GetVisitedArgumentAs<Str>("in", true);
                if(arg == null)
                {
                    return new Time().Initialize(DateTime.UtcNow);
                }
                if (DateTime.TryParse(arg.Value, out DateTime result))
                {
                    return new Time().Initialize(result);
                }
                throw new TypeException("Could not create Time from provided string.");
            }
        }

    }
}
