using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamHill.Data.Repository;
using WilliamHill.Service.Risk.UnSettled;

namespace WilliamHill.Service
{
    public class UnSettledBetService : IUnSettledBetService
    {
        public readonly IUnSettledRepository _unSettledRepository;
        public IEnumerable<IUnSettledBetRisk> _unSettledBetAssessors;

        public UnSettledBetService(IUnSettledRepository unSettledRepository, IEnumerable<IUnSettledBetRisk> unSettledBetAssessors)
        {
            _unSettledRepository = unSettledRepository;
            _unSettledBetAssessors = unSettledBetAssessors;
        }

        public List<UnSettledRisk> AssessUnSettledBets()
        {
            var results = new List<UnSettledRisk>();

            var unSettledBets = _unSettledRepository.GetAll().ToList();

            foreach (var assessor in _unSettledBetAssessors)
            {
                results.AddRange(assessor.AssessRisk(unSettledBets));
            }
            return results;
        }
    }

    public interface IUnSettledBetService
    {
        List<UnSettledRisk> AssessUnSettledBets();
    }
}
