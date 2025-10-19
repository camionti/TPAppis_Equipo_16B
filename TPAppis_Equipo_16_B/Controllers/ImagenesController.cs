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
    public class ImagenesController : ApiController
    {
        // GET api/imagen/Lista
        public  IEnumerable<Imagen> Get(int id = 0)
        {
            ConexionImagen imagenes = new ConexionImagen();
            return imagenes.Listar(id);
        }


        // POST api/imagen
        public HttpResponseMessage Post([FromBody] ImagenDTO imagen)
        {
            try
            {
                if (imagen.IdArticulo <= 0)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "El ID del articulo no puede ser Null");

                if (string.IsNullOrEmpty(imagen.UrlImagen))
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "La direccion de la Imagen es obligatoria.");


                var conexion = new ConexionArticulo();

                Articulo ArticuloEncontrado = null;

                ArticuloEncontrado = conexion.Listar().Find(x => x.Id == imagen.IdArticulo);

                if (ArticuloEncontrado == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "El articulo no existe");

                var nuevo = new Imagen
                {
                    UrlImagen = imagen.UrlImagen,
                    IdArticulo = imagen.IdArticulo,
                    IdImagen = imagen.IdImagen
                };

                new ConexionImagen().Agregar(nuevo); 
                return Request.CreateResponse(HttpStatusCode.Created, "Imagen creada correctamente.");
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error inesperado");

            }
        }

        // PUT api/imagen/{id articulo}
        public HttpResponseMessage Put(int id, [FromBody] ImagenDTO Imagen)
        {
            try
            {
                if (Imagen == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "La imagen no puede ser nula.");

                if (string.IsNullOrEmpty(Imagen.UrlImagen))
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "El Url de la imagen es obligatorio.");

                var idUrl = int.Parse(Request.GetRouteData().Values["id"].ToString());
                var conexion = new ConexionImagen();
                Imagen ImagenEncontrada = null;

                ImagenEncontrada = conexion.Listar(id).Find(x => x.IdImagen == idUrl);

                if (ImagenEncontrada == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "No existe una Imagen con ese ID");

                Imagen modificada = new Imagen 
                {
                    UrlImagen = Imagen.UrlImagen
                };

                conexion.Modificar(modificada);

                return Request.CreateResponse(HttpStatusCode.OK, "Imagen modificada correctamente.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error inesperado");
            }
        }

        // DELETE api/imagen/{id imagen}
        public HttpResponseMessage Delete()
        {
            try
            {
                var idUrlObject = Request.GetRouteData().Values["id"];
                if (idUrlObject == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "El ID de ategoria no puede ser nulo.");

                var idUrl = int.Parse(idUrlObject?.ToString());
                var conexion = new ConexionImagen();
                Imagen ImagenEncontrada = null;

                ImagenEncontrada = conexion.Listar(idUrl).Find(x => x.IdImagen == idUrl);

                if (ImagenEncontrada == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "No existe una imagen con ese ID");

                conexion.Eliminar(idUrl);

                return Request.CreateResponse(HttpStatusCode.OK, "Imagen borrada correctamente.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error inesperado");
            }
        }
    }
}