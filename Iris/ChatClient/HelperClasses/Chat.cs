using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.HelperClasses
{
    [Serializable]
    public class Chat
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public int RootID { get; set; }
        public List<User> Members { get; set; }
        public List<Message> Messages { get; set; }
        public Chat() { }
        public Chat(int id, string name)
        {
            this.ID = id;
            this.Name = name;
            this.Members = new List<User>();
            this.Messages = new List<Message>();
        }

        public override string ToString()
        {
            string str = "Chat id: " + this.ID + "\nMembers:\n";
            for (int i = 0; i < this.Members.Count(); i++)
            {
                str += this.Members[i].ToString();
            }
            str += "\nMessages:\n";
            for (int i = 0; i < this.Messages.Count(); i++)
            {
                str += this.Messages[i].ToString();
            }
            return str;
        }

        public ArrayList ConvertToArrayList()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(ID);
            arrayList.Add(Name);
            arrayList.Add(RootID);
            ArrayList membs = new ArrayList();
            foreach (User member in Members)
            {
                membs.Add(member.ConvertToArrayList());
            }
            arrayList.Add(membs);
            ArrayList mesgs = new ArrayList();
            foreach (User mes in Members)
            {
                mesgs.Add(mes.ConvertToArrayList());
            }
            arrayList.Add(mesgs);

            return arrayList;
        }

        public static Chat Disconvert(object[] list)
        {
            Chat chat = new Chat();
            chat.ID = (int)list[0];
            chat.Name = (string)list[1];
            chat.RootID = (int)list[2];
            chat.Members = new List<User>();
            foreach (object[] memb in (ArrayList)list[3])
            {
                User member = new User()
                {
                    ID = User.Disconvert((object[])memb).ID,
                    Name = User.Disconvert((object[])memb).Name,
                    Surname = User.Disconvert((object[])memb).Surname,
                    Nickname = User.Disconvert((object[])memb).Nickname,
                    Age = User.Disconvert((object[])memb).Age,
                    Login = User.Disconvert((object[])memb).Login,
                    Password = User.Disconvert((object[])memb).Password
                };
                chat.Members.Add(member);
            }
            chat.Messages = new List<Message>();
            foreach (ArrayList mes in (ArrayList)list[4])
            {
                Message message = new Message()
                {
                    ID = (int)mes[0],
                    Sender = new User()
                    {
                        ID = User.Disconvert((object[])mes[1]).ID,
                        Name = User.Disconvert((object[])mes[1]).Name,
                        Surname = User.Disconvert((object[])mes[1]).Surname,
                        Nickname = User.Disconvert((object[])mes[1]).Nickname,
                        Age = User.Disconvert((object[])mes[1]).Age,
                        Login = User.Disconvert((object[])mes[1]).Login,
                        Password = User.Disconvert((object[])mes[1]).Password
                    },
                    Text = (string)mes[2],
                    HasFile = (bool)mes[3],
                    File = new File()
                    {
                        Name = File.Disconvert((ArrayList)mes[4]).Name,
                        fs = File.Disconvert((ArrayList)mes[4]).fs,
                        Size = File.Disconvert((ArrayList)mes[4]).Size
                    },
                    Date = (DateTime)mes[5]
                };
            }
            return chat;
        }
    }
}
