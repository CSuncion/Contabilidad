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
    public partial class wCopiarAdicionarFormatoContable : Heredados.MiForm8
    {
        public wCopiarAdicionarFormatoContable()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        List<FormatoContableEN> eLisForCon = new List<FormatoContableEN>();

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
            this.wForCon.Enabled = false;
                     
            //Mostrar ventana
            this.Show();            
        }                

        public void NuevaVentana()
        {
            this.InicializaVentana();            
            this.ActualizarListaFormatoContablesParaBD();
            this.ActualizarDgvForCon();
            this.txtCodEmp1.Focus();
        }

        public void ActualizarDgvForCon()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvAux;
            List<FormatoContableEN> iFuenteDatos = eLisForCon;
            Dgv.Franja iCondicionFranja = Dgv.Franja.PorIndice;
            string iClaveBusqueda = string.Empty;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvForCon();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvForCon()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaCheckBox(FormatoContableEN.VerFal, "Seleccionar", 85));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(FormatoContableEN.CodForCon, "Numero", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(FormatoContableEN.DesForCon, "Descripcion", 200));            
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(FormatoContableEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaFormatoContablesParaBD()
        {
            eLisForCon = this.ListarFormatoContablesParaCopiaAEmpresa();
        }

        public List<FormatoContableEN> ListarFormatoContablesParaCopiaAEmpresa()
        {
            //Asignar parametros
            string iCodigoEmpresaCopia = this.txtCodEmp1.Text.Trim();
            string iCodigoEmpresaGuarda = Universal.gCodigoEmpresa;

            //ejecutar metodo
            return FormatoContableRN.ListarFormatoContablesParaCopiarAEmpresa(iCodigoEmpresaCopia, iCodigoEmpresaGuarda);
        }

        public void ModificarFormatoContable()
        {
            //asignar parametros
            FormatoContableEN iCuoEN = new FormatoContableEN();
            iCuoEN.ClaveFormatoContable = Dgv.ObtenerValorCelda(this.DgvAux, FormatoContableEN.ClaObj);
            iCuoEN.VerdadFalso = Dgv.ObtenerValorCeldaCheckBox(this.DgvAux, VentanaBotonEN.VerFal);

            //ejecutar metodo
            FormatoContableRN.ModificarVerdadFalsoFormatoContable(iCuoEN, this.eLisForCon);
        }
        
        public void Aceptar()
        {
            //validar campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //validar si hay FormatoContables marcadas
            if (this.HayMarcados() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion("Agregar Formato Contables") == false) { return; }

            //agregar las FormatoContables marcadas
            this.AgregarFormatoContables();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se agregaron las Formato Contables correctamente", "Formato Contables");

            //actualizar ventana propietario
            this.wForCon.ActualizarVentana();

            //cerrar
            this.Close();
        }
               
        public bool HayMarcados()
        {
            FormatoContableEN iCuoMarEN = FormatoContableRN.HayObjetosMarcados(eLisForCon);
            if (iCuoMarEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCuoMarEN.Adicionales.Mensaje, this.wForCon.eTitulo);               
            }
            return iCuoMarEN.Adicionales.EsVerdad;  
        }

        public void AgregarFormatoContables()
        { 
            //asignar parametros
            List<FormatoContableEN> iLisForConMar = FormatoContableRN.ListarFormatoContablesSoloMarcadas(this.eLisForCon);
            List<FormatoContableEN> iLisForConVal = this.ListarFormatoContablesParaCopiaAEmpresa();
            string iCodigoEmpresaGuarda = Universal.gCodigoEmpresa;

            //ejecutar metodo
            FormatoContableRN.AdicionarFormatoContablesPorCopia(iCodigoEmpresaGuarda, iLisForConMar, iLisForConVal);
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
                Mensaje.OperacionDenegada(iEmpEN.Adicionales.Mensaje, this.wForCon.eTitulo);
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
            this.ActualizarListaFormatoContablesParaBD();
            this.ActualizarDgvForCon();
        }

        public void MarcarTodos()
        {
            FormatoContableRN.MarcarTodos(this.eLisForCon, true);
            this.ActualizarDgvForCon();
        }

        public void DesmarcarTodos()
        {
            FormatoContableRN.MarcarTodos(this.eLisForCon, false);
            this.ActualizarDgvForCon();
        }

        #endregion

        private void wCopiarAdicionarFormatoContable_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wForCon.Enabled = true;           
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();          
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvForCon_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.ModificarFormatoContable();
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
