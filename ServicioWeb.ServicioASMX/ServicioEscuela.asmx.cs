using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ServiciosWeb.Datos.Modelo;

namespace ServicioWeb.ServicioASMX
{
    /// <summary>
    /// Descripción breve de ServicioEscuela
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioEscuela : System.Web.Services.WebService
    {
        SchoolEntities BD = new SchoolEntities();

        [WebMethod]
        public List<School_Table> ObtenerEscuela()
        {
            var listado = BD.School_Table.ToList();
                return listado;
        }
    }
}
