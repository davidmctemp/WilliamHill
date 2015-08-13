using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamHill.Service.Risk.UnSettled;


namespace WilliamHill.Service.Risk.Settled
{
    public class WinningAtUnusualRate : ISettledBetRisk
    {
        /// <summary>
        /// A customer wins on more than 60% of their bets 
        /// (i.e. in the settled bets data, they have a value in the “win” column for more than 60% of their bets) 
        /// </summary>
        /// <param name="bets"></param>
        /// <returns></returns>
        public List<SettledRisk> AssessRisk(List<Data.Models.Settled> bets)
        {
            var results = new List<SettledRisk>();

            foreach (var cust in bets.GroupBy(a => a.Customer))
            {
                var totalBets = new decimal(cust.Count());
                var totalWins = new decimal(cust.Count(a => a.Win > 0));

                // not likely, but....
                if (totalBets == 0) continue;

                var winRatio = totalWins / totalBets;

                if (winRatio > 0.6M)
                {
                    results.Add(new SettledRisk(cust.Key, string.Format("Customer {0} has won over 60% of their bets", cust.Key)));
                }
            }

            return results;
        }
    }
}
