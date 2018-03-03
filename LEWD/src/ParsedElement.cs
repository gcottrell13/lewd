using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src
{
    public class ParsedElement
    {
        public ParsedElement Parent;
        public string Head;
        public List<ParsedElement> Tail;
        public int Indent;

        public ParsedElement(string head, int indent)
        {
            Head = head;
            Tail = new List<ParsedElement>();
            Indent = indent;
        }

        public void AddChild(ParsedElement child)
        {
            Tail.Add(child);
            child.Parent = this;
        }

        public bool IsChildOf(ParsedElement parsed)
        {
            if (parsed == null)
            {
                return false;
            }
            if (Parent == null)
            {
                return false;
            }
            if (parsed == Parent)
            {
                return true;
            }
            return Parent.IsChildOf(parsed);
        }
    }
}
