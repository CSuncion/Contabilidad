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
    public partial class wCuenta : Heredados.MiForm8
    {
        public wCuenta()
        {
            InitializeComponent();
        }

        #region Atributos

        string eNombreColumnaDgvCue = CuentaEN.CodCue;
        string eEncabezadoColumnaDgvCue = "Codigo";
        public string eClaveDgvCue = string.Empty;
        Dgv.Franja eFranjaDgvCue = Dgv.Franja.PorIndice;
        public List<CuentaEN> eLisCue = new List<CuentaEN>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "Cuenta";

        #endregion
        
        #region General


        public void NuevaVentana()
        {
            this.Show();       
            this.ActualizarVentana();          
        }
        
        public void ActualizarVentana()
        {
            this.ActualizarListaCuentaesDeBaseDatos();
            this.ActualizarDgvCue();
            Dgv.HabilitarDesplazadores(this.DgvCue, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvCue, this.sst1);
            this.AccionBuscar(); 
        }

        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvCue;
            this.tstBuscar.Focus();
        }

        public void ActualizarDgvCue()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvCue;
            List<CuentaEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvCue;
            string iClaveBusqueda = eClaveDgvCue;
            string iColumnaPintura = eNombreColumnaDgvCue;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCue();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        
        public List<DataGridViewColumn> ListarColumnasDgvCue()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.CodCue, "Codigo", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.DesCue, "Descripcion", 240));            
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.NDoc, "Documento", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.NAux, "Auxiliar", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.NCenCos, "Cen.Cos", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.NAlm, "Almacen", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.NBan, "Banco", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.NMon, "Moneda", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.NAut, "Automatica", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.CodCueAut1, "Automatica1", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.CodCueAut2, "Automatica2", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.NumDigAna, "#.Dig", 50));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.NReg, "Registro", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.CodForCon, "Formato.Cont", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.ClaObj, "Clave", 90, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaCuentaesDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            CuentaEN iPerEN = new CuentaEN();
            iPerEN.Adicionales.CampoOrden = eNombreColumnaDgvCue;
            this.eLisCue = CuentaRN.ListarCuenta(iPerEN);
        }

        public List<CuentaEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvCue;
            List<CuentaEN> iLisPer = eLisCue;

            //ejecutar y retornar
            return CuentaRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iLisPer);
        }

        public void HabilitarAcciones()
        {
            //asignar parametros
            ToolStrip iTs1 = tsPrincipal;
            ToolStrip iTs2 = tsSecundario;
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaVentana("009", DgvCue.Rows.Count);

            //ejecutar metodo
            Tst.HabilitarItems(iTs1, iTs2, iLisPer);
        }
             
        public void AsignarCuenta(CuentaEN pObj)
        {
            pObj.ClaveCuenta = Dgv.ObtenerValorCelda(this.DgvCue, CuentaEN.ClaObj);
            pObj.CodigoCuenta = Dgv.ObtenerValorCelda(this.DgvCue, CuentaEN.CodCue);
        }
        
        public void AccionAdicionar()
        {
            wEditCuenta win = new wEditCuenta();
            win.wCue = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvCue = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        
        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            CuentaEN iAuxEN = this.EsActoModificarCuenta();
            if (iAuxEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditCuenta win = new wEditCuenta();
            win.wCue = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvCue = Dgv.Franja.PorValor;
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
            CuentaEN iAuxEN = this.EsActoEliminarCuenta();
            if (iAuxEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditCuenta win = new wEditCuenta();
            win.wCue = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvCue = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iAuxEN);
        }

        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            CuentaEN iAuxEN = this.EsCuentaExistente();
            if (iAuxEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditCuenta win = new wEditCuenta();
            win.wCue = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iAuxEN);
        }

        public void AccionCopiarPcgeAdicionar()
        {
            //validar
            CuentaEN iAuxEN = this.EsActoAdicionarCopiaPcge();
            if (iAuxEN.Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion
            if (Mensaje.DeseasRealizarOperacion("Adicionar copia Pcge") == false) { return; }

            //adicionar copia
            CuentaRN.CopiarPcge();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se adiciono la copia desde el Pcge", this.eTitulo);

            //actualizar ventana
            this.ActualizarVentana();
        }

        public void AccionCopiarPcgeEliminar()
        {
            //validar
            CuentaEN iAuxEN = this.EsActoEliminarCopiaPcge();
            if (iAuxEN.Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion
            if (Mensaje.DeseasRealizarOperacion("Eliminar copia Pcge") == false) { return; }

            //eliminar copia
            CuentaRN.EliminarCuentasCopiaDePcge();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se elimino la copia Pcge", this.eTitulo);

            //actualizar ventana
            this.ActualizarVentana();
        }

        public void AccionCopiarDeEmpresaAdicionar()
        {
            //si existe
            wCopiarAdicionarCuentas win = new wCopiarAdicionarCuentas();
            win.wCue = this;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void AccionCopiarDeEmpresaEliminar()
        {
            //validar
            CuentaEN iAuxEN = this.EsActoEliminarCopiaDeEmpresa();
            if (iAuxEN.Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion
            if (Mensaje.DeseasRealizarOperacion("Eliminar copia ") == false) { return; }

            //eliminar copia
            CuentaRN.EliminarCuentasCopiaDeEmpresa();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se elimino la copia", this.eTitulo);

            //actualizar ventana
            this.ActualizarVentana();
        }

        public void AccionImportarExcel()
        {
            //instanciar
            wImportarCuenta win = new wImportarCuenta();
            win.wCue = this;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void AccionEliminarImportarExcel()
        {
            //validar
            CuentaEN iAuxEN = this.EsActoEliminarImportacionCuenta();
            if (iAuxEN.Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion
            if (Mensaje.DeseasRealizarOperacion("Eliminar importacion") == false) { return; }

            //eliminar copia
            CuentaRN.EliminarCuentasImportadasExcel();

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

            //obtener el numero de digitos para las cuentas analiticas
            string iNumeroDigitosAnalitica = EmpresaRN.BuscarEmpresaDeAcceso().NumeroDigitosAnalitica;

            try
            {
                               
                //---------------------------------------
                //obtener la cabecera del detalle reporte
                //---------------------------------------

                //armar las columnas
                List<ColumnaExcel> iListaColumnas = new List<ColumnaExcel>();
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("Codigo", 16, "Debe contener un maximo de " + iNumeroDigitosAnalitica + " caracteres"));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("Descripcion", 60,"Debe contener un maximo de 150 caracteres"));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("CDocumento", 15, "Solo puede registras estos codigos:0 = 'No';1 = 'Si'"));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("CAuxiliar", 15, "Solo puede registras estos codigos:0 = 'No';1 = 'Si'"));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("CCentroCosto", 15, "Solo puede registras estos codigos:0 = 'No';1 = 'Si'"));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("CAlmacen", 15, "Solo puede registras estos codigos:0 = 'No';1 = 'Si'"));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("CArea", 15, "Solo puede registras estos codigos:0 = 'No';1 = 'Si'"));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("CFlujoCaja", 15, "Solo puede registras estos codigos:0 = 'No';1 = 'Si'"));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("CAutomatica", 15, "Solo puede registras estos codigos:0 = 'No';1 = 'Si'"));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("CDiferenciaCambio", 18, "Solo puede registras estos codigos:0 = 'No';1 = 'Si'"));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("CBanco", 15, "Solo puede registras estos codigos:0 = 'No';1 = 'Si'"));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("CMoneda", 15, "Solo puede registras estos codigos:0 = 'Soles';1 = 'Dolares'"));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("CAsientoApertura", 18, "Solo puede registras estos codigos:0 = 'No';1 = 'Si'"));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("CAsientoCierre7", 18, "Solo puede registras estos codigos:0 = 'No';1 = 'Si'"));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("CAsientoCierre9", 18, "Solo puede registras estos codigos:0 = 'No';1 = 'Si'"));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("CuentaAutomatica1", 19, "Debe contener " + iNumeroDigitosAnalitica + " caracteres"));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("CuentaAutomatica2", 19, "Debe contener " + iNumeroDigitosAnalitica + " caracteres"));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena1("FormatoContable", 18, "Solo puede registras los codigos de la tabla 'Formato Contable'"));
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

        public CuentaEN EsCuentaExistente()
        {
            CuentaEN iAuxEN = new CuentaEN();
            this.AsignarCuenta(iAuxEN);
            iAuxEN = CuentaRN.EsCuentaExistente(iAuxEN);
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, eTitulo);
            }
            return iAuxEN;
        }

        public CuentaEN EsActoModificarCuenta()
        {
            CuentaEN iAuxEN = new CuentaEN();
            this.AsignarCuenta(iAuxEN);
            iAuxEN = CuentaRN.EsActoModificarCuenta(iAuxEN);
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, eTitulo);
            }
            return iAuxEN;
        }

        public CuentaEN EsActoEliminarCuenta()
        {
            CuentaEN iAuxEN = new CuentaEN();
            this.AsignarCuenta(iAuxEN);
            iAuxEN = CuentaRN.EsActoEliminarCuenta(iAuxEN);
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, eTitulo);
            }
            return iAuxEN;
        }

        public CuentaEN EsActoAdicionarCopiaPcge()
        {
            CuentaEN iAuxEN = new CuentaEN();
            iAuxEN = CuentaRN.EsActoAdicionarCopiaPcge();
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, eTitulo);
            }
            return iAuxEN;
        }
        
        public CuentaEN EsActoEliminarCopiaPcge()
        {
            CuentaEN iAuxEN = new CuentaEN();            
            iAuxEN = CuentaRN.EsActoEliminarCopiaPcge();
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, eTitulo);
            }
            return iAuxEN;
        }

        public CuentaEN EsActoEliminarCopiaDeEmpresa()
        {
            CuentaEN iAuxEN = new CuentaEN();
            iAuxEN = CuentaRN.EsActoEliminarCopiaDeEmpresa();
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, eTitulo);
            }
            return iAuxEN;
        }

        public CuentaEN EsActoEliminarImportacionCuenta()
        {
            CuentaEN iAuxEN = new CuentaEN();
            iAuxEN = CuentaRN.EsActoEliminarImportacionExcel();
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
            wMen.CerrarVentanaHijo(this, wMen.IteCuentas, null);        
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvCue = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvCue = this.DgvCue.Columns[pColumna].Name;
            this.eEncabezadoColumnaDgvCue = this.DgvCue.Columns[pColumna].HeaderText;
            this.ActualizarVentana();     
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCue, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCue, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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
             
        private void wCuenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvCue = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void DgvCue_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvCue, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvCue, this.sst1);
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCue, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCue, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCue, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCue, Dgv.Desplazar.Ultimo);
        }

        private void DgvCue_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void DgvCue_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
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

        private void IteCopiarPcgeAdicionar_Click(object sender, EventArgs e)
        {
            this.AccionCopiarPcgeAdicionar();
        }

        private void IteCopiarPcgeEliminar_Click(object sender, EventArgs e)
        {
            this.AccionCopiarPcgeEliminar();
        }

        private void IteCopiarEmpresaAdicionar_Click(object sender, EventArgs e)
        {
            this.AccionCopiarDeEmpresaAdicionar();
        }

        private void IteCopiarEmpresaEliminar_Click(object sender, EventArgs e)
        {
            this.AccionCopiarDeEmpresaEliminar();
        }
    }
}
