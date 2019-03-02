using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    public class Car
    {
        public  string Model { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public int Codan { get; set; }

        private int codan = 123;
        protected int numberOfSeats = 4;

        public Car()
        {

        }


        public Car(string fileName)
        {
            Car carFromFile = Car.DeserializeACar(fileName);

            this.Model = carFromFile.Model;
            this.Brand = carFromFile.Brand;
            this.Year = carFromFile.Year;
            this.Color = carFromFile.Color;
        }

        public Car(string model, string brand, int year, string color, int codan, int numberofseats)
        {
            this.Model = model;
            this.Brand = brand;
            this.Year = year;
            this.Color = color;

            this.codan = codan;
            this.numberOfSeats = numberofseats;
        }

        public int GetCodan()
        {
            return this.codan;
        }


        public int GetNumberOfSeats()
        {
            return this.numberOfSeats;
        }

        protected void ChangeNumberOfSeats(int numberofseats)
        {
            if (numberofseats > 0)
            {
                this.numberOfSeats = numberofseats;
            }
        }

        public static Car DeserializeACar(string fileName)
        {
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Car));

            Car result = null;

            using (Stream file = new FileStream(fileName, FileMode.Open))
            {
                result = myXmlSerializer.Deserialize(file) as Car;

            }

            Console.WriteLine("Deserialized succeed!");

            return result;
        }

        public static void SerializeACar(string fileName, Car car)
        {
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Car));

            using (Stream file = new FileStream(fileName, FileMode.Create)) 
            {
                myXmlSerializer.Serialize(file, car);

            } 

            Console.WriteLine("Serialized succeed!");
        }

        public static void SerializeACarArray(string fileName, Car[] cars)
        {
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Car[]));

            using (Stream file = new FileStream(fileName, FileMode.Create)) 
            {
                myXmlSerializer.Serialize(file, cars);

            } 

            Console.WriteLine("Serialized succeed!");
        }

        public static Car[] DeserializeACarArray(string fileName)
        {
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Car[]));

            Car[] result = null;

            using (Stream file = new FileStream(fileName, FileMode.Open)) 
            {
                result = myXmlSerializer.Deserialize(file) as Car[];

            } 

            Console.WriteLine("Deserialized succeed!");

            return result;
        }

        public bool CarCompare(string fileName)
        {
            Car carFromFile = Car.DeserializeACar(fileName);
            if (this.Model == carFromFile.Model &&
                this.Brand == carFromFile.Brand &&
                this.Year == carFromFile.Year &&
                this.Color == carFromFile.Color)
            {
                return true;
            }
            return false;
        }


        public override string ToString()
        {
            return $"Car Modle : {this.Model} Bard : {this.Brand} Year : {this.Year} Color : {this.Color}";
        }
    }
}
