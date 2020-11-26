using Iris;
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

namespace ChatClient.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditProfile.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        private bool isShowOldPassword = true, isShowNewPassword = true;

        public ChangePasswordWindow()
        {
            InitializeComponent();
        }
         
        private void RemoveTextOldPassword(object sender, RoutedEventArgs e)
        {
            if(isShowOldPassword)
            {
                tbOldPassword.Text = null;
                tbOldPassword.Foreground = Brushes.Black;
                isShowOldPassword = false;
            }
        }

        private void RemoveTextNewPassword(object sender, RoutedEventArgs e)
        {
            if (isShowNewPassword)
            {
                tbNewPassword.Text = null;
                tbNewPassword.Foreground = Brushes.Black;
                isShowNewPassword = false;
            }
        }

        private void ButtonClickChangePassword(object sender, RoutedEventArgs e)
        {
            if (MainWindow.CurrentUser.Password.Equals(tbOldPassword.Text))
            {
                MainWindow.CurrentUser.Password = tbNewPassword.Text;
                Database.changePassword(MainWindow.CurrentUser);
                this.Close();
            }
            else
            {
                lableChangePassword.Visibility = Visibility.Visible;
                tbOldPassword.Text = null;
                tbNewPassword.Text = null;
            }
        }


        private void ButtonClickBack(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
              new MainWindow().Show();
                      
        }
    }
}
