using InvestNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace InvestNetwork
{
    public interface IInvestContext
    {
        IPrincipal CurrentUser { get; }
        void SetAuthCookie(string email, bool isPersistent = false);
    }
}
