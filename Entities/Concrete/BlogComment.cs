using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BlogComment : IEntity
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string CommentContent { get; set; }
        public string CommentUserName { get; set; }
        public string CommentUserEmail { get; set; }
        public bool CommentStatus { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
