namespace Core.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using Domain.Models.Wishes;

    internal sealed class Configuration : DbMigrationsConfiguration<Core.Contexts.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Core.Contexts.Context context)
        {
            SeedWishes(context);
        }

        private static void SeedWishes(Core.Contexts.Context context)
        {
            context.Wishes.AddRange(new List<Wish>()
            {
                new Wish
                {
                   Created = DateTime.UtcNow,
                   Content = "Byle nie ITN :)"
                },
                new Wish
                {
                    Created = DateTime.UtcNow.AddDays(-7),
                    Content = "Zadowoli mnie 5.5."
                }
            });
            context.SaveChanges();
        }
    }
}
