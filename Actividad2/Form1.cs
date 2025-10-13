using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using Conexion;



namespace Actividad2
{
    public partial class Form1 : Form
    {
        public List<Articulo> listaArticulo;
        private int indiceImg = 0;

        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            cargar();
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Código");
            cboCampo.Items.Add("Marca");
            cboCampo.Items.Add("Categoría");
            cboCampo.SelectedItem = "Nombre";
            cboCriterio.SelectedItem = "Comienza con";
            indiceImg = 0;

        }

        private void cargar()
        {
            Conexion.ConexionArticulo conexion = new Conexion.ConexionArticulo();
            listaArticulo = conexion.Listar();
            DGVArticulos.DataSource = listaArticulo;
            ocultarColumnas();
            indiceImg = 0;

            if (listaArticulo.Count > 0)
            {
                if (listaArticulo[0].Imagen != null && listaArticulo[0].Imagen.Count > 0)
                    cargarImagen(listaArticulo[0].Imagen[0].UrlImagen);
                else
                    cargarImagen("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }

        }

        private void ocultarColumnas()
        {
            string[] cols = { "Id", "IdCategoria", "IdMarca", "IdImagen", "Imagen", "TipoMarca", "TipoCategoria" };
            foreach (var name in cols)
                if (DGVArticulos.Columns.Contains(name))
                    DGVArticulos.Columns[name].Visible = false;
        }
        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            FormAltaArticulo alta = new FormAltaArticulo();
            alta.ShowDialog();
            cargar();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = (Articulo)DGVArticulos.CurrentRow?.DataBoundItem;

            if (seleccionado == null) seleccionado = (Articulo)DGVArticulos.Rows[0].DataBoundItem;

            FormAltaArticulo modificar = new FormAltaArticulo(seleccionado);
            modificar.ShowDialog();
            cargar();
        }

        private void btnEliminarArticulos_Click(object sender, EventArgs e)
        {
            ConexionArticulo conexion = new ConexionArticulo();
            Articulo seleccionado;

            try
            {
                seleccionado = (Articulo)DGVArticulos.CurrentRow.DataBoundItem;
                DialogResult respuesta = MessageBox.Show("¿Seguro que querés eliminar este artículo?",
                                                 "Eliminar artículo",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    conexion.eliminar(seleccionado.Id);
                    MessageBox.Show("Artículo eliminado correctamente.");
                    cargar();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            string filtro = txtFiltroRapido.Text;

            if (filtro.Length >= 1)
            {
                listaFiltrada = listaArticulo.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper())
                                                         || x.TipoMarca.ToString().ToUpper().Contains(filtro.ToUpper())
                                                         || x.TipoCategoria.ToString().ToUpper().Contains(filtro.ToUpper())
                                                         || x.Codigo.ToUpper().Contains(filtro.ToUpper()));

            }
            else
            {
                listaFiltrada = listaArticulo;
            }

            DGVArticulos.DataSource = null;
            DGVArticulos.DataSource = listaFiltrada;
            ocultarColumnas();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ConexionArticulo datosArticulos = new ConexionArticulo();

            try
            {
                if (validarFiltro())
                    return;

                if (validarFiltroNumerico())
                    return;

                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;
                int precioMinimo = validarPrecio(txtPrecioMinimo, 1000);
                int precioMaximo = validarPrecio(txtPrecioMaximo, 99999999);



                DGVArticulos.DataSource = datosArticulos.filtroAvanzado(campo, criterio, filtro, precioMinimo, precioMaximo);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private int validarPrecio(TextBox txtBox, int precioPorDefecto)
        {
            if (string.IsNullOrEmpty(txtBox.Text))
            {
                return precioPorDefecto;
            }

            return int.Parse(txtBox.Text);
        }

        private bool validarFiltro()
        {
            if (cboCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor seleccione un campo para filtrar");
                return true;
            }

            if (cboCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor seleccione un criterio para filtrar");
                return true;
            }


            return false;
        }

        private bool validarFiltroNumerico()
        {
            string precioMinimo = txtPrecioMinimo.Text;
            string precioMaximo = txtPrecioMaximo.Text;

            if (string.IsNullOrEmpty(precioMinimo))
            {
                precioMinimo = "1000";
            }

            if (string.IsNullOrEmpty(precioMaximo))
            {
                precioMaximo = "99999999";
            }

            if (int.Parse(precioMinimo) > int.Parse(precioMaximo))
            {
                MessageBox.Show("El precio mínimo no puede ser mayor al precio máximo");
                txtPrecioMinimo.Text = "";
                txtPrecioMaximo.Text = "";
                txtPrecioMinimo.Focus();
                return true;
            }


            if (int.Parse(precioMinimo) < 1000)
            {
                MessageBox.Show("El precio mínimo no puede ser menor a 1000");
                txtPrecioMinimo.Text = "";
                txtPrecioMinimo.Focus();
                return true;
            }

            if (int.Parse(precioMaximo) < 1500)
            {
                MessageBox.Show("El precio máximo no puede ser menor a 1500");
                txtPrecioMaximo.Text = "";
                txtPrecioMaximo.Focus();
                return true;
            }


            if (!(soloNumeros(precioMinimo)) && !(soloNumeros(precioMaximo)))
            {
                MessageBox.Show("Los campos numéricos deben contener solamente números");
                txtPrecioMinimo.Text = "";
                txtPrecioMaximo.Text = "";
                txtPrecioMinimo.Focus();
                return true;
            }
            else if (!(soloNumeros(precioMinimo)))
            {
                MessageBox.Show("Los campos numéricos deben contener solamente números");
                txtPrecioMinimo.Text = "";
                txtPrecioMinimo.Focus();
                return true;
            }
            else if (!(soloNumeros(precioMaximo)))
            {
                MessageBox.Show("Los campos numéricos deben contener solamente números");
                txtPrecioMaximo.Text = "";
                txtPrecioMaximo.Focus();
                return true;
            }


            return false;
        }

        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                    return false;
            }

            return true;
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();

            if (opcion == "Precio")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }

        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxArticulo.Load(imagen);
            }
            catch (Exception)
            {
                pbxArticulo.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }

        private void DGVArticulos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Articulo seleccionado;
            seleccionado = (Articulo)DGVArticulos.CurrentRow.DataBoundItem;
            FormAltaArticulo modificar = new FormAltaArticulo(seleccionado);
            modificar.ShowDialog();
            cargar();

        }

        private void DGVArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (DGVArticulos.CurrentRow == null) return;

            Articulo aux = (Articulo)DGVArticulos.CurrentRow.DataBoundItem;

            if (DGVArticulos.CurrentRow != null && aux.Imagen.Count > 0)
            {
                cargarImagen(aux.Imagen?[0].UrlImagen);
                
            }
            else
            {
                cargarImagen("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            FrmCategorias FromCategorias = new FrmCategorias();
            FromCategorias.ShowDialog(); 
            cargar(); 
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            FrmMarcas FormMarcas = new FrmMarcas();
            FormMarcas.ShowDialog();
            cargar();
        }

        private void bntImgAdelante_Click(object sender, EventArgs e)
        {

            Articulo seleccionado;
            seleccionado = (Articulo)DGVArticulos.CurrentRow?.DataBoundItem;

            if (seleccionado == null) seleccionado = (Articulo)DGVArticulos.Rows[0].DataBoundItem;

            if (indiceImg + 1 < seleccionado.Imagen.Count())
            {
                indiceImg++;
                cargarImagen(seleccionado.Imagen[indiceImg]?.UrlImagen);
            }
        }

        private void bntImgAtras_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = (Articulo)DGVArticulos.CurrentRow?.DataBoundItem;

            if (seleccionado == null) seleccionado = (Articulo)DGVArticulos.Rows[0].DataBoundItem;

            if (indiceImg >= 1)
            {
                indiceImg--;
                cargarImagen(seleccionado.Imagen[indiceImg]?.UrlImagen);
            }
        }
    }


}
