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
    public partial class wImportarCuenta : Heredados.MiForm8
    {
        public wImportarCuenta()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        string eTitulo = "Cuenta";
        List<CuentaEN> eLisCue = new List<CuentaEN>();
        List<ErrorCeldaExcel> eLisErr = new List<ErrorCeldaExcel>();

        #endregion

        #region Propietario

        public wCuenta wCue;

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
            this.wCue.Enabled = false;

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
            this.ActualizarDgvCue();
            this.MostrarTituloDgvCue();
            this.CargarErrores();           
            this.ActualizarDgvErr();
            this.HabilitarControles();
        }

        public void ActualizarDgvCue()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvCue;
            List<CuentaEN> iFuenteDatos = this.eLisCue;
            Dgv.Franja iCondicionFranja =  Dgv.Franja.PorIndice;
            string iClaveBusqueda = string.Empty  ;            
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCue();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvCue()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.CodCue, "Codigo", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.DesCue, "Descripcion", 200));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.CDoc, "Documento", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.CAux, "Auxiliar", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.CCenCos, "Cen.Cos", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.CAlm, "Almacen", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.CAre, "Area", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.CFluCaj, "Flujo.Caja", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.CAut, "Automatica", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.CDifCam, "Dif.Cambio", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.CBan, "Banco", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.CMon, "Moneda", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.CAsiApe, "Asi.Apertura", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.CAsiCie7, "Asi.Cierre7", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.CAsiCie9, "Asi.Cierre9", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.CodCueAut1, "Automatica1", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.CodCueAut2, "Automatica2", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.CodForCon, "Formato.Contable", 120));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.CEstCue, "Estado", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaEN.ClaObj, "Clave", 90, false));

            //devolver
            return iLisRes;
        }

        public void MostrarTituloDgvCue()
        {
            //asignar parametros
            string iTexto1 = "Registros a importar";            
            string iTexto2 = "# : " + this.dgvCue.Rows.Count;
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
            this.btnAceptar.Enabled = Cadena.CompararDosValores(this.dgvCue.Rows.Count, 0, false, true);
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
            this.ActualizarListaCuentasAImportar();

            //actualizar ventana
            this.ActualizarVentana();
        }

        public void Aceptar()
        {
            //desea realizar la operacion
            if (Mensaje.DeseasRealizarOperacion("Importar") == false) { return; }

            //importar
            CuentaRN.AdicionarCuentasPorImportacionExcel(this.eLisCue);

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se importaron los registros correctamente", this.eTitulo);

            //actualizar al propietario
            this.wCue.ActualizarVentana();

            //cerrar esta ventana
            this.Close();
        }

        public void ActualizarListaCuentasAImportar()
        {
            //asignar parametros
            List<CuentaEN> iLisCue= this.TransformarExcelAListaCuenta();

            //ejecutar metodo
            CuentaRN.ActualizarCuentasDeImportacionExcelParaGrabar(iLisCue);

            //pasar a la lista externa
            this.eLisCue = iLisCue;
        }

        public List<CuentaEN> TransformarExcelAListaCuenta()
        {
            //obtener la hoja de la lectura de agua
            Worksheet iHoja = this.ObtenerHojaExcel();

            //lista de las lecturas de agua transformadas
            List<CuentaEN> iLisRes = new List<CuentaEN>();

            //recorrer cada fila del excel
            for (int i = 2; i < 10000; i++)
            {
                //si no hay dato en la fila , entonces se termina el bucle
                object iNulo = iHoja.Range["A" + i].Value;
                if (iNulo == null) { break; }
                
                //si el indice fila existe en la lista de errores, entonces este registro no se carga
                if(MiExcel.ExisteIndiceFila(this.eLisErr, i.ToString()) == true) { continue; }

                //creamos un nuevo objeto Cuenta
                CuentaEN iCueEN = new CuentaEN();

                //actualizamos datos
                iCueEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iCueEN.CodigoCuenta = iHoja.Range["A" + i].Text;
                iCueEN.DescripcionCuenta = iHoja.Range["B" + i].Text;
                iCueEN.CDocumento = iHoja.Range["C" + i].Text;
                iCueEN.CAuxiliar = iHoja.Range["D" + i].Text;
                iCueEN.CCentroCosto = iHoja.Range["E" + i].Text;
                iCueEN.CAlmacen = iHoja.Range["F" + i].Text;
                iCueEN.CArea = iHoja.Range["G" + i].Text;
                iCueEN.CFlujoCaja = iHoja.Range["H" + i].Text;
                iCueEN.CAutomatica = iHoja.Range["I" + i].Text;
                iCueEN.CDiferenciaCambio = iHoja.Range["J" + i].Text;
                iCueEN.CBanco = iHoja.Range["K" + i].Text;
                iCueEN.CMoneda = iHoja.Range["L" + i].Text;
                iCueEN.CAsientoApertura = iHoja.Range["M" + i].Text;
                iCueEN.CAsientoCierre7 = iHoja.Range["N" + i].Text;
                iCueEN.CAsientoCierre9 = iHoja.Range["O" + i].Text;
                iCueEN.CodigoCuentaAutomatica1 = iHoja.Range["P" + i].Text;
                iCueEN.CodigoCuentaAutomatica2 = iHoja.Range["Q" + i].Text;
                iCueEN.CodigoFormatoContable = iHoja.Range["R" + i].Text;
                iCueEN.CEstadoCuenta = iHoja.Range["S" + i].Text;
                iCueEN.COrigenVentanaCreacion = "03";//Ventana Importacion excel
                iCueEN.NumeroDigitosAnalitica = iCueEN.CodigoCuenta.Length.ToString();
                iCueEN.ClaveCuenta = CuentaRN.ObtenerClaveCuenta(iCueEN);

                //insertar a la lista resultado
                iLisRes.Add(iCueEN);
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
            Cmb.SeleccionarValorItem(this.cmbError, "99");
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

            //obtener la hoja de la lectura de agua
            Worksheet iHoja = this.ObtenerHojaExcel();

            //numero de digitos analitica para esta empresa
            int iNumeroDigitosAnalitica = EmpresaRN.ObtenerNumeroDigitosAnaliticaEmpresaDeAcceso();

            //obtener el numero de registros del excel
            int iNumeroRegistros = this.ObtenerNumeroRegistrosExcel(iHoja);

            //listas de codigos de cuentas
            List<string> iListaCodigosCuentas = CuentaRN.ListarCodigosCuentas();

            //lista de codigos de Si No
            List<string> ilistaSiNo = ItemGRN.ListarCodigosItems("SiNo");

            //listar los codigos de cuentas analiticas de bd y todas las cuentas que hay en el excel
            List<string> iListaCuentasAnaliticasYExcel = this.ListarCodigoCuentasAnaliticasDeBDYExcel("A", 2, iHoja, iNumeroRegistros);

            //lista de codigos de todos los formatos contables
            List<string> iListaFormatosContables = FormatoContableRN.ListarCodigosFormatoContables();

            ErrorCeldaExcel iErr;

            //recorrer cada fila del excel
            for (int i = 2; i < 100000; i++)
            {
                //si no hay dato en la fila , entonces se termina el bucle
                object iNulo = iHoja.Range["A" + i].Value;
                if (iNulo == null) { break; }

                //validar que la clave no exista en base de datos(Codigo)              
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorClaveExistenteBD("Codigo", "A" + i, iListaCodigosCuentas, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar la longitud del campo
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorLongitudCampo("Codigo", "A" + i,iNumeroDigitosAnalitica, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar la longitud del campo
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorLongitudCampo("Descripcion", "B" + i, 150, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar codigo inexistente 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistenteCondicionLongitudDato("Documento", "C" + i, ilistaSiNo, iHoja,
                    "A" + i, iNumeroDigitosAnalitica);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar codigo inexistente 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistenteCondicionLongitudDato("Auxiliar", "D" + i, ilistaSiNo, iHoja,
                    "A" + i, iNumeroDigitosAnalitica);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar codigo inexistente 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistenteCondicionLongitudDato("Centro Costo", "E" + i, ilistaSiNo, iHoja,
                    "A" + i, iNumeroDigitosAnalitica);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar codigo inexistente 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistenteCondicionLongitudDato("Almacen", "F" + i, ilistaSiNo, iHoja,
                    "A" + i, iNumeroDigitosAnalitica);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar codigo inexistente 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistenteCondicionLongitudDato("Area", "G" + i, ilistaSiNo, iHoja,
                    "A" + i, iNumeroDigitosAnalitica);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar codigo inexistente 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistenteCondicionLongitudDato("Flujo Caja", "H" + i, ilistaSiNo, iHoja,
                    "A" + i, iNumeroDigitosAnalitica);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar codigo inexistente 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistenteCondicionLongitudDato("Automatica", "I" + i, ilistaSiNo, iHoja,
                    "A" + i, iNumeroDigitosAnalitica);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar codigo inexistente 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistenteCondicionLongitudDato("Diferencia Cambio", "J" + i, ilistaSiNo, iHoja,
                    "A" + i, iNumeroDigitosAnalitica);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar codigo inexistente 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistenteCondicionLongitudDato("Banco", "K" + i, ilistaSiNo, iHoja,
                    "A" + i, iNumeroDigitosAnalitica);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar codigo inexistente 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistenteCondicionLongitudDato("Moneda", "L" + i, ilistaSiNo, iHoja,
                    "A" + i, iNumeroDigitosAnalitica);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar codigo inexistente 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistenteCondicionLongitudDato("Asiento Apertura", "M" + i, ilistaSiNo, iHoja,
                    "A" + i, 2);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar codigo inexistente 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistenteCondicionLongitudDato("Asiento Cierre 7", "N" + i, ilistaSiNo, iHoja,
                    "A" + i, 2);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar codigo inexistente 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistenteCondicionLongitudDato("Asiento Cierre 9", "O" + i, ilistaSiNo, iHoja,
                    "A" + i, 2);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar codigo inexistente 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistenteCondicionDato("Cuenta", "P" + i, iListaCuentasAnaliticasYExcel, iHoja,
                    "I" + i, "1");
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar codigo inexistente 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistenteCondicionDato("Cuenta", "Q" + i, iListaCuentasAnaliticasYExcel, iHoja,
                    "I" + i, "1");
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar campos iguales 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorValorCeldasIgualesCondicionDato( "P" + i, "Q" + i, iHoja, "I" + i, "1");
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar codigo inexistente 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistenteCondicionLongitudDato("Formato Contable", "R" + i, iListaFormatosContables, iHoja,
                    "A" + i, iNumeroDigitosAnalitica);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar codigo inexistente 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistente("Estado", "S" + i, ilistaSiNo, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }                
            }
                      
            //listar errores al validar las claves repetidas en el excel(Codigo)
            iLisRes.AddRange(this.ListarErroresPorClavesRepetidasEnExcel(iHoja, iNumeroRegistros));

            //destruir ala hoja
            MiExcel.EliminarHojaExcel(iHoja);

            //devolver
            return iLisRes;
        }

        public List<ErrorCeldaExcel> ListarErroresPorClavesRepetidasEnExcel(Worksheet pHoja, int pNumeroRegistros)
        {
            //asignar parametros
            string iColumnaClave = "A";
            int iIndiceFilaInicia = 2;
            int iNumeroRegistros = pNumeroRegistros;
            string iNombreCampo = "Codigo";

            //ejectuar metodo
            return MiExcel.ListarErroresExcelPorClavesRepetidasExcel(iColumnaClave, iIndiceFilaInicia, iNumeroRegistros, pHoja, iNombreCampo);
        }
      
        public List<string> ListarCodigoCuentasAnaliticasDeBDYExcel(string pColumnaClave,int pIndiceFilaInicia, Worksheet pHoja, int pNumeroRegistros)
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //cargamos las codigos de las cuentas analiticas que hay en bd
            iLisRes.AddRange(CuentaRN.ListarCodigosCuentasAnaliticas());

            //cargamos todos los codigos de las cuentas que estan en el excel
            iLisRes.AddRange(MiExcel.ListarDatosCeldasDeColumna(pColumnaClave, pIndiceFilaInicia, pNumeroRegistros, pHoja));

            //devolver
            return iLisRes;
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

        private void wImportarCuenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wCue.Enabled = true;
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
