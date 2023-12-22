using Business.Abstract;
using Bussines.BusinessAspects.Autofac;
using Core.Utilities.Results;
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
        public IResult Add(Message message)
        {
           _messageDal.Add(message);
            return new SuccessResult();
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Delete(Message message)
        {
            _messageDal.Delete(message);
            return new SuccessResult();
        }

        public IDataResult<Message> GetMessage(int id)
        {
            return new SuccessDataResult<Message>(_messageDal.Get(x=>x.Id==id));
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Update(Message message)
        {
            _messageDal.Update(message);
            return new SuccessResult();
        }
    }
}
