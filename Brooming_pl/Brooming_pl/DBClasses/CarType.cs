using System;
using System.Text;
using System.Collections.Generic;
using Brooming_pl.DBClasses;

namespace Brooming_pl.DBClasses
{
    
    public class CarType {
        public CarType() { }
        public virtual int TypeId { get; set; }
        public virtual string Type { get; set; }
        public virtual string Brand { get; set; }
        public virtual string Model { get; set; }
        public virtual string Color { get; set; }
        public virtual string Transmission { get; set; }
        public virtual string Fuel { get; set; }
        public virtual string FuelUsage { get; set; }
        public virtual string Power { get; set; }
        public virtual int? Capacity { get; set; }
        public virtual int? DoorQuantity { get; set; }
        public virtual int? SeatQuantity { get; set; }
    }
}
