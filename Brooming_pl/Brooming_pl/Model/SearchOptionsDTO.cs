using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Brooming_pl.Model
{
    [DataContract]
    public class SearchOptionsDTO
    {
        [DataMember]
        public string CarType { get; set; }
        [DataMember]
        public string CarBrand { get; set; }
        [DataMember]
        public string CarModel { get; set; }
        [DataMember]
        public string CarColor { get; set; }
        [DataMember]
        public string CarTransmission { get; set; }
        [DataMember]
        public string CarFuel { get; set; }
        [DataMember]
        public string CarPower { get; set; }
        [DataMember]
        public int? CarCapacity { get; set; }
        [DataMember]
        public int? CarDoorQuantity { get; set; }
        [DataMember]
        public int? CarSeatQuantity { get; set; }
        [DataMember]
        public string TakeLocation { get; set; }
        [DataMember]
        public string ReturnLocation { get; set; }
        [DataMember]
        public DateTime StartTime { get; set; }
        [DataMember]
        public DateTime EndTime { get; set; }
        [DataMember]
        public float? DailyPrice { get; set; }
        [DataMember]
        public int Page { get; set; }
    }
}
