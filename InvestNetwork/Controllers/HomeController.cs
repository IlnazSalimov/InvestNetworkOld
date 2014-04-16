﻿using InvestNetwork.Models;
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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCities()
        {
            var list = _cityRepository.GetAll().Where(s => s.CityID == 5);
            return View(list);
        }
    }
}
