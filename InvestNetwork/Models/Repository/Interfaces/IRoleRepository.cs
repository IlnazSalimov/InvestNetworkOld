using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestNetwork.Models
{
    public interface IRoleRepository
    {
        List<Role> GetAll();
        Role GetById(int id);
        void Insert(Role model);
        void Update(Role model);
        void Delete(Role model);
        void SaveChanges();
    }
}
