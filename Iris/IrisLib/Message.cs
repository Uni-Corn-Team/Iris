using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisLib
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
    }
}
