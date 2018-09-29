using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAuditInterception.Models
{
    public class People
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Display(Name = "Primeiro Nome")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }

        [Display(Name = "Idade")]
        public int Age { get; set; }
    }
}