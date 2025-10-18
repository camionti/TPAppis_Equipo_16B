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
    public class ImagenController : ApiController
    {
        // GET api/imagen/Lista
        public  IEnumerable<Imagen> Get(int id = 0)
        {
            ConexionImagen imagenes = new ConexionImagen();
            return imagenes.Listar(id);

        }


        // POST api/Imagen
        public HttpResponseMessage Post(int id, [FromBody] ImagenDTO Imagen)
        {
            try
            {
                if (Imagen == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "La Imagen no puede ser nula.");

                if (string.IsNullOrEmpty(Imagen.))
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "La descripcion de la Imagen es obligatoria.");

                var conexion = new ConexionImagen();

                Imagen ImagenEncontrada = null;

                ImagenEncontrada = conexion.Listar(id).Find(x => x.IDImagen == Imagen?.Id);

                if (ImagenEncontrada == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "La Imagen no existe.");

                var nuevo = new Imagen
                {
                    Descripcion = Imagen.Descripcion
                };

                conexion.Agregar(nuevo);

                return Request.CreateResponse(HttpStatusCode.OK, "Imagen creada correctamente.");
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error de conexion");

            }
        }

        //// PUT api/Imagen/x
        //public HttpResponseMessage Put(int id, [FromBody] ImagenDTO Imagen)
        //{
        //    try
        //    {
        //        if (Imagen == null)
        //            return Request.CreateResponse(HttpStatusCode.BadRequest, "La Imagen no puede ser nula.");

        //        if (string.IsNullOrEmpty(Imagen.Descripcion))
        //            return Request.CreateResponse(HttpStatusCode.BadRequest, "La descripción del Imagen es obligatoria.");

        //        var idUrl = int.Parse(Request.GetRouteData().Values["id"].ToString());
        //        var conexion = new ConexionImagen();
        //        Imagen ImagenEncontrada = null;

        //        ImagenEncontrada = conexion.Listar().Find(x => x.IDImagen == idUrl);

        //        if (ImagenEncontrada == null)
        //            return Request.CreateResponse(HttpStatusCode.BadRequest, "No existe una Imagen con ese ID");

        //        Imagen modificada = new Imagen { Descripcion = Imagen.Descripcion };

        //        return Request.CreateResponse(HttpStatusCode.OK, "Imagen modificada correctamente.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest, "Error de conexion");
        //    }
        //}

        //// DELETE api/Imagen/x
        //public HttpResponseMessage Delete()
        //{
        //    try
        //    {
        //        var idUrlObject = Request.GetRouteData().Values["id"];
        //        if (idUrlObject == null)
        //            return Request.CreateResponse(HttpStatusCode.BadRequest, "El ID de ategoria no puede ser nulo.");

        //        var idUrl = int.Parse(idUrlObject?.ToString());
        //        var conexion = new ConexionImagen();
        //        Imagen ImagenEncontrada = null;

        //        ImagenEncontrada = conexion.Listar().Find(x => x.IDImagen == idUrl);

        //        if (ImagenEncontrada == null)
        //            return Request.CreateResponse(HttpStatusCode.BadRequest, "No existe una categoría con ese ID");

        //        conexion.Eliminar(idUrl);

        //        return Request.CreateResponse(HttpStatusCode.OK, "Imagen borrada correctamente.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest, "Error de conexion");
        //    }
        //}
    }
}