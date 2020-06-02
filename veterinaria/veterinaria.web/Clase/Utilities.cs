using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using veterinaria.web.Models;

namespace veterinaria.web.Clase
{
    public class Utilities
    {
        readonly static ApplicationDbContext db = new ApplicationDbContext();

        public void Dispose() {
            db.Dispose();
        }
    }
}