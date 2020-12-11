using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Accounting
{
    [DataContract]

    public class Order
    {
        [DataMember]
        public string Сustomer_Name { get; set; }
        [DataMember]
        public string Task { get; set; }
        [DataMember]
        public bool IsFix { get; set; }
        [DataMember]
        public double Total_Price { get; set; }
        [DataMember]
        public double Work { get; set; }
        [DataMember]
        public double My_Work { get; set; }
        [DataMember]
        public double Girls_Work { get; set; }
        [DataMember]
        public string Cloths { get; set; }
        [DataMember]
        public double Cloths_Price { get; set; }
        [DataMember]
        public string Implements { get; set; }
        [DataMember]
        public double Implements_Price { get; set; }
        [DataMember]
        public double Equipment_Coating { get; set; }
    }
}
