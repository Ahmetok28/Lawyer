using Business.Abstract;
using Business.Constants;
using Core.Aspect.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WhyChooseUsManager : IWhyChooseUsService
    {
        private readonly IWhyChooseUsDal _whyChooseUsDal;

        public WhyChooseUsManager(IWhyChooseUsDal whyChooseUsDal)
        {
            _whyChooseUsDal = whyChooseUsDal;
        }
        [CacheRemoveAspect("IWhyChooseUsService.Get")]
        public IResult Add(WhyChooseUs whyChooseUs)
        {
            _whyChooseUsDal.Add(whyChooseUs);
            return new SuccessResult(Messages.SuccesfullyAdded);
        }
        [CacheRemoveAspect("IWhyChooseUsService.Get")]
        public IResult Delete(WhyChooseUs WhyChooseUs)
        {
            _whyChooseUsDal.Delete(WhyChooseUs);
            return new SuccessResult(Messages.SuccesfullyDeleted);
        }
        [CacheAspect]
        public IDataResult<List<WhyChooseUs>> GetAll()
        {
            return new SuccessDataResult<List<WhyChooseUs>>(_whyChooseUsDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<List<WhyChooseUsDTO>> GetAllWithLogos()
        {
            return new SuccessDataResult<List<WhyChooseUsDTO>>(_whyChooseUsDal.GetAllWithLogos());
        }

        public IDataResult<WhyChooseUs> GetWhyChooseUsById(int id)
        {
            return new SuccessDataResult<WhyChooseUs>(_whyChooseUsDal.Get(x=>x.Id== id));
        }
        [CacheRemoveAspect("IWhyChooseUsService.Get")]
        public IResult Update(WhyChooseUs whyChooseUs)
        {
            _whyChooseUsDal.Update(whyChooseUs);
            return new SuccessResult(Messages.SuccesfullyUpdated);
        }
    }
}
