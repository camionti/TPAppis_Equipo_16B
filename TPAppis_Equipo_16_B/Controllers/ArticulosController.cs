using Conexion;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;
using TPAppis_Equipo_16_B.Models;
namespace TPAppis_Equipo_16_B.Controllers
{
    public class ArticulosController : ApiController
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

        //GET: api/Articulo?codigo={ codigo articulo } //BUSCA x codigo 
        public IHttpActionResult Get(string codigo)
        {
            ConexionArticulo articulos = new ConexionArticulo();
            Articulo articulo = articulos.buscarXCodigo(codigo);
            return Ok(articulo);
        }

        // POST: api/Articulo //AGREGA
        public IHttpActionResult Post([FromBody]ArticuloDTO articulo)
        {
            try
            {
                // Validaciones 
                if (articulo == null)
                    return BadRequest("Error al enviar el artículo.");

                if (string.IsNullOrEmpty(articulo.Nombre))
                    return BadRequest("El nombre del artículo es obligatorio.");

                if (articulo.Precio <= 0)
                    return BadRequest("El precio debe ser mayor que cero.");

                if (articulo.Idcategoria <= 0 || articulo.Idmarca <= 0)
                    return BadRequest("Debe seleccionar una marca y una categoría válidas.");

                
                ConexionArticulo conexion = new ConexionArticulo();

                Articulo articuloEncontrado = null;

                articuloEncontrado = conexion.Listar().Find(x => x.Codigo == articulo?.Codigo);

                if (articuloEncontrado != null)
                    return BadRequest("Ya existe un articulo con ese código.");

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

        //POSTLOTE: api/articulo/6/imagenes //AGREGAR LOTE IMAGENES
        [Route("api/articulos/{id:int}/imagenes")]
        public IHttpActionResult PostLote(int id, [FromBody] List<String> imagenes)
        {
            if(id <= 0)
                return BadRequest("El id de articulo no es correcto.");
            

            if (imagenes == null || imagenes.Count == 0)
                return BadRequest("La lista de imagenes esta vacía");

            var conexionArticulo = new ConexionArticulo();
            var existeArticulo = conexionArticulo.Listar().Find(a => a.Id == id);
            if (existeArticulo == null)
                return BadRequest("No existe el artículo");

            var conexionImagen = new ConexionImagen();

            int insertadas = 0;
            int errores = 0;
            var urlImgNoCargadas = new List<string>();

            foreach( var imgUrl in imagenes)
            {
                try
                {
                    var imagen = new Imagen()
                    {
                        IdArticulo = id,
                        UrlImagen = imgUrl
                    };

                    var idNuevaImagen = conexionImagen.Agregar(imagen);

                    if( idNuevaImagen > 0 )
                    {   insertadas++; }
                    else
                    {
                        errores++;
                        urlImgNoCargadas.Add(imgUrl);
                    }

                }
                catch (Exception)
                {
                    errores++;
                    urlImgNoCargadas.Add(imgUrl);
                }
            }

            var payload = new
            {
                idArticulo = id,
                insertadas,
                errores,
                urlImgNoCargadas
            };

            return Created($"api/articulo/{id}/imagenes", payload);
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

                Articulo articuloEncontrado = conexion.Listar().Find(x => x.Id == id);

                if (articuloEncontrado == null)
                    return BadRequest("No existe un articulo con ese id.");

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
        public IHttpActionResult Delete(int id)
        {
            ConexionArticulo conexion = new ConexionArticulo();

            Articulo articuloEncontrado = conexion.Listar().Find(x => x.Id == id);

            if (articuloEncontrado == null)
                return BadRequest("No existe un articulo con ese id.");

            conexion.eliminar (id);

            return Ok("Articulo borrado correctamente");
        }
    }
}
