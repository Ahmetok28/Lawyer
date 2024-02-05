using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserForTeamDTO:IDto
    {
        public int UserId { get; set; }
        public int UserAdditionaPropertylId { get; set; }
        public int UserProfliePhotolId { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string?  AboutUser { get; set; }
        public string? Mail { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ProfliePhoto { get; set; }
        public string? Profession { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Twitter { get; set; }
        public string? Linkedln { get; set; }
        public string? SeoUrl { get; set; }
        public bool TeamStatus { get; set; }

    }
}
