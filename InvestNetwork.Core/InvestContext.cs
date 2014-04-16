using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestNetwork.Core
{
    public class InvestContext : 
    {

        public AccountDto GetAccount()
        {
            HttpContext
            AccountDto account = ( Session["AccountInfo"] as AccountDto);

            return account;
        }
    }
}
