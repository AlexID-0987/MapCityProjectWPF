using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MapCityProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using var db = new CityDbContext();
            db.Database.EnsureCreated();
            CityData.Initialize(db);
            Map_Loaded();
        }
        private void Map_Loaded()
        {
            using var cityes= new CityDbContext();
            var cityList = cityes.Cities.ToList();
            searchCity.ItemsSource = cityList;
            searchCity.DisplayMemberPath = "CityName";
            searchCity.SelectedValuePath = "Id";
            searchCity1.ItemsSource = cityList;
            searchCity1.DisplayMemberPath = "CityName";
            searchCity1.SelectedValuePath = "Id";
            cityInfo.Text = "Select a city to see its coordinates.";
            cityInfo1.Text = "Select a city to see its coordinates.";
        }
        private void CitySelected(object sender, SelectionChangedEventArgs e)
        {
            if(searchCity.SelectedItem is City city)
            {
                cityInfo.Text = $"Location: {city.coordinateX}, {city.coordinateY}!";
            }
            if (searchCity1.SelectedItem is City city1)
            {
                cityInfo1.Text = $"Location: {city1.coordinateX}, {city1.coordinateY}!";
            }
        }
       

        private void LoadCityesClick(object sender, RoutedEventArgs e)
        {
            Map_Loaded();
        }
    }
}