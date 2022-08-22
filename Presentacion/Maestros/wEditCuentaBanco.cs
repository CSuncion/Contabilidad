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

namespace Presentacion.Maestros
{
    public partial class wEditCuentaBanco : Heredados.MiForm8
    {
        public wEditCuentaBanco()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();

        #endregion

        #region Propietario

        public wCuentaBanco wCueBan;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCodCueBan, this.txtCodBan, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesCueBan, this.txtCodBan, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNMon, this.txtCodBan, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodBan, false, "Banco", "vvff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNomBan, this.txtCodBan, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNumCueBan, false, "Numero Cuenta", "vvff", 20);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCTip, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtSalCueBan, false, "Saldo", "vvff", 2, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCEstCueBan, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAceptar, "vvvf");
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
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wCueBan.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //llenar Combos
            this.CargarCTipo();
            this.CargarCEstadoCuentaBanco();

            //deshabilitar al propietario
            this.wCueBan.Enabled = false;

            //mostrar ventana
            this.Show();
        }

        public void CargarCTipo()
        {
            Cmb.Cargar(this.cmbCTip, ItemGRN.ListarItemsG("TiPCB"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCEstadoCuentaBanco()
        {
            Cmb.Cargar(this.cmbCEstCueBan, ItemGRN.ListarItemsG("EstReg"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarCuentaBanco(CuentaBancoRN.EnBlanco());
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodBan.Focus();
        }

        public void VentanaModificar(CuentaBancoEN pObj)
        {
            this.InicializaVentana();
            this.MostrarCuentaBanco(pObj);
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodBan.Focus();
        }

        public void VentanaEliminar(CuentaBancoEN pObj)
        {
            this.InicializaVentana();
            this.MostrarCuentaBanco(pObj);
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(CuentaBancoEN pObj)
        {
            this.InicializaVentana();
            this.MostrarCuentaBanco(pObj);
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }

        public void AsignarCuentaBanco(CuentaBancoEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.CodigoCuentaBanco = this.txtCodCueBan.Text.Trim();
            pObj.CodigoBanco = this.txtCodBan.Text.Trim();
            pObj.NumeroCuentaBanco = this.txtNumCueBan.Text.Trim();
            pObj.CTipo = Cmb.ObtenerValor(this.cmbCTip, string.Empty);
            pObj.SaldoCuentaBanco = Conversion.ADecimal(this.txtSalCueBan.Text, 0);
            pObj.CEstadoCuentaBanco = Cmb.ObtenerValor(this.cmbCEstCueBan, string.Empty);
            pObj.ClaveCuentaBanco = CuentaBancoRN.ObtenerClaveCuentaBanco(pObj);
        }

        public void MostrarCuentaBanco(CuentaBancoEN pObj)
        {
            this.txtCodCueBan.Text = pObj.CodigoCuentaBanco;
            this.txtDesCueBan.Text = pObj.DescripcionCuentaBanco;
            this.txtNMon.Text = pObj.NMoneda;
            this.txtCodBan.Text = pObj.CodigoBanco;
            this.txtNomBan.Text = pObj.NombreBanco;
            this.txtNumCueBan.Text = pObj.NumeroCuentaBanco;
            Cmb.SeleccionarValorItem(this.cmbCTip, pObj.CTipo);
            this.txtSalCueBan.Text = Formato.NumeroDecimal(pObj.SaldoCuentaBanco, 2);
            Cmb.SeleccionarValorItem(this.cmbCEstCueBan, pObj.CEstadoCuentaBanco);
        }

        public void Aceptar()
        {
            switch (this.eOperacion)
            {               
                case Universal.Opera.Modificar: { this.Modificar(); break; }            
                default: break;
            }
        }
           
        public string ObtenerClaveCuentaBanco()
        {
            CuentaBancoEN iObjEN = new CuentaBancoEN();
            this.AsignarCuentaBanco(iObjEN);
            return iObjEN.ClaveCuentaBanco;
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //volver a preguntar si es acto
            if (this.wCueBan.EsActoModificarCuentaBanco().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wCueBan.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarCuentaBanco();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("La Cuenta Banco se modifico correctamente", this.wCueBan.eTitulo);

            //actualizar al wUsu
            this.wCueBan.eClaveDgvCueBan = this.ObtenerClaveCuentaBanco();
            this.wCueBan.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void ModificarCuentaBanco()
        {
            CuentaBancoEN iObjEN = new CuentaBancoEN();
            this.AsignarCuentaBanco(iObjEN);
            iObjEN = CuentaBancoRN.BuscarCuentaBancoXClave(iObjEN);
            this.AsignarCuentaBanco(iObjEN);
            CuentaBancoRN.ModificarCuentaBanco(iObjEN);
        }

        public void ListarBancos()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodBan.ReadOnly == true) { return; }

            //instanciar
            wLisItemG win = new wLisItemG();
            win.eVentana = this;
            win.eTituloVentana = "Bancos";
            win.eCtrlValor = this.txtCodBan;
            win.eCtrlFoco = this.txtNumCueBan;
            win.eIteEN.CodigoTabla = "Banco";
            win.eCondicionLista = Listas.wLisItemG.Condicion.ItemsActivosXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsBancoValido()
        {
            return Generico.EsCodigoItemGValido("Banco", this.txtCodBan, this.txtNomBan, "Banco");
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wCueBan.eTitulo);
        }


        #endregion

        private void wEditCuentaBanco_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wCueBan.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void txtCodBan_Validating(object sender, CancelEventArgs e)
        {
            this.EsBancoValido();
        }

        private void txtCodBan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarBancos(); }
        }

        private void txtCodBan_DoubleClick(object sender, EventArgs e)
        {
            this.ListarBancos();
        }
    }
}
