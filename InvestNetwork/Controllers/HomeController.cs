using InvestNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvestNetwork.Core;

namespace InvestNetwork.Controllers
{
    public class HomeController : Controller//, IGeneralController
    {
        //
        // GET: /Home/
        private readonly IUserRepository _userRepository;
        private readonly ICityRepository _cityRepository;

        public HomeController(IUserRepository userRepository, ICityRepository cityRepository)
        {
            _userRepository = userRepository;
            _cityRepository = cityRepository;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
