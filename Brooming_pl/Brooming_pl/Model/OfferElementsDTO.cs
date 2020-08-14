using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Brooming_pl.Model
{
    [DataContract]
    public class OfferElementsDTO
    {
        [DataMember]
        public int CarId { get; set; }
        [DataMember]
        public string TakeLocation { get; set; }
        [DataMember]
        public string ReturnLocation { get; set; }
        [DataMember]
        public DateTime? StartTime { get; set; }
        [DataMember]
        public DateTime? EndTime { get; set; }
        [DataMember]
        public string AdditionalInfo { get; set; }
        [DataMember]
        public float? DailyPrice { get; set; }
    }
}
