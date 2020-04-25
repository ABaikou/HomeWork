using System;
using System.Collections.Generic;
using System.Linq;

namespace AviaCompany
{
    class AviaCompany
    {
        public string CompanyName { get; private set; }
        public List<CompanyPassengerPlane> PlanePark { get; private set; }
        public AviaCompany(string name) 
        {
            CompanyName = name;
            PlanePark = new List<CompanyPassengerPlane>();
        }        
        public void AddPlane(CompanyPassengerPlane plane) 
        {
            PlanePark.Add(plane);
        }
        public void AddPlane(CompanyPassengerPlane[] plane)
        {
            PlanePark.AddRange(plane);
        }
        public void PrintPlanePark()
        {
            int i = 1;
            Console.WriteLine($"{CompanyName} company has the following planes:");
            foreach (CompanyPassengerPlane item in PlanePark)
            {
                Console.WriteLine($"Plane #{i}: '{item.AircraftName}' - {item.Manufacturer} {item.Model}");
                i++;
            }
        }
        public void SortPlanesByFlightRange() 
        {
            var selectedPlanes = PlanePark
                .OrderBy(p => p.MaxFlightRange)
                .ToList();
            if (selectedPlanes.Any())
            {
                var groupPlanes = selectedPlanes
                .GroupBy(p => p.Model)
                .Select(grouping => new
                {
                    ModelName = grouping.Key,
                    FlightRange = grouping.Select(pl => pl.MaxFlightRange).FirstOrDefault(),
                    Count = grouping.Count(),
                    Values = grouping.Select(pl => pl.AircraftName)
                })
                .ToList();

                Console.WriteLine($"Planes {CompanyName} sorted by flight range:");
                foreach (var group in groupPlanes)
                {
                    Console.Write($"Model: {group.ModelName}, Flight range: {group.FlightRange},  Quantity: { group.Count}, Aircraft name: ");
                    foreach (var value in group.Values)
                    {
                        Console.Write($"'{value}' ");
                    }
                    Console.WriteLine();
                }
            }            
        }
        public double CountTotalCarryingWeight()
        {
            double totalCarryingWeight = PlanePark.Sum(w => w.MaxTakeOffWeight);
            return totalCarryingWeight;
        }
        public int CountTotalCapacity()
        {
            int totalTotalCapacity = PlanePark.Sum(p => p.PassengerCapacity);
            return totalTotalCapacity;
        }
        public void FindByFuelConsumptionRange(double minValue, double maxValue)
        {
            var selectedPlanes = PlanePark
                .Where(p => (p.MaxFlightRange != 0) && (p.FuelCapacity / p.MaxFlightRange >= minValue) && (p.FuelCapacity / p.MaxFlightRange <= maxValue))
                .ToList();
            if (selectedPlanes.Any())
            {
                var groupPlanes = selectedPlanes
                .GroupBy(p => p.Model)
                .Select(grouping => new
                {
                    ModelName = grouping.Key,
                    Count = grouping.Count(),
                    Values = grouping.Select(pl => pl.AircraftName)
                })
                .ToList();

                Console.WriteLine($"{CompanyName} has the following planes within the specified range fuel consumption:");
                foreach (var group in groupPlanes)
                {
                    Console.Write($"Model: {group.ModelName}, Quantity: { group.Count}, Aircraft name: ");
                    foreach (var value in group.Values)
                    {
                        Console.Write($"'{value}' ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine($"{CompanyName} hasn't planes within the specified range fuel consumption");
            }
        }
    }
}
