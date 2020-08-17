using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Brooming_pl.Model
{
    [DataContract]
    public class CarIdDTO
    {
        [DataMember]
        public int CarId { get; set; }
    }
}
