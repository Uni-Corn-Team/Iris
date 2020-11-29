using IrisLib;
using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Shapes;

namespace IrisClient
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        private bool isShowID = true;
        private void ButtonClickBack(object sender, EventArgs e)
        {
            this.Close();
        }
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void ButtonClickAddUserToChat(object sender, RoutedEventArgs e)
        {
            if (ClientData.database.GetUserFromList(int.Parse(tbID.Text)) != null && ClientData.CurrentUser.CurrentChatID != -1)
            {
                ClientData.client.AddUserToChat(ClientData.CurrentUser, ClientData.database.GetUserFromList(int.Parse(tbID.Text)), ClientData.CurrentUser.CurrentChatID);
                this.Close();
            }
            else
            {
                //write that user isn't exists and delete next two lines
                this.Close();
            }


        }

        private void RemoveTextID(object sender, EventArgs e)
        {
            if(isShowID)
            {
                tbID.Text = null;
                tbID.Foreground = Brushes.Black;
                isShowID = false;
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            new MainWindow().Show();
        }

       
    }
}
