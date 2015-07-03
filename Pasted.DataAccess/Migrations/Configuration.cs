namespace Pasted.DataAccess.Migrations
{
    using Pasted.Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Pasted.DataAccess.PastedDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Pasted.DataAccess.PastedDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            var pastes = new List<Paste>
            {
                new Paste { Id = 1, Content = "console.log('Test1');", CreatedDate=DateTime.Now, ExpiryDate=DateTime.Now.AddDays(3)},
                new Paste { Id = 2, Content = "var x = new Exception(\"test\");", CreatedDate=DateTime.Now, ExpiryDate=DateTime.Now.AddDays(3) },
                new Paste { Id = 3, Content = "var arr = [1, 2, 3, 4, 5];\nconsole.log(arr.slice(0, 2));", CreatedDate=DateTime.Now, ExpiryDate=DateTime.Now.AddDays(3) }
            };

            context.Pastes.AddOrUpdate(p => p.Id, pastes.ToArray());
        }
    }
}
