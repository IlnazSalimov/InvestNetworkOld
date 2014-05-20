using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestNetwork.Models
{
    public class ProjectDto
    {
        public int ProjectID { get; set; }
        public int AuthorID { get; set; }
        public int LocationCityID { get; set; }
        public string Name { get; set; }
        public int ScopeID { get; set; }
        public string Description { get; set; }
        public string LinkToBusinessPlan { get; set; }
        public string LinkToFinancialPlan { get; set; }
        public string LinkToVideoPresentation { get; set; }
        public string LinkToGuaranteeLetter { get; set; }
        public int ProjectStatusID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string LinkToImg { get; set; }
        public DateTime EndDate { get; set; }
        public decimal NecessaryFunding { get; set; }
        public string ShortDescription { get; set; }
        public int FundingDuration { get; set; }
        public bool IsInspected { get; set; }
        public string ProjectFilesDirectory { get; set; }
    }
}