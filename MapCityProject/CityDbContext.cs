using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapCityProject
{
    public class CityDbContext : DbContext
    {
        public DbSet<City> Cities { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NUCBOXG3\\SQLEXPRESS;Database=Cityes;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}



