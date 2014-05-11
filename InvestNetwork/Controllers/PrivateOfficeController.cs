using InvestNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvestNetwork.Controllers
{
    public class PrivateOfficeController : Controller
    {
        //
        // GET: /UsersInfo/
        private readonly IUsersInfoRepository _usersInfoRepository;
        private readonly IInvestContext _investContext;

        public PrivateOfficeController(IUsersInfoRepository usersInfoRepository, IInvestContext investContext)
        {
            _usersInfoRepository = usersInfoRepository;
            _investContext = investContext;
        }

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            User user = _investContext.CurrentUser;
            user.Avatar = "http://placehold.it/210x230";

            ViewBag.usersInfo = _usersInfoRepository.GetByUserId(user.Id);
            ViewBag.partycipations = _usersInfoRepository.GetPartycipation(user.ID);

            return View(user);
        }
    }
}
