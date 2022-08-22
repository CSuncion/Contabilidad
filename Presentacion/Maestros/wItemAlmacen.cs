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
    public partial class wItemAlmacen : Heredados.MiForm8
    {
        public wItemAlmacen()
        {
            InitializeComponent();
        }

        #region Atributos

        string eNombreColumnaDgvIteAlm = ItemAlmacenEN.CodIteAlm;
        string eEncabezadoColumnaDgvIteAlm = "Codigo";
        public string eClaveDgvIteAlm = string.Empty;
        Dgv.Franja eFranjaDgvIteAlm = Dgv.Franja.PorIndice;
        public List<ItemAlmacenEN> eLisCue = new List<ItemAlmacenEN>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "ItemAlmacen";

        #endregion
        
        #region General


        public void NuevaVentana()
        {
            this.Show();       
            this.ActualizarVentana();          
        }
        
        public void ActualizarVentana()
        {
            this.ActualizarListaItemAlmacenesDeBaseDatos();
            this.ActualizarDgvIteAlm();
            Dgv.HabilitarDesplazadores(this.DgvIteAlm, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvIteAlm, this.sst1);
            this.AccionBuscar(); 
        }

        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvIteAlm;
            this.tstBuscar.Focus();
        }

        public void ActualizarDgvIteAlm()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvIteAlm;
            List<ItemAlmacenEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvIteAlm;
            string iClaveBusqueda = eClaveDgvIteAlm;
            string iColumnaPintura = eNombreColumnaDgvIteAlm;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvIteAlm();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        
        public List<DataGridViewColumn> ListarColumnasDgvIteAlm()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ItemAlmacenEN.CodIteAlm, "Codigo", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ItemAlmacenEN.DesIteAlm, "Descripcion", 250));            
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ItemAlmacenEN.NUniMed, "Uni.Med", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ItemAlmacenEN.DesAlm, "Almacen", 130));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ItemAlmacenEN.NEstIteAlm, "Estado", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ItemAlmacenEN.ClaObj, "Clave", 90, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaItemAlmacenesDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            ItemAlmacenEN iPerEN = new ItemAlmacenEN();
            iPerEN.Adicionales.CampoOrden = eNombreColumnaDgvIteAlm;
            this.eLisCue = ItemAlmacenRN.ListarItemAlmacen(iPerEN);
        }

        public List<ItemAlmacenEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvIteAlm;
            List<ItemAlmacenEN> iLisPer = eLisCue;

            //ejecutar y retornar
            return ItemAlmacenRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iLisPer);
        }

        public void HabilitarAcciones()
        {
            //asignar parametros
            ToolStrip iTs1 = tsPrincipal;
            ToolStrip iTs2 = tsSecundario;
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaVentana("009", DgvIteAlm.Rows.Count);

            //ejecutar metodo
            Tst.HabilitarItems(iTs1, iTs2, iLisPer);
        }
             
        public void AsignarItemAlmacen(ItemAlmacenEN pObj)
        {
            pObj.ClaveItemAlmacen = Dgv.ObtenerValorCelda(this.DgvIteAlm, ItemAlmacenEN.ClaObj);
            pObj.CodigoItemAlmacen = Dgv.ObtenerValorCelda(this.DgvIteAlm, ItemAlmacenEN.CodIteAlm);
        }
        
        public void AccionAdicionar()
        {
            wEditItemAlmacen win = new wEditItemAlmacen();
            win.wIteAlm = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvIteAlm = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        
        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            ItemAlmacenEN iAuxEN = this.EsActoModificarItemAlmacen();
            if (iAuxEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditItemAlmacen win = new wEditItemAlmacen();
            win.wIteAlm = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvIteAlm = Dgv.Franja.PorValor;
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

        public void AccionEliminar()
        {
            //preguntar si el registro seleccionado existe
            ItemAlmacenEN iAuxEN = this.EsActoEliminarItemAlmacen();
            if (iAuxEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditItemAlmacen win = new wEditItemAlmacen();
            win.wIteAlm = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvIteAlm = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iAuxEN);
        }

        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            ItemAlmacenEN iAuxEN = this.EsItemAlmacenExistente();
            if (iAuxEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditItemAlmacen win = new wEditItemAlmacen();
            win.wIteAlm = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iAuxEN);
        }
            
        public void AccionCopiarDeEmpresaAdicionar()
        {
            //si existe
            wCopiarAdicionarItemsAlmacen win = new wCopiarAdicionarItemsAlmacen();
            win.wIteAlm = this;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void AccionCopiarDeEmpresaEliminar()
        {
            ////validar
            //ItemAlmacenEN iAuxEN = this.EsActoEliminarCopiaDeEmpresa();
            //if (iAuxEN.Adicionales.EsVerdad == false) { return; }

            ////desea realizar la operacion
            //if (Mensaje.DeseasRealizarOperacion("Eliminar copia ") == false) { return; }

            ////eliminar copia
            //ItemAlmacenRN.EliminarItemAlmacenCopia();

            ////mensaje satisfactorio
            //Mensaje.OperacionSatisfactoria("Se elimino la copia", this.eTitulo);

            ////actualizar ventana
            //this.ActualizarVentana();
        }

        public void AccionImportarExcel()
        {
            //instanciar
            wImportarItemAlmacen win = new wImportarItemAlmacen();
            win.wIteAlm = this;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void AccionEliminarImportarExcel()
        {
            //validar
            ItemAlmacenEN iAuxEN = this.EsActoEliminarImportacionItemAlmacen();
            if (iAuxEN.Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion
            if (Mensaje.DeseasRealizarOperacion("Eliminar importacion") == false) { return; }

            //eliminar copia
            //ItemAlmacenRN.EliminarItemAlmacensImportadasExcel();

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
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("Almacen", 10, "Solo puede registras los codigos de la tabla 'Almacenes'"));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("Codigo", 16, "Debe contener un maximo de 20 caracteres"));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("Descripcion", 60,"Debe contener un maximo de 100 caracteres"));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("Uni.Med", 12, "Solo puede registras los codigos de la tabla 'Unidad Medida'"));
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

        public ItemAlmacenEN EsItemAlmacenExistente()
        {
            ItemAlmacenEN iAuxEN = new ItemAlmacenEN();
            this.AsignarItemAlmacen(iAuxEN);
            iAuxEN = ItemAlmacenRN.EsItemAlmacenExistente(iAuxEN);
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, eTitulo);
            }
            return iAuxEN;
        }

        public ItemAlmacenEN EsActoModificarItemAlmacen()
        {
            ItemAlmacenEN iAuxEN = new ItemAlmacenEN();
            this.AsignarItemAlmacen(iAuxEN);
            iAuxEN = ItemAlmacenRN.EsActoModificarItemAlmacen(iAuxEN);
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, eTitulo);
            }
            return iAuxEN;
        }

        public ItemAlmacenEN EsActoEliminarItemAlmacen()
        {
            ItemAlmacenEN iAuxEN = new ItemAlmacenEN();
            this.AsignarItemAlmacen(iAuxEN);
            iAuxEN = ItemAlmacenRN.EsActoEliminarItemAlmacen(iAuxEN);
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, eTitulo);
            }
            return iAuxEN;
        }

        public ItemAlmacenEN EsActoEliminarCopiaDeEmpresa()
        {
            ItemAlmacenEN iAuxEN = new ItemAlmacenEN();
            iAuxEN = ItemAlmacenRN.EsActoEliminarCopiaItemAlmacen();
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, eTitulo);
            }
            return iAuxEN;
        }

        public ItemAlmacenEN EsActoEliminarImportacionItemAlmacen()
        {
            ItemAlmacenEN iAuxEN = new ItemAlmacenEN();
            //iAuxEN = ItemAlmacenRN.EsActoEliminarImportacionExcel();
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
            wMen.CerrarVentanaHijo(this, wMen.IteItemAlmacen, null);        
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvIteAlm = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvIteAlm = this.DgvIteAlm.Columns[pColumna].Name;
            this.eEncabezadoColumnaDgvIteAlm = this.DgvIteAlm.Columns[pColumna].HeaderText;
            this.ActualizarVentana();     
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvIteAlm, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvIteAlm, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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
             
        private void wItemAlmacen_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvIteAlm = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void DgvIteAlm_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvIteAlm, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvIteAlm, this.sst1);
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvIteAlm, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvIteAlm, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvIteAlm, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvIteAlm, Dgv.Desplazar.Ultimo);
        }

        private void DgvIteAlm_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void DgvIteAlm_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
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

        private void IteCopiarEmpresaAdicionar_Click(object sender, EventArgs e)
        {
            this.AccionCopiarDeEmpresaAdicionar();
        }

        private void IteCopiarEmpresaEliminar_Click(object sender, EventArgs e)
        {
            this.AccionCopiarDeEmpresaEliminar();
        }

        private void IteCopiarEmpresaAdicionar_Click_1(object sender, EventArgs e)
        {
            this.AccionCopiarDeEmpresaAdicionar();
        }

        private void IteCopiarEmpresaEliminar_Click_1(object sender, EventArgs e)
        {
            this.AccionCopiarDeEmpresaEliminar();
        }
    }
}
