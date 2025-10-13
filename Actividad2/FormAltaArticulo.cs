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
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Conexion.ConexionArticulo;

namespace Actividad2
{
    public partial class FormAltaArticulo : Form
    {

        private Articulo articulo = null;
        private OpenFileDialog archivo = null;
        private int indicePbx = 0;
        private PictureBox[] pictureBoxes;
        private PictureBox pbxSeleccionado = null;
        private List<Imagen> listaImagenes = new List<Imagen>();
        private List<int> idsImagenesParaEliminar = new List<int>();
        private string txtURLImagen = "";

        public FormAltaArticulo()
        {
            InitializeComponent();
            InicializarPbx();
            DeshabilitarBotones();

            foreach (PictureBox pbx in pictureBoxes)
            {
                pbx.Click += pbxClick;
                pbx.MouseDoubleClick += pbxDobleClick;
            }

        }



        public FormAltaArticulo(Articulo articulo) : this()
        {
            this.articulo = articulo;
            Text = "Modificar Articulo";
        }
        private void FormAltaArticulo_Load(object sender, EventArgs e)
        {
            ConexionArticulo articuloConexion = new ConexionArticulo();
            if (articulo == null) articulo = new Articulo();
            if (articulo.Imagen == null) articulo.Imagen = new List<Imagen>();

            try
            {
                ConexionMarca conexionMarca = new ConexionMarca();
                ConexionCategorias conexionCategoria = new ConexionCategorias();

                comboBoxMarca.DataSource = conexionMarca.Listar();
                comboBoxMarca.DisplayMember = "Descripcion";
                comboBoxMarca.ValueMember = "IDMarca";
                comboBoxCategoria.DataSource = conexionCategoria.Listar();
                comboBoxCategoria.DisplayMember = "Descripcion";
                comboBoxCategoria.ValueMember = "Id";

                //Si el articulo existe lo creo
                if (articulo != null)
                {
                    textBoxCodigo.Text = articulo.Codigo;
                    textBoxNombre.Text = articulo.Nombre;
                    textBoxDescrip.Text = articulo.Descripcion;
                    textBoxPrecio.Text = articulo.Precio.ToString();
                    comboBoxMarca.SelectedValue = articulo.Idmarca;
                    comboBoxCategoria.SelectedValue = articulo.Idcategoria;

                    //Cargo las imgs en los pbx
                    for (int i = 0; i < articulo.Imagen.Count && i < pictureBoxes.Length; i++)
                    {
                        agregarImagenPbx(pictureBoxes[i], articulo.Imagen[i]);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void agregarImagenPbx(PictureBox pbx, Imagen img)
        {
            string urlXDefecto = "https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png";


            if (img == null) img = new Imagen();
            pbx.Tag = img;
            pbx.Visible = true;

            try
            {
                if (!string.IsNullOrEmpty(img.UrlImagen))
                    pbx.Load(img.UrlImagen);
                else
                    pbx.Load(urlXDefecto);
            }
            catch (Exception)
            {

                pbx.Load(urlXDefecto);
                img.UrlImagen = urlXDefecto;
            }
        }

        private void InicializarPbx()
        {
            pictureBoxes = new PictureBox[] { pbx_1, pbx_2, pbx_3, pbx_4 };
        }

        private void DeshabilitarBotones()
        {
            btnModificarImagen.Enabled = false;
            btnEliminarImagen.Enabled = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonConfrim_Click(object sender, EventArgs e)
        {

            ConexionArticulo conexionArticulo = new ConexionArticulo();
            ConexionImagen conexionImagen = new ConexionImagen();

            try
            {
                if (articulo == null)
                    articulo = new Articulo();

                if (string.IsNullOrWhiteSpace(textBoxCodigo.Text)) { MessageBox.Show("Debe ingresar un código para el artículo."); return; }
                if (string.IsNullOrWhiteSpace(textBoxNombre.Text)) { MessageBox.Show("Debe ingresar un nombre para el artículo."); return; }
                if (comboBoxMarca.SelectedIndex < 0) { MessageBox.Show("Debe seleccionar una marca."); return; }
                if (comboBoxCategoria.SelectedIndex < 0) { MessageBox.Show("Debe seleccionar una categoría."); return; }


                decimal precio;

                if (!decimal.TryParse(textBoxPrecio.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out precio))
                { MessageBox.Show("El precio ingresado no es válido."); return; }
                if (precio <= 0) { MessageBox.Show("El precio debe ser mayor a cero."); return; }

                articulo.Codigo = textBoxCodigo.Text;
                articulo.Nombre = textBoxNombre.Text;
                articulo.Descripcion = textBoxDescrip.Text;
                articulo.Idmarca = (int)comboBoxMarca.SelectedValue;
                articulo.Idcategoria = (int)comboBoxCategoria.SelectedValue;
                articulo.Precio = precio;

                articulo.TipoMarca = new Marca { IDMarca = articulo.Idmarca };
                articulo.TipoCategoria = new Categoria { Id = articulo.Idcategoria };
                articulo.Imagen = new List<Imagen>();

                foreach (var pbx in pictureBoxes)
                {
                    if (pbx.Tag is Imagen img && !string.IsNullOrWhiteSpace(img.UrlImagen))
                        articulo.Imagen.Add(img);
                }

                if (articulo.Id != 0)
                    conexionArticulo.modificar(articulo);
                else
                    articulo.Id = conexionArticulo.agregar(articulo);

                if (idsImagenesParaEliminar.Count > 0)
                {
                    // uso HashSet por si se marcó dos veces el mismo Id
                    var uniq = new HashSet<int>(idsImagenesParaEliminar);
                    foreach (var idImg in uniq)
                        conexionImagen.Eliminar(idImg);
                }

                var imgsDb = conexionImagen.Listar(articulo.Id);
                cargarImagenesEnDB(imgsDb, articulo.Imagen, articulo.Id);

                idsImagenesParaEliminar.Clear();
                MessageBox.Show(articulo.Id != 0 ? "Articulo modificado exitosamente" : "Articulo agregado exitosamente");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cargarImagenesEnDB(List<Imagen> listaDB, List<Imagen> listaFormulario, int idArticulo)
        {
            ConexionImagen conexionImagen = new ConexionImagen();
            try
            {
                foreach (Imagen img in listaFormulario)
                {

                    if (img == null) continue;

                    if (img.Eliminada)
                    {
                        if (img.IdImagen > 0)
                            conexionImagen.Eliminar(img.IdImagen);
                        continue;
                    }

                    img.IdArticulo = idArticulo;

                    if (img.IdImagen > 0)
                    {

                        bool cambioUrl = listaDB.Any(imgDB => imgDB.IdImagen == img.IdImagen && imgDB.UrlImagen != img.UrlImagen);

                        if (cambioUrl)
                            conexionImagen.Modificar(img);
                    }
                    else if (img.IdImagen == 0)
                    {
                        img.IdArticulo = idArticulo;
                        img.IdImagen = conexionImagen.Agregar(img);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }



        private void btnExaminar_Click(object sender, EventArgs e)
        {

        }

        public void guardarImagenLocal(OpenFileDialog archivo)
        {
            Directory.CreateDirectory(ConfigurationManager.AppSettings["img-folder"]);
            File.Copy(archivo.FileName, ConfigurationManager.AppSettings["img-folder"] + archivo.SafeFileName);
        }

        private void agregarImagen()
        {
            indicePbx = buscarPbxVacio();
            string url = txtURLImagen;

            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("No cargaste ninguna imagen");
                return;
            }

            if (indicePbx >= pictureBoxes.Length) { MessageBox.Show("No se pueden agregar más imágenes"); return; }


            Imagen imagen = pictureBoxes[indicePbx].Tag as Imagen;

            try
            {
                Imagen nuevaImagen = new Imagen { UrlImagen = url };
                pictureBoxes[indicePbx].Tag = nuevaImagen;

                // me aseguro que articulo.Imagen tenga espacio
                if (articulo.Imagen.Count > indicePbx)
                    articulo.Imagen[indicePbx] = nuevaImagen;  // reemplazo
                else
                    articulo.Imagen.Add(nuevaImagen);

                agregarImagenPbx(pictureBoxes[indicePbx], articulo.Imagen[indicePbx]);

            }
            catch (Exception)
            {
                pictureBoxes[indicePbx].Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
                pictureBoxes[indicePbx].Visible = true;
            }

            txtURLImagen = "";

        }

        private void modificarImagen()
        {
            Imagen imagen = pbxSeleccionado.Tag as Imagen;
            string url = txtURLImagen;
            indicePbx = Array.IndexOf(pictureBoxes, pbxSeleccionado);

            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("No cargaste ninguna imagen");
                return;
            }

            if (pbxSeleccionado == null)
            {
                MessageBox.Show("No seleccionaste ningun PictureBox");
                return;
            }

            try
            {
                articulo.Imagen[indicePbx].UrlImagen = url;
                pbxSeleccionado.Tag = articulo.Imagen[indicePbx];
                agregarImagenPbx(pbxSeleccionado, articulo.Imagen[indicePbx]);
            }
            catch (Exception)
            {
                pbxSeleccionado.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }

            pbxSeleccionado.Visible = true;
            txtURLImagen = "";
        }



        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg;|png|*.png;|webp|*.webp;|jpeg|*.jpeg;|bmp|*.bmp";

            if (archivo.ShowDialog() == DialogResult.OK)
            {
                txtURLImagen = archivo.FileName;

            }

            if (!string.IsNullOrEmpty(txtURLImagen))
            {
                agregarImagen();
            }
            else
            {
                MessageBox.Show("Por favor añada una imagen");
                return;
            }
        }

        private int buscarPbxVacio()
        {
            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                //Si no esta visible no esta cargado -> retorno el indice
                if (!pictureBoxes[i].Visible) return i;

                //No tiene img cargada
                if (pictureBoxes[i].Image == null) return i;
            }
            return pictureBoxes.Length;
        }

        private void pbxClick(object sender, EventArgs e)
        {
            PictureBox pbx = sender as PictureBox;
            btnModificarImagen.Enabled = true;
            btnEliminarImagen.Enabled = true;
            //borderstyle
            foreach (var pb in pictureBoxes)
                pb.BorderStyle = BorderStyle.None;

            pbx.BorderStyle = BorderStyle.Fixed3D;


            pbxSeleccionado = pbx;
        }

        private void btnModificarImagen_Click(object sender, EventArgs e)
        {
            if (pbxSeleccionado == null)
            {
                MessageBox.Show("No hay ninguna imagen seleccionada");
                return;
            }


            indicePbx = Array.IndexOf(pictureBoxes, pbxSeleccionado);

            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg;|png|*.png;|webp|*.webp;|jpeg|*.jpeg;|bmp|*.bmp";

            if (archivo.ShowDialog() == DialogResult.OK)
            {
                txtURLImagen = archivo.FileName;

                if (string.IsNullOrWhiteSpace(txtURLImagen))
                {
                    MessageBox.Show("Por favor cargue una imagen");
                    return;
                }
                else
                {

                    modificarImagen();
                }
            }
        }

        private void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            if (pbxSeleccionado == null)
            {
                MessageBox.Show("No hay ninguna imagen seleccionada");
                return;
            }

            Imagen imgSeleccionada = (Imagen)pbxSeleccionado.Tag;
            ConexionImagen conexionImagen = new ConexionImagen();

            try
            {
                DialogResult respuesta = MessageBox.Show("¿Seguro que querés eliminar este artículo?",
                                                 "Eliminar artículo",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {

                    if (imgSeleccionada.IdImagen > 0 && !idsImagenesParaEliminar.Contains(imgSeleccionada.IdImagen))
                        idsImagenesParaEliminar.Add(imgSeleccionada.IdImagen);

                    pbxSeleccionado.Tag = null;
                    pbxSeleccionado.Image = null;
                    pbxSeleccionado.Visible = false;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void pbxDobleClick(object sender, EventArgs e)
        {

            pbxClick(sender, e);

            indicePbx = Array.IndexOf(pictureBoxes, pbxSeleccionado);

            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg;|png|*.png;|webp|*.webp;|jpeg|*.jpeg;|bmp|*.bmp";

            if (archivo.ShowDialog() == DialogResult.OK)
            {
                txtURLImagen = archivo.FileName;

                if (string.IsNullOrWhiteSpace(txtURLImagen))
                {
                    MessageBox.Show("Por favor cargue una imagen");
                    return;
                }

                modificarImagen();
            }

        }
    }
}
