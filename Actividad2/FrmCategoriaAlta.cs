using Conexion;
using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Conexion.ConexionArticulo;

namespace Actividad2
{
    public partial class FrmCategoriaAlta : Form
    {
        private Categoria categoria = null;

        
        public FrmCategoriaAlta()
        {
            InitializeComponent();
            
        }
        public FrmCategoriaAlta(Categoria categoria) : this() 
        {
            this.categoria = categoria;
           
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            if (categoria != null)
                categoria.Descripcion = txtDescripcion.Text;
        }

        private void FrmCategoriaAlta_Load(object sender, EventArgs e)
        {
            ConexionCategorias categoriaConexion = new ConexionCategorias();

            try
            {

                if (categoria != null)
                {
                    txtDescripcion.Text = categoria.Descripcion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ConexionCategorias conexion = new ConexionCategorias();

            try
            {
                if (categoria == null)
                    categoria = new Categoria();

                categoria.Descripcion = txtDescripcion.Text;

                if (categoria.Id != 0)
                {
                    conexion.modificar(categoria);
                    MessageBox.Show("Categoría modificada exitosamente.");
                }
                else
                {
                    conexion.agregar(categoria);
                    MessageBox.Show("Categoría agregada exitosamente.");
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
