﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Bussines.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Validation;
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

        [ValidationAspect(typeof(MessageValidator))]
        public IResult Add(Message message)
        {
            _messageDal.Add(message);
            return new SuccessResult(Messages.SuccesfullyAdded);
        }
        [SecuredOperation("Admin,Editor")]
        public IResult Delete(Message message)
        {
            _messageDal.Delete(message);
            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        public IDataResult<List<Message>> GetAll()
        {
            return new SuccessDataResult<List<Message>>(_messageDal.GetAll());
        }

        public IDataResult<Message> GetMessage(int id)
        {
            return new SuccessDataResult<Message>(_messageDal.Get(x=>x.Id==id));
        }
        [SecuredOperation("Admin,Editor")]
        public IResult Update(Message message)
        {
            _messageDal.Update(message);
            return new SuccessResult(Messages.SuccesfullyUpdated);
        }
    }
}
