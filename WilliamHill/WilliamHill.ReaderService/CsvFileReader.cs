using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamHill.ReaderService.Interfaces;

namespace WilliamHill.ReaderService
{
    public class CsvFileReader : IFileReader
    {
        public BetItem GetBetItem(string line)
        {
            Console.WriteLine("hello from csv reader");
            return new BetItem(1, 1, 1, 1, 1);
        }

        public IList<BetItem> LoadAll(string fileName)
        {
            return new List<BetItem>();
        }
    }
}
