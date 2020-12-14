using System;
using System.Windows;

namespace IrisClient
{
    /// <summary>
    /// Логика взаимодействия для EditProfile.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
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
        }
    }
}
