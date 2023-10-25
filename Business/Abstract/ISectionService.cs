using Entities.Concrete;
namespace Business.Abstract
{
    public interface ISectionService
    {
        void Add(Section section);
        void Update(Section section);
        void Delete(Section section);
        List<Section> GetSectionByPracticeAreaId(int id);
        List<Section> GetAll();
    }
}
