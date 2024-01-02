using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WhyChooseLogoManager : IWhyChooseLogoService
    {
        private readonly IWhyChooseLogoDal _logodal;

        public WhyChooseLogoManager(IWhyChooseLogoDal logodal)
        {
            _logodal = logodal;
        }

        public IResult Add(WhyChooseLogo whyChooseLogo)
        {
            _logodal.Add(whyChooseLogo);
            return new SuccessResult();
        }

        public IResult Delete(WhyChooseLogo whyChooseLogo)
        {
            _logodal.Delete(whyChooseLogo);
            return new SuccessResult();
        }

        public IDataResult<List<WhyChooseLogo>> GetAll()
        {
            return new SuccessDataResult<List<WhyChooseLogo>>(_logodal.GetAll());
        }

        public IDataResult<WhyChooseLogo> GetById(int id)
        {
            return new SuccessDataResult<WhyChooseLogo>(_logodal.Get(x=>x.Id==id));
        }

        public IResult Update(WhyChooseLogo whyChooseLogo)
        {
            _logodal.Update(whyChooseLogo);
            return new SuccessResult();
        }
    }
}
