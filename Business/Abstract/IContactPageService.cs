using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IContactPageService
    {
        IResult Add(ContactPage contactPage);
        IResult Update(ContactPage contactPage);
        IResult Delete(ContactPage contactPage);
        IDataResult<ContactPage> GetContactPage();
        
    }
}
