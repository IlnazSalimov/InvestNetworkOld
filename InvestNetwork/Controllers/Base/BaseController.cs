using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvestNetwork.Models;
using Ninject;

namespace InvestNetwork.Controllers
{
    public class BaseController : Controller
    {
        [Inject]
        public IAuthentication Auth { get; set; }
        
        public User CurrentUser
        {
            get
            {
                return ((UserIndentity)Auth.CurrentUser.Identity).User;
            }
        }

    }
}
