using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripTracker.BackService.Models;

namespace TripTracker.BackService.Data
{
    public class TripContext:DbContext
    {
        public DbSet<Trip> Trips { get; set; }

        public TripContext(DbContextOptions<TripContext> options):base(options)
        {

        }
        public TripContext()
        {

        }
        public static void SeedData(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<TripContext>();
                context.Database.EnsureCreated();
                if (context.Trips.Any())
                    return;
                context.Trips.AddRange(new Trip[] {
                new Trip
            {
                Id=1,
                Name="MVP Summit",
                StartDate=new DateTime(2019,04,25),
                EndDate=new DateTime(2019-04-30)
            },
            new Trip{
                Id=2,
                Name="DevInterSection Orlando 2018",
                StartDate=new DateTime(2019,04,28),
                EndDate=new DateTime(2019,04,30)


            },
            new Trip
            {
                Id=3,
                Name="Chennai Field trip",
                StartDate=new DateTime(2019,05,01),
                EndDate=new DateTime(2019,05,04)
            }
            });
                context.SaveChanges();
            }
        }

        
        
    }
}
