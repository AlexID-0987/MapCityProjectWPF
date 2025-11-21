using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapCityProject.Services
{
    internal class AddCity
    {
        private CityDbContext _context;
        private City _city;
        public AddCity(CityDbContext context)
        {
            _context = context;
        }
        public void AddNewCity (City city)
        {
            _city = city;
            _context.Cities.Add(_city);
            _context.SaveChanges();
        }
    }
}
