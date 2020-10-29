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
                Database.getUsers();
                Database.addUser(new User(4, "user9", "sur_user9", "us9", 13, "user9", "user9"));
                Database.getUsers();
                Console.WriteLine(Database.Users[0].Name);
                Console.WriteLine(Database.Users[1].Name);
                Console.WriteLine(Database.Users[2].Name);
                Console.WriteLine(Database.Users[3].Name);
                //end test

                Console.WriteLine("Хост стартовал!");
                Console.ReadLine();
            }
        }
    }
}
