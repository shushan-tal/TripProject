using Entity.Model;
using Microsoft.EntityFrameworkCore;

using Repository1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository1.Repositories
{
    public class CustumerRepository : IRepository<Custumer>,Ilogin
    {
        private readonly Icontext context;
        public CustumerRepository(Icontext context)
        {
            this.context = context;
        }
        public Custumer AddItem(Custumer item)
        {
            context.Custumers.Add(item);
            context.save();
            return item;
        }

        public void DeleteItem(int id)
        {
            context.Custumers.Remove(GetById(id));
            context.save();
        }

        public List<Custumer> GetAll()
        {
            return context.Custumers.ToList();
        }

        public Custumer GetById(int id)
        {
            return context.Custumers.FirstOrDefault(x => x.Id == id);
        }

        public Custumer getUserByPassAndUser(string user, string pass)
        {
            return context.Custumers.FirstOrDefault(x => x.Name == user && x.Password == pass);
        }

        public void Update(int id, Custumer item)
        {
            var custumer = GetById(id);
            custumer.Name = item.Name;
            custumer.Commends= item.Commends;
            custumer.Password = item.Password;
            custumer.Mail = item.Mail;
           
            context.save();
        }
    }
}
