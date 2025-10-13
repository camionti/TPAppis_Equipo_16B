using System;
using System.Windows.Forms;

namespace Actividad2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.DGVArticulos = new System.Windows.Forms.DataGridView();
            this.btnAgregarArticulo = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminarArticulos = new System.Windows.Forms.Button();
            this.lblFiltroRapido = new System.Windows.Forms.Label();
            this.txtFiltroRapido = new System.Windows.Forms.TextBox();
            this.txtFiltroAvanzado = new System.Windows.Forms.TextBox();
            this.cboCriterio = new System.Windows.Forms.ComboBox();
            this.cboCampo = new System.Windows.Forms.ComboBox();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.lblCampo = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPrecioMaximo = new System.Windows.Forms.Label();
            this.txtPrecioMaximo = new System.Windows.Forms.TextBox();
            this.txtPrecioMinimo = new System.Windows.Forms.TextBox();
            this.pbxArticulo = new System.Windows.Forms.PictureBox();
            this.btnCategorias = new System.Windows.Forms.Button();
            this.btnMarcas = new System.Windows.Forms.Button();
            this.bntImgAtras = new System.Windows.Forms.Button();
            this.bntImgAdelante = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVArticulos
            // 
            this.DGVArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGVArticulos.Location = new System.Drawing.Point(35, 56);
            this.DGVArticulos.Margin = new System.Windows.Forms.Padding(2);
            this.DGVArticulos.Name = "DGVArticulos";
            this.DGVArticulos.RowHeadersWidth = 51;
            this.DGVArticulos.RowTemplate.Height = 24;
            this.DGVArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVArticulos.Size = new System.Drawing.Size(667, 295);
            this.DGVArticulos.TabIndex = 1;
            this.DGVArticulos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVArticulos_CellContentDoubleClick);
            this.DGVArticulos.SelectionChanged += new System.EventHandler(this.DGVArticulos_SelectionChanged);
            // 
            // btnAgregarArticulo
            // 
            this.btnAgregarArticulo.Location = new System.Drawing.Point(35, 370);
            this.btnAgregarArticulo.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarArticulo.Name = "btnAgregarArticulo";
            this.btnAgregarArticulo.Size = new System.Drawing.Size(118, 28);
            this.btnAgregarArticulo.TabIndex = 1;
            this.btnAgregarArticulo.Text = "Agregar Articulo ";
            this.btnAgregarArticulo.UseVisualStyleBackColor = true;
            this.btnAgregarArticulo.Click += new System.EventHandler(this.btnAgregarArticulo_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(177, 370);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(118, 28);
            this.btnModificar.TabIndex = 2;
            this.btnModificar.Text = "Modificar Articulo ";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminarArticulos
            // 
            this.btnEliminarArticulos.Location = new System.Drawing.Point(317, 370);
            this.btnEliminarArticulos.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminarArticulos.Name = "btnEliminarArticulos";
            this.btnEliminarArticulos.Size = new System.Drawing.Size(118, 28);
            this.btnEliminarArticulos.TabIndex = 3;
            this.btnEliminarArticulos.Text = "Eliminar Articulo ";
            this.btnEliminarArticulos.UseVisualStyleBackColor = true;
            this.btnEliminarArticulos.Click += new System.EventHandler(this.btnEliminarArticulos_Click);
            // 
            // lblFiltroRapido
            // 
            this.lblFiltroRapido.AutoSize = true;
            this.lblFiltroRapido.Location = new System.Drawing.Point(32, 28);
            this.lblFiltroRapido.Name = "lblFiltroRapido";
            this.lblFiltroRapido.Size = new System.Drawing.Size(66, 13);
            this.lblFiltroRapido.TabIndex = 4;
            this.lblFiltroRapido.Text = "Filtro Rápido";
            // 
            // txtFiltroRapido
            // 
            this.txtFiltroRapido.Location = new System.Drawing.Point(104, 25);
            this.txtFiltroRapido.Name = "txtFiltroRapido";
            this.txtFiltroRapido.Size = new System.Drawing.Size(205, 20);
            this.txtFiltroRapido.TabIndex = 0;
            this.txtFiltroRapido.TextChanged += new System.EventHandler(this.txtFiltroRapido_TextChanged);
            // 
            // txtFiltroAvanzado
            // 
            this.txtFiltroAvanzado.Location = new System.Drawing.Point(900, 372);
            this.txtFiltroAvanzado.Name = "txtFiltroAvanzado";
            this.txtFiltroAvanzado.Size = new System.Drawing.Size(186, 20);
            this.txtFiltroAvanzado.TabIndex = 8;
            // 
            // cboCriterio
            // 
            this.cboCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriterio.FormattingEnabled = true;
            this.cboCriterio.Location = new System.Drawing.Point(763, 370);
            this.cboCriterio.Name = "cboCriterio";
            this.cboCriterio.Size = new System.Drawing.Size(120, 21);
            this.cboCriterio.TabIndex = 5;
            // 
            // cboCampo
            // 
            this.cboCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCampo.FormattingEnabled = true;
            this.cboCampo.Location = new System.Drawing.Point(542, 369);
            this.cboCampo.Name = "cboCampo";
            this.cboCampo.Size = new System.Drawing.Size(117, 21);
            this.cboCampo.TabIndex = 4;
            this.cboCampo.SelectedIndexChanged += new System.EventHandler(this.cboCampo_SelectedIndexChanged);
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(711, 373);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(39, 13);
            this.lblCriterio.TabIndex = 24;
            this.lblCriterio.Text = "Criterio";
            // 
            // lblCampo
            // 
            this.lblCampo.AutoSize = true;
            this.lblCampo.Location = new System.Drawing.Point(451, 373);
            this.lblCampo.Name = "lblCampo";
            this.lblCampo.Size = new System.Drawing.Size(85, 13);
            this.lblCampo.TabIndex = 23;
            this.lblCampo.Text = "Filtrar por campo";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(1101, 369);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 24);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(455, 411);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Precio mínimo";
            // 
            // lblPrecioMaximo
            // 
            this.lblPrecioMaximo.AutoSize = true;
            this.lblPrecioMaximo.Location = new System.Drawing.Point(682, 411);
            this.lblPrecioMaximo.Name = "lblPrecioMaximo";
            this.lblPrecioMaximo.Size = new System.Drawing.Size(75, 13);
            this.lblPrecioMaximo.TabIndex = 30;
            this.lblPrecioMaximo.Text = "Precio máximo";
            // 
            // txtPrecioMaximo
            // 
            this.txtPrecioMaximo.Location = new System.Drawing.Point(763, 408);
            this.txtPrecioMaximo.Name = "txtPrecioMaximo";
            this.txtPrecioMaximo.Size = new System.Drawing.Size(133, 20);
            this.txtPrecioMaximo.TabIndex = 7;
            // 
            // txtPrecioMinimo
            // 
            this.txtPrecioMinimo.Location = new System.Drawing.Point(542, 408);
            this.txtPrecioMinimo.Name = "txtPrecioMinimo";
            this.txtPrecioMinimo.Size = new System.Drawing.Size(121, 20);
            this.txtPrecioMinimo.TabIndex = 6;
            // 
            // pbxArticulo
            // 
            this.pbxArticulo.Location = new System.Drawing.Point(763, 56);
            this.pbxArticulo.Name = "pbxArticulo";
            this.pbxArticulo.Size = new System.Drawing.Size(323, 295);
            this.pbxArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxArticulo.TabIndex = 32;
            this.pbxArticulo.TabStop = false;
            // 
            // btnCategorias
            // 
            this.btnCategorias.Location = new System.Drawing.Point(35, 411);
            this.btnCategorias.Margin = new System.Windows.Forms.Padding(2);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(180, 30);
            this.btnCategorias.TabIndex = 33;
            this.btnCategorias.Text = "Categorias";
            this.btnCategorias.UseVisualStyleBackColor = true;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // btnMarcas
            // 
            this.btnMarcas.Location = new System.Drawing.Point(257, 411);
            this.btnMarcas.Margin = new System.Windows.Forms.Padding(2);
            this.btnMarcas.Name = "btnMarcas";
            this.btnMarcas.Size = new System.Drawing.Size(180, 30);
            this.btnMarcas.TabIndex = 34;
            this.btnMarcas.Text = "Marcas";
            this.btnMarcas.UseVisualStyleBackColor = true;
            this.btnMarcas.Click += new System.EventHandler(this.btnMarcas_Click);
            // 
            // bntImgAtras
            // 
            this.bntImgAtras.Location = new System.Drawing.Point(716, 188);
            this.bntImgAtras.Name = "bntImgAtras";
            this.bntImgAtras.Size = new System.Drawing.Size(34, 35);
            this.bntImgAtras.TabIndex = 35;
            this.bntImgAtras.Text = "←";
            this.bntImgAtras.UseVisualStyleBackColor = true;
            this.bntImgAtras.Click += new System.EventHandler(this.bntImgAtras_Click);
            // 
            // bntImgAdelante
            // 
            this.bntImgAdelante.Location = new System.Drawing.Point(1101, 188);
            this.bntImgAdelante.Name = "bntImgAdelante";
            this.bntImgAdelante.Size = new System.Drawing.Size(34, 35);
            this.bntImgAdelante.TabIndex = 36;
            this.bntImgAdelante.Text = "→";
            this.bntImgAdelante.UseVisualStyleBackColor = true;
            this.bntImgAdelante.Click += new System.EventHandler(this.bntImgAdelante_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 465);
            this.Controls.Add(this.bntImgAdelante);
            this.Controls.Add(this.bntImgAtras);
            this.Controls.Add(this.btnMarcas);
            this.Controls.Add(this.btnCategorias);
            this.Controls.Add(this.pbxArticulo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPrecioMaximo);
            this.Controls.Add(this.txtPrecioMaximo);
            this.Controls.Add(this.txtPrecioMinimo);
            this.Controls.Add(this.txtFiltroAvanzado);
            this.Controls.Add(this.cboCriterio);
            this.Controls.Add(this.cboCampo);
            this.Controls.Add(this.lblCriterio);
            this.Controls.Add(this.lblCampo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtFiltroRapido);
            this.Controls.Add(this.lblFiltroRapido);
            this.Controls.Add(this.btnEliminarArticulos);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregarArticulo);
            this.Controls.Add(this.DGVArticulos);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.DataGridView DGVArticulos;
        private Button btnAgregarArticulo;
        private Button btnModificar;
        private Button btnEliminarArticulos;
        private Label lblFiltroRapido;
        private TextBox txtFiltroRapido;
        private ComboBox cboCriterio;
        private ComboBox cboCampo;
        private Label lblCriterio;
        private Label lblCampo;
        private Button btnBuscar;
        private Label label2;
        private Label lblPrecioMaximo;
        private TextBox txtPrecioMaximo;
        private TextBox txtPrecioMinimo;
        private PictureBox pbxArticulo;
        private Button btnCategorias;
        private Button btnMarcas;
        protected TextBox txtFiltroAvanzado;
        private Button bntImgAtras;
        private Button bntImgAdelante;
    }
}

