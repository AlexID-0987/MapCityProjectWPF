using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapCityProject.Services
{
    public class AddCity
    {
        private CityDbContext _context;
        //private City _city;
        public AddCity()
        {
            _context = new CityDbContext();
        }
        public void AddNewCity (City city)
        {
            //_city = city;
            _context.Cities.Add(city);
            _context.SaveChanges();
        }
    }
}
