using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAdminDB
{
    public static class AdminData
    {
        public static void InitialAdmin(AdminDbContext adminDbContext)
        {
            if(!adminDbContext.Admins.Any())
            {
                var defaultAdmin = new Admin
                {
                    Username = "admin",
                    Password = "admin123", // In a real application, ensure to hash passwords
                    Role="admin",
                };
                adminDbContext.Admins.Add(defaultAdmin);
                adminDbContext.SaveChanges();
            }
        }
    }
}
