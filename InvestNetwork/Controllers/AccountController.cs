using InvestNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace InvestNetwork.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public AccountController(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        //TODO: Нужно создать модели-витрины где-нибудь в отдельной папке.
        /*[HttpPost]
        public ActionResult SignUp(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                _userRepository.Insert(new User { FullName = model.FullName, Email = model.Email, Password = model.Password });
                _userRepository.Save();
                FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }*/

        /*public ActionResult SetAdminRole()
        {
            if (User.Identity.IsAuthenticated)
            {
                User currentUser = _userRepository.GetAll().SingleOrDefault(user => string.Equals(user.Email, User.Identity.Name));
                currentUser.Roles.Add(_roleRepository.GetAll().SingleOrDefault(role => string.Equals(role.RoleName, "Admin")));
                _userRepository.Update(currentUser);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }*/

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        //TODO: Нужно создать модели-витрины где-нибудь в отдельной папке.
        /*[HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                string email = model.Email;
                string password = model.Password;

                if (_userRepository.ValidateUser(email, password))
                {
                    FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Имя пользователя или пароль является не корректным.");
                }
            }

            return View(model);
        }*/

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}
