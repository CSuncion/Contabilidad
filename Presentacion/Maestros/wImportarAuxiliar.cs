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
    public partial class wImportarAuxiliar : Heredados.MiForm8
    {
        public wImportarAuxiliar()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        string eTitulo = "Auxiliar";
        List<AuxiliarEN> eLisAux = new List<AuxiliarEN>();
        List<ErrorCeldaExcel> eLisErr = new List<ErrorCeldaExcel>();

        #endregion

        #region Propietario

        public wAuxiliar wAux;

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
            this.wAux.Enabled = false;

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
            this.ActualizarDgvAux();
            this.MostrarTituloDgvAux();
            this.CargarErrores();
            this.ActualizarDgvErr();
            this.HabilitarControles();
        }

        public void ActualizarDgvAux()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvAux;
            List<AuxiliarEN> iFuenteDatos = this.eLisAux;
            Dgv.Franja iCondicionFranja =  Dgv.Franja.PorIndice;
            string iClaveBusqueda = string.Empty  ;            
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvAux();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvAux()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AuxiliarEN.CTipDocAux, "Doc.Ide", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AuxiliarEN.CodAux, "Numero", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AuxiliarEN.CTipAux, "Tipo", 120));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AuxiliarEN.CClaAux, "Clase", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AuxiliarEN.DesAux, "Nombre", 250));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AuxiliarEN.DirAux, "Direccion", 250));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AuxiliarEN.CelAux, "Celular", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AuxiliarEN.TelAux, "Telefono", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AuxiliarEN.NEstAux, "Estado", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(PerfilEN.ClaObj, "Clave", 90, false));

            //devolver
            return iLisRes;
        }

        public void MostrarTituloDgvAux()
        {
            //asignar parametros
            string iTexto1 = "Registros a importar";            
            string iTexto2 = "# : " + this.dgvAux.Rows.Count;
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
            this.btnAceptar.Enabled = Cadena.CompararDosValores(this.dgvAux.Rows.Count, 0, false, true);
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
            this.ActualizarListaAuxiliaresAImportar();

            //actualizar ventana
            this.ActualizarVentana();
        }

        public void Aceptar()
        {
            //desea realizar la operacion
            if (Mensaje.DeseasRealizarOperacion("Importar") == false) { return; }

            //importar
            AuxiliarRN.AdicionarAuxiliarsPorImportacionExcel(this.eLisAux);

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se importaron los registros correctamente", this.eTitulo);

            //actualizar al propietario
            this.wAux.ActualizarVentana();

            //cerrar esta ventana
            this.Close();
        }

        public void ActualizarListaAuxiliaresAImportar()
        {
            //asignar parametro
            List<AuxiliarEN> iLisAux= this.TransformarExcelAListaAuxiliar();

            //ejecutar metodo
            AuxiliarRN.ActualizarAuxiliaresImportacionExcelParaGrabar(iLisAux);

            //pasar a la lista externa
            this.eLisAux = iLisAux;
        }

        public List<AuxiliarEN> TransformarExcelAListaAuxiliar()
        {
            //obtener la hoja de la lectura de agua
            Worksheet iHoja = this.ObtenerHojaExcel();

            //lista de las lecturas de agua transformadas
            List<AuxiliarEN> iLisRes = new List<AuxiliarEN>();

            //recorrer cada fila del excel
            for (int i = 2; i < 10000; i++)
            {
                //si no hay dato en la fila , entonces se termina el bucle
                object iNulo = iHoja.Range["B" + i].Value;
                if (iNulo == null) { break; }
                
                //si el indice fila existe en la lista de errores, entonces este registro no se carga
                if(MiExcel.ExisteIndiceFila(this.eLisErr, i.ToString()) == true) { continue; }

                //creamos un nuevo objeto Auxiliar
                AuxiliarEN iAuxEN = new AuxiliarEN();

                //actualizamos datos
                iAuxEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iAuxEN.CTipoDocumentoAuxiliar = iHoja.Range["A" + i].Text;
                iAuxEN.CodigoAuxiliar = iHoja.Range["B" + i].Text;
                iAuxEN.CTipoAuxiliar = iHoja.Range["C" + i].Text;
                iAuxEN.CClaseAuxiliar = iHoja.Range["D" + i].Text;
                iAuxEN.ApellidoPaternoAuxiliar = iHoja.Range["E" + i].Text;
                iAuxEN.ApellidoMaternoAuxiliar = iHoja.Range["F" + i].Text;
                iAuxEN.PrimerNombreAuxiliar = iHoja.Range["G" + i].Text;
                iAuxEN.SegundoNombreAuxiliar = iHoja.Range["H" + i].Text;
                iAuxEN.DescripcionAuxiliar = iHoja.Range["I" + i].Text;               
                iAuxEN.DireccionAuxiliar = iHoja.Range["J" + i].Text;
                iAuxEN.TelefonoAuxiliar = iHoja.Range["K" + i].Text;
                iAuxEN.CelularAuxiliar = iHoja.Range["L" + i].Text;
                iAuxEN.CorreoAuxiliar = iHoja.Range["M" + i].Text;
                iAuxEN.ReferenciaAuxiliar = iHoja.Range["N" + i].Text;
                iAuxEN.CPaisNoDomiciliadoAuxiliar = iHoja.Range["O" + i].Text;
                iAuxEN.CEstadoAuxiliar = iHoja.Range["P" + i].Text;
                iAuxEN.COrigenVentanaCreacion = "03";//Ventana Importacion excel
                iAuxEN.ClaveAuxiliar = AuxiliarRN.ObtenerClaveAuxiliar(iAuxEN);

                //insertar a la lista resultado
                iLisRes.Add(iAuxEN);
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
            string iColumnaClave = "B";
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

            //lista de codigos tipos de documentos
            List<string> iListaTiposDocumentos = ItemGRN.ListarCodigosItems("Tdi");

            //lista de codigos de auxiliares de la empresa
            List<string> iListaAuxiliares = AuxiliarRN.ListarCodigosAuxiliares();

            //lista de codigos tipos de auxiliar
            List<string> iListaTiposAuxiliar = ItemGRN.ListarCodigosItems("TipAux");

            //lista de codigos clases de auxiliar
            List<string> iListaClasesAuxiliar = ItemGRN.ListarCodigosItems("ClaAux");

            //lista de codigos de paises
            List<string> iListaPaises = ItemGRN.ListarCodigosItems("Pais");

            //lista de codigos de Si No
            List<string> ilistaSiNo = ItemGRN.ListarCodigosItems("SiNo");

            ErrorCeldaExcel iErr;

            //recorrer cada fila del excel
            for (int i = 2; i < 100000; i++)
            {
                //si no hay dato en la fila , entonces se termina el bucle
                object iNulo = iHoja.Range["B" + i].Value;
                if (iNulo == null) { break; }

                //validar codigo inexistente 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistente("Documento.Ide", "A" + i, iListaTiposDocumentos, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar que la clave no exista en base de datos            
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorClaveExistenteBD("Numero.Doc", "B" + i, iListaAuxiliares, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar la longitud del campo
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorLongitudCampo("Numero.Doc", "B" + i, 11, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar que la clave no exista en base de datos            
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistente("Tipo", "C" + i, iListaTiposAuxiliar, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar que la clave no exista en base de datos            
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistente("Clase", "D" + i, iListaClasesAuxiliar, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar la longitud del campo
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorLongitudCampo("Ape.Paterno", "E" + i, 50, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar dato vacio
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorDatoVacioCondicionDato("Ape.Paterno", "E" + i, iHoja,
                    "D" + i, "0");
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar la longitud del campo
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorLongitudCampo("Ape.Materno", "F" + i, 50, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar la longitud del campo
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorLongitudCampo("Pri.nombre", "G" + i, 50, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar dato vacio
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorDatoVacioCondicionDato("Pri.nombre", "G" + i, iHoja,
                    "D" + i, "0");
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar la longitud del campo
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorLongitudCampo("Seg.nombre", "H" + i, 50, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar la longitud del campo
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorLongitudCampo("Razon Social", "I" + i, 200, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar dato vacio
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorDatoVacioCondicionDato("Razon Social", "I" + i, iHoja,
                    "D" + i, "1");
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar la longitud del campo
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorLongitudCampo("Direccion", "J" + i, 150, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar la longitud del campo
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorLongitudCampo("Telefono", "K" + i, 20, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar la longitud del campo
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorLongitudCampo("Celular", "L" + i, 10, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar la longitud del campo
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorLongitudCampo("Correo", "M" + i, 40, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar la longitud del campo
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorLongitudCampo("Referencia", "N" + i, 150, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar codigo inexistente 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistenteCondicionDato("Pais", "O" + i, iListaPaises, iHoja,
                    "D" + i, "1");
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }
                
                //validar codigo inexistente 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistente("Estado", "P" + i, ilistaSiNo, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }
            }

            //listar errores al validar las claves repetidas en el excel(Codigo)
            iLisRes.AddRange(this.ListarErroresPorClavesRepetidasEnExcel(iHoja, iNumeroRegistros));

            //eliminar la hoja excel
            MiExcel.EliminarHojaExcel(iHoja);

            //devolver
            return iLisRes;
        }
        
        public List<ErrorCeldaExcel> ListarErroresPorClavesRepetidasEnExcel(Worksheet pHoja, int pNumeroRegistros)
        {
            //asignar parametros
            string iColumnaClave = "B";
            int iIndiceFilaInicia = 2;
            int iNumeroRegistros = pNumeroRegistros;
            string iNombreCampo = "Numero";
            
            //ejectuar metodo
            return MiExcel.ListarErroresExcelPorClavesRepetidasExcel(iColumnaClave, iIndiceFilaInicia, iNumeroRegistros, pHoja, iNombreCampo);
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

        private void wImportarAuxiliar_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wAux.Enabled = true;
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
