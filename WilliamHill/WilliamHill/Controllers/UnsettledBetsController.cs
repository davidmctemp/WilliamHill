using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WilliamHill.Service;

namespace WilliamHill.Controllers
{
    public class UnsettledBetsController : Controller
    {
        private readonly IUnSettledBetService _unsettledBetsService;

        public UnsettledBetsController(IUnSettledBetService unsettledBetsService)
        {
            _unsettledBetsService = unsettledBetsService;
        }

        //
        // GET: /UnsettledBets/
        public ActionResult Index()
        {
            var results = _unsettledBetsService.AssessUnSettledBets();
            return View(results);
        }
    }
}
