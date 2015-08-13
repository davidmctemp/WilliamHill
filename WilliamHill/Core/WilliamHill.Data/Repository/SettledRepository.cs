using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamHill.Data.Models;

namespace WilliamHill.Data.Repository
{
    public class SettledRepository : GenericRepository<Settled>, ISettledRepository
    {
        public double GetAverageStakeForCustomer(int customerId)
        {
            var q = from settled in Context.Settled
                    where settled.Customer == customerId
                    group settled by settled.Customer into grp
                    select grp.Average(a => a.Stake);

            return q.FirstOrDefault();
        }
    }

    public interface ISettledRepository : IRepository<Settled>
    {
        double GetAverageStakeForCustomer(int customerId);
    }
}
