using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamHill.Service.Risk.UnSettled
{
    public class WinOver1000 : IUnSettledBetRisk
    {
        public List<UnSettledRisk> AssessRisk(List<Data.Models.UnSettled> bets)
        {
            return bets.Where(a => a.Win >= 1000)
                .Select(a => new UnSettledRisk(a.ID, string.Format("Bet id {0} could win {1}", a.ID, a.Win)))
                .ToList();
        }
    }
}
