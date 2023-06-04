using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using wordfinder;

List<string> matrix = new()
{
    "abcoc",
    "fgwio",
    "chill",
    "pqnsd",
    "uvdxy"
};

List<string> words = new()
{
    "chill",
    "cold",
    "wind"
};


IEnumerable<string> result = new WordFinder(matrix).Find(words);
Console.WriteLine();
Console.WriteLine("The top 10 most repeated words at matrix are: ");
result.ToList().ForEach(x => Console.WriteLine(x));





