namespace DataModel.VisitCardContextMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataModel.Contexts.VisitCardDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"VisitCardContextMigrations";
        }

        protected override void Seed(DataModel.Contexts.VisitCardDbContext context)
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
            //var nick = new CustomerProfile
            //{
            //    Birthday = DateTime.Now,
            //    Name = "Nick",
            //    Surname = "Pupkin",
            //    Email = "np@mail.cc",
            //    Login = "np",
            //    Password = "123467",
            //    Phone = "123456",
            //    Profession = "Carrier"
            //};

            //context.CustomerProfiles.Add(nick);

            //var jack = new CustomerProfile
            //{
            //    Birthday = DateTime.Now,
            //    Name = "Jack",
            //    Surname = "Sparrow",
            //    Email = "jsp@mail.cc",
            //    Login = "sparrow",
            //    Password = "123467",
            //    Phone = "123456",
            //    Profession = "designer"
            //};
            //context.CustomerProfiles.Add(jack);
            //var luke = new CustomerProfile
            //{
            //    Birthday = DateTime.Now,
            //    Name = "Luke",
            //    Surname = "Skywaker",
            //    Email = "ls@mail.cc",
            //    Login = "ls",
            //    Password = "123467",
            //    Phone = "123456",
            //    Profession = "Programmer"
            //};
            //context.CustomerProfiles.Add(luke);
            //var card = new VisitCardModel();

            //context.VisitCards.Add(new VisitCardModel
            //{
            //    Info = jack
            //});
            //context.VisitCards.Add(new VisitCardModel
            //{
            //    Info = luke
            //}); context.VisitCards.Add(new VisitCardModel
            //{
            //    Info = nick
            //});

            //context.SaveChanges();
        }
    }
}
