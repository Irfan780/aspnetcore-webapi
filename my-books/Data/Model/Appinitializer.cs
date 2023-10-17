using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Model
{
    public class Appinitializer
    {
        public static void seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceSope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceSope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book
                    {
                        Title = "1st Book title",
                        Description = "1st Book description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        Author = "1st Author",
                        CoverUrl = "https......",
                        DateAdded = DateTime.Now

                    },
                    new Book
                    {
                        Title = "2st Book title",
                        Description = "2st Book description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        Author = "1st Author",
                        CoverUrl = "https......",
                        DateAdded = DateTime.Now

                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
