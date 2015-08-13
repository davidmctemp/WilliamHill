using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamHill.Data.Repository;
using WilliamHill.Service.Risk.Settled;

namespace WilliamHill.Service
{
    public class SettledBetService : ISettledBetService
    {
        public readonly ISettledRepository _settledRepository;
        public IEnumerable<ISettledBetRisk> _settledBetAssessors;

        public SettledBetService(ISettledRepository settledRepository, IEnumerable<ISettledBetRisk> settledBetAssessors)
        {
            _settledRepository = settledRepository;
            _settledBetAssessors = settledBetAssessors;
        }

        public List<SettledRisk> AssessSettledBets()
        {
            var results = new List<SettledRisk>();

            var settledBets = _settledRepository.GetAll().ToList();

            foreach (var assessor in _settledBetAssessors)
            {
                results.AddRange(assessor.AssessRisk(settledBets));
            }

            return results;
        }
    }

    public interface ISettledBetService
    {
        List<SettledRisk> AssessSettledBets();
    }
}
