using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MedicServiceWCF.Models
{
    [DataContract]
    public class MedicamentoModel
    {
        [DataMember(Order = 0)]
        public int IdMedicamento { get; set; }

        [DataMember(Order = 1)]
        public string Nombre { get; set; }

        [DataMember(Order = 2)]
        public string Concentracion { get; set; }

        [DataMember(Order = 3)]
        public int? IdFormaFarmaceutica { get; set; }

        [DataMember(Order = 4)]
        public string NombreFormaFarmaceutica { get; set; }

        [DataMember(Order = 5)]
        public decimal? Precio { get; set; }

        [DataMember(Order = 6)]
        public int? Stock { get; set; }

        [DataMember(Order = 7)]
        public string Presentacion { get; set; }

        [DataMember(Order = 8)]
        public int? BHabilitado { get; set; }
    }
}