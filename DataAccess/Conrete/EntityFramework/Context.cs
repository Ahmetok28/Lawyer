using Core.Entities.Concrete;
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
        public DbSet<Team>? Teams { get; set; }
        public DbSet<PracticeArea> Practices { get; set; }
        public DbSet<HomeServices> HomeServices { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ContactPage>? ContactPage { get; set; }
        public DbSet<Blog>? Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAdditionalProperties>? UserProperties { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<ProfilePhoto>? ProfilePhotos { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<WhyChooseUs> WhyChooses { get; set; }
        public DbSet<WhatsSaidAboutUs> WhatsSaidAbouts { get; set; }
        public DbSet<AboutPage> AboutPages { get; set; }
        public DbSet<WhyChooseLogo> WhyChooseLogos { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<FooterSocialAndSaying>? FooterSocialAndSayings { get; set; }
    }
}
