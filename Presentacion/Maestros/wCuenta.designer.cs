namespace Presentacion.Maestros
{
    partial class wCuenta
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tsPrincipal = new System.Windows.Forms.ToolStrip();
            this.tsbAdicionar = new System.Windows.Forms.ToolStripButton();
            this.tsbModificar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tsbVisualizar = new System.Windows.Forms.ToolStripButton();
            this.tsbSalir = new System.Windows.Forms.ToolStripButton();
            this.sst1 = new System.Windows.Forms.StatusStrip();
            this.tssEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsSecundario = new System.Windows.Forms.ToolStrip();
            this.tsbPrimero = new System.Windows.Forms.ToolStripButton();
            this.tsbAnterior = new System.Windows.Forms.ToolStripButton();
            this.tsbSiguiente = new System.Windows.Forms.ToolStripButton();
            this.tsbUltimo = new System.Windows.Forms.ToolStripButton();
            this.tsbActualizarTabla = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tstBuscar = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.IteMasivos = new System.Windows.Forms.ToolStripDropDownButton();
            this.IteCopiar = new System.Windows.Forms.ToolStripMenuItem();
            this.IteCopiarPcge = new System.Windows.Forms.ToolStripMenuItem();
            this.IteCopiarPcgeAdicionar = new System.Windows.Forms.ToolStripMenuItem();
            this.IteCopiarPcgeEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.IteCopiarEmpresa = new System.Windows.Forms.ToolStripMenuItem();
            this.IteCopiarEmpresaAdicionar = new System.Windows.Forms.ToolStripMenuItem();
            this.IteCopiarEmpresaEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.IteImportar = new System.Windows.Forms.ToolStripMenuItem();
            this.ItePlantillaImportacion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.IteImportarAdicionar = new System.Windows.Forms.ToolStripMenuItem();
            this.IteImportarEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.DgvCue = new System.Windows.Forms.DataGridView();
            this.tsPrincipal.SuspendLayout();
            this.sst1.SuspendLayout();
            this.tsSecundario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCue)).BeginInit();
            this.SuspendLayout();
            // 
            // tsPrincipal
            // 
            this.tsPrincipal.AutoSize = false;
            this.tsPrincipal.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsPrincipal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdicionar,
            this.tsbModificar,
            this.tsbEliminar,
            this.tsbVisualizar,
            this.tsbSalir});
            this.tsPrincipal.Location = new System.Drawing.Point(6, 23);
            this.tsPrincipal.Name = "tsPrincipal";
            this.tsPrincipal.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsPrincipal.Size = new System.Drawing.Size(1039, 46);
            this.tsPrincipal.Stretch = true;
            this.tsPrincipal.TabIndex = 53;
            this.tsPrincipal.Text = "toolStrip1";
            // 
            // tsbAdicionar
            // 
            this.tsbAdicionar.Image = global::Presentacion.Properties.Resources._16__Plus_;
            this.tsbAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdicionar.Name = "tsbAdicionar";
            this.tsbAdicionar.Size = new System.Drawing.Size(63, 43);
            this.tsbAdicionar.Text = "Adicionar";
            this.tsbAdicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAdicionar.Click += new System.EventHandler(this.tsbAdicionar_Click);
            // 
            // tsbModificar
            // 
            this.tsbModificar.Image = global::Presentacion.Properties.Resources._16__Pencil_tool_;
            this.tsbModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbModificar.Name = "tsbModificar";
            this.tsbModificar.Size = new System.Drawing.Size(61, 43);
            this.tsbModificar.Text = "Modificar";
            this.tsbModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbModificar.Click += new System.EventHandler(this.tsbModificar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.Image = global::Presentacion.Properties.Resources._16__Refuse_;
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(57, 43);
            this.tsbEliminar.Text = "Eliminar";
            this.tsbEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // tsbVisualizar
            // 
            this.tsbVisualizar.Image = global::Presentacion.Properties.Resources.Game_11_32x32_32;
            this.tsbVisualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbVisualizar.Name = "tsbVisualizar";
            this.tsbVisualizar.Size = new System.Drawing.Size(66, 43);
            this.tsbVisualizar.Text = "Visualizar";
            this.tsbVisualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbVisualizar.Click += new System.EventHandler(this.tsbVisualizar_Click);
            // 
            // tsbSalir
            // 
            this.tsbSalir.Image = global::Presentacion.Properties.Resources.gnome_home;
            this.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalir.Name = "tsbSalir";
            this.tsbSalir.Size = new System.Drawing.Size(36, 43);
            this.tsbSalir.Text = "Salir";
            this.tsbSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSalir.Click += new System.EventHandler(this.tsbSalir_Click);
            // 
            // sst1
            // 
            this.sst1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssEstado});
            this.sst1.Location = new System.Drawing.Point(6, 506);
            this.sst1.Name = "sst1";
            this.sst1.Size = new System.Drawing.Size(1039, 22);
            this.sst1.TabIndex = 54;
            this.sst1.Text = "statusStrip1";
            // 
            // tssEstado
            // 
            this.tssEstado.BackColor = System.Drawing.SystemColors.Control;
            this.tssEstado.Name = "tssEstado";
            this.tssEstado.Size = new System.Drawing.Size(10, 17);
            this.tssEstado.Text = ".";
            // 
            // tsSecundario
            // 
            this.tsSecundario.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsSecundario.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPrimero,
            this.tsbAnterior,
            this.tsbSiguiente,
            this.tsbUltimo,
            this.tsbActualizarTabla,
            this.toolStripSeparator1,
            this.tstBuscar,
            this.toolStripLabel1,
            this.IteMasivos});
            this.tsSecundario.Location = new System.Drawing.Point(6, 69);
            this.tsSecundario.Name = "tsSecundario";
            this.tsSecundario.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsSecundario.Size = new System.Drawing.Size(1039, 25);
            this.tsSecundario.TabIndex = 94;
            this.tsSecundario.Text = "ToolStrip2";
            // 
            // tsbPrimero
            // 
            this.tsbPrimero.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrimero.Image = global::Presentacion.Properties.Resources._18;
            this.tsbPrimero.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrimero.Name = "tsbPrimero";
            this.tsbPrimero.Size = new System.Drawing.Size(23, 22);
            this.tsbPrimero.Click += new System.EventHandler(this.tsbPrimero_Click);
            // 
            // tsbAnterior
            // 
            this.tsbAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAnterior.Image = global::Presentacion.Properties.Resources._16;
            this.tsbAnterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAnterior.Name = "tsbAnterior";
            this.tsbAnterior.Size = new System.Drawing.Size(23, 22);
            this.tsbAnterior.Click += new System.EventHandler(this.tsbAnterior_Click);
            // 
            // tsbSiguiente
            // 
            this.tsbSiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSiguiente.Image = global::Presentacion.Properties.Resources._17;
            this.tsbSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSiguiente.Name = "tsbSiguiente";
            this.tsbSiguiente.Size = new System.Drawing.Size(23, 22);
            this.tsbSiguiente.Click += new System.EventHandler(this.tsbSiguiente_Click);
            // 
            // tsbUltimo
            // 
            this.tsbUltimo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUltimo.Image = global::Presentacion.Properties.Resources._19;
            this.tsbUltimo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUltimo.Name = "tsbUltimo";
            this.tsbUltimo.Size = new System.Drawing.Size(23, 22);
            this.tsbUltimo.Click += new System.EventHandler(this.tsbUltimo_Click);
            // 
            // tsbActualizarTabla
            // 
            this.tsbActualizarTabla.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbActualizarTabla.Image = global::Presentacion.Properties.Resources.arrow_refresh;
            this.tsbActualizarTabla.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbActualizarTabla.Name = "tsbActualizarTabla";
            this.tsbActualizarTabla.Size = new System.Drawing.Size(23, 22);
            this.tsbActualizarTabla.Text = "Actualiza Grilla";
            this.tsbActualizarTabla.Click += new System.EventHandler(this.tsbActualizarTabla_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tstBuscar
            // 
            this.tstBuscar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tstBuscar.Name = "tstBuscar";
            this.tstBuscar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tstBuscar.Size = new System.Drawing.Size(150, 25);
            this.tstBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tstBuscar_KeyUp);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel1.Image = global::Presentacion.Properties.Resources._16__Filter_;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(16, 22);
            // 
            // IteMasivos
            // 
            this.IteMasivos.AutoToolTip = false;
            this.IteMasivos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IteCopiar,
            this.IteImportar});
            this.IteMasivos.Image = global::Presentacion.Properties.Resources._16__Card_file_;
            this.IteMasivos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.IteMasivos.Name = "IteMasivos";
            this.IteMasivos.Size = new System.Drawing.Size(79, 22);
            this.IteMasivos.Text = "Masivos";
            // 
            // IteCopiar
            // 
            this.IteCopiar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IteCopiarPcge,
            this.IteCopiarEmpresa});
            this.IteCopiar.Name = "IteCopiar";
            this.IteCopiar.Size = new System.Drawing.Size(152, 22);
            this.IteCopiar.Text = "Copiar";
            // 
            // IteCopiarPcge
            // 
            this.IteCopiarPcge.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IteCopiarPcgeAdicionar,
            this.IteCopiarPcgeEliminar});
            this.IteCopiarPcge.Name = "IteCopiarPcge";
            this.IteCopiarPcge.Size = new System.Drawing.Size(152, 22);
            this.IteCopiarPcge.Text = "Pcge";
            // 
            // IteCopiarPcgeAdicionar
            // 
            this.IteCopiarPcgeAdicionar.Name = "IteCopiarPcgeAdicionar";
            this.IteCopiarPcgeAdicionar.Size = new System.Drawing.Size(125, 22);
            this.IteCopiarPcgeAdicionar.Text = "Adicionar";
            this.IteCopiarPcgeAdicionar.Click += new System.EventHandler(this.IteCopiarPcgeAdicionar_Click);
            // 
            // IteCopiarPcgeEliminar
            // 
            this.IteCopiarPcgeEliminar.Name = "IteCopiarPcgeEliminar";
            this.IteCopiarPcgeEliminar.Size = new System.Drawing.Size(125, 22);
            this.IteCopiarPcgeEliminar.Text = "Eliminar";
            this.IteCopiarPcgeEliminar.Click += new System.EventHandler(this.IteCopiarPcgeEliminar_Click);
            // 
            // IteCopiarEmpresa
            // 
            this.IteCopiarEmpresa.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IteCopiarEmpresaAdicionar,
            this.IteCopiarEmpresaEliminar});
            this.IteCopiarEmpresa.Name = "IteCopiarEmpresa";
            this.IteCopiarEmpresa.Size = new System.Drawing.Size(152, 22);
            this.IteCopiarEmpresa.Text = "Otra Empresa";
            // 
            // IteCopiarEmpresaAdicionar
            // 
            this.IteCopiarEmpresaAdicionar.Name = "IteCopiarEmpresaAdicionar";
            this.IteCopiarEmpresaAdicionar.Size = new System.Drawing.Size(152, 22);
            this.IteCopiarEmpresaAdicionar.Text = "Adicionar";
            this.IteCopiarEmpresaAdicionar.Click += new System.EventHandler(this.IteCopiarEmpresaAdicionar_Click);
            // 
            // IteCopiarEmpresaEliminar
            // 
            this.IteCopiarEmpresaEliminar.Name = "IteCopiarEmpresaEliminar";
            this.IteCopiarEmpresaEliminar.Size = new System.Drawing.Size(152, 22);
            this.IteCopiarEmpresaEliminar.Text = "Eliminar";
            this.IteCopiarEmpresaEliminar.Click += new System.EventHandler(this.IteCopiarEmpresaEliminar_Click);
            // 
            // IteImportar
            // 
            this.IteImportar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItePlantillaImportacion,
            this.toolStripSeparator2,
            this.IteImportarAdicionar,
            this.IteImportarEliminar});
            this.IteImportar.Name = "IteImportar";
            this.IteImportar.Size = new System.Drawing.Size(152, 22);
            this.IteImportar.Text = "Importar";
            // 
            // ItePlantillaImportacion
            // 
            this.ItePlantillaImportacion.Name = "ItePlantillaImportacion";
            this.ItePlantillaImportacion.Size = new System.Drawing.Size(184, 22);
            this.ItePlantillaImportacion.Text = "Plantilla Importacion";
            this.ItePlantillaImportacion.Click += new System.EventHandler(this.ItePlantillaImportacion_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            // 
            // IteImportarAdicionar
            // 
            this.IteImportarAdicionar.Name = "IteImportarAdicionar";
            this.IteImportarAdicionar.Size = new System.Drawing.Size(184, 22);
            this.IteImportarAdicionar.Text = "Adicionar";
            this.IteImportarAdicionar.Click += new System.EventHandler(this.IteImportarAdicionar_Click);
            // 
            // IteImportarEliminar
            // 
            this.IteImportarEliminar.Name = "IteImportarEliminar";
            this.IteImportarEliminar.Size = new System.Drawing.Size(184, 22);
            this.IteImportarEliminar.Text = "Eliminar";
            this.IteImportarEliminar.Click += new System.EventHandler(this.IteImportarEliminar_Click);
            // 
            // DgvCue
            // 
            this.DgvCue.BackgroundColor = System.Drawing.Color.White;
            this.DgvCue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvCue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvCue.GridColor = System.Drawing.Color.Silver;
            this.DgvCue.Location = new System.Drawing.Point(6, 94);
            this.DgvCue.Name = "DgvCue";
            this.DgvCue.Size = new System.Drawing.Size(1039, 412);
            this.DgvCue.TabIndex = 95;
            this.DgvCue.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCue_CellEnter);
            this.DgvCue.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvCue_CellMouseDoubleClick);
            this.DgvCue.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvCue_ColumnHeaderMouseClick);
            // 
            // wCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(1051, 534);
            this.Controls.Add(this.DgvCue);
            this.Controls.Add(this.tsSecundario);
            this.Controls.Add(this.sst1);
            this.Controls.Add(this.tsPrincipal);
            this.Name = "wCuenta";
            this.Text = "Cuentas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wCuenta_FormClosing);
            this.Controls.SetChildIndex(this.tsPrincipal, 0);
            this.Controls.SetChildIndex(this.sst1, 0);
            this.Controls.SetChildIndex(this.tsSecundario, 0);
            this.Controls.SetChildIndex(this.DgvCue, 0);
            this.tsPrincipal.ResumeLayout(false);
            this.tsPrincipal.PerformLayout();
            this.sst1.ResumeLayout(false);
            this.sst1.PerformLayout();
            this.tsSecundario.ResumeLayout(false);
            this.tsSecundario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsPrincipal;
        internal System.Windows.Forms.ToolStrip tsSecundario;
        internal System.Windows.Forms.ToolStripButton tsbPrimero;
        internal System.Windows.Forms.ToolStripButton tsbAnterior;
        internal System.Windows.Forms.ToolStripButton tsbSiguiente;
        internal System.Windows.Forms.ToolStripButton tsbUltimo;
        internal System.Windows.Forms.ToolStripButton tsbActualizarTabla;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel tssEstado;
        internal System.Windows.Forms.StatusStrip sst1;
        private System.Windows.Forms.DataGridView DgvCue;
        private System.Windows.Forms.ToolStripTextBox tstBuscar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tsbAdicionar;
        private System.Windows.Forms.ToolStripButton tsbModificar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.ToolStripButton tsbVisualizar;
        private System.Windows.Forms.ToolStripButton tsbSalir;
        private System.Windows.Forms.ToolStripDropDownButton IteMasivos;
        internal System.Windows.Forms.ToolStripMenuItem IteCopiar;
        private System.Windows.Forms.ToolStripMenuItem IteCopiarPcge;
        private System.Windows.Forms.ToolStripMenuItem IteCopiarEmpresa;
        private System.Windows.Forms.ToolStripMenuItem IteImportar;
        private System.Windows.Forms.ToolStripMenuItem IteImportarAdicionar;
        private System.Windows.Forms.ToolStripMenuItem IteImportarEliminar;
        private System.Windows.Forms.ToolStripMenuItem ItePlantillaImportacion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem IteCopiarPcgeAdicionar;
        private System.Windows.Forms.ToolStripMenuItem IteCopiarPcgeEliminar;
        private System.Windows.Forms.ToolStripMenuItem IteCopiarEmpresaAdicionar;
        private System.Windows.Forms.ToolStripMenuItem IteCopiarEmpresaEliminar;
    }
}
