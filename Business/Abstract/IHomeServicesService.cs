using Entities.Concrete;

namespace Business.Abstract
{
    public interface IHomeServicesService
    {
        void Add(HomeServices homeServices);
        void Update(HomeServices homeServices);
        void Delete(HomeServices homeServices);
        List<HomeServices> GetAll();
    }
}
