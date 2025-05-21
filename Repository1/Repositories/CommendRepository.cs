using Entity.Model;
using Repository1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository1.Repositories
{
    public class CommendRepository : IRepository<Commend>
    {
        private readonly Icontext context;
        public CommendRepository(Icontext context)
        {
            this.context = context;
        }
        public Commend AddItem(Commend item)
        {
            context.Commends.Add(item);
            context.save();
            return item;
        }

        public void DeleteItem(int id)
        {
            context.Commends.Remove(GetById(id));
            context.save();
        }

        public List<Commend> GetAll()
        {
            return context.Commends.ToList();
        }

        public Commend GetById(int id)
        {
           return context.Commends.FirstOrDefault(x=>x.Id==id);
        }

        public void Update(int id, Commend item)
        {
            var commend = GetById(id);
            commend.Description = item.Description;
            commend.Rating = item.Rating;
            commend.IdCustumer = item.IdCustumer;
            commend.Custumer = item.Custumer;
            commend.Trip = item.Trip;
            commend.Date = item.Date;
            context.save();
        }
    }
}
