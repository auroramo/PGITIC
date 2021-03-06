﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorkerRole1.ServiceReferenceBD {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceBD.IServicioBD")]
    public interface IServicioBD {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioBD/RecuperarLecturas", ReplyAction="http://tempuri.org/IServicioBD/RecuperarLecturasResponse")]
        System.Data.DataSet RecuperarLecturas();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioBD/RecuperarLecturas", ReplyAction="http://tempuri.org/IServicioBD/RecuperarLecturasResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> RecuperarLecturasAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioBD/InsertarLectura", ReplyAction="http://tempuri.org/IServicioBD/InsertarLecturaResponse")]
        int InsertarLectura(int estacion, decimal longitud, decimal latitud, int temperatura, int humedad, int presion, decimal velocidadViento, int nubes, System.DateTime fechaHora);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioBD/InsertarLectura", ReplyAction="http://tempuri.org/IServicioBD/InsertarLecturaResponse")]
        System.Threading.Tasks.Task<int> InsertarLecturaAsync(int estacion, decimal longitud, decimal latitud, int temperatura, int humedad, int presion, decimal velocidadViento, int nubes, System.DateTime fechaHora);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicioBDChannel : WorkerRole1.ServiceReferenceBD.IServicioBD, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicioBDClient : System.ServiceModel.ClientBase<WorkerRole1.ServiceReferenceBD.IServicioBD>, WorkerRole1.ServiceReferenceBD.IServicioBD {
        
        public ServicioBDClient() {
        }
        
        public ServicioBDClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicioBDClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioBDClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioBDClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet RecuperarLecturas() {
            return base.Channel.RecuperarLecturas();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> RecuperarLecturasAsync() {
            return base.Channel.RecuperarLecturasAsync();
        }
        
        public int InsertarLectura(int estacion, decimal longitud, decimal latitud, int temperatura, int humedad, int presion, decimal velocidadViento, int nubes, System.DateTime fechaHora) {
            return base.Channel.InsertarLectura(estacion, longitud, latitud, temperatura, humedad, presion, velocidadViento, nubes, fechaHora);
        }
        
        public System.Threading.Tasks.Task<int> InsertarLecturaAsync(int estacion, decimal longitud, decimal latitud, int temperatura, int humedad, int presion, decimal velocidadViento, int nubes, System.DateTime fechaHora) {
            return base.Channel.InsertarLecturaAsync(estacion, longitud, latitud, temperatura, humedad, presion, velocidadViento, nubes, fechaHora);
        }
    }
}
