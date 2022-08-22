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
using System.Collections;
using Presentacion.Listas;

namespace Presentacion.Maestros
{
    public partial class wEditCuenta : Heredados.MiForm8
    {
        public wEditCuenta()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();

        #endregion

        #region Propietario

        public wCuenta wCue;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroSinEspacion(this.txtCodCue, true, "Codigo", "vfff", 11);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDesCue, true, "Descripcion", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCDoc, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCAux, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCCenCos, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCAlm, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCAre, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCFluCaj, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCAut, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCDifCam, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCBan, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCMon, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCAsiApe, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCAsiCie7, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCAsiCie9, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCReg, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodCueAut1, true, "Cuenta Automatica1", "vvff", 11);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesCueAut1, this.txtCodCueAut1, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodCueAut2, true, "Cuenta Automatica2", "vvff", 11);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesCueAut2, this.txtCodCueAut2, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodForCon, true, "Formato Contable", "vvff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesForCon, this.txtCodForCon, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCEstCue, "vvff");
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
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wCue.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //llenar Combos
            this.CargarCDocumento();
            this.CargarCAuxiliar();
            this.CargarCCentroCosto();
            this.CargarCAlmacen();
            this.CargarCArea();
            this.CargarCFlujoCaja();
            this.CargarCAutomatica();
            this.CargarCDiferenciaCambio();
            this.CargarCBanco();
            this.CargarCMoneda();
            this.CargarCAsientoApertura();
            this.CargarCAsientoCierre7();
            this.CargarCAsientoCierre9();
            this.CargarCRegistro();
            this.CargarCEstadoCuenta();

            //deshabilitar al propietario
            this.wCue.Enabled = false;

            //mostrar ventana
            this.Show();
        }

        public void CargarCDocumento()
        {
            Cmb.Cargar(this.cmbCDoc, ItemGRN.ListarItemsG("SiNo"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCAuxiliar()
        {
            Cmb.Cargar(this.cmbCAux, ItemGRN.ListarItemsG("SiNo"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCCentroCosto()
        {
            Cmb.Cargar(this.cmbCCenCos, ItemGRN.ListarItemsG("SiNo"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCAlmacen()
        {
            Cmb.Cargar(this.cmbCAlm, ItemGRN.ListarItemsG("SiNo"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCArea()
        {
            Cmb.Cargar(this.cmbCAre, ItemGRN.ListarItemsG("SiNo"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCFlujoCaja()
        {
            Cmb.Cargar(this.cmbCFluCaj, ItemGRN.ListarItemsG("SiNo"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCAutomatica()
        {
            Cmb.Cargar(this.cmbCAut, ItemGRN.ListarItemsG("SiNo"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCDiferenciaCambio()
        {
            Cmb.Cargar(this.cmbCDifCam, ItemGRN.ListarItemsG("SiNo"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCBanco()
        {
            Cmb.Cargar(this.cmbCBan, ItemGRN.ListarItemsG("SiNo"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCMoneda()
        {
            Cmb.Cargar(this.cmbCMon, ItemGRN.ListarItemsG("Moneda"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCAsientoApertura()
        {
            Cmb.Cargar(this.cmbCAsiApe, ItemGRN.ListarItemsG("SiNo"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCAsientoCierre7()
        {
            Cmb.Cargar(this.cmbCAsiCie7, ItemGRN.ListarItemsG("SiNo"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCAsientoCierre9()
        {
            Cmb.Cargar(this.cmbCAsiCie9, ItemGRN.ListarItemsG("SiNo"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCRegistro()
        {
            Cmb.Cargar(this.cmbCReg, ItemGRN.ListarItemsG("Reg"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCEstadoCuenta()
        {
            Cmb.Cargar(this.cmbCEstCue, ItemGRN.ListarItemsG("EstReg"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarCuenta(CuentaRN.EnBlanco());
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.AccionLongitudCodigoCuenta();
            this.AccionCambiarCmbCAut();
            this.AccionCambiarCmbCMon();
            this.ModificarMaximoTamañoTxtCodCue();
            this.txtCodCue.Focus();
        }

        public void VentanaModificar(CuentaEN pObj)
        {
            this.InicializaVentana();
            this.MostrarCuenta(pObj);
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.AccionLongitudCodigoCuenta();
            this.AccionCambiarCmbCAut();
            this.AccionCambiarCmbCMon();
            this.txtDesCue.Focus();
        }

        public void VentanaEliminar(CuentaEN pObj)
        {
            this.InicializaVentana();
            this.MostrarCuenta(pObj);
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(CuentaEN pObj)
        {
            this.InicializaVentana();
            this.MostrarCuenta(pObj);
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }

        public void AsignarCuenta(CuentaEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.CodigoCuenta = this.txtCodCue.Text.Trim();
            pObj.DescripcionCuenta = this.txtDesCue.Text.Trim();
            pObj.NumeroDigitosAnalitica = pObj.CodigoCuenta.Length.ToString();
            pObj.CDocumento = Cmb.ObtenerValor(this.cmbCDoc);
            pObj.CAuxiliar = Cmb.ObtenerValor(this.cmbCAux);
            pObj.CCentroCosto = Cmb.ObtenerValor(this.cmbCCenCos);
            pObj.CAlmacen = Cmb.ObtenerValor(this.cmbCAlm);
            pObj.CArea = Cmb.ObtenerValor(this.cmbCAre);
            pObj.CFlujoCaja = Cmb.ObtenerValor(this.cmbCFluCaj);
            pObj.CAutomatica = Cmb.ObtenerValor(this.cmbCAut);
            pObj.CDiferenciaCambio = Cmb.ObtenerValor(this.cmbCDifCam);
            pObj.CBanco = Cmb.ObtenerValor(this.cmbCBan);
            pObj.CMoneda = Cmb.ObtenerValor(this.cmbCMon);
            pObj.CAsientoApertura = Cmb.ObtenerValor(this.cmbCAsiApe);
            pObj.CAsientoCierre7 = Cmb.ObtenerValor(this.cmbCAsiCie7);
            pObj.CAsientoCierre9 = Cmb.ObtenerValor(this.cmbCAsiCie9);
            pObj.CRegistro = Cmb.ObtenerValor(this.cmbCReg);
            pObj.CodigoCuentaAutomatica1 = this.txtCodCueAut1.Text.Trim();
            pObj.CodigoCuentaAutomatica2 = this.txtCodCueAut2.Text.Trim();
            pObj.CodigoFormatoContable = this.txtCodForCon.Text.Trim();
            pObj.CEstadoCuenta = Cmb.ObtenerValor(this.cmbCEstCue, string.Empty);
            pObj.ClaveCuenta = CuentaRN.ObtenerClaveCuenta(pObj);
        }

        public void MostrarCuenta(CuentaEN pObj)
        {
            this.txtCodCue.Text = pObj.CodigoCuenta;
            this.txtDesCue.Text = pObj.DescripcionCuenta;
            Cmb.SeleccionarValorItem(this.cmbCDoc, pObj.CDocumento);
            Cmb.SeleccionarValorItem(this.cmbCAux, pObj.CAuxiliar);
            Cmb.SeleccionarValorItem(this.cmbCCenCos, pObj.CCentroCosto);
            Cmb.SeleccionarValorItem(this.cmbCAlm, pObj.CAlmacen);
            Cmb.SeleccionarValorItem(this.cmbCAre, pObj.CArea);
            Cmb.SeleccionarValorItem(this.cmbCFluCaj, pObj.CFlujoCaja);
            Cmb.SeleccionarValorItem(this.cmbCAut, pObj.CAutomatica);
            Cmb.SeleccionarValorItem(this.cmbCDifCam, pObj.CDiferenciaCambio);
            Cmb.SeleccionarValorItem(this.cmbCBan, pObj.CBanco);
            Cmb.SeleccionarValorItem(this.cmbCMon, pObj.CMoneda);
            Cmb.SeleccionarValorItem(this.cmbCAsiApe, pObj.CAsientoApertura);
            Cmb.SeleccionarValorItem(this.cmbCAsiCie7, pObj.CAsientoCierre7);
            Cmb.SeleccionarValorItem(this.cmbCAsiCie9, pObj.CAsientoCierre9);
            Cmb.SeleccionarValorItem(this.cmbCReg, pObj.CRegistro);
            this.txtCodCueAut1.Text = pObj.CodigoCuentaAutomatica1;
            this.txtDesCueAut1.Text = pObj.DescripcionCuentaAutomatica1;
            this.txtCodCueAut2.Text = pObj.CodigoCuentaAutomatica2;
            this.txtDesCueAut2.Text = pObj.DescripcionCuentaAutomatica2;
            this.txtCodForCon.Text = pObj.CodigoFormatoContable;
            this.txtDesForCon.Text = pObj.DescripcionFormatoContable;
            Cmb.SeleccionarValorItem(this.cmbCEstCue, pObj.CEstadoCuenta);
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

            //es codigo disponible
            if (this.EsCodigoCuentaDisponible() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wCue.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarCuenta();

            //adicionar la cuenta banco, si esta el campo "Banco" igual a "si"
            this.AccionAdicionarCuentaBanco();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("la Cuenta se adiciono correctamente", this.wCue.eTitulo);

            //actualizar al propietario
            this.wCue.eClaveDgvCue = this.ObtenerClaveCuenta();
            this.wCue.ActualizarVentana();

            //limpiar controles
            this.MostrarCuenta(CuentaRN.EnBlanco());
            this.AccionLongitudCodigoCuenta();
            this.AccionCambiarCmbCAut();
            eMas.AccionPasarTextoPrincipal();
            this.txtCodCue.Focus();
        }

        public void AdicionarCuenta()
        {
            CuentaEN iObjEN = new CuentaEN();
            this.AsignarCuenta(iObjEN);
            CuentaRN.AdicionarCuenta(iObjEN);
        }

        public string ObtenerClaveCuenta()
        {
            CuentaEN iObjEN = new CuentaEN();
            this.AsignarCuenta(iObjEN);
            return iObjEN.ClaveCuenta;
        }

        public void AccionAdicionarCuentaBanco()
        {
            //asignar parametros
            CuentaEN iCueEN = new CuentaEN();
            this.AsignarCuenta(iCueEN);

            //ejecutar metodo
            CuentaBancoRN.AccionAdicionarCuentaBanco(iCueEN);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //volver a preguntar si es acto
            if (this.wCue.EsActoModificarCuenta().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wCue.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarCuenta();

            //accion modificar cuentaBanco desde cuenta
            this.AccionModificarCuentaBanco();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("la Cuenta se modifico correctamente", this.wCue.eTitulo);

            //actualizar al wUsu
            this.wCue.eClaveDgvCue = this.ObtenerClaveCuenta();
            this.wCue.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void ModificarCuenta()
        {
            CuentaEN iObjEN = new CuentaEN();
            this.AsignarCuenta(iObjEN);
            iObjEN = CuentaRN.BuscarCuentaXClave(iObjEN);
            this.AsignarCuenta(iObjEN);
            CuentaRN.ModificarCuenta(iObjEN);
        }

        public void AccionModificarCuentaBanco()
        {
            //asignar parametros
            CuentaEN iCueEN = new CuentaEN();
            this.AsignarCuenta(iCueEN);

            //ejecutar metodo
            CuentaBancoRN.AccionModificarCuentaBanco(iCueEN);
        }

        public void Eliminar()
        {
            //volver a preguntar si es acto
            if (this.wCue.EsActoEliminarCuenta().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wCue.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarCuenta();

            //accion eliminar cuentaBanco desde cuenta
            this.AccionEliminarCuentaBanco();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Cuenta se elimino correctamente", this.wCue.eTitulo);

            //actualizar al propietario           
            this.wCue.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void EliminarCuenta()
        {
            CuentaEN iObjEN = new CuentaEN();
            this.AsignarCuenta(iObjEN);
            CuentaRN.EliminarCuenta(iObjEN);
        }

        public void AccionEliminarCuentaBanco()
        {
            //asignar parametros
            CuentaEN iCueEN = new CuentaEN();
            this.AsignarCuenta(iCueEN);

            //ejecutar metodo
            CuentaBancoRN.AccionEliminarCuentaBanco(iCueEN);
        }

        public bool EsCodigoCuentaDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            //Asignar parametros
            CuentaEN iObjEN = new CuentaEN();
            this.AsignarCuenta(iObjEN);

            //ejecutar metodo
            iObjEN = CuentaRN.EsCodigoCuentaDisponible(iObjEN);

            //mensaje de error
            Generico.MostrarMensajeError(iObjEN.Adicionales, this.txtCodCue);

            //accion x longitud codigo cuenta
            this.AccionLongitudCodigoCuenta();

            //accion x cambiar cmbCAut
            this.AccionCambiarCmbCAut();

            //accion x cambiar cmbCMon
            this.AccionCambiarCmbCMon();

            //devolver
            return iObjEN.Adicionales.EsVerdad;
        }

        public void AccionLongitudCodigoCuenta()
        {
            //solo se puede ejecutar cuando se adiciona y modifica
            if (MiForm.VerdaderoCuandoAdicionaYModifica((int)eOperacion) == false) { return; }

            //habilitar controles
            this.HabilitarXLongitudCodigoCuenta();

            //limpiar controles
            this.LimpiarXLongitudCodigoCuenta();
        }

        public void HabilitarXLongitudCodigoCuenta()
        {            
            //asignar parametros         
            Hashtable iLisConVF = this.ListarControlesHabilitarXLongitudCodigoCuenta();
            int iIndVF = this.ObtenerIndiceHabilitaXLongitudCodigoCuenta();
                        
            //ejecutar metodo
            MiControl.Habilitar(iLisConVF, iIndVF);
        }

        public Hashtable ListarControlesHabilitarXLongitudCodigoCuenta()
        {
            //crear la lista
            Hashtable iLisConVF = new Hashtable();

            //insertar los controles
            iLisConVF.Add(this.cmbCAlm, "ffv");
            iLisConVF.Add(this.cmbCAre, "ffv");
            iLisConVF.Add(this.cmbCAsiApe, "fvf");
            iLisConVF.Add(this.cmbCAsiCie7, "fvf");
            iLisConVF.Add(this.cmbCAsiCie9, "fvf");
            iLisConVF.Add(this.cmbCAut, "ffv");
            iLisConVF.Add(this.cmbCAux, "ffv");
            iLisConVF.Add(this.cmbCBan, "ffv");
            iLisConVF.Add(this.cmbCMon, "ffv");
            iLisConVF.Add(this.cmbCCenCos, "ffv");
            iLisConVF.Add(this.cmbCDifCam, "ffv");
            iLisConVF.Add(this.cmbCDoc, "ffv");
            iLisConVF.Add(this.cmbCFluCaj, "ffv");
            iLisConVF.Add(this.cmbCReg, "ffv");
            iLisConVF.Add(this.txtCodCueAut1, "ffv");
            iLisConVF.Add(this.txtCodCueAut2, "ffv");
            iLisConVF.Add(this.txtCodForCon, "ffv");

            //devolver
            return iLisConVF;
        }

        public int ObtenerIndiceHabilitaXLongitudCodigoCuenta()
        {
            //asignar parametros
            string iCodigoCuenta = this.txtCodCue.Text.Trim();
            string iNumeroDigitosAnalitica = EmpresaRN.BuscarEmpresaDeAcceso().NumeroDigitosAnalitica;

            //ejecutar metodo
            return CuentaRN.ObtenerIndiceHabilitaXLongitudCodigoCuenta(iCodigoCuenta, iNumeroDigitosAnalitica);
        }

        public void LimpiarXLongitudCodigoCuenta()
        {           
            //asignar parametros           
            Hashtable iLisConVF = this.ListarControlesLimpiarXLongitudCodigoCuenta();
            int iIndVF = this.ObtenerIndiceHabilitaXLongitudCodigoCuenta();

            //ejecutar metodo         
            MiControl.Limpiar(iLisConVF, iIndVF);
        }

        public Hashtable ListarControlesLimpiarXLongitudCodigoCuenta()
        {
            //crear la lista
            Hashtable iLisConVF = new Hashtable();

            //insertar los controles
            iLisConVF.Add(this.txtCodCueAut1, "vvf");
            iLisConVF.Add(this.txtDesCueAut1, "vvf");
            iLisConVF.Add(this.txtCodCueAut2, "vvf");
            iLisConVF.Add(this.txtDesCueAut2, "vvf");
            iLisConVF.Add(this.txtCodForCon, "vvf");
            

            //devolver
            return iLisConVF;
        }

        public void AccionCambiarCmbCAut()
        {
            //solo se puede ejecutar cuando se adiciona y modifica
            if (MiForm.VerdaderoCuandoAdicionaYModifica((int)eOperacion) == false) { return; }

            //si el control esta deshabilitado, entonces termina el proceso
            if (this.cmbCAut.Enabled == false) { return; }

            //habilitar controles
            this.HabilitarXCambiarCmbCAut();

            //limpiar controles
            this.LimpiarXCambiarCmbCAut();

            //mostrar cuenta automatica 2
            this.MostrarCuentaAutomatica2();
        }

        public void HabilitarXCambiarCmbCAut()
        {
            //asignar parametros         
            Hashtable iLisConVF = this.ListarControlesHabilitarXCambiarCmbCAut();
            int iIndVF = Convert.ToInt32(Cmb.ObtenerValor(this.cmbCAut, "0"));

            //ejecutar metodo
            MiControl.Habilitar(iLisConVF, iIndVF);
        }

        public Hashtable ListarControlesHabilitarXCambiarCmbCAut()
        {
            //crear la lista
            Hashtable iLisConVF = new Hashtable();

            //insertar los controles
            iLisConVF.Add(this.txtCodCueAut1, "fv");         
            iLisConVF.Add(this.txtCodCueAut2, "fv");
           
            //devolver
            return iLisConVF;
        }

        public void LimpiarXCambiarCmbCAut()
        {
            //asignar parametros           
            Hashtable iLisConVF = this.ListarControlesLimpiarXCambiarCmbCAut();
            int iIndVF = Convert.ToInt32(Cmb.ObtenerValor(this.cmbCAut, "0"));

            //ejecutar metodo         
            MiControl.Limpiar(iLisConVF, iIndVF);
        }

        public Hashtable ListarControlesLimpiarXCambiarCmbCAut()
        {
            //crear la lista
            Hashtable iLisConVF = new Hashtable();

            //insertar los controles
            iLisConVF.Add(this.txtCodCueAut1, "vf");
            iLisConVF.Add(this.txtDesCueAut1, "vf");
            iLisConVF.Add(this.txtCodCueAut2, "vf");
            iLisConVF.Add(this.txtDesCueAut2, "vf");
          
            //devolver
            return iLisConVF;
        }

        public void MostrarCuentaAutomatica2()
        {
            //si el control muestra no, entonces termina el proceso
            if (Cmb.ObtenerValor( this.cmbCAut) != "1") { return; }

            //asignar parametros
            string iCodigoCuentaAutomatica = EmpresaRN.BuscarEmpresaDeAcceso().CuentaAutomatica2;

            //ejecutar metodo
            CuentaEN iCueEN = CuentaRN.BuscarCuentaXCodigo(iCodigoCuentaAutomatica);

            //mostrar
            this.txtCodCueAut2.Text = iCueEN.CodigoCuenta;
            this.txtDesCueAut2.Text = iCueEN.DescripcionCuenta;
        }

        public void ListarCuentaAutomatica1()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodCueAut1.ReadOnly == true) { return; }

            //instanciar
            wLisCue win = new wLisCue();
            win.eVentana = this;
            win.eTituloVentana = "Cuentas";
            win.eCtrlValor = this.txtCodCueAut1;
            win.eCtrlFoco = this.txtCodCueAut2;
            win.eCondicionLista = Listas.wLisCue.Condicion.CuentasAnaliticasActivasExceptoUna;
            win.eCodigoCuentaExcepcion = this.txtCodCueAut2.Text.Trim();
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoCuentaAutomatica1ActivoValido()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodCueAut1.ReadOnly == true) { return true; }

            //asignar parametros
            CuentaEN iObjEN = new CuentaEN();
            iObjEN.CodigoCuenta = this.txtCodCueAut1.Text.Trim();
            iObjEN.ClaveCuenta = CuentaRN.ObtenerClaveCuenta(iObjEN);
            string iCodigoCuentaExcepcion = this.txtCodCueAut2.Text.Trim();

            //ejecutar metodo
            iObjEN = CuentaRN.EsCuentaActivoValido(iObjEN, iCodigoCuentaExcepcion);

            //mensaje de error
            Generico.MostrarMensajeError(iObjEN.Adicionales, this.txtCodCueAut1);

            //mostrar datos
            this.txtCodCueAut1.Text = iObjEN.CodigoCuenta;
            this.txtDesCueAut1.Text = iObjEN.DescripcionCuenta;
            
            //devolver
            return iObjEN.Adicionales.EsVerdad;
        }

        public void ListarCuentaAutomatica2()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodCueAut2.ReadOnly == true) { return; }

            //instanciar
            wLisCue win = new wLisCue();
            win.eVentana = this;
            win.eTituloVentana = "Cuentas";
            win.eCtrlValor = this.txtCodCueAut2;
            win.eCtrlFoco = this.txtCodForCon;
            win.eCondicionLista = Listas.wLisCue.Condicion.CuentasAnaliticasActivasExceptoUna;
            win.eCodigoCuentaExcepcion = this.txtCodCueAut1.Text.Trim();
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoCuentaAutomatica2ActivoValido()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodCueAut2.ReadOnly == true) { return true; }

            //asignar parametros
            CuentaEN iObjEN = new CuentaEN();
            iObjEN.CodigoCuenta = this.txtCodCueAut2.Text.Trim();
            iObjEN.ClaveCuenta = CuentaRN.ObtenerClaveCuenta(iObjEN);
            string iCodigoCuentaExcepcion = this.txtCodCueAut1.Text.Trim();

            //ejecutar metodo
            iObjEN = CuentaRN.EsCuentaActivoValido(iObjEN, iCodigoCuentaExcepcion);

            //mensaje de error
            Generico.MostrarMensajeError(iObjEN.Adicionales, this.txtCodCueAut2);

            //mostrar datos
            this.txtCodCueAut2.Text = iObjEN.CodigoCuenta;
            this.txtDesCueAut2.Text = iObjEN.DescripcionCuenta;

            //devolver
            return iObjEN.Adicionales.EsVerdad;
        }

        public void ModificarMaximoTamañoTxtCodCue()
        {
            //ejecutar metodo
            int iMaximoNumero = CuentaRN.ObtenerMaximaLongitudCodigoCuenta();
           
            //modificar la propiedad del control
            this.txtCodCue.MaxLength = iMaximoNumero;
        }

        public void ListarFormatoContables()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodForCon.ReadOnly == true) { return; }

            //instanciar
            wLisForCon win = new wLisForCon();
            win.eVentana = this;
            win.eTituloVentana = "Formatos contables";
            win.eCtrlValor = this.txtCodForCon;
            win.eCtrlFoco = this.cmbCEstCue;
            win.eCondicionLista = Listas.wLisForCon.Condicion.FormatosContablesActivas;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoFormatoContableActivoValido()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodCueAut2.ReadOnly == true) { return true; }

            //asignar parametros
            FormatoContableEN iObjEN = new FormatoContableEN();
            iObjEN.CodigoFormatoContable = this.txtCodForCon.Text.Trim();
            iObjEN.ClaveFormatoContable = FormatoContableRN.ObtenerClaveFormatoContable(iObjEN);
            
            //ejecutar metodo
            iObjEN = FormatoContableRN.EsFormatoContableActivoValido(iObjEN);

            //mensaje de error
            Generico.MostrarMensajeError(iObjEN.Adicionales, this.txtCodForCon);

            //mostrar datos
            this.txtCodForCon.Text = iObjEN.CodigoFormatoContable;
            this.txtDesForCon.Text = iObjEN.DescripcionFormatoContable;

            //devolver
            return iObjEN.Adicionales.EsVerdad;
        }

        public void AccionCambiarCmbCMon()
        {
            //solo se puede ejecutar cuando se adiciona y modifica
            if (MiForm.VerdaderoCuandoAdicionaYModifica((int)eOperacion) == false) { return; }

            //si el control esta deshabilitado, entonces termina el proceso
            if (this.cmbCMon.Enabled == false) { return; }

            //habilitar diferencia de cambio
            this.cmbCDifCam.Enabled = Cadena.CompararDosValores(Cmb.ObtenerValor(this.cmbCMon, "0"), "0", false, true);
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wCue.eTitulo);
        }

        #endregion

   
        private void wEditCuenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wCue.Enabled = true;
        }

        private void txtCodCue_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoCuentaDisponible();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void cmbCAut_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.AccionCambiarCmbCAut();
        }

        private void txtCodCueAut1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarCuentaAutomatica1(); }
        }

        private void txtCodCueAut1_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoCuentaAutomatica1ActivoValido();
        }

        private void txtCodCueAut1_DoubleClick(object sender, EventArgs e)
        {
            this.ListarCuentaAutomatica1();
        }

        private void txtCodCueAut2_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoCuentaAutomatica2ActivoValido();
        }

        private void txtCodCueAut2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarCuentaAutomatica2(); }
        }

        private void txtCodCueAut2_DoubleClick(object sender, EventArgs e)
        {
            this.ListarCuentaAutomatica2();
        }

        private void txtCodForCon_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoFormatoContableActivoValido();
        }

        private void txtCodForCon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarFormatoContables(); }
        }

        private void txtCodForCon_DoubleClick(object sender, EventArgs e)
        {
            this.ListarFormatoContables();
        }

        private void cmbCMon_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.AccionCambiarCmbCMon();
        }
    }
}
