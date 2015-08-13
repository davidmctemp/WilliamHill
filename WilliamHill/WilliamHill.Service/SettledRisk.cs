using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamHill.Service
{
    public class SettledRisk
    {
        public SettledRisk(int id, string concern)
        {
            CustomerId = id;
            Concern = concern;
        }

        public int CustomerId { get; set; }
        public string Concern { get; set; }
    }
}
