using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }


}
