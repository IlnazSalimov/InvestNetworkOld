using InvestNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestNetwork
{
    public interface IUserProvider
    {
        User User { get; set; }
    }
}
