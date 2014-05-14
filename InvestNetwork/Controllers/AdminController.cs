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

        public ActionResult GetReviewingProjects()
        {

            return View(_projectRepository.GetAll().Where(p => p.Status == ProjectStatusEnum.OnReview));
        }

        public ActionResult GetInspectingProjects()
        {
            return View(_projectRepository.GetAll().Where(p => !p.IsInspected));
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
            reviewingProject.IsInspected = true;
            _projectRepository.SaveChanges();
            return RedirectToAction("ReviewProject", new { Id = Id });
        }

        public ActionResult ApproveProject(int Id)
        {
            Project reviewingProject = _projectRepository.GetById(Id);
            reviewingProject.IsInspected = true;
            _projectRepository.SaveChanges();
            return RedirectToAction("ReviewProject", new { Id = Id });
        }
    }
}
