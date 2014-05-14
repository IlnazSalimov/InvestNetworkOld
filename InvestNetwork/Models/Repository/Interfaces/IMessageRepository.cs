using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestNetwork.Models
{
    public interface IMessageRepository
    {
        List<Message> GetAll();
        Message GetById(int id);
        List<Message> GetByUserId(int id);
        void Insert(Message model);
        void Update(Message model);
        void Delete(Message model);
        void SaveChanges();
    }
}
