using System.Runtime.InteropServices;
using WebApplication11.Models;

namespace WebApplication11.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication11.Models.ApplicationDbContext>
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "WebApplication11.Models.ApplicationDbContext";

        }

        protected override void Seed(ApplicationDbContext context)
        {
            var customer1 = new Customer
            {
                Name = "kishor",
                Address = "Address 1",
                DateCreated = DateTime.Now
            };
            db.Customers.Add(customer1);
            db.SaveChanges();

            var product1 = new Product
            {
                Name = "Demo product1",
                Price = 150
            };
            db.Products.Add(product1);
            db.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
