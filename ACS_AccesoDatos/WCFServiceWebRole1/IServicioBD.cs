using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioBD
    {

        [OperationContract]
        DataSet RecuperarLecturas();
        [OperationContract]
        int InsertarLectura(int estacion, decimal longitud, decimal latitud, int temperatura, int humedad, int presion, decimal velocidadViento, int nubes, DateTime fechaHora);
    }


}
