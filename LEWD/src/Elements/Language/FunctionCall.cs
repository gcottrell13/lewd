using LEWD.src.Elements.Action;
using LEWD.src.Elements.Data;
using LEWD.src.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Language
{
    public class FunctionCall : BaseCallable
    {
        Symbol Name;
        List<IElement> Arguments;

        public FunctionCall()
        {
            Arguments = new List<IElement>();
        }

        public override IElement Copy()
        {
            return this;
        }

        public override List<IElement> GetArguments()
        {
            return Arguments;
        }

        public override IElement Invoke()
        {
            var element = Scope.SearchForName(Name.Value);
            if (element != null && element is IAction action)
            {
                return action.OnAction(Arguments);
            }
            else
            {
                throw new NameNotFoundException(Name.Value);
            }
        }

        public override void OnRecieveChildFromParse(IElement element)
        {
            if (Name == null)
            {
                if (element is Symbol symbol)
                {
                    Name = new Symbol().Initialize(symbol.Value) as Symbol;
                }
                else
                {
                    throw new Exception();
                }
            }
            else
            {
                Arguments.Add(element);
            }
        }

        public override string Repr()
        {
            return "Function";
        }
    }
}
