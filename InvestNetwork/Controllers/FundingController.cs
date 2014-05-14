using InvestNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvestNetwork.Controllers
{
    [Authorize]
    public class FundingController : Controller
    {
        private readonly IProjectRepository _projectRepository;

        public FundingController(IProjectRepository projectRepository)
        {
            this._projectRepository = projectRepository;
        }

        public ActionResult DetermineAmount(int Id)
        {
            return View(_projectRepository.GetById(Id));
        }

    }
}
