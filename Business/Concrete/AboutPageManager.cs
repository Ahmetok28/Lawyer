﻿using Business.Abstract;
using Business.Constants;
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
    public class AboutPageManager : IAboutPageService
    {
        private readonly IAboutPageDal _aboutPageDal;

        public AboutPageManager(IAboutPageDal aboutPageDal)
        {
            _aboutPageDal = aboutPageDal;
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Add(AboutPage aboutPage)
        {
            _aboutPageDal.Add(aboutPage);
            return new SuccessResult(Messages.SuccesfullyAdded);
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Delete(AboutPage aboutPage)
        {
            _aboutPageDal.Delete(aboutPage);
            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        public IDataResult<AboutPage> GetAboutPage()
        {
           return new SuccessDataResult<AboutPage>(_aboutPageDal.GetAll().First());
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Update(AboutPage aboutPage)
        {
           _aboutPageDal.Update(aboutPage);
            return new SuccessResult(Messages.SuccesfullyUpdated);
        }
    }
}
