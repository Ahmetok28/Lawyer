using Business.Abstract;
using Business.Constants;
using Bussines.BusinessAspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactPageManager : IContactPageService
    {

        private IContactPageDal _locationdal;

        public ContactPageManager(IContactPageDal locationdal)
        {
            _locationdal = locationdal;
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Add(ContactPage location)
        {
            _locationdal.Add(location);
            return new SuccessResult(Messages.SuccesfullyAdded);
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Delete(ContactPage location)
        {
            _locationdal.Delete(location);
            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        
        public IDataResult< ContactPage> GetContactPage()
        {            
            return new SuccessDataResult<ContactPage>( _locationdal.GetAll().FirstOrDefault());          
        }

        public IDataResult<ContactPage> GetContactPageById(int id)
        {
            return new SuccessDataResult<ContactPage>(_locationdal.Get(x=>x.Id==id));
        }

        public IDataResult<List<ContactPage>> GetLocations()
        {
            return new SuccessDataResult<List<ContactPage>>( _locationdal.GetAll());
        }

        [SecuredOperation("Admin,Moderator")]
        public IResult Update(ContactPage location)
        {
            _locationdal.Update(location);
            return new SuccessResult(Messages.SuccesfullyUpdated);
        }
    }
}
