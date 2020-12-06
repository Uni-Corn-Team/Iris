using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace IrisLib
{
    [Serializable]
    [DataContract]
    public class Message
    {
        [DataMember] public int ID { get; set; }
        [DataMember] public User Sender { get; set; }
        [DataMember] public string Text { get; set; }
        [DataMember] public bool HasFile { get; set; }
        [DataMember] public string Doc { get; set; }
        [DataMember] public File File { get; set; }
        [DataMember] public DateTime Date { get; set; }
        public Message(int id, User sender, string text)
        {
            this.ID = id;
            this.Sender = sender;
            this.Text = text;
            this.Date = DateTime.Now;
            this.HasFile = false;
            this.Doc = null;
        }

        public Message(int id, User sender, string text, DateTime time)
        {
            this.ID = id;
            this.Sender = sender;
            this.Text = text;
            this.Date = time;
            this.HasFile = false;
            this.Doc = null;
        }

        public Message(int id, User sender, string text, DateTime time, string Doc)
        {
            this.ID = id;
            this.Sender = sender;
            this.Text = text;
            this.Date = time;
            this.HasFile = false;
            this.Doc = Doc;
        }

        public override string ToString()
        {
            return "Mes Id: " + this.ID + " Text: " + this.Text + "\nSender: " + this.Sender.ToString();
        }

        public string ToShortString()
        {
            return Date + " | " + Sender.Nickname + " |\n\t" + Text;
        }
    }
}
