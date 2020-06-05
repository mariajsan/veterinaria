using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace veterinaria.web.Models
{
    public class Pet
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Nombre")]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Tipo de Mascota")]
        [MaxLength(20)]
        public string PetType { get; set; }
        [Display(Name = "Edad")]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Color")]
        [MaxLength(20)]
        public string Color { get; set; }
        [Display(Name = "Raza")]
        [MaxLength(20)]
        public string Race { get; set; }
        [Required]
        [Display(Name = "Peso")]
        public decimal Weight { get; set; }
        [Required]
        [Display(Name = "Altura")]
        public decimal Height { get; set; }
        [Display(Name = "Foto")]
        public string ImgUrl { get; set; }

        public Owner Owner { get; set; }

        public ICollection<Consult> Consult { get; set; }
    }
}