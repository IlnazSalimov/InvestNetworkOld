using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestNetwork.Models
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
        void Insert(User model);
        void Update(User model);
        void Delete(User model);
        bool ValidateUser(string email, string password);
        void Save();
    }
}
