using InvestNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvestNetwork.Controllers
{
    public class UsersInfoController : Controller
    {
        //
        // GET: /UsersInfo/
        private readonly IUsersInfoRepository _usersInfoRepository;
        private readonly IInvestContext _investContext;

        public UsersInfoController(IUsersInfoRepository usersInfoRepository, IInvestContext investContext)
        {
            _usersInfoRepository = usersInfoRepository;
            _investContext = investContext;
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Add(UsersInfo model)
        {
            if (ModelState.IsValid)
            {
                User user = _investContext.CurrentUser;

                model.UserID = user.Id;
                UsersInfo usersInfo = _usersInfoRepository.GetByUserId(user.Id);

                if (usersInfo == null)
                {
                    model.RegisterDate = DateTime.Now;
                    _usersInfoRepository.Insert(model);
                }
                else
                {
                    model.UsersInfoID = usersInfo.UsersInfoID;
                    _usersInfoRepository.Update(model);
                }

                _usersInfoRepository.Save();

            }
            return View(model);
        }
    }
}
