using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamHill.Data.Repository;

namespace WilliamHill.Service.Risk.UnSettled
{
    public class HigherThanAvergeStakes : IUnSettledBetRisk
    {
        private readonly int _factor;
        private readonly ISettledRepository _settledRepository;
        private Dictionary<int, double> _cachedResults;

        public HigherThanAvergeStakes(int factor, ISettledRepository settledRepository)
        {
            _factor = factor;
            _settledRepository = settledRepository;
            _cachedResults = new Dictionary<int, double>();
        }

        /// <summary>
        /// Bets where the stake is more than 10 times higher than that customer’s 
        /// average bet in their betting history should be highlighted as unusual 
        /// 
        /// Same for 30 times higher.....
        /// </summary>
        /// <param name="bets"></param>
        /// <returns></returns>
        public List<UnSettledRisk> AssessRisk(List<Data.Models.UnSettled> bets)
        {
            // NOTE: I'm making an assumption here, that we're only comparing the average of the settled bets (i.e. history).

            var results = new List<UnSettledRisk>();

            foreach(var bet in bets)
            {
                var customerAverage = GetAverage(bet.Customer);

                if(customerAverage * _factor < bet.Stake)
                {
                    results.Add(new UnSettledRisk(bet.ID, 
                        string.Format("Bet id: {0} is more than {1} times over the customers average of {2}", bet.ID, _factor, customerAverage)));
                }
            }

            return results;
        }

        private double GetAverage(int customerId)
        {
            if (!_cachedResults.ContainsKey(customerId))
                _cachedResults[customerId] = _settledRepository.GetAverageStakeForCustomer(customerId);

            return _cachedResults[customerId];
        }
    }
}
