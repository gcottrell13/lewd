using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using LEWD.src.Elements;
using LEWD.src.Elements.Structure;
using LEWD.src.language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LEWD.src
{
    public class Parser
    {
        /// <summary>
        /// Returns a tree of parsed elements
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public Document Parse(string source)
        {
            var lexer = new lewdLexer(new Antlr4.Runtime.AntlrInputStream(source));
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new lewdParser(tokenStream);
            var sentenceContext = parser.document();
            var walker = new ParseTreeWalker();
            var listener = new LEWDListener();
            walker.Walk(listener, sentenceContext);
            return listener.document;
        }
    }
}
