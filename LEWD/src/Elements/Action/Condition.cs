using LEWD.src.Elements.Data;
using LEWD.src.Elements.Structure;
using LEWD.src.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Action
{
    public class Condition : BaseAction
    {
        public static string Symbol = "if";

        protected override string[] Signature => new[] { "if", "then", "else" };

        public override IElement Action(ArgumentContainer Args)
        {
            var cond = Args.GetRawArgument("if", true);
            var then = Args.GetRawArgument("then", true);
            var el = Args.GetRawArgument("else", true);
            if (cond == null)
            {
                return new Noop();
            }

            if (then == null)
            {
                throw new TypeException("IF must recieve at least 2 parameters!");
            }

            var testResult = Interpreter.VisitAndGetResult(cond);
            if (testResult is TrueFalse tf)
            {
                if (tf.Value == true)
                {
                    return Interpreter.VisitAndGetResult(then);
                }
                else if (el != null)
                {
                    return Interpreter.VisitAndGetResult(el);
                }
            }
            else
            {
                throw new TypeException("Returned value to IF was not a boolean value!");
            }

            return new Noop();
        }
    }

    public class Cond : BaseAction
    {
        public const string Symbol = "cond";

        protected override string[] Signature => new[] { REST };

        public override IElement Action(ArgumentContainer Args)
        {
            // let's assume that all parameters are collections of the form:
            // [condition-expr then-expr]

            foreach (var param in Args.GetRawRestArguments().Value)
            {
                if (param is Collection cond)
                {
                    var values = cond.GetInnerValues();
                    if (values.Count == 2)
                    {
                        var testResult = Interpreter.VisitAndGetResult(values.First());

                        if (testResult is TrueFalse tf)
                        {
                            if (tf.Value == true)
                            {
                                return Interpreter.VisitAndGetResult(values.Skip(1).First());
                            }
                            // else move on to the next pair
                        }
                        else
                        {
                            throw new TypeException("Returned value to IF was not a boolean value!");
                        }
                    }
                    else
                    {
                        throw new TypeException("IF must recieve collections with exactly 2 items in each");
                    }
                }
            }
            return new Noop();
        }
    }
}
