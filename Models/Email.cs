using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RemboComingSoon.Models
{
    public class Email
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string EmailAddress { get; set; }
    }
}
