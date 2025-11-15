using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapCityProject.Model
{
    internal class CityTo: TravilingToSomeWhere
    {
        private readonly float[] CoorninateTo= new float[2];
        private  string CityNameTo=" ";
        public float[] MyTrevelCoordinate(IEnumerable<City> cityes)
        {
            foreach (var city in cityes)
            {
                CoorninateTo[0] = city.coordinateX;
                CoorninateTo[1] = city.coordinateY;
            }
            return CoorninateTo.ToArray();
        }
        public string MyTrevelCityName(IEnumerable<City> cityes)
        {
            
            foreach (var city in cityes)
            {
                CityNameTo=city.CityName;
            }
            return CityNameTo;
        }
    }
}
