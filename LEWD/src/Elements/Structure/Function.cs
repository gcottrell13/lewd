using LEWD.src.Elements.Action;
using LEWD.src.Elements.Data;
using LEWD.src.Elements.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Structure
{
    class Function : BaseAction, IBlockDefiner
    {
        public StaticScope InnerScope { get; set; }

        protected override string[] Signature => new[] { REST };

        List<Parameter> ParameterList;
        IElement Body;

        public Function()
        {
            ParameterList = new List<Parameter>();
        }

        public Dictionary<string, IElement> OnEnterBlock(List<IElement> Params)
        {
            var items = new Dictionary<string, IElement>();
            var paramsIterator = Params.GetEnumerator();

            foreach(var param in ParameterList)
            {
                var gotInput = paramsIterator.MoveNext();
                if (gotInput)
                {
                    var input = paramsIterator.Current;
                    items[param.Value] = input;
                }
                else
                {
                    throw new Exception("Not enough args");
                }
            }
            return items;
        }

        public override void OnRecieveChildFromParse(IElement element)
        {
            if (element is Parameter p)
            {
                ParameterList.Add(p);
            }
            else if (Body == null)
            {
                Body = element;
            }
            else
            {
                throw new Exception("Cannot have multiple bodies!");
            }
        }

        public override IElement Action(ArgumentContainer Args)
        {
            var args = Args.GetVisitedRestArguments();
            InnerScope.NewDynamicScope();
            InnerScope.AddNamesToDynamicScope(OnEnterBlock(args.Value));
            var bodyResult = Interpreter.VisitAndGetResult(Body);
            InnerScope.PopDynamicScope();
            return bodyResult;
        }

        public override string Repr()
        {
            return $"{{({String.Join(",", ParameterList.Select(p => p.Value))})}}";
        }
    }
}
