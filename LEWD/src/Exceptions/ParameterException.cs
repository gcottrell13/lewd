using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Exceptions
{
    public class ParameterException : Exception
    {
        public ParameterException() { }
        public ParameterException(string message) : base(message) { }
    }
}
