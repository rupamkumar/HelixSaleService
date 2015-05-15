namespace WebApiTest.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApiTest.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApiTest.Models.SaleServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApiTest.Models.SaleServiceContext context)
        {
            context.Products.AddOrUpdate(p => p.ID,
                new Product() { ID = 1, Name = "Test1", quantity =5, sale_amount =1500 },
                new Product() { ID = 2, Name = "Test2", quantity = 4, sale_amount = 3500 },
                new Product() { ID = 3, Name = "Test3", quantity = 3, sale_amount = 2500 }
                );
            context.Sales.AddOrUpdate(s => s.ID,
                new Sale() { ID = 1, location_name = "Helix Perth", ProductId = 1, sales_person_name = "SalesPerson1", total_sale_amount = 4500, currency = "AU", sale_invoice_number = "SalesPerson1" + "HelixPerth"+"1" },
                new Sale() { ID = 2, location_name = "Helix Perth", ProductId = 1, sales_person_name = "SalesPerson2", total_sale_amount = 4500, currency = "AU", sale_invoice_number = "SalesPerson1" + "HelixPerth" + "2" },
                new Sale(){ID =3, location_name = "Helix Perth", ProductId =1, sales_person_name="SalesPerson3" , total_sale_amount = 4500, currency = "AU", sale_invoice_number = "SalesPerson1" + "HelixPerth"+"3" }
                );
        }
    }
}
