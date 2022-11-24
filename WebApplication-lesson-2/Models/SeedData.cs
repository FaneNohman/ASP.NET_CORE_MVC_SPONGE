using Microsoft.EntityFrameworkCore;
using System;

namespace WebApplication_lesson_2.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DBContext(serviceProvider.GetRequiredService<DbContextOptions<DBContext>>()))
            {
                if (context.Homes.Any())
                {
                    return;
                }

                var homes = new List<Home>
                {
                    new Home
                    {
                        HomeType = "Rock",
                        IsNeighbour = true
                    },
                    new Home
                    {
                        HomeType = "Moai statue",
                        IsNeighbour = true
                    },
                    new Home
                    {
                        HomeType = "Anchor",
                        IsNeighbour = false
                    },
                    new Home
                    {
                        HomeType = "Chum Bucket",
                        IsNeighbour = false
                    }
                };

                var friends = new List<Friend>
                {
                    new Friend
                    {
                        FirstName = "Patrick",
                        LastName = "Star",
                        Job = "jobless",
                        JobPlace = "none",
                        SkinColor = "pink",
                        Home = homes[0]

                    },
                    new Friend
                    {
                        FirstName = "Squidward",
                        LastName = "Tentacles",
                        Job = "cashier",
                        JobPlace = "Krusty Krab",
                        SkinColor = "turquoise",
                        Home = homes[1]

                    },
                    new Friend
                    {
                        FirstName = "Eugene",
                        LastName = "Krabs",
                        Job = "Owner and founder of the Krusty Krab",
                        JobPlace = "Krusty Krab",
                        SkinColor = "crimson red",
                        Home = homes[2]

                    },
                    new Friend
                    {
                        FirstName = "Sheldon",
                        LastName = "Plankton",
                        Job = "Co-owner and founder of the Chum Bucket",
                        JobPlace = "Chum Bucket",
                        SkinColor = "deep green",
                        Home = homes[3]

                    }
                };

                homes.ForEach(x => context.Homes.Add(x));
                friends.ForEach(x => context.Friends.Add(x));

               

                context.SaveChanges();
            }

        }
    }
}
