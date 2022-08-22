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
using Microsoft.Office.Interop.Excel;
using WinControles.Entidades;

namespace Presentacion.Maestros
{
    public partial class wFormatoContable : Heredados.MiForm8
    {
        public wFormatoContable()
        {
            InitializeComponent();
        }

        #region Atributos

        string eNombreColumnaDgvForCon = FormatoContableEN.CodForCon;
        string eEncabezadoColumnaDgvForCon = "Codigo";
        public string eClaveDgvForCon = string.Empty;
        Dgv.Franja eFranjaDgvForCon = Dgv.Franja.PorIndice;
        public List<FormatoContableEN> eLisForCon = new List<FormatoContableEN>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "Formato Contable";

        #endregion
        
        #region General


        public void NuevaVentana()
        {
            this.Show();       
            this.ActualizarVentana();          
        }
        
        public void ActualizarVentana()
        {
            this.ActualizarListaFormatoContableesDeBaseDatos();
            this.ActualizarDgvForCon();
            Dgv.HabilitarDesplazadores(this.DgvForCon, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvForCon, this.sst1);
            this.AccionBuscar();       
        }

        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvForCon;
            this.tstBuscar.Focus();
        }

        public void ActualizarDgvForCon()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvForCon;
            List<FormatoContableEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvForCon;
            string iClaveBusqueda = eClaveDgvForCon;
            string iColumnaPintura = eNombreColumnaDgvForCon;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvForCon();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        
        public List<DataGridViewColumn> ListarColumnasDgvForCon()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(FormatoContableEN.CodForCon, "Codigo", 60));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(FormatoContableEN.DesForCon, "Descripcion", 260));            
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(FormatoContableEN.NGru, "Grupo", 140));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(FormatoContableEN.NNat, "Naturaleza", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(FormatoContableEN.NEstForCon, "Estado", 80));            
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(FormatoContableEN.ClaObj, "Clave", 90, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaFormatoContableesDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            FormatoContableEN iPerEN = new FormatoContableEN();
            iPerEN.Adicionales.CampoOrden = eNombreColumnaDgvForCon;
            this.eLisForCon = FormatoContableRN.ListarFormatoContable(iPerEN);
        }

        public List<FormatoContableEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvForCon;
            List<FormatoContableEN> iLisPer = eLisForCon;

            //ejecutar y retornar
            return FormatoContableRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iLisPer);
        }

        public void HabilitarAcciones()
        {
            //asignar parametros
            ToolStrip iTs1 = tsPrincipal;
            ToolStrip iTs2 = tsSecundario;
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaVentana("009", DgvForCon.Rows.Count);

            //ejecutar metodo
            Tst.HabilitarItems(iTs1, iTs2, iLisPer);
        }
             
        public void AsignarFormatoContable(FormatoContableEN pObj)
        {
            pObj.ClaveFormatoContable = Dgv.ObtenerValorCelda(this.DgvForCon, FormatoContableEN.ClaObj);
            pObj.CodigoFormatoContable = Dgv.ObtenerValorCelda(this.DgvForCon, FormatoContableEN.CodForCon);
        }
        
        public void AccionAdicionar()
        {
            wEditFormatoContable win = new wEditFormatoContable();
            win.wForCon = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvForCon = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        
        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            FormatoContableEN iAuxEN = this.EsActoModificarFormatoContable();
            if (iAuxEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditFormatoContable win = new wEditFormatoContable();
            win.wForCon = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvForCon = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iAuxEN);
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

        public void AccionCopiar()
        {
            ////preguntar si el registro seleccionado existe
            //FormatoContableEN iAuxEN = this.EsFormatoContableExistente();
            //if (iAuxEN.Adicionales.EsVerdad == false) { return; }

            ////si existe
            //wEditFormatoContable win = new wEditFormatoContable();
            //win.wAux = this;
            //win.eOperacion = Universal.Opera.Copiar;
            //this.eFranjaDgvForCon = Dgv.Franja.PorValor;
            //TabCtrl.InsertarVentana(this, win);
            //win.VentanaCopiar(iAuxEN);
        }

        public void AccionEliminar()
        {
            //preguntar si el registro seleccionado existe
            FormatoContableEN iAuxEN = this.EsActoEliminarFormatoContable();
            if (iAuxEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditFormatoContable win = new wEditFormatoContable();
            win.wForCon = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvForCon = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iAuxEN);
        }

        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            FormatoContableEN iAuxEN = this.EsFormatoContableExistente();
            if (iAuxEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditFormatoContable win = new wEditFormatoContable();
            win.wForCon = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iAuxEN);
        }

        public void AccionCopiarAdicionar()
        {
            //si existe
            wCopiarAdicionarFormatoContable win = new wCopiarAdicionarFormatoContable();
            win.wForCon = this;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void AccionCopiarEliminar()
        {
            //validar
            FormatoContableEN iForConEN = this.EsActoEliminarCopiaFormatoContable();
            if (iForConEN.Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion
            if (Mensaje.DeseasRealizarOperacion("Eliminar copia") == false) { return; }

            //eliminar copia
            FormatoContableRN.EliminarFormatoContablesCopia();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se elimino la copia", this.eTitulo);

            //actualizar ventana
            this.ActualizarVentana();
        }

        public void AccionImportarExcel()
        {
            //instanciar
            wImportarFormatoContable win = new wImportarFormatoContable();
            win.wForCon = this;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void AccionEliminarImportarExcel()
        {
            //validar
            FormatoContableEN iForConEN = this.EsActoEliminarImportacionFormatoContable();
            if (iForConEN.Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion
            if (Mensaje.DeseasRealizarOperacion("Eliminar importacion") == false) { return; }

            //eliminar copia
            FormatoContableRN.EliminarFormatoContablesImportacion();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se elimino la importacion", this.eTitulo);

            //actualizar ventana
            this.ActualizarVentana();
        }

        public void AccionPlantillaImportacionExcel()
        {
            //declarar objetos de excel         
            Microsoft.Office.Interop.Excel.Application iAplicacion;
            Workbook iLibro;
            Worksheet iHoja;

            //creamos una nueva aplicacion excel
            iAplicacion = new Microsoft.Office.Interop.Excel.Application();

            //adicionamos el libro a la aplicacion
            iLibro = iAplicacion.Workbooks.Add();

            //obtener la hoja 1 del libro
            iHoja = iLibro.Worksheets["Hoja1"];

            //dando el zoom predeterminado a la hoja
            iAplicacion.ActiveWindow.Zoom = 73;

            try
            {
                               
                //---------------------------------------
                //obtener la cabecera del detalle reporte
                //---------------------------------------

                //armar las columnas
                List<ColumnaExcel> iListaColumnas = new List<ColumnaExcel>();
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("Codigo", 8, "Debe contener un maximo de 8 caracteres"));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("Descripcion", 30,"Debe contener un maximo de 150 caracteres"));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("Descripcion Alterna", 30, "Debe contener un maximo de 150 caracteres"));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("Agrupado en", 20, "Solo puede registras estos codigos:01 = 'ACTIVO CORRIENTE';02 = 'ACTIVO NO CORRIENTE';03 = 'PASIVO CORRIENTE';04 = 'PASIVO NO CORRIENTE';05 = 'PATRIMONIO';06 = 'VENTAS';07 = 'GASTOS VENTAS';08 = 'OTROS GASTOS';09 = 'OTROS INGRESOS';10 = 'OTROS EGRESOS'"));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("Naturaleza", 20, "Solo puede registras estos codigos:0 = 'DEUDORA';1 = 'ACREEDORA'"));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("Estado", 10, "Solo puede registras estos codigos:0 = 'Desactivado';1 = 'Activado'"));

                //objeto que armara todas las columnas en el excel
                EncabezadosExcel iEncExc = new EncabezadosExcel();
                iEncExc.Hoja = iHoja;
                iEncExc.Niveles = 1;
                iEncExc.IndiceColumnaPartida = 1;
                iEncExc.IndiceFilaPartida = 1;
                iEncExc.Color = Color.GreenYellow;
                iEncExc.NumeroRegistros = 20000;
                iEncExc.ListaColumnas = iListaColumnas;
                MiExcel.ArmarEstructuraEncabezados(iEncExc);

                //ver el excel
                iAplicacion.Application.Visible = true;

            }
            catch (Exception ex)
            {
                Mensaje.OperacionDenegada(ex.Message, "Error");
            }
            finally
            {
                //liberamos recursos
                MiExcel.LiberarObjetoCom(iAplicacion);
                MiExcel.LiberarObjetoCom(iLibro);
                MiExcel.LiberarObjetoCom(iHoja);
            }
        }

        public FormatoContableEN EsFormatoContableExistente()
        {
            FormatoContableEN iAuxEN = new FormatoContableEN();
            this.AsignarFormatoContable(iAuxEN);
            iAuxEN = FormatoContableRN.EsFormatoContableExistente(iAuxEN);
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, eTitulo);
            }
            return iAuxEN;
        }

        public FormatoContableEN EsActoModificarFormatoContable()
        {
            FormatoContableEN iAuxEN = new FormatoContableEN();
            this.AsignarFormatoContable(iAuxEN);
            iAuxEN = FormatoContableRN.EsActoModificarFormatoContable(iAuxEN);
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, eTitulo);
            }
            return iAuxEN;
        }

        public FormatoContableEN EsActoEliminarFormatoContable()
        {
            FormatoContableEN iAuxEN = new FormatoContableEN();
            this.AsignarFormatoContable(iAuxEN);
            iAuxEN = FormatoContableRN.EsActoEliminarFormatoContable(iAuxEN);
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, eTitulo);
            }
            return iAuxEN;
        }

        public FormatoContableEN EsActoEliminarCopiaFormatoContable()
        {
            FormatoContableEN iAuxEN = new FormatoContableEN();            
            iAuxEN = FormatoContableRN.EsActoEliminarCopiaFormatoContable();
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, eTitulo);
            }
            return iAuxEN;
        }

        public FormatoContableEN EsActoEliminarImportacionFormatoContable()
        {
            FormatoContableEN iAuxEN = new FormatoContableEN();
            iAuxEN = FormatoContableRN.EsActoEliminarImportacionFormatoContable();
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, eTitulo);
            }
            return iAuxEN;
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteFormatoContable, null);        
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvForCon = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvForCon = this.DgvForCon.Columns[pColumna].Name;
            this.eEncabezadoColumnaDgvForCon = this.DgvForCon.Columns[pColumna].HeaderText;
            this.ActualizarVentana();     
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvForCon, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvForCon, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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
             
        private void wFormatoContable_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvForCon = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void DgvForCon_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvForCon, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvForCon, this.sst1);
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvForCon, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvForCon, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvForCon, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvForCon, Dgv.Desplazar.Ultimo);
        }

        private void DgvForCon_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void DgvForCon_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
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

        private void IteCopiarAdicionar_Click(object sender, EventArgs e)
        {
            this.AccionCopiarAdicionar();
        }

        private void IteCopiarEliminar_Click(object sender, EventArgs e)
        {
            this.AccionCopiarEliminar();
        }

        private void IteImportarAdicionar_Click(object sender, EventArgs e)
        {
            this.AccionImportarExcel();
        }

        private void IteImportarEliminar_Click(object sender, EventArgs e)
        {
            this.AccionEliminarImportarExcel();
        }

        private void ItePlantillaImportacion_Click(object sender, EventArgs e)
        {
            this.AccionPlantillaImportacionExcel();
        }
    }
}
