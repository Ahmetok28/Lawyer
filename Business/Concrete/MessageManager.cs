using Business.Abstract;
using Bussines.BusinessAspects.Autofac;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        [SecuredOperation("Admin,Moderator")]
        public void Add(Message message)
        {
           _messageDal.Add(message);
        }
        [SecuredOperation("Admin,Moderator")]
        public void Delete(Message message)
        {
            throw new NotImplementedException();
        }

        public Message GetMessage()
        {
            throw new NotImplementedException();
        }
        [SecuredOperation("Admin,Moderator")]
        public void Update(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
