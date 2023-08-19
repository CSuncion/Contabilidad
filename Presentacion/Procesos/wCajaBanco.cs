using Comun;
using Entidades;
using Entidades.Adicionales;
using Heredados.VentanasPersonalizadas;
using Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControles.ControlesWindows;

namespace Presentacion.Procesos
{
    public partial class wCajaBanco : Heredados.MiForm8
    {
        string eNombreColumnaDgvCue = RegContabCabeEN.CodCue;
        string eEncabezadoColumnaDgvCajBco = "Codigo";
        public string eClaveDgvCajBco = string.Empty;
        Dgv.Franja eFranjaDgvCajBco = Dgv.Franja.PorIndice;
        public List<RegContabCabeEN> eLisCajBco = new List<RegContabCabeEN>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "Caja y Banco";

        public wCajaBanco()
        {
            InitializeComponent();
        }
        public void NuevaVentana()
        {
            this.Show();
            this.MostrarPersistencia();
        }
        public void ActualizarVentana()
        {
            this.ActualizarListaCuentaesDeBaseDatos();
            this.ActualizarDgvCajBco();
            Dgv.HabilitarDesplazadores(this.DgvCajaBanco, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvCajaBanco, this.sst1);
            this.AccionBuscar();
        }
        public void ActualizarListaCuentaesDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            RegContabCabeEN iRegContEN = new RegContabCabeEN();
            iRegContEN.PeriodoRegContabCabe = lblPeriodo.Text;
            iRegContEN.Adicionales.CampoOrden = eNombreColumnaDgvCue;
            iRegContEN.COrigen = "4";
            this.eLisCajBco = RegContabCabeRN.ListarRegContabCabeXPeriodoYOrigen(iRegContEN);
        }
        public void ActualizarDgvCajBco()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvCajaBanco;
            List<RegContabCabeEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvCajBco;
            string iClaveBusqueda = eClaveDgvCajBco;
            string iColumnaPintura = eNombreColumnaDgvCue;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCajBco();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        public List<RegContabCabeEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvCue;
            List<RegContabCabeEN> iLisCajBco = eLisCajBco;

            //ejecutar y retornar
            return RegContabCabeRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iLisCajBco);
        }
        public List<DataGridViewColumn> ListarColumnasDgvCajBco()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.ClaObj, "Clave", 140));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.COri, "Origen", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.NOri, "Nombre", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.CFil, "Origen", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.NFil, "File", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.CorRegConCab, "Numero Voucher", 120));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.FecRegConCab, "Fecha Voucher", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.ImpSolRegConCab, "Monto", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.CodCue, "Codigo Cuenta", 90));
            //iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN., "Codigo Cuenta", 90));
            //iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.NAut, "Automatica", 70));
            //iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.CodCueAut1, "Automatica1", 100));
            //iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.CodCueAut2, "Automatica2", 100));
            //iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.NumDigAna, "#.Dig", 50));
            //iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.NReg, "Registro", 70));
            //iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.CodForCon, "Formato.Cont", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RegContabCabeEN.ClaObj, "Clave", 90, false));

            //devolver
            return iLisRes;
        }
        public void AccionAdicionar()
        {
            wEditCajaBanco win = new wEditCajaBanco();
            win.wCajBco = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvCajBco = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }

        public void HabilitarAcciones()
        {
            //asignar parametros
            ToolStrip iTs1 = tsPrincipal;
            ToolStrip iTs2 = tsSecundario;
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaVentana("009", DgvCajaBanco.Rows.Count);

            //ejecutar metodo
            Tst.HabilitarItems(iTs1, iTs2, iLisPer);
        }

        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvCajBco;
            this.tstBuscar.Focus();
        }

        public void AccionSeleccionarPeriodo()
        {
            vSeleccionarPeriodo win = new vSeleccionarPeriodo();
            win.eVentanaInvoca = this;
            win.eControlDevuelveValor = lblPeriodo;
            win.ePeriodoActual = lblPeriodo.Text;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void AccionCambiaPeriodo()
        {
            //poner la descripcion del mes
            lblDescripcionPeriodo.Text = AñoMes.ObtenerDescripcionPeriodo(lblPeriodo.Text);

            //MessageBox.Show(lblDescripcionPeriodo.Text);

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

        private void tsbAdicionar_Click(object sender, EventArgs e)
        {
            this.AccionAdicionar();
        }

        private void btnPeriodo_Click(object sender, EventArgs e)
        {
            this.AccionSeleccionarPeriodo();
        }

        private void lblPeriodo_TextChanged(object sender, EventArgs e)
        {
            this.AccionCambiaPeriodo();
        }
    }
}
