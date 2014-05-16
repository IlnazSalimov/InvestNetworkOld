using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvestNetwork.Models;

namespace InvestNetwork.Controllers
{
    public class ProfileController : Controller
    {
        readonly private IUserRepository userRepository;
        readonly private IUsersInfoRepository usersInfoRepository;
        readonly private IProjectRepository projectRepository;

        public ProfileController(IUserRepository userRepository, IUsersInfoRepository usersInfoRepository, IProjectRepository projectRepository)
        {
            this.userRepository = userRepository;
            this.usersInfoRepository = usersInfoRepository;
            this.projectRepository = projectRepository;
        }

        [HttpGet]
        public ActionResult GetProfile(int id)
        {
            UserProfile profile = new UserProfile()
            {
                User = userRepository.GetById(id),
                UsersInfo = usersInfoRepository.GetByUserId(id),
                Projects = projectRepository.GetAll().Where(e => e.AuthorID == id).ToList()
            };

            return View(profile);
        }

    }
}
