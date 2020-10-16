using System.ServiceModel;
using System.Runtime.Serialization;
using System;

namespace Iris
{
    [Serializable]
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        /// <summary>
        /// user's name
        /// </summary>
        public string Nickname { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        /// <summary>
        /// user's id
        /// </summary>
        public int ID { get; set; }

        public Chat CurrentChat { get; set; }


        /// <summary>
        /// information about connection user to server
        /// </summary>
        public OperationContext OperationContext { get; set; }
    }


}
