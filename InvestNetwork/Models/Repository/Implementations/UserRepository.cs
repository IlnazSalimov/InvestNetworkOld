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
        private IRoleRepository roleRepository;

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

        public User Login(string email, string password)
        {
            return userRepository.GetAll().FirstOrDefault(p => string.Compare(p.Email, email, true) == 0 && p.Password == password);
        }

        public void Save()
        {
            userRepository.Save();
        }

        public bool InRoles(string roles)
        {
            if (string.IsNullOrWhiteSpace(roles))
            {
                return false;
            }

            var rolesArray = roles.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var role in rolesArray)
            {
                var hasRole = roleRepository.GetAll().Any(p => string.Compare(p.RoleName, role, true) == 0);
                if (hasRole)
                {
                    return true;
                }
            }
            return false;
        }

        public User GetUser(string email)
        {
            return userRepository.GetAll().FirstOrDefault(p => string.Compare(p.Email, email, true) == 0);
        }
    }
}

