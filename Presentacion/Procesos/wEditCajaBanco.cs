using Comun;
using Entidades;
using Entidades.Adicionales;
using Negocio;
using Presentacion.FuncionesGenericas;
using Presentacion.Listas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControles;
using WinControles.ControlesWindows;

namespace Presentacion.Procesos
{
    public partial class wEditCajaBanco : Heredados.MiForm8
    {
        #region Atributos

        public string wTipoCambio, wano, wmes, wperiodo, wOrigenVentana;
        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        public string eTitulo = "Caja y Banco";
        public List<RegContabDetaEN> eLisCajBanDet = new List<RegContabDetaEN>();
        public string eClaveDgvCajBanDet = string.Empty;
        Dgv.Franja eFranjaDgvCajBanDet = Dgv.Franja.PorIndice;
        string eNombreColumnaDgvTipOpe = TipoCambioEN.FecTipCam;
        public List<TipoCambioEN> eLisTipCam = new List<TipoCambioEN>();
        #endregion

        #region Propietario

        public wCajaBanco wCajBco;

        #endregion
        public wEditCajaBanco()
        {
            InitializeComponent();
        }
        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodOri, false, "Origen", "vvff", 2);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesOri, this.txtCodOri, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesFile, this.txtCodFile, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecCorrRegContab, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtTipCam, true, "Tipo Cambio", "vfff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtImporte, true, "Importe", "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodModPag, false, "Modo Pago", "vvff", 2);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesModPag, this.txtCodModPag, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodTD, false, "Tipo Documento", "vvff", 2);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesTD, this.txtCodTD, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNumRef, true, "Numero", "vvff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesCtaBco, this.txtCodCtaBco, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtGirPag, true, "Girado / Pagado", "vvff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtConcep, true, "Concepto", "vvff", 6);
            xLis.Add(xCtrl);


            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbMon, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtTipCam, false, "Tipo Cambio", "vvff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAgregar, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnModificar, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnQuitar, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAceptar, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnCancelar, "vvvv");
            xLis.Add(xCtrl);

            return xLis;
        }

        public void VentanaAdicionar()
        {
            this.wCajBco.lblPeriodo.Text = this.wCajBco.lblDescripcionPeriodo.Text;
            wano = this.wCajBco.lblPeriodo.Text.Substring(0, 4);
            wmes = this.wCajBco.lblPeriodo.Text.Substring(5).ToUpper();
            this.NumeroMesDelNombreDelMes();
            wperiodo = Universal.gCodigoEmpresa + "-" + wano + "-" + wmes;
            //Buscar Tipo de cambio del periodo
            TipoCambioEN nTipCmb = new TipoCambioEN();
            nTipCmb.PeriodoTipoCambio = wperiodo;
            nTipCmb = TipoCambioRN.BuscarTipoCambioXFecha(nTipCmb);
            wTipoCambio = nTipCmb.CompraUsTipoCambio.ToString();

            this.InicializaVentana();
            this.MostrarCajaBanco(RegContabCabeRN.EnBlanco());
            this.MostrarCajaBancoDeta();
            this.ImportesDebeHaber();
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodOri.Focus();
        }
        public void NumeroMesDelNombreDelMes()
        {
            if (wmes == "ENERO")
            {
                wmes = "01";
            }
            if (wmes == "FEBRERO")
            {
                wmes = "02";
            }
            if (wmes == "MARZO")
            {
                wmes = "03";
            }
            if (wmes == "ABRIL")
            {
                wmes = "04";
            }
            if (wmes == "MAYO")
            {
                wmes = "05";
            }
            if (wmes == "JUNIO")
            {
                wmes = "06";
            }
            if (wmes == "JULIO")
            {
                wmes = "07";
            }
            if (wmes == "AGOSTO")
            {
                wmes = "08";
            }
            if (wmes == "SETIEMBRE")
            {
                wmes = "09";
            }
            if (wmes == "OCTUBRE")
            {
                wmes = "10";
            }
            if (wmes == "NOVIEMBRE")
            {
                wmes = "11";
            }
            if (wmes == "DICIEMBRE")
            {
                wmes = "12";
            }
        }
        public void InicializaVentana()
        {
            //titulo ventana
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //llenar combos
            this.CargarMonedas();

            //Deshabilitar al propietario de esta ventana
            this.wCajBco.Enabled = false;

            //mostrar ventana
            this.Show();
        }
        public void MostrarCajaBanco(RegContabCabeEN pObj)
        {
            this.txtCodOri.Text = pObj.COrigen;
            this.txtDesOri.Text = pObj.NOrigen;
            this.txtCodFile.Text = pObj.CFile;
            this.txtDesFile.Text = pObj.NFile;
            this.txtCorrRegContab.Text = pObj.CorrelativoRegContabCabe;
            this.dtpFecCorrRegContab.Text = pObj.FechaRegContabCabe;
            Cmb.SeleccionarValorItem(this.cmbMon, pObj.CMonedaDocumento);
            this.txtTipCam.Text = pObj.VentaTipoCambio.ToString();
            this.txtImporte.Text = Formato.NumeroDecimal(pObj.ImporteRegContabCabe, 3);
            this.txtDistSoles.Text = Formato.NumeroDecimal(pObj.ImporteSolRegContabCabe, 3);
            this.txtCodModPag.Text = pObj.CModoCompra;
            this.txtDesModPag.Text = pObj.NModoPago;
            this.txtCodTD.Text = pObj.CTipoDocumento;
            this.txtDesTD.Text = pObj.NTipoDocumento;
            this.txtNumRef.Text = pObj.NumeroDocumentoRef;
            this.txtCodCtaBco.Text = pObj.CodigoCuenta;
            this.txtDesCtaBco.Text = pObj.DescripcionCuenta;
            this.txtNroCtaBco.Text = pObj.NumeroCuentaBanco;
            this.txtGirPag.Text = pObj.GiradoPagoRegContabCabe;
            this.txtConcep.Text = pObj.GlosaRegContabCabe;
            this.lblDebTotSol.Text = Formato.NumeroDecimal(string.Empty, 2);
            this.lblDebTotDol.Text = Formato.NumeroDecimal(string.Empty, 2);
            this.lblHabTotSol.Text = Formato.NumeroDecimal(string.Empty, 2);
            this.lblHabTotDol.Text = Formato.NumeroDecimal(string.Empty, 2);
            this.lblSaldo.Text = Formato.NumeroDecimal(string.Empty, 2);
            this.CargarTipoCambio();
        }
        public void MostrarCajaBancoDeta()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvCajBanDet;
            List<RegContabDetaEN> iFuenteDatos = RegContabDetaRN.RefrescarListaRegContabDeta(this.eLisCajBanDet); ;
            Dgv.Franja iCondicionFranja = eFranjaDgvCajBanDet;
            string iClaveBusqueda = eClaveDgvCajBanDet;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCom();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }
        public List<DataGridViewColumn> ListarColumnasDgvCom()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabDetaEN.CodCue, "Cuenta", 60));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabDetaEN.DesCue, "Nombre Cuenta", 145));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabDetaEN.CodAux, "R.U.C.", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabDetaEN.DesAux, "Razón Social", 145));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabDetaEN.NDebHab, "D/H", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(RegContabDetaEN.ImpSolRegConDet, "Importe S/.", 60, 3));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(RegContabDetaEN.ImpMonRegConDet, "Importe $", 60, 3));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabDetaEN.CTipDoc, "TD", 85));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabDetaEN.NTipDoc, "Desc. TD", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabDetaEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }
        public void CargarMonedas()
        {
            Cmb.Cargar(this.cmbMon, ItemGRN.ListarItemsG("Moneda"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void ListarOrigen()
        {
            //si es de lectura , entonces no lista
            if (txtCodOri.ReadOnly == true) { return; }

            //instanciar
            wLisItemG win = new wLisItemG();
            win.eVentana = this;
            win.eTituloVentana = "Origen";
            win.eCtrlValor = this.txtCodOri;
            win.eCtrlFoco = this.txtCodFile;
            win.eIteEN.CodigoTabla = "Ori";
            win.eCondicionLista = Listas.wLisItemG.Condicion.ItemsActivosXTablaxCondicionOrigenes;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }
        public bool EsOrigenValido()
        {
            bool result = false;
            if (this.txtCodOri.Text.Trim() != string.Empty)
            {
                string codOri = this.txtCodOri.Text.Trim().Substring(0, 1);
                if (codOri == "1" || codOri == "2")
                {
                    result = Generico.EsCodigoItemGValido("Ori", this.txtCodOri, this.txtDesOri, "Origen");
                }
                else
                {
                    this.txtCodOri.Text = string.Empty;
                    this.txtCodOri.Focus();
                    Mensaje.OperacionDenegada("El codigo de origen no existe", wCajBco.eTitulo);
                }
            }
            return result;
        }

        public void ListarFile()
        {
            //si es de lectura , entonces no lista
            if (txtCodFile.ReadOnly == true) { return; }

            //instanciar
            wLisItemE win = new wLisItemE();
            win.eVentana = this;
            win.eTituloVentana = "File";
            win.eCtrlValor = this.txtCodFile;
            win.eCtrlFoco = this.dtpFecCorrRegContab;
            win.eIteEN.CodigoTabla = "Fil";
            win.eIteEN.CodigoItemE = this.txtCodOri.Text.Trim();
            win.eCondicionLista = Listas.wLisItemE.Condicion.ItemsActivosXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }
        public bool EsFileValido()
        {
            return Generico.EsCodigoItemEValido("Fil", this.txtCodFile, this.txtDesFile, "File");
        }

        public void ListarModoPago()
        {
            //si es de lectura , entonces no lista
            if (txtCodModPag.ReadOnly == true) { return; }

            //instanciar
            wLisItemG win = new wLisItemG();
            win.eVentana = this;
            win.eTituloVentana = "Modo Pago";
            win.eCtrlValor = this.txtCodModPag;
            win.eCtrlFoco = this.txtCodTD;
            win.eIteEN.CodigoTabla = "ModPag";
            win.eCondicionLista = Listas.wLisItemG.Condicion.ItemsActivosXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }
        public bool EsModoPagoValido()
        {
            return Generico.EsCodigoItemGValido("ModPag", this.txtCodModPag, this.txtDesModPag, "Modo Pago");
        }

        public void ListarTipoDocumento()
        {
            //si es de lectura , entonces no lista
            if (txtCodTD.ReadOnly == true) { return; }

            //instanciar
            wLisItemG win = new wLisItemG();
            win.eVentana = this;
            win.eTituloVentana = "Tipo Documento";
            win.eCtrlValor = this.txtCodTD;
            win.eCtrlFoco = this.txtNumRef;
            win.eIteEN.CodigoTabla = "TipDoc";
            win.eCondicionLista = Listas.wLisItemG.Condicion.ItemsActivosXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }
        public bool EsTipoDocumentoValido()
        {
            return Generico.EsCodigoItemGValido("TipDoc", this.txtCodTD, this.txtDesTD, "Tipo Documento");
        }

        public void ListarCuentaBanco()
        {
            //si es de lectura , entonces no lista
            if (txtCodCtaBco.ReadOnly == true) { return; }

            //instanciar
            wLisCueBco win = new wLisCueBco();
            win.eVentana = this;
            win.eTituloVentana = "Cuenta Banco";
            win.eCtrlValor = this.txtCodCtaBco;
            win.eCtrlFoco = this.txtGirPag;
            win.eCondicionLista = Listas.wLisCueBco.Condicion.CuentasBancoActivas;
            win.eObjEN.CMoneda = Cmb.ObtenerValor(this.cmbMon);
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }
        public bool EsCuentaBancoValido()
        {
            if (txtCodCtaBco.ReadOnly) { return false; }

            CuentaBancoEN iCtaBco = new CuentaBancoEN();
            iCtaBco.CodigoCuentaBanco = this.txtCodCtaBco.Text.Trim();
            iCtaBco = CuentaBancoRN.EsCuentaBancoActivoValido(iCtaBco);
            if (iCtaBco.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCtaBco.Adicionales.Mensaje, (this.eTitulo));
                this.txtCodCtaBco.Focus();
            }

            //mostrar datos
            this.txtCodCtaBco.Text = iCtaBco.CodigoCuentaBanco;
            this.txtDesCtaBco.Text = iCtaBco.DescripcionCuentaBanco;
            this.txtNroCtaBco.Text = iCtaBco.NumeroCuentaBanco;

            //devolver
            return iCtaBco.Adicionales.EsVerdad;
        }

        public void AccionAgregarItem()
        {

            //instanciar
            wAgregarItemCajaBanco win = new wAgregarItemCajaBanco();
            win.wEditCajBco = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvCajBanDet = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, (this.wCajBco.eTitulo));
        }

        public string ObtenerClaveCajaBcoCabe()
        {
            RegContabCabeEN iRegBcoCabEN = new RegContabCabeEN();
            this.AsignarCajaBcoCabe(iRegBcoCabEN);
            return iRegBcoCabEN.ClaveRegContabCabe;
        }

        public void AsignarCajaBcoCabe(RegContabCabeEN pRegContabCab)
        {
            pRegContabCab.CodigoEmpresa = Universal.gCodigoEmpresa;
            pRegContabCab.PeriodoRegContabCabe = this.wCajBco.lblPeriodo.Text;
            pRegContabCab.COrigen = this.txtCodOri.Text;
            pRegContabCab.CFile = this.txtCodFile.Text;
            pRegContabCab.CorrelativoRegContabCabe = this.txtCorrRegContab.Text;
            pRegContabCab.FechaRegContabCabe = this.dtpFecCorrRegContab.Text;
            pRegContabCab.CTipoDocumento = this.txtCodTD.Text;
            pRegContabCab.CMonedaDocumento = Cmb.ObtenerValor(this.cmbMon, string.Empty);
            pRegContabCab.VentaTipoCambio = Conversion.ADecimal(this.txtTipCam.Text, 0);
            pRegContabCab.GlosaRegContabCabe = this.txtConcep.Text;
            pRegContabCab.NumeroPapeletaDetraccion = this.txtNumRef.Text;
            pRegContabCab.CodigoCuenta = this.txtCodCtaBco.Text;
            pRegContabCab.ImporteRegContabCabe = Conversion.ADecimal(this.txtImporte.Text, 0);
            pRegContabCab.ImporteSolRegContabCabe = Conversion.ADecimal(this.txtDistSoles.Text, 0);
            pRegContabCab.CModoPago = this.txtCodModPag.Text;
            pRegContabCab.GiradoPagoRegContabCabe = this.txtGirPag.Text;
            pRegContabCab.ClaveRegContabCabe = RegContabCabeRN.ObtenerClaveRegContabCabe(pRegContabCab);
        }

        public void CargarTipoCambio()
        {
            decimal tipCam = 0;
            TipoCambioEN objTipCam = new TipoCambioEN();
            objTipCam.Adicionales.CampoOrden = eNombreColumnaDgvTipOpe;
            eLisTipCam = TipoCambioRN.ListarTipoCambios(objTipCam);

            string fechaTipoCambio = Fecha.ObtenerDiaMesAno(Conversion.ADateTime(dtpFecCorrRegContab.Text));

            if (eLisTipCam.Where(e => e.FechaTipoCambio == fechaTipoCambio).Count() == 0)
            {
                Mensaje.OperacionDenegada("Se debe ingresar un tipo de cambio para la fecha del documento.", this.wCajBco.eTitulo);
                txtTipCam.Text = Formato.NumeroDecimal(0, 4);
            }
            else
                txtTipCam.Text = eLisTipCam.FirstOrDefault(e => e.FechaTipoCambio == fechaTipoCambio).VentaUsTipoCambio.ToString();

        }

        public void ImportesDebeHaber()
        {
            this.CalculoDistribucion();
            int numreg = this.dgvCajBanDet.Rows.Count - 2;
            string deha = string.Empty;
            decimal impS, impD;
            for (int i = 0; i < numreg; i++)
            {
                deha = this.dgvCajBanDet.Rows[i].Cells[RegContabDetaEN.NDebHab].Value.ToString();
                impS = Conversion.ADecimal(this.dgvCajBanDet.Rows[i].Cells[RegContabDetaEN.ImpSolRegConDet].Value.ToString(), 2);
                impD = Conversion.ADecimal(this.dgvCajBanDet.Rows[i].Cells[RegContabDetaEN.ImpMonRegConDet].Value.ToString(), 2);
                switch (deha)
                {
                    case "Haber":
                        this.lblHabTotSol.Text = (Conversion.ADecimal(this.lblHabTotSol.Text, 2) + impS).ToString();
                        this.lblHabTotDol.Text = (Conversion.ADecimal(this.lblHabTotDol.Text, 2) + impD).ToString();
                        break;
                    case "Debe":
                        this.lblDebTotSol.Text = (Conversion.ADecimal(this.lblDebTotSol.Text, 2) + impS).ToString();
                        this.lblDebTotDol.Text = (Conversion.ADecimal(this.lblDebTotDol.Text, 2) + impD).ToString();
                        break;
                }
            }
        }

        public void CalculoDistribucion()
        {
            if (this.txtImporte.Text.Length != 0)
            {
                switch (Cmb.ObtenerValor(this.cmbMon))
                {
                    case "0":
                        this.txtDistSoles.Text = this.txtImporte.Text;
                        break;
                    case "1":
                        this.txtDistSoles.Text = (Conversion.ADecimal(this.txtImporte.Text, 2) * Conversion.ADecimal(this.txtTipCam.Text, 3)).ToString();
                        break;
                    default:
                        this.txtDistSoles.Text = this.txtImporte.Text;
                        break;
                }
            }
        }

        public void AgregarCuentaBanco()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }


        }

        public void AsignarCuentaBanco()
        {

        }

        private void txtCodOri_DoubleClick(object sender, EventArgs e)
        {
            this.ListarOrigen();
        }

        private void txtCodOri_Validating(object sender, CancelEventArgs e)
        {
            this.EsOrigenValido();
        }

        private void txtCodFile_DoubleClick(object sender, EventArgs e)
        {
            this.ListarFile();
        }

        private void txtCodFile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarFile(); }
        }

        private void txtCodFile_Validating(object sender, CancelEventArgs e)
        {
            this.EsFileValido();
        }

        private void txtCodModPag_Validating(object sender, CancelEventArgs e)
        {
            this.EsModoPagoValido();
        }

        private void txtCodModPag_DoubleClick(object sender, EventArgs e)
        {
            this.ListarModoPago();
        }

        private void txtCodModPag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarModoPago(); }
        }

        private void txtCodTD_Validating(object sender, CancelEventArgs e)
        {
            this.EsTipoDocumentoValido();
        }

        private void txtCodTD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarTipoDocumento(); }
        }

        private void txtCodTD_DoubleClick(object sender, EventArgs e)
        {
            this.ListarTipoDocumento();
        }

        private void txtCodCtaBco_Validating(object sender, CancelEventArgs e)
        {
            this.EsCuentaBancoValido();
        }

        private void txtCodCtaBco_DoubleClick(object sender, EventArgs e)
        {
            this.ListarCuentaBanco();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if ((this.lblDebTotSol.Text == this.txtDistSoles.Text)
                &&
                (this.lblHabTotSol.Text == this.txtDistSoles.Text))
            {
                Mensaje.OperacionDenegada("El importe ya esta cuadrado", this.wCajBco.eTitulo);
                return;
            }



            if (
                (this.lblDebTotSol.Text == "0.00" && this.lblHabTotSol.Text == "0.00")
            &&
            (Convert.ToDecimal(this.lblDebTotSol.Text) < Convert.ToDecimal(this.txtDistSoles.Text)
            ||
             Convert.ToDecimal(this.lblHabTotSol.Text) < Convert.ToDecimal(this.txtDistSoles.Text))
             )
                this.AccionAgregarItem();
            else
            {
                if (Convert.ToDecimal(this.lblDebTotSol.Text) == Convert.ToDecimal(this.lblHabTotSol.Text))
                {
                    Mensaje.OperacionDenegada("La suma de los importes ya estan cuadrados", this.wCajBco.eTitulo);
                    return;
                }
                else
                    this.AccionAgregarItem();
            }
        }

        private void dtpFecCorrRegContab_Validated(object sender, EventArgs e)
        {
            this.CargarTipoCambio();
        }

        private void txtImporte_Validated(object sender, EventArgs e)
        {
            this.ImportesDebeHaber();
        }

        private void cmbMon_Validating(object sender, CancelEventArgs e)
        {
            this.ImportesDebeHaber();
        }

        private void txtCodOri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            { this.ListarOrigen(); }
        }

        private void txtCodCtaBco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarCuentaBanco(); }
        }

        private void btnAgregarCtaBco_Click(object sender, EventArgs e)
        {
            this.AgregarCuentaBanco();
        }

        private void wEditCajaBanco_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wCajBco.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }
    }
}
