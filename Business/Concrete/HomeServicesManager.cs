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
    public class HomeServicesManager:IHomeServicesService
    {
        private readonly IHomeServicesDal _homeServicesDal;

        public HomeServicesManager(IHomeServicesDal homeServicesDal)
        {
            _homeServicesDal = homeServicesDal;
        }

        public void Add(HomeServices homeServices)
        {
            throw new NotImplementedException();
        }

        public void Delete(HomeServices homeServices)
        {
            throw new NotImplementedException();
        }

        public List<HomeServices> GetAll()
        {
           return _homeServicesDal.GetAll();
        }

        public void Update(HomeServices homeServices)
        {
            throw new NotImplementedException();
        }
    }
}
