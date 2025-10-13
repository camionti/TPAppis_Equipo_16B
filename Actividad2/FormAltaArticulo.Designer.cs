namespace Actividad2
{
    partial class FormAltaArticulo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LabelNombre = new System.Windows.Forms.Label();
            this.Descripcion = new System.Windows.Forms.Label();
            this.LabelPrecio = new System.Windows.Forms.Label();
            this.labelMarca = new System.Windows.Forms.Label();
            this.labelCategoria = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxDescrip = new System.Windows.Forms.TextBox();
            this.textBoxPrecio = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonConfrim = new System.Windows.Forms.Button();
            this.comboBoxMarca = new System.Windows.Forms.ComboBox();
            this.comboBoxCategoria = new System.Windows.Forms.ComboBox();
            this.labelCodigo = new System.Windows.Forms.Label();
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.pbx_1 = new System.Windows.Forms.PictureBox();
            this.pbx_2 = new System.Windows.Forms.PictureBox();
            this.pbx_3 = new System.Windows.Forms.PictureBox();
            this.pbx_4 = new System.Windows.Forms.PictureBox();
            this.btnAgregarImagen = new System.Windows.Forms.Button();
            this.btnModificarImagen = new System.Windows.Forms.Button();
            this.btnEliminarImagen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_4)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelNombre
            // 
            this.LabelNombre.AutoSize = true;
            this.LabelNombre.Location = new System.Drawing.Point(25, 62);
            this.LabelNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelNombre.Name = "LabelNombre";
            this.LabelNombre.Size = new System.Drawing.Size(44, 13);
            this.LabelNombre.TabIndex = 0;
            this.LabelNombre.Text = "Nombre";
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSize = true;
            this.Descripcion.Location = new System.Drawing.Point(25, 109);
            this.Descripcion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Size = new System.Drawing.Size(63, 13);
            this.Descripcion.TabIndex = 1;
            this.Descripcion.Text = "Descripcion";
            // 
            // LabelPrecio
            // 
            this.LabelPrecio.AutoSize = true;
            this.LabelPrecio.Location = new System.Drawing.Point(25, 156);
            this.LabelPrecio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelPrecio.Name = "LabelPrecio";
            this.LabelPrecio.Size = new System.Drawing.Size(37, 13);
            this.LabelPrecio.TabIndex = 2;
            this.LabelPrecio.Text = "Precio";
            // 
            // labelMarca
            // 
            this.labelMarca.AutoSize = true;
            this.labelMarca.Location = new System.Drawing.Point(25, 195);
            this.labelMarca.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMarca.Name = "labelMarca";
            this.labelMarca.Size = new System.Drawing.Size(37, 13);
            this.labelMarca.TabIndex = 3;
            this.labelMarca.Text = "Marca";
            // 
            // labelCategoria
            // 
            this.labelCategoria.AutoSize = true;
            this.labelCategoria.Location = new System.Drawing.Point(25, 235);
            this.labelCategoria.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCategoria.Name = "labelCategoria";
            this.labelCategoria.Size = new System.Drawing.Size(52, 13);
            this.labelCategoria.TabIndex = 4;
            this.labelCategoria.Text = "Categoria";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(172, 57);
            this.textBoxNombre.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(140, 20);
            this.textBoxNombre.TabIndex = 1;
            // 
            // textBoxDescrip
            // 
            this.textBoxDescrip.Location = new System.Drawing.Point(172, 102);
            this.textBoxDescrip.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDescrip.Name = "textBoxDescrip";
            this.textBoxDescrip.Size = new System.Drawing.Size(140, 20);
            this.textBoxDescrip.TabIndex = 2;
            // 
            // textBoxPrecio
            // 
            this.textBoxPrecio.Location = new System.Drawing.Point(172, 149);
            this.textBoxPrecio.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPrecio.Name = "textBoxPrecio";
            this.textBoxPrecio.Size = new System.Drawing.Size(140, 20);
            this.textBoxPrecio.TabIndex = 3;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(182, 320);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(130, 29);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancelar";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonConfrim
            // 
            this.buttonConfrim.Location = new System.Drawing.Point(28, 320);
            this.buttonConfrim.Margin = new System.Windows.Forms.Padding(2);
            this.buttonConfrim.Name = "buttonConfrim";
            this.buttonConfrim.Size = new System.Drawing.Size(130, 29);
            this.buttonConfrim.TabIndex = 8;
            this.buttonConfrim.Text = "Confirmar";
            this.buttonConfrim.UseVisualStyleBackColor = true;
            this.buttonConfrim.Click += new System.EventHandler(this.buttonConfrim_Click);
            // 
            // comboBoxMarca
            // 
            this.comboBoxMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMarca.FormattingEnabled = true;
            this.comboBoxMarca.Location = new System.Drawing.Point(172, 193);
            this.comboBoxMarca.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxMarca.Name = "comboBoxMarca";
            this.comboBoxMarca.Size = new System.Drawing.Size(140, 21);
            this.comboBoxMarca.TabIndex = 4;
            // 
            // comboBoxCategoria
            // 
            this.comboBoxCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategoria.FormattingEnabled = true;
            this.comboBoxCategoria.Location = new System.Drawing.Point(172, 235);
            this.comboBoxCategoria.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxCategoria.Name = "comboBoxCategoria";
            this.comboBoxCategoria.Size = new System.Drawing.Size(140, 21);
            this.comboBoxCategoria.TabIndex = 5;
            // 
            // labelCodigo
            // 
            this.labelCodigo.AutoSize = true;
            this.labelCodigo.Location = new System.Drawing.Point(25, 24);
            this.labelCodigo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCodigo.Name = "labelCodigo";
            this.labelCodigo.Size = new System.Drawing.Size(40, 13);
            this.labelCodigo.TabIndex = 14;
            this.labelCodigo.Text = "Codigo";
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.Location = new System.Drawing.Point(172, 17);
            this.textBoxCodigo.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.Size = new System.Drawing.Size(140, 20);
            this.textBoxCodigo.TabIndex = 0;
            // 
            // pbx_1
            // 
            this.pbx_1.Location = new System.Drawing.Point(335, 41);
            this.pbx_1.Name = "pbx_1";
            this.pbx_1.Size = new System.Drawing.Size(152, 151);
            this.pbx_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx_1.TabIndex = 18;
            this.pbx_1.TabStop = false;
            this.pbx_1.DoubleClick += new System.EventHandler(this.pbxDobleClick);
            // 
            // pbx_2
            // 
            this.pbx_2.Location = new System.Drawing.Point(493, 41);
            this.pbx_2.Name = "pbx_2";
            this.pbx_2.Size = new System.Drawing.Size(152, 151);
            this.pbx_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx_2.TabIndex = 22;
            this.pbx_2.TabStop = false;
            this.pbx_2.Visible = false;
            this.pbx_2.DoubleClick += new System.EventHandler(this.pbxDobleClick);
            // 
            // pbx_3
            // 
            this.pbx_3.Location = new System.Drawing.Point(335, 198);
            this.pbx_3.Name = "pbx_3";
            this.pbx_3.Size = new System.Drawing.Size(152, 151);
            this.pbx_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx_3.TabIndex = 23;
            this.pbx_3.TabStop = false;
            this.pbx_3.Visible = false;
            this.pbx_3.DoubleClick += new System.EventHandler(this.pbxDobleClick);
            // 
            // pbx_4
            // 
            this.pbx_4.Location = new System.Drawing.Point(493, 195);
            this.pbx_4.Name = "pbx_4";
            this.pbx_4.Size = new System.Drawing.Size(152, 151);
            this.pbx_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx_4.TabIndex = 24;
            this.pbx_4.TabStop = false;
            this.pbx_4.Visible = false;
            this.pbx_4.DoubleClick += new System.EventHandler(this.pbxDobleClick);
            // 
            // btnAgregarImagen
            // 
            this.btnAgregarImagen.Location = new System.Drawing.Point(335, 12);
            this.btnAgregarImagen.Name = "btnAgregarImagen";
            this.btnAgregarImagen.Size = new System.Drawing.Size(100, 25);
            this.btnAgregarImagen.TabIndex = 25;
            this.btnAgregarImagen.Text = "Agregar Imagen";
            this.btnAgregarImagen.UseVisualStyleBackColor = true;
            this.btnAgregarImagen.Click += new System.EventHandler(this.btnAgregarImagen_Click);
            // 
            // btnModificarImagen
            // 
            this.btnModificarImagen.Location = new System.Drawing.Point(439, 12);
            this.btnModificarImagen.Name = "btnModificarImagen";
            this.btnModificarImagen.Size = new System.Drawing.Size(100, 25);
            this.btnModificarImagen.TabIndex = 26;
            this.btnModificarImagen.Text = "Modificar Imagen";
            this.btnModificarImagen.UseVisualStyleBackColor = true;
            this.btnModificarImagen.Click += new System.EventHandler(this.btnModificarImagen_Click);
            // 
            // btnEliminarImagen
            // 
            this.btnEliminarImagen.Location = new System.Drawing.Point(545, 12);
            this.btnEliminarImagen.Name = "btnEliminarImagen";
            this.btnEliminarImagen.Size = new System.Drawing.Size(100, 25);
            this.btnEliminarImagen.TabIndex = 27;
            this.btnEliminarImagen.Text = "Eliminar imagen";
            this.btnEliminarImagen.UseVisualStyleBackColor = true;
            this.btnEliminarImagen.Click += new System.EventHandler(this.btnEliminarImagen_Click);
            // 
            // FormAltaArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 383);
            this.Controls.Add(this.btnEliminarImagen);
            this.Controls.Add(this.btnModificarImagen);
            this.Controls.Add(this.btnAgregarImagen);
            this.Controls.Add(this.pbx_4);
            this.Controls.Add(this.pbx_3);
            this.Controls.Add(this.pbx_2);
            this.Controls.Add(this.pbx_1);
            this.Controls.Add(this.textBoxCodigo);
            this.Controls.Add(this.labelCodigo);
            this.Controls.Add(this.comboBoxCategoria);
            this.Controls.Add(this.comboBoxMarca);
            this.Controls.Add(this.buttonConfrim);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxPrecio);
            this.Controls.Add(this.textBoxDescrip);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.labelCategoria);
            this.Controls.Add(this.labelMarca);
            this.Controls.Add(this.LabelPrecio);
            this.Controls.Add(this.Descripcion);
            this.Controls.Add(this.LabelNombre);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormAltaArticulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAltaArticulo";
            this.Load += new System.EventHandler(this.FormAltaArticulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelNombre;
        private System.Windows.Forms.Label Descripcion;
        private System.Windows.Forms.Label LabelPrecio;
        private System.Windows.Forms.Label labelMarca;
        private System.Windows.Forms.Label labelCategoria;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxDescrip;
        private System.Windows.Forms.TextBox textBoxPrecio;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonConfrim;
        private System.Windows.Forms.ComboBox comboBoxMarca;
        private System.Windows.Forms.ComboBox comboBoxCategoria;
        private System.Windows.Forms.Label labelCodigo;
        private System.Windows.Forms.TextBox textBoxCodigo;
        private System.Windows.Forms.PictureBox pbx_1;
        private System.Windows.Forms.PictureBox pbx_2;
        private System.Windows.Forms.PictureBox pbx_3;
        private System.Windows.Forms.PictureBox pbx_4;
        private System.Windows.Forms.Button btnAgregarImagen;
        private System.Windows.Forms.Button btnModificarImagen;
        private System.Windows.Forms.Button btnEliminarImagen;
    }
}