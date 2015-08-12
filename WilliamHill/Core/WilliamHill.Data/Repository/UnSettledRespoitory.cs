using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamHill.Data.Models;

namespace WilliamHill.Data.Repository
{
    public class UnSettledRepositiry : GenericRepository<Unsettled>, IUnSettledRepository
    {
    }

    public interface IUnSettledRepository : IRepository<Unsettled>
    {
    }
}
