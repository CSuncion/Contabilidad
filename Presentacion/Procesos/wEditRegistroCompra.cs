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
    public partial class wEditRegistroCompra : Heredados.MiForm8
    {
        public wEditRegistroCompra()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        public List<RegContabDetaEN> eLisRegConDet = new List<RegContabDetaEN>();
        public string eClaveDgvMovDet = string.Empty;
        public string wSaldo = string.Empty;
        Dgv.Franja eFranjaDgvMovDet = Dgv.Franja.PorIndice;

        #endregion

        #region Propietario

        public wRegistroCompra wRegConCab;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtPerRegConCab, this.txtCFil, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCOri, this.txtCFil, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNOri, this.txtCFil, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCFil, true, "File", "vfff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNFil, this.txtCFil, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroSinEspacion(this.txtCorRegConCab, true, "Correlativo", "vfff", 5);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecRegConCab, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAux, true, "Proveedor", "vvff", 11);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAux, this.txtCodAux, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCTipDoc, false, "Tipo Documento", "vvff", 2);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNTipDoc, this.txtCTipDoc, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtSerDoc, false, "Serie", "vvff", 4);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNumDoc, false, "Numero Documento", "vvff", 15);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCMonDoc, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecDoc, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtVenTipCam, false, "Tipo Cambio", this.dtpFecDoc);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecVctDoc, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCModCom, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtPorIgv, false, "% Igv", this.cmbCModCom);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCTipCom, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtPreVenRegConCab, false, "Precio Venta", "vvff", 2, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCAplIna, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtExoRegConCab, false, "Exonerado", "vvff", 2, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtInaRegConCab, false, "Inafecto", "vvff", 2, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtValVenRegConCab, false, "Valor Venta", "vvff", 2, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCAplIgv, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtIgvRegConCab, false, "Igv", "vvff", 2, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtImpTotDis, false, "Distribuir", this.cmbCModCom);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCTipDocRef, false, "Tipo Documento Ref", "vvff", 2);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNTipDocRef, this.txtCTipDocRef, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtSerDocRef, false, "Serie Ref", "vvff", 4);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNumDocRef, false, "Numero Documento Ref", "vvff", 15);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNMonDocRef, this.txtCFil, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtFecDocRef, this.txtCFil, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCAplDet, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecDet, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNumPapDet, false, "Numero Papeleta", "vvff", 15);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtGloRegConCab, false, "GlosaRegContabCabe", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodCue, false, "Codigo Cuenta", "vvff", 11);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesCue, this.txtCodCue, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAgregar, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnModificar, "vvvv");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnQuitar, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAceptar, "vvvv");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnCancelar, "vvvv");
            xLis.Add(xCtrl);

            return xLis;
        }

        #endregion

        #region General

        public void InicializaVentana()
        {
            //titulo ventana
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wRegConCab.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //llenar Combos
            this.CargarCMonedaDocumento();
            this.CargarCModoCompra();
            this.CargarCTipoCompra();
            this.CargarCAplicaIgv();
            this.CargarCAplicaInafecto();
            this.CargarCAplicaDetraccion();
            this.EfectoModoCompra();

            //valores x defecto
            this.ValoresXDefecto();

            //deshabilitar al propietario
            this.wRegConCab.Enabled = false;

            //mostrar ventana
            this.Show();
        }

        public void ValoresXDefecto()
        {
            this.txtPerRegConCab.Text = this.wRegConCab.lblDescripcionPeriodo.Text;
            this.txtCOri.Text = "4";
            this.txtNOri.Text = "Compra";
        }

        public void CargarCModoCompra()
        {
            Cmb.Cargar(this.cmbCModCom, ItemGRN.ListarItemsG("ModCom"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCTipoCompra()
        {
            Cmb.Cargar(this.cmbCTipCom, ItemGRN.ListarItemsG("TipCom"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCMonedaDocumento()
        {
            Cmb.Cargar(this.cmbCMonDoc, ItemGRN.ListarItemsG("Moneda"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCAplicaIgv()
        {
            Cmb.Cargar(this.cmbCAplIgv, ItemGRN.ListarItemsG("SiNo"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCAplicaInafecto()
        {
            Cmb.Cargar(this.cmbCAplIna, ItemGRN.ListarItemsG("SiNo"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCAplicaDetraccion()
        {
            Cmb.Cargar(this.cmbCAplDet, ItemGRN.ListarItemsG("SiNo"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void EsDocumentoRegistrado()
        {
            CuentaCorrienteEN iCtaCte = new CuentaCorrienteEN();
            iCtaCte.CodigoEmpresa = Universal.gCodigoEmpresa;
            iCtaCte.CodigoAuxiliar = this.txtCodAux.Text.Trim();
            iCtaCte.CTipoDocumento = this.txtCTipDoc.Text.Trim();
            iCtaCte.SerieDocumento = this.txtSerDoc.Text.Trim();
            iCtaCte.NumeroDocumento = this.txtNumDoc.Text.Trim();
            iCtaCte.ClaveDocumentoCuentaCorriente = CuentaCorrienteRN.ObtenerClaveDocumentoCuentaCorriente(iCtaCte);
            iCtaCte = CuentaCorrienteRN.BuscarCuentaCorrienteXClaveDocumentoCuentaCorriente(iCtaCte);
            if (iCtaCte.ClaveDocumentoCuentaCorriente != string.Empty)
            {
                MessageBox.Show("Documento ya esta registrado", "Validador");
                this.txtNumDoc.Focus();
                return;
            }

        }

        public void EfectoModoCompra()
        {
            string wModoCompra = this.cmbCModCom.SelectedValue.ToString();
            switch (wModoCompra)
            {
                case "0": this.txtModoCompra.Text = "ADQUISICIONES GRABADAS DESTINADAS A OPERACIONES GRAVADAS Y/O DE EXPORTACION"; break;
                case "1": this.txtModoCompra.Text = "ADQUISICIONES GRABADAS DESTINADAS A OPERACIONES GRAVADAS Y/O DE EXPORTACION Y A OPERACIONES NO GRAVADAS"; break;
                case "2": this.txtModoCompra.Text = "ADQUISICIONES GRABADAS DESTINADAS A OPERACIONES NO GRAVADAS"; break;
                default:
                    this.txtModoCompra.Text = "Que sera"; break;
            }
        }


        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarRegContabCabe(RegContabCabeRN.EnBlanco());
            this.MostrarRegContabDetas();
            eMas.AccionHabilitarControles(0);
            this.CambiarCkbAuto();
            this.MostrarFechaRegContabCabeSugerida();
            this.MostrarFechasDocumentoSugeridas();
            this.MostrarTipoCambio();
            this.MostrarPorcentajeIgv();
            this.MostrarMontosDocumentos();
            this.HabilitarControlesMontosDocumento();
            this.HabilitarControlesDocumentoReferencia();
            this.HabilitarControlesDetraccion();
            this.MostrarCalculosDistribucion();
            eMas.AccionPasarTextoPrincipal();
            this.txtCFil.Focus();
        }

        public void VentanaModificar(RegContabCabeEN pObj)
        {
            this.InicializaVentana();
            this.MostrarRegContabCabe(pObj);
            this.LLenarRegContabDetaDeBaseDatos(pObj);
            this.MostrarRegContabDetas();
            eMas.AccionHabilitarControles(1);
            this.ckbAuto.Enabled = false;
            this.MostrarTipoCambio();
            this.MostrarPorcentajeIgv();
            this.MostrarMontosDocumentos();
            this.HabilitarControlesMontosDocumento();
            this.HabilitarControlesDocumentoReferencia();
            this.HabilitarControlesDetraccion();
            this.MostrarCalculosDistribucion();
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecRegConCab.Focus();
        }

        public void VentanaEliminar(RegContabCabeEN pObj)
        {
            this.InicializaVentana();
            this.MostrarRegContabCabe(pObj);
            this.LLenarRegContabDetaDeBaseDatos(pObj);
            this.MostrarRegContabDetas();
            eMas.AccionHabilitarControles(2);
            this.ckbAuto.Enabled = false;
            this.MostrarCalculosDistribucion();
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(RegContabCabeEN pObj)
        {
            wSaldo = "Visualizar";
            this.InicializaVentana();
            this.MostrarRegContabCabe(pObj);
            this.LLenarRegContabDetaDeBaseDatos(pObj);
            this.MostrarRegContabDetas();
            eMas.AccionHabilitarControles(3);
            this.ckbAuto.Enabled = false;
            this.MostrarCalculosDistribucion();
            this.btnCancelar.Focus();
        }

        public void AsignarRegContabCabe(RegContabCabeEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.PeriodoRegContabCabe = this.wRegConCab.lblPeriodo.Text;
            pObj.COrigen = this.txtCOri.Text.Trim();
            pObj.CFile = this.txtCFil.Text.Trim();
            pObj.CorrelativoRegContabCabe = RegContabCabeRN.ArmarCorrelativoRegContabCabe(this.txtCorRegConCab.Text.Trim());
            pObj.FechaRegContabCabe = this.dtpFecRegConCab.Text;
            pObj.CodigoAuxiliar = this.txtCodAux.Text.Trim();
            pObj.CModoCompra = Cmb.ObtenerValor(this.cmbCModCom, string.Empty);
            pObj.CTipoCompra = Cmb.ObtenerValor(this.cmbCTipCom, string.Empty);
            pObj.CTipoDocumento = this.txtCTipDoc.Text.Trim();
            pObj.CAplicaDocumentoRef = this.txtCAplDocRef.Text.Trim();
            pObj.CTipoNota = this.txtCTipNot.Text.Trim();
            pObj.SerieDocumento = RegContabCabeRN.ArmarSerieDocumento(this.txtSerDoc.Text.Trim());
            pObj.NumeroDocumento = RegContabCabeRN.ArmarNumeroDocumento(this.txtNumDoc.Text.Trim());
            pObj.FechaDocumento = this.dtpFecDoc.Text;
            pObj.FechaVctoDocumento = this.dtpFecVctDoc.Text;
            pObj.CMonedaDocumento = Cmb.ObtenerValor(this.cmbCMonDoc, string.Empty);
            pObj.CTipoDocumentoRef = this.txtCTipDocRef.Text.Trim();
            pObj.SerieDocumentoRef = RegContabCabeRN.ArmarSerieDocumento(this.txtSerDocRef.Text.Trim());
            pObj.NumeroDocumentoRef = RegContabCabeRN.ArmarNumeroDocumento(this.txtNumDocRef.Text.Trim());
            pObj.CMonedaDocumentoRef = this.txtCMonDocRef.Text.Trim();
            pObj.NMonedaDocumentoRef = this.txtNMonDocRef.Text.Trim();
            pObj.FechaDocumentoRef = this.txtFecDocRef.Text.Trim();
            pObj.VentaTipoCambio = Conversion.ADecimal(this.txtVenTipCam.Text, 0);
            pObj.PorcentajeIgv = Conversion.ADecimal(this.txtPorIgv.Text, 0);
            pObj.CAplicaIgv = Cmb.ObtenerValor(this.cmbCAplIgv, string.Empty);
            pObj.CAplicaInafecto = Cmb.ObtenerValor(this.cmbCAplIna, string.Empty);
            pObj.ValorVentaRegContabCabe = Conversion.ADecimal(this.txtValVenRegConCab.Text, 0);
            pObj.IgvRegContabCabe = Conversion.ADecimal(this.txtIgvRegConCab.Text, 0);
            pObj.ExoneradoRegContabCabe = Conversion.ADecimal(this.txtExoRegConCab.Text, 0);
            pObj.InafectoRegContabCabe = Conversion.ADecimal(this.txtInaRegConCab.Text, 0);
            pObj.PrecioVentaRegContabCabe = Conversion.ADecimal(this.txtPreVenRegConCab.Text, 0);
            pObj.GlosaRegContabCabe = this.txtGloRegConCab.Text.Trim();
            pObj.CAplicaDetraccion = Cmb.ObtenerValor(this.cmbCAplDet, string.Empty);
            pObj.NumeroPapeletaDetraccion = this.txtNumPapDet.Text.Trim();
            pObj.FechaDetraccion = Dtp.ObtenerValor(this.dtpFecDet);
            pObj.CodigoCuenta = this.txtCodCue.Text.Trim();
            pObj.ClaveRegContabCabe = RegContabCabeRN.ObtenerClaveRegContabCabe(pObj);
        }

        public void MostrarRegContabCabe(RegContabCabeEN pObj)
        {
            //this.txtPerRegConCab.Text = pObj.PeriodoRegContabCabe;
            //this.txtCOri.Text = pObj.COrigen;
            this.txtCFil.Text = pObj.CFile;
            this.txtNFil.Text = pObj.NFile;
            this.txtCorRegConCab.Text = pObj.CorrelativoRegContabCabe;
            this.dtpFecRegConCab.Text = pObj.FechaRegContabCabe;
            this.txtCodAux.Text = pObj.CodigoAuxiliar;
            this.txtDesAux.Text = pObj.DescripcionAuxiliar;
            Cmb.SeleccionarValorItem(this.cmbCModCom, pObj.CModoCompra);
            Cmb.SeleccionarValorItem(this.cmbCTipCom, pObj.CTipoCompra);
            this.txtCTipDoc.Text = pObj.CTipoDocumento;
            this.txtNTipDoc.Text = pObj.NTipoDocumento;
            this.txtCAplDocRef.Text = pObj.CAplicaDocumentoRef;
            this.txtCTipNot.Text = pObj.CTipoNota;
            this.txtSerDoc.Text = pObj.SerieDocumento;
            this.txtNumDoc.Text = pObj.NumeroDocumento;
            this.dtpFecDoc.Text = pObj.FechaDocumento;
            this.dtpFecVctDoc.Text = pObj.FechaVctoDocumento;
            Cmb.SeleccionarValorItem(this.cmbCMonDoc, pObj.CMonedaDocumento);
            this.txtCTipDocRef.Text = pObj.CTipoDocumentoRef;
            this.txtNTipDocRef.Text = pObj.NTipoDocumentoRef;
            this.txtSerDocRef.Text = pObj.SerieDocumentoRef;
            this.txtNumDocRef.Text = pObj.NumeroDocumentoRef;
            this.txtCMonDocRef.Text = pObj.CMonedaDocumentoRef;
            this.txtNMonDocRef.Text = pObj.NMonedaDocumentoRef;
            this.txtFecDocRef.Text = pObj.FechaDocumentoRef;
            this.txtVenTipCam.Text = Formato.NumeroDecimal(pObj.VentaTipoCambio, 3);
            this.txtPorIgv.Text = Formato.NumeroDecimal(pObj.PorcentajeIgv, 2);
            Cmb.SeleccionarValorItem(this.cmbCAplIgv, pObj.CAplicaIgv);
            Cmb.SeleccionarValorItem(this.cmbCAplIna, pObj.CAplicaInafecto);
            this.txtValVenRegConCab.Text = Formato.NumeroDecimal(pObj.ValorVentaRegContabCabe, 2);
            this.txtIgvRegConCab.Text = Formato.NumeroDecimal(pObj.IgvRegContabCabe, 2);
            this.txtExoRegConCab.Text = Formato.NumeroDecimal(pObj.ExoneradoRegContabCabe, 2);
            this.txtInaRegConCab.Text = Formato.NumeroDecimal(pObj.InafectoRegContabCabe, 2);
            this.txtPreVenRegConCab.Text = Formato.NumeroDecimal(pObj.PrecioVentaRegContabCabe, 2);
            this.txtGloRegConCab.Text = pObj.GlosaRegContabCabe;
            Cmb.SeleccionarValorItem(this.cmbCAplDet, pObj.CAplicaDetraccion);
            this.txtNumPapDet.Text = pObj.NumeroPapeletaDetraccion;
            this.dtpFecDet.Text = pObj.FechaDetraccion;
            this.txtCodCue.Text = pObj.CodigoCuenta;
            this.txtDesCue.Text = pObj.DescripcionCuenta;
        }

        public void MostrarRegContabDetas()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvRegConDet;
            List<RegContabDetaEN> iFuenteDatos = ListaG.Refrescar<RegContabDetaEN>(this.eLisRegConDet);
            Dgv.Franja iCondicionFranja = eFranjaDgvMovDet;
            string iClaveBusqueda = eClaveDgvMovDet;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCom();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvCom()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabDetaEN.CodCue, "Codigo", 60));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabDetaEN.DesCue, "Descripcion", 200));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabDetaEN.NDebHab, "D/H", 50));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(RegContabDetaEN.ImpSolRegConDet, "Importe s/.", 90, 2));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabDetaEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void LLenarRegContabDetaDeBaseDatos(RegContabCabeEN pObj)
        {
            RegContabDetaEN iRegConDetEN = new RegContabDetaEN();
            iRegConDetEN.ClaveRegContabCabe = pObj.ClaveRegContabCabe;
            iRegConDetEN.Adicionales.CampoOrden = RegContabDetaEN.ClaRegConDet;
            if (wSaldo == "Visualizar")
            {
                this.eLisRegConDet = RegContabDetaRN.ListarRegContabDetaXClaveRegContabCabeYTipoLineaAsientoCompleto(iRegConDetEN);
            }
            else
            {
                this.eLisRegConDet = RegContabDetaRN.ListarRegContabDetaXClaveRegContabCabeYTipoLineaAsiento(iRegConDetEN);
            }

        }

        public void Aceptar()
        {
            switch (this.eOperacion)
            {
                case Universal.Opera.Adicionar: { this.Adicionar(); break; }
                case Universal.Opera.Modificar: { this.Modificar(); break; }
                case Universal.Opera.Eliminar: { this.Eliminar(); break; }
                default: break;
            }
        }

        public void Adicionar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wRegConCab.eTitulo) == false) { return; }

            //obtener nuevo correlativo
            this.MostrarNuevoCorrelativo();             

            //adicionando el registro
            this.AdicionarRegContabCabe();             

            //adicionando los regContabDetas
            this.AdicionarRegContabDetas();             

            //adicionando el registro
            this.AdicionarCuentaCorriente();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Registro Compra se adiciono correctamente", this.wRegConCab.eTitulo);

            //actualizar al propietario
            this.wRegConCab.eClaveDgvMovCab = this.ObtenerClaveRegContabCabe();
            this.wRegConCab.ActualizarVentana();

            //limpiar controles
            this.ValoresXDefecto();
            this.eLisRegConDet.Clear();
            this.MostrarRegContabCabe(RegContabCabeRN.EnBlanco());
            this.MostrarCalculosDistribucion();
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecRegConCab.Focus();
        }

        public RegContabCabeEN NuevoRegContabCabeDeVentana()
        {
            RegContabCabeEN iRegConCabEN = new RegContabCabeEN();
            this.AsignarRegContabCabe(iRegConCabEN);
            return iRegConCabEN;
        }

        //public CuentaCorrienteEN NuevoCuentaCorrienteDeVentana()
        //{
        //    RegContabCabeEN iRegConCabEN = new RegContabCabeEN();
        //    this.AsignarRegContabCabe(iRegConCabEN);
        //    return iRegConCabEN;
        //}

        public void MostrarNuevoCorrelativo()
        {
            //solo si es automatico
            if (this.ckbAuto.Checked == false) { return; }

            //asignar parametros
            RegContabCabeEN iRegConCabEN = this.NuevoRegContabCabeDeVentana();

            //obtener el nuevo numero
            string iNuevoNumero = RegContabCabeRN.ObtenerNuevoCorrelativoRegContabCabeAutogenerado(iRegConCabEN);

            //mostrar en pantalla
            this.txtCorRegConCab.Text = iNuevoNumero;
        }

        public void AdicionarRegContabCabe()
        {
            //asignar parametros
            RegContabCabeEN iObjEN = this.NuevoRegContabCabeDeVentana();
            
            //ejecutar metodo
            RegContabCabeRN.AdicionarRegContabCabe(iObjEN);
        }

        public string ObtenerClaveRegContabCabe()
        {
            RegContabCabeEN iObjEN = new RegContabCabeEN();
            this.AsignarRegContabCabe(iObjEN);
            return iObjEN.ClaveRegContabCabe;
        }

        public void AdicionarRegContabDetas()
        {
            //asignar parametros
            RegContabCabeEN iRegConCabEN = RegContabCabeRN.BuscarRegContabCabeXClave(this.ObtenerClaveRegContabCabe());
            List<RegContabDetaEN> iLisRegConDetEdi = RegContabDetaRN.CrearListaRegContabDetaActualizadaSoloDatosCabecera(iRegConCabEN, this.eLisRegConDet);

            //ejecutar metodo
            RegContabDetaRN.AdicionarRegContabDetasParaCompra(iRegConCabEN, iLisRegConDetEdi);
        }

        public List<RegContabDetaEN> LisstarRegContabDetasCompleto()
        {
            //asignar parametros
            RegContabCabeEN iRegConCabEN = this.NuevoRegContabCabeDeVentana();
            List<RegContabDetaEN> iLisRegConDetEdi = RegContabDetaRN.CrearListaRegContabDetaActualizadaSoloDatosCabecera(iRegConCabEN, this.eLisRegConDet);

            //ejecutar metodo
            return RegContabDetaRN.ArmarAsientoTotalParaCompraNormal(iRegConCabEN, iLisRegConDetEdi);
        }

        public void AdicionarCuentaCorriente()
        {
            //asignar parametros
            CuentaCorrienteEN iCtaCte= new CuentaCorrienteEN();
            iCtaCte.ClaveCuentaCorriente = Universal.gCodigoEmpresa + "-" + this.wRegConCab.lblPeriodo.Text + "-" + this.txtCOri.Text.Trim() + "-" + this.txtCFil.Text.Trim() + "-" + this.txtCorRegConCab.Text.Trim();
            iCtaCte.ClaveDocumentoCuentaCorriente = Universal.gCodigoEmpresa + "-" + this.txtCodAux.Text.Trim() + "-" + this.txtCTipDoc.Text.Trim()+"-" + this.txtSerDoc.Text.Trim()+"-" + this.txtNumDoc.Text.Trim();        
            iCtaCte.CodigoEmpresa = Universal.gCodigoEmpresa;             
            iCtaCte.PeriodoRegContabCabe = this.wRegConCab.lblPeriodo.Text;             
            iCtaCte.COrigen = this.txtCOri.Text.Trim();           
            iCtaCte.CFile = this.txtCFil.Text.Trim();         
            iCtaCte.NumeroVoucherRegContabCabe = this.txtCorRegConCab.Text.Trim();           
            iCtaCte.CodigoAuxiliar = this.txtCodAux.Text.Trim();          
            iCtaCte.CTipoDocumento = this.txtCTipDoc.Text.Trim();         
            iCtaCte.SerieDocumento = this.txtSerDoc.Text.Trim();            
            iCtaCte.NumeroDocumento = this.txtNumDoc.Text.Trim();         
            iCtaCte.FechaDocumento =  this.dtpFecDoc.Text;
            iCtaCte.CMonedaDocumento = Cmb.ObtenerValor(this.cmbCMonDoc, string.Empty);         
            iCtaCte.VentaTipoCambio = Conversion.ADecimal(this.txtVenTipCam.Text, 0);         
            //iCtaCte.VentaEurTipoCambio = Conversion.ADecimal(this.txtVenEurTipCam.Text, 0);
            iCtaCte.PorcentajeIgv = Conversion.ADecimal(this.txtPorIgv.Text, 0);         
            iCtaCte.ImporteOriginalCuentaCorriente = Conversion.ADecimal(this.txtPreVenRegConCab.Text, 0);
            //pObj.PrecioVentaRegContabCabe = Conversion.ADecimal(this.txtPreVenRegConCab.Text, 0);
            iCtaCte.ImportePagadoCuentaCorriente = 0; // Conversion.ADecimal(this.txt.Text, 0);           
            iCtaCte.SaldoCuentaCorriente = iCtaCte.ImporteOriginalCuentaCorriente;         
            iCtaCte.CodigoCuenta = this.txtCodCue.Text.Trim();         
            iCtaCte.CEstadoCuentaCorriente = "1";           

            //ejecutar metodo
            CuentaCorrienteRN.AdicionarCuentaCorriente(iCtaCte);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //volver a preguntar si es acto
            if (this.wRegConCab.EsActoModificarRegContabCabe().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wRegConCab.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarRegContabCabe();

            //eliminas regContabDetas anterior
            this.EliminarRegContabDetas();

            //volver a crear los regContabDetas
            this.AdicionarRegContabDetas();
                       
            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Registro compra se modifico correctamente", this.wRegConCab.eTitulo);

            //actualizar al wUsu
            this.wRegConCab.eClaveDgvMovCab = this.ObtenerClaveRegContabCabe();
            this.wRegConCab.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void ModificarRegContabCabe()
        {
            RegContabCabeEN iObjEN = new RegContabCabeEN();
            this.AsignarRegContabCabe(iObjEN);
            iObjEN = RegContabCabeRN.BuscarRegContabCabeXClave(iObjEN);
            this.AsignarRegContabCabe(iObjEN);
            RegContabCabeRN.ModificarRegContabCabe(iObjEN);
        }

        public void EliminarRegContabDetas()
        {
            //asignar parametros
            string iClaveRegContabCabe = this.ObtenerClaveRegContabCabe();

            //ejecutar metodo
            RegContabDetaRN.EliminarRegContabDetasDeClaveRegContabCabe(iClaveRegContabCabe);
        }

        public void Eliminar()
        {
            //volver a preguntar si es acto
            if (this.wRegConCab.EsActoEliminarRegContabCabe().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wRegConCab.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarRegContabCabe();

            //eliminas regContabDetas
            this.EliminarRegContabDetas();

            //eliminar el registro
            this.EliminarCuentaCorriente();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Registro compra se elimino correctamente", this.wRegConCab.eTitulo);

            //actualizar al propietario           
            this.wRegConCab.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void EliminarRegContabCabe()
        {
            RegContabCabeEN iObjEN = new RegContabCabeEN();
            this.AsignarRegContabCabe(iObjEN);
            RegContabCabeRN.EliminarRegContabCabe(iObjEN);
        }

        public void EliminarCuentaCorriente()
        {
            RegContabCabeEN iObjEN = new RegContabCabeEN();
            this.AsignarRegContabCabe(iObjEN);

            CuentaCorrienteRN.EliminarCuentaCorrienteDeRegContabCabe(iObjEN);
        }

        public bool EsCodigoRegContabCabeDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.txtCorRegConCab.ReadOnly == true) { return true; }

            //Asignar parametros
            RegContabCabeEN iRegConCabEN = this.NuevoRegContabCabeDeVentana();

            //ejecutar metodo
            iRegConCabEN = RegContabCabeRN.EsCodigoRegContabCabeDisponible(iRegConCabEN);

            //mensaje de error
            Generico.MostrarMensajeError(iRegConCabEN.Adicionales, this.txtCorRegConCab);

            //mostrar correlativo completo
            this.txtCorRegConCab.Text = RegContabCabeRN.ArmarCorrelativoRegContabCabe(this.txtCorRegConCab.Text.Trim());

            //devolver
            return iRegConCabEN.Adicionales.EsVerdad;
        }

        public void ListarFiles()
        {
            //si es de lectura , entonces no lista
            if (this.txtCFil.ReadOnly == true) { return; }

            //instanciar
            wLisItemE win = new wLisItemE();
            win.eVentana = this;
            win.eTituloVentana = "Files";
            win.eCtrlValor = this.txtCFil;
            win.eCtrlFoco = this.dtpFecRegConCab;
            win.eIteEN.CodigoTabla = "Fil";
            win.eIteEN.CodigoItemE = "4";
            win.eCondicionLista = Listas.wLisItemE.Condicion.ItemsActivosXTablaYFiltroCodigo;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoFileValido()
        {
            return Generico.EsCodigoItemEActivoXFiltroCodigoValido("Fil", this.txtCFil, this.txtNFil, "File", "4");
        }

        public void CambiarCkbAuto()
        {
            Txt.HabilitarParaFiltro(this.txtCorRegConCab, this.ckbAuto.Checked);            
        }

        public void MostrarFechaRegContabCabeSugerida()
        {
            //asignar parametros
            string iPeriodoRegistro = this.wRegConCab.lblPeriodo.Text;
            string iFechaRegContabCabeDtp = Fecha.ObtenerDiaMesAno(this.dtpFecRegConCab.Value);

            //ejecutar metodo
            this.dtpFecRegConCab.Text = RegContabCabeRN.ObtenerFechaRegContabCabeSugerido(iPeriodoRegistro, iFechaRegContabCabeDtp);
        }

        public bool ValidaFechaRegContabCabe()
        {
            //validar solo cuando adiciona y modifica
            if (MiForm.VerdaderoCuandoAdicionaYModifica((int)this.eOperacion) == false) { return true; }

            //asignar parametros
            RegContabCabeEN iRegConCabEN = this.NuevoRegContabCabeDeVentana();

            //ejecutar metodo
            iRegConCabEN = RegContabCabeRN.ValidaCuandoFechaRegContabCabeNoEsDelPeriodoElegido(iRegConCabEN);

            //mensaje de error
            Generico.MostrarMensajeError(iRegConCabEN.Adicionales, this.dtpFecRegConCab);
            
            //devolver
            return iRegConCabEN.Adicionales.EsVerdad;
        }

        public void ListarProveedores()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodAux.ReadOnly == true) { return; }

            //instanciar
            wLisAux win = new wLisAux();
            win.eVentana = this;
            win.eTituloVentana = "Proveedores";
            win.eCtrlValor = this.txtCodAux;
            win.eCtrlFoco = this.txtCTipDoc;
            win.eCondicionLista = Listas.wLisAux.Condicion.ProveedoresActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsProveedorValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodAux.ReadOnly == true) { return true; }

            //asignar parametros
            AuxiliarEN iAuxEN = new AuxiliarEN();
            iAuxEN.CodigoAuxiliar = this.txtCodAux.Text.Trim();

            //ejecutar metodo
            iAuxEN = AuxiliarRN.EsProveedorActivoValido(iAuxEN);

            //mensaje de error
            Generico.MostrarMensajeError(iAuxEN.Adicionales, this.txtCodAux);
            
            //mostrar datos
            this.txtCodAux.Text = iAuxEN.CodigoAuxiliar;
            this.txtDesAux.Text = iAuxEN.DescripcionAuxiliar;

            //devolver
            return iAuxEN.Adicionales.EsVerdad;          
        }

        public void ListarTiposDocumento()
        {
            //si es de lectura , entonces no lista
            if (this.txtCTipDoc.ReadOnly == true) { return; }

            //instanciar
            wLisTipDoc win = new wLisTipDoc();
            win.eVentana = this;
            win.eTituloVentana = "Tipos Documento";
            win.eCtrlValor = this.txtCTipDoc;
            win.eCtrlFoco = this.txtSerDoc;            
            win.eCondicionLista = Listas.wLisTipDoc.Condicion.ComprasActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsTipoDocumentoValido()
        {
            //si es de lectura , entonces no lista
            if (this.txtCTipDoc.ReadOnly == true) { return true; }

            //asignar parametros
            TipoDocumentoEN iTipDocEN = new TipoDocumentoEN();
            iTipDocEN.CodigoTipoDocumento = this.txtCTipDoc.Text.Trim();

            //ejecutar metodo
            iTipDocEN = TipoDocumentoRN.EsTipoDocumentoParaCompraActivoValido(iTipDocEN);

            //mensaje de error
            Generico.MostrarMensajeError(iTipDocEN.Adicionales, this.txtCTipDoc);

            //mostrar datos
            this.txtCTipDoc.Text = iTipDocEN.CodigoTipoDocumento;
            this.txtNTipDoc.Text = iTipDocEN.DescripcionTipoDocumento;
            this.txtCAplDocRef.Text = iTipDocEN.CAplicaDocumentoRef;
            this.txtCTipNot.Text = iTipDocEN.CTipoNota;

            //devolver
            return iTipDocEN.Adicionales.EsVerdad;
        }

        public bool EsDocumentoDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.txtNumDoc.ReadOnly == true) { return true; }

            //Asignar parametros
            RegContabCabeEN iRegConCabEN = this.NuevoRegContabCabeDeVentana();

            //ejecutar metodo
            iRegConCabEN = RegContabCabeRN.ValidaCuandoDocumentoYaExiste(iRegConCabEN);

            //mensaje de error
            Generico.MostrarMensajeError(iRegConCabEN.Adicionales, this.txtNumDoc);

            //mostrar correlativo completo
            this.txtNumDoc.Text = RegContabCabeRN.ArmarNumeroDocumento(this.txtNumDoc.Text.Trim());

            //devolver
            return iRegConCabEN.Adicionales.EsVerdad;
        }

        public void MostrarTipoCambio()
        {
            //cuando el t.d esta solo lectura,entonces termina proceso
            if (this.txtCTipDoc.ReadOnly == true) { return; }

            //asignar parametros
            RegContabCabeEN iRegConCabEN = this.NuevoRegContabCabeDeVentana();

            //ejecutar metodo
            decimal iValor = RegContabCabeRN.ObtenerVentaTipoCambio(iRegConCabEN);

            //mostrar en pantalla
            this.txtVenTipCam.Text = Formato.NumeroDecimal(iValor, 3);
        }

        public void MostrarPorcentajeIgv()
        {
            //ejecutar metodo
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //mostrar en pantalla
            this.txtPorIgv.Text = Formato.NumeroDecimal(iParEN.PorcentajeIgv, 2);
        }

        public void MostrarMontosDocumentos()
        {
            //asignar parametros
            RegContabCabeEN iRegConCabEN = this.NuevoRegContabCabeDeVentana();            
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //ejecutar metodo
            RegContabCabeRN.ActualizarMontosDocumento(iRegConCabEN, iParEN);

            //mostrar en pantalla
            this.txtValVenRegConCab.Text = Formato.NumeroDecimal(iRegConCabEN.ValorVentaRegContabCabe, 2);
            this.txtIgvRegConCab.Text = Formato.NumeroDecimal(iRegConCabEN.IgvRegContabCabe, 2);
            this.txtExoRegConCab.Text = Formato.NumeroDecimal(iRegConCabEN.ExoneradoRegContabCabe, 2);
            this.txtInaRegConCab.Text = Formato.NumeroDecimal(iRegConCabEN.InafectoRegContabCabe, 2);
            this.txtPreVenRegConCab.Text = Formato.NumeroDecimal(iRegConCabEN.PrecioVentaRegContabCabe, 2);
        }

        public void HabilitarControlesMontosDocumento()
        {
            //asignar parametros
            RegContabCabeEN iRegConCabEN = this.NuevoRegContabCabeDeVentana();
            
            //ejecutar metodos
            Txt.SoloEscritura3(this.txtPreVenRegConCab, !RegContabCabeRN.EsEditablePrecioVenta(iRegConCabEN));
            Txt.SoloEscritura3(this.txtExoRegConCab, !RegContabCabeRN.EsEditableExonerado(iRegConCabEN));
            Txt.SoloEscritura3(this.txtInaRegConCab, !RegContabCabeRN.EsEditableInafecto(iRegConCabEN));
            Txt.SoloEscritura3(this.txtIgvRegConCab, !RegContabCabeRN.EsEditableIgv(iRegConCabEN));
            Txt.SoloEscritura3(this.txtValVenRegConCab, !RegContabCabeRN.EsEditableValorVenta(iRegConCabEN));
            Cmb.Habilitar(this.cmbCAplIgv, RegContabCabeRN.EsEditableAplicaIgv(iRegConCabEN), "0", "1");
        }

        public void HabilitarControlesDocumentoReferencia()
        {
            //ejecutar metodo
            bool iValor = Conversion.CadenaABoolean(this.txtCAplDocRef.Text.Trim(), false);

            //habilitar
            Txt.SoloEscritura(this.txtCTipDocRef, !iValor);
            Txt.Limpiar(this.txtNTipDocRef, !iValor);
            Txt.SoloEscritura(this.txtSerDocRef, !iValor);
            Txt.SoloEscritura(this.txtNumDocRef, !iValor);
            Txt.Limpiar(this.txtCMonDocRef, !iValor);
            Txt.Limpiar(this.txtNMonDocRef, !iValor);
            Txt.Limpiar(this.txtFecDocRef, !iValor);
        }

        public void ListarTiposDocumentoReferencia()
        {
            //si es de lectura , entonces no lista
            if (this.txtCTipDocRef.ReadOnly == true) { return; }

            //instanciar
            wLisTipDoc win = new wLisTipDoc();
            win.eVentana = this;
            win.eTituloVentana = "Tipos Documento";
            win.eCtrlValor = this.txtCTipDocRef;
            win.eCtrlFoco = this.txtSerDocRef;
            win.eCondicionLista = Listas.wLisTipDoc.Condicion.ComprasActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();            
        }

        public bool EsTipoDocumentoReferenciaValido()
        {
            //si es de lectura , entonces no lista
            if (this.txtCTipDocRef.ReadOnly == true) { return true; }

            //asignar parametros
            TipoDocumentoEN iTipDocEN = new TipoDocumentoEN();
            iTipDocEN.CodigoTipoDocumento = this.txtCTipDocRef.Text.Trim();

            //ejecutar metodo
            iTipDocEN = TipoDocumentoRN.EsTipoDocumentoParaCompraActivoValido(iTipDocEN);

            //mensaje de error
            Generico.MostrarMensajeError(iTipDocEN.Adicionales, this.txtCTipDocRef);

            //mostrar datos
            this.txtCTipDocRef.Text = iTipDocEN.CodigoTipoDocumento;
            this.txtNTipDocRef.Text = iTipDocEN.DescripcionTipoDocumento;
            
            //devolver
            return iTipDocEN.Adicionales.EsVerdad;
        }

        public bool EsDocumentoReferenciaValido()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.txtNumDocRef.ReadOnly == true) { return true; }

            //Asignar parametros
            RegContabCabeEN iRegConCabEN = this.NuevoRegContabCabeDeVentana();

            //ejecutar metodo
            iRegConCabEN = RegContabCabeRN.EsDocumentoReferenciaValido(iRegConCabEN);

            //mensaje de error
            Generico.MostrarMensajeError(iRegConCabEN.Adicionales, this.txtNumDocRef);

            //mostrar datos
            this.txtNumDocRef.Text = RegContabCabeRN.ArmarNumeroDocumento(this.txtNumDocRef.Text.Trim());
            this.txtCMonDocRef.Text = iRegConCabEN.CMonedaDocumento;
            this.txtNMonDocRef.Text = iRegConCabEN.NMonedaDocumento;
            this.txtFecDocRef.Text = iRegConCabEN.FechaDocumento;

            //devolver
            return iRegConCabEN.Adicionales.EsVerdad;
        }

        public void HabilitarControlesDetraccion()
        {
            //ejecutar metodo
            bool iValor = Conversion.CadenaABoolean(Cmb.ObtenerValor(this.cmbCAplDet, "0"), false);

            //habilitar
            Dtp.Habilitar(this.dtpFecDet, iValor);
            Txt.SoloEscritura(this.txtNumPapDet, !iValor);            
        }

        public void HabilitarControlCuentaPV()
        {
            //ejecutar metodo
            bool iValor = Cadena.CompararDosValores(Cmb.ObtenerValor(this.cmbCTipCom, "0"), ItemGEN.TipoCompra_Normal, true, false);
            
            //habilitar
            Txt.SoloEscritura(this.txtCodCue, !iValor);
            Txt.Limpiar(this.txtCodCue, !iValor);            
            Txt.Limpiar(this.txtDesCue, !iValor);
        }

        public void ListarCuentas()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodCue.ReadOnly == true) { return; }

            //instanciar
            wLisCue win = new wLisCue();
            win.eVentana = this;
            win.eTituloVentana = "Cuentas";
            win.eCtrlValor = this.txtCodCue;
            win.eCtrlFoco = this.btnAgregar;
            Universal.gMonedaCompra = this.cmbCMonDoc.SelectedValue.ToString();
             
            win.eCondicionLista = Listas.wLisCue.Condicion.CuentasAnaliticasParaRegistroCompraPVMonedaActivas;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCuentaValido()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodCue.ReadOnly == true) { return true; }

            //asignar parametros
            CuentaEN iCueEN = new CuentaEN();
            iCueEN.CodigoCuenta = this.txtCodCue.Text.Trim();

            //ejecutar metodo
            iCueEN = CuentaRN.EsCuentaParaRegistroCompraPVValido(iCueEN);

            //mensaje de error
            Generico.MostrarMensajeError(iCueEN.Adicionales, this.txtCodCue);

            //mostrar datos
            this.txtCodCue.Text = iCueEN.CodigoCuenta;
            this.txtDesCue.Text = iCueEN.DescripcionCuenta;
            
            //devolver
            return iCueEN.Adicionales.EsVerdad;
        }

        public void MostrarFechasDocumentoSugeridas()
        {
            //valida cuando el file es solo lectura
            if (this.txtCFil.ReadOnly == true) { return; }

            //modificar datos
            this.dtpFecDoc.Text = this.dtpFecRegConCab.Text;
            this.dtpFecVctDoc.Text = this.dtpFecRegConCab.Text;
        }

        public void MostrarImporteTotal()
        {
            //asignar parametros
            RegContabCabeEN iRegConCabEN = this.NuevoRegContabCabeDeVentana();

            //ejecutar metodo
            decimal iValor = RegContabCabeRN.ObtenerImporteTotalDistribucion(iRegConCabEN);

            //mostrar en pantalla
            this.txtImpTotDis.Text = Formato.NumeroDecimal(iValor, 2);
        }

        public void MostrarImporteTotalSol()
        {
            //asignar parametros
            RegContabCabeEN iRegConCabEN = this.NuevoRegContabCabeDeVentana();

            //ejecutar metodo
            decimal iValor = RegContabCabeRN.ObtenerImporteTotalSolesDistribucion(iRegConCabEN);

            //mostrar en pantalla
            this.txtImpTotDisSol.Text = Formato.NumeroDecimal(iValor, 2);
        }

        public void MostrarImporte1()
        {
            //asignar parametros
            RegContabCabeEN iRegConCabEN = this.NuevoRegContabCabeDeVentana();

            //ejecutar metodo
            decimal iValor = RegContabCabeRN.ObtenerImporte1(iRegConCabEN, eLisRegConDet);

            //mostrar en pantalla
            this.txtImp1.Text = Formato.NumeroDecimal(iValor, 2);
        }

        public void MostrarImporte2()
        {
            //asignar parametros
            RegContabCabeEN iRegConCabEN = this.NuevoRegContabCabeDeVentana();
            decimal iImpTotSol = Conversion.ADecimal(this.txtImp1.Text, 0);

            //ejecutar metodo
            decimal iValor = RegContabCabeRN.ObtenerImporte2(iRegConCabEN, iImpTotSol, eLisRegConDet);

            //mostrar en pantalla
            this.txtImp2.Text = Formato.NumeroDecimal(iValor, 2);

            if (wSaldo == "Visualizar")
            {
                this.txtImp2.Text = "0.00";
            }
            
        }

        public void CambiarTextoAlCambiarTipoCompra()
        {
            //asignar parametros
            string iCTipoCompra = Cmb.ObtenerValor(this.cmbCTipCom, string.Empty);

            //ejecutar metodos
            this.lblImp1.Text = Cadena.CompararDosValores(iCTipoCompra, "0", "Importe Total S/.", "Debe S/.");
            this.lblImp2.Text = Cadena.CompararDosValores(iCTipoCompra, "0", "Saldo S/.", "Haber S/.");
        }

        public void CambiarVisibilidadAlCambiarTipoCompra()
        {
            //asignar parametros
            string iCTipoCompra = Cmb.ObtenerValor(this.cmbCTipCom, string.Empty);

            //ejecutar metodos
            this.lblImpTotDisSol.Visible = Cadena.CompararDosValores(iCTipoCompra, ItemGEN.TipoCompra_Normal, false, true);
            this.txtImpTotDisSol.Visible = Cadena.CompararDosValores(iCTipoCompra, ItemGEN.TipoCompra_Normal, false, true);
        }

        public void MostrarCalculosDistribucion()
        {
            this.MostrarImporteTotal();
            this.MostrarImporteTotalSol();
            this.CambiarTextoAlCambiarTipoCompra();
            this.CambiarVisibilidadAlCambiarTipoCompra();
            this.MostrarImporte1();
            this.MostrarImporte2();
        }

        public void AccionAgregarItem()
        {
            //validar si se puede adicionar
            RegContabDetaEN iRegConDetEN = this.EsActoAdicionarRegContabDeta();
            if (iRegConDetEN.Adicionales.EsVerdad == false) { return; }

            //instanciar
            wDetalleRegistroCompra win = new wDetalleRegistroCompra();
            win.wEdiRegCom = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvMovDet = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }

        public void AccionModificarItem()
        {
            //ver si hay registro
            if(Dgv.ValidaCuandoGrillaEstaVacia(this.dgvRegConDet) == false) { return; }

            //instanciar
            wDetalleRegistroCompra win = new wDetalleRegistroCompra();
            win.wEdiRegCom = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvMovDet = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(this.eLisRegConDet[Dgv.ObtenerIndiceRegistroXFranja(this.dgvRegConDet)]);
        }

        public void AccionQuitarItem()
        {
            //ver si hay registro
            if (Dgv.ValidaCuandoGrillaEstaVacia(this.dgvRegConDet) == false) { return; }

            //instanciar
            wDetalleRegistroCompra win = new wDetalleRegistroCompra();
            win.wEdiRegCom = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvMovDet = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(this.eLisRegConDet[Dgv.ObtenerIndiceRegistroXFranja(this.dgvRegConDet)]);
        }

        public RegContabDetaEN EsActoAdicionarRegContabDeta()
        {
            //asignar parametros
            RegContabCabeEN iRegConCabEN = this.NuevoRegContabCabeDeVentana();

            //ejecutar metodo
            RegContabDetaEN iRegConDetEN = RegContabDetaRN.EsActoParaEditarNuevoRegContabDeta(iRegConCabEN, this.eLisRegConDet);

            //mensaje error
            Generico.MostrarMensajeError(iRegConDetEN.Adicionales);

            //devolver
            return iRegConDetEN;
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wRegConCab.eTitulo);
        }


        #endregion

        private void wEditRegistroCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wRegConCab.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void txtCFil_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarFiles(); }
        }

        private void txtCFil_DoubleClick(object sender, EventArgs e)
        {
            this.ListarFiles();
        }

        private void txtCFil_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoFileValido();
        }

        private void ckbAuto_CheckedChanged(object sender, EventArgs e)
        {
            this.CambiarCkbAuto();
        }

        private void txtCorRegConCab_Validated(object sender, EventArgs e)
        {            
            this.EsCodigoRegContabCabeDisponible();
        }

        private void dtpFecRegConCab_Validated(object sender, EventArgs e)
        {
            this.ValidaFechaRegContabCabe();
            this.MostrarFechasDocumentoSugeridas();
            this.MostrarTipoCambio();
        }

        private void txtCodAux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarProveedores(); }
        }

        private void txtCodAux_DoubleClick(object sender, EventArgs e)
        {
            this.ListarProveedores();
        }

        private void txtCodAux_Validating(object sender, CancelEventArgs e)
        {
            this.EsProveedorValido();
        }

        private void txtCTipDoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarTiposDocumento(); }
        }

        private void txtCTipDoc_DoubleClick(object sender, EventArgs e)
        {
            this.ListarTiposDocumento();
        }

        private void txtCTipDoc_Validating(object sender, CancelEventArgs e)
        {
            this.EsTipoDocumentoValido();
        }

        private void txtSerDoc_Validated(object sender, EventArgs e)
        {
            this.txtSerDoc.Text = RegContabCabeRN.ArmarSerieDocumento(this.txtSerDoc.Text.Trim());
            this.EsDocumentoRegistrado();
        }

        private void txtNumDoc_Validated(object sender, EventArgs e)
        {
            this.EsDocumentoDisponible();
            this.EsDocumentoRegistrado();
        }

        private void cmbCMonDoc_Validating(object sender, CancelEventArgs e)
        {
            this.MostrarTipoCambio();
            this.MostrarCalculosDistribucion();
        }

        private void dtpFecDoc_Validating(object sender, CancelEventArgs e)
        {
            this.MostrarTipoCambio();
            this.MostrarCalculosDistribucion();
        }
        
        private void txtCTipDoc_Validated(object sender, EventArgs e)
        {
            this.MostrarMontosDocumentos();            
            this.HabilitarControlesMontosDocumento();
            this.HabilitarControlesDocumentoReferencia();
            this.MostrarCalculosDistribucion();
        }

        private void txtPreVenRegConCab_Validated(object sender, EventArgs e)
        {
            this.MostrarMontosDocumentos();            
            this.HabilitarControlesMontosDocumento();
            this.MostrarCalculosDistribucion();
        }

        private void txtExoRegConCab_Validated(object sender, EventArgs e)
        {
            this.MostrarMontosDocumentos();           
            this.HabilitarControlesMontosDocumento();
            this.MostrarCalculosDistribucion();
        }

        private void txtInaRegConCab_Validated(object sender, EventArgs e)
        {
            this.MostrarMontosDocumentos();            
            this.HabilitarControlesMontosDocumento();
            this.MostrarCalculosDistribucion();
        }

        private void txtValVenRegConCab_Validated(object sender, EventArgs e)
        {
            this.MostrarMontosDocumentos();            
            this.HabilitarControlesMontosDocumento();
            this.MostrarCalculosDistribucion();
        }

        private void txtIgvRegConCab_Validated(object sender, EventArgs e)
        {
            this.MostrarMontosDocumentos();           
            this.HabilitarControlesMontosDocumento();
            this.MostrarCalculosDistribucion();
        }

        private void cmbCAplIna_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.MostrarMontosDocumentos();            
            this.HabilitarControlesMontosDocumento();
            this.MostrarCalculosDistribucion();
        }

        private void txtCFil_Validated(object sender, EventArgs e)
        {
            
        }

        private void txtCTipDocRef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarTiposDocumentoReferencia(); }
        }

        private void txtCTipDocRef_DoubleClick(object sender, EventArgs e)
        {
            this.ListarTiposDocumentoReferencia();
        }

        private void txtCTipDocRef_Validating(object sender, CancelEventArgs e)
        {
            this.EsTipoDocumentoReferenciaValido();
        }

        private void txtSerDocRef_Validated(object sender, EventArgs e)
        {
            this.txtSerDocRef.Text = RegContabCabeRN.ArmarSerieDocumento(this.txtSerDocRef.Text.Trim());
        }

        private void txtNumDocRef_Validated(object sender, EventArgs e)
        {
            this.EsDocumentoReferenciaValido();
            this.MostrarTipoCambio();
            this.MostrarCalculosDistribucion();
        }

        private void cmbCAplDet_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.HabilitarControlesDetraccion();
        }

        private void cmbCTipCom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.MostrarMontosDocumentos();
            this.HabilitarControlesMontosDocumento();
            this.HabilitarControlCuentaPV();
            this.MostrarCalculosDistribucion();
        }

        private void txtCodCue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarCuentas(); }
        }

        private void txtCodCue_DoubleClick(object sender, EventArgs e)
        {
            this.ListarCuentas();
        }

        private void txtCodCue_Validating(object sender, CancelEventArgs e)
        {
            this.EsCuentaValido();
        }

        private void cmbCAplIgv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.MostrarCalculosDistribucion();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.AccionAgregarItem();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.AccionModificarItem();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            this.AccionQuitarItem();
        }       

        private void cmbCModCom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.EfectoModoCompra();            
        }

        private void txtCodAux_Validated(object sender, EventArgs e)
        {
            this.EsDocumentoRegistrado();
        }

        
    }
}
