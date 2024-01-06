using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class BlogDTO:IDto
    {
        public int BlogId { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }  
        public string AuthorFullName { get; set; }      
       
        public string CategoryName { get; set; }
        public string BlogTitle { get; set; }
        public string BlogDescription { get; set; }
        public string BlogContent { get; set; }
        public string BlogPhoto { get; set; }
        public DateTime BlogCreatedDate { get; set; }

    }
}
