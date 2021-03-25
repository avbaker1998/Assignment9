using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_3.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            MovieDBContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<MovieDBContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if(!context.Movies.Any())
            {
                context.Movies.AddRange(

                    new MoviesModel
                    {
                        Category = "Romance",
                        Title = "Breakfast at Tiffany's",
                        Year = 1961,
                        Director = "Blake Edwards",
                        Rating = "G",
                        Edited = false,
                        Lent = "Alle Baker",
                        Notes = "This is one of the best movies known to man!"
                    });
                context.SaveChanges();
            }
        }
    }
}
