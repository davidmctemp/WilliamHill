using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WilliamHill.Service;

namespace WilliamHill.Controllers
{
    public class SettledBetsController : Controller
    {
        private readonly ISettledBetService _service;

        public SettledBetsController(ISettledBetService service)
        {
            _service = service;
        }

        //
        // GET: /Bets/
        public ActionResult Index()
        {
            var bigWinners = _service.AssessSettledBets();

            return View(bigWinners);
        }
    }
}
