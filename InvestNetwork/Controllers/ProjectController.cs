using InvestNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvestNetwork.Controllers
{
    public class ProjectController : Controller
    {
        //
        // GET: /Project/
        private readonly IProjectRepository _projectRepository;
        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
