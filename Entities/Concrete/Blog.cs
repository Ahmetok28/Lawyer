using Castle.Components.DictionaryAdapter;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Blog:IEntity
    {
       
        public int BlogId { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string? PhotoUrl { get; set; }      
        public DateTime CreatedDate { get; set; }

        
    }
}
