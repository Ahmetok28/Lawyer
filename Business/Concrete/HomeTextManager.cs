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
    public class HomeTextManager:IHomeTextService
    {
        private readonly IHomeTextDal _homeTextDal;

        public HomeTextManager(IHomeTextDal homeTextDal)
        {
            _homeTextDal = homeTextDal;
        }
        [SecuredOperation("Admin,Moderator")]
        public void Add(HomeText homeText)
        {
            _homeTextDal.Add(homeText);
        }
        [SecuredOperation("Admin,Moderator")]
        public void Delete(HomeText homeText)
        {
            _homeTextDal.Delete(homeText);
        }

        public HomeText GetHomeText()
        {
            return _homeTextDal.GetAll().First();
        }
        [SecuredOperation("Admin,Moderator")]
        public void Update(HomeText homeText)
        {
            _homeTextDal.Update(homeText);
        }
    }
}
