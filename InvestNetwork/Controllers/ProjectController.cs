using InvestNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvestNetwork.Controllers
{
    public enum ProjectStatus
    {
        Сhecking = 1,
        Active = 5,
        Inactive = -99
    }

    public class ProjectController : Controller
    {
        //
        // GET: /Project/
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectStatusRepository _projectStatusRepository;
        public ProjectController(IProjectRepository projectRepository, IProjectStatusRepository projectStatusRepository)
        {
            this._projectRepository = projectRepository;
            this._projectStatusRepository = projectStatusRepository;
        }

        public ActionResult Index()
        {
            return View(_projectRepository.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Project model)
        {
            if (ModelState.IsValid)
            {
                model.AuthorID = 1;
                model.CreateDate = DateTime.Now;
                model.ProjectStatusID = _projectStatusRepository.GetByCode((int)ProjectStatus.Сhecking).ProjectStatusID;
                model.LinkToBusinessPlan = "";
                model.LinkToFinancialPlan = "";
                model.LinkToGuaranteeLetter = "";
                model.LinkToVideoPresentation = "";

                _projectRepository.Insert(model);
                _projectRepository.Save();
            }
            return View(model);
        }
    }
}
