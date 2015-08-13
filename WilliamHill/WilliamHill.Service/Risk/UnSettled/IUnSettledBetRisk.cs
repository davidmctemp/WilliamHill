using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbModel = WilliamHill.Data.Models;

namespace WilliamHill.Service.Risk.UnSettled
{
    public interface IUnSettledBetRisk
    {
        void AssessRisk(List<DbModel.UnSettled> bets);
    }
}
