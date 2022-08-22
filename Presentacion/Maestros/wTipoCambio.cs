using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heredados;
using WinControles;
using WinControles.ControlesWindows;
using Entidades.Adicionales;
using Comun;
using Entidades;
using Negocio;
using Presentacion.Principal;
using System.Collections;

namespace Presentacion.Maestros
{
    public partial class wTipoCambio : Heredados.MiForm8
    {
        public wTipoCambio()
        {
            InitializeComponent();
        }

        //atributos
        string eNombreColumnaDgvTipCam = TipoCambioEN.FecTipCam;
        string eEncabezadoColumnaDgvTipCam = "Fecha";
        public string eClaveDgvTipCam = string.Empty;
        Dgv.Franja eFranjaDgvTipCam = Dgv.Franja.PorIndice;
        public List<TipoCambioEN> eLisTipCam = new List<TipoCambioEN>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "Tipo cambio";
    
        #region General


        public void NuevaVentana()
        {
            this.Show();       
            this.ActualizarVentana();          
        }
        
        public void ActualizarVentana()
        {
            this.ActualizarListaTipoCambiosDeBaseDatos();
            this.ActualizarDgvTipCam();
            Dgv.HabilitarDesplazadores(this.DgvTipCam, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvTipCam, this.sst1);
            this.AccionBuscar();     
        }

        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvTipCam;
            this.tstBuscar.Focus();
        }

        public void ActualizarDgvTipCam()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvTipCam;
            List<TipoCambioEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvTipCam;
            string iClaveBusqueda = eClaveDgvTipCam;
            string iColumnaPintura = eNombreColumnaDgvTipCam;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvTipCam();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        
        public List<DataGridViewColumn> ListarColumnasDgvTipCam()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(TipoCambioEN.FecTipCam, "Fecha", 75));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(TipoCambioEN.ComUsTipCam, "Compra.Us", 80, 3));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(TipoCambioEN.VenUsTipCam, "Venta.Us", 80, 3));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(TipoCambioEN.ComCadTipCam, "Compra.Cad", 80, 3));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(TipoCambioEN.VenCadTipCam, "Venta.Cad", 80, 3));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(TipoCambioEN.ComEurTipCam, "Compra.Eur", 80, 3));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(TipoCambioEN.VenEurTipCam, "Venta.Eur", 80, 3));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(TipoCambioEN.ClaObj, "Clave", 90, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaTipoCambiosDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            TipoCambioEN iTipCamEN = new TipoCambioEN();
            iTipCamEN.Adicionales.CampoOrden = eNombreColumnaDgvTipCam;
            this.eLisTipCam = TipoCambioRN.ListarTipoCambios(iTipCamEN);
        }

        public List<TipoCambioEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvTipCam;
            List<TipoCambioEN> iLisPer = eLisTipCam;

            //ejecutar y retornar
            return TipoCambioRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iLisPer);
        }

        public void HabilitarAcciones()
        {
            //asignar parametros
            ToolStrip iTs1 = tsPrincipal;
            ToolStrip iTs2 = tsSecundario;
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaVentana("006", DgvTipCam.Rows.Count);

            //ejecutar metodo
            Tst.HabilitarItems(iTs1, iTs2, iLisPer);
        }
             
        public void AsignarTipoCambio(TipoCambioEN pObj)
        {
            pObj.FechaTipoCambio = Dgv.ObtenerValorCelda(this.DgvTipCam, TipoCambioEN.ClaObj);            
        }
        
        public void AccionAdicionar()
        {
            wEditTipoCambio win = new wEditTipoCambio();
            win.wTipCam = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvTipCam = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        
        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            TipoCambioEN iPerEN = this.EsActoModificarTipoCambio();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditTipoCambio win = new wEditTipoCambio();
            win.wTipCam = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvTipCam = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iPerEN);            
        }

        public void AccionModificarAlHacerDobleClick(int pColumna, int pFila)
        {
            //no debe pasar cuando la fila o columna sea -1
            if (pColumna == -1 || pFila == -1) { return; }

            //preguntar si este usuario tiene acceso a la accion modificar
            //basta con ver si el boton modificar esta habilitado o no
            if (tsbModificar.Enabled == false)
            {
                Mensaje.OperacionDenegada("Tu usuario no tiene permiso para modificar este registro", "Modificar");
            }
            else
            {
                this.AccionModificar();
            }
        }

        public void AccionEliminar()
        {
            //preguntar si el registro seleccionado existe
            TipoCambioEN iPerEN = this.EsActoEliminarTipoCambio();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditTipoCambio win = new wEditTipoCambio();
            win.wTipCam = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvTipCam = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iPerEN);    
        }
        
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            TipoCambioEN iPerEN = this.EsTipoCambioExistente();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditTipoCambio win = new wEditTipoCambio();
            win.wTipCam = this;
            win.eOperacion = Universal.Opera.Visualizar;            
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iPerEN);               
        }

        public TipoCambioEN EsTipoCambioExistente()
        {
            TipoCambioEN iPerEN = new TipoCambioEN();
            this.AsignarTipoCambio(iPerEN);
            iPerEN = TipoCambioRN.EsTipoCambioExistente(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, eTitulo);
            }
            return iPerEN;
        }

        public TipoCambioEN EsActoModificarTipoCambio()
        {
            TipoCambioEN iPerEN = new TipoCambioEN();
            this.AsignarTipoCambio(iPerEN);
            iPerEN = TipoCambioRN.EsActoModificarTipoCambio(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, eTitulo);
            }
            return iPerEN;
        }

        public TipoCambioEN EsActoEliminarTipoCambio()
        {
            TipoCambioEN iPerEN = new TipoCambioEN();
            this.AsignarTipoCambio(iPerEN);
            iPerEN = TipoCambioRN.EsActoEliminarTipoCambio(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, eTitulo);
            }
            return iPerEN;
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteTiposCambio, wMen.tsbTiposCambio);        
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvTipCam = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvTipCam = this.DgvTipCam.Columns[pColumna].Name;
            this.eEncabezadoColumnaDgvTipCam = this.DgvTipCam.Columns[pColumna].HeaderText;
            this.ActualizarVentana();     
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipCam, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipCam, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Left:
                case Keys.Right:
                    {
                        break;
                    }
                default:
                    {
                        if (this.tstBuscar.Text != string.Empty) { eVaBD = 0; }
                        this.ActualizarVentana();
                        eVaBD = 1;
                        break;
                    }
            }
        }

        #endregion
             
        private void wTipoCambio_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvTipCam = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void DgvTipCam_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvTipCam, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvTipCam, this.sst1);
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipCam, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipCam, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipCam, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipCam, Dgv.Desplazar.Ultimo);
        }

        private void DgvTipCam_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void DgvTipCam_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex);
        }

        private void tsbAdicionar_Click(object sender, EventArgs e)
        {
            this.AccionAdicionar();
        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {
            this.AccionModificar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            this.AccionEliminar();
        }

        private void tsbVisualizar_Click(object sender, EventArgs e)
        {
            this.AccionVisualizar();
        }
        
        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
