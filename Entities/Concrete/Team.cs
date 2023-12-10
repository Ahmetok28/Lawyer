using Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Entities.Concrete
{
    public class Team : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string Image { get; set; }
        public string About { get; set; }
        public string Profession { get; set; }
        [AllowNull]
        public string? Facebook { get; set; }
        [AllowNull]
        public string? Instagram { get; set; }
        [AllowNull]
        public string? Twitter { get; set; }
        [AllowNull]
        public string? Linkedln { get; set; }

    }
}
