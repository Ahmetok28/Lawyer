using Business.Abstract;
using Bussines.BusinessAspects.Autofac;
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
        public void Add(ContactPage location)
        {
            _locationdal.Add(location);
        }
        [SecuredOperation("Admin,Moderator")]
        public void Delete(ContactPage location)
        {
            _locationdal.Delete(location);
        }

        
        public ContactPage GetContactPage()
        {            
            return _locationdal.GetAll().FirstOrDefault();          
        }

        public List<ContactPage> GetLocations()
        {
            return _locationdal.GetAll();
        }

        [SecuredOperation("Admin,Moderator")]
        public void Update(ContactPage location)
        {
            _locationdal.Update(location);
        }
    }
}
