using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestNetwork.Models
{
    public interface ICityRepository
    {
        List<City> GetAll();
        City GetById(int id);
    }
}
