using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinControles;
using WinControles.ControlesWindows;
using Comun;
using Entidades;
using Entidades.Adicionales;
using Negocio;
using Presentacion.Listas;
using Presentacion.Principal;
using Presentacion.Maestros;
using Presentacion.FuncionesGenericas;
using Microsoft.Office.Interop.Excel;
using WinControles.Entidades;
 


namespace Presentacion.Maestros
{
    public partial class wImportarItemAlmacen : Heredados.MiForm8
    {
        public wImportarItemAlmacen()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        string eTitulo = "Item Almacen";
        List<ItemAlmacenEN> eLisIteAlm = new List<ItemAlmacenEN>();
        List<ErrorCeldaExcel> eLisErr = new List<ErrorCeldaExcel>();

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
            xCtrl.Btn(this.btnBusArcExc, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbHoj, "Hoja", "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnValidar, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbError, "Error", "vfff");
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
            this.ActualizarVentana();
            eMas.AccionPasarTextoPrincipal();
            this.btnBusArcExc.Focus();
        }

        public void ActualizarVentana()
        {
            this.ActualizarDgvIteAlm();
            this.MostrarTituloDgvIteAlm();
            this.CargarErrores();
            this.ActualizarDgvErr();
            this.HabilitarControles();
        }

        public void ActualizarDgvIteAlm()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvIteAlm;
            List<ItemAlmacenEN> iFuenteDatos = this.eLisIteAlm;
            Dgv.Franja iCondicionFranja =  Dgv.Franja.PorIndice;
            string iClaveBusqueda = string.Empty  ;            
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvIteAlm();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvIteAlm()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ItemAlmacenEN.CodAlm, "Almacen", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ItemAlmacenEN.CodIteAlm, "Codigo", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ItemAlmacenEN.DesIteAlm, "Descripcion", 200));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ItemAlmacenEN.CUniMed, "Uni.Med", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ItemAlmacenEN.CEstIteAlm, "Estado", 70));            
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ItemAlmacenEN.ClaObj, "Clave", 90, false));

            //devolver
            return iLisRes;
        }

        public void MostrarTituloDgvIteAlm()
        {
            //asignar parametros
            string iTexto1 = "Registros a importar";            
            string iTexto2 = "# : " + this.dgvIteAlm.Rows.Count;
            string iSeparador = "/";

            //ejecutar metodo
            string iTextoFormato = Formato.UnionDosTextos(iTexto1, iTexto2, iSeparador);

            //mostrar
            this.lblRegImp.Text = iTextoFormato;
        }

        public void ActualizarDgvErr()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvErr;
            List<ErrorCeldaExcel> iFuenteDatos = MiExcel.FiltrarPorTipoError(this.eLisErr, Cmb.ObtenerValor(this.cmbError,""));
            Dgv.Franja iCondicionFranja = Dgv.Franja.PorIndice;
            string iClaveBusqueda = string.Empty;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvErr();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvErr()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena("Celda", "Celda", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena("MensajeErrorCelda", "Error", 390));

            //devolver
            return iLisRes;
        }

        public void HabilitarControles()
        {
            this.btnExportar.Enabled = Cadena.CompararDosValores(this.dgvErr.Rows.Count, 0, false, true);
            this.btnAceptar.Enabled = Cadena.CompararDosValores(this.dgvIteAlm.Rows.Count, 0, false, true);
            this.cmbError.Enabled = Cadena.CompararDosValores(this.dgvErr.Rows.Count, 0, false, true);
        }

        public void BuscarExcel()
        {
            //asignar parametros
            OpenFileDialog win = new OpenFileDialog();
            System.Windows.Forms.TextBox iControlRuta = txtArcExc;
            ComboBox iControlHojas = cmbHoj;
            
            //ejecutar metodo
            MiControl.MostrarRutaYHojasExcel(win, iControlRuta, iControlHojas);
        }

        public void Validar()
        {
            //campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //actualizar la lista de errores
            this.ActualizarListaErroresExcel();

            //actualizar la lista de registros a importar
            this.ActualizarListaItemAlmacensAImportar();

            //actualizar ventana
            this.ActualizarVentana();
        }

        public void Aceptar()
        {
            //desea realizar la operacion
            if (Mensaje.DeseasRealizarOperacion("Importar") == false) { return; }

            //importar
            ItemAlmacenRN.AdicionarItemAlmacenPorImportacionExcel(this.eLisIteAlm);

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se importaron los registros correctamente", this.eTitulo);

            //actualizar al propietario
            this.wIteAlm.ActualizarVentana();

            //cerrar esta ventana
            this.Close();
        }

        public void ActualizarListaItemAlmacensAImportar()
        {
            this.eLisIteAlm = this.TransformarExcelAListaItemAlmacen();
        }

        public List<ItemAlmacenEN> TransformarExcelAListaItemAlmacen()
        {
            //obtener la hoja de la lectura de agua
            Worksheet iHoja = this.ObtenerHojaExcel();

            //lista de las lecturas de agua transformadas
            List<ItemAlmacenEN> iLisRes = new List<ItemAlmacenEN>();

            //recorrer cada fila del excel
            for (int i = 2; i < 10000; i++)
            {
                //si no hay dato en la fila , entonces se termina el bucle
                object iNulo = iHoja.Range["A" + i].Value;
                if (iNulo == null) { break; }
                
                //si el indice fila existe en la lista de errores, entonces este registro no se carga
                if(MiExcel.ExisteIndiceFila(this.eLisErr, i.ToString()) == true) { continue; }

                //creamos un nuevo objeto ItemAlmacen
                ItemAlmacenEN iIteAlmEN = new ItemAlmacenEN();

                //actualizamos datos
                iIteAlmEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iIteAlmEN.CodigoAlmacen = iHoja.Range["A" + i].Text;
                iIteAlmEN.CodigoItemAlmacen = iHoja.Range["B" + i].Text;
                iIteAlmEN.DescripcionItemAlmacen = iHoja.Range["C" + i].Text;
                iIteAlmEN.CUnidadMedida = iHoja.Range["D" + i].Text;
                iIteAlmEN.CEstadoItemAlmacen = iHoja.Range["E" + i].Text;
                iIteAlmEN.COrigenVentanaCreacion = "03";//Ventana Importacion excel
                iIteAlmEN.ClaveItemAlmacen = ItemAlmacenRN.ObtenerClaveItemAlmacen(iIteAlmEN);

                //insertar a la lista resultado
                iLisRes.Add(iIteAlmEN);
            }

            //destruor ala hoja
            MiExcel.EliminarHojaExcel(iHoja);

            //devolver
            return iLisRes;
        }

        public Worksheet ObtenerHojaExcel()
        {
            //asignar parametros
            string iRutaArchivoExcel = txtArcExc.Text.Trim();          
            string iHojaExcel = MiExcel.ObtenerNombreHoja(this.cmbHoj.Text);
           
            //ejecutar metodo
            return MiExcel.ObtenerHojaExcel(iRutaArchivoExcel, iHojaExcel);          
        }

        public int ObtenerNumeroRegistrosExcel(Worksheet pHoja)
        {
            //asignar parametros
            string iColumnaClave = "A";
            int iIndiceFilaInicia = 2;
            Worksheet iHoja = pHoja;

            //ejecutar metodo
            return MiExcel.ObtenerNumeroCeldasConDatos(iColumnaClave, iIndiceFilaInicia, iHoja);        
        }

        public void CargarErrores()
        {
            Cmb.Cargar(this.cmbError, MiExcel.ListarTiposErroresDistintos(this.eLisErr), "Codigo", "Descripcion");
        }

        public void ExportarExcel()
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

                //-----------------
                //llenando cabecera
                //-----------------

                iHoja.Cells.Item[1, 1] = "Error :  " + this.cmbError.Text.Trim();
                
                //---------------------------------------
                //obtener la cabecera del detalle reporte
                //---------------------------------------

                //armar las columnas
                List<ColumnaExcel> iListaColumnas = new List<ColumnaExcel>();              
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Celda", 12));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Error", 70));                

                //objeto que armara todas las columnas en el excel
                EncabezadosExcel iEncExc = new EncabezadosExcel();
                iEncExc.Hoja = iHoja;
                iEncExc.Niveles = 1;
                iEncExc.IndiceColumnaPartida = 1;
                iEncExc.IndiceFilaPartida = 2;
                iEncExc.Color = Color.GreenYellow;
                iEncExc.NumeroRegistros = this.dgvErr.Rows.Count;
                iEncExc.ListaColumnas = iListaColumnas;
                MiExcel.ArmarEstructuraEncabezados(iEncExc);

                //----------------------
                //llenando datos detalle
                //----------------------

                //indice para cada fila
                int iIndiceFila = 2;

                //recorrer cada objeto
                foreach (DataGridViewRow xInsFal in this.dgvErr.Rows)
                {
                    iIndiceFila++;
                    iHoja.Cells.Item[iIndiceFila, 1] = xInsFal.Cells[0].Value;
                    iHoja.Cells.Item[iIndiceFila, 2] = xInsFal.Cells[1].Value;

                }

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

        public void ActualizarListaErroresExcel()
        {
            this.eLisErr = this.ListarErroresCeldasExcel();
        }

        public List<ErrorCeldaExcel> ListarErroresCeldasExcel()
        {
            //lista resultado
            List<ErrorCeldaExcel> iLisRes = new List<ErrorCeldaExcel>();

            //traer la hoja que se quiere importar
            Worksheet iHoja = this.ObtenerHojaExcel();

            //obtener el numero de registros del excel
            int iNumeroRegistros = this.ObtenerNumeroRegistrosExcel(iHoja);

            //lista codigos itemAlmacen en bd
            List<string> iListaItemAlmacen = ItemAlmacenRN.ListarCodigosItemAlmacen();

            //lista codigos almacenes
            List<string> iListaAlmacenes = ItemERN.ListarCodigosItems("Alm");

            //lista codigos unidad de medidas
            List<string> iListaUniMedida = ItemGRN.ListarCodigosItems("UniMed");

            //lista de codigos de Si No
            List<string> ilistaSiNo = ItemGRN.ListarCodigosItems("SiNo");

            ErrorCeldaExcel iErr;

            //recorrer cada fila del excel
            for (int i = 2; i < 100000; i++)
            {
                //si no hay dato en la fila , entonces se termina el bucle
                object iNulo = iHoja.Range["A" + i].Value;
                if (iNulo == null) { break; }

                //validar que la clave no exista en base de datos            
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorClaveExistenteBD("Almacen + Codigo", "A" + i, "B" + i, iListaItemAlmacen, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar codigo inexistente 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistente("Almacen", "A" + i, iListaAlmacenes, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar la longitud del campo
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorLongitudCampo("Codigo", "B" + i, 20, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar la longitud del campo
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorLongitudCampo("Descripcion", "C" + i, 100, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar codigo inexistente 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistente("Uni.Med", "D" + i, iListaUniMedida, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar codigo inexistente 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistente("Estado", "E" + i, ilistaSiNo, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }
            }
                
            //listar errores al validar las claves repetidas en el excel
            iLisRes.AddRange(this.ListarErroresPorClavesRepetidasEnExcel(iHoja, iNumeroRegistros));
           
            //eliminar la hoja excel
            MiExcel.EliminarHojaExcel(iHoja);

            //devolver
            return iLisRes;
        }
             
        public List<ErrorCeldaExcel> ListarErroresPorClavesRepetidasEnExcel(Worksheet pHoja, int pNumeroRegistros)
        {
            //asignar parametros
            string iColumnaClave1 = "A";
            string iColumnaClave2 = "B";
            int iIndiceFilaInicia = 2;
            int iNumeroRegistros = pNumeroRegistros;
            string iNombreCampo = "Almacen + Codigo";
            
            //ejectuar metodo
            return MiExcel.ListarErroresExcelPorClavesRepetidasExcel(iColumnaClave1,iColumnaClave2, iIndiceFilaInicia, iNumeroRegistros,
                pHoja, iNombreCampo);
        }
     
        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, eTitulo);
        }


        #endregion


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void wImportarItemAlmacen_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wIteAlm.Enabled = true;
        }

        private void btnBusArcExc_Click(object sender, EventArgs e)
        {
            this.BuscarExcel();         
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            this.Validar();
        }

        private void cmbError_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.ActualizarDgvErr();
            this.HabilitarControles();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            this.ExportarExcel();
        }
    }
}
