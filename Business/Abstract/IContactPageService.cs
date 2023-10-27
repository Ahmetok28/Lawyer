using Entities.Concrete;

namespace Business.Abstract
{
    public interface IContactPageService
    {
        void Add(ContactPage contactPage);
        void Update(ContactPage contactPage);
        void Delete(ContactPage contactPage);
        ContactPage GetContactPage();
        
    }
}
