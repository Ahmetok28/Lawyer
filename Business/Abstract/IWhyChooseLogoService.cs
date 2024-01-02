using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IWhyChooseLogoService
    {
        IResult Add(WhyChooseLogo whyChooseLogo);
        IResult Delete(WhyChooseLogo whyChooseLogo);
        IResult Update(WhyChooseLogo whyChooseLogo);
        IDataResult<List<WhyChooseLogo>> GetAll();
        IDataResult<WhyChooseLogo> GetById(int id);
    }
}
