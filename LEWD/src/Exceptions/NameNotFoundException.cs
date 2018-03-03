using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Exceptions
{
    public class NameNotFoundException : Exception
    {
        public NameNotFoundException(string name) : base($"Name not found: '{name}'")
        {
        }
    }
}
