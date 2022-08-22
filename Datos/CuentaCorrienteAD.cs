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

    public class CuentaCorrienteAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<CuentaCorrienteEN> xLista = new List<CuentaCorrienteEN>();
        private CuentaCorrienteEN xObj = new CuentaCorrienteEN();
        private string xTabla = "CuentaCorriente";
        private string xVista = "VsCuentaCorriente";

        #endregion
        
        #region Metodos privados

        private CuentaCorrienteEN Objeto(IDataReader iDr)
        {
            CuentaCorrienteEN xObjEnc = new CuentaCorrienteEN();
            xObjEnc.ClaveCuentaCorriente = iDr[CuentaCorrienteEN.ClaCtaCte].ToString();
            xObjEnc.ClaveDocumentoCuentaCorriente = iDr[CuentaCorrienteEN.ClaDocCtaCte].ToString();
            xObjEnc.CodigoEmpresa = iDr[CuentaCorrienteEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[CuentaCorrienteEN.NomEmp].ToString();
            xObjEnc.PeriodoRegContabCabe = iDr[CuentaCorrienteEN.PerRegConCab].ToString();
            xObjEnc.COrigen = iDr[CuentaCorrienteEN.COri].ToString();
            xObjEnc.NOrigen = iDr[CuentaCorrienteEN.NOri].ToString();
            xObjEnc.CFile = iDr[CuentaCorrienteEN.CFil].ToString();
            xObjEnc.NFile = iDr[CuentaCorrienteEN.NFil].ToString();
            xObjEnc.NumeroVoucherRegContabCabe = iDr[CuentaCorrienteEN.NumVouRegConCab].ToString();
            xObjEnc.CodigoAuxiliar = iDr[CuentaCorrienteEN.CodAux].ToString();
            xObjEnc.DescripcionAuxiliar = iDr[CuentaCorrienteEN.DesAux].ToString();
            xObjEnc.CTipoDocumento = iDr[CuentaCorrienteEN.CTipDoc].ToString();
            xObjEnc.NTipoDocumento = iDr[CuentaCorrienteEN.NTipDoc].ToString();            
            xObjEnc.SerieDocumento = iDr[CuentaCorrienteEN.SerDoc].ToString();
            xObjEnc.NumeroDocumento = iDr[CuentaCorrienteEN.NumDoc].ToString();
            xObjEnc.FechaDocumento = Fecha.ObtenerDiaMesAno(iDr[CuentaCorrienteEN.FecDoc].ToString());            
            xObjEnc.CMonedaDocumento = iDr[CuentaCorrienteEN.CMonDoc].ToString();
            xObjEnc.NMonedaDocumento = iDr[CuentaCorrienteEN.NMonDoc].ToString();
            xObjEnc.FechaVctoDocumento = Fecha.ObtenerDiaMesAno(iDr[CuentaCorrienteEN.FecVctDoc].ToString());
            xObjEnc.VentaTipoCambio = Convert.ToDecimal(iDr[CuentaCorrienteEN.VenTipCam].ToString());
            xObjEnc.VentaEurTipoCambio = Convert.ToDecimal(iDr[CuentaCorrienteEN.VenEurTipCam].ToString());
            xObjEnc.PorcentajeIgv = Convert.ToDecimal(iDr[CuentaCorrienteEN.PorIgv].ToString());
            xObjEnc.ImporteOriginalCuentaCorriente = Convert.ToDecimal(iDr[CuentaCorrienteEN.ImpOriCtaCte].ToString());
            xObjEnc.ImportePagadoCuentaCorriente = Convert.ToDecimal(iDr[CuentaCorrienteEN.ImpPagCtaCte].ToString());
            xObjEnc.SaldoCuentaCorriente = Convert.ToDecimal(iDr[CuentaCorrienteEN.SalCtaCte].ToString());
            xObjEnc.CodigoCuenta = iDr[CuentaCorrienteEN.CodCta].ToString();
            xObjEnc.DescripcionCuenta = iDr[CuentaCorrienteEN.DesCta].ToString();
            xObjEnc.CEstadoCuentaCorriente= iDr[CuentaCorrienteEN.CEstCtaCte].ToString();
            xObjEnc.NEstadoCuentaCorriente = iDr[CuentaCorrienteEN.NEstCtaCte].ToString();
            xObjEnc.UsuarioAgrega = iDr[CuentaCorrienteEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[CuentaCorrienteEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[CuentaCorrienteEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[CuentaCorrienteEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveCuentaCorriente;
            return xObjEnc;
        }
        
        private List<CuentaCorrienteEN> ListarObjetos(string pScript)
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
        
        private CuentaCorrienteEN BuscarObjeto(string pScript)
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

        public bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaCorrienteEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaCorrienteEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }
        
        public void AgregarCuentaCorriente(CuentaCorrienteEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(CuentaCorrienteEN.ClaCtaCte, pObj.ClaveCuentaCorriente);
            xIns.AsignarParametro(CuentaCorrienteEN.ClaDocCtaCte, pObj.ClaveDocumentoCuentaCorriente);
            xIns.AsignarParametro(CuentaCorrienteEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(CuentaCorrienteEN.PerRegConCab, pObj.PeriodoRegContabCabe);
            xIns.AsignarParametro(CuentaCorrienteEN.COri, pObj.COrigen);
            xIns.AsignarParametro(CuentaCorrienteEN.CFil, pObj.CFile);
            xIns.AsignarParametro(CuentaCorrienteEN.NumVouRegConCab, pObj.NumeroVoucherRegContabCabe);
            xIns.AsignarParametro(CuentaCorrienteEN.CodAux, pObj.CodigoAuxiliar);
            xIns.AsignarParametro(CuentaCorrienteEN.CTipDoc, pObj.CTipoDocumento);
            xIns.AsignarParametro(CuentaCorrienteEN.SerDoc, pObj.SerieDocumento);
            xIns.AsignarParametro(CuentaCorrienteEN.NumDoc, pObj.NumeroDocumento);
            xIns.AsignarParametro(CuentaCorrienteEN.FecDoc, Fecha.ObtenerAnoMesDia(pObj.FechaDocumento));
            
            xIns.AsignarParametro(CuentaCorrienteEN.CMonDoc, pObj.CMonedaDocumento);
            xIns.AsignarParametro(CuentaCorrienteEN.FecVctDoc, Fecha.ObtenerAnoMesDia(pObj.FechaVctoDocumento));
            xIns.AsignarParametro(CuentaCorrienteEN.VenTipCam, pObj.VentaTipoCambio.ToString());
            xIns.AsignarParametro(CuentaCorrienteEN.VenEurTipCam, pObj.VentaEurTipoCambio.ToString());
            xIns.AsignarParametro(CuentaCorrienteEN.PorIgv, pObj.PorcentajeIgv.ToString());
            xIns.AsignarParametro(CuentaCorrienteEN.ImpOriCtaCte, pObj.ImporteOriginalCuentaCorriente.ToString());
            xIns.AsignarParametro(CuentaCorrienteEN.ImpPagCtaCte, pObj.ImportePagadoCuentaCorriente.ToString());
            xIns.AsignarParametro(CuentaCorrienteEN.SalCtaCte, pObj.SaldoCuentaCorriente.ToString());
            xIns.AsignarParametro(CuentaCorrienteEN.CodCta, pObj.CodigoCuenta);
            xIns.AsignarParametro(CuentaCorrienteEN.CEstCtaCte, pObj.CEstadoCuentaCorriente);
            xIns.AsignarParametro(CuentaCorrienteEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(CuentaCorrienteEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(CuentaCorrienteEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(CuentaCorrienteEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarCuentaCorriente(CuentaCorrienteEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);

            xUpd.AsignarParametro(CuentaCorrienteEN.CodAux, xObj.CodigoAuxiliar);
            xUpd.AsignarParametro(CuentaCorrienteEN.CTipDoc, xObj.CTipoDocumento);
            xUpd.AsignarParametro(CuentaCorrienteEN.SerDoc, xObj.SerieDocumento);
            xUpd.AsignarParametro(CuentaCorrienteEN.NumDoc, xObj.NumeroDocumento);
            xUpd.AsignarParametro(CuentaCorrienteEN.FecDoc, Fecha.ObtenerAnoMesDia(xObj.FechaDocumento));
            xUpd.AsignarParametro(CuentaCorrienteEN.CMonDoc, xObj.CMonedaDocumento);
            xUpd.AsignarParametro(CuentaCorrienteEN.FecVctDoc, Fecha.ObtenerAnoMesDia(xObj.FechaVctoDocumento));            
            xUpd.AsignarParametro(CuentaCorrienteEN.VenTipCam, xObj.VentaTipoCambio.ToString());
            xUpd.AsignarParametro(CuentaCorrienteEN.VenEurTipCam, xObj.VentaEurTipoCambio.ToString());
            xUpd.AsignarParametro(CuentaCorrienteEN.PorIgv, xObj.PorcentajeIgv.ToString());
            xUpd.AsignarParametro(CuentaCorrienteEN.ImpOriCtaCte, xObj.ImporteOriginalCuentaCorriente.ToString());
            xUpd.AsignarParametro(CuentaCorrienteEN.ImpPagCtaCte, xObj.ImportePagadoCuentaCorriente.ToString());
            xUpd.AsignarParametro(CuentaCorrienteEN.SalCtaCte, xObj.SaldoCuentaCorriente.ToString());
            xUpd.AsignarParametro(CuentaCorrienteEN.CodCta, pObj.CodigoCuenta);
            xUpd.AsignarParametro(CuentaCorrienteEN.CEstCtaCte, pObj.CEstadoCuentaCorriente);
            xUpd.AsignarParametro(CentroCostoEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(CentroCostoEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaCorrienteEN.ClaCtaCte, SqlSelect.Operador.Igual, pObj.ClaveCuentaCorriente);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarCuentaCorriente(CuentaCorrienteEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaCorrienteEN.ClaCtaCte, SqlSelect.Operador.Igual, pObj.ClaveCuentaCorriente);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<CuentaCorrienteEN> ListarCuentaCorriente(CuentaCorrienteEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaCorrienteEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public CuentaCorrienteEN BuscarCuentaCorrienteXClave(CuentaCorrienteEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaCorrienteEN.ClaCtaCte, SqlSelect.Operador.Igual, pObj.ClaveCuentaCorriente);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public void EliminarCuentaCorrienteDeRegContabCabe(RegContabCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaCorrienteEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuentaCorrienteEN.ClaCtaCte, SqlSelect.Operador.Igual, pObj.ClaveRegContabCabe);
            //xSel.CondicionCV(SqlSelect.Reservada.Y, SaldoEN.CodExi, SqlSelect.Operador.Igual, pObj.CodigoExistencia);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public CuentaCorrienteEN BuscarCuentaCorrienteXClaveDocumentoCuentaCorriente(CuentaCorrienteEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaCorrienteEN.ClaCtaCte, SqlSelect.Operador.Igual, pObj.ClaveCuentaCorriente);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        #endregion

    }
}
