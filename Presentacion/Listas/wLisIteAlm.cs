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
using Entidades;
using Negocio;

namespace Presentacion.Listas
{
    public partial class wLisIteAlm : Heredados.MiForm8
    {
        public wLisIteAlm()
        {
            InitializeComponent();
        }

        #region Enumeraciones

        public enum Condicion
        {
            ItemsAlmacenes = 0,
            ItemsAlmacenesActivas,
            ItemsAlmacenesActivasDeAlmacen,
            //CuentasAnaliticasActivasExceptoUna,
            //CuentasAnaliticasParaRegistroCompraActivas,
        }


        #endregion

        public Form eVentana = new Form();
        public ItemAlmacenEN eObjEN = new ItemAlmacenEN();
        public List<ItemAlmacenEN> eLisObj = new List<ItemAlmacenEN>();
        public string eTituloVentana;
        public Condicion eCondicionLista;
        public string eCampoBusqueda;
        public TextBox eCtrlValor;
        public Control eCtrlFoco;
        public string eCodigoCuentaExcepcion;

        #region Metodos


        public void InicializaVentana()
        {
            this.eVentana.Enabled = false;
            eObjEN.Adicionales.CampoOrden = ItemAlmacenEN.CodIteAlm;
            this.Text = "Listado de" + Cadena.Espacios(1) + this.eTituloVentana;
            this.eCampoBusqueda = "Codigo";
            this.ActualizaVentana();
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();        
            this.Show();
            this.txtBus.Focus();
        }
        
        public void ActualizaVentana()
        {
            this.ActualizarListaItemsAlmacenDeBaseDatos();
            this.gbBus.Text = "Criterio de busqueda / Por :" + this.eCampoBusqueda;
            this.ActualizarDgvLista();
            Dgv.PintarColumna(this.DgvLista, eObjEN.Adicionales.CampoOrden);
        }

        public void ActualizarDgvLista()
        {          
            //llenar la grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvLista;
            iDgv.RefrescarDatosGrilla(this.ObtenerDatosParaGrilla());

            //asignando columnas
            iDgv.AsignarColumnaTextCadena(ItemAlmacenEN.CodIteAlm, "Codigo", 80);
            iDgv.AsignarColumnaTextCadena(ItemAlmacenEN.DesIteAlm, "Descripcion", 260);
            iDgv.AsignarColumnaTextCadena(ItemAlmacenEN.DesAlm, "Almacen", 100);
        }

        public void ActualizarListaItemsAlmacenDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (txtBus.Text.Trim() != string.Empty) { return; }

            //ejecutar segun condicion
            switch (eCondicionLista)
            {
                case Condicion.ItemsAlmacenes: { this.eLisObj = ItemAlmacenRN.ListarItemAlmacen(eObjEN); break; }
                case Condicion.ItemsAlmacenesActivas: { this.eLisObj = ItemAlmacenRN.ListarItemAlmacenActivos(eObjEN); break; }
                case Condicion.ItemsAlmacenesActivasDeAlmacen: { this.eLisObj = ItemAlmacenRN.ListarItemAlmacenActivosDeAlmacen(eObjEN); break; }
            }
        }

        public List<ItemAlmacenEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = txtBus.Text.Trim();
            string iCampoBusqueda = eObjEN.Adicionales.CampoOrden;
            List<ItemAlmacenEN> iListaItemsAlmacen = eLisObj;

            //ejecutar y retornar
            return ItemAlmacenRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaItemsAlmacen);
        }

        public void DevolverDato()
        {
            if (this.DgvLista.Rows.Count == 0)
            {
                return;
            }
            else
            {
                this.eCtrlValor.Text = Dgv.ObtenerValorCelda(this.DgvLista, ItemAlmacenEN.CodIteAlm);
                this.Close();
                this.eCtrlValor.Focus();
                this.eCtrlFoco.Focus();
            }
        }

        public void OrdenarPorColumna(int pColumna)
        {
            eObjEN.Adicionales.CampoOrden = this.DgvLista.Columns[pColumna].Name;
            this.eCampoBusqueda = this.DgvLista.Columns[pColumna].HeaderText;
            this.ActualizaVentana();
            Txt.CursorAlUltimo(this.txtBus);  
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvLista, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.txtBus); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvLista, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
                        Txt.CursorAlUltimo(this.txtBus); break;
                    }
                case Keys.Left:
                case Keys.Right:
                    {
                        break;
                    }
                default:
                    {
                        this.ActualizaVentana();
                        break;
                    }
            }
        }

        #endregion


        private void wLisIteAlm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.eVentana.Enabled = true;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            this.DevolverDato();
        }

        private void txtBus_KeyPress(object sender, KeyPressEventArgs e)
        {         
            //si se selecciono la barra espaciadora
            if (Encoding.ASCII.GetBytes(e.KeyChar.ToString())[0] == 13){this.DevolverDato();}
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DevolverDato();
        }

        private void txtBus_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);       
        }

        private void DgvLista_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

       
    }
}
