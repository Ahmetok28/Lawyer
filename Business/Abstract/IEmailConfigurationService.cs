using Core.Utilities.Mail;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IEmailConfigurationService
    {
       
        IResult Delete(EmailConfiguration emailConfiguration);
        IResult Update(EmailConfiguration emailConfiguration);       
        IDataResult<EmailConfiguration> Get();
    }
}
