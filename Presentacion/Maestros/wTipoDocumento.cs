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
    public partial class wTipoDocumento : Heredados.MiForm8
    {
        public wTipoDocumento()
        {
            InitializeComponent();
        }

        #region Atributos

        string eNombreColumnaDgvTipDoc = TipoDocumentoEN.CodTipDoc;
        string eEncabezadoColumnaDgvTipDoc = "Codigo";
        public string eClaveDgvTipDoc = string.Empty;
        Dgv.Franja eFranjaDgvTipDoc = Dgv.Franja.PorIndice;
        public List<TipoDocumentoEN> eLisTipDoc = new List<TipoDocumentoEN>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "Tipo Documento";

        #endregion
        
        #region General


        public void NuevaVentana()
        {
            this.Show();       
            this.ActualizarVentana();          
        }
        
        public void ActualizarVentana()
        {
            this.ActualizarListaTipoDocumentosDeBaseDatos();
            this.ActualizarDgvTipCam();
            Dgv.HabilitarDesplazadores(this.DgvTipDoc, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvTipDoc, this.sst1);
            this.AccionBuscar();     
        }

        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvTipDoc;
            this.tstBuscar.Focus();
        }

        public void ActualizarDgvTipCam()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvTipDoc;
            List<TipoDocumentoEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvTipDoc;
            string iClaveBusqueda = eClaveDgvTipDoc;
            string iColumnaPintura = eNombreColumnaDgvTipDoc;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvTipCam();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        
        public List<DataGridViewColumn> ListarColumnasDgvTipCam()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(TipoDocumentoEN.CodTipDoc, "Codigo", 60));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(TipoDocumentoEN.DesTipDoc, "Descripcion", 210));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(TipoDocumentoEN.NAplEnReg, "Apl.Registro", 110));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(TipoDocumentoEN.NAplDocRef, "Apl.Doc.Ref", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(TipoDocumentoEN.NEstTipDoc, "Estado", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(TipoDocumentoEN.ClaObj, "Clave", 90, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaTipoDocumentosDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            TipoDocumentoEN iTipCamEN = new TipoDocumentoEN();
            iTipCamEN.Adicionales.CampoOrden = eNombreColumnaDgvTipDoc;
            this.eLisTipDoc = TipoDocumentoRN.ListarTipoDocumento(iTipCamEN);
        }

        public List<TipoDocumentoEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvTipDoc;
            List<TipoDocumentoEN> iLisPer = eLisTipDoc;

            //ejecutar y retornar
            return TipoDocumentoRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iLisPer);
        }

        public void HabilitarAcciones()
        {
            //asignar parametros
            ToolStrip iTs1 = tsPrincipal;
            ToolStrip iTs2 = tsSecundario;
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaVentana("006", DgvTipDoc.Rows.Count);

            //ejecutar metodo
            Tst.HabilitarItems(iTs1, iTs2, iLisPer);
        }
             
        public void AsignarTipoDocumento(TipoDocumentoEN pObj)
        {
            pObj.CodigoTipoDocumento = Dgv.ObtenerValorCelda(this.DgvTipDoc, TipoDocumentoEN.CodTipDoc);
            pObj.ClaveObjeto = Dgv.ObtenerValorCelda(this.DgvTipDoc, TipoDocumentoEN.ClaObj);            
        }
        
        public void AccionAdicionar()
        {
            wEditTipoDocumento win = new wEditTipoDocumento();
            win.wTipDoc = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvTipDoc = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        
        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            TipoDocumentoEN iPerEN = this.EsActoModificarTipoDocumento();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditTipoDocumento win = new wEditTipoDocumento();
            win.wTipDoc = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvTipDoc = Dgv.Franja.PorValor;
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
            TipoDocumentoEN iPerEN = this.EsActoEliminarTipoDocumento();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditTipoDocumento win = new wEditTipoDocumento();
            win.wTipDoc = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvTipDoc = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iPerEN);    
        }
        
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            TipoDocumentoEN iPerEN = this.EsTipoDocumentoExistente();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditTipoDocumento win = new wEditTipoDocumento();
            win.wTipDoc = this;
            win.eOperacion = Universal.Opera.Visualizar;            
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iPerEN);               
        }

        public TipoDocumentoEN EsTipoDocumentoExistente()
        {
            TipoDocumentoEN iPerEN = new TipoDocumentoEN();
            this.AsignarTipoDocumento(iPerEN);
            iPerEN = TipoDocumentoRN.EsTipoDocumentoExistente(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, eTitulo);
            }
            return iPerEN;
        }

        public TipoDocumentoEN EsActoModificarTipoDocumento()
        {
            TipoDocumentoEN iPerEN = new TipoDocumentoEN();
            this.AsignarTipoDocumento(iPerEN);
            iPerEN = TipoDocumentoRN.EsActoModificarTipoDocumento(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, eTitulo);
            }
            return iPerEN;
        }

        public TipoDocumentoEN EsActoEliminarTipoDocumento()
        {
            TipoDocumentoEN iPerEN = new TipoDocumentoEN();
            this.AsignarTipoDocumento(iPerEN);
            iPerEN = TipoDocumentoRN.EsActoEliminarTipoDocumento(iPerEN);
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
            wMen.CerrarVentanaHijo(this, wMen.IteTiposDocumentos, null);        
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvTipDoc = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvTipDoc = this.DgvTipDoc.Columns[pColumna].Name;
            this.eEncabezadoColumnaDgvTipDoc = this.DgvTipDoc.Columns[pColumna].HeaderText;
            this.ActualizarVentana();     
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipDoc, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipDoc, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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
             
        private void wTipoDocumento_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvTipDoc = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void DgvTipDoc_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvTipDoc, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvTipDoc, this.sst1);
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipDoc, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipDoc, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipDoc, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipDoc, Dgv.Desplazar.Ultimo);
        }

        private void DgvTipDoc_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void DgvTipDoc_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
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
