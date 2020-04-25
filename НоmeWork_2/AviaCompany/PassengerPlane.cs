using System;

namespace AviaCompany
{
    class PassengerPlane : Plane
    {
        public string Model { get; set; }
        public string AircraftType { get; set; }
        public int PassengerCapacity { get; set; }
        public string CabinConfig { get; set; }
        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine(
                $"Model: {Model} \n" +
                $"Aircraft Type: {AircraftType} \n" +
                $"Passenger Capacity: {PassengerCapacity} \n" +
                $"Cabin Configuration: {CabinConfig} \n");
        }
    }
}
