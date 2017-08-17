using System;
using System.Collections.Generic;
using System.Linq;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            "Hello world!"
                .ToUpper()
                .And(s =>
                    s.EndsWith("!")
                    ? s.Substring(0, s.Length - 1)
                    : s)
                .Split(" ")
                .Select(s => s + "z")
                .Do(() => Console.WriteLine("I'm in yer chainz"))
                .Aggregate((acc, curr) => acc += " " + curr)
                .And(s => s += "!")
                .AndFinally(Console.WriteLine);

            "html"
                .AndMap(
                    FunctionalExtensions.GetConstructor<TagBuilder>())
                .SetBody($"{new TagBuilder("head").ToString()}\n\t{new TagBuilder("body").ToString()}")
                .ToString()
                .AndFinally(Console.WriteLine);
        }
    }

    class TagBuilder
    {
        public string Tag { get; }
        public string Body { get; private set; }
        public TagBuilder(string tag) => Tag = tag;

        public TagBuilder SetBody(string body)
        {
            Body = body;
            return this;
        }

        public override string ToString() => $@"<{Tag}>{(Body == null ? null : "\n\t" + Body + "\n")}</{Tag}>";
    }
}
