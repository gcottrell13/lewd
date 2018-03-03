using LEWD.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Lambda Expressions While Do
/// </summary>
namespace LEWD
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = null;
            if (args.Count() < 1)
            {
                Console.WriteLine("Usage: <filename>\nProvide a file name:");
                fileName = Console.ReadLine();
            }

            Console.Clear();

            var driver = new Driver(fileName);
            var input = Console.ReadLine();
        }
    }
}
