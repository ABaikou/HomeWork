using System;

namespace AviaCompany
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Data
            PassengerPlane b777 = new PassengerPlane()
            {
                Manufacturer = "Boeing",
                Model = "B777-300ER",
                Length = 73.9,
                Height = 18.5,
                WingSpan = 64.8,
                MaxTakeOffWeight = 317.5,
                MaxFlightRange = 11200,
                MaxAltitude = 13.1, 
                CruisingSpeed = 905,
                FuelCapacity = 181280,
                AircraftType = "Long-haul passenger aircraft",
                PassengerCapacity = 365,
                CabinConfig = "30C+48W(Comfort)+324Y"
            };
            PassengerPlane b737 = new PassengerPlane()
            {
                Manufacturer = "Boeing",
                Model = "B737-800",
                Length = 39.5,
                Height = 12.62,
                WingSpan = 34.32,
                MaxTakeOffWeight = 79.0,
                MaxFlightRange = 4500,
                MaxAltitude = 12.5,
                CruisingSpeed = 900,
                FuelCapacity = 26022,
                AircraftType = "Short and medium-haul passenger aircraft",
                PassengerCapacity = 189,
                CabinConfig = "20C+138Y"
            };
            PassengerPlane a350 = new PassengerPlane()
            {
                Manufacturer = "Airbus",
                Model = "A350-900",
                Length = 66.8,
                Height = 17.1,
                WingSpan = 64.75,
                MaxTakeOffWeight = 268.0,
                MaxFlightRange = 12400,
                MaxAltitude = 13.1,
                CruisingSpeed = 910,
                FuelCapacity = 138000,
                AircraftType = "Long-haul passenger aircraft",
                PassengerCapacity = 440,
                CabinConfig = "28C+24W(Comfort)+264Y"
            };
            PassengerPlane a330 = new PassengerPlane()
            {
                Manufacturer = "Airbus",
                Model = "A330-200",
                Length = 58.8,
                Height = 17.39,
                WingSpan = 60.3,
                MaxTakeOffWeight = 230.0,
                MaxFlightRange = 11200,
                MaxAltitude = 12.5,
                CruisingSpeed = 900,
                FuelCapacity = 139090,
                AircraftType = "Long-haul passenger aircraft",
                PassengerCapacity = 375,
                CabinConfig = "34C+ 207Y"
            };
            PassengerPlane a321 = new PassengerPlane()
            {
                Manufacturer = "Airbus",
                Model = "A321-200",
                Length = 44.51,
                Height = 11.76,
                WingSpan = 35.8,
                MaxTakeOffWeight = 89.0,
                MaxFlightRange = 3800,
                MaxAltitude = 12.1,
                CruisingSpeed = 830,
                FuelCapacity = 24050,
                AircraftType = "Short and medium-haul passenger aircraft",
                PassengerCapacity = 170,
                CabinConfig = "28C+142Y"
            };
            PassengerPlane a320 = new PassengerPlane()
            {
                Manufacturer = "Airbus",
                Model = "A320-200",
                Length = 37.57,
                Height = 11.76,
                WingSpan = 35.8,
                MaxTakeOffWeight = 75.5,
                MaxFlightRange = 4000,
                MaxAltitude = 12.1,
                CruisingSpeed = 830,
                FuelCapacity = 24210,
                AircraftType = "Short and medium-haul passenger aircraft",
                PassengerCapacity = 140,
                CabinConfig = "20C+ 120Y"
            };
            PassengerPlane sj100 = new PassengerPlane()
            {
                Manufacturer = "Sukhoi",
                Model = "SuperJet 100-95B",
                Length = 29.94,
                Height = 10.28,
                WingSpan = 27.80,
                MaxTakeOffWeight = 45.5,
                MaxFlightRange = 2400,
                MaxAltitude = 12.2,
                CruisingSpeed = 840,
                FuelCapacity = 15805,
                AircraftType = "Short and medium-haul passenger aircraft",
                PassengerCapacity = 87,
                CabinConfig = "12С+ 75Y"
            };
            PassengerPlane e175 = new PassengerPlane()
            {
                Manufacturer = "Embraer",
                Model = "E-175",
                Length = 31.68,
                Height = 9.67,
                WingSpan = 26.0,
                MaxTakeOffWeight = 38.7,
                MaxFlightRange = 3334,
                MaxAltitude = 12.5,
                CruisingSpeed = 890,
                FuelCapacity = 11840,
                AircraftType = "Short and medium-haul passenger aircraft",
                PassengerCapacity = 76,
                CabinConfig = "12С+64Y"
            };
            PassengerPlane e195 = new PassengerPlane()
            {
                Manufacturer = "Embraer",
                Model = "E-195",
                Length = 38.65,
                Height = 10.28,
                WingSpan = 28.72,
                MaxTakeOffWeight = 50.8,
                MaxFlightRange = 3900,
                MaxAltitude = 12.5,
                CruisingSpeed = 880,
                FuelCapacity = 16250,
                AircraftType = "Short and medium-haul passenger aircraft",
                PassengerCapacity = 107,
                CabinConfig = "11С+96Y"
            };


            #endregion

            double minFuelConsumption = InputValue("minimum", 0, 20);
            double maxFuelConsumption = InputValue("maximum", minFuelConsumption, 25);
            Console.WriteLine("_________________________________________________________");

            //AEROFLOT
            {
                AviaCompany aeroFlot = new AviaCompany("AeroFlot");
                aeroFlot.AddPlane(new CompanyPassengerPlane[] {
            new CompanyPassengerPlane("Kutuzov", b777),
            new CompanyPassengerPlane("Bagration", b777),
            new CompanyPassengerPlane("Barklay de Tolly", b777),
            new CompanyPassengerPlane("Khachaturian", b737),
            new CompanyPassengerPlane("Kandinsky", b737),
            new CompanyPassengerPlane("Obraztsov", b737),
            new CompanyPassengerPlane("Tchaikovsky", a350),
            new CompanyPassengerPlane("Svetlanov", a330),
            new CompanyPassengerPlane("Visotsky", a330),
            new CompanyPassengerPlane("Brodsky", a330),
            new CompanyPassengerPlane("Mitchurin", a321),
            new CompanyPassengerPlane("Pirogov", a321),
            new CompanyPassengerPlane("Tsiolkovsky", a321),
            new CompanyPassengerPlane("SKYTEAM", a320),
            new CompanyPassengerPlane("Rostropovich", a320),
            new CompanyPassengerPlane("Kruzenshtern", a320),
            new CompanyPassengerPlane("Sysovsky", sj100),
            new CompanyPassengerPlane("Orlovets", sj100),
            new CompanyPassengerPlane("Benkunsky", sj100)
            });

                //aeroFlot.PrintPlanePark();
                Console.WriteLine();

                aeroFlot.SortPlanesByFlightRange();
                Console.WriteLine();

                double totalCarryingWeght = aeroFlot.CountTotalCarryingWeight();
                Console.WriteLine($"{aeroFlot.CompanyName} planes total carrying weight = {totalCarryingWeght} tons\n");

                int totalTotalCapacity = aeroFlot.CountTotalCapacity();
                Console.WriteLine($"{aeroFlot.CompanyName} planes total capacity = {totalTotalCapacity} people\n");


                aeroFlot.FindByFuelConsumptionRange(minFuelConsumption, maxFuelConsumption);
                Console.WriteLine("______________________________________________________");
            }   

            //BELAVIA
            {
                AviaCompany belavia = new AviaCompany("Belavia");

                belavia.AddPlane(new CompanyPassengerPlane[] {
            new CompanyPassengerPlane("B2 734", b737),
            new CompanyPassengerPlane("B2 9716", e175),
            new CompanyPassengerPlane("B2 868", b737),
            new CompanyPassengerPlane("B2 856", e195),
            new CompanyPassengerPlane("B2 870", e195),
            new CompanyPassengerPlane("B2 806", e195),
            new CompanyPassengerPlane("B2 880", e175)
            });

                //belavia.PrintPlanePark();
                Console.WriteLine();

                belavia.SortPlanesByFlightRange();
                Console.WriteLine();

                var totalCarryingWeght = belavia.CountTotalCarryingWeight();
                Console.WriteLine($"{belavia.CompanyName} planes total carrying weight = {totalCarryingWeght} tons\n");

                var totalTotalCapacity = belavia.CountTotalCapacity();
                Console.WriteLine($"{belavia.CompanyName} planes total capacity = {totalTotalCapacity} people\n");

                belavia.FindByFuelConsumptionRange(minFuelConsumption, maxFuelConsumption);
                Console.WriteLine("______________________________________________________");
            }


        }
        static double InputValue(string message, double min, double max)
        {
            Console.Write($"Enter {message} fuel consumption value (L/Km) [{min}...{max}]: ");
            double num;
            string input = Console.ReadLine();
            while (!(Double.TryParse(input, out num) && (num >= min) && (num <= max)))
            {
                Console.WriteLine("Incorrect input. Try again: ");
                Console.Write($"Enter {message} fuel consumption value (L/Km) [{min}...{max}]: ");
                input = Console.ReadLine();
            }
            return num;
            //if (Double.TryParse(input, out num) && (num >= min) && (num <= max))
            //{
            //    return num;
            //}
            //else
            //{
            //    Console.WriteLine("Incorrect input");
            //    return default;
            //}
        }
    }
}
