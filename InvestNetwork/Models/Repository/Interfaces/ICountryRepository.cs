using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestNetwork.Models
{
    public interface ICountryRepository
    {
        List<Country> GetAll();
        Country GetById(int id);
    }
}
