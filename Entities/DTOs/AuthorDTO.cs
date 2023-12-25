using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AuthorDTO:IDto
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
    }
}
