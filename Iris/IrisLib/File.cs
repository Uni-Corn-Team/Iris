using System;
using System.Runtime.Serialization;

namespace IrisLib
{
    /// <summary>
    /// Класс для описания объекта "Файл".
    /// </summary>
    [Serializable]
    [DataContract]
    public class File
    {
        /// <summary>
        /// Название файла.
        /// </summary>
        [DataMember] public string Name { get; set; }

        /// <summary>
        /// Бинарное представление файла.
        /// </summary>
        [DataMember] public Byte[] Binary { get; set; }

    }
}
