using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Iris;

namespace ChatHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(Iris.ServiceChat)))
            {
                //host.Open();

                //Please delete this code in future, when host will work!!!
                //this code is temporary test for methods of Database
                //start test
                Database.getUsersFromDB();
                Database.getChatsFromDB();
                Console.WriteLine(Database.ToString());
                User us_test = new User(8, "test", "test", "test", 13, "test", "test");
                Database.addUserToDB(us_test);
                Chat test = new Chat(2, "test");
                test.Members.Add(us_test);
                test.Members.Add(Database.Users[0]);
                test.Members.Add(Database.Users[1]);
                test.Messages.Add(new Message(4, Database.Users[0], "ssss"));
                test.Messages.Add(new Message(5, Database.Users[1], "ssdsdsdss"));
                Database.addChatToDB(test);
                Database.getUsersFromDB();
                Database.getChatsFromDB();
                Console.WriteLine(Database.ToString());
                //end test

                Console.WriteLine("Хост стартовал!");
                Console.ReadLine();
            }
        }
    }
}
