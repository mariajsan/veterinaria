using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace veterinaria.web.Models
{
    public class Veterinary
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        [MaxLength(100)]
        public string Description { get; set; }

        public ICollection<Consult> Consult { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}