using IrisLib;
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

namespace IrisClient
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
         
       

       

        private void ButtonClickChangePassword(object sender, RoutedEventArgs e)
        {
            if (ClientData.CurrentUser.Password.Equals(tbOldPassword.Password) && tbNewPassword.Password == tbConfirmPassword.Password)
            {
                ClientData.CurrentUser.Password = tbNewPassword.Password;
                ClientData.client.ChangePassword(ClientData.CurrentUser);
                this.Close();
            }
            else
            {
                lableChangePassword.Visibility = Visibility.Visible;
                tbOldPassword.Password = null;
                tbNewPassword.Password = null;
                tbConfirmPassword.Password = null;
            }
        }


        private void ButtonClickBack(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow.isWindowOpenChangePassword = false;
            //new MainWindow().Show();
            //ClientData.ShowMainWindow();

        }
    }
}
