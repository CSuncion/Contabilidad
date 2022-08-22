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
    public partial class wCuentaBanco : Heredados.MiForm8
    {
        public wCuentaBanco()
        {
            InitializeComponent();
        }

        #region Atributos

        string eNombreColumnaDgvCueBan = CuentaBancoEN.CodCueBan;
        string eEncabezadoColumnaDgvCueBan = "Codigo";
        public string eClaveDgvCueBan = string.Empty;
        Dgv.Franja eFranjaDgvCueBan = Dgv.Franja.PorIndice;
        public List<CuentaBancoEN> eLisCueBan = new List<CuentaBancoEN>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "Cuenta Banco";

        #endregion

        #region General


        public void NuevaVentana()
        {
            this.Show();
            this.ActualizarVentana();
        }

        public void ActualizarVentana()
        {
            this.ActualizarListaCuentaBancoesDeBaseDatos();
            this.ActualizarDgvCueBan();
            Dgv.HabilitarDesplazadores(this.DgvCueBan, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvCueBan, this.sst1);
            this.AccionBuscar();
        }

        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvCueBan;
            this.tstBuscar.Focus();
        }

        public void ActualizarDgvCueBan()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvCueBan;
            List<CuentaBancoEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvCueBan;
            string iClaveBusqueda = eClaveDgvCueBan;
            string iColumnaPintura = eNombreColumnaDgvCueBan;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCueBan();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvCueBan()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaBancoEN.CodCueBan, "Codigo", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaBancoEN.DesCueBan, "Descripcion", 240));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaBancoEN.NomBan, "Banco", 120));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaBancoEN.NumCueBan, "Numero", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaBancoEN.NTip, "Tipo", 120));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaBancoEN.NMon, "Moneda", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaBancoEN.NEstCueBan, "Estado", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaBancoEN.ClaObj, "Clave", 90, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaCuentaBancoesDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            CuentaBancoEN iPerEN = new CuentaBancoEN();
            iPerEN.Adicionales.CampoOrden = eNombreColumnaDgvCueBan;
            this.eLisCueBan = CuentaBancoRN.ListarCuentaBanco(iPerEN);
        }

        public List<CuentaBancoEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvCueBan;
            List<CuentaBancoEN> iLisPer = eLisCueBan;

            //ejecutar y retornar
            return CuentaBancoRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iLisPer);
        }

        public void HabilitarAcciones()
        {
            //asignar parametros
            ToolStrip iTs1 = tsPrincipal;
            ToolStrip iTs2 = tsSecundario;
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaVentana("009", DgvCueBan.Rows.Count);

            //ejecutar metodo
            Tst.HabilitarItems(iTs1, iTs2, iLisPer);
        }

        public void AsignarCuentaBanco(CuentaBancoEN pObj)
        {
            pObj.ClaveCuentaBanco = Dgv.ObtenerValorCelda(this.DgvCueBan, CuentaBancoEN.ClaObj);
            pObj.CodigoCuentaBanco = Dgv.ObtenerValorCelda(this.DgvCueBan, CuentaBancoEN.CodCueBan);
        }

        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            CuentaBancoEN iAuxEN = this.EsActoModificarCuentaBanco();
            if (iAuxEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditCuentaBanco win = new wEditCuentaBanco();
            win.wCueBan = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvCueBan = Dgv.Franja.PorValor;
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

        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            CuentaBancoEN iAuxEN = this.EsCuentaBancoExistente();
            if (iAuxEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditCuentaBanco win = new wEditCuentaBanco();
            win.wCueBan = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iAuxEN);
        }

        public CuentaBancoEN EsCuentaBancoExistente()
        {
            CuentaBancoEN iAuxEN = new CuentaBancoEN();
            this.AsignarCuentaBanco(iAuxEN);
            iAuxEN = CuentaBancoRN.EsCuentaBancoExistente(iAuxEN);
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, eTitulo);
            }
            return iAuxEN;
        }

        public CuentaBancoEN EsActoModificarCuentaBanco()
        {
            CuentaBancoEN iAuxEN = new CuentaBancoEN();
            this.AsignarCuentaBanco(iAuxEN);
            iAuxEN = CuentaBancoRN.EsActoModificarCuentaBanco(iAuxEN);
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
            wMen.CerrarVentanaHijo(this, wMen.IteCuentaBancos, null);
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvCueBan = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvCueBan = this.DgvCueBan.Columns[pColumna].Name;
            this.eEncabezadoColumnaDgvCueBan = this.DgvCueBan.Columns[pColumna].HeaderText;
            this.ActualizarVentana();
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCueBan, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCueBan, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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

        private void wCuentaBanco_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvCueBan = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void DgvCueBan_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvCueBan, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvCueBan, this.sst1);
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCueBan, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCueBan, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCueBan, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCueBan, Dgv.Desplazar.Ultimo);
        }

        private void DgvCueBan_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void DgvCueBan_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex);
        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {
            this.AccionModificar();
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
