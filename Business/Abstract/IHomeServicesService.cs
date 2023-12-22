using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IHomeServicesService
    {
        IResult Add(HomeServices homeServices);
        IResult Update(HomeServices homeServices);
        IResult Delete(HomeServices homeServices);
        IDataResult<List<HomeServices>> GetAll();
    }
}
