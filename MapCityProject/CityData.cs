using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapCityProject
{
    internal static class CityData
    {
        public static void Initialize(CityDbContext db)
        {
            
            if (!db.Cities.Any())
            {
                
                db.Cities.AddRange(
                    new City { CityName = "Kyiv", coordinateX = 50.4504f, coordinateY = 30.5245f },
                    new City { CityName = "Kharkiv", coordinateX = 50.0020f, coordinateY = 36.3074f },
                    new City { CityName = "Lviv", coordinateX = 49.8397f, coordinateY = 24.0297f },
                    new City { CityName = "Chicago", coordinateX = 41.8781f, coordinateY = -87.6298f },
                    new City { CityName = "Houston", coordinateX = 29.7604f, coordinateY = -95.3698f },
                    new City { CityName = "Phoenix", coordinateX = 33.4484f, coordinateY = -112.0740f }
                    );
                db.SaveChanges();
            }
        }
        
    }
}
 