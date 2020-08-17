using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Brooming_pl.Model
{
    [DataContract]
    public class GetUserDTO
    {
        [DataMember]
        public int UserId { get; set; }
    }
}
