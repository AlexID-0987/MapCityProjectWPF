using MapCityProject.Model;
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
        private readonly float[] CoordinateTo = new float[2];
        private readonly float[] CoordinateEnd = new float[2];
        public MainWindow()
        {
            InitializeComponent();
            using var db = new CityDbContext();
            db.Database.EnsureCreated();
            CityData.Initialize(db);
            Map_Loaded();
            statusText.Text = "Map connected successfully.";   

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
            
            
            if (searchCity.SelectedItem is City city)
            {
                cityInfo.Text = $"Location: {city.coordinateX}, {city.coordinateY}!";
                CoordinateTo[0] = city.coordinateX;
                CoordinateTo[1] = city.coordinateY;
            } 
            if (searchCity1.SelectedItem is City city1)
            {
                cityInfo1.Text = $"Location: {city1.coordinateX}, {city1.coordinateY}!";
                CoordinateEnd[0] = city1.coordinateX;
                CoordinateEnd[1] = city1.coordinateY;
            }
        }
       

        private void LoadCityesClick(object sender, RoutedEventArgs e)
        {
            Map_Loaded();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Direction direction = new Direction();
            CalculationDirection calculationDirection = new CalculationDirection();
            direction.SetStartCoordinates(MainMap, CoordinateTo, CoordinateEnd);
            double floatDistance = calculationDirection.CalculateDistance(CoordinateTo, CoordinateEnd);    
            statusText.Text=$"Distance {Math.Round(floatDistance,2)} KM ";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Direction direction = new Direction();
            direction.UpdateMap(MainMap);
        }
    }
}