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
    public partial class wDetalleRegistroCompra : Heredados.MiForm8
    {
        public wDetalleRegistroCompra()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        string eTitulo = "Item";

        #endregion

        #region Propietario

        public wEditRegistroCompra wEdiRegCom;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;
            
            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodCue, true, "CodigoCuenta", "vvff", 11);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesCue, this.txtCodCue, "ffff");
            xLis.Add(xCtrl);
            
            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCDebHab, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtImpSolRegConDet, true, "ImporteSolRegContabDeta", "vvff", 2, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodIngEgr, true, "Ingreso/Egreso", "vvff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNIngEgr, this.txtCodIngEgr, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCCenCos, true, "Centro Costo", "vvff", 6);
            xLis.Add(xCtrl);    

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNCenCos, this.txtCCenCos, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCAre, true, "Area", "vvff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNAre, this.txtCAre, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAlm, true, "Almacen", "vvff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAlm, this.txtCodAlm, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodIteAlm, true, "Item Almacen", "vvff", 20);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesIteAlm, this.txtCodIteAlm, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtCanIteAlm, true, "Cantidad Item", "vvff", 2, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtGloRegConDet, false, "Glosa", "vvff", 150);
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
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //llenar Combos            
            this.CargarCDebeHaber();
           
            //deshabilitar al propietario
            this.wEdiRegCom.Enabled = false;

            //mostrar ventana
            this.Show();
        }

        public void CargarCDebeHaber()
        {
            Cmb.Cargar(this.cmbCDebHab, ItemGRN.ListarItemsG("DeHa"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }
        
        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarRegContabDeta(RegContabDetaRN.EnBlanco());            
            eMas.AccionHabilitarControles(0);
            this.CambiarAtributoSoloLecturaAlCambiarCuenta();
            this.CambiarItemDebeHaberSegunTipoDocumento();
            this.MostrarImporteSolSugerido();
            eMas.AccionPasarTextoPrincipal();
            this.txtCodCue.Focus();
        }

        public void VentanaModificar(RegContabDetaEN pObj)
        {
            this.InicializaVentana();
            this.MostrarRegContabDeta(pObj);
            eMas.AccionHabilitarControles(1);
            this.CambiarAtributoSoloLecturaAlCambiarCuenta();
            eMas.AccionPasarTextoPrincipal();
            this.txtImpSolRegConDet.Focus();
        }

        public void VentanaEliminar(RegContabDetaEN pObj)
        {
            this.InicializaVentana();
            this.MostrarRegContabDeta(pObj);
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void AsignarRegContabDeta(RegContabDetaEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.CTipoNota = this.wEdiRegCom.txtCTipNot.Text.Trim();    
            pObj.CodigoCuenta = this.txtCodCue.Text.Trim();
            pObj.DescripcionCuenta = this.txtDesCue.Text.Trim();
            pObj.CCentroCostoCuenta = this.txtCCenCosCue.Text.Trim();
            pObj.CAlmacen = this.txtCAlm.Text.Trim();
            pObj.CAreaCuenta = this.txtCAreCue.Text.Trim();
            pObj.CAuxiliar = this.txtCAux.Text.Trim();
            pObj.CDocumento = this.txtCDoc.Text.Trim();
            pObj.CAutomatica = this.txtCAut.Text.Trim();
            pObj.CodigoCuentaAutomatica1 = this.txtCodCueAut1.Text.Trim();
            pObj.CodigoCuentaAutomatica2 = this.txtCodCueAut2.Text.Trim();
            pObj.CDebeHaber = Cmb.ObtenerValor(this.cmbCDebHab, string.Empty);
            pObj.NDebeHaber = Cmb.ObtenerTexto(this.cmbCDebHab);
            pObj.ImporteSolRegContabDeta = Conversion.ADecimal(this.txtImpSolRegConDet.Text, 0);
            pObj.CIngresoEgreso = this.txtCodIngEgr.Text.Trim();
            pObj.NIngresoEgreso = this.txtNIngEgr.Text.Trim();
            pObj.CCentroCosto = this.txtCCenCos.Text.Trim();
            pObj.NCentroCosto = this.txtNCenCos.Text.Trim();
            pObj.CArea = this.txtCAre.Text.Trim();
            pObj.NArea = this.txtNAre.Text.Trim();
            pObj.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            pObj.DescripcionAlmacen = this.txtDesAlm.Text.Trim();
            pObj.CodigoItemAlmacen = this.txtCodIteAlm.Text.Trim();
            pObj.DescripcionItemAlmacen = this.txtDesIteAlm.Text.Trim();
            pObj.CantidadItemAlmacen = Conversion.ADecimal(this.txtCanIteAlm.Text, 0);            
            pObj.GlosaRegContabDeta = this.txtGloRegConDet.Text.Trim();                            
        }

        public void MostrarRegContabDeta(RegContabDetaEN pObj)
        {            
            this.txtCodCue.Text = pObj.CodigoCuenta;
            this.txtDesCue.Text = pObj.DescripcionCuenta;
            this.txtCCenCosCue.Text = pObj.CCentroCostoCuenta;
            this.txtCAlm.Text = pObj.CAlmacen;
            this.txtCAreCue.Text = pObj.CAreaCuenta;
            this.txtCAux.Text = pObj.CAuxiliar;
            this.txtCDoc.Text = pObj.CDocumento;
            this.txtCAut.Text = pObj.CAutomatica;
            this.txtCodCueAut1.Text = pObj.CodigoCuentaAutomatica1;
            this.txtCodCueAut2.Text = pObj.CodigoCuentaAutomatica2;       
            Cmb.SeleccionarValorItem(this.cmbCDebHab, pObj.CDebeHaber);
            this.txtImpSolRegConDet.Text = Formato.NumeroDecimal(pObj.ImporteSolRegContabDeta, 2);
            this.txtCodIngEgr.Text = pObj.CIngresoEgreso;
            this.txtNIngEgr.Text = pObj.NIngresoEgreso;
            this.txtCCenCos.Text = pObj.CCentroCosto;
            this.txtNCenCos.Text = pObj.NCentroCosto;
            this.txtCAre.Text = pObj.CArea;
            this.txtNAre.Text = pObj.NArea;
            this.txtCodAlm.Text = pObj.CodigoAlmacen;
            this.txtDesAlm.Text = pObj.DescripcionAlmacen;       
            this.txtCodIteAlm.Text = pObj.CodigoItemAlmacen;
            this.txtDesIteAlm.Text = pObj.DescripcionItemAlmacen;
            this.txtCanIteAlm.Text = Formato.NumeroDecimal(pObj.CantidadItemAlmacen, 2);
            this.txtGloRegConDet.Text = pObj.GlosaRegContabDeta;
        }

        public RegContabDetaEN NuevoRegContabDetaDeVentana()
        {
            //asignar parametros
            RegContabDetaEN iRegConDetEN = new RegContabDetaEN();
            this.AsignarRegContabDeta(iRegConDetEN);

            //devolver
            return iRegConDetEN;
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
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarRegContabDeta();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("se adiciono el registro", this.eTitulo);

            //actualizar al propietario
            this.wEdiRegCom.eClaveDgvMovDet = ListaG.ObtenerUltimoValor<RegContabDetaEN>(this.wEdiRegCom.eLisRegConDet, RegContabDetaEN.ClaObj);
            this.wEdiRegCom.MostrarRegContabDetas();
            this.wEdiRegCom.MostrarCalculosDistribucion();

            //limpiar controles
            this.MostrarRegContabDeta(RegContabDetaRN.EnBlanco());            
            this.CambiarItemDebeHaberSegunTipoDocumento();
            this.MostrarImporteSolSugerido();
            eMas.AccionPasarTextoPrincipal();
            this.txtCodCue.Focus();
        }

        public void AdicionarRegContabDeta()
        {
            //asignar parametros
            RegContabDetaEN iObjEN = this.NuevoRegContabDetaDeVentana();
            
            //ejecutar metodo
            RegContabDetaRN.AdicionarRegContabDeta(this.wEdiRegCom.eLisRegConDet, iObjEN);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //volver a preguntar si es acto
            //if (this.wEdiRegCom.EsActoModificarRegContabDeta().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarRegContabDeta();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("se modifico el registro", this.eTitulo);

            //actualizar al wUsu
            this.wEdiRegCom.eClaveDgvMovDet = this.wEdiRegCom.eLisRegConDet[Dgv.ObtenerIndiceRegistroXFranja(this.wEdiRegCom.dgvRegConDet)].ClaveObjeto;
            this.wEdiRegCom.MostrarRegContabDetas();
            this.wEdiRegCom.MostrarCalculosDistribucion();

            //salir de la ventana
            this.Close();
        }

        public void ModificarRegContabDeta()
        {
            //asignar los nuevos valores
            this.AsignarRegContabDeta(this.wEdiRegCom.eLisRegConDet[Dgv.ObtenerIndiceRegistroXFranja(this.wEdiRegCom.dgvRegConDet)]);            
        }

        public void Eliminar()
        {
            //volver a preguntar si es acto
            //if (this.wEdiRegCom.EsActoEliminarRegContabDeta().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarRegContabDeta();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("se elimino el registro", this.eTitulo);

            //actualizar al propietario           
            this.wEdiRegCom.MostrarRegContabDetas();
            this.wEdiRegCom.MostrarCalculosDistribucion();

            //salir de la ventana
            this.Close();
        }

        public void EliminarRegContabDeta()
        {
            this.wEdiRegCom.eLisRegConDet.RemoveAt(Dgv.ObtenerIndiceRegistroXFranja(this.wEdiRegCom.dgvRegConDet));
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
            win.eCtrlFoco = this.cmbCDebHab;
            win.eTipoCompra = Cmb.ObtenerValor(this.wEdiRegCom.cmbCTipCom, "");
            win.eCondicionLista = Listas.wLisCue.Condicion.CuentasAnaliticasParaRegistroCompraDetalle;
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
            string iTipoCompra = Cmb.ObtenerValor(this.wEdiRegCom.cmbCTipCom, "");

            //ejecutar metodo
            iCueEN = CuentaRN.EsCuentaParaRegistroCompraDetalleValido(iCueEN, iTipoCompra);

            //mensaje de error
            Generico.MostrarMensajeError(iCueEN.Adicionales, this.txtCodCue);

            //mostrar datos
            this.txtCodCue.Text = iCueEN.CodigoCuenta;
            this.txtDesCue.Text = iCueEN.DescripcionCuenta;
            this.txtCCenCosCue.Text = iCueEN.CCentroCosto;
            this.txtCAlm.Text = iCueEN.CAlmacen;
            this.txtCAreCue.Text = iCueEN.CArea;
            this.txtCAux.Text = iCueEN.CAuxiliar;
            this.txtCDoc.Text = iCueEN.CDocumento;
            this.txtCAut.Text = iCueEN.CAutomatica;
            this.txtCodCueAut1.Text = iCueEN.CodigoCuentaAutomatica1;
            this.txtCodCueAut2.Text = iCueEN.CodigoCuentaAutomatica2;

            //habilitar controles segun cambio cuenta
            this.CambiarAtributoSoloLecturaAlCambiarCuenta();

            //devolver
            return iCueEN.Adicionales.EsVerdad;
        }

        public void ListarIngresosEgresos()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodIngEgr.ReadOnly == true) { return; }

            //instanciar
            wLisItemE win = new wLisItemE();
            win.eVentana = this;
            win.eTituloVentana = "Ingresos & Egresos";
            win.eCtrlValor = this.txtCodIngEgr;
            win.eCtrlFoco = this.txtCCenCos;
            win.eIteEN.CodigoTabla = "InEg";            
            win.eCondicionLista = Listas.wLisItemE.Condicion.ItemsActivosXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoIngresoEgresoValido()
        {
            return Generico.EsCodigoItemEActivoValido("InEg", this.txtCodIngEgr, this.txtNIngEgr, "Ingreso & Egreso");
        }

        public void ListarCentrosCosto()
        {
            //si es de lectura , entonces no lista
            if (this.txtCCenCos.ReadOnly == true) { return; }

            //instanciar
            wLisItemE win = new wLisItemE();
            win.eVentana = this;
            win.eTituloVentana = "Centros Costo";
            win.eCtrlValor = this.txtCCenCos;
            win.eCtrlFoco = this.txtCAre;
            win.eIteEN.CodigoTabla = "CenCos";
            win.eCondicionLista = Listas.wLisItemE.Condicion.ItemsActivosXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoCentroCostoValido()
        {
            return Generico.EsCodigoItemEActivoValido("CenCos", this.txtCCenCos, this.txtNCenCos, "Centro Costo");
        }

        public void ListarAreas()
        {
            //si es de lectura , entonces no lista
            if (this.txtCAre.ReadOnly == true) { return; }

            //instanciar
            wLisItemE win = new wLisItemE();
            win.eVentana = this;
            win.eTituloVentana = "Areas";
            win.eCtrlValor = this.txtCAre;
            win.eCtrlFoco = this.txtCodAlm;
            win.eIteEN.CodigoTabla = "Area";
            win.eCondicionLista = Listas.wLisItemE.Condicion.ItemsActivosXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoAreaValido()
        {
            return Generico.EsCodigoItemEActivoValido("Area", this.txtCAre, this.txtNAre, "Area");
        }

        public void ListarAlmacenes()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodAlm.ReadOnly == true) { return; }

            //instanciar
            wLisItemE win = new wLisItemE();
            win.eVentana = this;
            win.eTituloVentana = "Almacenes";
            win.eCtrlValor = this.txtCodAlm;
            win.eCtrlFoco = this.txtCodIteAlm;
            win.eIteEN.CodigoTabla = "Alm";
            win.eCondicionLista = Listas.wLisItemE.Condicion.ItemsActivosXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoAlmacenValido()
        {
            return Generico.EsCodigoItemEActivoValido("Alm", this.txtCodAlm, this.txtDesAlm, "Almacen");
        }

        public void ListarItemsAlmacen()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodIteAlm.ReadOnly == true) { return; }

            //instanciar
            wLisIteAlm win = new wLisIteAlm();
            win.eVentana = this;
            win.eTituloVentana = "Almacenes";
            win.eCtrlValor = this.txtCodIteAlm;
            win.eCtrlFoco = this.txtCanIteAlm;
            win.eObjEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            win.eCondicionLista = Listas.wLisIteAlm.Condicion.ItemsAlmacenesActivasDeAlmacen;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsItemAlmacenValido()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodIteAlm.ReadOnly == true) { return true; }

            //asignar parametros
            ItemAlmacenEN iIteAlmEN = new ItemAlmacenEN();
            iIteAlmEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iIteAlmEN.CodigoItemAlmacen = this.txtCodIteAlm.Text.Trim();
            iIteAlmEN.ClaveItemAlmacen = ItemAlmacenRN.ObtenerClaveItemAlmacen(iIteAlmEN);

            //ejecutar metodo
            iIteAlmEN = ItemAlmacenRN.EsItemAlmacenActivoValido(iIteAlmEN);

            //mensaje de error
            Generico.MostrarMensajeError(iIteAlmEN.Adicionales, this.txtCodIteAlm);

            //mostrar datos
            this.txtCodIteAlm.Text = iIteAlmEN.CodigoItemAlmacen;
            this.txtDesIteAlm.Text = iIteAlmEN.DescripcionItemAlmacen;

            //devolver
            return iIteAlmEN.Adicionales.EsVerdad;
        }

        public void CambiarAtributoSoloLecturaAlCambiarCuenta()
        {
            this.CambiarAtributoSoloLecturaACentroCosto();
            this.CambiarAtributoSoloLecturaAAlmacen();
            this.CambiarAtributoSoloLecturaAArea(); 
        }

        public void CambiarAtributoSoloLecturaACentroCosto()
        {
            //asignar parametros
            RegContabDetaEN iRegConDetEN = this.NuevoRegContabDetaDeVentana();

            //ejecutar metodo
            bool iValor = RegContabDetaRN.EsDigitableCentroCosto(iRegConDetEN);

            //cambiar atributo readOnly y limpiar
            Txt.SoloEscritura3(this.txtCCenCos, !iValor);
            Txt.Limpiar(this.txtCCenCos, !iValor);
            Txt.Limpiar(this.txtNCenCos, !iValor);
        }

        public void CambiarAtributoSoloLecturaAArea()
        {
            //asignar parametros
            RegContabDetaEN iRegConDetEN = this.NuevoRegContabDetaDeVentana();

            //ejecutar metodo
            bool iValor = RegContabDetaRN.EsDigitableArea(iRegConDetEN);

            //cambiar atributo readOnly y limpiar
            Txt.SoloEscritura3(this.txtCAre, !iValor);
            Txt.Limpiar(this.txtCAre, !iValor);
            Txt.Limpiar(this.txtNAre, !iValor);
        }

        public void CambiarAtributoSoloLecturaAAlmacen()
        {
            //asignar parametros
            RegContabDetaEN iRegConDetEN = this.NuevoRegContabDetaDeVentana();

            //ejecutar metodo
            bool iValor = RegContabDetaRN.EsDigitableAlmacen(iRegConDetEN);

            //cambiar atributo readOnly y limpiar
            Txt.SoloEscritura3(this.txtCodAlm, !iValor);
            Txt.SoloEscritura3(this.txtCodIteAlm, !iValor);
            Txt.SoloEscritura3(this.txtCanIteAlm, !iValor);
            Txt.Limpiar(this.txtCodAlm, !iValor);
            Txt.Limpiar(this.txtDesAlm, !iValor);
            Txt.Limpiar(this.txtCodIteAlm, !iValor);
            Txt.Limpiar(this.txtDesIteAlm, !iValor);
            Txt.Limpiar(this.txtCanIteAlm, "0.00", !iValor);
        }

        public void CambiarItemDebeHaberSegunTipoDocumento()
        {
            //asignar parametros
            RegContabDetaEN iRegConDetEN = this.NuevoRegContabDetaDeVentana();

            //ejecutar metodo
            string iValor = RegContabDetaRN.ObtenerCodigoDebeHaberSegunTipoDocumentoEnCompra(iRegConDetEN);

            //mostrar en pantalla
            Cmb.SeleccionarValorItem(this.cmbCDebHab, iValor);
        }

        public void MostrarImporteSolSugerido()
        {
            //asignar parametros
            string iCDebHab = Cmb.ObtenerValor(this.cmbCDebHab, "0");
            RegContabCabeEN iRegConCabEN = this.wEdiRegCom.NuevoRegContabCabeDeVentana();
            List<RegContabDetaEN> iLisRegConDet = this.wEdiRegCom.eLisRegConDet;
            
            //ejecutar metodo
            decimal iValor = RegContabDetaRN.ObtenerImporteSolSugerido(iCDebHab, iRegConCabEN, iLisRegConDet);

            //mostrar e pantalla
            this.txtImpSolRegConDet.Text = Formato.NumeroDecimal(iValor, 2);
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.eTitulo);
        }

        #endregion

        private void wDetalleRegistroCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wEdiRegCom.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
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

        private void txtCodIngEgr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarIngresosEgresos(); }
        }

        private void txtCodIngEgr_DoubleClick(object sender, EventArgs e)
        {
            this.ListarIngresosEgresos();
        }

        private void txtCodIngEgr_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoIngresoEgresoValido();
        }

        private void txtCCenCos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarCentrosCosto(); }
        }

        private void txtCCenCos_DoubleClick(object sender, EventArgs e)
        {
            this.ListarCentrosCosto();
        }

        private void txtCCenCos_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoCentroCostoValido();
        }

        private void txtCAre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarAreas(); }
        }

        private void txtCAre_DoubleClick(object sender, EventArgs e)
        {
            this.ListarAreas();
        }

        private void txtCAre_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoAreaValido();
        }

        private void txtCodAlm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarAlmacenes(); }
        }

        private void txtCodAlm_DoubleClick(object sender, EventArgs e)
        {
            this.ListarAlmacenes();
        }

        private void txtCodAlm_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoAlmacenValido();
        }

        private void txtCodIteAlm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarItemsAlmacen(); }
        }

        private void txtCodIteAlm_DoubleClick(object sender, EventArgs e)
        {
            this.ListarItemsAlmacen();
        }

        private void txtCodIteAlm_Validating(object sender, CancelEventArgs e)
        {
            this.EsItemAlmacenValido();
        }
    }
}
