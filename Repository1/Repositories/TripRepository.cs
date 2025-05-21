using Entity.Model;
using Repository1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository1.Repositories
{
    public class TripRepository:IRepository<Trip>
    {
        private readonly Icontext context;
        public TripRepository(Icontext context)
        {
            this.context = context;
        }
        public Trip AddItem(Trip item)
        {
            context.Trips.Add(item);
            context.save();
            return item;
        }

        public void DeleteItem(int id)
        {
            context.Trips.Remove(GetById(id));
            context.save();
        }

        public List<Trip> GetAll()
        {
            return context.Trips.ToList();
        }

        public Trip GetById(int id)
        {
            return context.Trips.FirstOrDefault(x => x.Id == id);
        }

        public void Update(int id, Trip item)
        {
            var trip = GetById(id);
            trip.Name = item.Name;
            trip.Description = item.Description;
            trip.Age = item.Age;
            trip.Adress = item.Adress;
            trip.Area = item.Area;
            trip.DryOrWet = item.DryOrWet;
            trip.Commends = item.Commends;
            trip.Rating = item.Rating;
            trip.Season = item.Season;
            

            context.save();
        }
    }
}
