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
            if(!context.Genres.Any())
            {
                context.Genres.AddOrUpdate(genre => genre.GenreID,
                    new MovieGenre() { GenreName = MovieGenreType.Action },
                    new MovieGenre() { GenreName = MovieGenreType.Adventure },
                    new MovieGenre() { GenreName = MovieGenreType.Comedy },
                    new MovieGenre() { GenreName = MovieGenreType.Crime },
                    new MovieGenre() { GenreName = MovieGenreType.Historical },
                    new MovieGenre() { GenreName = MovieGenreType.Horror },
                    new MovieGenre() { GenreName = MovieGenreType.Musical },
                    new MovieGenre() { GenreName = MovieGenreType.Romance },
                    new MovieGenre() { GenreName = MovieGenreType.ScienceFiction },
                    new MovieGenre() { GenreName = MovieGenreType.Thriller },
                    new MovieGenre() { GenreName = MovieGenreType.War },
                    new MovieGenre() { GenreName = MovieGenreType.Western});
            }
            if(!context.Movies.Any())
            {
                context.Movies.AddOrUpdate(movie => movie.MovieID,
                    new Movie
                    {
                        Title = "Pulp Fiction",
                        Description = "Test description of Pulp Fiction",
                        GenreId = (from genre in context.Genres where genre.GenreName == MovieGenreType.Action select genre.GenreID).First(),
                        Country = "United States",
                        Language = "English",
                        Minutes = 154,
                        Year = 1994,
                        DirectorId = (from director in context.Directors where director.FirstName == "Quentin" && director.LastName == "Tarantino" select director.DirectorID).First()
                    });
            }
        }
    }
}
