using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAboutPageService
    {
        IResult Add(AboutPage aboutPage);
        IResult Update(AboutPage aboutPage);
        IResult Delete(AboutPage aboutPage);
        IDataResult<AboutPage> GetAboutPage();
    }
}
