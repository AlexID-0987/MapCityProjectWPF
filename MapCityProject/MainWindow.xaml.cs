using MapCityProject.Model;
using MapCityProject.Windows;
using MyAdminDB;
using System.Linq;
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
        
        IEnumerable<City> IEcityesTo = new List<City>();
        IEnumerable<City> IEcityesEnd = new List<City>();  
        CityTo CityTo = new CityTo();
        private readonly CityDbContext _context;
        private readonly AdminDbContext _adminContext;

        public MainWindow()
        {
            InitializeComponent();
            _context = new CityDbContext();
            _context.Database.EnsureCreated();
            CityData.Initialize(_context);
            _adminContext = new AdminDbContext();
            _adminContext.Database.EnsureCreated();
            AdminData.InitialAdmin(_adminContext);
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
                IEcityesTo=IEcityesTo.Append(city);
            } 
            if (searchCity1.SelectedItem is City city1)
            {
                cityInfo1.Text = $"Location: {city1.coordinateX}, {city1.coordinateY}!";
                IEcityesEnd=IEcityesEnd.Append(city1);

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
            direction.SetStartCoordinates(MainMap, CityTo.MyTrevelCoordinate(IEcityesTo), CityTo.MyTrevelCoordinate(IEcityesEnd));
            double floatDistance = calculationDirection.CalculateDistance(CityTo.MyTrevelCoordinate(IEcityesTo), CityTo.MyTrevelCoordinate(IEcityesEnd));    
            statusText.Text=$"Distance {CityTo.MyTrevelCityName(IEcityesTo)} To {CityTo.MyTrevelCityName(IEcityesEnd)} {Math.Round(floatDistance,2)} KM ";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Direction direction = new Direction();
            direction.UpdateMap(MainMap);
        }

        private void OpenDetail(object sender, RoutedEventArgs e)
        {
            
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
        }
        
    }
}