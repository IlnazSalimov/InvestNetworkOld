using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestNetwork.Models
{
    public class SignupUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public bool RememberMe { get; set; }
    }
}