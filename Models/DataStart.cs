using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;


namespace razor_pg_ef.Models
{
    public static class DataStart
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = new StoreGameContext(
                serviceProvider.GetRequiredService<DbContextOptions<StoreGameContext>>()
                );
            if (context.Game.Any())
            {
                return;
            }
            context.Game.AddRange(
                new Game { Price = 5.60M, Title = "Among us ", ReleaseDate = DateTime.Parse("1976-05-6") },
                new Game { Price = 85.60M, Title = "Aminal Crossing ", ReleaseDate = DateTime.Parse("2009-11-6") },
                new Game { Price = 55.90M, Title = "Cash ", ReleaseDate = DateTime.Parse("1976-05-6") }
            );
            context.SaveChanges();
        }
    }
}