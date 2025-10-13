using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using dominio;
using Conexion;
using TPAppis_Equipo_16_B.Models;
namespace TPAppis_Equipo_16_B.Controllers
{
    public class ArticuloController : ApiController
    {
        // GET: api/Articulo //LISTA
        public IEnumerable<Articulo> Get()
        {
            ConexionArticulo articulo = new ConexionArticulo();
            return articulo.Listar(); 
        }

        // GET: api/Articulo/5 //BUSCA
        public Articulo Get(int id)
        {
            ConexionArticulo articulo = new ConexionArticulo();
            List<Articulo> lista = articulo.Listar();

            return lista.Find(x=> x.Id == id);
        }

        // POST: api/Articulo //AGREGA
        public IHttpActionResult Post([FromBody]ArticuloDTO articulo)
        {
            try
            {
                // Validaciones 
                if (articulo == null)
                    return BadRequest("El artículo no puede ser nulo.");

                if (string.IsNullOrEmpty(articulo.Nombre))
                    return BadRequest("El nombre del artículo es obligatorio.");

                if (articulo.Precio <= 0)
                    return BadRequest("El precio debe ser mayor que cero.");

                if (articulo.Idcategoria <= 0 || articulo.Idmarca <= 0)
                    return BadRequest("Debe seleccionar una marca y una categoría válidas.");

                
                ConexionArticulo conexion = new ConexionArticulo();

                Articulo nuevo = new Articulo
                {
                    Codigo = articulo.Codigo,
                    Nombre = articulo.Nombre,
                    Descripcion = articulo.Descripcion,
                    Idmarca = articulo.Idmarca,
                    Idcategoria = articulo.Idcategoria,
                    Idimagen = articulo.Idimagen,
                    Precio = articulo.Precio
                };

                conexion.agregar(nuevo);

               
                return Ok("Artículo agregado correctamente.");
            }
            catch (Exception ex)
            {
               
                return InternalServerError(ex);
            }
        }

        // PUT: api/Articulo/5 //MODIFICA
        public IHttpActionResult Put(int id, [FromBody] ArticuloDTO articulo)
        {
            try
            {
                // Validaciones
                if (articulo == null)
                    return BadRequest("El artículo no puede ser nulo.");

                if (string.IsNullOrEmpty(articulo.Nombre))
                    return BadRequest("El nombre del artículo es obligatorio.");

                if (articulo.Precio <= 0)
                    return BadRequest("El precio debe ser mayor que cero.");

                if (articulo.Idcategoria <= 0 || articulo.Idmarca <= 0)
                    return BadRequest("Debe seleccionar una marca y una categoría válidas.");

                if (id <= 0)
                    return BadRequest("El ID del artículo no es válido.");

                ConexionArticulo conexion = new ConexionArticulo();

                Articulo modificado = new Articulo
                {
                    Id = id,
                    Codigo = articulo.Codigo,
                    Nombre = articulo.Nombre,
                    Descripcion = articulo.Descripcion,
                    Idmarca = articulo.Idmarca,
                    Idcategoria = articulo.Idcategoria,
                    Idimagen = articulo.Idimagen,
                    Precio = articulo.Precio
                };

                conexion.modificar(modificado);

                return Ok("Artículo modificado correctamente.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Articulo/5 //ELIMINA
        public void Delete(int id)
        {
            ConexionArticulo conexion = new ConexionArticulo();
            conexion.eliminar (id);
        }
    }
}
