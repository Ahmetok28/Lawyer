using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IFooterSocialAndSayingService
    {
             
        IResult Update(FooterSocialAndSaying socialMedia);      
        IDataResult<FooterSocialAndSaying> Get();
    }
}
