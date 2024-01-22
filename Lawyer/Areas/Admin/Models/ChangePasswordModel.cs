namespace Lawyer.Areas.Admin.Models
{
    public class ChangePasswordModel
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set;}
        public string NewPasswordReply { get; set;}
    }
}
