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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel;
using System.Threading;

using MapCityProject.Model;

namespace MapCityProject.Windows
{
    /// <summary>
    /// Interaction logic for WindowDetails.xaml
    /// </summary>
    public partial class WindowDetails : Window
    {
        private readonly CityDbContext _context;
        public WindowDetails()
        {
            InitializeComponent();
            _context = new CityDbContext();
            Window_Loaded();
        }
        private void Window_Loaded()
        {
            CityList.ItemsSource= _context.Cities.ToList();
            
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void CityGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
           if(CityList.SelectedItem is City selectedCity)
            {
                EditCity editCityWindow = new EditCity(_context,selectedCity);
                editCityWindow.ShowDialog();
                // Refresh the city list after editing
                CityList.ItemsSource = _context.Cities.ToList();
            }
        }

    }
}
