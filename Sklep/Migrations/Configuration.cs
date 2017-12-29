namespace Sklep.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models.DbModels;

    internal sealed class Configuration : DbMigrationsConfiguration<Sklep.Models.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Sklep.Models.MyDbContext";
        }

        protected override void Seed(Sklep.Models.MyDbContext context)
        {
            if (!context.Roles.Any()) //check if db already seeded (will add movies and directors later)
            {
                context.Roles.AddOrUpdate(role => role.RoleID,
                    new Role() { RoleName = RoleType.Admin },
                    new Role() { RoleName = RoleType.Producer },
                    new Role() { RoleName = RoleType.User });   
            }
            if (!context.UserAccounts.Any())
            {
                context.UserAccounts.AddOrUpdate(user => user.UserID,
                    new UserAccount
                    {
                        FirstName = "admin",
                        LastName = "admin",
                        Email = "admin@movie.com",
                        Password = "admin",
                        Username = "admin",
                        RoleId = (from role in context.Roles where role.RoleName == RoleType.Admin select role.RoleID).First()
                    },
                    new UserAccount
                    {
                        FirstName = "producer",
                        LastName = "producer",
                        Email = "producer@gmail.com",
                        Password = "producer",
                        Username = "producer",
                        RoleId = (from role in context.Roles where role.RoleName == RoleType.Producer select role.RoleID).First()
                    }); 
            }
            if(!context.Directors.Any())
            {
                context.Directors.AddOrUpdate(director => director.DirectorID,
                    new Director
                    {
                        FirstName = "Quentin",
                        LastName = "Tarantino",
                        Nationality = "United States",
                        DateOfBirth = new DateTime(1963,3,26)
                    });
            }
        }
    }
}
