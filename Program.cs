using System;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Car mycar = new Car("COROLA","TOYOTA",2019,"White",321,4);
           // XmlSerializer CarSerializer = new XmlSerializer(typeof(Car));
            //using (Stream file = new FileStream(@"C:\Users\ADMIN\Downloads\XMLcar", FileMode.Create))
           // {
            //    CarSerializer.Serialize(file, mycar);
            //}

            Car othercar = new Car(@"C:\Users\ADMIN\Downloads\XMLcar");
            Console.WriteLine(othercar);
        }
    }
}
