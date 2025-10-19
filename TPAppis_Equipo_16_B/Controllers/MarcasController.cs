using Conexion;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using TPAppis_Equipo_16_B.Models;

namespace TPAppis_Equipo_16_B.Controllers
{
    public class MarcasController : ApiController
    {
        // GET api/marca/Lista
        public IEnumerable<Marca> Get()
        {
            ConexionMarca marcas = new ConexionMarca();
            return marcas.Listar();

        }

        // GET api/marca/x
        public Marca Get(int id)
        {
            var marcas = new ConexionMarca().Listar();
            var marca = new Marca();

            marca = marcas.Find(x => x.IDMarca == id);

            return marca;
        }

        // POST api/marca
        public HttpResponseMessage Post(int id, [FromBody] MarcaDTO marca)
        {
            try
            {
                if (marca == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "La marca no puede ser nula.");

                if (string.IsNullOrEmpty(marca.Descripcion))
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "La descripcion de la marca es obligatoria.");

                var conexion = new ConexionMarca();

                Marca marcaEncontrada = null;

                marcaEncontrada = conexion.Listar().Find(x => x.IDMarca == marca?.Id);

                if (marcaEncontrada == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "La marca no existe.");

                var nuevo = new Marca
                {
                    Descripcion = marca.Descripcion
                };

                conexion.Agregar(nuevo);

                return Request.CreateResponse(HttpStatusCode.OK, "Marca creada correctamente.");
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error inesperado");

            }
        }

        // PUT api/marca/x
        public HttpResponseMessage Put(int id, [FromBody] MarcaDTO marca)
        {
            try
            {
                if (marca == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "La marca no puede ser nula.");

                if (string.IsNullOrEmpty(marca.Descripcion))
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "La descripción del marca es obligatoria.");

                var idUrl = int.Parse(Request.GetRouteData().Values["id"].ToString());
                var conexion = new ConexionMarca();
                Marca marcaEncontrada = null;

                marcaEncontrada = conexion.Listar().Find(x => x.IDMarca == idUrl);

                if (marcaEncontrada == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "No existe una marca con ese ID");

                Marca modificada = new Marca { Descripcion = marca.Descripcion };

                return Request.CreateResponse(HttpStatusCode.OK, "Marca modificada correctamente.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error inesperado");
            }
        }

        // DELETE api/marca/x
        public HttpResponseMessage Delete(int id)
        {
            try
            { 
                if (id < 1)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "El ID de ategoria no puede ser nulo.");

                var conexion = new ConexionMarca();
                Marca marcaEncontrada = null;

                marcaEncontrada = conexion.Listar().Find(x => x.IDMarca == id);

                if (marcaEncontrada == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "No existe una marca con ese ID");

                conexion.Eliminar(id);

                return Request.CreateResponse(HttpStatusCode.OK, "Marca borrada correctamente.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error inesperado");
            }
        }
    }
}