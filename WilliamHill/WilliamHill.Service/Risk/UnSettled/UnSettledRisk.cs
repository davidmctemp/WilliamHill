using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamHill.Service.Risk.UnSettled
{
    public class UnSettledRisk
    {
        public UnSettledRisk(int betId, string concern)
        {
            BetId = betId;
            Concern = concern;
        }

        public int BetId { get; set; }
        public string Concern { get; set; }
    }
}
