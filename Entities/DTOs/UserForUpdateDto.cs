using Core.Entities;

namespace Entities.DTOs
{
    public class UserForUpdateDto : IDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
