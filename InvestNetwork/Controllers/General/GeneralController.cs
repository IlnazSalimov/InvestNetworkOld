using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvestNetwork.Models;

namespace InvestNetwork.Controllers
{
    public class GeneralController : Controller
    {
        //
        // GET: /General/

        public AccountDto GetAccount()
        {
            AccountDto account = (this.Session["AccountInfo"] as AccountDto);

            return account;
        }

    }
}
