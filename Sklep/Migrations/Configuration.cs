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
            context.Roles.AddOrUpdate( role => role.RoleID,
                    new Role() { RoleName = RoleType.Admin },
                    new Role() { RoleName = RoleType.Producer },
                    new Role() { RoleName = RoleType.User });
            context.UserAccounts.AddOrUpdate( user => user.UserID, 
               new UserAccount {FirstName = "admin", LastName = "admin", Email = "admin@movie.com", Password = "admin", Username = "admin", 
                                RoleId = (from role in context.Roles where role.RoleName == RoleType.Admin select role.RoleID).First()});
        }
    }
}