using Conexion;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TPAppis_Equipo_16_B.Models;

namespace TPAppis_Equipo_16_B.Controllers
{
    public class CategoriaController : ApiController
    {
        // GET api/categoria/Lista

        public IEnumerable<Categoria> Get()
        {
            ConexionCategorias categorias = new ConexionCategorias();
            return categorias.Listar();

        }

        // GET api/categoria/x
        public Categoria Get(int id)
        {
            var categorias = new ConexionCategorias().Listar();
            var categoria = new Categoria();

            categoria = categorias.Find(x => x.Id == id);
            
            return categoria;
        }

        // POST api/categoria
        public HttpResponseMessage Post(int id, [FromBody]CategoriaDTO categoria)
        {
            try
            {
                if (categoria == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "La categoria no puede ser nula.");

                if (string.IsNullOrEmpty(categoria.Descripcion))
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "La descripcion de la categoria es obligatoria.");

                var conexion = new ConexionCategorias();

                Categoria categoriaEncontrada = null;

                categoriaEncontrada = conexion.Listar().Find(x => x.Id == categoria?.Id);

                if(categoriaEncontrada == null) 
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "La categoria no existe.");

                var nuevo = new Categoria
                {
                    Descripcion = categoria.Descripcion
                };

                conexion.agregar(nuevo);

                return Request.CreateResponse(HttpStatusCode.OK, "Categoria creada correctamente.");
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error de conexion");

            }
        }

        // PUT api/categoria/x
        public HttpResponseMessage Put(int id, [FromBody] CategoriaDTO categoria)
        {
            try
            {
                if (categoria == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "La categoría no puede ser nula.");

                if (string.IsNullOrEmpty(categoria.Descripcion))
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "La descripción del categoría es obligatoria.");

                var idUrl = int.Parse(Request.GetRouteData().Values["id"].ToString());
                var conexion = new ConexionCategorias();
                Categoria categoriaEncontrada = null;

                categoriaEncontrada = conexion.Listar().Find(x => x.Id ==  idUrl );

                if (categoriaEncontrada == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "No existe una categoría con ese ID");

                Categoria modificada = new Categoria { Descripcion = categoria.Descripcion };

                return Request.CreateResponse(HttpStatusCode.OK, "Categoria modificada correctamente.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error de conexion");
            }
        }

        // DELETE api/categoria/x
        public HttpResponseMessage Delete()
        {
            try
            {
                var idUrlObject = Request.GetRouteData().Values["id"];
                if (idUrlObject == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "El ID de ategoria no puede ser nulo.");

                var idUrl = int.Parse(idUrlObject?.ToString());
                var conexion = new ConexionCategorias();
                Categoria categoriaEncontrada = null;

                categoriaEncontrada = conexion.Listar().Find(x => x.Id == idUrl);

                if (categoriaEncontrada == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "No existe una categoría con ese ID");

                conexion.eliminar(idUrl);

                return Request.CreateResponse(HttpStatusCode.OK, "Categoria borrada correctamente.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error de conexion");
            }
        }
    }
}