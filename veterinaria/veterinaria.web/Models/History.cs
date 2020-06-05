using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace veterinaria.web.Models
{
    public class History
    {
        public int Id { get; set; }
        public int ConsultId { get; set; }
        [ForeignKey("ConsultId")]
        public Consult Consult { get; set; }
    }
}