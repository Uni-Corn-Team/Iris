using System;
using System.Windows;

namespace IrisClient
{
    /// <summary>
    /// Логика взаимодействия для EditProfile.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public ChangePasswordWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод для обработки события нажания на кнопку "Изменить пароль".
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
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

        /// <summary>
        /// Метод для обработки события нажания на кнопку "Назад".
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        private void ButtonClickBack(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Метод для обработки события закрытия окна.
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow.isWindowOpenChangePassword = false;
        }
    }
}
