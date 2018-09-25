using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAuditInterception.Models
{
    public class PeopleHist
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Operation { get; set; }
        public DateTime Date { get; set; }
        public string User { get; set; }
    }
}