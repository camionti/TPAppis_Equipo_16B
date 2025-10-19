using dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Conexion
{
    public class ConexionArticulo
    {
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setarConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, A.IdCategoria, A.Precio, I.ImagenUrl, I.Id IdImagen, M.Descripcion Marca, C.Descripcion Categoria FROM ARTICULOS A LEFT JOIN IMAGENES I ON I.IdArticulo = A.Id LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id INNER JOIN MARCAS M ON A.IdMarca = M.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    int Id = (int)datos.Lector["Id"];
                    Articulo aux = lista.Find( articulo => articulo.Id == Id);

                    if (aux == null)
                    {
                        aux = new Articulo();
                        aux.Id = (int)datos.Lector["Id"];
                        aux.Codigo = datos.Lector["Codigo"].ToString();
                        aux.Nombre = (string)datos.Lector["Nombre"];
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                        aux.Idmarca = (int)datos.Lector["IdMarca"];
                        aux.Idcategoria = (int)datos.Lector["IdCategoria"];
                        aux.Precio = (decimal)datos.Lector["Precio"];
                        aux.TipoMarca = new Marca();
                        aux.TipoMarca.Descripcion = (string)datos.Lector["Marca"];
                        aux.TipoCategoria = new Categoria();
                        aux.TipoCategoria.Descripcion = datos.Lector["Categoria"] is DBNull ? "" : (string)datos.Lector["Categoria"];
                        aux.Imagen = new List<Imagen>();

                        lista.Add(aux);
                    }

                    if (!(datos.Lector["IdImagen"] is DBNull))
                    {
                        Imagen imgAux = new Imagen();
                        imgAux.IdImagen = (int)datos.Lector["IdImagen"];
                        imgAux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                        imgAux.IdArticulo = aux.Id;

                        aux.Imagen.Add(imgAux);
                    }

                }

                return lista;

            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        
        public int agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            int idArticulo;

            try
            {
                datos.setarConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria) " +
                     "VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @IdMarca, @IdCategoria); SELECT CAST(SCOPE_IDENTITY() AS int);");

                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.setearParametro("@IdMarca", nuevo.Idmarca);
                datos.setearParametro("@IdCategoria", nuevo.Idcategoria);
                idArticulo = datos.ejecutarEscalar();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { 
                datos.cerrarConexion();
            }

            return idArticulo;
        }
        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setarConsulta("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio WHERE Id = @Id");
                datos.setearParametro("@Codigo", articulo.Codigo);
                datos.setearParametro("@Nombre", articulo.Nombre);
                datos.setearParametro("@Descripcion", articulo.Descripcion);
                datos.setearParametro("@Precio", articulo.Precio);
                datos.setearParametro("@IdMarca", articulo.Idmarca);
                datos.setearParametro("@IdCategoria", articulo.Idcategoria);
                datos.setearParametro("@Id", articulo.Id);



                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar (int id)
        {
            try
            {
                AccesoDatos datos= new AccesoDatos();
                datos.setarConsulta("delete from ARTICULOS where id = @id");
                datos.setearParametro ("@id", id);
                datos.ejecutarAccion ();

            }
            catch (Exception ex)
            {

                throw ex ;
            }
        }

        public Articulo buscarXCodigo(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setarConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, A.IdCategoria, A.Precio, I.ImagenUrl, I.Id IdImagen, M.Descripcion Marca, C.Descripcion Categoria FROM ARTICULOS A LEFT JOIN IMAGENES I ON I.IdArticulo = A.Id LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id INNER JOIN MARCAS M ON A.IdMarca = M.Id WHERE A.Codigo = @codigo");
                datos.setearParametro("@codigo", codigo);
                datos.ejecutarLectura();


                if (!datos.Lector.Read())
                    return null;

                Articulo aux = new Articulo();

                aux.Id = (int)datos.Lector["Id"];
                aux.Codigo = datos.Lector["Codigo"].ToString();
                aux.Nombre = (string)datos.Lector["Nombre"];
                aux.Descripcion = (string)datos.Lector["Descripcion"];
                aux.Idmarca = (int)datos.Lector["IdMarca"];
                aux.Idcategoria = (int)datos.Lector["IdCategoria"];
                aux.Precio = (decimal)datos.Lector["Precio"];
                aux.TipoMarca = new Marca();
                aux.TipoMarca.Descripcion = (string)datos.Lector["Marca"];
                aux.TipoCategoria = new Categoria();
                aux.TipoCategoria.Descripcion = datos.Lector["Categoria"] is DBNull ? "" : (string)datos.Lector["Categoria"];
                aux.Imagen = new List<Imagen>();

                do
                {
                    if (!(datos.Lector["IdImagen"] is DBNull))
                    {
                        aux.Imagen.Add(new Imagen
                        {
                            IdImagen = (int)datos.Lector["IdImagen"],
                            UrlImagen = (string)datos.Lector["ImagenUrl"],
                            IdArticulo = aux.Id
                        });
                    }
                } while (datos.Lector.Read());


                return aux;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
