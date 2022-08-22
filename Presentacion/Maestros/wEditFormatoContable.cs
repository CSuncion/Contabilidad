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
    public partial class wEditFormatoContable : Heredados.MiForm8
    {
        public wEditFormatoContable()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();

        #endregion

        #region Propietario

        public wFormatoContable wForCon;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodForCon, true, "Codigo", "vfff", 8);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDesForCon, false, "Descripcion", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDesAltForCon, false, "Descripcion Alterna", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCGru, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCNat, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCEstForCon, "vvff");
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
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wForCon.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //llenar Combos
            this.CargarCGrupo();
            this.CargarCNaturaleza();
            this.CargarCEstadoFormatoContable();

            //deshabilitar al propietario
            this.wForCon.Enabled = false;

            //mostrar ventana
            this.Show();
        }

        public void CargarCGrupo()
        {
            Cmb.Cargar(this.cmbCGru, ItemGRN.ListarItemsG("GruFC"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCNaturaleza()
        {
            Cmb.Cargar(this.cmbCNat, ItemGRN.ListarItemsG("NatuFC"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCEstadoFormatoContable()
        {
            Cmb.Cargar(this.cmbCEstForCon, ItemGRN.ListarItemsG("EstReg"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarFormatoContable(FormatoContableRN.EnBlanco());
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodForCon.Focus();
        }

        public void VentanaModificar(FormatoContableEN pObj)
        {
            this.InicializaVentana();
            this.MostrarFormatoContable(pObj);
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtDesForCon.Focus();
        }

        public void VentanaEliminar(FormatoContableEN pObj)
        {
            this.InicializaVentana();
            this.MostrarFormatoContable(pObj);
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(FormatoContableEN pObj)
        {
            this.InicializaVentana();
            this.MostrarFormatoContable(pObj);
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }

        public void AsignarFormatoContable(FormatoContableEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.CodigoFormatoContable = this.txtCodForCon.Text.Trim();
            pObj.DescripcionFormatoContable = this.txtDesForCon.Text.Trim();
            pObj.DescripcionAlternaFormatoContable = this.txtDesAltForCon.Text.Trim();
            pObj.CGrupo = Cmb.ObtenerValor(this.cmbCGru, string.Empty);
            pObj.CNaturaleza = Cmb.ObtenerValor(this.cmbCNat, string.Empty);
            pObj.CEstadoFormatoContable = Cmb.ObtenerValor(this.cmbCEstForCon, string.Empty);
            pObj.ClaveFormatoContable = FormatoContableRN.ObtenerClaveFormatoContable(pObj);
        }

        public void MostrarFormatoContable(FormatoContableEN pObj)
        {
            this.txtCodForCon.Text = pObj.CodigoFormatoContable;
            this.txtDesForCon.Text = pObj.DescripcionFormatoContable;
            this.txtDesAltForCon.Text = pObj.DescripcionAlternaFormatoContable;
            Cmb.SeleccionarValorItem(this.cmbCGru, pObj.CGrupo);
            Cmb.SeleccionarValorItem(this.cmbCNat, pObj.CNaturaleza);
            Cmb.SeleccionarValorItem(this.cmbCEstForCon, pObj.CEstadoFormatoContable);
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
            if (this.EsCodigoFormatoContableDisponible() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wForCon.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarFormatoContable();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Formato Contable se adiciono correctamente", this.wForCon.eTitulo);

            //actualizar al propietario
            this.wForCon.eClaveDgvForCon = this.ObtenerClaveFormatoContable();
            this.wForCon.ActualizarVentana();

            //limpiar controles
            this.MostrarFormatoContable(FormatoContableRN.EnBlanco());
            eMas.AccionPasarTextoPrincipal();
            this.txtCodForCon.Focus();
        }

        public void AdicionarFormatoContable()
        {
            FormatoContableEN iObjEN = new FormatoContableEN();
            this.AsignarFormatoContable(iObjEN);
            FormatoContableRN.AdicionarFormatoContable(iObjEN);
        }

        public string ObtenerClaveFormatoContable()
        {
            FormatoContableEN iObjEN = new FormatoContableEN();
            this.AsignarFormatoContable(iObjEN);
            return iObjEN.ClaveFormatoContable;
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //volver a preguntar si es acto
            if (this.wForCon.EsActoModificarFormatoContable().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wForCon.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarFormatoContable();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Formato Contable se modifico correctamente", this.wForCon.eTitulo);

            //actualizar al wUsu
            this.wForCon.eClaveDgvForCon = this.ObtenerClaveFormatoContable();
            this.wForCon.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void ModificarFormatoContable()
        {
            FormatoContableEN iObjEN = new FormatoContableEN();
            this.AsignarFormatoContable(iObjEN);
            iObjEN = FormatoContableRN.BuscarFormatoContableXClave(iObjEN);
            this.AsignarFormatoContable(iObjEN);
            FormatoContableRN.ModificarFormatoContable(iObjEN);
        }

        public void Eliminar()
        {
            //volver a preguntar si es acto
            if (this.wForCon.EsActoEliminarFormatoContable().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wForCon.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarFormatoContable();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Formato Contable se elimino correctamente", this.wForCon.eTitulo);

            //actualizar al propietario           
            this.wForCon.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void EliminarFormatoContable()
        {
            FormatoContableEN iObjEN = new FormatoContableEN();
            this.AsignarFormatoContable(iObjEN);
            FormatoContableRN.EliminarFormatoContable(iObjEN);
        }

        public bool EsCodigoFormatoContableDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            //Asignar parametros
            FormatoContableEN iObjEN = new FormatoContableEN();
            this.AsignarFormatoContable(iObjEN);

            //ejecutar metodo
            iObjEN = FormatoContableRN.EsCodigoFormatoContableDisponible(iObjEN);

            //mensaje de error
            Generico.MostrarMensajeError(iObjEN.Adicionales, this.txtCodForCon);

            //devolver
            return iObjEN.Adicionales.EsVerdad;
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wForCon.eTitulo);
        }

        #endregion

        private void wEditFormatoContable_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wForCon.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void txtCodForCon_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoFormatoContableDisponible();
        }
    }
}
