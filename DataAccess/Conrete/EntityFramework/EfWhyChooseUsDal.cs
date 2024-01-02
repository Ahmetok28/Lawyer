using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfWhyChooseUsDal : EfEntityRepositoryBase<WhyChooseUs, Context>, IWhyChooseUsDal
    {
        public List<WhyChooseUsDTO> GetAllWithLogos(Expression<Func<WhyChooseUsDTO, bool>> filter = null)
        {
            using (Context context = new Context())
            {
                var results = from whyChUs in context.WhyChooses
                              join logo in context.WhyChooseLogos
                              on whyChUs.LogoId equals logo.Id
                              select new WhyChooseUsDTO
                              {
                                  WCUId= whyChUs.Id,
                                  Description=whyChUs.Description,
                                  Title=whyChUs.Title,
                                  LogoId=logo.Id,
                                  LogoName=logo.Name,
                                  LogoText=logo.Logo

                              };
                return filter == null ? results.ToList()
                                      : results.Where(filter).ToList();

            }
        }

    }
}
