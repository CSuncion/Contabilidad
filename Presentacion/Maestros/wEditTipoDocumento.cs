using Comun;
using Entidades;
using Entidades.Adicionales;
using Negocio;
using Presentacion.FuncionesGenericas;
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
    public partial class wEditTipoDocumento : Heredados.MiForm8
    {
        public wEditTipoDocumento()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();

        #endregion

        #region Propietario

        public wTipoDocumento wTipDoc;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodTipDoc, true, "Codigo", "vfff", 2);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDesTipDoc, true, "Descripcion", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCAplEnReg, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCAplDocRef, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCTipNot, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCEstTipDoc, "vvff");
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
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wTipDoc.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //llenar Combos
            this.CargarCAplicaEnRegistro();
            this.CargarCAplicaDocumentoRef();
            this.CargarCTipoNota();
            this.CargarCEstadoTipoDocumento();

            //deshabilitar al propietario
            this.wTipDoc.Enabled = false;

            //mostrar ventana
            this.Show();
        }

        public void CargarCAplicaEnRegistro()
        {
            Cmb.Cargar(this.cmbCAplEnReg, ItemGRN.ListarItemsG("AplReg"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCAplicaDocumentoRef()
        {
            Cmb.Cargar(this.cmbCAplDocRef, ItemGRN.ListarItemsG("SiNo"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCTipoNota()
        {
            Cmb.Cargar(this.cmbCTipNot, ItemGRN.ListarItemsG("TiNo"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCEstadoTipoDocumento()
        {
            Cmb.Cargar(this.cmbCEstTipDoc, ItemGRN.ListarItemsG("EstReg"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarTipoDocumento(TipoDocumentoRN.EnBlanco());
            eMas.AccionHabilitarControles(0);
            this.AccionCuandoCambiaAplicaDocRef();
            eMas.AccionPasarTextoPrincipal();
            this.txtCodTipDoc.Focus();
        }

        public void VentanaModificar(TipoDocumentoEN pObj)
        {
            this.InicializaVentana();
            this.MostrarTipoDocumento(pObj);
            eMas.AccionHabilitarControles(1);
            this.AccionCuandoCambiaAplicaDocRef();
            eMas.AccionPasarTextoPrincipal();
            this.txtDesTipDoc.Focus();
        }

        public void VentanaEliminar(TipoDocumentoEN pObj)
        {
            this.InicializaVentana();
            this.MostrarTipoDocumento(pObj);
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(TipoDocumentoEN pObj)
        {
            this.InicializaVentana();
            this.MostrarTipoDocumento(pObj);
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }

        public void AsignarTipoDocumento(TipoDocumentoEN pObj)
        {
            pObj.CodigoTipoDocumento = this.txtCodTipDoc.Text.Trim();
            pObj.DescripcionTipoDocumento = this.txtDesTipDoc.Text.Trim();
            pObj.CAplicaEnRegistro = Cmb.ObtenerValor(this.cmbCAplEnReg, string.Empty);
            pObj.CAplicaDocumentoRef = Cmb.ObtenerValor(this.cmbCAplDocRef, string.Empty);
            pObj.CTipoNota = Cmb.ObtenerValor(this.cmbCTipNot);
            pObj.CEstadoTipoDocumento = Cmb.ObtenerValor(this.cmbCEstTipDoc, string.Empty);
        }

        public void MostrarTipoDocumento(TipoDocumentoEN pObj)
        {
            this.txtCodTipDoc.Text = pObj.CodigoTipoDocumento;
            this.txtDesTipDoc.Text = pObj.DescripcionTipoDocumento;
            Cmb.SeleccionarValorItem(this.cmbCAplEnReg, pObj.CAplicaEnRegistro);
            Cmb.SeleccionarValorItem(this.cmbCAplDocRef, pObj.CAplicaDocumentoRef);
            Cmb.SeleccionarValorItem(this.cmbCTipNot, pObj.CTipoNota);
            Cmb.SeleccionarValorItem(this.cmbCEstTipDoc, pObj.CEstadoTipoDocumento);
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

            //valida cuando codigo ya existe
            if (this.EsCodigoTipoDocumentoDisponible() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wTipDoc.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarTipoDocumento();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Tipo Documento se adiciono correctamente", this.wTipDoc.eTitulo);

            //actualizar al propietario
            this.wTipDoc.eClaveDgvTipDoc = this.ObtenerClaveTipoDocumento();
            this.wTipDoc.ActualizarVentana();

            //limpiar controles
            this.MostrarTipoDocumento(TipoDocumentoRN.EnBlanco());
            this.AccionCuandoCambiaAplicaDocRef();
            eMas.AccionPasarTextoPrincipal();
            this.txtCodTipDoc.Focus();
        }

        public void AdicionarTipoDocumento()
        {
            TipoDocumentoEN iObjEN = new TipoDocumentoEN();
            this.AsignarTipoDocumento(iObjEN);
            TipoDocumentoRN.AdicionarTipoDocumento(iObjEN);
        }

        public string ObtenerClaveTipoDocumento()
        {
            TipoDocumentoEN iObjEN = new TipoDocumentoEN();
            this.AsignarTipoDocumento(iObjEN);
            return iObjEN.CodigoTipoDocumento;
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //volver a preguntar si es acto
            if (this.wTipDoc.EsActoModificarTipoDocumento().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wTipDoc.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarTipoDocumento();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Tipo Documento se modifico correctamente", this.wTipDoc.eTitulo);

            //actualizar al wUsu
            this.wTipDoc.eClaveDgvTipDoc = this.ObtenerClaveTipoDocumento();
            this.wTipDoc.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void ModificarTipoDocumento()
        {
            TipoDocumentoEN iObjEN = new TipoDocumentoEN();
            this.AsignarTipoDocumento(iObjEN);
            iObjEN = TipoDocumentoRN.BuscarTipoDocumentoXCodigo(iObjEN);
            this.AsignarTipoDocumento(iObjEN);
            TipoDocumentoRN.ModificarTipoDocumento(iObjEN);
        }

        public void Eliminar()
        {
            //volver a preguntar si es acto
            if (this.wTipDoc.EsActoEliminarTipoDocumento().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wTipDoc.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarTipoDocumento();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Tipo Documento se elimino correctamente", this.wTipDoc.eTitulo);

            //actualizar al propietario           
            this.wTipDoc.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void EliminarTipoDocumento()
        {
            TipoDocumentoEN iObjEN = new TipoDocumentoEN();
            this.AsignarTipoDocumento(iObjEN);
            TipoDocumentoRN.EliminarTipoDocumento(iObjEN);
        }

        public bool EsCodigoTipoDocumentoDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            //Asignar parametros
            TipoDocumentoEN iObjEN = new TipoDocumentoEN();
            this.AsignarTipoDocumento(iObjEN);

            //ejecutar metodo
            iObjEN = TipoDocumentoRN.EsCodigoTipoDocumentoDisponible(iObjEN);

            //mensaje de error
            Generico.MostrarMensajeError(iObjEN.Adicionales, this.txtCodTipDoc);

            //devolver
            return iObjEN.Adicionales.EsVerdad;
        }

        public void AccionCuandoCambiaAplicaDocRef()
        {
            //asignar parametros
            bool iValor = Conversion.CadenaABoolean(Cmb.ObtenerValor(this.cmbCAplDocRef), false);

            //ejecutar metodo
            Cmb.Habilitar(this.cmbCTipNot, iValor);
        }


        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wTipDoc.eTitulo);
        }


        #endregion

        private void wEditTipoDocumento_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wTipDoc.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void txtCodTipDoc_Validated(object sender, EventArgs e)
        {
            this.EsCodigoTipoDocumentoDisponible();
        }

        private void cmbCAplDocRef_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.AccionCuandoCambiaAplicaDocRef();
        }
    }
}
