using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace veterinaria.web.Models
{
    public class Manager
    {
        public int Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}