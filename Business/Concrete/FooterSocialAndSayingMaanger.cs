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
    public class FooterSocialAndSayingMaanger : IFooterSocialAndSayingService
    {
        private readonly IFooterSocialAndSayingDal _socialMediaDal;

        public FooterSocialAndSayingMaanger(IFooterSocialAndSayingDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public IDataResult<FooterSocialAndSaying> Get()
        {
            return new SuccessDataResult<FooterSocialAndSaying>(_socialMediaDal.GetAll().SingleOrDefault());
        }

        public IResult Update(FooterSocialAndSaying socialMedia)
        {
            _socialMediaDal.Update(socialMedia);
            return new SuccessResult();
        }
    }
}
