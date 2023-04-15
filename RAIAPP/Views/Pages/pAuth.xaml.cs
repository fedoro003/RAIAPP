using RAIAPP.Utils;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RAIAPP.Views.Pages
{
    /// <summary>
    /// Interaction logic for pAuth.xaml
    /// </summary>
    public partial class pAuth : Page
    {
        public pAuth()
        {
            InitializeComponent();
        }

        private void tblShowPassword_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            pbPassword.Visibility = Visibility.Collapsed;
            tbPassword.Visibility = Visibility.Visible;
            tbPassword.Text = pbPassword.Password;
        }

        private void tblShowPassword_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            pbPassword.Visibility = Visibility.Visible;
            tbPassword.Visibility = Visibility.Collapsed;
  
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbLogin.Text=="DEMO"&&pbPassword.Password=="DEMO")
                {
                    NavigationService.Navigate(new pDemo());
                    return;
                }
                var currentUser = AppData.DB.Personals.FirstOrDefault(c=>c.PersonalLogin == tbLogin.Text
                && c.PersonalPassword == pbPassword.Password);
                if (currentUser != null)
                {
                    NavigationService.Navigate(new pMain());
                }
                else
                {
                    throw new Exception("Пользователь не найден");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
