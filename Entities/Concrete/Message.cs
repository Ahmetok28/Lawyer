using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Message:IEntity
    {
        public int Id { get; set; }
        public int IssueId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime SendTime { get; set; }
        public bool Status { get; set; }
        public bool  IsImportant { get; set; }

    }
}
