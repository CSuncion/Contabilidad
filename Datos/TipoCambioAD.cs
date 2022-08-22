using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ScriptBD;
using Datos;
using Entidades;
using Entidades.Adicionales;
using Datos.Config;
using Comun;

namespace Datos
{

    public class TipoCambioAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<TipoCambioEN> xLista = new List<TipoCambioEN>();
        private TipoCambioEN xObj = new TipoCambioEN();
        private string xTabla = "TipoCambio";
        private string xVista = "VsTipoCambio";

        #endregion
        
        #region Metodos privados

        private TipoCambioEN Objeto(IDataReader iDr)
        {
            TipoCambioEN xObjEnc = new TipoCambioEN();
            xObjEnc.FechaTipoCambio = Fecha.ObtenerDiaMesAno(iDr[TipoCambioEN.FecTipCam].ToString());
            xObjEnc.AñoTipoCambio = iDr[TipoCambioEN.AñoTipCam].ToString();
            xObjEnc.CMesTipoCambio = iDr[TipoCambioEN.CMesTipCam].ToString();           
            xObjEnc.NMesTipoCambio = iDr[TipoCambioEN.NMesTipCam].ToString();
            xObjEnc.PeriodoTipoCambio = iDr[TipoCambioEN.PerTipCam].ToString();
            xObjEnc.CompraUsTipoCambio = Convert.ToDecimal(iDr[TipoCambioEN.ComUsTipCam].ToString());
            xObjEnc.VentaUsTipoCambio = Convert.ToDecimal(iDr[TipoCambioEN.VenUsTipCam].ToString());
            xObjEnc.CompraCadTipoCambio = Convert.ToDecimal(iDr[TipoCambioEN.ComCadTipCam].ToString());
            xObjEnc.VentaCadTipoCambio = Convert.ToDecimal(iDr[TipoCambioEN.VenCadTipCam].ToString());
            xObjEnc.CompraEurTipoCambio = Convert.ToDecimal(iDr[TipoCambioEN.ComEurTipCam].ToString());
            xObjEnc.VentaEurTipoCambio = Convert.ToDecimal(iDr[TipoCambioEN.VenEurTipCam].ToString());
            xObjEnc.CEstadoTipoCambio = iDr[TipoCambioEN.CEstTipCam].ToString();
            xObjEnc.NEstadoTipoCambio = iDr[TipoCambioEN.NEstTipCam].ToString();
            xObjEnc.UsuarioAgrega = iDr[TipoCambioEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[TipoCambioEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[TipoCambioEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[TipoCambioEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.FechaTipoCambio;
            return xObjEnc;
        }
        
        private List<TipoCambioEN> ListarObjetos(string pScript)
        {
            xObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
            xObjCon.ComandoTexto(pScript);
            IDataReader xIdr = xObjCon.ObtenerIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xLista.Add(this.Objeto(xIdr));
            }
            xObjCon.Desconectar();
            return xLista;
        }
        
        private TipoCambioEN BuscarObjeto(string pScript)
        {
            xObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
            xObjCon.ComandoTexto(pScript);
            IDataReader xIdr = xObjCon.ObtenerIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xObj = this.Objeto(xIdr);
            }
            xObjCon.Desconectar();
            return xObj;
        }
        
        private bool ExisteObjeto(string pScript)
        {
            xObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
            xObjCon.ComandoTexto(pScript);
            IDataReader xIdr = xObjCon.ObtenerIdr();
            bool xResultado = false;
            while (xIdr.Read())
            {
                string xTxt = xIdr["Busqueda"].ToString();
                if (xTxt != string.Empty)
                {
                    xResultado = true;
                }
            }
            xObjCon.Desconectar();
            return xResultado;
        }

        #endregion

        #region Metodos publicos

        public bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public void AgregarTipoCambio(TipoCambioEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(TipoCambioEN.FecTipCam, Fecha.ObtenerAnoMesDia(pObj.FechaTipoCambio));
            xIns.AsignarParametro(TipoCambioEN.AñoTipCam, pObj.AñoTipoCambio);
            xIns.AsignarParametro(TipoCambioEN.CMesTipCam, pObj.CMesTipoCambio);
            xIns.AsignarParametro(TipoCambioEN.PerTipCam, pObj.PeriodoTipoCambio);
            xIns.AsignarParametro(TipoCambioEN.ComUsTipCam, pObj.CompraUsTipoCambio.ToString());
            xIns.AsignarParametro(TipoCambioEN.VenUsTipCam, pObj.VentaUsTipoCambio.ToString());
            xIns.AsignarParametro(TipoCambioEN.ComCadTipCam, pObj.CompraCadTipoCambio.ToString());
            xIns.AsignarParametro(TipoCambioEN.VenCadTipCam, pObj.VentaCadTipoCambio.ToString());
            xIns.AsignarParametro(TipoCambioEN.ComEurTipCam, pObj.CompraEurTipoCambio.ToString());
            xIns.AsignarParametro(TipoCambioEN.VenEurTipCam, pObj.VentaEurTipoCambio.ToString());
            xIns.AsignarParametro(TipoCambioEN.CEstTipCam, pObj.CEstadoTipoCambio);
            xIns.AsignarParametro(TipoCambioEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(TipoCambioEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(TipoCambioEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(TipoCambioEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarTipoCambio(TipoCambioEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(TipoCambioEN.ComUsTipCam, pObj.CompraUsTipoCambio.ToString());
            xUpd.AsignarParametro(TipoCambioEN.VenUsTipCam, pObj.VentaUsTipoCambio.ToString());
            xUpd.AsignarParametro(TipoCambioEN.ComCadTipCam, pObj.CompraCadTipoCambio.ToString());
            xUpd.AsignarParametro(TipoCambioEN.VenCadTipCam, pObj.VentaCadTipoCambio.ToString());
            xUpd.AsignarParametro(TipoCambioEN.ComEurTipCam, pObj.CompraEurTipoCambio.ToString());
            xUpd.AsignarParametro(TipoCambioEN.VenEurTipCam, pObj.VentaEurTipoCambio.ToString());
            xUpd.AsignarParametro(TipoCambioEN.CEstTipCam, pObj.CEstadoTipoCambio);
            xUpd.AsignarParametro(TipoCambioEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(TipoCambioEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, TipoCambioEN.FecTipCam, SqlSelect.Operador.Igual, Fecha.ObtenerAnoMesDia(pObj.FechaTipoCambio));
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarTipoCambio(TipoCambioEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, TipoCambioEN.FecTipCam, SqlSelect.Operador.Igual, Fecha.ObtenerAnoMesDia(pObj.FechaTipoCambio));
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<TipoCambioEN> ListarTipoCambios(TipoCambioEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);          
            //xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Desc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public TipoCambioEN BuscarTipoCambioXFecha(TipoCambioEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, TipoCambioEN.FecTipCam, SqlSelect.Operador.Igual, Fecha.ObtenerAnoMesDia(pObj.FechaTipoCambio));
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        #endregion

    }
}
