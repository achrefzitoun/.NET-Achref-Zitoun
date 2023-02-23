using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class AMContext : DbContext
    {
        public DbSet<Flight> Flights {get;set;}
        public DbSet<Passenger> Passengers {get;set;}
        public DbSet<Plane> Planes {get;set;}
      //  public DbSet<Staff> Staff {get;set;}
        public DbSet<Traveller> Travellers {get;set;}
        public DbSet<Test2> test2s { get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (localDB)\MsSqlLocalDB; initial catalog = AchrefZitounNet; Integrated Security=true;");
        }
    }
}
