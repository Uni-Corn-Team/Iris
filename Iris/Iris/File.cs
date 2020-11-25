using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Iris
{
    [Serializable]
    [DataContract]
    public class File
    {
        [DataMember] public string Name { get; set; }
        [DataMember] public FileStream fs { get; set; }
        [DataMember] public int Size { get; set; }

        
    }
}
