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
    public partial class wAgregarItemCajaBanco : Heredados.MiForm8
    {
        //variables
        public Universal.Opera eOperacion;
        public int wMoneda = 0;
        Masivo eMas = new Masivo();
        string eTitulo = "Item";
        string eNombreColumnaDgvTipOpe = TipoCambioEN.FecTipCam;
        public List<TipoCambioEN> eLisTipCam = new List<TipoCambioEN>();

        public wEditCajaBanco wEditCajBco;

        public wAgregarItemCajaBanco()
        {
            InitializeComponent();
        }

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodCta, false, "Cuenta", "vvff", 11);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesCta, this.txtCodCta, "ffff");
            xLis.Add(xCtrl);


            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAux, false, "Proveedor", "vvff", 11);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAux, this.txtCodAux, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodCCosto, false, "Centro Costo", "vvff", 11);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesCCosto, this.txtCodCCosto, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodTD, false, "T.D", "vvff", 2);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesTD, this.txtCodTD, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtSerDoc, false, "Serie", "vvff", 4);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecDoc, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNumDoc, false, "N.D", "vvff", 15);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbMon, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtTipCam, false, "Tipo Cambio", "vvff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbMon, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtImpSol, false, "Importe Soles", "vvff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtGloIteCajBco, false, "Glosa", "vvff", 100);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodFluEfe, false, "Flujo Efectivo", "vvff", 11);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesFluEfe, this.txtCodFluEfe, "ffff");
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
            this.InicializaVentana();
            this.Text = Universal.Opera.Adicionar.ToString() + Cadena.Espacios(1) + this.eTitulo;
            this.MostrarCajaBancoDeta(RegContabDetaRN.EnBlanco());
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodCta.Focus();
        }
        public void InicializaVentana()
        {
            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //llenar combos
            this.CargarMonedas();
            this.CargarDebeHaber();

            //deshabilita propietario
            this.wEditCajBco.Enabled = false;
            if (wEditCajBco.txtCodMonSyD.Text == "0")  //Soles
            {
                //this.txtPreUniDol.Enabled = false;
            }
            else
            {
                //this.txtPreUniDol.Enabled = true;
            }

            //ver ventana
            this.Show();
        }
        public void MostrarCajaBancoDeta(RegContabDetaEN pObj)
        {
            this.txtCodCta.Text = pObj.CodigoCuenta;
            this.txtDesCta.Text = pObj.DescripcionCuenta;
            this.txtCodAux.Text = pObj.CodigoAuxiliar;
            this.txtDesAux.Text = pObj.DescripcionAuxiliar;
            this.txtCodCCosto.Text = pObj.CCentroCosto;
            this.txtDesCCosto.Text = pObj.NCentroCosto;
            this.txtCodTD.Text = pObj.CTipoDocumento;
            this.txtDesTD.Text = pObj.NTipoDocumento;
            this.txtSerDoc.Text = pObj.SerieDocumento;
            this.dtpFecDoc.Text = pObj.FechaDocumento;
            this.txtNumDoc.Text = pObj.NumeroDocumento;
            Cmb.SeleccionarValorItem(this.cmbMon, pObj.CMoneda);
            this.txtTipCam.Text = Formato.NumeroDecimal(pObj.VentaTipoCambio, 3);
            this.txtCodMonSyD.Text = pObj.CMonedaDocumento;
            Cmb.SeleccionarValorItem(this.cmbDebHab, pObj.CDebeHaber);
            this.txtImpSol.Text = Formato.NumeroDecimal(pObj.ImporteSolRegContabDeta, 3);
            this.txtGloIteCajBco.Text = pObj.GlosaRegContabDeta;
            this.txtCodFluEfe.Text = pObj.CFlujoCaja;
            this.txtDesFluEfe.Text = pObj.NFlujoCaja;
        }
        public void ListarCuenta()
        {
            //si es de lectura , entonces no lista
            if (txtCodCta.ReadOnly == true) { return; }

            //instanciar
            wLisCue win = new wLisCue();
            win.eVentana = this;
            win.eTituloVentana = "Cuenta";
            win.eCtrlValor = this.txtCodCta;
            win.eCtrlFoco = this.txtCodAux;
            win.eCondicionLista = Listas.wLisCue.Condicion.CuentasAnaliticasActivas;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }
        public bool EsCuentaValido()
        {
            if (txtCodCta.ReadOnly) { return false; }

            CuentaEN iCta = new CuentaEN();
            iCta.CodigoCuenta = this.txtCodCta.Text.Trim();
            iCta = CuentaRN.EsCuentaActivoValido(iCta);
            if (iCta.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCta.Adicionales.Mensaje, (this.eTitulo));
                this.txtCodCta.Focus();
            }

            //mostrar datos
            this.txtCodCta.Text = iCta.CodigoCuenta;
            this.txtDesCta.Text = iCta.DescripcionCuenta;


            //devolver
            return iCta.Adicionales.EsVerdad;
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
            win.eCtrlFoco = this.txtCodCCosto;
            win.eCondicionLista = Listas.wLisAux.Condicion.ProveedoresActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsProveedorValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodAux.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            AuxiliarEN iAuxEN = new AuxiliarEN();
            iAuxEN.CodigoAuxiliar = this.txtCodAux.Text.Trim();
            iAuxEN = AuxiliarRN.EsProveedorActivoValido(iAuxEN);
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, (this.wEditCajBco.eTitulo));
                this.txtCodAux.Focus();
            }

            //mostrar datos
            this.txtCodAux.Text = iAuxEN.CodigoAuxiliar;
            this.txtDesAux.Text = iAuxEN.DescripcionAuxiliar;

            //devolver
            return iAuxEN.Adicionales.EsVerdad;
        }

        public void ListarCentroCosto()
        {
            //si es de lectura , entonces no lista
            if (txtCodCCosto.ReadOnly == true) { return; }

            //instanciar
            wLisItemE win = new wLisItemE();
            win.eVentana = this;
            win.eTituloVentana = "Centro Costo";
            win.eCtrlValor = this.txtCodCCosto;
            win.eCtrlFoco = this.txtCodTD;
            win.eIteEN.CodigoTabla = "CenCos";
            win.eCondicionLista = Listas.wLisItemE.Condicion.ItemsActivosXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }
        public bool EsCentroCostoValido()
        {
            return Generico.EsCodigoItemEValido("CenCos", this.txtCodCCosto, this.txtDesCCosto, "Centro Costo");
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
            win.eCtrlFoco = this.txtSerDoc;
            win.eIteEN.CodigoTabla = "TipDoc";
            win.eCondicionLista = Listas.wLisItemG.Condicion.ItemsActivosXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }
        public bool EsTipoDocumentoValido()
        {
            return Generico.EsCodigoItemGValido("TipDoc", this.txtCodTD, this.txtDesTD, "Tipo Documento");
        }

        public void CargarMonedas()
        {
            Cmb.Cargar(this.cmbMon, ItemGRN.ListarItemsG("Moneda"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarDebeHaber()
        {
            Cmb.Cargar(this.cmbDebHab, ItemGRN.ListarItemsG("DeHa"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void ListarFlujoEfectivo()
        {
            //si es de lectura , entonces no lista
            if (txtCodTD.ReadOnly == true) { return; }

            //instanciar
            wLisItemG win = new wLisItemG();
            win.eVentana = this;
            win.eTituloVentana = "Flujo Efectivo";
            win.eCtrlValor = this.txtCodFluEfe;
            win.eCtrlFoco = this.btnAceptar;
            win.eIteEN.CodigoTabla = "FluEfe";
            win.eCondicionLista = Listas.wLisItemG.Condicion.ItemsActivosXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }
        public bool EsFlujoEfectivoValido()
        {
            return Generico.EsCodigoItemGValido("FluEfe", this.txtCodFluEfe, this.txtDesFluEfe, "Flujo Efectivo");
        }

        public void Aceptar()
        {
            switch (this.eOperacion)
            {
                case Universal.Opera.Adicionar: { this.Adicionar(); break; }
                //case Universal.Opera.Modificar: { this.Modificar(); break; }
                //case Universal.Opera.Eliminar: { this.Eliminar(); break; }
                default: break;
            }
        }

        public void Adicionar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //adicionar RegContab
            this.AdicionarCajaBancoDeta();

            //adicionar lotes para la existencia
            //this.AdicionarLotesExistencia();

            //mensaje
            Mensaje.OperacionSatisfactoria("Se adiciono el registro", "Detalle");

            //actualizar propietario
            this.wEditCajBco.eClaveDgvCajBanDet = this.wEditCajBco.eLisCajBanDet[this.wEditCajBco.eLisCajBanDet.Count - 1].ClaveObjeto;
            this.wEditCajBco.MostrarCajaBancoDeta();
            //this.wEditCajBco.CambiarSoloLecturaACodigoAlmacen();
            //this.wEditCajBco.CambiarSoloLecturaACodigoTipoOperacion();

            //limpiar controles
            this.MostrarCajaBancoDeta(RegContabDetaRN.EnBlanco());
            //this.HabilitarControlesSegunPropiedadLote("");          
            //this.CambiarAtributoSoloLecturaACodigoExistencia();
            //this.eLisLotExi.Clear();
            eMas.AccionPasarTextoPrincipal();
            this.txtCodCta.Focus();
        }

        public void AdicionarCajaBancoDeta()
        {
            RegContabDetaEN iComDetEN = new RegContabDetaEN();
            this.AsignarMovimientoDeta(iComDetEN);

            //adicionar detalle
            RegContabDetaRN.AdicionarRegContabDeta(this.wEditCajBco.eLisCajBanDet, iComDetEN);
        }

        public void AsignarMovimientoDeta(RegContabDetaEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.PeriodoRegContabCabe = this.wEditCajBco.wCajBco.lblPeriodo.Text;
            pObj.CodigoAuxiliar = this.txtCodAux.Text;
            pObj.CTipoDocumento = this.txtCodTD.Text;
            pObj.NTipoDocumento = this.txtDesTD.Text;
            pObj.SerieDocumento = this.txtSerDoc.Text;
            pObj.NumeroDocumento = this.txtNumDoc.Text;
            pObj.FechaDocumento = this.dtpFecDoc.Text;
            pObj.CMonedaDocumento = Cmb.ObtenerValor(this.cmbMon, string.Empty);
            pObj.VentaTipoCambio = Conversion.ADecimal(this.txtTipCam.Text, 3);
            pObj.CodigoCuenta = this.txtCodCta.Text;
            pObj.DescripcionCuenta = this.txtDesCta.Text;
            pObj.CMoneda = Cmb.ObtenerValor(this.cmbMon, string.Empty);
            pObj.CCentroCostoCuenta = this.txtCodCCosto.Text;
            pObj.CAuxiliar = this.txtCodAux.Text;
            pObj.DescripcionAuxiliar = this.txtDesAux.Text;
            pObj.CDebeHaber = Cmb.ObtenerValor(this.cmbDebHab, string.Empty);
            pObj.NDebeHaber = Cmb.ObtenerTexto(this.cmbDebHab);
            pObj.ImporteSolRegContabDeta = Conversion.ADecimal(this.txtImpSol.Text, 2);
            pObj.ImporteMonedaRegContabDeta = 0;
            pObj.GlosaRegContabDeta = this.txtGloIteCajBco.Text;
            pObj.CCentroCosto = this.txtCodCCosto.Text;
            pObj.CFlujoCaja = this.txtCodFluEfe.Text;
            pObj.CTipoLineaAsiento = ItemGEN.TipoLineaAsiento_Editado;
            pObj.CEstadoRegContabDeta = "1";
            pObj.ClaveRegContabCabe = this.wEditCajBco.ObtenerClaveCajaBcoCabe();
        }

        public void CargarTipoCambio()
        {
            decimal tipCam = 0;
            TipoCambioEN objTipCam = new TipoCambioEN();
            objTipCam.Adicionales.CampoOrden = eNombreColumnaDgvTipOpe;
            eLisTipCam = TipoCambioRN.ListarTipoCambios(objTipCam);

            string fechaTipoCambio = Fecha.ObtenerDiaMesAno(Conversion.ADateTime(dtpFecDoc.Text));

            if (eLisTipCam.Where(e => e.FechaTipoCambio == fechaTipoCambio).Count() == 0)
            {
                Mensaje.OperacionDenegada("Se debe ingresar un tipo de cambio para la fecha del documento.", this.wEditCajBco.wCajBco.eTitulo);
                txtTipCam.Text = Formato.NumeroDecimal(0, 4);
            }
            else
                txtTipCam.Text = eLisTipCam.FirstOrDefault(e => e.FechaTipoCambio == fechaTipoCambio).VentaUsTipoCambio.ToString();

        }

        private void txtCodCta_Validating(object sender, CancelEventArgs e)
        {
            this.EsCuentaValido();
        }

        private void txtCodCta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarCuenta(); }
        }

        private void txtCodCta_DoubleClick(object sender, EventArgs e)
        {
            this.ListarCuenta();
        }

        private void txtCodAux_Validating(object sender, CancelEventArgs e)
        {
            this.EsProveedorValido();
        }

        private void txtCodAux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarProveedores(); }
        }

        private void txtCodAux_DoubleClick(object sender, EventArgs e)
        {
            this.ListarProveedores();
        }

        private void txtCodCCosto_Validating(object sender, CancelEventArgs e)
        {
            this.EsCentroCostoValido();
        }

        private void txtCodCCosto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarCentroCosto(); }
        }

        private void txtCodCCosto_DoubleClick(object sender, EventArgs e)
        {
            this.ListarCentroCosto();
        }

        private void txtCodTD_Validating(object sender, CancelEventArgs e)
        {
            this.EsTipoDocumentoValido();
        }

        private void txtCodTD_DoubleClick(object sender, EventArgs e)
        {
            this.ListarTipoDocumento();
        }

        private void txtCodTD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarTipoDocumento(); }
        }

        private void txtCodFluEfe_Validating(object sender, CancelEventArgs e)
        {
            this.EsFlujoEfectivoValido();
        }

        private void txtCodFluEfe_MouseClick(object sender, MouseEventArgs e)
        {
            this.ListarFlujoEfectivo();
        }

        private void txtCodFluEfe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarFlujoEfectivo(); }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void dtpFecDoc_Validated(object sender, EventArgs e)
        {
            this.CargarTipoCambio();
        }
    }
}
