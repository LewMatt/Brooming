using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Brooming_pl.Model
{
    [DataContract]
    public class OfferDTO
    {
        [DataMember]
        public virtual string OfferDetail { get; set; }
        [DataMember]
        public virtual float DailyPrice { get; set; }
        [DataMember]
        public virtual string AdditionalInfo { get; set; }
    }
}
