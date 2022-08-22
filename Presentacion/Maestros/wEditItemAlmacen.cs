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
    public partial class wEditItemAlmacen : Heredados.MiForm8
    {
        public wEditItemAlmacen()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();

        #endregion

        #region Propietario

        public wItemAlmacen wIteAlm;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCodAlm, "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodIteAlm, true, "Codigo", "vfff", 20);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDesIteAlm, false, "Descripcion", "vvff", 100);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCUniMed, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCEstIteAlm, "vvff");
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
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wIteAlm.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //llenar Combos
            this.CargarCodigoAlmacen();
            this.CargarCUnidadMedida();
            this.CargarCEstadoItemAlmacen();

            //deshabilitar al propietario
            this.wIteAlm.Enabled = false;

            //mostrar ventana
            this.Show();
        }

        public void CargarCodigoAlmacen()
        {
            Cmb.Cargar(this.cmbCodAlm, ItemERN.ListarItemsE("Alm"), ItemEEN.CodIteE, ItemEEN.NomIteE);
        }

        public void CargarCUnidadMedida()
        {
            Cmb.Cargar(this.cmbCUniMed, ItemGRN.ListarItemsG("UniMed"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCEstadoItemAlmacen()
        {
            Cmb.Cargar(this.cmbCEstIteAlm, ItemGRN.ListarItemsG("EstReg"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarItemAlmacen(ItemAlmacenRN.EnBlanco());
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodIteAlm.Focus();
        }

        public void VentanaModificar(ItemAlmacenEN pObj)
        {
            this.InicializaVentana();
            this.MostrarItemAlmacen(pObj);
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtDesIteAlm.Focus();
        }

        public void VentanaEliminar(ItemAlmacenEN pObj)
        {
            this.InicializaVentana();
            this.MostrarItemAlmacen(pObj);
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(ItemAlmacenEN pObj)
        {
            this.InicializaVentana();
            this.MostrarItemAlmacen(pObj);
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }

        public void AsignarItemAlmacen(ItemAlmacenEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.CodigoAlmacen = Cmb.ObtenerValor(this.cmbCodAlm, string.Empty);
            pObj.CodigoItemAlmacen = this.txtCodIteAlm.Text.Trim();
            pObj.DescripcionItemAlmacen = this.txtDesIteAlm.Text.Trim();
            pObj.CUnidadMedida = Cmb.ObtenerValor(this.cmbCUniMed, string.Empty);
            pObj.CEstadoItemAlmacen = Cmb.ObtenerValor(this.cmbCEstIteAlm, string.Empty);
            pObj.ClaveItemAlmacen = ItemAlmacenRN.ObtenerClaveItemAlmacen(pObj);
        }

        public void MostrarItemAlmacen(ItemAlmacenEN pObj)
        {
            Cmb.SeleccionarValorItem(this.cmbCodAlm, pObj.CodigoAlmacen);
            this.txtCodIteAlm.Text = pObj.CodigoItemAlmacen;
            this.txtDesIteAlm.Text = pObj.DescripcionItemAlmacen;
            Cmb.SeleccionarValorItem(this.cmbCUniMed, pObj.CUnidadMedida);
            Cmb.SeleccionarValorItem(this.cmbCEstIteAlm, pObj.CEstadoItemAlmacen);
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

            //es valido el codigo
            if (this.EsCodigoItemAlmacenDisponible() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wIteAlm.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarItemAlmacen();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El ItemAlmacen se adiciono correctamente", this.wIteAlm.eTitulo);

            //actualizar al propietario
            this.wIteAlm.eClaveDgvIteAlm = this.ObtenerClaveItemAlmacen();
            this.wIteAlm.ActualizarVentana();

            //limpiar controles
            this.MostrarItemAlmacen(ItemAlmacenRN.EnBlanco());
            eMas.AccionPasarTextoPrincipal();
            this.txtCodIteAlm.Focus();
        }

        public void AdicionarItemAlmacen()
        {
            ItemAlmacenEN iObjEN = new ItemAlmacenEN();
            this.AsignarItemAlmacen(iObjEN);
            ItemAlmacenRN.AdicionarItemAlmacen(iObjEN);
        }

        public string ObtenerClaveItemAlmacen()
        {
            ItemAlmacenEN iObjEN = new ItemAlmacenEN();
            this.AsignarItemAlmacen(iObjEN);
            return iObjEN.ClaveItemAlmacen;
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //volver a preguntar si es acto
            if (this.wIteAlm.EsActoModificarItemAlmacen().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wIteAlm.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarItemAlmacen();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El ItemAlmacen se modifico correctamente", this.wIteAlm.eTitulo);

            //actualizar al wUsu
            this.wIteAlm.eClaveDgvIteAlm = this.ObtenerClaveItemAlmacen();
            this.wIteAlm.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void ModificarItemAlmacen()
        {
            ItemAlmacenEN iObjEN = new ItemAlmacenEN();
            this.AsignarItemAlmacen(iObjEN);
            iObjEN = ItemAlmacenRN.BuscarItemAlmacenXClave(iObjEN);
            this.AsignarItemAlmacen(iObjEN);
            ItemAlmacenRN.ModificarItemAlmacen(iObjEN);
        }

        public void Eliminar()
        {
            //volver a preguntar si es acto
            if (this.wIteAlm.EsActoEliminarItemAlmacen().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wIteAlm.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarItemAlmacen();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El ItemAlmacen se elimino correctamente", this.wIteAlm.eTitulo);

            //actualizar al propietario           
            this.wIteAlm.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void EliminarItemAlmacen()
        {
            ItemAlmacenEN iObjEN = new ItemAlmacenEN();
            this.AsignarItemAlmacen(iObjEN);
            ItemAlmacenRN.EliminarItemAlmacen(iObjEN);
        }

        public bool EsCodigoItemAlmacenDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            //Asignar parametros
            ItemAlmacenEN iObjEN = new ItemAlmacenEN();
            this.AsignarItemAlmacen(iObjEN);

            //ejecutar metodo
            iObjEN = ItemAlmacenRN.EsCodigoItemAlmacenDisponible(iObjEN);

            //mensaje de error
            Generico.MostrarMensajeError(iObjEN.Adicionales, this.txtCodIteAlm);

            //devolver
            return iObjEN.Adicionales.EsVerdad;
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wIteAlm.eTitulo);
        }

        #endregion

        private void wEditItemAlmacen_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wIteAlm.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void txtCodIteAlm_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoItemAlmacenDisponible();
        }
    }
}
