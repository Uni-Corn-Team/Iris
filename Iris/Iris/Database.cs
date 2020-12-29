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

        //we need static indexes of objects to add new objects (i suggest use count as ID; rewrite these 3 fields every time we change the database)
        //also need rewrite DB (.db file) because ID
        public static int UsersCountAsNextID;
        public static int ChatsCountAsNextID;
        public static int MessagesCountAsNextID;

        static Database()
        {
            Users = new List<User>();
            Chats = new List<Chat>();
        }

        public static User getUserFromList(string login)
        {
            for (int i = 0; i < Users.Count(); i++)
            {
                if (Users[i].Login.Equals(login))
                {
                    return Users[i];
                }
            }
            return null;
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

        public static Chat getChatFromList(int id)
        {
            for (int i = 0; i < Chats.Count(); i++)
            {
                if (Chats[i].ID == id)
                    return Chats[i];
            }
            return null;
        }

        public static Chat getChatFromList(string name)
        {
            for (int i = 0; i < Chats.Count(); i++)
            {
                if (Chats[i].Name.Equals(name))
                    return Chats[i];
            }
            return null;
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

                UsersCountAsNextID = Users.Count;

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
            Users.Add(user);
            try
            {
                using (var connection = new SqliteConnection(DBPath))
                {
                    if(user.ID == 0)
                    {
                        UsersCountAsNextID += 1;
                        user.ID = UsersCountAsNextID;
                    }


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
                    connection.Close();
                    connection.Open();
                    for (int i = 0; i < Chats.Count(); i++)
                    {
                        command = connection.CreateCommand();
                        command.CommandText =
                        @"
                         SELECT *
                         FROM Messages
                         WHERE Chat_id LIKE @id
                        ";
                        command.Parameters.AddWithValue("@id", Chats[i].ID);


                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Chats[i].Messages.Add(new Message(reader.GetInt32(0), getUserFromList(reader.GetInt32(2)), reader.GetString(3), DateTime.Parse(reader.GetString(5))));
                            }
                        }
                        
                        command = connection.CreateCommand();
                        command.CommandText =
                        @"
                         SELECT *
                         FROM LinkUC
                         WHERE Chat_id LIKE @id
                        ";
                        command.Parameters.AddWithValue("@id", Chats[i].ID);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int tmp = reader.GetInt32(0);
                                Chats[i].Members.Add(getUserFromList(tmp));
                                if (reader.GetString(2).Equals("root"))
                                    Chats[i].RootID = tmp;
                            }
                        }
                        
                    }
                        
                    connection.Close();
                }

                ChatsCountAsNextID = Chats.Count;
                MessagesCountAsNextID = 0;
                foreach (Chat chat in Chats)
                {
                    MessagesCountAsNextID += chat.Messages.Count;
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return false;
            }
        }

        public static bool changePassword(User user)
        {
            try
            {
                using (var connection = new SqliteConnection(DBPath))
                {

                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText =
                    @"
                    UPDATE Users
                    SET Password = @password
                    WHERE User_id LIKE @id
                    ";
                    command.Parameters.AddWithValue("@id", user.ID);
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

        public static bool addMessageToChat(Message message, Chat chat)
        {
            try
            {
                MessagesCountAsNextID += 1;
                message.ID = MessagesCountAsNextID;
                getChatFromList(chat.ID).Messages.Add(message);
                addChatToDB(getChatFromList(chat.ID));
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
            
        }

        public static bool addChatToDB(Chat chat)
        {
            try
            {
                using (var connection = new SqliteConnection(DBPath))
                {
                    if(chat.ID == 0)
                    {
                        ChatsCountAsNextID += 1;
                        chat.ID = ChatsCountAsNextID;
                        Chats.Add(chat);
                    }


                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText =
                    @"
                    INSERT OR IGNORE 
                    INTO 'Chats'('Chat_id','name')
                    VALUES (@Chat_id, @name)
                    ";
                    command.Parameters.AddWithValue("@Chat_id", chat.ID);
                    command.Parameters.AddWithValue("@name", chat.Name);

                    command.ExecuteNonQuery();

                    for (int i = 0; i < chat.Messages.Count(); i++)
                    {
                        command = connection.CreateCommand();
                        command.CommandText =
                        @"
                        INSERT OR IGNORE 
                        INTO 'Messages'('Mes_id','Chat_id', 'Sender_id', 'Text','DateTime')
                        VALUES (@Mes_id, @Chat_id, @Sender_id, @Text, @DateTime)
                        ";

                        command.Parameters.AddWithValue("@Mes_id", chat.Messages[i].ID);
                        command.Parameters.AddWithValue("@Chat_id", chat.ID);
                        command.Parameters.AddWithValue("@Sender_id", chat.Messages[i].Sender.ID);
                        command.Parameters.AddWithValue("@Text", chat.Messages[i].Text);
                        command.Parameters.AddWithValue("@DateTime", chat.Messages[i].Date.ToString());

                        command.ExecuteNonQuery();
                    }

                    for (int i = 0; i < chat.Members.Count(); i++)
                    {
                        command = connection.CreateCommand();
                        command.CommandText =
                        @"
                        INSERT OR IGNORE 
                        INTO 'LinkUC'('User_id','Chat_id', 'Rights')
                        VALUES (@User_id, @Chat_id, @Rights)
                        ";
                        command.Parameters.AddWithValue("@User_id", chat.Members[i].ID);
                        command.Parameters.AddWithValue("@Chat_id", chat.ID);
                        if (chat.RootID != chat.Members[i].ID)
                            command.Parameters.AddWithValue("@Rights", "user");
                        else
                            command.Parameters.AddWithValue("@Rights", "root");
                        command.ExecuteNonQuery();
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

        public static bool Update()
        {
            if (getUsersFromDB() && getChatsFromDB())
                return true;
            return false;
        }

        public new static string ToString()
        {
            string str = "Users: \n";
            for (int i = 0; i < Users.Count(); i++)
            {
                str += Users[i].ToString();
            }
            str += "\nChats:\n";
            for (int i = 0; i < Chats.Count(); i++)
            {
                str += Chats[i].ToString();
            }
            return str;
        }
    }
}

