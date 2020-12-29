using System;
using System.ServiceModel;

namespace IrisHost
{
    /// <summary>
    /// Класс, содержащий метод для запуска хоста.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Метод для запуска хоста.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            using (var host = new ServiceHost(typeof(IrisLib.ServiceChat)))
            {
                host.Open();
                Console.WriteLine("Host started");
                Console.ReadLine();
            }
        }
    }
}
