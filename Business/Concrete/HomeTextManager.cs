using Business.Abstract;
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
    public class HomeTextManager:IHomeTextService
    {
        private readonly IHomeTextDal _homeTextDal;

        public HomeTextManager(IHomeTextDal homeTextDal)
        {
            _homeTextDal = homeTextDal;
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Add(HomeText homeText)
        {
            _homeTextDal.Add(homeText);
            return new SuccessResult(Messages.SuccesfullyAdded);
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Delete(HomeText homeText)
        {
            _homeTextDal.Delete(homeText);
            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        public IDataResult< HomeText> GetHomeText()
        {
            return  new SuccessDataResult<HomeText>( _homeTextDal.GetAll().First());
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Update(HomeText homeText)
        {
            _homeTextDal.Update(homeText);
            return new SuccessResult(Messages.SuccesfullyUpdated);
        }
    }
}
