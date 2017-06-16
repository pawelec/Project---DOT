namespace Core.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using Domain.Models.Wishes;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using Domain.Models.Users;
    using Domain.Models.Comments;

    internal sealed class Configuration : DbMigrationsConfiguration<Core.Contexts.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            Database.SetInitializer<Contexts.Context>(new DropCreateDatabaseAlways<Contexts.Context>());
        }

        protected override void Seed(Core.Contexts.Context context)
        {
            SeedRoles(context);
            SeedUsers(context);
            SeedWishes(context);
            SeedComments(context);
        }



        private static void SeedUsers(Contexts.Context context)
        {
            if (!context.Users.Any(u => u.UserName == "admin@admin.admin"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User { UserName = "admin@admin.admin" };

                manager.Create(user, "ChangeItAsap!");
                manager.AddToRole(user.Id, "Admin");
            }
            if (!context.Users.Any(u => u.UserName == "user@user.user"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User { UserName = "user@user.user" };

                manager.Create(user, "ChangeItAsap!");
                manager.AddToRole(user.Id, "User");
            }
        }

        private static void SeedRoles(Contexts.Context context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "User"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "User" };

                manager.Create(role);
            }
        }

        private static void SeedWishes(Core.Contexts.Context context)
        {
            context.Wishes.AddRange(new List<Wish>
            {
                new Wish
                {
                    Content = "Byle nie ITN z DOT!", Created = DateTime.UtcNow,
                    Creator = context.Users.FirstOrDefault(user => user.UserName == "admin@admin.admin")
                },
                new Wish
                {
                    Content = "Nie musi byæ ju¿ 5.0... Wysraczy 4.5 :D", Created = DateTime.UtcNow.AddDays(-7),
                    Creator = context.Users.FirstOrDefault(user => user.UserName == "admin@admin.admin")
                },
                new Wish
                {
                    Content = "Wycieczka do francji", Created = DateTime.UtcNow.AddYears(-1),
                    Creator = context.Users.FirstOrDefault(user => user.UserName == "user@user.user")
                },
                new Wish
                {
                    Content = "Marzy mi siê maluch", Created = DateTime.UtcNow.AddDays(-1),
                    Creator = context.Users.FirstOrDefault(user => user.UserName == "user@user.user")
                }
            });
            context.SaveChanges();
        }
        private static void SeedComments(Contexts.Context context)
        {
            context.Comments.AddRange(new List<Comment>
            {
                new Comment
                {
                    Content = "Fajne, podoba mi siê.",
                    Created = DateTime.UtcNow,
                    Wish = context.Wishes.FirstOrDefault(),
                    Creator = "Pafcio"
                },
                new Comment
                {
                    Content = "No niech bêdzie...",
                    Created = DateTime.UtcNow,
                    Wish = context.Wishes.FirstOrDefault(),
                    Creator = "Kafcia"
                },
                new Comment
                {
                    Content = "Taki sobie komentarz",
                    Created = DateTime.UtcNow,
                    Wish = context.Wishes.FirstOrDefault(),
                    Creator = "Pafcio Pafcia"
                },
                new Comment
                {
                    Content = "Nie no kicha!",
                    Created = DateTime.UtcNow,
                    Wish = context.Wishes.ToList().LastOrDefault(),
                    Creator = "Prowadz¹cy"
                }
            });
            context.SaveChanges();
            //}
        }
    }
}
