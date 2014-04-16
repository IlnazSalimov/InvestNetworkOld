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
        private readonly IInvestContext _investContext;

        public AccountController(IUserRepository userRepository, IRoleRepository roleRepository, IInvestContext investContext)
        {
            this._userRepository = userRepository;
            this._roleRepository = roleRepository;
            this._investContext = investContext;
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

        [HttpPost]
        public ActionResult SignUp(SignupUser model)
        {
            if (ModelState.IsValid)
            {
                _userRepository.Insert(new User { FullName = model.FullName, Email = model.Email, Password = model.Password });
                _userRepository.Save();
                FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

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


        [HttpPost]
        public ActionResult Login(LoginUser model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_userRepository.Login(model.Email, model.Password) != null)
                {
                    _investContext.SetAuthCookie(model.Email, model.RememberMe);
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
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
