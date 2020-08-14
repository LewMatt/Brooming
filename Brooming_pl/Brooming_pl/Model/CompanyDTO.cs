using Brooming_pl.DBClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Brooming_pl.Model
{
    [DataContract]
    public class CompanyDTO
    {
        [DataMember]
        public string CompanyName { set; get; }
        [DataMember]
        public string Adress { set; get; }
        [DataMember]
        public string TaxNumber { set; get; }
        [DataMember]
        public int UserId { set; get; }
    }
}
