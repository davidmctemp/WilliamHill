using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamHill.Data.Models;
using WilliamHill.Data.Repository;
using WilliamHill.Service.Risk.UnSettled;

namespace WilliamHill.Service.Tests
{
    [TestFixture]
    public class Test_Higher_Than_Average_Bet
    {
        [TestCase(10)]
        [TestCase(30)]
        public void Test_Higher_Than_Previous_Average(int factor)
        {
            var averageBet = 100;
            var repository = new Mock<ISettledRepository>();
            repository.Setup(a => a.GetAverageStakeForCustomer(1)).Returns(averageBet);

            var test = new HigherThanAvergeStakes(factor, repository.Object);
            
            var bets = new List<UnSettled>();
            bets.Add(new UnSettled { ID = 50, Customer = 1, Stake = averageBet * factor + 1 });

            var results = test.AssessRisk(bets);

            Assert.IsTrue(results.Count == 1);
            Assert.IsTrue(results[0].Concern == string.Format("Bet id: 50 is more than {0} times over the customers average of 100", factor));
        }

        [TestCase(10)]
        [TestCase(30)]
        public void Test_Bet_Is_Less_Than_N_Previous_Average(int factor)
        {
            var averageBet = 100;
            var repository = new Mock<ISettledRepository>();
            repository.Setup(a => a.GetAverageStakeForCustomer(1)).Returns(averageBet);

            var test = new HigherThanAvergeStakes(factor, repository.Object);

            var bets = new List<UnSettled>();
            bets.Add(new UnSettled { ID = 50, Customer = 1, Stake = averageBet * factor - 1 });

            var results = test.AssessRisk(bets);

            Assert.IsTrue(results.Count == 0);
        }
    }
}
