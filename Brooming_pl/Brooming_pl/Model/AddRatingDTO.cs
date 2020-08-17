using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Brooming_pl.Model
{
    [DataContract]
    public class AddRatingDTO
    {
        [DataMember]
        public int Rating { get; set; }
        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public int CompanyId { get; set; }

    }
}
