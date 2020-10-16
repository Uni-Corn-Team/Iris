using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using ChatClient.ServiceChat;
using Iris;

namespace ChatClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IServiceChatCallback
    {
        bool isConnected = false;
        ServiceChatClient client;
        int ID;

        public MainWindow()
        {
            InitializeComponent();
            lbUserInfo.Items.Add(SignIn.user.Surname + " " + SignIn.user.Name);
            lbUserInfo.Items.Add(SignIn.user.Nickname);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        /*void ConnectUser()
        {
            if (!isConnected)
            {
                client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
                ID = client.Connect(tbUserName.Text);
                tbUserName.IsEnabled = false;
                bConnectDisconnect.Content = "Disconnect";
                isConnected = true;
            }
        }*/

        /*void DisconnectUser()
        {
            if (isConnected)
            {
                client.Disconnect(ID);
                client = null;
                tbUserName.IsEnabled = true;
                bConnectDisconnect.Content = "Connect";
                isConnected = false;
            }

        }*/

        /*private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isConnected)
            {
                DisconnectUser();
            }
            else
            {
                ConnectUser();
            }

        }*/

        private void New_Dialog(object sender, RoutedEventArgs e)
        {
            lbChat.Items.Add("dialog-=-\n");
        }

        private void Open_Dialog(object sender, RoutedEventArgs e)
        {
            lbChat.Items.Add("dialog-=-\n");
        }

        public void MessageCallback(string message)
        {
            lbChat.Items.Add(message);
            lbChat.ScrollIntoView(lbChat.Items[lbChat.Items.Count - 1]);
        }

        /*private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DisconnectUser();
        }*/

        /*private void tbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (client != null)
                {
                    client.SendMessage(tbMessage.Text, ID);
                    tbMessage.Text = string.Empty;
                }
            }
        }*/


    }
}
