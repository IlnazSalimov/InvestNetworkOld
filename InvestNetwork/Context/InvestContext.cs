using InvestNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace InvestNetwork
{
    public class InvestContext : IInvestContext
    {
        private const string COOKIENAME = "__AUTH_COOKIE";
        private HttpContext HttpContext { get; set; }
        private IUserRepository _userRepository;

        public InvestContext(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        private IPrincipal _currentUser;

        public IPrincipal CurrentUser
        {
            get
            {
                try
                {
                    HttpCookie authCookie = HttpContext.Request.Cookies.Get(COOKIENAME);
                    if (authCookie != null && !string.IsNullOrEmpty(authCookie.Value))
                    {
                        var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                        _currentUser = new UserProvider(ticket.Name, _userRepository);
                    }
                    else
                    {
                        _currentUser = null;
                    }
                }
                catch (Exception ex)
                {
                    _currentUser = null;
                }

                return _currentUser;
            }
        }

        public void SetAuthCookie(string email, bool isPersistent = false)
        {
            var ticket = new FormsAuthenticationTicket(
                  1,
                  email,
                  DateTime.Now,
                  DateTime.Now.Add(FormsAuthentication.Timeout),
                  isPersistent,
                  string.Empty,
                  FormsAuthentication.FormsCookiePath);

            // Encrypt the ticket.
            var encTicket = FormsAuthentication.Encrypt(ticket);

            // Create the cookie.
            var AuthCookie = new HttpCookie(COOKIENAME)
            {
                Value = encTicket,
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout)
            };
            HttpContext.Response.Cookies.Set(AuthCookie);
        }
    }
}
