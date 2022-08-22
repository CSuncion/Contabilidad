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
using Entidades;
using Negocio;
using Entidades.Adicionales;
using Comun;
using Presentacion.Principal;
using System.Collections;
using Presentacion.Maestros;
using Heredados.VentanasPersonalizadas;
using System.Reflection;
using Presentacion.FuncionesGenericas;
using Presentacion.Impresiones;

namespace Presentacion.Procesos
{
    public partial class wRegistroCompra : Heredados.MiForm8
    {
        public wRegistroCompra()
        {
            InitializeComponent();
        }

        #region Atributos

        string eNombreColumnaDgvMovCab = RegContabCabeEN.CorRegConCab;
        string eEncabezadoColumnaDgvMovCab = "Numero";
        public string eClaveDgvMovCab = string.Empty;
        Dgv.Franja eFranjaDgvMovCab = Dgv.Franja.PorIndice;
        public List<RegContabCabeEN> eLisMovCab = new List<RegContabCabeEN>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "Registro Compra";

        #endregion
        
        #region General
        
        public void NuevaVentana()
        {
            this.Show();
            this.MostrarPersistencia();
        }

        public void ActualizarVentana()
        {
            this.ActualizarListaRegContabCabesDeBaseDatos();
            this.ActualizarDgvMovCab();
            Dgv.HabilitarDesplazadores(this.DgvMovCab, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvMovCab, this.sst1);
            this.AccionBuscar();
        }

        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvMovCab;
            this.tstBuscar.Focus();
        }

        public void ActualizarDgvMovCab()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvMovCab;
            List<RegContabCabeEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvMovCab;
            string iClaveBusqueda = eClaveDgvMovCab;
            string iColumnaPintura = eNombreColumnaDgvMovCab;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvMovCab();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvMovCab()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.ClaRegConCab, "Clave", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.NOri, "Origen", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.NFil, "File", 140));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.CorRegConCab, "Numero", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.FecRegConCab, "Fecha", 65));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.CodAux, "Cod.Aux", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.DesAux, "Proveedor", 230));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.NTipDoc, "Documento", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.SerDoc, "Serie", 50));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.NumDoc, "N.D", 120));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.FecDoc, "Fc.Doc", 65));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(RegContabCabeEN.PreVenRegConCab, "Precio.Vta", 70, 2));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(RegContabCabeEN.ValVenRegConCab, "Valor.Vta", 70, 2));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(RegContabCabeEN.IgvRegConCab, "I.G.V", 70, 2));            
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaRegContabCabesDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            RegContabCabeEN iCuoEN = new RegContabCabeEN();
            iCuoEN.PeriodoRegContabCabe = lblPeriodo.Text;
            iCuoEN.COrigen = "4";//Compras
            iCuoEN.Adicionales.CampoOrden = eNombreColumnaDgvMovCab;
            this.eLisMovCab = RegContabCabeRN.ListarRegContabCabeXPeriodoYOrigen(iCuoEN);
        }

        public List<RegContabCabeEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvMovCab;
            List<RegContabCabeEN> iListaRegContabCabes = eLisMovCab;

            //ejecutar y retornar
            return RegContabCabeRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaRegContabCabes);
        }

        public void HabilitarAcciones()
        {
            //asignar parametros
            ToolStrip iTs1 = tsPrincipal;
            ToolStrip iTs2 = tsSecundario;
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaVentana("013", DgvMovCab.Rows.Count);

            //ejecutar metodo
            Tst.HabilitarItems(iTs1, iTs2, iLisPer);
        }

        public void AsignarRegContabCabe(RegContabCabeEN pIng)
        {
            pIng.ClaveRegContabCabe = Dgv.ObtenerValorCelda(this.DgvMovCab, RegContabCabeEN.ClaObj);
            pIng.PeriodoRegContabCabe = lblPeriodo.Text;
            //pIng.COrigen = "1";//ingreso      
        }

        public void AccionAdicionar()
        {
            //validar
            RegContabCabeEN iIngEN = this.EsActoAdicionarRegContabCabe();
            if (iIngEN.Adicionales.EsVerdad == false) { return; }

            //instanciar
            wEditRegistroCompra win = new wEditRegistroCompra();
            win.wRegConCab = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvMovCab = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }

        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            RegContabCabeEN iIngEN = this.EsActoModificarRegContabCabe();
            if (iIngEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditRegistroCompra win = new wEditRegistroCompra();
            win.wRegConCab = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvMovCab = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iIngEN);            
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
            RegContabCabeEN iRegConCabEN = this.EsActoEliminarRegContabCabe();
            if (iRegConCabEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditRegistroCompra win = new wEditRegistroCompra();
            win.wRegConCab = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvMovCab = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iRegConCabEN);         
        }

        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            RegContabCabeEN iCuoEN = this.EsRegContabCabeExistente();
            if (iCuoEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditRegistroCompra win = new wEditRegistroCompra();
            win.wRegConCab = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iCuoEN);
        }

        public void AccionImportarExcel()
        {
            ////instanciar
            //wImportarMovimientosIngresos win = new wImportarMovimientosIngresos();
            //win.wIng = this;
            //TabCtrl.InsertarVentana(this, win);
            //win.NuevaVentana();
        }

        public void AccionEliminarImportarExcel()
        {
            ////validar
            //RegContabCabeEN iMovCabEN = this.EsActoEliminarImportacionRegContabCabes();
            //if (iMovCabEN.Adicionales.EsVerdad == false) { return; }

            ////desea realizar la operacion
            //if (Mensaje.DeseasRealizarOperacion("Eliminar importacion") == false) { return; }

            ////eliminar copia
            //RegContabCabeRN.EliminarAntesDeImportarIngreso(this.lblPeriodo.Text);

            ////mensaje satisfactorio
            //Mensaje.OperacionSatisfactoria("Se elimino la importacion", this.eTitulo);

            ////actualizar ventana
            //this.ActualizarVentana();
        }

        public void AccionImprimirNota()
        {
            ////preguntar si el registro seleccionado existe
            //RegContabCabeEN iSalEN = this.EsRegContabCabeExistente();
            //if (iSalEN.Adicionales.EsVerdad == false) { return; }

            ////si existe
            //wImpNotaIngreso win = new wImpNotaIngreso();
            //win.wIng = this;
            //win.eVentana = wImpNotaIngreso.Ventana.wIngresos;
            //win.NuevaVentana(iSalEN);
        }

        public void AccionSeleccionarPeriodo()
        {
            vSeleccionarPeriodo win = new vSeleccionarPeriodo();
            win.eVentanaInvoca = this;
            win.eControlDevuelveValor =  lblPeriodo;
            win.ePeriodoActual = lblPeriodo.Text;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentanaContable();
        }
          
        public RegContabCabeEN EsRegContabCabeExistente()
        {
            RegContabCabeEN iCuoEN = new RegContabCabeEN();
            this.AsignarRegContabCabe(iCuoEN);
            iCuoEN = RegContabCabeRN.EsRegContabCabeExistente(iCuoEN);
            if (iCuoEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCuoEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iCuoEN;
        }

        public RegContabCabeEN EsActoAdicionarRegContabCabe()
        {
            RegContabCabeEN iIngEN = new RegContabCabeEN();
            this.AsignarRegContabCabe(iIngEN);
            iIngEN = RegContabCabeRN.EsActoAdicionarRegContabCabe(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iIngEN;
        }

        public RegContabCabeEN EsActoModificarRegContabCabe()
        {
            RegContabCabeEN iIngEN = new RegContabCabeEN();
            this.AsignarRegContabCabe(iIngEN);
            iIngEN = RegContabCabeRN.EsActoModificarRegContabCabe(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iIngEN;
        }

        public RegContabCabeEN EsActoEliminarRegContabCabe()
        {
            RegContabCabeEN iIngEN = new RegContabCabeEN();
            this.AsignarRegContabCabe(iIngEN);
            iIngEN = RegContabCabeRN.EsActoEliminarRegContabCabe(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iIngEN;
        }

        public RegContabCabeEN EsActoEliminarImportacionRegContabCabes()
        {
            RegContabCabeEN iIngEN = new RegContabCabeEN();
            //this.AsignarRegContabCabe(iIngEN);
            //iIngEN = RegContabCabeRN.EsActoEliminarImportacionRegContabCabeIngreso(iIngEN);
            //if (iIngEN.Adicionales.EsVerdad == false)
            //{
            //    Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            //}
            return iIngEN;
        }

        public void AccionCambiaPeriodo()
        {
            //poner la descripcion del mes
            lblDescripcionPeriodo.Text = AñoMes.ObtenerDescripcionPeriodo(lblPeriodo.Text);
           
            //guardar el nuevo periodo
            Properties.Settings.Default.GuardarPeriodoIngresos = TsL.ModificarValor(Properties.Settings.Default.GuardarPeriodoIngresos, Universal.gCodigoEmpresa, lblPeriodo);
            Properties.Settings.Default.Save();

            //actualizar ventana
            this.ActualizarVentana();
        }

        public void MostrarPersistencia()
        {
            TsL.MostrarValor(lblPeriodo, Properties.Settings.Default.GuardarPeriodoIngresos, Universal.gCodigoEmpresa);
        }
      
        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteRcCompras, wMen.tsbCompras);
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvMovCab = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvMovCab = this.DgvMovCab.Columns[pColumna].Name;
            this.eEncabezadoColumnaDgvMovCab = this.DgvMovCab.Columns[pColumna].HeaderText;
            this.ActualizarVentana();
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {
                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMovCab, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMovCab, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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

        
        private void wRegistroCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvMovCab = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void DgvMovCab_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvMovCab, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvMovCab, this.sst1);
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMovCab, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMovCab, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMovCab, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMovCab, Dgv.Desplazar.Ultimo);
        }

        private void DgvMovCab_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void DgvMovCab_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex);
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }

        private void btnPeriodo_Click(object sender, EventArgs e)
        {
            this.AccionSeleccionarPeriodo();
        }

        private void lblPeriodo_TextChanged(object sender, EventArgs e)
        {
            this.AccionCambiaPeriodo();
        }

        private void tsbImprimirNota_Click(object sender, EventArgs e)
        {
            this.AccionImprimirNota();
        }

        private void IteImportarAdicionar_Click(object sender, EventArgs e)
        {
            this.AccionImportarExcel();
        }

        private void IteImportarEliminar_Click(object sender, EventArgs e)
        {
            this.AccionEliminarImportarExcel();
        }
    }
}
