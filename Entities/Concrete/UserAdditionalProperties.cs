using Core.Entities;

namespace Entities.Concrete
{
    public class UserAdditionalProperties : IEntity
    {
       
        public int Id { get; set; } 
        public int UserId { get; set; } 
        public string? ProfilePhoto { get; set; }
        public string? PhoneNumber { get; set; }     
        public string? About { get; set; }
        public string? Profession { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Twitter { get; set; }
        public string? Linkedln { get; set; }
        public bool TeamStatus { get; set; }

    }
}
