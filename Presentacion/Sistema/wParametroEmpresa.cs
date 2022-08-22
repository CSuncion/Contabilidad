using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades.Adicionales;
using WinControles;
using Entidades;
using Negocio;
using WinControles.ControlesWindows;
using Comun;
using Presentacion.Listas;
using System.IO;
using Presentacion.Principal;
using Presentacion.FuncionesGenericas;

namespace Presentacion.Sistema
{
    public partial class wParametroEmpresa : Heredados.MiForm8
    {
        public wParametroEmpresa()
        {
            InitializeComponent( );
        }

        //variables      
        Masivo eMas = new Masivo( );
          
        #region Propietario

        public wEmpresa wEmp;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls( )
        {
            List<ControlEditar> xLis = new List<ControlEditar>( );
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtNumDigAna, true, "Numero dig Analitica", "vvff", 0, 2);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCueAut2, false, "Cuenta Automatica 2", "vvff", 11);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCueIgv, false, "Cuenta Igv", "vvff", 11);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar( );
            xCtrl.Btn( this.btnCancelar , "vvvv" );
            xLis.Add( xCtrl );

            return xLis;
        }

        #endregion

        #region General

        public void InicializaVentana()
        {
            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //deshabilitar propietario
            this.wEmp.Enabled = false;

            //ver
            this.Show();
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();
            this.MostrarParametroEmpresa();
            this.txtNumDigAna.Focus();
        }

        public void MostrarParametroEmpresa()
        {
            EmpresaEN iEmpEN = new EmpresaEN();
            iEmpEN.CodigoEmpresa = Dgv.ObtenerValorCelda(wEmp.DgvEmp, EmpresaEN.CodEmp);
            iEmpEN = EmpresaRN.BuscarEmpresaXCodigo(iEmpEN);

            //mostar datos
            this.txtNumDigAna.Text = iEmpEN.NumeroDigitosAnalitica;
            this.txtCueAut2.Text = iEmpEN.CuentaAutomatica2;
            this.txtCueIgv.Text = iEmpEN.CuentaIgv;
            this.pbImaLog.ImageLocation = iEmpEN.LogoEmpresa;
            this.lblRutLog.Text = iEmpEN.LogoEmpresa;
        }

        public void MensajeDeConfirmacion()
        {
            MessageBox.Show("El parametro se modifico Correctamente", "Parametro", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ModificarCampo(string pCampo, string pValor)
        {
            string iCodigoEmpresa = Dgv.ObtenerValorCelda(wEmp.DgvEmp, EmpresaEN.CodEmp);
            EmpresaRN.ModificarCampoParametro(pCampo, pValor, iCodigoEmpresa);
            this.MensajeDeConfirmacion();
        }

        public void BuscarImagenLogo()
        {
            
        }

        public void AsignarParametrosEmpresa(EmpresaEN pObj)
        {
            pObj.CodigoEmpresa = Dgv.ObtenerValorCelda(this.wEmp.DgvEmp, EmpresaEN.CodEmp);
            pObj.NumeroDigitosAnalitica = this.txtNumDigAna.Text.Trim();
            pObj.CuentaAutomatica2 = this.txtCueAut2.Text.Trim();
            pObj.CuentaIgv = this.txtCueIgv.Text.Trim();
        }

        public bool EsActoModificarNumeroDigitosAnalitica()
        {
            //asignar parametros
            EmpresaEN iObjEN = new EmpresaEN();
            this.AsignarParametrosEmpresa(iObjEN);

            //ejecutar metodo
            iObjEN = EmpresaRN.EsActoModificarNumeroDigitosAnalitica(iObjEN);

            //mensaje de error
            Generico.MostrarMensajeError(iObjEN.Adicionales, this.txtNumDigAna);

            //devolver
            return iObjEN.Adicionales.EsVerdad;
        }

        public void Aceptar()
        {
            //validar datos obligatorios
            if (this.eMas.CamposObligatorios() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion("Parametros") == false) { return; }

            //modificar
            this.ModificarEmpresa();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Los parametros se modificaron correctamente", "Parametros");

            //salir de la ventana
            this.Close();
        }

        public void ModificarEmpresa()
        {
            //asignar parametros
            EmpresaEN iEmpEN = new EmpresaEN();
            iEmpEN.CodigoEmpresa = Dgv.ObtenerValorCelda(wEmp.DgvEmp, EmpresaEN.CodEmp);
            iEmpEN = EmpresaRN.BuscarEmpresaXCodigo(iEmpEN);

            //pasar datos
            this.AsignarParametrosEmpresa(iEmpEN);

            //ejecutar metodo
            EmpresaRN.ModificarEmpresa(iEmpEN);
        }

        #endregion


        private void btnCancelar_Click( object sender , EventArgs e )
        {
            this.Close( );
        }

        private void wParametroEmpresa_FormClosing( object sender , FormClosingEventArgs e )
        {
            this.wEmp.Enabled = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.BuscarImagenLogo();
        }

        private void btnActLogEmp_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(EmpresaEN.LogEmp, this.lblRutLog.Text);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void txtNumDigAna_Validating(object sender, CancelEventArgs e)
        {
            this.EsActoModificarNumeroDigitosAnalitica();
        }
    }
}
