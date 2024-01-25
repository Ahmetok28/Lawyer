using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ISuscriberService
    {
        IResult Add(Subscriber subscriber);
        IResult Update(Subscriber subscriber);
        IResult Delete(Subscriber subscriber);
        IDataResult<List<Subscriber>> GetAll();
    } 
}
