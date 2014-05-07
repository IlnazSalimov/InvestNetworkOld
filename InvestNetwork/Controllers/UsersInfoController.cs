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

        /*[HttpPost]
        public ActionResult Add(UsersInfo model)
        {
            if (ModelState.IsValid)
            {
                // достать текущего user'а
                //------------------------------------------------------------------------
                var cur_user = _investContext.CurrentUser;
                User user;
                if (cur_user != null)
                {
                    user = ((UserIndentity)cur_user.Identity).User;

                    model.UserID = user.Id;

                    if (_usersInfoRepository.GetByUserId(user.Id) == null)
                    {
                        model.RegisterDate = DateTime.Now;
                        _usersInfoRepository.Insert(model);
                    }
                    else
                    {
                        _usersInfoRepository.Update(model);
                    }

                    _usersInfoRepository.Save();
                }
            }
            return View(model);
        }*/
    }
}
