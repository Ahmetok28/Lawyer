using Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Section:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Paragraphs { get; set; }

        // Section'ın ait olduğu PracticeArea'nın referansı
        public int PracticeAreaId { get; set; }
        public PracticeArea PracticeArea { get; set; }
    }


}
