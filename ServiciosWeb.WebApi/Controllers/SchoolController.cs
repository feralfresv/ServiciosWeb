using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServiciosWeb.Datos.Modelo;

namespace ServiciosWeb.WebApi.Controllers
{
    public class SchoolController : ApiController
    {

        SchoolEntities BD = new SchoolEntities();

        [HttpGet]
        public IEnumerable<School_Table> Get()
        {
            var listado = BD.School_Table.ToList();
            return listado;
        }

        [HttpGet]
        public School_Table Get(int id)
        {
            var alimento = BD.School_Table.FirstOrDefault(x => x.Id == id);
            return alimento;
        }
    }
}
