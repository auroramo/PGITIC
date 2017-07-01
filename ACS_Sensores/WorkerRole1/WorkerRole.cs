using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Newtonsoft.Json;
using System.Net.Http;

namespace WorkerRole1
{
    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);

        ServiceReferenceBD.ServicioBDClient sr = new ServiceReferenceBD.ServicioBDClient();
        private static readonly HttpClient cliente = new HttpClient();
        Sensores obj;

        public override void Run()
        {
            Trace.TraceInformation("WorkerRole1 is running");

            try
            {
                this.RunAsync(this.cancellationTokenSource.Token).Wait();
            }
            finally
            {
                this.runCompleteEvent.Set();
            }
        }

        public override bool OnStart()
        {
            // Establecer el número máximo de conexiones simultáneas
            ServicePointManager.DefaultConnectionLimit = 12;

            // Para obtener información sobre cómo administrar los cambios de configuración
            // consulte el tema de MSDN en https://go.microsoft.com/fwlink/?LinkId=166357.

            bool result = base.OnStart();

            Trace.TraceInformation("WorkerRole1 has been started");

            return result;
        }

        public override void OnStop()
        {
            Trace.TraceInformation("WorkerRole1 is stopping");

            this.cancellationTokenSource.Cancel();
            this.runCompleteEvent.WaitOne();

            base.OnStop();

            Trace.TraceInformation("WorkerRole1 has stopped");
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Reemplazar lo siguiente por su propia lógica.
            while (!cancellationToken.IsCancellationRequested)
            {
                //Trace.TraceInformation("Working");
                try
                {
                    var sensor = await RecuperarInfoSensores();

                    if (sensor != null)
                        sr.InsertarLectura(2522258, sensor.coord.lon, sensor.coord.lat, sensor.main.temp, sensor.main.humidty, sensor.main.pressure, sensor.wind.speed, sensor.clouds.all, DateTime.UtcNow);
                }
                catch (Exception ex) { }

                    await Task.Delay(1080000);
            }
        }

        private async Task<Sensores> RecuperarInfoSensores()
        {
            var values = new Dictionary<string, string>
            {
                { "id", "2522258" },
                { "mode", "json" },
                { "units", "metric" },
                { "lang", "es" },
                {"APPID", "dd5763d9a979b0eaad2fb38b85ed88e1" }
            };

            //var content = new FormUrlEncodedContent(values);
            var contenido = new FormUrlEncodedContent(new Dictionary<string, string>());
            try
            {
                var response = await cliente.PostAsync("http://api.openweathermap.org/data/2.5/weather?id=2522258&mode=json&units=metric&lang=es&APPID=dd5763d9a979b0eaad2fb38b85ed88e1", contenido);

                var responseString = await response.Content.ReadAsStringAsync();

                obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Sensores>(responseString);

                return obj;
            }
            catch (Exception ex) { return null; }
        }




    }
}
