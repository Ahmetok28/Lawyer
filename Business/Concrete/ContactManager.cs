using Business.Abstract;
using Bussines.BusinessAspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Add(Contact contact)
        {
            _contactDal.Add(contact);
            return new SuccessResult();
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Delete(Contact contact)
        {
            _contactDal.Delete(contact);
            return new SuccessResult();
        }

        public IDataResult< Contact> GetContact()
        {
            return new SuccessDataResult<Contact>( ReplacePhoneNumber(_contactDal.GetAll().First()));
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Update(Contact contact)
        {
            _contactDal.Update(contact);
            return new SuccessResult();
        }

        private Contact ReplacePhoneNumber(Contact contact)
        {
            // Sadece rakamları içeren bir telefon numarası alın
            string digits = Regex.Replace(contact.PhoneNumber, @"\D", "");

            // İstediğiniz formata göre telefon numarasını düzenleyin
            string formattedNumber = "";
            if (digits.Length == 10)
            {
                formattedNumber = Regex.Replace(digits, @"(\d{3})(\d{3})(\d{2})(\d{2})", "$1 $2 $3 $4");
            }
            else if (digits.Length == 11)
            {
                formattedNumber = Regex.Replace(digits, @"(\d{4})(\d{3})(\d{2})(\d{2})", "$1 $2 $3 $4");
            }
            contact.PhoneNumber = formattedNumber;
            return contact;
        }
    }
}
