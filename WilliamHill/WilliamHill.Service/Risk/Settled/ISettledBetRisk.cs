using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamHill.Service.Risk.UnSettled;
using DbModel = WilliamHill.Data.Models;

namespace WilliamHill.Service.Risk.Settled
{
    public interface ISettledBetRisk
    {
        List<SettledRisk> AssessRisk(List<DbModel.Settled> bets);
    }
}
