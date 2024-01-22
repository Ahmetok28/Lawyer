namespace Lawyer.Areas.Admin.Models
{
    public class UserUpdateModel
    {
        public int UserId { get; set; }
        public int UserAdditionaPropertylId { get; set; }
        public int UserProfliePhotolId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public string Phone { get; set; }
        public string? Profession { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Twitter { get; set; }
        public string? Linkedln { get; set; }

    }
}
