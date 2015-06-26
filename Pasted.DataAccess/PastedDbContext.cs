using Pasted.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasted.DataAccess
{
   public class PastedDbContext : DbContext
    {
        public DbSet<Paste> Pastes { get; set; }

       public PastedDbContext()
       {

       }

       protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
           // Add additional model configuration steps here

           base.OnModelCreating(modelBuilder);
       }

       
    }
}
