using Core.Utilities.Results;
using Entities.Concrete;
namespace Business.Abstract
{
    public interface IWebMetaSettingService
    {
        IResult Add(WebMetaSetting webMetaSetting);
        IResult Update(WebMetaSetting webMetaSetting);
        IResult Delete(WebMetaSetting webMetaSetting);
      
        IDataResult<WebMetaSetting> Get();
    }
}
