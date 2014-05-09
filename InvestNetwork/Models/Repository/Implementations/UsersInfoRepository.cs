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
    public class UsersInfoRepository : IUsersInfoRepository
    {
        private IRepository<UsersInfo> usersInfoRepository;

        public UsersInfoRepository(IRepository<UsersInfo> usersInfoRepository)
        {
            this.usersInfoRepository = usersInfoRepository;
        }

        public UsersInfo GetById(int id)
        {
            if (id == 0)
                return null;
            return usersInfoRepository.GetById(id);
        }

        public UsersInfo GetByUserId(int id)
        {
            try
            {
                if (id == 0)
                    return null;
                return usersInfoRepository.GetAll().Where(u => u.UserID == id).Single();
            }
            catch
            {
                return null;
            }
        }

        public void Insert(UsersInfo model)
        {
            if (model == null)
                throw new ArgumentNullException("usersInfo");
            usersInfoRepository.Insert(model);
        }

        public void Update(UsersInfo model)
        {
            if (model == null)
                throw new ArgumentNullException("usersInfo");
            usersInfoRepository.Update(model);

        }

        public void Delete(UsersInfo model)
        {
            if (model == null)
                throw new ArgumentNullException("usersInfo");
            usersInfoRepository.Delete(model);
        }

        //public bool ValidateUser(string email, string password)
        //{
        //    return usersInfoRepository.GetAll().Any(user => string.Equals(user.Email, email) && string.Equals(user.Password, password));
        //}

        public void SaveChanges()
        {
            usersInfoRepository.SaveChanges();
        }
    }
}

