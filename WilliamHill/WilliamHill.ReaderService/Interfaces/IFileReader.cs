using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamHill.ReaderService.Interfaces
{
    public interface IFileReader
    {
        BetItem GetBetItem(string line);
        List<BetItem> LoadAll(string fileName);
    }
}
