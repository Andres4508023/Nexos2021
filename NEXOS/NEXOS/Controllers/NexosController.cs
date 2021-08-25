using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NEXOS.Models;

namespace NEXOS.Controllers
{
    public class NexosController : ApiController
    {
        NexosEntities db = new NexosEntities();

        // [Route("api/student/names")]
        [Route("Api/Nexos/Consulta")]
        public IQueryable<AutorLibroView> GetConsulta()
        {
            db.Configuration.ProxyCreationEnabled = false;

            return (from L in db.Libro
                          join A in db.Autores
                          on L.IdAutor equals A.IdAutor

                          select new AutorLibroView
                          {
                              IdLibro = L.IdLibro,
                              NombresAutor = A.Nombres,
                              Titulo = L.Titulo,
                              Genero = L.Genero,
                              Año = L.Año,
                              NumeroPagina = L.NumeroPagina
                          });
        }

        [Route("Api/Nexos/AutoresLista")]
        public IQueryable<Autores>GetAutores()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Autores;
        }

        [Route("Api/Nexos/PostLibros")]
        public IHttpActionResult PostLibros(LibroViewModel libro)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos Invalidos");

            db.Libro.Add(new Libro()
            {
                IdLibro = libro.IdLibro,
                Titulo = libro.Titulo,
                Año = libro.Año,
                Genero = libro.Genero,
                NumeroPagina = libro.NumeroPagina,
                IdAutor = libro.IdAutor
            });
            db.SaveChanges();

            return Ok();
        }

        [Route("Api/Nexos/PostAutores")]
        public IHttpActionResult PostAutores (AutoresViewModel autor)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos invalidos");

            db.Autores.Add(new Autores()
            {
                IdAutor = autor.IdAutor,
                Nombres = autor.Nombres,
                FechaNacimiento = autor.FechaNacimiento,
                CiudadNacimiento = autor.CiudadNacimiento,
                Correo = autor.Correo   
            });
            db.SaveChanges();

            return Ok();
        }

    }
}
