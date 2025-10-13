using dominio;
using System;
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
                datos.setarConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, A.IdCategoria, A.Precio, I.ImagenUrl, I.Id IdImagen, M.Descripcion Marca, C.Descripcion Categoria FROM ARTICULOS A LEFT JOIN IMAGENES I ON I.IdArticulo = A.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id INNER JOIN MARCAS M ON A.IdMarca = M.Id");
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
                        aux.TipoCategoria.Descripcion = (string)datos.Lector["Categoria"];
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

        public List<Articulo> filtroAvanzado(string campo, string criterio, string filtro, int precioMinimo, int precioMaximo)
        {
            List<Articulo> listaArticulos = new List<Articulo>();
            AccesoDatos BaseDeDatos = new AccesoDatos();

            try
            {

                string consulta = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, Precio, C.Descripcion Categoria,C.Id IdCategoria , M.Descripcion Marca, M.Id IdMarca, I.ImagenUrl UrlImagen, I.Id IdImagen from ARTICULOS A, CATEGORIAS C, MARCAS M, IMAGENES I where M.Id = A.IdMarca And A.IdCategoria = C.Id AND I.Id = (SELECT MIN(Id) FROM IMAGENES WHERE IdArticulo = A.Id) AND ";

                switch (campo)
                {
                    case "Código":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "Codigo like '" + filtro + "%'";
                                break;

                            case "Termina con":
                                consulta += "Codigo like '%" + filtro + "'";
                                break;

                            default:
                                consulta += "Codigo like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    case "Marca":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "M.Descripcion like '" + filtro + "%'";
                                break;

                            case "Termina con":
                                consulta += "M.Descripcion like '%" + filtro + "'";
                                break;

                            default:
                                consulta += "M.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    case "Categoría":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "C.Descripcion like '" + filtro + "%'";
                                break;

                            case "Termina con":
                                consulta += "C.Descripcion like '%" + filtro + "'";
                                break;

                            default:
                                consulta += "C.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    default:
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "Nombre like '" + filtro + "%'";
                                break;

                            case "Termina con":
                                consulta += "C.Descripcion like '%" + filtro + "'";
                                break;

                            default:
                                consulta += "C.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;
                }

                //Agrego los precios a la consulta
                consulta += " AND Precio >= " + precioMinimo + " AND Precio <= " + precioMaximo;

                BaseDeDatos.setarConsulta(consulta);
                BaseDeDatos.ejecutarLectura();

                 while (BaseDeDatos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                   

                    aux.Id = (int)BaseDeDatos.Lector["Id"];
                    aux.Codigo = BaseDeDatos.Lector["Codigo"].ToString();
                    aux.Nombre = (string)BaseDeDatos.Lector["Nombre"];
                    aux.Descripcion = (string)BaseDeDatos.Lector["Descripcion"];
                    aux.Idmarca = (int)BaseDeDatos.Lector["IdMarca"];
                    aux.Idcategoria = (int)BaseDeDatos.Lector["IdCategoria"];
                    aux.Precio = (decimal)BaseDeDatos.Lector["Precio"];
                    aux.TipoMarca = new Marca();
                    aux.TipoMarca.Descripcion = (string)BaseDeDatos.Lector["Marca"];
                    aux.TipoCategoria = new Categoria();
                    aux.TipoCategoria.Descripcion = (string)BaseDeDatos.Lector["Categoria"];
                    aux.Imagen = new List<Imagen>();
                    aux.Imagen[aux.Id].UrlImagen = (string)BaseDeDatos.Lector["UrlImagen"];
                    aux.Imagen[aux.Id].IdImagen = (int)BaseDeDatos.Lector["IdImagen"];


                    listaArticulos.Add(aux);
                }

                return listaArticulos;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
