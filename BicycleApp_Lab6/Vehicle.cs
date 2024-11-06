using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleApp_Lab6
{
    public abstract class Vehicle
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

        public double CalculateSpeed() => Time > 0 ? Distance / Time : 0;
    }

}
