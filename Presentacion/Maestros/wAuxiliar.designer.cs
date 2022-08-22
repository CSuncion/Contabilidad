﻿namespace Presentacion.Maestros
{
    partial class wAuxiliar
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
            this.tsbCopiar = new System.Windows.Forms.ToolStripButton();
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
            this.IteCopiarAdicionar = new System.Windows.Forms.ToolStripMenuItem();
            this.IteCopiarEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.IteImportar = new System.Windows.Forms.ToolStripMenuItem();
            this.IteImportarAdicionar = new System.Windows.Forms.ToolStripMenuItem();
            this.IteImportarEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.DgvAux = new System.Windows.Forms.DataGridView();
            this.ItePlantillaImportacion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsPrincipal.SuspendLayout();
            this.sst1.SuspendLayout();
            this.tsSecundario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAux)).BeginInit();
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
            this.tsbCopiar,
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
            // tsbCopiar
            // 
            this.tsbCopiar.Image = global::Presentacion.Properties.Resources._16__Edit_3_;
            this.tsbCopiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopiar.Name = "tsbCopiar";
            this.tsbCopiar.Size = new System.Drawing.Size(46, 43);
            this.tsbCopiar.Text = "Copiar";
            this.tsbCopiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCopiar.Click += new System.EventHandler(this.tsbCopiar_Click);
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
            this.IteCopiarAdicionar,
            this.IteCopiarEliminar});
            this.IteCopiar.Name = "IteCopiar";
            this.IteCopiar.Size = new System.Drawing.Size(152, 22);
            this.IteCopiar.Text = "Copiar";
            // 
            // IteCopiarAdicionar
            // 
            this.IteCopiarAdicionar.Name = "IteCopiarAdicionar";
            this.IteCopiarAdicionar.Size = new System.Drawing.Size(125, 22);
            this.IteCopiarAdicionar.Text = "Adicionar";
            this.IteCopiarAdicionar.Click += new System.EventHandler(this.IteCopiarAdicionar_Click);
            // 
            // IteCopiarEliminar
            // 
            this.IteCopiarEliminar.Name = "IteCopiarEliminar";
            this.IteCopiarEliminar.Size = new System.Drawing.Size(125, 22);
            this.IteCopiarEliminar.Text = "Eliminar";
            this.IteCopiarEliminar.Click += new System.EventHandler(this.IteCopiarEliminar_Click);
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
            // DgvAux
            // 
            this.DgvAux.BackgroundColor = System.Drawing.Color.White;
            this.DgvAux.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvAux.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAux.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvAux.GridColor = System.Drawing.Color.Silver;
            this.DgvAux.Location = new System.Drawing.Point(6, 94);
            this.DgvAux.Name = "DgvAux";
            this.DgvAux.Size = new System.Drawing.Size(1039, 412);
            this.DgvAux.TabIndex = 95;
            this.DgvAux.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAux_CellEnter);
            this.DgvAux.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvAux_CellMouseDoubleClick);
            this.DgvAux.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvAux_ColumnHeaderMouseClick);
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
            // wAuxiliar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(1051, 534);
            this.Controls.Add(this.DgvAux);
            this.Controls.Add(this.tsSecundario);
            this.Controls.Add(this.sst1);
            this.Controls.Add(this.tsPrincipal);
            this.Name = "wAuxiliar";
            this.Text = "Auxiliares";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wAuxiliar_FormClosing);
            this.Controls.SetChildIndex(this.tsPrincipal, 0);
            this.Controls.SetChildIndex(this.sst1, 0);
            this.Controls.SetChildIndex(this.tsSecundario, 0);
            this.Controls.SetChildIndex(this.DgvAux, 0);
            this.tsPrincipal.ResumeLayout(false);
            this.tsPrincipal.PerformLayout();
            this.sst1.ResumeLayout(false);
            this.sst1.PerformLayout();
            this.tsSecundario.ResumeLayout(false);
            this.tsSecundario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAux)).EndInit();
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
        private System.Windows.Forms.DataGridView DgvAux;
        private System.Windows.Forms.ToolStripTextBox tstBuscar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tsbAdicionar;
        private System.Windows.Forms.ToolStripButton tsbModificar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.ToolStripButton tsbVisualizar;
        private System.Windows.Forms.ToolStripButton tsbSalir;
        private System.Windows.Forms.ToolStripDropDownButton IteMasivos;
        internal System.Windows.Forms.ToolStripMenuItem IteCopiar;
        private System.Windows.Forms.ToolStripMenuItem IteCopiarAdicionar;
        private System.Windows.Forms.ToolStripMenuItem IteCopiarEliminar;
        private System.Windows.Forms.ToolStripMenuItem IteImportar;
        private System.Windows.Forms.ToolStripMenuItem IteImportarAdicionar;
        private System.Windows.Forms.ToolStripMenuItem IteImportarEliminar;
        private System.Windows.Forms.ToolStripButton tsbCopiar;
        private System.Windows.Forms.ToolStripMenuItem ItePlantillaImportacion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}
