using Entities.Concrete;

namespace Lawyer.Models
{
    public class ContactPageViewModel
    {
        public Contact ContactData { get; set; }
        public List<PracticeArea> PracticeAreas { get; set; }
        public ContactPage ContactPageData { get; set; }
    }
}
