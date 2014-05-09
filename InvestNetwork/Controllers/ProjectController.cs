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
        private readonly IProjectStatusRepository _projectStatusRepository;
        private readonly IInvestContext _investContext;
        private const int PROJECT_COUNT_AT_THE_FIRST_VIEWING = 20;

        public ProjectController(IProjectRepository projectRepository, IProjectStatusRepository projectStatusRepository, IInvestContext investContext)
        {
            this._projectRepository = projectRepository;
            this._projectStatusRepository = projectStatusRepository;
            this._investContext = investContext;
        }

        public ActionResult Index()
        {
            return View(_projectRepository.GetAll());
        }

        [Authorize]
        public ActionResult Start()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Start(Project model)
        {
            if (ModelState.IsValid)
            {
                model.AuthorID = _investContext.CurrentUser.Id;
                model.CreateDate = DateTime.Now;
                model.Status = ProjectStatusEnum.OnReview;
                model.LinkToBusinessPlan = "";
                model.LinkToFinancialPlan = "";
                model.LinkToGuaranteeLetter = "";
                model.LinkToVideoPresentation = "";
                model.LinkToImg = "";

                _projectRepository.Insert(model);
                _projectRepository.SaveChanges();
            }
            else
            {
                return View(model);
            }
            return RedirectToAction("Discover");
        }

        public ActionResult Discover()
        {
            return View(_projectRepository.GetAll().Where(p => p.Status == ProjectStatusEnum.Active).Take(PROJECT_COUNT_AT_THE_FIRST_VIEWING));
        }

        public ActionResult View(int id)
        {
            return View(_projectRepository.GetById(id));
        }
    }
}
