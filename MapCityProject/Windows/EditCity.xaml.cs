using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MapCityProject.Windows
{
    /// <summary>
    /// Interaction logic for EditCity.xaml
    /// </summary>
    public partial class EditCity : Window
    {
        private readonly CityDbContext _context;
        private readonly City _city;
        public EditCity(CityDbContext cityDbContext,City city)
        {
            InitializeComponent();
            _context = cityDbContext;
            _city = city;
            CityNameTextBox.Text=_city.CityName;
            CityNameCoordinateX.Text=_city.coordinateX.ToString();
            CityNameCoordinateX.IsEnabled=false;
            CityNameCoordinateY.Text=_city.coordinateY.ToString();
            CityNameCoordinateY.IsEnabled=false;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _city.CityName = CityNameTextBox.Text;
            if(float.TryParse(CityNameCoordinateX.Text, out float x))
            {
                _city.coordinateX = x;
            }
            if(float.TryParse(CityNameCoordinateY.Text, out float y))
            {
                _city.coordinateY = y;
            }
            _context.Cities.Add(_city);
            _context.SaveChanges();
            Close();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            _context.Cities.Remove(_city);
            _context.SaveChanges();
            Close();
        }   
    }
}
