using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Microsoft.Data.Sqlite;

//SELECT Users.User_id, LinkUC.Chat_id, Chats.Name, Messages.Mes_id, Messages.Sender_id, Messages.Doc, Messages.text 
//FROM Users JOIN LinkUC JOIN Chats JOIN Messages 
//ON Users.User_id = 1 AND Users.User_id = LinkUC.User_id AND LinkUC.Chat_id = Chats.Chat_id AND Chats.Chat_id = Messages.Chat_id

namespace Iris
{
    [Serializable]
    public static class Database
    {
        //Maybe change it when will realese to new path(this path from bin\debug
        private const string DBPath = "Data Source=..\\..\\..\\Database\\database.db";
        public static List<User> Users { get; set; }

        public static List<Chat> Chats { get; set; }

        static Database()
        {
            Users = new List<User>();
            Chats = new List<Chat>();
        }

        public static bool getUsersFromDB()
        {
            Console.Out.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
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
                    connection.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return false;
            }
        }
    

        public static bool addUserToDB(User user)
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
                    INTO 'Users'('User_id','Name','Surname','Nickname','Age','Login','Password') 
                    VALUES (@id, @name, @surname, @nickname, @age, @login, @password)
                    ";
                    command.Parameters.AddWithValue("@id", user.ID);
                    command.Parameters.AddWithValue("@name", user.Name);
                    command.Parameters.AddWithValue("@surname", user.Surname);
                    command.Parameters.AddWithValue("@nickname", user.Nickname);
                    command.Parameters.AddWithValue("@age", user.Age);
                    command.Parameters.AddWithValue("@login", user.Login);
                    command.Parameters.AddWithValue("@password", user.Password);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return false;
            }
        }

        public static User getUserFromList(int id)
        {
            for (int i = 0; i < Users.Count(); i++)
            {
                if (Users[i].ID == id)
                    return Users[i];
            }
            return null;
        }
        public static bool getChatsFromDB()
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
                    FROM Chats
                    ";

                    Chats.Clear();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Chats.Add(new Chat(reader.GetInt32(0), reader.GetString(1)));
                        }
                    }

                    for (int i = 0; i < Chats.Count(); i++)
                    {
                        int id = Chats[i].ID;
                        command = connection.CreateCommand();
                        command.CommandText =
                        @"
                         SELECT *
                         FROM Messages
                         WHERE Chat_id = 'id'
                        ";
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.GetString(4) == null)
                                    Chats[i].Messages.Add(new Message(reader.GetInt32(0), getUserFromList(reader.GetInt32(2)), reader.GetString(3)));
                            }
                        }
                    }
                    connection.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return false;
            }
        }



        public static bool addChatToDB(Chat chat)
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
                    INTO 'Chats'('Chat_id','surname','nickname','age','login','password') 
                    VALUES (@name, @surname, @nickname, @age, @login, @password)
                    ";
                    //TODO
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return false;
            }
        }

        public static bool Update()
        {
            if (getUsersFromDB() && getChatsFromDB())
                return true;
            return false;
        }
    }
}

