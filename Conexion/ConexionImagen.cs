using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conexion
{
    public class ConexionImagen
    {

        public List<Imagen> Listar(int IdArticulo)
        {
            List<Imagen> listaImagenes = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setarConsulta("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES WHERE IdArticulo = @IdArticulo");
                datos.setearParametro("@IdArticulo", IdArticulo);
                datos.ejecutarLectura();

                while( datos.Lector.Read() )
                {
                    int Id = (int)datos.Lector["Id"];
                    Imagen aux = listaImagenes.Find(img => img.IdImagen == Id);

                    if( aux == null )
                    {
                        aux = new Imagen();
                        aux.IdImagen = (int)datos.Lector["Id"];
                        aux.IdArticulo = (int)datos.Lector["IdArticulo"];
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];

                        listaImagenes.Add(aux);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }finally
            {
                datos.cerrarConexion();
            }

            return listaImagenes;

        }
        public int Agregar(Imagen imagen)
        {
            int idImagen;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setarConsulta("INSERT INTO IMAGENES (ImagenUrl, IdArticulo) VALUES (@ImagenUrl, @IdArticulo) ; SELECT CAST(SCOPE_IDENTITY() AS int);");
                datos.setearParametro("@IdArticulo", imagen.IdArticulo);
                datos.setearParametro("@ImagenUrl", imagen.UrlImagen);
                idImagen = datos.ejecutarEscalar();
            }
            catch (Exception ex)
            {
               idImagen = 0;
               MessageBox.Show(ex.ToString());
            }
            finally
            {
                datos.cerrarConexion();
            }

            return idImagen;
        }

        public void Modificar(Imagen imagen)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setarConsulta("UPDATE IMAGENES SET ImagenUrl = @ImagenUrl WHERE Id = @IdImagen");
                datos.setearParametro("@ImagenUrl", imagen.UrlImagen);
                datos.setearParametro("@IdImagen", imagen.IdImagen);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void ModificarImagenes(List<Imagen> listaImagenes)
        {
            for(int i = 0; i < listaImagenes.Count(); i++)
            {
                Modificar(listaImagenes[i]);
            }
        }


        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setarConsulta("DELETE FROM Imagenes WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
