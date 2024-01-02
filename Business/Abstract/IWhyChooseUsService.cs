using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IWhyChooseUsService
    {
        IResult Add(WhyChooseUs whyChooseUs);
        IResult Update(WhyChooseUs whyChooseUs);
        IResult Delete(WhyChooseUs WhyChooseUs);
        IDataResult<WhyChooseUs> GetWhyChooseUsById(int id);
        IDataResult<List<WhyChooseUs>> GetAll();
        IDataResult<List<WhyChooseUsDTO>> GetAllWithLogos();
    }
}
