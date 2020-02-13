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

        [HttpPost]
        public bool Post (School_Table escuela)
        {
            BD.School_Table.Add(escuela);
            return BD.SaveChanges() > 0;
        }

        [HttpPut]
        public bool Put(School_Table escuela)
        {
            var escuelaActualizar = BD.School_Table.FirstOrDefault(x => x.Id == escuela.Id);
            escuelaActualizar.Id = escuela.Id;
            escuelaActualizar.Name = escuela.Name;
            escuelaActualizar.Year = escuela.Year;

            return BD.SaveChanges() > 0;
        }

        [HttpDelete]
        public bool Delete (int id)
        {
            var escuelaEliminar = BD.School_Table.FirstOrDefault(x => x.Id == id);
            BD.School_Table.Remove(escuelaEliminar);
            return BD.SaveChanges() > 0;
        }
    }
}
