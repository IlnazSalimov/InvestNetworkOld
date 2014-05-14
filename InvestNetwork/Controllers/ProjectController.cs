using InvestNetwork.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
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
        public ActionResult Start(Project model, HttpPostedFileBase projectImg)
        {
            if (ModelState.IsValid)
            {
                DateTime now = DateTime.Now;

                model.AuthorID = _investContext.CurrentUser.Id;
                model.CreateDate = DateTime.Now;
                model.Status = ProjectStatusEnum.Active;
                model.LinkToBusinessPlan = "";
                model.LinkToFinancialPlan = "";
                model.LinkToGuaranteeLetter = "";
                model.LinkToVideoPresentation = "";
                model.LinkToImg = "";
                model.StartDate = now;
                model.EndDate = now.AddDays(model.FundingDuration);
                model.IsInspected = false;

                _projectRepository.Insert(model);
                _projectRepository.SaveChanges();


                if ((projectImg != null && projectImg.ContentLength > 0))
                {
                    string relativePath = Path.Combine(
                        ConfigurationManager.AppSettings["FileUploadDirectory"].ToString(),
                        model.ID.ToString() +
                        "in" +
                        model.CreateDate.ToString("dd_MM_yyyy"));
                    string FullPathOfDir = Server.MapPath(relativePath);
                    if (!Directory.Exists(FullPathOfDir))
                    {
                        Directory.CreateDirectory(FullPathOfDir);
                    }
                    string fileName = "full_photo.jpg";
                    string savedFilePath = Path.Combine(FullPathOfDir, fileName);
                    projectImg.SaveAs(savedFilePath);

                    model.LinkToImg = Path.Combine(relativePath, fileName);
                    _projectRepository.SaveChanges();
                }
                else
                {
                    return View(model);
                }
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
