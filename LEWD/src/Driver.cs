using LEWD.src.Elements;
using LEWD.src.Elements.Action;
using LEWD.src.Elements.Data;
using LEWD.src.Elements.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src
{
    class Driver
    {
        string SourceFileName;

        public Driver(string src)
        {

            SourceFileName = src;

            string lines = null;

            try
            {
                lines = System.IO.File.ReadAllText(src);
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't access file.");
            }

            if (lines != null)
            {
                var parser = new Parser();
                var document = parser.Parse(lines);
                var i = new Interpreter();

                i.Run(document);
            }
        }
    }
}
