using IrisLib;
using System;
using System.Windows;

namespace IrisClient
{
    /// <summary>
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignInWindow : Window, IrisLib.IServerChatCallback
    {
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public SignInWindow()
        {
            InitializeComponent();
            new ClientData();
            ClientData.isClose = true;
        }

        /// <summary>
        /// Метод для обработки события закрытия окна.
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        void WindowClosed(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ClientData.isClose)
            {
                Application.Current.Shutdown();
            }
            else
            {
                ClientData.isClose = true;
            }
        }

        /// <summary>
        /// Метод для обработки события нажания на кнопку "Войти".
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        private void ButtonClickSignIn(object sender, RoutedEventArgs e)
        {
            ClientData.CurrentUser = ClientData.database.GetUserFromList(tblogin.Text);
            if (ClientData.CurrentUser != null)
            {
                if (ClientData.CurrentUser.Password.Equals(tbPassword.Password))
                {
                    ClientData.ShowMainWindow();
                    ClientData.isClose = false;
                    this.Close();
                }
                else
                {
                    lableLoginError.Visibility = Visibility.Visible;
                    tblogin.Text = null;
                    tbPassword.Password = null;
                }
            }
            else
            {
                lableLoginError.Visibility = Visibility.Visible;
                tblogin.Text = null;
                tbPassword.Password = null;
                ClientData.CurrentUser = new User();
            }
        }

        /// <summary>
        /// Метод для получения базы данных от сервера.
        /// </summary>
        /// <param name="database"> получаемая база данных </param>
        public void DatabaseCallback(Database database)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод для обработки события нажания на кнопку "Зарегистрироваться".
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        private void ButtonClickSignUp(object sender, RoutedEventArgs e)
        {
            (new SignUpWindow()).Show();
            ClientData.isClose = false;
            this.Close();
        }

        /// <summary>
        /// Метод для получения файла с сервера.
        /// </summary>
        /// <param name="file"> получаемый файл </param>
        public void FileCallback(IrisLib.File file)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод для получения идентификатора пользователя от сервера.
        /// </summary>
        /// <param name="id"> получаемый идентификатор пользователя </param>
        public void UserIdCallback(int id)
        {
            throw new NotImplementedException();
        }
    }
}
