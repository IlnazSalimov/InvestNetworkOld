using Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvestNetwork.Models
{
    [MetadataType(typeof(ProjectMetaData))]
    public partial class Project
    {
        private IUserRepository _userRepository;

        public string AuthorFullName
        {
            get
            {
                _userRepository = DependencyResolver.Current.GetService<IUserRepository>();
                return _userRepository.GetById(this.AuthorID).FullName;
            }
        }
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