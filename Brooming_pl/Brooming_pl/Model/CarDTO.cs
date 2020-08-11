using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brooming_pl.Model
{
    public class CarDTO
    {
        public CarTypeDTO CarType { get; set; }
        public string RegistrationNumber { get; set; }
        public int YearOfProduction { get; set; }
        public string Description { get; set; }
        public string LinkToPhoto { get; set; }
    }

    public class CarTypeDTO
    {
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Transmission { get; set; }
        public string Fuel { get; set; }
        public string FuelUsage { get; set; }
        public string Power { get; set; }
        public int Capacity { get; set; }
        public int DoorQuantity { get; set; }
        public int SeatQuantity { get; set; }
    }
}
