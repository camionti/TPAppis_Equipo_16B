using Conexion;
using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Actividad2
{
    public partial class FrmMarcasAlta : Form
    {

        private Marca marca = null;

        public FrmMarcasAlta()
        {
            InitializeComponent();
        }

        public FrmMarcasAlta(Marca marca) : this()
        {
            this.marca = marca;
            txtDescripcion.Text = marca.Descripcion;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ConexionMarca conexion = new ConexionMarca();

            try
            {
                if (marca == null) marca = new Marca();

                marca.Descripcion = txtDescripcion.Text;

                if( marca.IDMarca != 0)
                {
                    conexion.Modificar(marca);
                    MessageBox.Show("Marca modificada exitosamente.");
                }
                else
                {
                    conexion.Agregar(marca);
                    MessageBox.Show("Marca agregada exitosamente.");
                }

                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
