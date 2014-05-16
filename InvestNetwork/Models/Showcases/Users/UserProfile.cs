using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestNetwork.Models
{
    public class UserProfile
    {
        public User User { set; get; }
        public UsersInfo UsersInfo { set; get; }
        public List<Project> Projects { set; get; }
    }
}