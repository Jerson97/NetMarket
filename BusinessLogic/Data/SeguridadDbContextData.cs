using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data
{
    public class SeguridadDbContextData
    {
        public static async Task SeedUserAsync(UserManager<Usuario> userManager) {

            if (!userManager.Users.Any())
            {
                var usuario = new Usuario
                {
                    Nombre = "Jerson",
                    Apellido = "Soto",
                    UserName = "ramijer",
                    Email = "jersonramirez97@gmail.com",
                    Direccion = new Direccion
                    {
                        Calle = "Sucre 245",
                        Ciudad = "Lima",
                        CodigoPostal = "01",
                        Departamento = "Lima",
                    }
                };

                await userManager.CreateAsync(usuario, "JersonR2025$");
            }
        }
    }
}
