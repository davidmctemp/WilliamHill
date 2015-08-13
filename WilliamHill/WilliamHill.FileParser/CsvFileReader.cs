using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamHill.FileParser
{
    public class CsvFileReader : IFileReader
    {
        /// <summary>
        /// Parses a bet item from a string.
        /// </summary>
        /// <param name="line">String to parse.</param>
        /// <returns>Populated bet item.</returns>
        public BetItem GetBetItem(string line)
        {
            var parts = line.Split(',');

            // Note to reviewers - I would usually have some validation here!
            return new BetItem(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]));
        }

        /// <summary>
        /// Load all lines, skipping line #1 as it's a header row.
        /// </summary>
        /// <param name="fileName">File to open.</param>
        /// <returns>List of BetItems</returns>
        public List<BetItem> LoadAll(string fileName)
        {
            var results = new List<BetItem>();
            var betLines = File.ReadLines(fileName).Skip(1);

            foreach (string line in betLines)
            {
                results.Add(GetBetItem(line));
            }

            return results;
        }
    }
}
