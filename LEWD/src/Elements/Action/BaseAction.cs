using LEWD.src.Elements.Data;
using LEWD.src.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Action
{
    public abstract class BaseAction : BaseElement, IAction
    {
        public abstract IElement Action(ArgumentContainer Args);

        protected const string REST = "...";
        protected abstract string[] Signature { get; }

        string[] cachedSignature;

        public BaseAction()
        {
            cachedSignature = Signature;
        }

        public IElement OnAction(List<IElement> Arguments)
        {
            var args = new ArgumentContainer();
            args.InputSignature(cachedSignature, Arguments);
            return Action(args);
        }

        public override IElement Copy()
        {
            return this;
        }

        public class ArgumentContainer
        {
            Dictionary<string, IElement> parameters;
            Collection rest;
            Dictionary<string, IElement> visitedParameters;

            public ArgumentContainer()
            {
                rest = new Collection().Initialize(new List<IElement>()) as Collection;
                parameters = new Dictionary<string, IElement>
                {
                    { REST, rest },
                };
            }

            public void InputSignature(string[] signature, List<IElement> args)
            {
                var enumer = args.GetEnumerator();
                foreach (var sig in signature)
                {
                    enumer.MoveNext();

                    if (sig == REST)
                    {
                        break;
                    }
                    else if (enumer.Current == null)
                    {
                        throw new ParameterException($"Missing parameter '{sig}'");
                    }
                    else
                    {
                        parameters[sig] = enumer.Current;
                    }
                }

                while(enumer.Current != null)
                {
                    rest.Value.Add(enumer.Current);
                    enumer.MoveNext();
                }
            }

            public IElement GetRawArgument(string name)
            {
                if (parameters.ContainsKey(name))
                {
                    return parameters[name];
                }
                return null;
            }

            public IElement VisitArgument(string name)
            {
                var arg = GetRawArgument(name);
                if (arg != null) 
                    return Interpreter.VisitAndGetResult(arg);
                return null;
            }


            public Collection GetRawRestArguments()
            {
                return GetRawArgument(REST) as Collection;
            }

            public Collection GetVisitedRestArguments()
            {
                return VisitArgument(REST) as Collection;
            }

            public IElement GetRawArgument(string name, bool nullOK = false)
            {
                var arg = GetRawArgument(name);
                if (arg == null && !nullOK)
                {
                    throw new ParameterException($"Parameter {name} did not have a value.");
                }
                return arg;
            }

            public IElement GetVisitedArgument(string name, bool nullOK = false)
            {
                var arg = VisitArgument(name);
                if (arg == null && !nullOK)
                {
                    throw new ParameterException($"Parameter {name} did not have a value.");
                }
                return arg;
            }

            public TType GetVisitedArgumentAs<TType>(string name, bool nullOK = false) where TType : IElement
            {
                var inputarg = VisitArgument(name);
                if (inputarg is TType arg)
                {
                    return arg;
                }
                if (nullOK)
                {
                    return default(TType);
                }
                throw new TypeException($"Provided argument '{inputarg.GetType().Name}' for parameter '{name}' did not match type {typeof(TType).Name}");
            }
        }
    }
}
