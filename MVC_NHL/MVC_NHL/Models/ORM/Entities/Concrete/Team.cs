using MVC_NHL.Models.ORM.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_NHL.Models.ORM.Entities.Concrete
{
    public class Team:BaseEntity
    {
        public string TeamName { get; set; }
        public string Description { get; set; }
    }
}