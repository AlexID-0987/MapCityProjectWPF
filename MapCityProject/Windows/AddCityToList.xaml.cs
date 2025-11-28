using MapCityProject.Services;
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
    /// Interaction logic for AddCityToList.xaml
    /// </summary>
    public partial class AddCityToList : Window
    {
        public AddCityToList()
        {
            InitializeComponent();
        }

        private void AddCityButton_Click(object sender, RoutedEventArgs e)
        {
            AddCity addCityService = new AddCity();

            City city = new City
            {
                CityName = CityName.Text,
                coordinateX = float.Parse(InputCoordinateX.Text),
                coordinateY = float.Parse(InputCoordinateY.Text)
            };
            addCityService.AddNewCity(city);

        }
    }
}
