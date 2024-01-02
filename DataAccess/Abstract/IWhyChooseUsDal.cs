using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IWhyChooseUsDal : IEntityRepository<WhyChooseUs>
    {
        List<WhyChooseUsDTO> GetAllWithLogos(Expression<Func<WhyChooseUsDTO, bool>> filter = null);
    } 
}
