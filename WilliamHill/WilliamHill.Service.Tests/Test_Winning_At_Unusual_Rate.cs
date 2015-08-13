using System;
using NUnit.Framework;
using WilliamHill.Service.Risk.Settled;
using WilliamHill.Data.Models;
using System.Collections.Generic;

namespace WilliamHill.Service.Tests
{
    [TestFixture]
    public class Test_Winning_At_Unusual_Rate
    {
        [Test]
        public void Test_Has_One_Lucky_Winner()
        {
            var bets = new List<Settled>();
            bets.Add(new Settled{ Customer = 1, Win = 0 });
            bets.Add(new Settled{ Customer = 1, Win = 10 });
            bets.Add(new Settled{ Customer = 1, Win = 10 });

            var winningRate = new WinningAtUnusualRate();
            var result = winningRate.AssessRisk(bets);

            Assert.IsTrue(result.Count == 1);
        }

        [Test]
        public void Test_Has_Two_Lucky_Winner()
        {
            var bets = new List<Settled>();
            bets.Add(new Settled { Customer = 1, Win = 0 });
            bets.Add(new Settled { Customer = 1, Win = 10 });
            bets.Add(new Settled { Customer = 1, Win = 10 });
            bets.Add(new Settled { Customer = 2, Win = 0 });
            bets.Add(new Settled { Customer = 2, Win = 10 });
            bets.Add(new Settled { Customer = 2, Win = 10 });

            var winningRate = new WinningAtUnusualRate();
            var result = winningRate.AssessRisk(bets);

            Assert.IsTrue(result.Count == 2);
        }

        [Test]
        public void Test_Has_One_Lucky_Winner_And_One_NotSoLucky()
        {
            var bets = new List<Settled>();
            // Lucky Guy #1
            bets.Add(new Settled { Customer = 1, Win = 0 });
            bets.Add(new Settled { Customer = 1, Win = 10 });
            bets.Add(new Settled { Customer = 1, Win = 10 });
            // UnLucky Guy #1
            bets.Add(new Settled { Customer = 2, Win = 0 });
            bets.Add(new Settled { Customer = 2, Win = 0 });
            bets.Add(new Settled { Customer = 2, Win = 10 });

            var winningRate = new WinningAtUnusualRate();
            var result = winningRate.AssessRisk(bets);

            Assert.IsTrue(result.Count == 1);
        }

        [Test]
        public void Test_Has_Zero_Lucky_Winner()
        {
            var bets = new List<Settled>();
            // UnLucky Guy #1
            bets.Add(new Settled { Customer = 2, Win = 0 });
            bets.Add(new Settled { Customer = 2, Win = 0 });
            bets.Add(new Settled { Customer = 2, Win = 10 });

            var winningRate = new WinningAtUnusualRate();
            var result = winningRate.AssessRisk(bets);

            Assert.IsTrue(result.Count == 0);
        }

        [Test]
        public void Test_Has_Zero_Lucky_Winner_And_Two_NotSoLucky()
        {
            var bets = new List<Settled>();
            // UnLucky Guy #1
            bets.Add(new Settled { Customer = 1, Win = 0 });
            bets.Add(new Settled { Customer = 1, Win = 0 });
            bets.Add(new Settled { Customer = 1, Win = 0 });
            // UnLucky Guy #1
            bets.Add(new Settled { Customer = 2, Win = 0 });
            bets.Add(new Settled { Customer = 2, Win = 0 });
            bets.Add(new Settled { Customer = 2, Win = 10 });

            var winningRate = new WinningAtUnusualRate();
            var result = winningRate.AssessRisk(bets);

            Assert.IsTrue(result.Count == 0);
        }
    }
}
