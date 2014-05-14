using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using InvestNetwork.Models;

namespace InvestNetwork.Api
{
    public class MessageController : ApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IInvestContext _investContext;

        public MessageController(IUserRepository userRepository, IInvestContext investContext, IMessageRepository messageRepository)
        {
            _userRepository = userRepository;
            _messageRepository = messageRepository;
            _investContext = investContext;
        }

        [Authorize]
        [HttpPost]
        public bool Send(MessageSending model)
        {
            try
            {
                User user = _investContext.CurrentUser;

                Message msg = new Message()
                    {
                        FromUserID = user.Id,
                        MessageDate = DateTime.Now,
                        MessageText = model.Message,
                        ToUserID = model.ToUserID
                    };

                _messageRepository.Insert(msg);
                _messageRepository.SaveChanges();

                return true;
            }
            catch
            { return false; }
        }
    }
}
