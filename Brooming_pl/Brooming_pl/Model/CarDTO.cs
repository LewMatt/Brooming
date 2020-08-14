using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Brooming_pl.Model
{
    [DataContract]
    public class CarDTO
    {
        [DataMember]
        public string RegistrationNumber { get; set; }
        [DataMember]
        public int YearOfProduction { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string LinkToPhoto { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Brand { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public string Transmission { get; set; }
        [DataMember]
        public string Fuel { get; set; }
        [DataMember]
        public string FuelUsage { get; set; }
        [DataMember]
        public string Power { get; set; }
        [DataMember]
        public int Capacity { get; set; }
        [DataMember]
        public int DoorQuantity { get; set; }
        [DataMember]
        public int SeatQuantity { get; set; }
    }
}
