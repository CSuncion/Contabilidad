using Negocio;
using Presentacion.Desarrollador;
using Presentacion.Maestros;
using Presentacion.Sistema;
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
using Comun;
using WinControles;

using Presentacion.Varios;
using Entidades.Adicionales;
using Presentacion.Impresiones;
using Presentacion.Procesos;

namespace Presentacion.Principal
{
    public partial class wMenu : Form
    {
        public wMenu()
        {
            InitializeComponent();
        }

        #region Metodos

        public void NuevaVentanaAcceso()
        {
            //instanciamos wAcceso
            wAcceso win = new wAcceso();
            win.wMen = this;
            win.NuevaVentana();
        }

        public List<Form> ObtenerListaDeVentanasAbiertas()
        {
            //lista resultado
            List<Form> iLisRes = new List<Form>();

            //solo excepto el wMenu y el wAcceso
            foreach (Form xWin in Application.OpenForms)
            {
                if (xWin.Name != "wMenu" && xWin.Name != "wAcceso")
                {
                    iLisRes.Add(xWin);
                }
            }

            //devolver
            return iLisRes;
        }

        public void EliminarTodasLasVentanasAbiertas()
        {
            //obtener la lista de ventanas a eliminar
            List<Form> iLisVenEli = this.ObtenerListaDeVentanasAbiertas();

            //obtener el numero de formularios abiertos
            int iNumeroVentanasAbiertas = iLisVenEli.Count;

            //ir eliminando cada ventana 
            for (int i = 0; i < iNumeroVentanasAbiertas; i++)
            {
                iLisVenEli[i].Close();
            }
        }

        public void EliminarTodosLosTabVentanas()
        {
            //esta ventana puede ser instanciada por el boton cambiar usuario
            //y en ese momento puede tener modulos abiertos , entonces cuando el usuario
            //ingrese con otro usuario , cerraremos todos los modulos 
            //obtener el numero de tab
            int iNroTabPage = this.tbcContenedor.TabPages.Count;

            //eliminar todos los tabpage pero desde el indice 1
            for (int i = 0; i < iNroTabPage; i++)
            {
                this.tbcContenedor.TabPages.RemoveAt(0);
            }
        }

        public void FormatoVentanaHijoPrincipal(Form pWin, ToolStripMenuItem pItem, ToolStripButton pAccDir, int PAncVen, int pAltVen)
        {
            pItem.Enabled = false;
            if (pAccDir != null) { pAccDir.Enabled = false; }
            this.tbcContenedor.Visible = true;
            //this.BackColor = System.Drawing.SystemColors.Control;
            this.BackColor = Color.White;
            TabCtrl.InsertarVentanaConTabPage(this.tbcContenedor, pWin, PAncVen, pAltVen);
        }

        public void CerrarVentanaHijo(Form pWin, ToolStripMenuItem pItem, ToolStripButton pAccDir)
        {
            pItem.Enabled = true;
            if (pAccDir != null) { pAccDir.Enabled = true; }
            TabCtrl.EliminarTabPageAlCerrarVentana(this.tbcContenedor, pWin);
            if (this.tbcContenedor.TabPages.Count == 0)
            {
                this.tbcContenedor.Visible = false;
                this.BackColor = Color.Gray;
            }
        }

        public void BloquearSistema()
        {
            wBloquearSistema win = new wBloquearSistema();
            this.tbcContenedor.Visible = false;
            this.BackColor = Color.Gray;
            win.wMen = this;
            win.NuevaVentana();
        }

        public void CambiarAcceso()
        {
            //instanciamos wAcceso
            wAcceso win = new wAcceso();
            this.tbcContenedor.Visible = false;
            this.BackColor = Color.Gray;
            win.wMen = this;
            win.eFlagInvoca = 1;
            win.NuevaVentana();
        }

        public void HabilitarAcciones()
        {
            //asignar parametros          
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaMenuPrincipal();

            //ejecutar metodo para el menu
            this.HabilitaAccionesMenu(iLisPer);

            //ejecutar metodo para los accesos directos
            this.HabilitaAccionesAccesosDirectos(iLisPer);
        }

        public void HabilitaAccionesMenu(Hashtable pListaPermisos)
        {
            //asignar parametros
            MenuStrip iMenu = msMenu;
            Hashtable iLisPer = pListaPermisos;

            //ejecutar metodo
            MeSt.HabilitarItems(iMenu, iLisPer);
        }

        public void HabilitaAccionesAccesosDirectos(Hashtable pListaPermisos)
        {
            //asignar parametros
            ToolStrip iTs = this.tsAccDir;
            Hashtable iLisPer = pListaPermisos;

            //ejecutar metodo
            Tst.HabilitarItems(iTs, iLisPer);
        }

        #endregion

        #region Instancias

        public void InstanciarEmpresas()
        {
            wEmpresa win = new wEmpresa();
            this.FormatoVentanaHijoPrincipal(win, this.IteEmpresas, null, 85, 85);
            win.NuevaVentana();
        }

        public void InstanciarUsuarios()
        {
            wUsuario win = new wUsuario();
            this.FormatoVentanaHijoPrincipal(win, this.IteUsuarios, null, 80, 80);
            win.NuevaVentana();
        }

        public void InstanciarPerfil()
        {
            wPerfil win = new wPerfil();
            this.FormatoVentanaHijoPrincipal(win, this.ItePerfiles, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarCambioDeClave()
        {
            wCambiarClave win = new wCambiarClave();
            this.FormatoVentanaHijoPrincipal(win, this.ItecambioDeClave, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarBotones()
        {
            wBoton win = new wBoton();
            this.FormatoVentanaHijoPrincipal(win, this.IteBotones, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarVentanas()
        {
            wVentana win = new wVentana();
            this.FormatoVentanaHijoPrincipal(win, this.IteVentanas, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarTablasGenerales()
        {
            wTablasGeneral win = new wTablasGeneral();
            this.FormatoVentanaHijoPrincipal(win, this.IteTablasGenerales, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarTablasEmpresas()
        {
            wTablasEmpresa win = new wTablasEmpresa();
            this.FormatoVentanaHijoPrincipal(win, this.IteTablasEmpresa, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarAuxiliares()
        {
            wAuxiliar win = new wAuxiliar();
            this.FormatoVentanaHijoPrincipal(win, this.IteAuxiliares, this.tsbAuxiliares, 90, 90);
            win.NuevaVentana();
        }

        public void InstanciarPeriodos()
        {
            wPeriodo win = new wPeriodo();
            this.FormatoVentanaHijoPrincipal(win, this.ItePeriodos, null, 0, 0);
            win.NuevaVentana();
        }
     
        public void InstanciarParametrosGenerales()
        {
            wParametrosGenerales win = new wParametrosGenerales();
            this.FormatoVentanaHijoPrincipal(win, this.IteParametros, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarCopiaSeguridadBD()
        {
            wCopiaSeguridad win = new wCopiaSeguridad();
            this.FormatoVentanaHijoPrincipal(win, this.IteCopiaSeguridadBD, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarTiposCambio()
        {
            wTipoCambio win = new wTipoCambio();
            this.FormatoVentanaHijoPrincipal(win, this.IteTiposCambio, this.tsbTiposCambio, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarCuentas()
        {
            wCuenta win = new wCuenta();
            this.FormatoVentanaHijoPrincipal(win, this.IteCuentas, null, 90, 90);
            win.NuevaVentana();
        }

        public void InstanciarFormatosContables()
        {
            wFormatoContable win = new wFormatoContable();
            this.FormatoVentanaHijoPrincipal(win, this.IteFormatoContable, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarCuentasBancos()
        {
            wCuentaBanco win = new wCuentaBanco();
            this.FormatoVentanaHijoPrincipal(win, this.IteCuentaBancos, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarItemsAlmacen()
        {
            wItemAlmacen win = new wItemAlmacen();
            this.FormatoVentanaHijoPrincipal(win, this.IteItemAlmacen, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarRegistroCompra()
        {
            wRegistroCompra win = new wRegistroCompra();
            this.FormatoVentanaHijoPrincipal(win, this.IteRcCompras, tsbCompras, 92, 90);
            win.NuevaVentana();
        }

        public void InstanciarTiposDocumento()
        {
            wTipoDocumento win = new wTipoDocumento();
            this.FormatoVentanaHijoPrincipal(win, this.IteTiposDocumentos, null, 0, 0);
            win.NuevaVentana();
        }
        public void InstanciarCajaBanco()
        {
            wCajaBanco win = new wCajaBanco();
            this.FormatoVentanaHijoPrincipal(win, this.IteRcCajaYBancos, null, 92, 90);
            win.NuevaVentana();
        }
        #endregion

        private void wMenu_Load(object sender, EventArgs e)
        {
            this.NuevaVentanaAcceso();
        }

        private void wMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                bool iRpta = Mensaje.DeseasRealizarOperacion("Salir del sistema");
                if (iRpta == false)
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void IteSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ItecambioDeClave_Click(object sender, EventArgs e)
        {
            this.InstanciarCambioDeClave();
        }

        private void IteBloquearSistema_Click(object sender, EventArgs e)
        {
            this.BloquearSistema();
        }

        private void IteCambiarAcceso_Click(object sender, EventArgs e)
        {
            this.CambiarAcceso();
        }

        private void tsbBloSis_Click(object sender, EventArgs e)
        {
            this.BloquearSistema();
        }

        private void tsbCamAcc_Click(object sender, EventArgs e)
        {
            this.CambiarAcceso();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IteEmpresas_Click(object sender, EventArgs e)
        {
            this.InstanciarEmpresas();
        }

        private void IteUsuarios_Click(object sender, EventArgs e)
        {
            this.InstanciarUsuarios();
        }

        private void ItePerfiles_Click(object sender, EventArgs e)
        {
            this.InstanciarPerfil();
        }

        private void IteTablasGenerales_Click(object sender, EventArgs e)
        {
            this.InstanciarTablasGenerales();
        }

        private void IteBotones_Click(object sender, EventArgs e)
        {
            this.InstanciarBotones();
        }

        private void IteVentanas_Click(object sender, EventArgs e)
        {
            this.InstanciarVentanas();
        }

        private void IteAuxiliares_Click(object sender, EventArgs e)
        {
            this.InstanciarAuxiliares();
        }

        private void tsbAuxiliares_Click(object sender, EventArgs e)
        {
            this.InstanciarAuxiliares();
        }

        private void ItePeriodos_Click(object sender, EventArgs e)
        {
            this.InstanciarPeriodos();
        }

        private void IteParametros_Click(object sender, EventArgs e)
        {
            this.InstanciarParametrosGenerales();
        }

        private void IteCopiaSeguridadBD_Click(object sender, EventArgs e)
        {
            this.InstanciarCopiaSeguridadBD();
        }

        private void IteTiposCambio_Click(object sender, EventArgs e)
        {
            this.InstanciarTiposCambio();
        }

        private void tsbTiposCambio_Click(object sender, EventArgs e)
        {
            this.InstanciarTiposCambio();
        }

        private void IteTablasEmpresa_Click(object sender, EventArgs e)
        {
            this.InstanciarTablasEmpresas();
        }

        private void IteCuentas_Click(object sender, EventArgs e)
        {
            this.InstanciarCuentas();
        }

        private void IteFormatoContable_Click(object sender, EventArgs e)
        {
            this.InstanciarFormatosContables();
        }

        private void IteCuentaBancos_Click(object sender, EventArgs e)
        {
            this.InstanciarCuentasBancos();
        }

        private void IteItemAlmacen_Click(object sender, EventArgs e)
        {
            this.InstanciarItemsAlmacen();
        }

        private void IteRcCompras_Click(object sender, EventArgs e)
        {
            this.InstanciarRegistroCompra();
        }

        private void IteTiposDocumentos_Click(object sender, EventArgs e)
        {
            this.InstanciarTiposDocumento();
        }

        private void tsbCompras_Click(object sender, EventArgs e)
        {
            this.InstanciarRegistroCompra();
        }

        private void IteRcCajaYBancos_Click(object sender, EventArgs e)
        {
            this.InstanciarCajaBanco();
        }
    }
}
