﻿namespace Lawyer.Models
{
    public class BlogViewModel
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DescriptionForSearch { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public string CreatedDateDays { get; set; }
        public string SeoUrl { get; set; }
        public string AuthorSeoUrl { get; set; }
        
        public string CreatedDateMonths { get; set; }
    }
}
