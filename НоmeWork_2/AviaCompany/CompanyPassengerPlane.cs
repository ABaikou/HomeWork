using System;

namespace AviaCompany
{
    class CompanyPassengerPlane : PassengerPlane
    {
        public string AircraftName { get; private set; }
        public CompanyPassengerPlane(string aircraftName, PassengerPlane planeModel)
        {
            AircraftName = aircraftName;
            Manufacturer = planeModel.Manufacturer;
            Model = planeModel.Model;
            Length = planeModel.Length;
            Height = planeModel.Height;
            WingSpan = planeModel.WingSpan;
            MaxTakeOffWeight = planeModel.MaxTakeOffWeight;
            MaxFlightRange = planeModel.MaxFlightRange;
            MaxAltitude = planeModel.MaxAltitude;
            CruisingSpeed = planeModel.CruisingSpeed;
            FuelCapacity = planeModel.FuelCapacity;
            AircraftType = planeModel.AircraftType;
            PassengerCapacity = planeModel.PassengerCapacity;
            CabinConfig = planeModel.CabinConfig;
        }
        public override void GetInfo() 
        {
            Console.WriteLine($"Aircraft name: {AircraftName}");
            base.GetInfo();
        }
    }
}
