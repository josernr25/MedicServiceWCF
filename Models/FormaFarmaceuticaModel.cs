using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MedicServiceWCF.Models
{
    [DataContract]
    public class FormaFarmaceuticaModel
    {
        [DataMember(Order = 0)]
        public int IdFormaFarmaceutica { get; set; }

        [DataMember(Order = 1)]
        public string Nombre { get; set; }

        [DataMember(Order = 2)]
        public int? BHabilitado { get; set; }
    }
}