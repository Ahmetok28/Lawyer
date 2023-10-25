using Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Contact : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
        public string Title2 { get; set; }
      
    }


}
