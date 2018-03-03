using LEWD.src.Elements.Data;
using LEWD.src.Elements.Structure;
using LEWD.src.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEWD.src.Elements.Action
{
    public class IO
    {
        static Dictionary<string, string> localFiles;
        static string wd;

        public static void RescanFiles()
        {
            wd = Directory.GetCurrentDirectory();
            var dirs = Directory.GetDirectories(Directory.GetCurrentDirectory());
            var files = Directory.GetFiles(Directory.GetCurrentDirectory());
            localFiles = dirs
                .Concat(files)
                .ToDictionary(d => d.Remove(0, wd.Length + 1), d => d);
            localFiles[".."] = Directory.GetParent(".").FullName;
            localFiles["."] = wd;
        }

        public class OpenFile : BaseAction
        {
            public const string Symbol = "open";

            protected override string[] Signature => new[] { "filename" };

            public override IElement Action(ArgumentContainer Args)
            {
                var p = Args.GetVisitedArgumentAs<Str>("filename");
                return new Str().Initialize(File.ReadAllText(p.Value));
            }
        }

        public class Print : BaseAction
        {
            public const string Symbol = "print";

            protected override string[] Signature => new[] { REST };

            public override IElement Action(ArgumentContainer Args)
            {
                Console.WriteLine($"{String.Join(" ", Args.GetVisitedRestArguments().Value.Select(c => c.Repr()))}");
                return new Noop();
            }
        }

        public class PWD : BaseAction
        {
            public const string Symbol = "pwd";

            protected override string[] Signature => new string[] { };

            public override IElement Action(ArgumentContainer Args)
            {
                return new Str().Initialize(wd);
            }
        }

        public class DIR : BaseAction
        {
            public const string Symbol = "dir";

            protected override string[] Signature => new string[] { };

            public override IElement Action(ArgumentContainer Args)
            {
                return new Collection().Initialize(localFiles.Keys.Select(f => new Str().Initialize(f) as IElement).ToList());
            }
        }

        public class CD : BaseAction
        {
            public const string Symbol = "cd";

            protected override string[] Signature => new[] { "path" };

            public override IElement Action(ArgumentContainer Args)
            {
                var path = Args.GetVisitedArgumentAs<Str>("path");
                if (localFiles.ContainsKey(path.Value))
                {
                    Directory.SetCurrentDirectory(localFiles[path.Value]);
                    RescanFiles();
                }

                return new Noop();
            }
        }

        public class GetInput : BaseAction
        {
            public const string Symbol = "getline";

            protected override string[] Signature => new[] { REST };

            public override IElement Action(ArgumentContainer Args)
            {
                new Print().OnAction(Args.GetVisitedRestArguments().Value);
                return new Str().Initialize(Console.ReadLine());
            }
        }
    }
}
