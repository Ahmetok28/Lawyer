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
    public class MetaSettingManager : IWebMetaSettingService
    {
        private readonly IMetaValuesDal _metaSetting;

        public MetaSettingManager(IMetaValuesDal metaSetting)
        {
            _metaSetting = metaSetting;
        }

        public IResult Add(WebMetaSetting webMetaSetting)
        {
            _metaSetting.Add(webMetaSetting);
            return new SuccessResult();
        }

        public IResult Delete(WebMetaSetting webMetaSetting)
        {
            _metaSetting.Delete(webMetaSetting);
            return new SuccessResult();
        }

        public IDataResult<WebMetaSetting> Get()
        {
           return new SuccessDataResult<WebMetaSetting>(_metaSetting.GetAll().FirstOrDefault());
        }

        public IResult Update(WebMetaSetting webMetaSetting)
        {
            _metaSetting.Update(webMetaSetting);
            return new SuccessResult();
        }
    }
}
