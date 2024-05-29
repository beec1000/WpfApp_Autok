using System;
using System.Collections.Generic;
using System.IO;

namespace Wpf_Autok
{
    internal class Car
    {
        public string BrandName { get; set; }
        public string Type { get; set; }
        public int Vintage { get; set; }
        public string Color { get; set; }
        public string Source { get; set; }

        public Car(string name, string type, int vintage, string color, string source)
        {
            BrandName = name;
            Type = type;
            Vintage = vintage;
            Color = color;
            Source = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"../../../src/IMAGES/{source}"));
        }

        public static List<Car> FromFile(string path)
        {
            List<Car> cars = new List<Car>();

            string[] lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                string[] parts = line.Split(';');

                string carName = parts[0];
                string carType = parts[1];
                int carVintage = int.Parse(parts[2]);
                string carColor = parts[3];
                string carImageS = parts[4];

                Car car = new Car(carName, carType, carVintage, carColor, carImageS);
                cars.Add(car);
            }

            return cars;
        }

        public override string ToString()
        {
            return $"{BrandName} {Type} | {Vintage} | {Color}";
        }
    }
}
