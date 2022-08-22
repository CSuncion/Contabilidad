using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;
using Presentacion.Principal;
using Negocio;
using Comun;
using WinControles.ControlesWindows;
using WinControles;
using Entidades.Adicionales;
using Presentacion.Listas;
using System.IO;


namespace Presentacion.Varios
{
    public partial class wParametrosGenerales : Heredados.MiForm8
    {
        public wParametrosGenerales()
        {
            InitializeComponent();
        }

        //variables      
        Masivo eMas = new Masivo();
         
        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtTipOpeTraIng, true, "Tip.Ope Transferencia Ingreso", "vvvv", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtTipOpeTraSal, true, "Tip.Ope Transferencia Salida", "vvvv", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtTipOpeProIng, true, "Tip.Ope Produccion Ingreso", "vvvv", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtTipOpeProSal, true, "Tip.Ope Produccion Salida", "vvvv", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCenCosPro, true, "Centro Costo Produccion", "vvvv", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtPorIgv, true, "% I.G.V", "vvvv", 2, 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAceptar, "vvvv");
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
            this.Show();
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();
            this.MostrarParametro();          
        }

        public void AsignarParametro(ParametroEN pObj)
        {
            pObj.PorcentajeIgv = Conversion.ADecimal(this.txtPorIgv.Text, 0);
        }

        public void MostrarParametro()
        {
            //traemos al parametro de la b.d
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //mostar datos        
            this.txtRutLog.Text = iParEN.RutaLogoEmpresa;          
            this.txtTipOpeTraIng.Text = iParEN.TipoOperacionTransferenciaIngreso;         
            this.txtTipOpeTraSal.Text = iParEN.TipoOperacionTransferenciaSalida;
            this.txtTipOpeProSal.Text = iParEN.TipoOperacionProduccionSalida;
            this.txtTipOpeProIng.Text = iParEN.TipoOperacionProduccionIngreso;
            this.txtCenCosPro.Text = iParEN.CentroCostoProduccion;
            this.txtPorIgv.Text = Formato.NumeroDecimal(iParEN.PorcentajeIgv, 2);
        }

        public void SeleccionarUbicacion(TextBox pTextBox)
        {
            FolderBrowserDialog iBuscarRuta = new FolderBrowserDialog();
            if (iBuscarRuta.ShowDialog() == DialogResult.OK)
            {
                pTextBox.Text = iBuscarRuta.SelectedPath;
            }
        }

        public void MensajeDeConfirmacion()
        {
            MessageBox.Show("El parametro se modifico Correctamente", "Parametro", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ModificarCampo(string pCampo, string pValor)
        {
            ParametroRN.ModificarCampoParametro(pCampo, pValor);
            this.MensajeDeConfirmacion();
        }

        public void BuscarArchivoWord(TextBox pTextBox, string pRutaCarpetaDestino)
        {
            //llamar al cuadro de dialogo para buscar una imagen
            OpenFileDialog iBuscarImagen = new OpenFileDialog();
            iBuscarImagen.Filter = "Archivos de documentos word|*.docx";
            iBuscarImagen.FileName = string.Empty;
            iBuscarImagen.Title = "Buscar docuemnto word";
            iBuscarImagen.InitialDirectory = pRutaCarpetaDestino;

            if (iBuscarImagen.ShowDialog() == DialogResult.OK)
            {

                //informacion del archivo
                FileInfo info = new FileInfo(iBuscarImagen.FileName);
                string iNombreArchivo = info.Name;
                string iDirectorioOrigen = info.DirectoryName;
                string iOrigenArchivo = Path.Combine(iDirectorioOrigen, iNombreArchivo);
                string iDestinoArchivo = Path.Combine(pRutaCarpetaDestino, iNombreArchivo);
                if (pRutaCarpetaDestino != iDirectorioOrigen)
                {
                    File.Copy(iOrigenArchivo, iDestinoArchivo, true);
                }
                pTextBox.Text = iDestinoArchivo;
            }
        }

        public void Aceptar()
        {
            //validar datos obligatorios
            if (this.eMas.CamposObligatorios() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion("Parametros") == false) { return; }

            //modificar
            this.ModificarParametro();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Los parametros se modificaron correctamente", "Parametros");
            
            //salir de la ventana
            this.Close();
        }

        public void ModificarParametro()
        {
            //asignar parametros
            ParametroEN iParEN = ParametroRN.BuscarParametro();
            this.AsignarParametro(iParEN);

            //ejecutar metodo
            ParametroRN.ModificarParametro(iParEN);
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteParametros, null);
        }

   
        #endregion
            
        private void btnCancelar_Click(object sender, EventArgs e)
        {        
            this.Close( );
        }
        
        private void wParametrosGenerales_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();     
        }
              
        private void btnBusLog_Click(object sender, EventArgs e)
        {
            this.SeleccionarUbicacion(this.txtRutLog);
        }

        private void btnActRutLog_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.RutLogEmp, this.txtRutLog.Text);
        }

        private void btnTipOpeTraIng_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.TipOpeTraIng, this.txtTipOpeTraIng.Text);
        }

        private void btnTipOpeTraSal_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.TipOpeTraSal, this.txtTipOpeTraSal.Text);
        }

        private void btnTipOpeProSal_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.TipOpeProSal, this.txtTipOpeProSal.Text);
        }

        private void btnTipOpeProIng_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.TipOpeProIng, this.txtTipOpeProIng.Text);
        }

        private void btnCenCosPro_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.CenCosPro, this.txtCenCosPro.Text);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }
    }
}
