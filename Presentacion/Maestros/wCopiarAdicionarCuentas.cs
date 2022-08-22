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
    public partial class wCopiarAdicionarCuentas : Heredados.MiForm8
    {
        public wCopiarAdicionarCuentas()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        List<CuentaEN> eLisCue = new List<CuentaEN>();

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
            this.wCue.Enabled = false;
                     
            //Mostrar ventana
            this.Show();            
        }                

        public void NuevaVentana()
        {
            this.InicializaVentana();            
            this.ActualizarListaCuentasParaBD();
            this.ActualizarDgvCue();
            this.txtCodEmp1.Focus();
        }

        public void ActualizarDgvCue()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvCue;
            List<CuentaEN> iFuenteDatos = eLisCue;
            Dgv.Franja iCondicionFranja = Dgv.Franja.PorIndice;
            string iClaveBusqueda = string.Empty;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCue();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvCue()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaCheckBox(CuentaEN.VerFal, "Seleccionar", 85));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.CodCue, "Codigo", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.DesCue, "Descripcion", 300));            
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaCuentasParaBD()
        {
            eLisCue = this.ListarCuentasParaCopiaAEmpresa();
        }

        public List<CuentaEN> ListarCuentasParaCopiaAEmpresa()
        {
            //Asignar parametros
            string iCodigoEmpresaCopia = this.txtCodEmp1.Text.Trim();
            string iCodigoEmpresaGuarda = Universal.gCodigoEmpresa;

            //ejecutar metodo
            return CuentaRN.ListarCuentasParaCopiarAEmpresa(iCodigoEmpresaCopia, iCodigoEmpresaGuarda);
        }

        public void ModificarCuenta()
        {
            //asignar parametros
            CuentaEN iCuoEN = new CuentaEN();
            iCuoEN.ClaveCuenta = Dgv.ObtenerValorCelda(this.DgvCue, CuentaEN.ClaObj);
            iCuoEN.VerdadFalso = Dgv.ObtenerValorCeldaCheckBox(this.DgvCue, VentanaBotonEN.VerFal);

            //ejecutar metodo
            CuentaRN.ModificarVerdadFalsoCuenta(iCuoEN, this.eLisCue);
        }
        
        public void Aceptar()
        {
            //validar campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //validar si hay Cuentas marcadas
            if (this.HayMarcados() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion("Agregar Cuentas") == false) { return; }

            //agregar las Cuentas marcadas
            this.AgregarCuentas();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se agregaron las Cuentas correctamente", "Cuentas");

            //actualizar ventana propietario
            this.wCue.ActualizarVentana();

            //cerrar
            this.Close();
        }
               
        public bool HayMarcados()
        {
            CuentaEN iCuoMarEN = CuentaRN.HayObjetosMarcados(eLisCue);
            if (iCuoMarEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCuoMarEN.Adicionales.Mensaje, this.wCue.eTitulo);               
            }
            return iCuoMarEN.Adicionales.EsVerdad;  
        }

        public void AgregarCuentas()
        { 
            //asignar parametros
            List<CuentaEN> iLisCueMar = CuentaRN.ListarCuentasSoloMarcadas(this.eLisCue);
            List<CuentaEN> iLisCueVal = this.ListarCuentasParaCopiaAEmpresa();
            string iCodigoEmpresaGuarda = Universal.gCodigoEmpresa;

            //ejecutar metodo
            CuentaRN.AdicionarCuentasPorCopia(iCodigoEmpresaGuarda, iLisCueMar, iLisCueVal);
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
                Mensaje.OperacionDenegada(iEmpEN.Adicionales.Mensaje, this.wCue.eTitulo);
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
            this.ActualizarListaCuentasParaBD();
            this.ActualizarDgvCue();
        }

        public void MarcarTodos()
        {
            CuentaRN.MarcarTodos(this.eLisCue, true);
            this.ActualizarDgvCue();
        }

        public void DesmarcarTodos()
        {
            CuentaRN.MarcarTodos(this.eLisCue, false);
            this.ActualizarDgvCue();
        }

        #endregion

        private void wCopiarAdicionarCuentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wCue.Enabled = true;           
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();          
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvCue_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.ModificarCuenta();
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
