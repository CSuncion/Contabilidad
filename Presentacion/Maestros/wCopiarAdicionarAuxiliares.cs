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
using Entidades;
using Negocio;
using Presentacion.Listas;

namespace Presentacion.Maestros
{
    public partial class wCopiarAdicionarAuxiliares : Heredados.MiForm8
    {
        public wCopiarAdicionarAuxiliares()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        List<AuxiliarEN> eLisAux = new List<AuxiliarEN>();

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
            xCtrl.TxtTodo(this.txtCodEmp1, true, "Empresa", "vfff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNomEmp1, this.txtCodEmp1, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnFiltrar, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnMarcarTodas, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnDesmarcarTodas, "vvvf");
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
            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();
         
            //Deshabilitar al propietario de esta ventana
            this.wAux.Enabled = false;
                     
            //Mostrar ventana
            this.Show();            
        }                

        public void NuevaVentana()
        {
            this.InicializaVentana();            
            this.ActualizarListaAuxiliarsParaBD();
            this.ActualizarDgvAux();
            this.txtCodEmp1.Focus();
        }

        public void ActualizarDgvAux()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvAux;
            List<AuxiliarEN> iFuenteDatos = eLisAux;
            Dgv.Franja iCondicionFranja = Dgv.Franja.PorIndice;
            string iClaveBusqueda = string.Empty;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvAux();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvAux()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaCheckBox(AuxiliarEN.VerFal, "Seleccionar", 85));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AuxiliarEN.CodAux, "Numero", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AuxiliarEN.DesAux, "Descripcion", 200));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AuxiliarEN.NTipAux, "Tipo", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AuxiliarEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaAuxiliarsParaBD()
        {
            eLisAux = this.ListarAuxiliarsParaCopiaAEmpresa();
        }

        public List<AuxiliarEN> ListarAuxiliarsParaCopiaAEmpresa()
        {
            //Asignar parametros
            string iCodigoEmpresaCopia = this.txtCodEmp1.Text.Trim();
            string iCodigoEmpresaGuarda = Universal.gCodigoEmpresa;

            //ejecutar metodo
            return AuxiliarRN.ListarAuxiliarsParaCopiarAEmpresa(iCodigoEmpresaCopia, iCodigoEmpresaGuarda);
        }

        public void ModificarAuxiliar()
        {
            //asignar parametros
            AuxiliarEN iCuoEN = new AuxiliarEN();
            iCuoEN.ClaveAuxiliar = Dgv.ObtenerValorCelda(this.DgvAux, AuxiliarEN.ClaObj);
            iCuoEN.VerdadFalso = Dgv.ObtenerValorCeldaCheckBox(this.DgvAux, VentanaBotonEN.VerFal);

            //ejecutar metodo
            AuxiliarRN.ModificarVerdadFalsoAuxiliar(iCuoEN, this.eLisAux);
        }
        
        public void Aceptar()
        {
            //validar campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //validar si hay Auxiliars marcadas
            if (this.HayMarcados() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion("Agregar Auxiliares") == false) { return; }

            //agregar las Auxiliars marcadas
            this.AgregarAuxiliars();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se agregaron las Auxiliares correctamente", "Auxiliares");

            //actualizar ventana propietario
            this.wAux.ActualizarVentana();

            //cerrar
            this.Close();
        }
               
        public bool HayMarcados()
        {
            AuxiliarEN iCuoMarEN = AuxiliarRN.HayObjetosMarcados(eLisAux);
            if (iCuoMarEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCuoMarEN.Adicionales.Mensaje, this.wAux.eTitulo);               
            }
            return iCuoMarEN.Adicionales.EsVerdad;  
        }

        public void AgregarAuxiliars()
        { 
            //asignar parametros
            List<AuxiliarEN> iLisAuxMar = AuxiliarRN.ListarAuxiliarsSoloMarcadas(this.eLisAux);
            List<AuxiliarEN> iLisAuxVal = this.ListarAuxiliarsParaCopiaAEmpresa();
            string iCodigoEmpresaGuarda = Universal.gCodigoEmpresa;

            //ejecutar metodo
            AuxiliarRN.AdicionarAuxiliarsPorCopia(iCodigoEmpresaGuarda, iLisAuxMar, iLisAuxVal);
        }

        public void ListarEmpresas1()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodEmp1.ReadOnly == true) { return; }

            //instanciar
            wLisEmp win = new wLisEmp();
            win.eVentana = this;
            win.eTituloVentana = "Empresas";
            win.eCtrlValor = this.txtCodEmp1;
            win.eCtrlFoco = this.btnFiltrar;
            win.eEmpEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            win.eCondicionLista = Listas.wLisEmp.Condicion.EmpresasExceptoUno;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsEmpresa1Valido()
        {
            //si es de lectura , entonces no lista
            if (txtCodEmp1.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            EmpresaEN iEmpEN = new EmpresaEN();
            iEmpEN.CodigoEmpresa = this.txtCodEmp1.Text.Trim();            
            string iCodigoEmpresaExcepcion = Universal.gCodigoEmpresa;
            iEmpEN = EmpresaRN.EsEmpresaValido(iEmpEN, iCodigoEmpresaExcepcion);
            if (iEmpEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iEmpEN.Adicionales.Mensaje, this.wAux.eTitulo);
                this.txtCodEmp1.Focus();
            }

            //mostrar datos
            this.txtCodEmp1.Text = iEmpEN.CodigoEmpresa;
            this.txtNomEmp1.Text = iEmpEN.NombreEmpresa;

            //devolver
            return iEmpEN.Adicionales.EsVerdad;         
        }
            
        public void Filtrar()
        {
            //valida campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //actualizar la grillaa
            this.ActualizarListaAuxiliarsParaBD();
            this.ActualizarDgvAux();
        }

        public void MarcarTodos()
        {
            AuxiliarRN.MarcarTodos(this.eLisAux, true);
            this.ActualizarDgvAux();
        }

        public void DesmarcarTodos()
        {
            AuxiliarRN.MarcarTodos(this.eLisAux, false);
            this.ActualizarDgvAux();
        }

        #endregion

        private void wCopiarAdicionarAuxiliares_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wAux.Enabled = true;           
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();          
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvAux_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.ModificarAuxiliar();
        }

        private void txtCodEmp1_Validating(object sender, CancelEventArgs e)
        {
            this.EsEmpresa1Valido();
        }

        private void txtCodEmp1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarEmpresas1(); }
        }

        private void txtCodEmp1_DoubleClick(object sender, EventArgs e)
        {
            this.ListarEmpresas1();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            this.Filtrar();
        }

        private void btnMarcarTodas_Click(object sender, EventArgs e)
        {
            this.MarcarTodos();
        }

        private void btnDesmarcarTodas_Click(object sender, EventArgs e)
        {
            this.DesmarcarTodos();
        }

   
    }
}
