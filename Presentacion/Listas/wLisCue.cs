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
    public partial class wLisCue : Heredados.MiForm8
    {
        public wLisCue()
        {
            InitializeComponent();
        }

        #region Enumeraciones

        public enum Condicion
        {
            CuentasAnaliticas = 0,
            CuentasAnaliticasActivas,
            CuentasAnaliticasActivasExceptoUna,
            CuentasAnaliticasParaRegistroCompraPVActivas,
            CuentasAnaliticasParaRegistroCompraPVMonedaActivas,
            CuentasAnaliticasParaRegistroCompraVVActivas,
            CuentasAnaliticasParaRegistroCompraEspecialActivas,
            CuentasAnaliticasParaRegistroCompraDetalle,
        }


        #endregion

        #region Atributos

        public Form eVentana = new Form();
        public CuentaEN eObjEN = new CuentaEN();
        public List<CuentaEN> eLisObj = new List<CuentaEN>();
        public string eTituloVentana;
        public Condicion eCondicionLista;
        public string eCampoBusqueda;
        public TextBox eCtrlValor;
        public Control eCtrlFoco;
        public string eCodigoCuentaExcepcion;
        public string eTipoCompra;
        public string eMonedaCompra;

        #endregion

        #region Metodos


        public void InicializaVentana()
        {
            this.eVentana.Enabled = false;
            eObjEN.Adicionales.CampoOrden = CuentaEN.CodCue;
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
            this.ActualizarListaCuentasDeBaseDatos();
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
            iDgv.AsignarColumnaTextCadena(CuentaEN.CodCue, "Codigo", 80);
            iDgv.AsignarColumnaTextCadena(CuentaEN.DesCue, "Descripcion", 260);
        }

        public void ActualizarListaCuentasDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (txtBus.Text.Trim() != string.Empty) { return; }

            //ejecutar segun condicion
            switch (eCondicionLista)
            {
                case Condicion.CuentasAnaliticas: { this.eLisObj = CuentaRN.ListarCuentaAnalitica(eObjEN); break; }
                case Condicion.CuentasAnaliticasActivas: { this.eLisObj = CuentaRN.ListarCuentaAnaliticaActivas(eObjEN); break; }
                case Condicion.CuentasAnaliticasActivasExceptoUna: { this.eLisObj = CuentaRN.ListarCuentaAnaliticaActivas(eObjEN, eCodigoCuentaExcepcion); break; }
                case Condicion.CuentasAnaliticasParaRegistroCompraPVActivas: { this.eLisObj = CuentaRN.ListarCuentasParaRegistroCompraPV(eObjEN); break; }
                case Condicion.CuentasAnaliticasParaRegistroCompraPVMonedaActivas: { this.eLisObj = CuentaRN.ListarCuentasParaRegistroCompraPVMoneda(eObjEN); break; }
                case Condicion.CuentasAnaliticasParaRegistroCompraVVActivas: { this.eLisObj = CuentaRN.ListarCuentasParaRegistroCompraVV(eObjEN); break; }
                case Condicion.CuentasAnaliticasParaRegistroCompraEspecialActivas: { this.eLisObj = CuentaRN.ListarCuentasParaRegistroCompraEspecial(eObjEN); break; }
                case Condicion.CuentasAnaliticasParaRegistroCompraDetalle: { this.eLisObj = CuentaRN.ListarCuentasParaRegistroCompraDetalle(eObjEN, this.eTipoCompra); break; }
            }
        }

        public List<CuentaEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = txtBus.Text.Trim();
            string iCampoBusqueda = eObjEN.Adicionales.CampoOrden;
            List<CuentaEN> iListaCuentas = eLisObj;

            //ejecutar y retornar
            return CuentaRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaCuentas);
        }

        public void DevolverDato()
        {
            if (this.DgvLista.Rows.Count == 0)
            {
                return;
            }
            else
            {
                this.eCtrlValor.Text = Dgv.ObtenerValorCelda(this.DgvLista, CuentaEN.CodCue);
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


        private void wLisCue_FormClosing(object sender, FormClosingEventArgs e)
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
            if (Encoding.ASCII.GetBytes(e.KeyChar.ToString())[0] == 13) { this.DevolverDato(); }
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
