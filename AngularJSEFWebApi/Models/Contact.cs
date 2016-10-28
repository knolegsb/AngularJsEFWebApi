using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AngularJSEFWebApi.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName="varchar")]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        [Column(TypeName = "varchar")]
        public string Address { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(15)]
        public string Phone { get; set; }
    }
}