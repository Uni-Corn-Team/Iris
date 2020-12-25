using System;
using System.Windows;

namespace IrisClient
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public AddUserWindow()
        {
            InitializeComponent();
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
        /// Метод для обработки события нажания на кнопку "Добавить пользователя в чат".
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        private void ButtonClickAddUserToChat(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(tbID.Text, out int ID))
            {
                if (ClientData.database.GetUserFromList(ID) != null && ClientData.CurrentUser.CurrentChatID != -1)
                {
                    ClientData.client.AddUserToChat(ClientData.CurrentUser, ClientData.database.GetUserFromList(ID), ClientData.CurrentUser.CurrentChatID);
                    this.Close();
                }
                else
                {
                    lableNonexistingUser.Visibility = Visibility.Visible;
                    lableNotAnInteger.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                lableNotAnInteger.Visibility = Visibility.Visible;
                lableNonexistingUser.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Метод для обработки события закрытия окна.
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow.isWindowOpenAddUser = false;
        }
    }
}
