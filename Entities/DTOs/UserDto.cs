using Core.Entities;

namespace Entities.DTOs
{
    public class UserDto : IDto
    {
        public int UserId { get; set; }
        public int ClaimId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string ClaimName { get; set; }

    }
}
