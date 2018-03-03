using LEWD.src.Elements;
using LEWD.src.Elements.Action;
using LEWD.src.Elements.Action.Arithmetic;
using LEWD.src.Elements.Action.List;
using LEWD.src.Elements.Action.LString;
using LEWD.src.Elements.Data;
using LEWD.src.Elements.Language;
using LEWD.src.Elements.Structure;
using LEWD.src.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src
{
    public class Interpreter
    {
        public void Run(Document document)
        {
            IO.RescanFiles();

            document.Scope.AddNames(GlobalNames());
            try
            {
                foreach (var child in document.Children)
                {
                    var result = VisitAndGetResult(child);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static IElement VisitAndGetResult(IElement element)
        {
            if (element == null)
            {
                throw new Exception("Null Elment");
            }

            if (element is IData data)
            {
                if (data is Symbol s)
                {
                    var e = s.Scope.SearchForName(s.Value);
                    if (e != null)
                    {
                        return VisitAndGetResult(e);
                    }
                    else
                    {
                        throw new NameNotFoundException(s.Value);
                    }
                }
                else if (data is IManyData many)
                {
                    var items = many.GetInnerValues().Select(arg => VisitAndGetResult(arg)).ToList();
                    return many.CreateNewWithValues(items);
                }
                else
                {
                    return data;
                }
            }

            if (element is ICallable callable)
            {
                return callable.Invoke();
            }
            
            if (element is INameDefiner names)
            {
                names.Scope.AddNames(names.NamesForParent());
            }

            return element;
        }

        public static List<IElement> VisitAll(List<IElement> elements)
        {
            return elements.Select(e => VisitAndGetResult(e)).ToList();
        }

        static Dictionary<string, IElement> GlobalNames()
        {
            return new Dictionary<string, IElement>
            {
                { IO.Print.Symbol, new IO.Print() },
                { IO.GetInput.Symbol, new IO.GetInput() },
                { IO.OpenFile.Symbol, new IO.OpenFile() },
                { IO.PWD.Symbol, new IO.PWD() },
                { IO.DIR.Symbol, new IO.DIR() },
                { IO.CD.Symbol, new IO.CD() },

                { Noop.Symbol, new Noop() },
                { Head.Symbol, new Head() },
                { Tail.Symbol, new Tail() },
                { Cons.Symbol, new Cons() },
                { Condition.Symbol, new Condition() },
                { Eq.Symbol, new Eq() },
                { Add.Symbol, new Add() },
                { Len.Symbol, new Len() },
                { SplitStr.Symbol, new SplitStr() },
                { Join.Symbol, new Join() },
            };
        }
    }
}
