using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Repository1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Data
{
    public class MyData : DbContext, Icontext
    {
        public DbSet<Trip> Trips { get ; set; }
        public DbSet<Custumer> Custumers { get ; set ; }
        public DbSet<Commend> Commends { get ; set; }

        public void save()
        {
           SaveChanges();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=sqlsrv;database=TripDb;trusted_connection=true;TrustServerCertificate=true");

        }
    }
}
