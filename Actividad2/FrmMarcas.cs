using Conexion;
using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Actividad2
{
    public partial class FrmMarcas : Form
    {
        public FrmMarcas()
        {
            InitializeComponent();
        }

        private void FrmMarcas_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            ConexionMarca con = new ConexionMarca();
            List<Marca> listaMarcas = con.Listar();
            dgvMarcas.DataSource = listaMarcas;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmMarcasAlta form = new FrmMarcasAlta();
            form.ShowDialog();
            Cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(dgvMarcas.CurrentRow != null)
            {
                Marca seleccionada = (Marca)dgvMarcas.CurrentRow.DataBoundItem;
                FrmMarcasAlta form = new FrmMarcasAlta(seleccionada);
                form.ShowDialog();
                Cargar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ConexionMarca conexion = new ConexionMarca();
            Marca seleccionada;
            try
            {
                seleccionada = (Marca)dgvMarcas.CurrentRow.DataBoundItem;
                DialogResult response = MessageBox.Show("¿Está seguro que quiere eliminar esta marca?",
                    "Eliminar marca: " + seleccionada.Descripcion,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if( response == DialogResult.Yes)
                {
                    conexion.Eliminar(seleccionada.IDMarca);
                    MessageBox.Show("Marca borrada correctamente");
                    Cargar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
