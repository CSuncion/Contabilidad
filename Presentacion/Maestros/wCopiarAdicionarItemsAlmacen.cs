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
    public partial class wCopiarAdicionarItemsAlmacen : Heredados.MiForm8
    {
        public wCopiarAdicionarItemsAlmacen()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        List<ItemAlmacenEN> eLisIteAlm = new List<ItemAlmacenEN>();

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
            this.wIteAlm.Enabled = false;
                     
            //Mostrar ventana
            this.Show();            
        }                

        public void NuevaVentana()
        {
            this.InicializaVentana();            
            this.ActualizarListaItemAlmacensParaBD();
            this.ActualizarDgvIteAlm();
            this.txtCodEmp1.Focus();
        }

        public void ActualizarDgvIteAlm()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvIteAlm;
            List<ItemAlmacenEN> iFuenteDatos = eLisIteAlm;
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
            iLisRes.Add(Dgv.NuevaColumnaCheckBox(ItemAlmacenEN.VerFal, "Seleccionar", 85));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ItemAlmacenEN.CodIteAlm, "Codigo", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ItemAlmacenEN.DesIteAlm, "Descripcion", 200));            
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ItemAlmacenEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaItemAlmacensParaBD()
        {
            eLisIteAlm = this.ListarItemAlmacensParaCopiaAEmpresa();
        }

        public List<ItemAlmacenEN> ListarItemAlmacensParaCopiaAEmpresa()
        {
            //Asignar parametros
            string iCodigoEmpresaCopia = this.txtCodEmp1.Text.Trim();
            string iCodigoEmpresaGuarda = Universal.gCodigoEmpresa;

            //ejecutar metodo
            return ItemAlmacenRN.ListarItemAlmacenParaCopiarAEmpresa(iCodigoEmpresaCopia, iCodigoEmpresaGuarda);
        }

        public void ModificarItemAlmacen()
        {
            //asignar parametros
            ItemAlmacenEN iCuoEN = new ItemAlmacenEN();
            iCuoEN.ClaveItemAlmacen = Dgv.ObtenerValorCelda(this.DgvIteAlm, ItemAlmacenEN.ClaObj);
            iCuoEN.VerdadFalso = Dgv.ObtenerValorCeldaCheckBox(this.DgvIteAlm, VentanaBotonEN.VerFal);

            //ejecutar metodo
            ItemAlmacenRN.ModificarVerdadFalsoItemAlmacen(iCuoEN, this.eLisIteAlm);
        }
        
        public void Aceptar()
        {
            //validar campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //validar si hay ItemAlmacens marcadas
            if (this.HayMarcados() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion("Agregar Items Almacen") == false) { return; }

            //agregar las ItemAlmacens marcadas
            this.AgregarItemAlmacens();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se agregaron los Items Almacen correctamente", "Items Almacen");

            //actualizar ventana propietario
            this.wIteAlm.ActualizarVentana();

            //cerrar
            this.Close();
        }
               
        public bool HayMarcados()
        {
            ItemAlmacenEN iCuoMarEN = ItemAlmacenRN.HayObjetosMarcados(eLisIteAlm);
            if (iCuoMarEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCuoMarEN.Adicionales.Mensaje, this.wIteAlm.eTitulo);               
            }
            return iCuoMarEN.Adicionales.EsVerdad;  
        }

        public void AgregarItemAlmacens()
        { 
            //asignar parametros
            List<ItemAlmacenEN> iLisForConMar = ItemAlmacenRN.ListarItemAlmacenSoloMarcadas(this.eLisIteAlm);
            List<ItemAlmacenEN> iLisForConVal = this.ListarItemAlmacensParaCopiaAEmpresa();
            string iCodigoEmpresaGuarda = Universal.gCodigoEmpresa;

            //ejecutar metodo
            ItemAlmacenRN.AdicionarItemAlmacenPorCopia(iCodigoEmpresaGuarda, iLisForConMar, iLisForConVal);
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
                Mensaje.OperacionDenegada(iEmpEN.Adicionales.Mensaje, this.wIteAlm.eTitulo);
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
            this.ActualizarListaItemAlmacensParaBD();
            this.ActualizarDgvIteAlm();
        }

        public void MarcarTodos()
        {
            ItemAlmacenRN.MarcarTodos(this.eLisIteAlm, true);
            this.ActualizarDgvIteAlm();
        }

        public void DesmarcarTodos()
        {
            ItemAlmacenRN.MarcarTodos(this.eLisIteAlm, false);
            this.ActualizarDgvIteAlm();
        }

        #endregion

        private void wCopiarAdicionarItemsAlmacen_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wIteAlm.Enabled = true;           
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();          
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvIteAlm_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.ModificarItemAlmacen();
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
