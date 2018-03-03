using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using LEWD.src.Elements;
using LEWD.src.Elements.Action;
using LEWD.src.Elements.Data;
using LEWD.src.Elements.Language;
using LEWD.src.Elements.Structure;
using static lewdParser;

namespace LEWD.src.language
{
    public class LEWDListener : lewdBaseListener
    {
        Stack<StaticScope> ScopeStack;
        Stack<IElement> ElementStack;
        IElement ParentOfCurrent;

        public Document document;

        public LEWDListener() : base()
        {
            ScopeStack = new Stack<StaticScope>();
            ElementStack = new Stack<IElement>();

            // add a global scope
            ScopeStack.Push(new StaticScope());
        }

        void print(string str)
        {
            Console.WriteLine(str);
        }

        void AddNamesToCurrentScope(Dictionary<string, IElement> elements)
        {
            ScopeStack.Peek().AddNames(elements);
        }

        void NewScopeFrame()
        {
            var scope = new StaticScope
            {
                Parent = ScopeStack.Peek(),
            };
            ScopeStack.Push(scope);
        }

        TElement CreateElementOnStack<TElement>() where TElement : IElement, new()
        {
            var element = new TElement
            {
                Scope = ScopeStack.Peek()
            };
            if (ElementStack.Count > 0)
                ParentOfCurrent = ElementStack.Peek();
            ElementStack.Push(element);

            if (element is IBlockDefiner block)
            {
                NewScopeFrame();
                block.InnerScope = ScopeStack.Peek();
            }

            return element;
        }
        void GiveChildToParent(IElement element)
        {
            if (ParentOfCurrent != null)
            {
                ParentOfCurrent.OnRecieveChildFromParse(element);
            }
        }

        void PopElementStack()
        {
            ElementStack.Pop();
        }

        public override void EnterDocument([NotNull] DocumentContext context)
        {
            var e = CreateElementOnStack<Document>();
            if (document == null)
            {
                document = e;
            }
        }
        public override void ExitDocument([NotNull] DocumentContext context)
        {
            PopElementStack();
        }

        public override void EnterAssignment([NotNull] AssignmentContext context)
        {
            var e = CreateElementOnStack<Assignment>();
            GiveChildToParent(e);
        }
        public override void ExitAssignment([NotNull] AssignmentContext context)
        {
            PopElementStack();
        }

        public override void EnterNumber([NotNull] NumberContext context)
        {
            Double.TryParse(context.GetText(), out double d);
            var e = CreateElementOnStack<Number>().Initialize(d);
            GiveChildToParent(e);
        }
        public override void ExitNumber([NotNull] NumberContext context)
        {
            PopElementStack();
        }

        public override void EnterCollection([NotNull] CollectionContext context)
        {
            var e = CreateElementOnStack<Collection>().Initialize(new List<IElement>());
            GiveChildToParent(e);
        }
        public override void ExitCollection([NotNull] CollectionContext context)
        {
            PopElementStack();
        }

        public override void EnterSymbol([NotNull] SymbolContext context)
        {
            var e = CreateElementOnStack<Symbol>().Initialize(context.GetText());
            GiveChildToParent(e);
        }
        public override void ExitSymbol([NotNull] SymbolContext context)
        {
            PopElementStack();
        }

        public override void EnterFunctionCall([NotNull] FunctionCallContext context)
        {
            var e = CreateElementOnStack<FunctionCall>();
            GiveChildToParent(e);
        }
        public override void ExitFunctionCall([NotNull] FunctionCallContext context)
        {
            PopElementStack();
        }

        public override void EnterParameter([NotNull] ParameterContext context)
        {
            var e = CreateElementOnStack<Parameter>().Initialize(context.GetText());
            GiveChildToParent(e);
        }
        public override void ExitParameter([NotNull] ParameterContext context)
        {
            PopElementStack();
        }

        public override void EnterFunctionDef([NotNull] FunctionDefContext context)
        {
            var e = CreateElementOnStack<Function>();
            GiveChildToParent(e);
        }
        public override void ExitFunctionDef([NotNull] FunctionDefContext context)
        {
            PopElementStack();
        }

        public override void EnterStr([NotNull] StrContext context)
        {
            var e = CreateElementOnStack<Str>().Initialize(context.GetText().Trim('"'));
            GiveChildToParent(e);
        }
        public override void ExitStr([NotNull] StrContext context)
        {
            PopElementStack();
        }

        public override void EnterTruefalse([NotNull] TruefalseContext context)
        {
            var e = CreateElementOnStack<TrueFalse>().Initialize(context.GetText() == "true");
            GiveChildToParent(e);
        }
        public override void ExitTruefalse([NotNull] TruefalseContext context)
        {
            PopElementStack();
        }
    }
}
