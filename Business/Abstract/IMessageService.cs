using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IMessageService
    {
        IResult Add(Message message);
        IResult Update(Message message);
        IResult Delete(Message message);
        IDataResult<Message> GetMessage(int id);
    }
}
