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
        //private readonly IInvestContext _sessionState;
        public HomeController(IUserRepository userRepository, ICityRepository cityRepository/*, ISessionState sessionState*/)
        {
            _userRepository = userRepository;
            _cityRepository = cityRepository;

        }

        [Authorize]
        public ActionResult Index()
        {
            /*_userRepository.Insert(new User { FullName = "Salimova Fanzilya", Email = "salimova.fanzilya@gmail.com", Password = "5153637" });
            _userRepository.Insert(new User { FullName = "sadf", Email = "salimovwera.fanzilya@gmail.com", Password = "5153637" });
            _userRepository.Insert(new User { FullName = "ertre", Email = "salimwferova.fanzilya@gmail.com", Password = "5153637" });
            _userRepository.Save();*/
            ViewData["Users"] = _userRepository.GetAll();
            return View();
        }

        public ActionResult GetCities()
        {
            var list = _cityRepository.GetAll().Where(s => s.CityID == 5);
            return View(list);
        }
    }
}
