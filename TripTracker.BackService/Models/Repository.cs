using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripTracker.BackService.Models
{
    public class Repository
    {
        private List<Trip> MyTrips = new List<Trip>
        {
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
        };

        public List<Trip> Get()
        {
            return MyTrips;
        }
        public Trip Get(int id)
        {
            return MyTrips.FirstOrDefault(t=>t.Id==id);
        }

        public void Add(Trip Newtrip)
        {
            MyTrips.Add(Newtrip);
        }

        public void Update(Trip tripToUpdate)
        {
            MyTrips.Remove(MyTrips.First(t => t.Id == tripToUpdate.Id));
            Add(tripToUpdate);
             
        }

        public void Remove(int id)
        {
            MyTrips.Remove(MyTrips.First(t => t.Id == id));
        }
    }
}
