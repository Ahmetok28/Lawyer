using Business.Abstract;
using Business.Constants;
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
    public class SuscriberManager : ISuscriberService
    {
        private readonly ISuscriberDal _suscriberDal;

        public SuscriberManager(ISuscriberDal suscriberDal)
        {
            _suscriberDal = suscriberDal;
        }

        public IResult Add(Subscriber subscriber)
        {
           var val=CheckIfEmailAlreadyExist(subscriber);
            if (val.Success)
            {
                _suscriberDal.Add(subscriber);

                return new SuccessResult();
            }
            return new ErrorResult(Messages.MailAlreadyExist);
        }

        public IResult Delete(Subscriber subscriber)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Subscriber>> GetAll()
        {
            return new SuccessDataResult<List<Subscriber>>( _suscriberDal.GetAll());
        }

        public IResult Update(Subscriber subscriber)
        {
            _suscriberDal.Update(subscriber);
            return new SuccessResult();
        }
        private IResult CheckIfEmailAlreadyExist(Subscriber subscriber)
        {
            var suscribe=  _suscriberDal.Get(x => x.EMail == subscriber.EMail);
            if (suscribe==null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
