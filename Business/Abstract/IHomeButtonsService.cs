using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IHomeButtonsService
    {
       
        IResult Update(HomeButtons homeButtons);
        
        IDataResult<HomeButtons> Get();
    } 
}
