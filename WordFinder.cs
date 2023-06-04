using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordfinder
{
    public class WordFinder: IFinder
    {
        private readonly IEnumerable<string> matrix;

        public WordFinder(IEnumerable<string> matrix)
        {
            this.matrix = matrix;
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            List<string> wordsFound = new();

            // iterate distinct words to avoid duplicates
            Console.WriteLine($"Proceeding search each word horizontally at the matrix...");
            foreach (var word in wordstream.Distinct())
            {
                //search from left to right
                foreach (var rowStream in this.matrix)
                {
                    if (rowStream.Contains(word))
                    {
                        Console.WriteLine($"word {word} is contained horizontally");
                        wordsFound.Add(word);
                    }
                }

            }

            Console.WriteLine();

            //create transpose matrix        
            Console.WriteLine($"Proceeding to create transpose matrix...");
            List<string> transpose = new();

            for (int col = 0; col < this.matrix.ToList()[0].Length; col++)
            {
                Console.Write($"Word at column {col} : ");

                StringBuilder builder = new();

                for (int row = 0; row < this.matrix.ToList()[0].Length; row++)
                {
                    builder.Append(matrix.ToList()[row].ToCharArray()[col].ToString());
                }

                Console.Write(builder.ToString());
                transpose.Add(builder.ToString());

                Console.WriteLine();
            }

            Console.WriteLine();

            // iterate distinct words to avoid duplicates
            Console.WriteLine($"Proceeding search each word vertically at the matrix...");

            foreach (var word in wordstream.Distinct())
            {
                //search from left to right
                foreach (var colStream in transpose)
                {
                    if (colStream.Contains(word))
                    {
                        Console.WriteLine($"word {word} is contained vertically");
                        wordsFound.Add(word);
                    }
                }
            }

            Console.WriteLine();

            // Count the occurrence of each string
            var wordCounts = wordsFound.GroupBy(w => w).Select(g => new { Word = g.Key, Count = g.Count() });

            // Print the word counts
            foreach (var wordCount in wordCounts)
            {
                Console.WriteLine($"Word: {wordCount.Word}, Count: {wordCount.Count}");
            }

            return wordsFound.GroupBy(s => s)
                .OrderByDescending(g => g.Count())
                .Take(10)
                .Select(g => g.Key)
                .ToList();
        }
    }

}
