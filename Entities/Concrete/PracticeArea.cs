using Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class PracticeArea : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string LogoImage { get; set; }
        public string BackgroundImage { get; set; }
        public List<Section> Sections { get; set; }
      
    }


}
