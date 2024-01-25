using Business.Abstract;
using Business.Constants;
using Core.Utilities.Mail;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EMailConfigurationManager : IEmailConfigurationService
    {
        private readonly IEmailConfigurationDal _emailConfigurationDal;

        public EMailConfigurationManager(IEmailConfigurationDal emailConfigurationDal)
        {
            _emailConfigurationDal = emailConfigurationDal;
        }



        public IResult Delete(EmailConfiguration emailConfiguration)
        {
            _emailConfigurationDal.Delete(emailConfiguration);
            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        public IDataResult<EmailConfiguration> Get()
        {
            return new SuccessDataResult<EmailConfiguration>(_emailConfigurationDal.GetAll().First());
        }

        public IResult Update(EmailConfiguration emailConfiguration)
        {
            _emailConfigurationDal.Update(emailConfiguration);
            return new SuccessResult(Messages.SuccesfullyUpdated);
        }
    }
}
