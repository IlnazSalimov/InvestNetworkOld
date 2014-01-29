using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using InvestNetwork.Core;
using System.Linq.Expressions;

namespace InvestNetwork.Models
{
    public class UserRepository : IUserRepository
    {
        private IRepository<User> userRepository;

        public UserRepository(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }
        public List<User> GetAll()
        {
            return userRepository.GetAll().ToList();
        }

        public User GetById(int id)
        {
            if (id == 0)
                return null;
            return userRepository.GetById(id);
        }

        public void Insert(User model)
        {
            if (model == null)
                throw new ArgumentNullException("user");
            userRepository.Insert(model);
        }

        public void Update(User model)
        {
            if (model == null)
                throw new ArgumentNullException("user");
            userRepository.Update(model);

        }

        public void Delete(User model)
        {
            if (model == null)
                throw new ArgumentNullException("user");
            userRepository.Delete(model);
        }

        public bool ValidateUser(string email, string password)
        {
            return userRepository.GetAll().Any(user => string.Equals(user.Email, email) && string.Equals(user.Password, password));
        }

        public void Save()
        {
            userRepository.Save();
        }
    }
}

