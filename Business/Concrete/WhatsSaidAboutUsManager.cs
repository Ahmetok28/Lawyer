using Business.Abstract;
using Business.Constants;
using Core.Aspect.Autofac.Caching;
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
    public class WhatsSaidAboutUsManager : IWhatsSaidAboutUsService
    {
        private readonly IWhatSaidAboutUsDal _whatSaidAboutUsDal;

        public WhatsSaidAboutUsManager(IWhatSaidAboutUsDal whatSaidAboutUsDal)
        {
            _whatSaidAboutUsDal = whatSaidAboutUsDal;
        }
        [CacheRemoveAspect("IWhatsSaidAboutUsService.Get")]

        public IResult Add(WhatsSaidAboutUs whatsSaidAboutUs)
        {
            _whatSaidAboutUsDal.Add(whatsSaidAboutUs);
            return new SuccessResult(Messages.SuccesfullyAdded);
        }
        [CacheRemoveAspect("IWhatsSaidAboutUsService.Get")]
        public IResult Delete(WhatsSaidAboutUs whatsSaidAboutUs)
        {
            _whatSaidAboutUsDal.Delete(whatsSaidAboutUs);
            return new SuccessResult(Messages.SuccesfullyDeleted);
        }
        [CacheAspect]
        public IDataResult<List<WhatsSaidAboutUs>> GetAll()
        {
            return new SuccessDataResult<List<WhatsSaidAboutUs>>(_whatSaidAboutUsDal.GetAll());
        }
        
        public IDataResult<WhatsSaidAboutUs> GetWhatsSaidAboutUsById(int id)
        {
           return new SuccessDataResult<WhatsSaidAboutUs>(_whatSaidAboutUsDal.Get(x=>x.Id == id));
        }
        [CacheRemoveAspect("IWhatsSaidAboutUsService.Get")]
        public IResult Update(WhatsSaidAboutUs whatsSaidAboutUs)
        {
            _whatSaidAboutUsDal.Update(whatsSaidAboutUs);
            return new SuccessResult(Messages.SuccesfullyUpdated);
        }
    }
}
