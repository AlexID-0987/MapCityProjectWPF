using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace MyAdminDB
{
    public class AdminDbContext: DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NUCBOXG3\\SQLEXPRESS;Database=AdminDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
