using Core.DataAccess.EntityFramework;
using Core.Utilities.Mail;
using DataAccess.Abstract;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfEmailConfigurationDal : EfEntityRepositoryBase<EmailConfiguration, Context>, IEmailConfigurationDal
    {
    }
}
