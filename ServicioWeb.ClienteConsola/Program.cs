using ServicioWeb.ClienteConsola.ServiceEscuelaASMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioWeb.ClienteConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            //Invocar Servicio ASMX 
            Service1Client oCliente = new Service1Client();
            var escuela = oCliente.ObtenerEscuela();

            ServiceEscuelaWCF.Service1Client oCliente2 = new ServiceEscuelaWCF.Service1Client();
            var escuela2 = oCliente2.ObtenerEscuela();

            foreach (var item in oCliente.ObtenerEscuela())
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Year);
                Console.WriteLine();
            }
        }
    }
}
