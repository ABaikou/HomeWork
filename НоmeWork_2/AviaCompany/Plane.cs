using System;

namespace AviaCompany
{
    class Plane
    {
        public string Manufacturer { get; set; }
        public double Length { get; set; }
        public double Height { get; set; }
        public double WingSpan { get; set; }
        public double MaxTakeOffWeight { get; set; }
        public int MaxFlightRange { get; set; }
        public double MaxAltitude { get; set; }
        public int CruisingSpeed { get; set; }
        public int FuelCapacity { get; set; }
        public virtual void GetInfo()
        {
            Console.Write(
                $"Manufacturer: {Manufacturer} \n" +                
                $"Length: {Length} m \n" +
                $"Height: {Height} m \n" +
                $"Wing Span: {WingSpan} m \n" +
                $"Max take off weight: {MaxTakeOffWeight} tons \n" +
                $"Max flight range: {MaxFlightRange} km \n" +
                $"Max altitude: {MaxAltitude} km \n" +
                $"Cruising speed: {CruisingSpeed} km/h \n" +
                $"Fuel capacity: {FuelCapacity} L \n");
        }

    }
}
