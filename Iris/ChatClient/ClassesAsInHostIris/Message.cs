using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iris
{
    [Serializable]
    public class Message
    {
        public int ID { get; set; }
        public User Sender { get; set; }
        public string Text { get; set; }
        public bool HasFile { get; set; }
        public File File { get; set; }
        public DateTime Date { get; set; }

        public Message()
        {

        }

        public Message(int id, User sender, string text)
        {
            this.ID = id;
            this.Sender = sender;
            this.Text = text;
            this.Date = DateTime.Now;
            this.HasFile = false;
        }

        public Message(int id, User sender, string text, DateTime time)
        {
            this.ID = id;
            this.Sender = sender;
            this.Text = text;
            this.Date = time;
            this.HasFile = false;
        }

        public override string ToString()
        {
            return "Mes Id: " + this.ID + " Text: " + this.Text + "\nSender: " + this.Sender.ToString();
        }

        public ArrayList ConvertToArrayList()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(ID);
            arrayList.Add(Sender.ConvertToArrayList());
            arrayList.Add(Text);
            arrayList.Add(HasFile);
            arrayList.Add(File.ConvertToArrayList());
            arrayList.Add(Date);

            return arrayList;
        }

        public static Message Disconvert(ArrayList list)
        {
            return new Message()
            {
                ID = (int)list[0],
                Sender = new User()
                {
                    ID = User.Disconvert((ArrayList)list[1]).ID,
                    Name = User.Disconvert((ArrayList)list[1]).Name,
                    Surname = User.Disconvert((ArrayList)list[1]).Surname,
                    Nickname = User.Disconvert((ArrayList)list[1]).Nickname,
                    Age = User.Disconvert((ArrayList)list[1]).Age,
                    Login = User.Disconvert((ArrayList)list[1]).Login,
                    Password = User.Disconvert((ArrayList)list[1]).Password
                },
                Text = (string)list[2],
                HasFile = (bool)list[3],
                File = new File()
                {
                    Name = File.Disconvert((ArrayList)list[4]).Name,
                    fs = File.Disconvert((ArrayList)list[4]).fs,
                    Size = File.Disconvert((ArrayList)list[4]).Size
                },
                Date = (DateTime)list[5]
            };
        }
    }
}
