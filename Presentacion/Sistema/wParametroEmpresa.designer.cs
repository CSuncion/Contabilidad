namespace Presentacion.Sistema
{
    partial class wParametroEmpresa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txtNumDigAna = new System.Windows.Forms.TextBox();
            this.tcParametros = new System.Windows.Forms.TabControl();
            this.tpCue = new System.Windows.Forms.TabPage();
            this.txtCueIgv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCueAut2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tpIma = new System.Windows.Forms.TabPage();
            this.btnActLogEmp = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.lblRutLog = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.pbImaLog = new System.Windows.Forms.PictureBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.tcParametros.SuspendLayout();
            this.tpCue.SuspendLayout();
            this.tpIma.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImaLog)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(701, 476);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(143, 32);
            this.btnCancelar.TabIndex = 283;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(36, 28);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(142, 18);
            this.label16.TabIndex = 287;
            this.label16.Text = "Numero Dig. Analitica";
            // 
            // txtNumDigAna
            // 
            this.txtNumDigAna.Location = new System.Drawing.Point(225, 22);
            this.txtNumDigAna.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumDigAna.MaxLength = 180;
            this.txtNumDigAna.Name = "txtNumDigAna";
            this.txtNumDigAna.Size = new System.Drawing.Size(44, 26);
            this.txtNumDigAna.TabIndex = 285;
            this.txtNumDigAna.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumDigAna_Validating);
            // 
            // tcParametros
            // 
            this.tcParametros.Controls.Add(this.tpCue);
            this.tcParametros.Controls.Add(this.tpIma);
            this.tcParametros.Location = new System.Drawing.Point(31, 42);
            this.tcParametros.Margin = new System.Windows.Forms.Padding(4);
            this.tcParametros.Name = "tcParametros";
            this.tcParametros.SelectedIndex = 0;
            this.tcParametros.Size = new System.Drawing.Size(819, 426);
            this.tcParametros.TabIndex = 290;
            // 
            // tpCue
            // 
            this.tpCue.Controls.Add(this.txtCueIgv);
            this.tpCue.Controls.Add(this.label1);
            this.tpCue.Controls.Add(this.txtCueAut2);
            this.tpCue.Controls.Add(this.label13);
            this.tpCue.Controls.Add(this.txtNumDigAna);
            this.tpCue.Controls.Add(this.label16);
            this.tpCue.Location = new System.Drawing.Point(4, 27);
            this.tpCue.Margin = new System.Windows.Forms.Padding(4);
            this.tpCue.Name = "tpCue";
            this.tpCue.Padding = new System.Windows.Forms.Padding(4);
            this.tpCue.Size = new System.Drawing.Size(811, 395);
            this.tpCue.TabIndex = 0;
            this.tpCue.Text = "Cuentas";
            this.tpCue.UseVisualStyleBackColor = true;
            // 
            // txtCueIgv
            // 
            this.txtCueIgv.Location = new System.Drawing.Point(225, 92);
            this.txtCueIgv.Margin = new System.Windows.Forms.Padding(4);
            this.txtCueIgv.MaxLength = 180;
            this.txtCueIgv.Name = "txtCueIgv";
            this.txtCueIgv.Size = new System.Drawing.Size(109, 26);
            this.txtCueIgv.TabIndex = 292;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 18);
            this.label1.TabIndex = 293;
            this.label1.Text = "Cuenta I.G.V";
            // 
            // txtCueAut2
            // 
            this.txtCueAut2.Location = new System.Drawing.Point(225, 58);
            this.txtCueAut2.Margin = new System.Windows.Forms.Padding(4);
            this.txtCueAut2.MaxLength = 180;
            this.txtCueAut2.Name = "txtCueAut2";
            this.txtCueAut2.Size = new System.Drawing.Size(109, 26);
            this.txtCueAut2.TabIndex = 290;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(36, 64);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(135, 18);
            this.label13.TabIndex = 291;
            this.label13.Text = "Cuenta Automatica 2";
            // 
            // tpIma
            // 
            this.tpIma.Controls.Add(this.btnActLogEmp);
            this.tpIma.Controls.Add(this.label22);
            this.tpIma.Controls.Add(this.lblRutLog);
            this.tpIma.Controls.Add(this.btnAgregar);
            this.tpIma.Controls.Add(this.pbImaLog);
            this.tpIma.Location = new System.Drawing.Point(4, 27);
            this.tpIma.Margin = new System.Windows.Forms.Padding(4);
            this.tpIma.Name = "tpIma";
            this.tpIma.Padding = new System.Windows.Forms.Padding(4);
            this.tpIma.Size = new System.Drawing.Size(811, 395);
            this.tpIma.TabIndex = 1;
            this.tpIma.Text = "Imagenes";
            this.tpIma.UseVisualStyleBackColor = true;
            // 
            // btnActLogEmp
            // 
            this.btnActLogEmp.Image = global::Presentacion.Properties.Resources.arrow_refresh;
            this.btnActLogEmp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnActLogEmp.Location = new System.Drawing.Point(211, 135);
            this.btnActLogEmp.Margin = new System.Windows.Forms.Padding(4);
            this.btnActLogEmp.Name = "btnActLogEmp";
            this.btnActLogEmp.Size = new System.Drawing.Size(41, 31);
            this.btnActLogEmp.TabIndex = 290;
            this.btnActLogEmp.UseVisualStyleBackColor = true;
            this.btnActLogEmp.Click += new System.EventHandler(this.btnActLogEmp_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(211, 28);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(175, 64);
            this.label22.TabIndex = 157;
            this.label22.Text = "Aqui se muestra la imagen\r\nque se visualizara como\r\nlogo en los reportes\r\n\r\n";
            // 
            // lblRutLog
            // 
            this.lblRutLog.AutoSize = true;
            this.lblRutLog.Location = new System.Drawing.Point(211, 108);
            this.lblRutLog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRutLog.Name = "lblRutLog";
            this.lblRutLog.Size = new System.Drawing.Size(23, 18);
            this.lblRutLog.TabIndex = 156;
            this.lblRutLog.Text = "---";
            this.lblRutLog.Visible = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(36, 134);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(167, 32);
            this.btnAgregar.TabIndex = 155;
            this.btnAgregar.Text = "Cambiar Imagen";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // pbImaLog
            // 
            this.pbImaLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbImaLog.Location = new System.Drawing.Point(36, 28);
            this.pbImaLog.Margin = new System.Windows.Forms.Padding(4);
            this.pbImaLog.Name = "pbImaLog";
            this.pbImaLog.Size = new System.Drawing.Size(165, 97);
            this.pbImaLog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImaLog.TabIndex = 154;
            this.pbImaLog.TabStop = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(544, 476);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(149, 32);
            this.btnAceptar.TabIndex = 293;
            this.btnAceptar.Tag = "3";
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // wParametroEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(877, 532);
            this.ControlBox = false;
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.tcParametros);
            this.Controls.Add(this.btnCancelar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wParametroEmpresa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parametros";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wParametroEmpresa_FormClosing);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.tcParametros, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.tcParametros.ResumeLayout(false);
            this.tpCue.ResumeLayout(false);
            this.tpCue.PerformLayout();
            this.tpIma.ResumeLayout(false);
            this.tpIma.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImaLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtNumDigAna;
        private System.Windows.Forms.TabControl tcParametros;
        private System.Windows.Forms.TabPage tpCue;
        private System.Windows.Forms.TabPage tpIma;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblRutLog;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.PictureBox pbImaLog;
        private System.Windows.Forms.Button btnActLogEmp;
        private System.Windows.Forms.TextBox txtCueAut2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCueIgv;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button btnAceptar;
    }
}