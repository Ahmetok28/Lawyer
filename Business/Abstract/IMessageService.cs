using Entities.Concrete;

namespace Business.Abstract
{
    public interface IMessageService
    {
        void Add(Message message);
        void Update(Message message);
        void Delete(Message message);
        Message GetMessage();
    }
}
