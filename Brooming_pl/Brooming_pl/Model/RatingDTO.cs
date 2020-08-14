using Brooming_pl.DBClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Brooming_pl.Model
{
    [DataContract]
    public class RatingDTO
    {
        [DataMember]
        public int Rating { get; set; }
        [DataMember]
        public string Comment { get; set; }
    }
}
