using Microsoft.EntityFrameworkCore;
using OzkaInsaat.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzkaInsaat.Dal.Concrete.Entityframework.Context
{
    public class ProjeDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=OzkaInsaat;user id=sa; password=12345;");
        }

        public DbSet<City> City { get; set; }
    }
}
