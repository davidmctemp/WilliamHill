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
        private readonly IUnsettledBetService _unsettledBetsService;

        public UnsettledBetsController(IUnsettledBetService unsettledBetsService)
        {
            _unsettledBetsService = unsettledBetsService;
        }

        //
        // GET: /UnsettledBets/
        public ActionResult Index()
        {
            return View();
        }
    }
}
