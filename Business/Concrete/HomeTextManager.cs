using Business.Abstract;
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

        public void Add(HomeText homeText)
        {
            _homeTextDal.Add(homeText);
        }

        public void Delete(HomeText homeText)
        {
            _homeTextDal.Delete(homeText);
        }

        public HomeText GetHomeText()
        {
            return _homeTextDal.GetAll().First();
        }

        public void Update(HomeText homeText)
        {
            _homeTextDal.Update(homeText);
        }
    }
}
