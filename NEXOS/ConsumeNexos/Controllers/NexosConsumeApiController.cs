using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ConsumeNexos.Models;
using Microsoft.Ajax.Utilities;

namespace ConsumeNexos.Controllers
{
    public class NexosConsumeApiController : Controller
    {
        // GET: NexosConsumeApi
        public ActionResult Index()
        {
            IEnumerable<AutorLibroView> AutorLibro = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49510/Api/Nexos/");
                var responseTask = client.GetAsync("Consulta");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<AutorLibroView>>();
                    readTask.Wait();

                    AutorLibro = readTask.Result;
                }
                else
                {
                    AutorLibro = Enumerable.Empty<AutorLibroView>();
                    ModelState.AddModelError(string.Empty, "Error en el servidor");
                }
            }
            return View(AutorLibro);
        }

        public ActionResult IndexAutores()
        {
            IEnumerable<AutoresViewModel> AutorLibro = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49510/Api/Nexos/");
                var responseTask = client.GetAsync("AutoresLista");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<AutoresViewModel>>();
                    readTask.Wait();

                    AutorLibro = readTask.Result;
                }
                else
                {
                    AutorLibro = Enumerable.Empty<AutoresViewModel>();
                    ModelState.AddModelError(string.Empty, "Error en el servidor");
                }
            }
            return View(AutorLibro);
        }

        public ActionResult createLibro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult createLibro(LibroViewModel libro)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49510/Api/Nexos/PostLibros");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<LibroViewModel>("libro", libro);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Error.");

            return View(libro);
        }

        public ActionResult createAutor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult createAutor(AutoresViewModel autores)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49510/Api/Nexos/PostAutores");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<AutoresViewModel>("Autores", autores);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Error.");

            return View(autores);
        }

    }
}