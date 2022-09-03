namespace Presentacion.Procesos
{
    partial class wEditCajaBanco
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
            this.txtPerCajBco = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCodOri = new System.Windows.Forms.TextBox();
            this.txtDesOri = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodFile = new System.Windows.Forms.TextBox();
            this.txtDesFile = new System.Windows.Forms.TextBox();
            this.txtCorrRegContab = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.dtpFecCorrRegContab = new System.Windows.Forms.DateTimePicker();
            this.cmbMon = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTipCam = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtCodMonSyD = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDistSoles = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodModPag = new System.Windows.Forms.TextBox();
            this.txtDesModPag = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodTD = new System.Windows.Forms.TextBox();
            this.txtDesTD = new System.Windows.Forms.TextBox();
            this.txtNumRef = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCodCtaBco = new System.Windows.Forms.TextBox();
            this.txtDesCtaBco = new System.Windows.Forms.TextBox();
            this.txtNroCtaBco = new System.Windows.Forms.TextBox();
            this.txtGirPag = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtConcep = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dgvCajBanDet = new System.Windows.Forms.DataGridView();
            this.btnQuitarCtaBco = new System.Windows.Forms.Button();
            this.btnAgregarCtaBco = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblDebTotSol = new System.Windows.Forms.Label();
            this.lblDebTotDol = new System.Windows.Forms.Label();
            this.lblHabTotSol = new System.Windows.Forms.Label();
            this.lblHabTotDol = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajBanDet)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPerCajBco
            // 
            this.txtPerCajBco.Location = new System.Drawing.Point(140, 43);
            this.txtPerCajBco.MaxLength = 4;
            this.txtPerCajBco.Name = "txtPerCajBco";
            this.txtPerCajBco.ReadOnly = true;
            this.txtPerCajBco.Size = new System.Drawing.Size(127, 22);
            this.txtPerCajBco.TabIndex = 379;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(27, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 14);
            this.label14.TabIndex = 378;
            this.label14.Text = "Periodo";
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.DarkGray;
            this.label24.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(27, 77);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(812, 14);
            this.label24.TabIndex = 387;
            this.label24.Text = "Datos Generales";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(27, 104);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 14);
            this.label18.TabIndex = 424;
            this.label18.Text = "Origen :";
            // 
            // txtCodOri
            // 
            this.txtCodOri.Location = new System.Drawing.Point(142, 101);
            this.txtCodOri.Name = "txtCodOri";
            this.txtCodOri.Size = new System.Drawing.Size(33, 22);
            this.txtCodOri.TabIndex = 422;
            this.txtCodOri.DoubleClick += new System.EventHandler(this.txtCodOri_DoubleClick);
            this.txtCodOri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodOri_KeyDown);
            this.txtCodOri.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodOri_Validating);
            // 
            // txtDesOri
            // 
            this.txtDesOri.Location = new System.Drawing.Point(176, 101);
            this.txtDesOri.Name = "txtDesOri";
            this.txtDesOri.ReadOnly = true;
            this.txtDesOri.Size = new System.Drawing.Size(240, 22);
            this.txtDesOri.TabIndex = 423;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(422, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 14);
            this.label1.TabIndex = 427;
            this.label1.Text = "File :";
            // 
            // txtCodFile
            // 
            this.txtCodFile.Location = new System.Drawing.Point(526, 101);
            this.txtCodFile.Name = "txtCodFile";
            this.txtCodFile.Size = new System.Drawing.Size(44, 22);
            this.txtCodFile.TabIndex = 425;
            this.txtCodFile.DoubleClick += new System.EventHandler(this.txtCodFile_DoubleClick);
            this.txtCodFile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodFile_KeyDown);
            this.txtCodFile.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodFile_Validating);
            // 
            // txtDesFile
            // 
            this.txtDesFile.Location = new System.Drawing.Point(571, 101);
            this.txtDesFile.Name = "txtDesFile";
            this.txtDesFile.ReadOnly = true;
            this.txtDesFile.Size = new System.Drawing.Size(256, 22);
            this.txtDesFile.TabIndex = 426;
            // 
            // txtCorrRegContab
            // 
            this.txtCorrRegContab.Location = new System.Drawing.Point(142, 129);
            this.txtCorrRegContab.MaxLength = 4;
            this.txtCorrRegContab.Name = "txtCorrRegContab";
            this.txtCorrRegContab.ReadOnly = true;
            this.txtCorrRegContab.Size = new System.Drawing.Size(274, 22);
            this.txtCorrRegContab.TabIndex = 429;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 14);
            this.label2.TabIndex = 428;
            this.label2.Text = "Número Voucher :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(422, 133);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(45, 14);
            this.label19.TabIndex = 431;
            this.label19.Text = "Fecha :";
            // 
            // dtpFecCorrRegContab
            // 
            this.dtpFecCorrRegContab.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecCorrRegContab.Location = new System.Drawing.Point(526, 129);
            this.dtpFecCorrRegContab.Name = "dtpFecCorrRegContab";
            this.dtpFecCorrRegContab.Size = new System.Drawing.Size(115, 22);
            this.dtpFecCorrRegContab.TabIndex = 430;
            this.dtpFecCorrRegContab.Validated += new System.EventHandler(this.dtpFecCorrRegContab_Validated);
            // 
            // cmbMon
            // 
            this.cmbMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMon.Location = new System.Drawing.Point(142, 157);
            this.cmbMon.Name = "cmbMon";
            this.cmbMon.Size = new System.Drawing.Size(93, 22);
            this.cmbMon.TabIndex = 441;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 161);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 14);
            this.label12.TabIndex = 440;
            this.label12.Text = "Moneda :";
            // 
            // txtTipCam
            // 
            this.txtTipCam.Location = new System.Drawing.Point(323, 157);
            this.txtTipCam.MaxLength = 10;
            this.txtTipCam.Name = "txtTipCam";
            this.txtTipCam.Size = new System.Drawing.Size(76, 22);
            this.txtTipCam.TabIndex = 451;
            this.txtTipCam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(287, 160);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(30, 14);
            this.label20.TabIndex = 450;
            this.label20.Text = "T.C. :";
            // 
            // txtCodMonSyD
            // 
            this.txtCodMonSyD.BackColor = System.Drawing.SystemColors.Control;
            this.txtCodMonSyD.Location = new System.Drawing.Point(405, 157);
            this.txtCodMonSyD.Name = "txtCodMonSyD";
            this.txtCodMonSyD.Size = new System.Drawing.Size(11, 22);
            this.txtCodMonSyD.TabIndex = 449;
            this.txtCodMonSyD.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(422, 164);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 14);
            this.label11.TabIndex = 453;
            this.label11.Text = "Importe :";
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(526, 157);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(85, 22);
            this.txtImporte.TabIndex = 452;
            this.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporte.Validated += new System.EventHandler(this.txtImporte_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(633, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 14);
            this.label3.TabIndex = 454;
            this.label3.Text = "Dist Soles :";
            // 
            // txtDistSoles
            // 
            this.txtDistSoles.Location = new System.Drawing.Point(712, 158);
            this.txtDistSoles.Name = "txtDistSoles";
            this.txtDistSoles.ReadOnly = true;
            this.txtDistSoles.Size = new System.Drawing.Size(115, 22);
            this.txtDistSoles.TabIndex = 455;
            this.txtDistSoles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 14);
            this.label4.TabIndex = 458;
            this.label4.Text = "Modo Pago :";
            // 
            // txtCodModPag
            // 
            this.txtCodModPag.Location = new System.Drawing.Point(142, 185);
            this.txtCodModPag.Name = "txtCodModPag";
            this.txtCodModPag.Size = new System.Drawing.Size(33, 22);
            this.txtCodModPag.TabIndex = 456;
            this.txtCodModPag.DoubleClick += new System.EventHandler(this.txtCodModPag_DoubleClick);
            this.txtCodModPag.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodModPag_KeyDown);
            this.txtCodModPag.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodModPag_Validating);
            // 
            // txtDesModPag
            // 
            this.txtDesModPag.Location = new System.Drawing.Point(176, 185);
            this.txtDesModPag.Name = "txtDesModPag";
            this.txtDesModPag.ReadOnly = true;
            this.txtDesModPag.Size = new System.Drawing.Size(240, 22);
            this.txtDesModPag.TabIndex = 457;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(422, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 14);
            this.label6.TabIndex = 461;
            this.label6.Text = "TD :";
            // 
            // txtCodTD
            // 
            this.txtCodTD.Location = new System.Drawing.Point(526, 185);
            this.txtCodTD.Name = "txtCodTD";
            this.txtCodTD.Size = new System.Drawing.Size(44, 22);
            this.txtCodTD.TabIndex = 459;
            this.txtCodTD.DoubleClick += new System.EventHandler(this.txtCodTD_DoubleClick);
            this.txtCodTD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodTD_KeyDown);
            this.txtCodTD.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodTD_Validating);
            // 
            // txtDesTD
            // 
            this.txtDesTD.Location = new System.Drawing.Point(571, 185);
            this.txtDesTD.Name = "txtDesTD";
            this.txtDesTD.ReadOnly = true;
            this.txtDesTD.Size = new System.Drawing.Size(256, 22);
            this.txtDesTD.TabIndex = 460;
            // 
            // txtNumRef
            // 
            this.txtNumRef.Location = new System.Drawing.Point(142, 213);
            this.txtNumRef.MaxLength = 4;
            this.txtNumRef.Name = "txtNumRef";
            this.txtNumRef.ReadOnly = true;
            this.txtNumRef.Size = new System.Drawing.Size(274, 22);
            this.txtNumRef.TabIndex = 463;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 14);
            this.label7.TabIndex = 462;
            this.label7.Text = "Número  :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(422, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 14);
            this.label8.TabIndex = 466;
            this.label8.Text = "Cta. Bco. :";
            // 
            // txtCodCtaBco
            // 
            this.txtCodCtaBco.Location = new System.Drawing.Point(526, 213);
            this.txtCodCtaBco.Name = "txtCodCtaBco";
            this.txtCodCtaBco.Size = new System.Drawing.Size(44, 22);
            this.txtCodCtaBco.TabIndex = 464;
            this.txtCodCtaBco.DoubleClick += new System.EventHandler(this.txtCodCtaBco_DoubleClick);
            this.txtCodCtaBco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodCtaBco_KeyDown);
            this.txtCodCtaBco.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodCtaBco_Validating);
            // 
            // txtDesCtaBco
            // 
            this.txtDesCtaBco.Location = new System.Drawing.Point(571, 213);
            this.txtDesCtaBco.Name = "txtDesCtaBco";
            this.txtDesCtaBco.ReadOnly = true;
            this.txtDesCtaBco.Size = new System.Drawing.Size(130, 22);
            this.txtDesCtaBco.TabIndex = 465;
            // 
            // txtNroCtaBco
            // 
            this.txtNroCtaBco.Location = new System.Drawing.Point(707, 214);
            this.txtNroCtaBco.Name = "txtNroCtaBco";
            this.txtNroCtaBco.ReadOnly = true;
            this.txtNroCtaBco.Size = new System.Drawing.Size(120, 22);
            this.txtNroCtaBco.TabIndex = 467;
            // 
            // txtGirPag
            // 
            this.txtGirPag.Location = new System.Drawing.Point(142, 242);
            this.txtGirPag.MaxLength = 4;
            this.txtGirPag.Name = "txtGirPag";
            this.txtGirPag.Size = new System.Drawing.Size(687, 22);
            this.txtGirPag.TabIndex = 472;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(27, 246);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 14);
            this.label13.TabIndex = 471;
            this.label13.Text = "Girado / Pagado :";
            // 
            // txtConcep
            // 
            this.txtConcep.Location = new System.Drawing.Point(144, 270);
            this.txtConcep.MaxLength = 4;
            this.txtConcep.Name = "txtConcep";
            this.txtConcep.Size = new System.Drawing.Size(687, 22);
            this.txtConcep.TabIndex = 474;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(29, 274);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 14);
            this.label15.TabIndex = 473;
            this.label15.Text = "Concepto :";
            // 
            // dgvCajBanDet
            // 
            this.dgvCajBanDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCajBanDet.Location = new System.Drawing.Point(32, 329);
            this.dgvCajBanDet.Name = "dgvCajBanDet";
            this.dgvCajBanDet.Size = new System.Drawing.Size(799, 178);
            this.dgvCajBanDet.TabIndex = 475;
            // 
            // btnQuitarCtaBco
            // 
            this.btnQuitarCtaBco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitarCtaBco.Location = new System.Drawing.Point(697, 298);
            this.btnQuitarCtaBco.Name = "btnQuitarCtaBco";
            this.btnQuitarCtaBco.Size = new System.Drawing.Size(134, 25);
            this.btnQuitarCtaBco.TabIndex = 477;
            this.btnQuitarCtaBco.Tag = "19";
            this.btnQuitarCtaBco.Text = "Quitar Cuenta Banco";
            this.btnQuitarCtaBco.UseVisualStyleBackColor = true;
            // 
            // btnAgregarCtaBco
            // 
            this.btnAgregarCtaBco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarCtaBco.Location = new System.Drawing.Point(557, 298);
            this.btnAgregarCtaBco.Name = "btnAgregarCtaBco";
            this.btnAgregarCtaBco.Size = new System.Drawing.Size(134, 25);
            this.btnAgregarCtaBco.TabIndex = 476;
            this.btnAgregarCtaBco.Tag = "19";
            this.btnAgregarCtaBco.Text = "Agregar Cuenta Banco";
            this.btnAgregarCtaBco.UseVisualStyleBackColor = true;
            this.btnAgregarCtaBco.Click += new System.EventHandler(this.btnAgregarCtaBco_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(729, 515);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(99, 25);
            this.btnCancelar.TabIndex = 479;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(624, 515);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(99, 25);
            this.btnAceptar.TabIndex = 478;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(29, 520);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 14);
            this.label16.TabIndex = 483;
            this.label16.Text = "Debe Total S/. :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(220, 520);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(93, 14);
            this.label17.TabIndex = 484;
            this.label17.Text = "Haber Total S/. :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(220, 538);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(85, 14);
            this.label21.TabIndex = 486;
            this.label21.Text = "Haber Total $ :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(29, 538);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(81, 14);
            this.label22.TabIndex = 485;
            this.label22.Text = "Debe Total $ :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(406, 520);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(44, 14);
            this.label23.TabIndex = 487;
            this.label23.Text = "Saldo :";
            // 
            // lblDebTotSol
            // 
            this.lblDebTotSol.AutoSize = true;
            this.lblDebTotSol.Location = new System.Drawing.Point(201, 520);
            this.lblDebTotSol.Name = "lblDebTotSol";
            this.lblDebTotSol.Size = new System.Drawing.Size(13, 14);
            this.lblDebTotSol.TabIndex = 488;
            this.lblDebTotSol.Text = "0";
            // 
            // lblDebTotDol
            // 
            this.lblDebTotDol.AutoSize = true;
            this.lblDebTotDol.Location = new System.Drawing.Point(201, 538);
            this.lblDebTotDol.Name = "lblDebTotDol";
            this.lblDebTotDol.Size = new System.Drawing.Size(13, 14);
            this.lblDebTotDol.TabIndex = 489;
            this.lblDebTotDol.Text = "0";
            // 
            // lblHabTotSol
            // 
            this.lblHabTotSol.AutoSize = true;
            this.lblHabTotSol.Location = new System.Drawing.Point(387, 520);
            this.lblHabTotSol.Name = "lblHabTotSol";
            this.lblHabTotSol.Size = new System.Drawing.Size(13, 14);
            this.lblHabTotSol.TabIndex = 490;
            this.lblHabTotSol.Text = "0";
            // 
            // lblHabTotDol
            // 
            this.lblHabTotDol.AutoSize = true;
            this.lblHabTotDol.Location = new System.Drawing.Point(387, 538);
            this.lblHabTotDol.Name = "lblHabTotDol";
            this.lblHabTotDol.Size = new System.Drawing.Size(13, 14);
            this.lblHabTotDol.TabIndex = 491;
            this.lblHabTotDol.Text = "0";
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Location = new System.Drawing.Point(506, 520);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(13, 14);
            this.lblSaldo.TabIndex = 492;
            this.lblSaldo.Text = "0";
            // 
            // btnQuitar
            // 
            this.btnQuitar.Image = global::Presentacion.Properties.Resources._16__Borders_;
            this.btnQuitar.Location = new System.Drawing.Point(835, 427);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(30, 25);
            this.btnQuitar.TabIndex = 482;
            this.btnQuitar.Tag = "19";
            this.btnQuitar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.Image = global::Presentacion.Properties.Resources._16__Pencil_tool_;
            this.btnModificar.Location = new System.Drawing.Point(835, 396);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(30, 25);
            this.btnModificar.TabIndex = 481;
            this.btnModificar.Tag = "19";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::Presentacion.Properties.Resources._16__Plus_;
            this.btnAgregar.Location = new System.Drawing.Point(835, 365);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(30, 25);
            this.btnAgregar.TabIndex = 480;
            this.btnAgregar.Tag = "19";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // wEditCajaBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 572);
            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.lblHabTotDol);
            this.Controls.Add(this.lblHabTotSol);
            this.Controls.Add(this.lblDebTotDol);
            this.Controls.Add(this.lblDebTotSol);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnQuitarCtaBco);
            this.Controls.Add(this.btnAgregarCtaBco);
            this.Controls.Add(this.dgvCajBanDet);
            this.Controls.Add(this.txtConcep);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtGirPag);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtNroCtaBco);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCodCtaBco);
            this.Controls.Add(this.txtDesCtaBco);
            this.Controls.Add(this.txtNumRef);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCodTD);
            this.Controls.Add(this.txtDesTD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCodModPag);
            this.Controls.Add(this.txtDesModPag);
            this.Controls.Add(this.txtDistSoles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.txtTipCam);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtCodMonSyD);
            this.Controls.Add(this.cmbMon);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.dtpFecCorrRegContab);
            this.Controls.Add(this.txtCorrRegContab);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodFile);
            this.Controls.Add(this.txtDesFile);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtCodOri);
            this.Controls.Add(this.txtDesOri);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.txtPerCajBco);
            this.Controls.Add(this.label14);
            this.Name = "wEditCajaBanco";
            this.Text = "Editar Caja y Banco";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wEditCajaBanco_FormClosing);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.txtPerCajBco, 0);
            this.Controls.SetChildIndex(this.label24, 0);
            this.Controls.SetChildIndex(this.txtDesOri, 0);
            this.Controls.SetChildIndex(this.txtCodOri, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.txtDesFile, 0);
            this.Controls.SetChildIndex(this.txtCodFile, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtCorrRegContab, 0);
            this.Controls.SetChildIndex(this.dtpFecCorrRegContab, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.cmbMon, 0);
            this.Controls.SetChildIndex(this.txtCodMonSyD, 0);
            this.Controls.SetChildIndex(this.label20, 0);
            this.Controls.SetChildIndex(this.txtTipCam, 0);
            this.Controls.SetChildIndex(this.txtImporte, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtDistSoles, 0);
            this.Controls.SetChildIndex(this.txtDesModPag, 0);
            this.Controls.SetChildIndex(this.txtCodModPag, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtDesTD, 0);
            this.Controls.SetChildIndex(this.txtCodTD, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtNumRef, 0);
            this.Controls.SetChildIndex(this.txtDesCtaBco, 0);
            this.Controls.SetChildIndex(this.txtCodCtaBco, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtNroCtaBco, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.txtGirPag, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.txtConcep, 0);
            this.Controls.SetChildIndex(this.dgvCajBanDet, 0);
            this.Controls.SetChildIndex(this.btnAgregarCtaBco, 0);
            this.Controls.SetChildIndex(this.btnQuitarCtaBco, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.btnModificar, 0);
            this.Controls.SetChildIndex(this.btnQuitar, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.Controls.SetChildIndex(this.label22, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.label23, 0);
            this.Controls.SetChildIndex(this.lblDebTotSol, 0);
            this.Controls.SetChildIndex(this.lblDebTotDol, 0);
            this.Controls.SetChildIndex(this.lblHabTotSol, 0);
            this.Controls.SetChildIndex(this.lblHabTotDol, 0);
            this.Controls.SetChildIndex(this.lblSaldo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajBanDet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtPerCajBco;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label18;
        internal System.Windows.Forms.TextBox txtCodOri;
        private System.Windows.Forms.TextBox txtDesOri;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtCodFile;
        private System.Windows.Forms.TextBox txtDesFile;
        internal System.Windows.Forms.TextBox txtCorrRegContab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label19;
        internal System.Windows.Forms.DateTimePicker dtpFecCorrRegContab;
        private System.Windows.Forms.ComboBox cmbMon;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.TextBox txtTipCam;
        private System.Windows.Forms.Label label20;
        internal System.Windows.Forms.TextBox txtCodMonSyD;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtDistSoles;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtCodModPag;
        private System.Windows.Forms.TextBox txtDesModPag;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txtCodTD;
        private System.Windows.Forms.TextBox txtDesTD;
        internal System.Windows.Forms.TextBox txtNumRef;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtCodCtaBco;
        private System.Windows.Forms.TextBox txtDesCtaBco;
        private System.Windows.Forms.TextBox txtNroCtaBco;
        internal System.Windows.Forms.TextBox txtGirPag;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.TextBox txtConcep;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.DataGridView dgvCajBanDet;
        internal System.Windows.Forms.Button btnQuitarCtaBco;
        internal System.Windows.Forms.Button btnAgregarCtaBco;
        internal System.Windows.Forms.Button btnQuitar;
        internal System.Windows.Forms.Button btnModificar;
        internal System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblDebTotSol;
        private System.Windows.Forms.Label lblDebTotDol;
        private System.Windows.Forms.Label lblHabTotSol;
        private System.Windows.Forms.Label lblHabTotDol;
        private System.Windows.Forms.Label lblSaldo;
    }
}