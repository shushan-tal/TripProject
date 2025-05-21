using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository1.Interfaces
{
    public interface Icontext
    {
        public DbSet<Trip>Trips { get; set; }
        public DbSet<Custumer> Custumers { get; set; }
        public DbSet<Commend> Commends { get; set; }

        public void save();


    }
}
