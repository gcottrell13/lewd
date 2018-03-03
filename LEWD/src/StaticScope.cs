using LEWD.src.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src
{
    public class StaticScope
    {
        public Dictionary<string, IElement> Names;
        public StaticScope Parent;

        Stack<DynamicScope> DynamicScopes;

        public StaticScope()
        {
            Names = new Dictionary<string, IElement>();
            DynamicScopes = new Stack<DynamicScope>();
        }

        public void AddNames(Dictionary<string, IElement> elements)
        {
            foreach (var kvp in elements)
            {
                Names.Add(kvp.Key, kvp.Value);
            }
        }

        public IElement SearchForName(string name)
        {
            if (DynamicScopes.Count > 0 && DynamicScopes.Peek().Names.ContainsKey(name))
            {
                return DynamicScopes.Peek().Names[name];
            }
            if (Names.ContainsKey(name))
            {
                return Names[name];
            }
            if (Parent != null)
            {
                return Parent.SearchForName(name);
            }
            return null;
        }

        public void NewDynamicScope()
        {
            DynamicScopes.Push(new DynamicScope());
        }
        public void PopDynamicScope()
        {
            DynamicScopes.Pop();
        }
        public void AddNamesToDynamicScope(Dictionary<string, IElement> elements)
        {
            var top = DynamicScopes.Peek();
            if (top != null)
            {
                foreach (var kvp in elements)
                {
                    top.Names.Add(kvp.Key, kvp.Value);
                }
            }
        }

        public class DynamicScope
        {
            public Dictionary<string, IElement> Names;

            public DynamicScope()
            {
                Names = new Dictionary<string, IElement>();
            }
        }
    }
}
