using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace veterinaria.web.Models
{
    public class Consult
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Fecha")]
        public DateTime ConsultDate { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        [MaxLength(50)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Tipo")]
        [MaxLength(20)]
        public string ConsultType { get; set; }

        public Veterinary Veterinary { get; set; }

        public Pet Pet { get; set; }
    }
}