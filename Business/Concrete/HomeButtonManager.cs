using Business.Abstract;
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
    public class HomeButtonManager : IHomeButtonsService
    {
        private readonly IHomeButtonDal _homeButtonDal;

        public HomeButtonManager(IHomeButtonDal homeButtonDal)
        {
            _homeButtonDal = homeButtonDal;
        }

        public IDataResult<HomeButtons> Get()
        {
            return new SuccessDataResult<HomeButtons>(_homeButtonDal.GetAll().FirstOrDefault());
        }

        public IResult Update(HomeButtons homeButtons)
        {
            _homeButtonDal.Update(homeButtons);
            return new SuccessResult();
        }
    }
}
