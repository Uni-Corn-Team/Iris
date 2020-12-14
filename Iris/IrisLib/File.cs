using System;
using System.Runtime.Serialization;

namespace IrisLib
{
    [Serializable]
    [DataContract]
    public class File
    {
        [DataMember] public string Name { get; set; }
        [DataMember] public Byte[] Binary { get; set; }

    }
}
