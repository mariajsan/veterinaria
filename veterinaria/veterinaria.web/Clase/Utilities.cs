using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using veterinaria.web.Models;
using System.Data.Entity.Validation;

namespace veterinaria.web.Clase
{
    public class Utilities
    {
        readonly static ApplicationDbContext db = new ApplicationDbContext();

        public static void CheckRoles(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }
        }

        internal static void CheckSuperUser()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userAsp = userManager.FindByName("admin@adminmail.com");

            if (userAsp == null)
            {
                CreateUserASP("admin@adminmail.com", "admin2030", "Admin");
            }
        }

        public static void CreateUserASP(string email, string password, string rol)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userASP = new ApplicationUser()
            {
                UserName = email,
                Email = email,
                FirstName = "Nombre",
                LastName = "Apellido",
                Address = "Dirección"
            };

            userManager.Create(userASP, password);
            userManager.AddToRole(userASP.Id, rol);
        }

        internal static void CheckClientDefault()
        {
            var clientdb = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userclient = clientdb.FindByName("cliente@veterinary.com");
            if (userclient == null)
            {
                CreateUserASP("cliente@veterinary.com", "cliente123", "Owner");
            }

        }

        public void Dispose() {
            db.Dispose();
        }
    }
}