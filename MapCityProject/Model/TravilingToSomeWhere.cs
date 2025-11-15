using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapCityProject.Model
{
    internal interface TravilingToSomeWhere
    {
        public float[] MyTrevelCoordinate(IEnumerable<City> cityes);
        public string MyTrevelCityName(IEnumerable<City> cityes);
    }
}
