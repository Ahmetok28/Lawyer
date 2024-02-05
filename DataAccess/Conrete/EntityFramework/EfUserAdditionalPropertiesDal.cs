using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfUserAdditionalPropertiesDal : EfEntityRepositoryBase<UserAdditionalProperties, Context>, IUserAdditionalPropertiesDal
    {
        public List<UserForTeamDTO> GetAllUserDetails(Expression<Func<UserForTeamDTO, bool>> filter = null)
        {
            using (var context = new Context())
            {
                var result = from userAddProp in context.UserProperties
                             join user in context.Users.Where(x=>x.Status==true)
                             on userAddProp.UserId equals user.Id
                             join profPhoto in context.ProfilePhotos
                             on userAddProp.UserId equals profPhoto.UserId
                             select new UserForTeamDTO
                             {
                                 UserId = user.Id,
                                 UserAdditionaPropertylId = userAddProp.Id,
                                 UserProfliePhotolId = profPhoto.Id,
                                 FullName = user.FirstName + " " + user.LastName,
                                 FirstName = user.FirstName ,
                                 LastName =  user.LastName,
                                 AboutUser = userAddProp.About,
                                 Mail = user.Email,
                                 PhoneNumber = userAddProp.PhoneNumber,
                                 ProfliePhoto = profPhoto.ImagePath,
                                 Profession = userAddProp.Profession,
                                 Facebook = userAddProp.Facebook,
                                 Twitter = userAddProp.Twitter,
                                 Instagram = userAddProp.Instagram,
                                 Linkedln = userAddProp.Linkedln,
                                 SeoUrl= userAddProp.SeoUrl,
                                 TeamStatus= userAddProp.TeamStatus,


                             };
                return filter == null ? result.ToList()
                    : result.Where(filter).ToList(); 
            }
        }

        public UserForTeamDTO GetUserDetailsByFilter(Expression<Func<UserForTeamDTO, bool>> filter)
        {
            using (var context = new Context())
            {
                var result = from userAddProp in context.UserProperties
                             join user in context.Users.Where(x => x.Status == true)
                             on userAddProp.UserId equals user.Id
                             join profPhoto in context.ProfilePhotos
                             on userAddProp.UserId equals profPhoto.UserId
                             select new UserForTeamDTO
                             {
                                 UserId = user.Id,
                                 UserAdditionaPropertylId = userAddProp.Id,
                                 UserProfliePhotolId = profPhoto.Id,
                                 FullName = user.FirstName + " " + user.LastName,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 AboutUser = userAddProp.About,
                                 Mail = user.Email,
                                 PhoneNumber = userAddProp.PhoneNumber,
                                 ProfliePhoto = profPhoto.ImagePath,
                                 Profession = userAddProp.Profession,
                                 Facebook = userAddProp.Facebook,
                                 Twitter = userAddProp.Twitter,
                                 Instagram = userAddProp.Instagram,
                                 Linkedln = userAddProp.Linkedln,
                                 SeoUrl=userAddProp.SeoUrl,
                                 TeamStatus = userAddProp.TeamStatus,
                                 


                             };
                return result.SingleOrDefault(filter);
            }


        }
    }
}
