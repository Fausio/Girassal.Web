using Girassol.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Girassal.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public ApplicationDbContext()
        {

        }


        public DbSet<SimpleEntity> simpleEntitie { get; set; }
        public DbSet<Invoice> GetInvoice { get; set; } 
        public DbSet<Client> Client { get; set; }

    }
}
