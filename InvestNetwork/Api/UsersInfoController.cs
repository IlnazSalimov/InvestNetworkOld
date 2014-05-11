using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InvestNetwork.Models;

namespace InvestNetwork.Api
{
    public class UsersInfoController : ApiController
    {
        private readonly IUsersInfoRepository _usersInfoRepository;
        private readonly IInvestContext _investContext;

        public UsersInfoController(IUsersInfoRepository usersInfoRepository, IInvestContext investContext)
        {
            _usersInfoRepository = usersInfoRepository;
            _investContext = investContext;
        }

        [Authorize]
        [HttpPost]
        public UsersInfo Edit(UsersInfo model)
        {
            if (model.DateOfBirth == DateTime.MinValue) return model;

            if (ModelState.IsValid)
            {
                User user = _investContext.CurrentUser;

                model.UserID = user.Id;
                UsersInfo usersInfo = _usersInfoRepository.GetByUserId(user.Id);

                if (usersInfo == null)
                {
                    model.RegisterDate = DateTime.Now;
                    _usersInfoRepository.Insert(model);
                }
                else
                {
                    model.UsersInfoID = usersInfo.UsersInfoID;
                    model.RegisterDate = usersInfo.RegisterDate;
                    _usersInfoRepository.Update(model);
                }

                _usersInfoRepository.SaveChanges();

            }
            return model;
        }
    }
}
