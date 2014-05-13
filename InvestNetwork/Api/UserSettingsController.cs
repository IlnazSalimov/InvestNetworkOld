using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using InvestNetwork.Models;

namespace InvestNetwork.Api
{
    public class UserSettingsController : ApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IInvestContext _investContext;

        public UserSettingsController(IUserRepository userRepository, IInvestContext investContext)
        {
            _userRepository = userRepository;
            _investContext = investContext;
        }

        [Authorize]
        [HttpPost]
        public object Edit(UserSettings model)
        {
            User user = _investContext.CurrentUser;

            if (model.NewPassword != null)
            {

                if (!model.OldPassword.Equals(user.Password))
                {
                    return new { isSuccess = false, errorMessage = "Действующий пароль введен неверно", successMessage = "" };
                }

                if (!model.NewPassword.Equals(model.ConfirmPassword))
                {
                    return new { isSuccess = false, errorMessage = "Подтвердите новый пароль", successMessage = "" };
                }

                user.Password = model.NewPassword.ToString();
            }

            if (model.Email == null)
            {
                model.Email = user.Email;
            }
            else
            {
                if (!model.Email.Equals(user.Email))
                {
                    var anyUser = _userRepository.GetAll().Any(p => p.Email.Equals(model.Email));
                    if (anyUser)
                    {
                        return new { isSuccess = false, errorMessage = "Пользователь с таким email уже зарегистрирован", successMessage = "" };
                    }

                    Regex rgx = new Regex("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*\\.([a-z]{2,4})$");
                    if (!rgx.IsMatch(model.Email))
                    {
                        return new { isSuccess = false, errorMessage = "Введен некорректный email", successMessage = "" };
                    }
                    user.Email = model.Email;
                }
            }

            if (model.FullName == null)
            {
                model.FullName = user.FullName;
            }
            else
            {
                if (!model.FullName.Equals(user.FullName))
                {
                    var anyUser = _userRepository.GetAll().Any(p => p.FullName.Equals(model.FullName));
                    if (anyUser)
                    {
                        return new { isSuccess = false, errorMessage = "Пользователь с таким именем уже зарегистрирован", successMessage = "" };
                    }
                }
                user.FullName = model.FullName;
            }

            if (model.Avatar == null)
            {
                model.Avatar = user.Avatar;
            }

            _userRepository.Update(user);

            _userRepository.SaveChanges();

            return new { isSuccess = true, errorMessage = "", successMessage = "Данные успешно сохранены" };
        }
    }
}
