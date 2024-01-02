using Core.Entities;

namespace Entities.Concrete
{
    public class WhyChooseUs : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int LogoId { get; set; }
    }
}
