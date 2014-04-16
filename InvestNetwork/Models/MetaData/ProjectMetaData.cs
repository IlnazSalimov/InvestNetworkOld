using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvestNetwork.Models
{
    [MetadataType(typeof(ProjectMetaData))]
    public partial class Project
    {
    }

    public class ProjectMetaData
    {
        [Required]
        [Display(Name = "Месторасположение")]
        public int LocationCityID { get; set; }

        [Required]
        [Display(Name = "Название проекта")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Сфера деятельности")]
        public int ScopeID { get; set; }

        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }

    }


}