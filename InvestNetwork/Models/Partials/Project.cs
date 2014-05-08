using InvestNetwork.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvestNetwork.Models
{
    [MetadataType(typeof(ProjectMetaData))]
    public partial class Project : IEntity
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

        public int ID
        {
            get { return this.ProjectID; }
        }
    }
}