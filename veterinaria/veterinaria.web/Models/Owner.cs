using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace veterinaria.web.Models
{
    public class Owner
    {
        
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Apellido")]
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Dirrección")]
        [MaxLength(400)]
        public string Address { get; set; }
        [Display(Name = "Teléfono")]
        [MaxLength(20)]
        [Required]
        public string Phone { get; set; }
        [Display(Name = "Correo")]
        [MaxLength(50)]
        public string Email { get; set; }
    }
}