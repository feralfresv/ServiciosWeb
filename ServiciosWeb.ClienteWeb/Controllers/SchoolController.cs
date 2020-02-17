using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ServiciosWeb.Dominio;
using System.Net.Http.Formatting;

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
                //BaseAddress = new Uri("http://localhost/WebApi/")
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

        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(Escuela escuela)
        {
            HttpClient clienteHTTP = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:60018/")
                //BaseAddress = new Uri("http://localhost/WebApi/")
            };

            var request = clienteHTTP.PostAsync("api/School", escuela, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var correcto = JsonConvert.DeserializeObject<bool>(resultString);

                if (correcto)
                {
                    return RedirectToAction("Index");
                }
                return View(escuela);
            }

            return View(escuela);
        }

        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            HttpClient clienteHTTP = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:60018/")
                //BaseAddress = new Uri("http://localhost/WebApi/")
            };

            var request = clienteHTTP.GetAsync("api/School?id=" +  id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var informacion = JsonConvert.DeserializeObject<Escuela>(resultString);
                return View(informacion);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Actualizar(Escuela escuela)
        {
            HttpClient clienteHTTP = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:60018/")
                //BaseAddress = new Uri("http://localhost/WebApi/")
            };

            var request = clienteHTTP.PutAsync("api/School", escuela, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var correcto = JsonConvert.DeserializeObject<bool>(resultString);

                if (correcto)
                {
                    return RedirectToAction("Index");
                }
                return View(escuela);
            }

            return View(escuela);
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            HttpClient clienteHTTP = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:60018/")
                //BaseAddress = new Uri("http://localhost/WebApi/")
            };

            var request = clienteHTTP.DeleteAsync("api/School?id=" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var correcto = JsonConvert.DeserializeObject<bool>(resultString);

                if (correcto)
                {
                    return RedirectToAction("Index");
                }          
            }
            return View();
        }

        [HttpGet]
        public ActionResult Detalle(int id)
        {
            HttpClient clienteHTTP = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:60018/")
                //BaseAddress = new Uri("http://localhost/WebApi/")
            };

            var request = clienteHTTP.GetAsync("api/School?id=" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var informacion = JsonConvert.DeserializeObject<Escuela>(resultString);
                return View(informacion);
            }
            return View();
        }

    }
}