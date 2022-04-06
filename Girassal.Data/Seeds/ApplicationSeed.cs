using Girassal.Data.Data;
using Girassol.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girassol.Data.Seeds
{
    public static class ApplicationSeed
    {  

        

        public static async Task SeedSimpleEntity()
        {

            try
            {
                DateTime CreatedDate = DateTime.Now;
                int CreatedUserID = 1;

                ApplicationDbContext db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
                var result = db.simpleEntitie.Count();

                if (result <= 0)
                {
                    List<SimpleEntity> Enums = new List<SimpleEntity>()
            {

                 // para tipos de roupas 
                 new SimpleEntity()
                 {
                     Type = "Part",
                     Description = "Vestuário",
                     CreatedDate = CreatedDate,
                     CreatedUserID = CreatedUserID ,
                     Guid = Guid.NewGuid()
                 },
                   new SimpleEntity()
                 {
                     Type ="Part",
                     Description = "Calçado",
                     CreatedDate = CreatedDate,
                     CreatedUserID = CreatedUserID ,
                     Guid = Guid.NewGuid()
                 } ,

                    // para tipo de Cliente
                   
                   new SimpleEntity()
                 {
                     Type ="Client",
                     Description = "Instituição / Empresa",
                     CreatedDate = CreatedDate,
                     CreatedUserID = CreatedUserID ,
                     statusCode = 1,
                     Guid = Guid.NewGuid()
                 },

                    // para tipo de de estado da fatura 
                        new SimpleEntity()
                 {
                     Type = "Invoice" ,
                     Description = "Processamento",
                     CreatedDate = CreatedDate,
                     CreatedUserID = CreatedUserID , 
                     Guid = Guid.NewGuid()
                 },
                     new SimpleEntity()
                 {
                     Type = "Invoice" ,
                     Description = "Iniciada",
                     CreatedDate = CreatedDate,
                     CreatedUserID = CreatedUserID ,
                     statusCode = 2,
                     Guid = Guid.NewGuid()
                 } ,
                      new SimpleEntity()
                 {
                     Type = "Invoice" ,
                     Description = "Finalizada",
                     CreatedDate = CreatedDate,
                     CreatedUserID = CreatedUserID ,
                     statusCode = 1,
                     Guid = Guid.NewGuid()
                 }
            };

                    await db.AddRangeAsync(Enums);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception x)
            { 
                throw x;
            }

         






        }
    }
}
