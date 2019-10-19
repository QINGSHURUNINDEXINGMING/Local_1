namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication2.Models.Model1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication2.Models.Model1 context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Testtables.AddOrUpdate(
              p => new { p.price, p.type, p.comment, p.date },
                  new Testtb { price = 80.0, type = "�\��", comment = "���\�@���C�Y", date = DateTime.Parse("2018/4/5").Date },
                  new Testtb { price = 70.0, type = "�\��", comment = "���\�K��", date = DateTime.Parse("2018/4/5").Date},
                  new Testtb { price = 550.0, type = "�\��", comment = "���\�������", date = DateTime.Parse("2018/4/5").Date }
                );

            //
            context.ExpenseTypes.AddOrUpdate(
              p => new { p.expenseType},
                  new ExpenseType { expenseType="�\��" },
                  new ExpenseType { expenseType = "��q" },
                  new ExpenseType { expenseType = "���" }
                );
        }
    }
}
