using Business.Abstract;
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

        public void Add(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void Delete(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Contact GetContact()
        {
            return ReplacePhoneNumber(_contactDal.GetAll().First());
        }

        public void Update(Contact contact)
        {
            throw new NotImplementedException();
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
