using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Microsoft.Data.Sqlite;


namespace Iris
{
    [Serializable]
    public static class Database
    {
        private const string DBPath = "Data Source=E:\\PROJECTS\\UniCorn\\IRIS\\Iris\\Iris\\Database\\database.db";
        public static List<User> Users { get; set; }

        public static List<Message> Messages { get; set; }

        static Database()
        {
            Users = new List<User>();
            Messages = new List<Message>();
        }

        public static bool getUsers()
        {
            try
            {
                using (var connection = new SqliteConnection(DBPath))
                {

                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText =
                    @"
                    SELECT * 
                    FROM Users 
                    ";

                    Users.Clear();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Users.Add(new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                                reader.GetString(3), reader.GetInt32(4), reader.GetString(5), reader.GetString(6)));
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return false;
            }
        }
    

        public static bool setUser(User user)
        {
            try
            {
                using (var connection = new SqliteConnection(DBPath))
                {

                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText =
                     @"
                    INSERT OR IGNORE 
                    INTO 'Users'('name','surname','nickname','age','login','password') 
                    VALUES (@name, @surname, @nickname, @age, @login, @password)
                    ";
                    command.Parameters.AddWithValue("@id", user.ID);
                    command.Parameters.AddWithValue("@name", user.Name);
                    command.Parameters.AddWithValue("@surname", user.Surname);
                    command.Parameters.AddWithValue("@nickname", user.Nickname);
                    command.Parameters.AddWithValue("@age", user.Age);
                    command.Parameters.AddWithValue("@login", user.Login);
                    command.Parameters.AddWithValue("@password", user.Password);
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return false;
            }
        }
    

        public static bool Load()
        {
            return false;
        }

        public static bool Save()
        {
            return false;
        }

    }
}
