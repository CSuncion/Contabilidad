using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Presentacion.Utilidades;

namespace Presentacion.Maestros
{
    public partial class wEditAuxiliar : Heredados.MiForm8
    {
        public wEditAuxiliar()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();

        #endregion

        #region Propietario

        public wAuxiliar wAux;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbTipDocAux, "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroSinEspacion(this.txtCodAux, true, "Numero", "vfff", 11);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbTipAux, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbClaAux, "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtApePatAux, true, "Apellido paterno", "vvff", 50);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtApeMatAux, true, "Apellido materno", "vvff", 50);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtPriNomAux, true, "1° nombre", "vvff", 50);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtSegNomAux, false, "2° Nombre", "vvff", 50);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDesAux, true, "Nombre", "vvff", 200);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDirAux, true, "Direccion", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtTelAux, false, "Telefono", "vvff", 20);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCelAux, false, "Celular", "vvff", 10);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCorAux, false, "Correo", "vvff", 40);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtRefAux, false, "Referencia", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCPaiNoDomAux, false, "Pais no domiciliado", "vvff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNPaiNoDomAux, this.txtCPaiNoDomAux, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbEstAux, "vvff");
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
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wAux.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //llenar combos      
            this.CargarClasesAuxiliar();
            this.CargarTiposAuxiliar();
            this.CargarTiposDocumentoAuxiliar();
            this.CargarEstadosAuxiliar();

            // Deshabilitar al propietario
            this.wAux.Enabled = false;

            // Mostrar ventana
            this.Show();
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarAuxiliar(AuxiliarRN.EnBlanco());
            eMas.AccionHabilitarControles(0);
            this.EfectoAlCambiarClaseAuxiliar();
            eMas.AccionPasarTextoPrincipal();
            this.cmbTipDocAux.Focus();
        }

        public void VentanaModificar(AuxiliarEN pObj)
        {
            this.InicializaVentana();
            this.MostrarAuxiliar(pObj);
            eMas.AccionHabilitarControles(1);
            this.EfectoHabilitarAlCambiarClase();
            this.ArmarDescripcionAuxiliar();
            eMas.AccionPasarTextoPrincipal();
            this.cmbTipAux.Focus();
        }

        public void VentanaCopiar(AuxiliarEN pObj)
        {
            this.InicializaVentana();
            this.MostrarAuxiliar(pObj);
            eMas.AccionHabilitarControles(0);
            this.EfectoHabilitarAlCambiarClase();
            this.ArmarDescripcionAuxiliar();
            eMas.AccionPasarTextoPrincipal();
            this.cmbTipDocAux.Focus();
        }

        public void VentanaEliminar(AuxiliarEN pObj)
        {
            this.InicializaVentana();
            this.MostrarAuxiliar(pObj);
            //this.EfectoHabilitarAlCambiarClase();
            this.ArmarDescripcionAuxiliar();
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(AuxiliarEN pObj)
        {
            this.InicializaVentana();
            this.MostrarAuxiliar(pObj);
            //this.EfectoHabilitarAlCambiarClase();
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }

        public void CargarClasesAuxiliar()
        {
            Cmb.Cargar(this.cmbClaAux, ItemGRN.ListarItemsG("ClaAux"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarTiposAuxiliar()
        {
            Cmb.Cargar(this.cmbTipAux, ItemGRN.ListarItemsG("TipAux"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarTiposDocumentoAuxiliar()
        {
            Cmb.Cargar(this.cmbTipDocAux, ItemGRN.ListarItemsG("Tdi"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarEstadosAuxiliar()
        {
            Cmb.Cargar(this.cmbEstAux, ItemGRN.ListarItemsG("EstReg"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void AsignarAuxiliar(AuxiliarEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.CodigoAuxiliar = this.txtCodAux.Text.Trim();
            pObj.CClaseAuxiliar = Cmb.ObtenerValor(this.cmbClaAux, string.Empty);
            pObj.ApellidoPaternoAuxiliar = this.txtApePatAux.Text.Trim();
            pObj.ApellidoMaternoAuxiliar = this.txtApeMatAux.Text.Trim();
            pObj.PrimerNombreAuxiliar = this.txtPriNomAux.Text.Trim();
            pObj.SegundoNombreAuxiliar = this.txtSegNomAux.Text.Trim();
            pObj.DescripcionAuxiliar = this.txtDesAux.Text.Trim();
            pObj.DireccionAuxiliar = this.txtDirAux.Text.Trim();
            pObj.TelefonoAuxiliar = this.txtTelAux.Text.Trim();
            pObj.CelularAuxiliar = this.txtCelAux.Text.Trim();
            pObj.CorreoAuxiliar = this.txtCorAux.Text.Trim();
            pObj.ReferenciaAuxiliar = this.txtRefAux.Text.Trim();
            pObj.CTipoAuxiliar = Cmb.ObtenerValor(this.cmbTipAux, string.Empty);
            pObj.NTipoAuxiliar = Cmb.ObtenerTexto(this.cmbTipAux);
            pObj.CTipoDocumentoAuxiliar = Cmb.ObtenerValor(this.cmbTipDocAux, string.Empty);
            pObj.CPaisNoDomiciliadoAuxiliar = this.txtCPaiNoDomAux.Text.Trim();
            pObj.CEstadoAuxiliar = Cmb.ObtenerValor(this.cmbEstAux, string.Empty);
            pObj.ClaveAuxiliar = AuxiliarRN.ObtenerClaveAuxiliar(pObj);
        }

        public void MostrarAuxiliar(AuxiliarEN pObj)
        {
            this.txtCodAux.Text = pObj.CodigoAuxiliar;
            this.cmbClaAux.SelectedValue = pObj.CClaseAuxiliar;
            this.txtApePatAux.Text = pObj.ApellidoPaternoAuxiliar;
            this.txtApeMatAux.Text = pObj.ApellidoMaternoAuxiliar;
            this.txtPriNomAux.Text = pObj.PrimerNombreAuxiliar;
            this.txtSegNomAux.Text = pObj.SegundoNombreAuxiliar;
            this.txtDesAux.Text = pObj.DescripcionAuxiliar;
            this.txtDirAux.Text = pObj.DireccionAuxiliar;
            this.txtTelAux.Text = pObj.TelefonoAuxiliar;
            this.txtCelAux.Text = pObj.CelularAuxiliar;
            this.txtCorAux.Text = pObj.CorreoAuxiliar;
            this.txtRefAux.Text = pObj.ReferenciaAuxiliar;
            this.cmbTipAux.SelectedValue = pObj.CTipoAuxiliar;
            this.cmbTipDocAux.SelectedValue = pObj.CTipoDocumentoAuxiliar;
            this.txtCPaiNoDomAux.Text = pObj.CPaisNoDomiciliadoAuxiliar;
            this.txtNPaiNoDomAux.Text = pObj.NPaisNoDomiciliadoAuxiliar;
            this.cmbEstAux.SelectedValue = pObj.CEstadoAuxiliar;
        }

        public void Aceptar()
        {
            switch (this.eOperacion)
            {
                case Universal.Opera.Adicionar: { this.Adicionar(); break; }
                case Universal.Opera.Modificar: { this.Modificar(); break; }
                case Universal.Opera.Eliminar: { this.Eliminar(); break; }
                case Universal.Opera.Copiar: { this.Copiar(); break; }
                default: break;
            }
        }

        public void Adicionar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //el codigo de usuario ya existe?
            if (this.EsCodigoAuxiliarDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wAux.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarAuxiliar();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Auxiliar se adiciono correctamente", this.wAux.eTitulo);

            //actualizar al propietario
            this.wAux.eClaveDgvAux = this.ObtenerClaveAuxiliar();
            this.wAux.ActualizarVentana();

            //limpiar controles
            this.MostrarAuxiliar(AuxiliarRN.EnBlanco());
            this.EfectoAlCambiarClaseAuxiliar();
            eMas.AccionPasarTextoPrincipal();
            this.cmbTipDocAux.Focus();
        }

        public string ObtenerClaveAuxiliar()
        {
            //asignar parametros
            AuxiliarEN iAuxEN = new AuxiliarEN();
            this.AsignarAuxiliar(iAuxEN);

            //devolver
            return iAuxEN.ClaveAuxiliar;
        }

        public void AdicionarAuxiliar()
        {
            AuxiliarEN iPerEN = new AuxiliarEN();
            this.AsignarAuxiliar(iPerEN);
            AuxiliarRN.AdicionarAuxiliar(iPerEN);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wAux.EsActoModificarAuxiliar().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wAux.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarAuxiliar();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Auxiliar se modifico correctamente", this.wAux.eTitulo);

            //actualizar al wUsu
            this.wAux.eClaveDgvAux = this.ObtenerClaveAuxiliar();
            this.wAux.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }

        public void ModificarAuxiliar()
        {
            AuxiliarEN iPerEN = new AuxiliarEN();
            this.AsignarAuxiliar(iPerEN);
            iPerEN = AuxiliarRN.BuscarAuxiliarXClave(iPerEN);
            this.AsignarAuxiliar(iPerEN);
            AuxiliarRN.ModificarAuxiliar(iPerEN);
        }

        public void Copiar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //el codigo de usuario ya existe?
            if (this.EsCodigoAuxiliarDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wAux.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarAuxiliar();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Auxiliar se copio correctamente", this.wAux.eTitulo);

            //actualizar al propietario
            this.wAux.eClaveDgvAux = this.ObtenerClaveAuxiliar();
            this.wAux.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wAux.EsActoEliminarAuxiliar().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wAux.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarAuxiliar();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Auxiliar se elimino correctamente", this.wAux.eTitulo);

            //actualizar al propietario           
            this.wAux.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void EliminarAuxiliar()
        {
            AuxiliarEN iPerEN = new AuxiliarEN();
            this.AsignarAuxiliar(iPerEN);
            AuxiliarRN.EliminarAuxiliar(iPerEN);
        }

        public bool EsCodigoAuxiliarDisponible()
        {
            //cuando la operacion es diferente del adicionar o copiar entonces retorna verdadero
            if (MiForm.VerdaderoCuandoSoloAdicionaYCopia((int)eOperacion) == false) { return true; }

            //validar
            AuxiliarEN iAuxEN = new AuxiliarEN();
            this.AsignarAuxiliar(iAuxEN);
            iAuxEN = AuxiliarRN.EsCodigoAuxiliarDisponible(iAuxEN);
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, this.wAux.eTitulo);
                this.txtCodAux.Clear();
                this.txtCodAux.Focus();
            }
            return iAuxEN.Adicionales.EsVerdad;
        }

        public void EfectoAlCambiarClaseAuxiliar()
        {
            //solo se puede ejecutar cuando se adiciona
            if (MiForm.VerdaderoCuandoSoloAdicionaYCopia((int)eOperacion) == false) { return; }

            //habilitar controles
            this.EfectoHabilitarAlCambiarClase();

            //limpiar controles
            this.EfectoLimpiarAlCambiarClase();

            //volver armar el nombre completo asociado
            this.ArmarDescripcionAuxiliar();
        }

        public void EfectoHabilitarAlCambiarClase()
        {
            //------------------
            //asignar parametros
            //------------------
            Hashtable iLisConVF = this.ListarControlesHabilitarXClase();
            int iIndVF = Convert.ToInt32(Cmb.ObtenerValor(this.cmbClaAux, "0"));

            //---------------
            //ejecutar metodo
            //---------------
            MiControl.Habilitar(iLisConVF, iIndVF);
        }

        public Hashtable ListarControlesHabilitarXClase()
        {
            //crear la lista
            Hashtable iLisConVF = new Hashtable();

            //insertar los controles
            iLisConVF.Add(this.txtApePatAux, "vf");
            iLisConVF.Add(this.txtApeMatAux, "vf");
            iLisConVF.Add(this.txtPriNomAux, "vf");
            iLisConVF.Add(this.txtSegNomAux, "vf");
            iLisConVF.Add(this.txtDesAux, "fv");
            iLisConVF.Add(this.txtCPaiNoDomAux, "fv");


            //devolver
            return iLisConVF;
        }

        public void EfectoLimpiarAlCambiarClase()
        {
            //------------------
            //asignar parametros
            //------------------
            Hashtable iLisConVF = this.ListarControlesLimpiarXClase();
            int iIndVF = Convert.ToInt32(Cmb.ObtenerValor(this.cmbClaAux, "0"));

            //---------------
            //ejecutar metodo
            //---------------
            MiControl.Limpiar(iLisConVF, iIndVF);
        }

        public Hashtable ListarControlesLimpiarXClase()
        {
            //crear la lista
            Hashtable iLisConVF = new Hashtable();

            //insertar los controles
            iLisConVF.Add(txtApePatAux, "fv");
            iLisConVF.Add(txtApeMatAux, "fv");
            iLisConVF.Add(txtPriNomAux, "fv");
            iLisConVF.Add(txtSegNomAux, "fv");
            iLisConVF.Add(txtDesAux, "vf");
            iLisConVF.Add(txtCPaiNoDomAux, "vf");
            iLisConVF.Add(txtNPaiNoDomAux, "vf");

            //devolver
            return iLisConVF;
        }

        public void ArmarDescripcionAuxiliar()
        {
            AuxiliarEN iAuxEN = new AuxiliarEN();
            iAuxEN.ApellidoPaternoAuxiliar = this.txtApePatAux.Text.Trim();
            iAuxEN.ApellidoMaternoAuxiliar = this.txtApeMatAux.Text.Trim();
            iAuxEN.PrimerNombreAuxiliar = this.txtPriNomAux.Text.Trim();
            iAuxEN.SegundoNombreAuxiliar = this.txtSegNomAux.Text.Trim();
            iAuxEN.DescripcionAuxiliar = this.txtDesAux.Text.Trim();
            iAuxEN.CClaseAuxiliar = Cmb.ObtenerValor(this.cmbClaAux, "0");
            this.txtDesAux.Text = AuxiliarRN.ArmarDescripcionAuxiliar(iAuxEN);
        }

        public void ListarPaisesNoDomiciliados()
        {
            //si es de lectura , entonces no lista
            if (this.txtCPaiNoDomAux.ReadOnly == true) { return; }

            //instanciar
            wLisItemG win = new wLisItemG();
            win.eVentana = this;
            win.eTituloVentana = "Paises";
            win.eCtrlValor = this.txtCPaiNoDomAux;
            win.eCtrlFoco = this.cmbEstAux;
            win.eIteEN.CodigoTabla = "Pais";
            win.eCondicionLista = Listas.wLisItemG.Condicion.ItemsActivosXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsPaisNoDomiciliadoValido()
        {
            return Generico.EsCodigoItemGValido("Pais", this.txtCPaiNoDomAux, this.txtNPaiNoDomAux, "Pais");
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wAux.eTitulo);
        }

        public async void peticionSunatRuc()
        {
            AuxiliarSunatEN aux = new AuxiliarSunatEN()
            {
                token = "CMrogiyPeqv9TcxcceYBrGlGwAx7uRb7KS0WOuxrlBAA77glqbLAT7lCKRwq",
                ruc = this.txtCodAux.Text.Trim()
            };
            //Instanciamos un objeto Reply
            Reply oReply = new Reply();
            //poblamos el objeto con el método generic Execute
            oReply = await Consumer.Execute<AuxiliarSunatEN>("https://api.migo.pe/api/v1/ruc ", Utilidades.methodHttp.POST, aux);
            //Mostramos el statuscode devuelto, podemos añadirle lógica de validación
            MessageBox.Show(oReply.StatusCode);
        }

        #endregion

        private void wEditAuxiliar_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wAux.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void txtCodAux_Validated(object sender, EventArgs e)
        {
            this.EsCodigoAuxiliarDisponible();
        }

        private void cmbClaAux_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.EfectoAlCambiarClaseAuxiliar();
        }

        private void txtApePatAux_Validated(object sender, EventArgs e)
        {
            this.ArmarDescripcionAuxiliar();
        }

        private void txtCPaiNoDomAux_Validating(object sender, CancelEventArgs e)
        {
            this.EsPaisNoDomiciliadoValido();
        }

        private void txtCPaiNoDomAux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarPaisesNoDomiciliados(); }
        }

        private void txtCPaiNoDomAux_DoubleClick(object sender, EventArgs e)
        {
            this.ListarPaisesNoDomiciliados();
        }

        private void btnSunat_Click(object sender, EventArgs e)
        {
            this.peticionSunatRuc();
        }
    }
}
