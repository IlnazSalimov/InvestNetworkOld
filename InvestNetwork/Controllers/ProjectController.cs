using InvestNetwork.Application.Core;
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
        //private readonly IProjectNewsRepository _projectNewsRepository;
        private readonly IProjectCommentRepository _projectCommentRepository;
        private readonly IProjectStatusRepository _projectStatusRepository;
        private readonly IInvestContext _investContext;
        private const int PROJECT_COUNT_AT_THE_FIRST_VIEWING = 20;

        public ProjectController(IProjectRepository projectRepository, IProjectStatusRepository projectStatusRepository, 
                                 /*IProjectNewsRepository projectNewsRepository, */ IProjectCommentRepository projectCommentRepository,
                                 IInvestContext investContext)
        {
            this._projectRepository = projectRepository;
            //this._projectNewsRepository = projectNewsRepository;
            this._projectCommentRepository = projectCommentRepository;
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
        public ActionResult Start(ProjectStart model)
        {
            if (ModelState.IsValid)
            {
                Project project = new Project
                {
                    AuthorID = _investContext.CurrentUser.Id,
                    CreateDate = DateTime.Now,
                    Status = ProjectStatusEnum.Uncreated,
                    IsInspected = false,
                    ProjectFilesDirectory = "",
                    Name = model.Name,
                    FundingDuration = model.FundingDuration,
                    LocationCityID = model.LocationCityID,
                    NecessaryFunding = model.NecessaryFunding,
                    ScopeID = model.ScopeID,
                    ShortDescription = model.ShortDescription
                };

                try
                {
                    project.ProjectID = _projectRepository.Insert(project);
                    _projectRepository.SaveChanges();

                    string projectFilesDirectoryName = String.Format("project{0}in{1}", project.ID.ToString(), project.CreateDate.ToString("dd_MM_yyyy"));
                    string userDirRelPath = Path.Combine(ConfigurationManager.AppSettings["FileUploadDirectory"].ToString(), _investContext.CurrentUser.FilesBrowserDirectory);
                    string projectDirRelPath = Path.Combine(userDirRelPath, projectFilesDirectoryName);
                    
                    Directory.CreateDirectory(Server.MapPath(projectDirRelPath));
                    project.ProjectFilesDirectory = projectFilesDirectoryName;
                    
                    _projectRepository.SaveChanges();
                }
                catch (Exception ex) { }

                return RedirectToAction("CompleteSecondStepOfStart", new { Id = project.ID });
            }
            else
            {
                return View(model);
            }

            
        }

        [Authorize]
        public ActionResult CompleteSecondStepOfStart(int Id)
        {
            try
            {
                Project fillingProject = _projectRepository.GetById(Id);
                return View(new ProjectStartingSecondStep { 
                    ProjectID = fillingProject.ID,
                    ProjectFilesDirectory = fillingProject.ProjectFilesDirectory 
                });
            }
            catch (Exception ex) { }

            return Start();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CompleteSecondStepOfStart(ProjectStartingSecondStep model, HttpPostedFileBase LinkToImg)
        {
            if (ModelState.IsValid && (LinkToImg != null && LinkToImg.ContentLength > 0))
            {
                Project fillingProject = _projectRepository.GetById(model.ProjectID);
                fillingProject.Description = model.Description;
                fillingProject.Status = ProjectStatusEnum.Active;
                fillingProject.StartDate = DateTime.Now;
                fillingProject.EndDate = fillingProject.StartDate.Value.AddDays((int)fillingProject.FundingDuration.Value);
                fillingProject.LinkToImg = FileUploader.Upload(LinkToImg, fillingProject.ProjectFilesDirectory);
                
                _projectRepository.SaveChanges();

                return RedirectToAction("Discover");
            }
            else
            {
                return View(model);
            }

            
        }

        public ActionResult Discover()
        {
            return View(_projectRepository.GetAll().Where(p => p.Status == ProjectStatusEnum.Active).Take(PROJECT_COUNT_AT_THE_FIRST_VIEWING));
        }

        public ActionResult View(int id)
        {
            //ViewBag.projectNews = _projectNewsRepository.GetAll().Where(p => p.ProjectID == id).ToList();
            ViewBag.projectComments = _projectCommentRepository.GetByProjectId(id);
            ViewBag.user = _investContext.CurrentUser;
            return View(_projectRepository.GetById(id));
        }
    }
}
