using NUnit.Framework;
using System.Collections.Generic;
using WilliamHill.Data.Models;
using WilliamHill.Service.Risk.UnSettled;

namespace WilliamHill.Service.Tests
{
    [TestFixture]
    public class Test_WinOver1000
    {
        [Test]
        public void Test_UnSettledBets_All_Over_1000()
        {
            var bets = new List<UnSettled>();

            bets.Add(new UnSettled { Customer = 1, Win = 1000 });
            bets.Add(new UnSettled { Customer = 2, Win = 1001 });
            bets.Add(new UnSettled { Customer = 3, Win = 1000000 });

            var test = new WinOver1000();
            var results = test.AssessRisk(bets);

            Assert.IsTrue(results.Count == 3);
        }

        [Test]
        public void Test_UnSettledBets_All_Under_1000()
        {
            var bets = new List<UnSettled>();

            bets.Add(new UnSettled { Customer = 1, Win = 999 });
            bets.Add(new UnSettled { Customer = 2, Win = 1 });
            bets.Add(new UnSettled { Customer = 3, Win = 2 });

            var test = new WinOver1000();
            var results = test.AssessRisk(bets);

            Assert.IsTrue(results.Count == 0);
        }

        [Test]
        public void Test_UnSettledBets_Mixture()
        {
            var bets = new List<UnSettled>();

            bets.Add(new UnSettled { Customer = 1, Win = 1 });
            bets.Add(new UnSettled { Customer = 2, Win = 2 });
            bets.Add(new UnSettled { Customer = 3, Win = 3 });
            bets.Add(new UnSettled { Customer = 4, Win = 1000 });
            bets.Add(new UnSettled { Customer = 5, Win = 1001 });
            bets.Add(new UnSettled { Customer = 6, Win = 1002 });

            var test = new WinOver1000();
            var results = test.AssessRisk(bets);

            Assert.IsTrue(results.Count == 3);
        }
    }
}
