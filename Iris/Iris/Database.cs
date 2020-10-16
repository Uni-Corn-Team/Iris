using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Iris
{
    [Serializable]
    public static class Database
    {
        public static List<User> Users { get; set; }

        public static List<Message> Messages { get; set; }

        static Database()
        {
            Users = new List<User>();
            Messages = new List<Message>();
        }

        public static bool Load()
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream("db_users"+ ".dat", FileMode.OpenOrCreate))
                {
                    Users = (List<User>)formatter.Deserialize(fs);
                }
                using (FileStream fs = new FileStream("db_messages" + ".dat", FileMode.OpenOrCreate))
                {
                    Messages = (List<Message>)formatter.Deserialize(fs);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool Save()
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream("db_users" + ".dat", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, Users);
                }
                using (FileStream fs = new FileStream("db_messages" + ".dat", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, Messages);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
