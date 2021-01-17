using MedicServiceWCF.DataAccess;
using MedicServiceWCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MedicServiceWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        IEnumerable<MedicamentoModel> GetMedicamentos();

        MedicamentoModel GetMedicamento(int id);

        bool AddMedicamento(MedicamentoModel medicamento);

        bool UpdateMedicamento(MedicamentoModel medicamento);

        bool DeleteMedicamento(int id);

        IEnumerable<FormaFarmaceuticaModel> GetFormaFarmaceuticas();

        // TODO: agregue aquí sus operaciones de servicio
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    
}
