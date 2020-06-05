using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace veterinaria.web.Models
{
    public class Owner
    {
        
        public int Id { get; set; }

        public string OwnerId { get; set; }
        [ForeignKey("OwnerId")]

        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<Pet> Pet { get; set; }
    }
}