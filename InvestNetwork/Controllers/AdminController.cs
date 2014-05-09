using InvestNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvestNetwork.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        private const int RECENT_PROJECT_CNT = 3;
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectStatusRepository _projectStatusRepository;

        public AdminController(IProjectRepository projectRepository, IProjectStatusRepository projectStatusRepository)
        {
            this._projectRepository = projectRepository;
            this._projectStatusRepository = projectStatusRepository;
        }

        public ActionResult Index()
        {
            ViewBag.RecentProjects = _projectRepository.GetAll().OrderByDescending(p => p.CreateDate).Take(RECENT_PROJECT_CNT);
            return View();
        }

        public ActionResult ReviewProject(int Id)
        {
            return View(_projectRepository.GetById(Id));
        }

        public ActionResult GetСheckingProjects()
        {
            return View(_projectRepository.GetAll().Where(p => p.Status == ProjectStatusEnum.OnReview));
        }

        public ActionResult BlockProject(int Id)
        {
            _projectRepository.GetById(Id).Status = ProjectStatusEnum.Blocked;
            _projectRepository.SaveChanges();
            return RedirectToAction("ReviewProject", new { Id = Id });
        }

        public ActionResult PublishProject(int Id)
        {
            Project reviewingProject = _projectRepository.GetById(Id);
            reviewingProject.Status = ProjectStatusEnum.Active;
            DateTime startDate = DateTime.Now;
            reviewingProject.StartDate = startDate;
            reviewingProject.EndDate = startDate.AddDays((int)FundingPeriod._30Days);
            _projectRepository.SaveChanges();
            return RedirectToAction("ReviewProject", new { Id = Id });
        }
    }
}
