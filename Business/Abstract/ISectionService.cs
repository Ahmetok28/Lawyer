using Core.Utilities.Results;
using Entities.Concrete;
namespace Business.Abstract
{
    public interface ISectionService
    {
        IResult Add(Section section);
        IResult Update(Section section);
        IResult Delete(Section section);
        IDataResult<List<Section>> GetSectionByPracticeAreaId(int id);
        IDataResult<List<Section>> GetAll();
    }
}
