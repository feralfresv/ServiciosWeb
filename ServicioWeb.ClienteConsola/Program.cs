using ServicioWeb.ClienteConsola.ServiceEscuelaASMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ServicioWeb.ClienteConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Invocar Servicio ASMX 
            //Service1Client oCliente = new Service1Client();
            //var escuela = oCliente.ObtenerEscuela();

            ////Invocar Servicio WCF
            //ServiceEscuelaWCF.Service1Client oCliente2 = new ServiceEscuelaWCF.Service1Client();
            //var escuela2 = oCliente2.ObtenerEscuela();x|
            //foreach (var item in oCliente.ObtenerEscuela())
            //{
            //    Console.WriteLine(item.Id);
            //    Console.WriteLine(item.Name);
            //    Console.WriteLine(item.Year);
            //    Console.WriteLine();
            //}
            //Console.ReadKey();

            //Invocar Seervicio REST
            HttpClient clienteHTTP = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:60018/")
            };

            var request = clienteHTTP.GetAsync("api/School").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<School_Table>>(resultString);

                foreach (var item in listado)
                {
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.Year);
                }
                Console.ReadLine();

            }

        }
    }
}
