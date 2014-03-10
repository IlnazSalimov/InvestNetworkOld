using InvestNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvestNetwork.Controllers
{
    public class UsersInfoController : GeneralController
    {
        //
        // GET: /UsersInfo/
        private readonly IUsersInfoRepository _usersInfoRepository;
        public UsersInfoController()
        {
        }
        public UsersInfoController(IUsersInfoRepository usersInfoRepository)
        {
            _usersInfoRepository = usersInfoRepository;
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UsersInfo model)
        {
            User user = this.GetAccount().User;
            model.UserID = user.Id;

            if (_usersInfoRepository.GetByUserId(user.Id) != null)
            {
                model.RegisterDate = DateTime.Now;
                _usersInfoRepository.Insert(model);
            }
            else
            {
                _usersInfoRepository.Update(model);
            }

            _usersInfoRepository.Save();
            return View(model);
        }
    }
}
