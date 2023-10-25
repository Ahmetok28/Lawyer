using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Conrete.EntityFramework
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MACHINA;Database=LawyerDb;Trusted_Connection=true;TrustServerCertificate=True");
        }

        public DbSet<HomeText> HomeTexts { get; set; }
        public DbSet<AboutText> AboutTexts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<PracticeArea> Practices { get; set; }
        public DbSet<HomeServices> HomeServices { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
