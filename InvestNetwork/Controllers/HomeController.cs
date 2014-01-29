using InvestNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvestNetwork.Core;

namespace InvestNetwork.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private readonly IUserRepository _userRepository;
        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

    }
}
