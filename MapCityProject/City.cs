using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapCityProject
{
    internal class City
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CityName { get; set; }
        public float coordinateX { get; set; }
        public float coordinateY { get; set; }

    }
}
