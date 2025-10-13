using Conexion;
using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Actividad2
{
    public partial class FrmCategorias : Form
    {
        public FrmCategorias()
        {
            InitializeComponent();
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            cargar();
        }
        private void cargar()
        {
            ConexionCategorias conexion = new ConexionCategorias();
            List<Categoria> listaCategorias = conexion.Listar();
            dgvCategorias.DataSource = conexion.Listar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmCategoriaAlta ventana = new FrmCategoriaAlta(); 
            ventana.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow != null)
            {
                Categoria seleccionada = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
                FrmCategoriaAlta form = new FrmCategoriaAlta(seleccionada);
                form.ShowDialog();
                cargar(); 
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ConexionCategorias conexion = new ConexionCategorias();
            Categoria seleccionado;

            try
            {
                seleccionado = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
                DialogResult respuesta = MessageBox.Show("¿Seguro que querés eliminar esta categoria?",
                                                 "Eliminar Categoria",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    conexion.eliminar (seleccionado.Id);
                    MessageBox.Show("Artículo eliminado correctamente.");
                    cargar();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

    }
}
