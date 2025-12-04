using MyAdminDB;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly AdminDbContext _adminDb;
        private readonly CityDbContext _cityDb;


        public LoginWindow()
        {
            InitializeComponent();
            _adminDb = new AdminDbContext();
            _cityDb = new CityDbContext();
        }
        private void LoginCheckUser(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            var admin = _adminDb.Admins.FirstOrDefault(a => a.Username == username && a.Password == password);
            if (admin!=null)
            {
                var details=new WindowDetails(_cityDb);
                details.ShowDialog();
                MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);  
                this.Close();


            }
            else
            {
                // Failed login
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
