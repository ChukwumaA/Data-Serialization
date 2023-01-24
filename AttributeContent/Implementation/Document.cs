using System;
using AttributeContent.CustomAttribute;

namespace AttributeContent.Implementation
{
    public class Document
    {
        [Document("A simple torchlight")]
        public class Torchlight
        {
            private IBattery battery;

            [Document("This adds the battery to the torchlight", "IBattery")]

            public Torchlight(IBattery battery)
            {
                this.battery = battery;
            }

            [Document("DisplayBatteryName")]
            public void DisplayBatteryName()
            {
                Console.WriteLine(battery.BrandName);
            }
         
            [Document("DisplayBatteryLife")]
            public void DisplayBatteryLife()
            {
                Console.WriteLine(battery.BatteryLife);
            }

            [Document("This indicate that we can turn on the torchlight")]
            public static bool CanTurnOn => true;

            [Document("This indicates the brightness of the battery")]
            public enum TorchBrightness
            {
                Low = 1,
                Medium = 2,
                High = 3
            }

        }

        public interface IBattery
        {
            public string BrandName { get; }

            public int BatteryLife { get; }
        }

        [Document("This is a duracell battery that works with a torchlight")]
        public class Duracell : IBattery
        {
            [Document("This is the brand name of the battery", "", "string")]
            public string BrandName => "Duracell";

            [Document("This is the life of the battery", "", "int")]
            public int BatteryLife => 60;
        }

    
        [Document("This is a Tiger battery that works with a torchlight")]

        public class Tiger : IBattery
        {
       
            [Document("This is the brand name of the battery", "", "string")]
            public string BrandName => "Tiger";


            [Document("This is the life of the battery", "", "int")]

            public int BatteryLife => 35;
        }

    }
}