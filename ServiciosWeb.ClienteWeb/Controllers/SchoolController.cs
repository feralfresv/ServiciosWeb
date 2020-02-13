using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ServiciosWeb.Dominio;

namespace ServiciosWeb.ClienteWeb.Controllers
{
    public class SchoolController : Controller
    {
        // GET: School
        public ActionResult Index()
        {
            HttpClient clienteHTTP = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:60018/")
            };

            var request = clienteHTTP.GetAsync("api/School").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Dominio.Escuela>>(resultString);
                return View(listado);
            }
            return View(new List<Dominio.Escuela>());
        }
    }
}