using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class WhatsSaidAboutUs:IEntity
    {
        public int Id { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    } 
}
