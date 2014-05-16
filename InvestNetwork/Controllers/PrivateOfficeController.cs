using InvestNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Configuration;

namespace InvestNetwork.Controllers
{
    public class PrivateOfficeController : Controller
    {
        //
        // GET: /UsersInfo/
        private readonly IUsersInfoRepository _usersInfoRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IInvestContext _investContext;

        public PrivateOfficeController(IUserRepository userRepository, IUsersInfoRepository usersInfoRepository, 
                                       IMessageRepository messageRepository, IInvestContext investContext)
        {
            _userRepository = userRepository;
            _usersInfoRepository = usersInfoRepository;
            _messageRepository = messageRepository;
            _investContext = investContext;
        }

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            User user = _investContext.CurrentUser;

            ViewBag.usersInfo = _usersInfoRepository.GetByUserId(user.Id);
            ViewBag.messages = _messageRepository.GetByUserId(user.Id);
            ViewBag.partycipations = _usersInfoRepository.GetPartycipation(user.ID);
            UserSettings userSettings = new UserSettings();
            
            userSettings.Avatar = user.Avatar;
            userSettings.Email = user.Email;
            userSettings.FullName = user.FullName;
            userSettings.Id = user.Id;
            userSettings.PostNotice = user.PostNotice;
            userSettings.RoleId = user.RoleId;

            ViewBag.userSettings = userSettings;

            return View(user);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            User user = _investContext.CurrentUser;

            ViewBag.usersInfo = _usersInfoRepository.GetByUserId(user.Id);
            ViewBag.messages = _messageRepository.GetByUserId(user.Id);
            ViewBag.partycipations = _usersInfoRepository.GetPartycipation(user.ID);
            UserSettings userSettings = new UserSettings();

            userSettings.Avatar = user.Avatar;
            userSettings.Email = user.Email;
            userSettings.FullName = user.FullName;
            userSettings.Id = user.Id;
            userSettings.PostNotice = user.PostNotice;
            userSettings.RoleId = user.RoleId;

            ViewBag.userSettings = userSettings;
            try
            {
                if ((file != null && file.ContentLength > 0))
                {
                    string relativePathOfDir = Path.Combine(
                        ConfigurationManager.AppSettings["FileUploadDirectory"].ToString(),
                        "user" + user.ID.ToString());
                    string FullPathOfDir = Server.MapPath(relativePathOfDir);
                    if (!Directory.Exists(FullPathOfDir))
                    {
                        Directory.CreateDirectory(FullPathOfDir);
                    }
                    string savedFilePath = Path.Combine(FullPathOfDir, file.FileName);
                    string relativeFilePath = Path.Combine(relativePathOfDir, file.FileName);
                    if (System.IO.File.Exists(savedFilePath))
                    {
                        System.IO.File.Delete(savedFilePath);
                    }
                    file.SaveAs(savedFilePath);

                    user.Avatar = relativeFilePath;
                    userSettings.Avatar = user.Avatar;
                    _userRepository.Update(user);
                    _userRepository.SaveChanges();
                }
                else
                {
                    return View(user);
                }
            }
            catch
            {
                return View(user);
            }
            return View(user);
        }
    }
}
