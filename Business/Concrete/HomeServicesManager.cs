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
    public class HomeServicesManager:IHomeServicesService
    {
        private readonly IHomeServicesDal _homeServicesDal;

        public HomeServicesManager(IHomeServicesDal homeServicesDal)
        {
            _homeServicesDal = homeServicesDal;
        }

        public IResult Add(HomeServices homeServices)
        {
            _homeServicesDal.Add(homeServices);
            return new SuccessResult();
        }

        public IResult Delete(HomeServices homeServices)
        {
            _homeServicesDal.Delete(homeServices);
            return new SuccessResult();
        }

        public IDataResult< List<HomeServices>> GetAll()
        {
           return new SuccessDataResult<List<HomeServices>>( _homeServicesDal.GetAll());
        }

        public IResult Update(HomeServices homeServices)
        {
            _homeServicesDal.Update(homeServices);
            return new SuccessResult();
        }
    }
}
