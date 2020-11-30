using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace IrisLib
{
    [Serializable]
    [DataContract]
    public class File
    {
        [DataMember] public string Name { get; set; }
        //[DataMember] public FileStream fs { get; set; }
        [DataMember] public Byte[] Binary { get; set; }

    }
}
