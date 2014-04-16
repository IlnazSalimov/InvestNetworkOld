using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Ninject;

namespace InvestNetwork.Models
{
    public class UserIndentity : IIdentity, IUserProvider
    {
        /// <summary>
        /// Текщий пользователь
        /// </summary>
        public User User { get; set; }

        public string AuthenticationType
        {
            get
            {
                return typeof(User).ToString();
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return User != null;
            }
        }

        public string Name
        {
            get
            {
                if (User != null)
                {
                    return User.Email;
                }
                //иначе аноним
                return "anonym";
            }
        }

        public void Init(string email, IUserRepository repository)
        {
            if (!string.IsNullOrEmpty(email))
            {
                User = repository.GetByEmail(email);
            }
        }
    }
}