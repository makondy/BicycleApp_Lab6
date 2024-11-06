using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BicycleApp_Lab6;


namespace BicycleApp_Lab6
{
    using System;

    namespace BicycleApp_Lab6
    {
        public class Bicycle : Vehicle
        {
        
            public string Brand { get; set; }
            public string Model { get; set; }
            public string Type { get; set; } // Тип велосипеда (наприклад, гірський, міський тощо)
            public double Weight { get; set; } // Вага велосипеда
            public int Gears { get; set; } // Кількість передач
            public double Mileage { get; set; } // Пробіг
            public double Distance { get; set; } // Відстань
            public double Time { get; set; } // Час
            public string Main { get; set; }
            public double Speed => CalculateSpeed();
           
            // Конструктор без параметрів
            public Bicycle() { }

            // Конструктор з параметрами
            public Bicycle(string brand, string model, string type, double weight, int gears, double mileage, double distance, double time)
            {
                Brand = brand;
                Model = model;
                Type = type;
                Weight = weight;
                Gears = gears;
                Mileage = mileage;
                Distance = distance;
                Time = time;
            }

            // Метод для обчислення швидкості
            public double CalculateSpeed() => Time > 0 ? Distance / Time : 0;
        }
    }


}
