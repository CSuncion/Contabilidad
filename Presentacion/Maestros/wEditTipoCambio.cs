using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinControles;
using Comun;
using WinControles.ControlesWindows;
using Entidades.Adicionales;
using Negocio;
using Entidades;
using Presentacion.FuncionesGenericas;
using Presentacion.Utilidades;

namespace Presentacion.Maestros
{
    public partial class wEditTipoCambio : Heredados.MiForm8
    {
        public wEditTipoCambio()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();

        #endregion

        #region Propietario

        public wTipoCambio wTipCam;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecTipCam, "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtComUsTipCam, true, "Compra Us", "vvff", 3, 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtVenUsTipCam, true, "Venta Us", "vvff", 3, 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtComCadTipCam, false, "Compra Cad", "vvff", 3, 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtVenCadTipCam, false, "Venta Cad", "vvff", 3, 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtComEurTipCam, false, "Compra Eur", "vvff", 3, 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtVenEurTipCam, false, "Venta Eur", "vvff", 3, 6);
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
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wTipCam.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //Deshabilitar al propietario
            this.wTipCam.Enabled = false;

            // Mostrar ventana
            this.Show();
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarTipoCambio(TipoCambioRN.EnBlanco());
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecTipCam.Focus();
        }

        public void VentanaModificar(TipoCambioEN pObj)
        {
            this.InicializaVentana();
            this.MostrarTipoCambio(pObj);
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtComUsTipCam.Focus();
        }

        public void VentanaEliminar(TipoCambioEN pObj)
        {
            this.InicializaVentana();
            this.MostrarTipoCambio(pObj);
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(TipoCambioEN pObj)
        {
            this.InicializaVentana();
            this.MostrarTipoCambio(pObj);
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }

        public void AsignarTipoCambio(TipoCambioEN pObj)
        {
            pObj.FechaTipoCambio = this.dtpFecTipCam.Text;
            pObj.AñoTipoCambio = Fecha.ObtenerAño(pObj.FechaTipoCambio);
            pObj.CMesTipoCambio = Fecha.ObtenerMes(pObj.FechaTipoCambio);
            pObj.PeriodoTipoCambio = Fecha.ObtenerPeriodo(pObj.FechaTipoCambio, "-");
            pObj.CompraUsTipoCambio = Conversion.ADecimal(this.txtComUsTipCam.Text, 0);
            pObj.VentaUsTipoCambio = Conversion.ADecimal(this.txtVenUsTipCam.Text, 0);
            pObj.CompraCadTipoCambio = Conversion.ADecimal(this.txtComCadTipCam.Text, 0);
            pObj.VentaCadTipoCambio = Conversion.ADecimal(this.txtVenCadTipCam.Text, 0);
            pObj.CompraEurTipoCambio = Conversion.ADecimal(this.txtComEurTipCam.Text, 0);
            pObj.VentaEurTipoCambio = Conversion.ADecimal(this.txtVenEurTipCam.Text, 0);
        }

        public void MostrarTipoCambio(TipoCambioEN pObj)
        {
            this.dtpFecTipCam.Text = pObj.FechaTipoCambio;
            this.txtComUsTipCam.Text = Formato.NumeroDecimal(pObj.CompraUsTipoCambio, 3);
            this.txtVenUsTipCam.Text = Formato.NumeroDecimal(pObj.VentaUsTipoCambio, 3);
            this.txtComCadTipCam.Text = Formato.NumeroDecimal(pObj.CompraCadTipoCambio, 3);
            this.txtVenCadTipCam.Text = Formato.NumeroDecimal(pObj.VentaCadTipoCambio, 3);
            this.txtComEurTipCam.Text = Formato.NumeroDecimal(pObj.CompraEurTipoCambio, 3);
            this.txtVenEurTipCam.Text = Formato.NumeroDecimal(pObj.VentaEurTipoCambio, 3);
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

            //el codigo es disponible?
            if (this.EsCodigoTipoCambioDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wTipCam.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarTipoCambio();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Tipo de cambio se adiciono correctamente", this.wTipCam.eTitulo);

            //actualizar al propietario
            this.wTipCam.eClaveDgvTipCam = this.dtpFecTipCam.Text;
            this.wTipCam.ActualizarVentana();

            //limpiar controles
            this.MostrarTipoCambio(TipoCambioRN.EnBlanco());
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecTipCam.Focus();
        }

        public void AdicionarTipoCambio()
        {
            TipoCambioEN iPerEN = new TipoCambioEN();
            this.AsignarTipoCambio(iPerEN);
            TipoCambioRN.AdicionarTipoCambio(iPerEN);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wTipCam.EsActoModificarTipoCambio().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wTipCam.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarTipoCambio();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Tipo de cambio se modifico correctamente", this.wTipCam.eTitulo);

            //actualizar al wUsu
            this.wTipCam.eClaveDgvTipCam = this.dtpFecTipCam.Text;
            this.wTipCam.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }

        public void ModificarTipoCambio()
        {
            TipoCambioEN iPerEN = new TipoCambioEN();
            this.AsignarTipoCambio(iPerEN);
            iPerEN = TipoCambioRN.BuscarTipoCambioXFecha(iPerEN);
            this.AsignarTipoCambio(iPerEN);
            TipoCambioRN.ModificarTipoCambio(iPerEN);
        }

        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wTipCam.EsActoEliminarTipoCambio().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wTipCam.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarTipoCambio();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Tipo de cambio se elimino correctamente", this.wTipCam.eTitulo);

            //actualizar al propietario           
            this.wTipCam.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void EliminarTipoCambio()
        {
            TipoCambioEN iPerEN = new TipoCambioEN();
            this.AsignarTipoCambio(iPerEN);
            TipoCambioRN.EliminarTipoCambio(iPerEN);
        }

        public bool EsCodigoTipoCambioDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            TipoCambioEN iPerEN = new TipoCambioEN();
            this.AsignarTipoCambio(iPerEN);
            iPerEN = TipoCambioRN.EsCodigoTipoCambioDisponible(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, this.wTipCam.eTitulo);
                this.dtpFecTipCam.Focus();
            }
            return iPerEN.Adicionales.EsVerdad;
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wTipCam.eTitulo);
        }

        public async void peticionSunatTipoCambio()
        {
            TipoCambioSunatEN tipCam = new TipoCambioSunatEN()
            {
                token = "CMrogiyPeqv9TcxcceYBrGlGwAx7uRb7KS0WOuxrlBAA77glqbLAT7lCKRwq",
                fecha = this.dtpFecTipCam.Text.Substring(6, 4) + "-" + this.dtpFecTipCam.Text.Substring(3, 2) + "-" + this.dtpFecTipCam.Text.Substring(0, 2)
            };
            //Instanciamos un objeto Reply
            Reply oReply = new Reply();
            //poblamos el objeto con el método generic Execute
            oReply = await Consumer.Execute<TipoCambioSunatEN>("https://api.migo.pe/api/v1/exchange/date", Utilidades.methodHttp.POST, tipCam);
            //Mostramos el statuscode devuelto, podemos añadirle lógica de validación
            MessageBox.Show(oReply.StatusCode);
        }
        #endregion

        private void wEditTipoCambio_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wTipCam.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void btnSunat_Click(object sender, EventArgs e)
        {
            this.peticionSunatTipoCambio();
        }
    }
}
