using InvestNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

namespace InvestNetwork.Api
{
    public class ProjectController : EntitySetController<ProjectDto, int>
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            this._projectRepository = projectRepository;
        }

        public override IQueryable<ProjectDto> Get()
        {
            List<ProjectDto> pr = _projectRepository.GetAll().Select(p => new ProjectDto
            {
                ProjectID = p.ProjectID,
                AuthorID = p.AuthorID,
                //LocationCityID = p.LocationCityID.Value,
                Name = p.Name,
                ScopeID = p.ScopeID,
                Description = p.Description,
                LinkToBusinessPlan = p.LinkToBusinessPlan,
                LinkToFinancialPlan = p.LinkToGuaranteeLetter,
                LinkToVideoPresentation = p.LinkToVideoPresentation,
                LinkToGuaranteeLetter = p.LinkToGuaranteeLetter,
                ProjectStatusID = p.ProjectStatusID,
                //StartDate = p.StartDate.Value,
                CreateDate = p.CreateDate,
                LinkToImg = p.LinkToImg,
                //EndDate = p.EndDate.Value,
                //NecessaryFunding = p.NecessaryFunding.Value,
                ShortDescription = p.ShortDescription,
                //FundingDuration = p.FundingDuration.Value,
                IsInspected = p.IsInspected,
                ProjectFilesDirectory = p.ProjectFilesDirectory
            }).ToList();
            return pr.AsQueryable();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
