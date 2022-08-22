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

    public class RegContabDetaAD
    {

        #region Atributos

        private SqlDatos eObjCon = new SqlDatos();
        private List<RegContabDetaEN> eLista = new List<RegContabDetaEN>();
        private RegContabDetaEN eObj = new RegContabDetaEN();
        private string eTabla = "RegContabDeta";
        private string eVista = "VsRegContabDeta";

        #endregion

        #region Metodos privados

        private RegContabDetaEN Objeto(IDataReader iDr)
        {
            RegContabDetaEN xObjEnc = new RegContabDetaEN();
            xObjEnc.ClaveRegContabDeta = iDr[RegContabDetaEN.ClaRegConDet].ToString();
            xObjEnc.CodigoEmpresa = iDr[RegContabDetaEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[RegContabDetaEN.NomEmp].ToString();
            xObjEnc.PeriodoRegContabCabe = iDr[RegContabDetaEN.PerRegConCab].ToString();
            xObjEnc.COrigen = iDr[RegContabDetaEN.COri].ToString();
            xObjEnc.NOrigen = iDr[RegContabDetaEN.NOri].ToString();
            xObjEnc.CFile = iDr[RegContabDetaEN.CFil].ToString();
            xObjEnc.NFile = iDr[RegContabDetaEN.NFil].ToString();
            xObjEnc.CorrelativoRegContabCabe = iDr[RegContabDetaEN.CorRegConCab].ToString();
            xObjEnc.CorrelativoRegContabDeta = iDr[RegContabDetaEN.CorRegConDet].ToString();
            xObjEnc.ClaveRegContabCabe = iDr[RegContabDetaEN.ClaRegConCab].ToString();
            xObjEnc.FechaRegContabCabe = iDr[RegContabDetaEN.FecRegConCab].ToString();
            xObjEnc.IgvSolRegContabCabe = Convert.ToDecimal(iDr[RegContabDetaEN.IgvSolRegConCab].ToString());
            xObjEnc.PrecioVentaSolRegContabCabe = Convert.ToDecimal(iDr[RegContabDetaEN.PreVenSolRegConCab].ToString());
            xObjEnc.CodigoAuxiliar = iDr[RegContabDetaEN.CodAux].ToString();
            xObjEnc.DescripcionAuxiliar = iDr[RegContabDetaEN.DesAux].ToString();
            xObjEnc.CTipoDocumento = iDr[RegContabDetaEN.CTipDoc].ToString();
            xObjEnc.NTipoDocumento = iDr[RegContabDetaEN.NTipDoc].ToString();
            xObjEnc.CAplicaDocumentoRef = iDr[RegContabDetaEN.CAplDocRef].ToString();
            xObjEnc.CTipoNota = iDr[RegContabDetaEN.CTipNot].ToString();
            xObjEnc.SerieDocumento = iDr[RegContabDetaEN.SerDoc].ToString();
            xObjEnc.NumeroDocumento = iDr[RegContabDetaEN.NumDoc].ToString();
            xObjEnc.FechaDocumento = Fecha.ObtenerDiaMesAno(iDr[RegContabDetaEN.FecDoc].ToString());
            xObjEnc.FechaVctoDocumento = Fecha.ObtenerDiaMesAno(iDr[RegContabDetaEN.FecVctDoc].ToString());
            xObjEnc.CMonedaDocumento = iDr[RegContabDetaEN.CMonDoc].ToString();
            xObjEnc.NMonedaDocumento = iDr[RegContabDetaEN.NMonDoc].ToString();
            xObjEnc.VentaTipoCambio = Convert.ToDecimal(iDr[RegContabDetaEN.VenTipCam].ToString());
            xObjEnc.CodigoCuenta = iDr[RegContabDetaEN.CodCue].ToString();
            xObjEnc.DescripcionCuenta = iDr[RegContabDetaEN.DesCue].ToString();
            xObjEnc.CAutomatica = iDr[RegContabDetaEN.CAut].ToString();
            xObjEnc.CodigoCuentaAutomatica1 = iDr[RegContabDetaEN.CodCueAut1].ToString();
            xObjEnc.CodigoCuentaAutomatica2 = iDr[RegContabDetaEN.CodCueAut2].ToString();
            xObjEnc.CBanco = iDr[RegContabDetaEN.CBan].ToString();
            xObjEnc.CMoneda = iDr[RegContabDetaEN.CMon].ToString();
            xObjEnc.CCentroCostoCuenta = iDr[RegContabDetaEN.CCenCosCue].ToString();
            xObjEnc.CAreaCuenta = iDr[RegContabDetaEN.CAreCue].ToString();
            xObjEnc.CAlmacen = iDr[RegContabDetaEN.CAlm].ToString();
            xObjEnc.CAuxiliar = iDr[RegContabDetaEN.CAux].ToString();
            xObjEnc.CDocumento = iDr[RegContabDetaEN.CDoc].ToString();
            xObjEnc.CDebeHaber = iDr[RegContabDetaEN.CDebHab].ToString();
            xObjEnc.NDebeHaber = iDr[RegContabDetaEN.NDebHab].ToString();
            xObjEnc.ImporteSolRegContabDeta = Convert.ToDecimal(iDr[RegContabDetaEN.ImpSolRegConDet].ToString());
            xObjEnc.ImporteMonedaRegContabDeta = Convert.ToDecimal(iDr[RegContabDetaEN.ImpMonRegConDet].ToString());
            xObjEnc.GlosaRegContabDeta = iDr[RegContabDetaEN.GloRegConDet].ToString();
            xObjEnc.CIngresoEgreso = iDr[RegContabDetaEN.CIngEgr].ToString();
            xObjEnc.NIngresoEgreso = iDr[RegContabDetaEN.NIngEgr].ToString();
            xObjEnc.CCentroCosto = iDr[RegContabDetaEN.CCenCos].ToString();
            xObjEnc.NCentroCosto = iDr[RegContabDetaEN.NCenCos].ToString();
            xObjEnc.CArea = iDr[RegContabDetaEN.CAre].ToString();
            xObjEnc.NArea = iDr[RegContabDetaEN.NAre].ToString();
            xObjEnc.CFlujoCaja = iDr[RegContabDetaEN.CFluCaj].ToString();
            xObjEnc.NFlujoCaja = iDr[RegContabDetaEN.NFluCaj].ToString();
            xObjEnc.CodigoAlmacen = iDr[RegContabDetaEN.CodAlm].ToString();
            xObjEnc.DescripcionAlmacen = iDr[RegContabDetaEN.DesAlm].ToString();
            xObjEnc.CodigoItemAlmacen = iDr[RegContabDetaEN.CodIteAlm].ToString();
            xObjEnc.DescripcionItemAlmacen = iDr[RegContabDetaEN.DesIteAlm].ToString();
            xObjEnc.CantidadItemAlmacen = Convert.ToDecimal(iDr[RegContabDetaEN.CanIteAlm].ToString());
            xObjEnc.CTipoLineaAsiento = iDr[RegContabDetaEN.CTipLinAsi].ToString();
            xObjEnc.CEstadoRegContabDeta = iDr[RegContabDetaEN.CEstRegConDet].ToString();
            xObjEnc.NEstadoRegContabDeta = iDr[RegContabDetaEN.NEstRegConDet].ToString();
            xObjEnc.UsuarioAgrega = iDr[RegContabDetaEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[RegContabDetaEN.FecAgr].ToString());
            xObjEnc.UsuarioModifica = iDr[RegContabDetaEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[RegContabDetaEN.FecMod].ToString());
            xObjEnc.ClaveObjeto = xObjEnc.ClaveRegContabDeta;
            return xObjEnc;
        }

        private List<RegContabDetaEN> ListarObjetos(string pScript)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
            eObjCon.ComandoTexto(pScript);
            IDataReader xIdr = eObjCon.ObtenerIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.eLista.Add(this.Objeto(xIdr));
            }
            eObjCon.Desconectar();
            return eLista;
        }

        private RegContabDetaEN BuscarObjeto(string pScript)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
            eObjCon.ComandoTexto(pScript);
            IDataReader xIdr = eObjCon.ObtenerIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.eObj = this.Objeto(xIdr);
            }
            eObjCon.Desconectar();
            return eObj;
        }

        private bool ExisteObjeto(string pScript)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
            eObjCon.ComandoTexto(pScript);
            IDataReader xIdr = eObjCon.ObtenerIdr();
            bool xResultado = false;
            while (xIdr.Read())
            {
                string xTxt = xIdr["Busqueda"].ToString();
                if (xTxt != string.Empty)
                {
                    xResultado = true;
                }
            }
            eObjCon.Desconectar();
            return xResultado;
        }

        private string ObtenerValor(string pScript)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
            eObjCon.ComandoTexto(pScript);
            string iValor = eObjCon.ObtenerValor();
            eObjCon.Desconectar();
            return iValor;
        }

        #endregion

        #region Metodos publicos

        public bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.eTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.eTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.eTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion2, SqlSelect.Operador.Igual, pValorCondicion2);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public string ObtenerMaximoValorEnColumna(string pColumnaBusqueda)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.eVista, pColumnaBusqueda);
            return this.ObtenerValor(xSel.ObtenerScript());
        }

        public string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.eVista, pColumnaBusqueda);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            return this.ObtenerValor(xSel.ObtenerScript());
        }

        public string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.eVista, pColumnaBusqueda);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion2, SqlSelect.Operador.Igual, pValorCondicion2);
            return this.ObtenerValor(xSel.ObtenerScript());
        }

        public void AdicionarRegContabDeta(List<RegContabDetaEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (RegContabDetaEN xObj in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.eTabla);
                xIns.AsignarParametro(RegContabDetaEN.ClaRegConDet, xObj.ClaveRegContabDeta);
                xIns.AsignarParametro(RegContabDetaEN.CodEmp, xObj.CodigoEmpresa);
                xIns.AsignarParametro(RegContabDetaEN.PerRegConCab, xObj.PeriodoRegContabCabe);
                xIns.AsignarParametro(RegContabDetaEN.COri, xObj.COrigen);
                xIns.AsignarParametro(RegContabDetaEN.CFil, xObj.CFile);
                xIns.AsignarParametro(RegContabDetaEN.CorRegConCab, xObj.CorrelativoRegContabCabe);
                xIns.AsignarParametro(RegContabDetaEN.CorRegConDet, xObj.CorrelativoRegContabDeta);
                xIns.AsignarParametro(RegContabDetaEN.ClaRegConCab, xObj.ClaveRegContabCabe);
                xIns.AsignarParametro(RegContabDetaEN.CodAux, xObj.CodigoAuxiliar);
                xIns.AsignarParametro(RegContabDetaEN.CTipDoc, xObj.CTipoDocumento);
                xIns.AsignarParametro(RegContabDetaEN.SerDoc, xObj.SerieDocumento);
                xIns.AsignarParametro(RegContabDetaEN.NumDoc, xObj.NumeroDocumento);
                xIns.AsignarParametro(RegContabDetaEN.FecDoc, Fecha.ObtenerAnoMesDia(xObj.FechaDocumento));
                xIns.AsignarParametro(RegContabDetaEN.FecVctDoc, Fecha.ObtenerAnoMesDia(xObj.FechaVctoDocumento));
                xIns.AsignarParametro(RegContabDetaEN.CMonDoc, xObj.CMonedaDocumento);
                xIns.AsignarParametro(RegContabDetaEN.VenTipCam, xObj.VentaTipoCambio.ToString());
                xIns.AsignarParametro(RegContabDetaEN.CodCue, xObj.CodigoCuenta);
                xIns.AsignarParametro(RegContabDetaEN.CDebHab, xObj.CDebeHaber);
                xIns.AsignarParametro(RegContabDetaEN.ImpSolRegConDet, xObj.ImporteSolRegContabDeta.ToString());
                xIns.AsignarParametro(RegContabDetaEN.ImpMonRegConDet, xObj.ImporteMonedaRegContabDeta.ToString());
                xIns.AsignarParametro(RegContabDetaEN.GloRegConDet, xObj.GlosaRegContabDeta);
                xIns.AsignarParametro(RegContabDetaEN.CIngEgr, xObj.CIngresoEgreso);
                xIns.AsignarParametro(RegContabDetaEN.CCenCos, xObj.CCentroCosto);
                xIns.AsignarParametro(RegContabDetaEN.CAre, xObj.CArea);
                xIns.AsignarParametro(RegContabDetaEN.CFluCaj, xObj.CFlujoCaja);
                xIns.AsignarParametro(RegContabDetaEN.CodAlm, xObj.CodigoAlmacen);
                xIns.AsignarParametro(RegContabDetaEN.CodIteAlm, xObj.CodigoItemAlmacen);
                xIns.AsignarParametro(RegContabDetaEN.CanIteAlm, xObj.CantidadItemAlmacen.ToString());
                xIns.AsignarParametro(RegContabDetaEN.CTipLinAsi, xObj.CTipoLineaAsiento);
                xIns.AsignarParametro(RegContabDetaEN.CEstRegConDet, xObj.CEstadoRegContabDeta);
                xIns.AsignarParametro(RegContabDetaEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(RegContabDetaEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(RegContabDetaEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(RegContabDetaEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                eObjCon.ComandoTexto(xIns.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void ModificarRegContabDeta(List<RegContabDetaEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (RegContabDetaEN xObj in pLista)
            {
                //armando escript para insertar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.eTabla);
                xUpd.AsignarParametro(RegContabDetaEN.ClaRegConDet, xObj.ClaveRegContabDeta);
                xUpd.AsignarParametro(RegContabDetaEN.CodEmp, xObj.CodigoEmpresa);
                xUpd.AsignarParametro(RegContabDetaEN.PerRegConCab, xObj.PeriodoRegContabCabe);
                xUpd.AsignarParametro(RegContabDetaEN.COri, xObj.COrigen);
                xUpd.AsignarParametro(RegContabDetaEN.CFil, xObj.CFile);
                xUpd.AsignarParametro(RegContabDetaEN.CorRegConCab, xObj.CorrelativoRegContabCabe);
                xUpd.AsignarParametro(RegContabDetaEN.CorRegConDet, xObj.CorrelativoRegContabDeta);
                xUpd.AsignarParametro(RegContabDetaEN.ClaRegConCab, xObj.ClaveRegContabCabe);
                xUpd.AsignarParametro(RegContabDetaEN.CodAux, xObj.CodigoAuxiliar);
                xUpd.AsignarParametro(RegContabDetaEN.CTipDoc, xObj.CTipoDocumento);
                xUpd.AsignarParametro(RegContabDetaEN.SerDoc, xObj.SerieDocumento);
                xUpd.AsignarParametro(RegContabDetaEN.NumDoc, xObj.NumeroDocumento);
                xUpd.AsignarParametro(RegContabDetaEN.FecDoc, Fecha.ObtenerAnoMesDia(xObj.FechaDocumento));
                xUpd.AsignarParametro(RegContabDetaEN.FecVctDoc, Fecha.ObtenerAnoMesDia(xObj.FechaVctoDocumento));
                xUpd.AsignarParametro(RegContabDetaEN.CMonDoc, xObj.CMonedaDocumento);
                xUpd.AsignarParametro(RegContabDetaEN.VenTipCam, xObj.VentaTipoCambio.ToString());
                xUpd.AsignarParametro(RegContabDetaEN.CodCue, xObj.CodigoCuenta);
                xUpd.AsignarParametro(RegContabDetaEN.CDebHab, xObj.CDebeHaber);
                xUpd.AsignarParametro(RegContabDetaEN.ImpSolRegConDet, xObj.ImporteSolRegContabDeta.ToString());
                xUpd.AsignarParametro(RegContabDetaEN.ImpMonRegConDet, xObj.ImporteMonedaRegContabDeta.ToString());
                xUpd.AsignarParametro(RegContabDetaEN.GloRegConDet, xObj.GlosaRegContabDeta);
                xUpd.AsignarParametro(RegContabDetaEN.CIngEgr, xObj.CIngresoEgreso);
                xUpd.AsignarParametro(RegContabDetaEN.CCenCos, xObj.CCentroCosto);
                xUpd.AsignarParametro(RegContabDetaEN.CAre, xObj.CArea);
                xUpd.AsignarParametro(RegContabDetaEN.CFluCaj, xObj.CFlujoCaja);
                xUpd.AsignarParametro(RegContabDetaEN.CodAlm, xObj.CodigoAlmacen);
                xUpd.AsignarParametro(RegContabDetaEN.CodIteAlm, xObj.CodigoItemAlmacen);
                xUpd.AsignarParametro(RegContabDetaEN.CanIteAlm, xObj.CantidadItemAlmacen.ToString());
                xUpd.AsignarParametro(RegContabDetaEN.CTipLinAsi, xObj.CTipoLineaAsiento);
                xUpd.AsignarParametro(RegContabDetaEN.CEstRegConDet, xObj.CEstadoRegContabDeta);
                xUpd.AsignarParametro(RegContabDetaEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(RegContabDetaEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, RegContabDetaEN.ClaRegConDet, SqlSelect.Operador.Igual, xObj.ClaveRegContabDeta);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                eObjCon.ComandoTexto(xUpd.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void EliminarRegContabDeta(List<RegContabDetaEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (RegContabDetaEN xObj in pLista)
            {
                //armando escript para insertar
                SqlDelete xDel = new SqlDelete();
                xDel.Tabla(this.eTabla);

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, RegContabDetaEN.ClaRegConDet, SqlSelect.Operador.Igual, xObj.ClaveRegContabDeta);
                xDel.CondicionDelete(xSel.ObtenerScript());

                eObjCon.ComandoTexto(xDel.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void EliminarRegContabDetasDeClaveRegContabCabe(string pClaveRegContabCabe)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //armando escript para insertar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.eTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RegContabDetaEN.ClaRegConCab, SqlSelect.Operador.Igual, pClaveRegContabCabe);
            xDel.CondicionDelete(xSel.ObtenerScript());

            eObjCon.ComandoTexto(xDel.ObtenerScript());
            eObjCon.EjecutarSinResultado();
            eObjCon.Desconectar();
        }

        public List<RegContabDetaEN> ListarRegContabDeta(RegContabDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RegContabDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public RegContabDetaEN BuscarRegContabDetaXClave(RegContabDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RegContabDetaEN.ClaRegConDet, SqlSelect.Operador.Igual, pObj.ClaveRegContabDeta);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<RegContabDetaEN> ListarRegContabDetaXClaveRegContabCabe(RegContabDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RegContabDetaEN.ClaRegConCab, SqlSelect.Operador.Igual, pObj.ClaveRegContabCabe);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<RegContabDetaEN> ListarRegContabDetaXClaveRegContabCabeYTipoLineaAsiento(RegContabDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RegContabDetaEN.ClaRegConCab, SqlSelect.Operador.Igual, pObj.ClaveRegContabCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RegContabDetaEN.CTipLinAsi, SqlSelect.Operador.Igual, ItemGEN.TipoLineaAsiento_Editado);
            //xSel.CondicionINx(SqlSelect.Reservada.Y, RegContabDetaEN.CTipLinAsi, "'0','1'");
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<RegContabDetaEN> ListarRegContabDetaXClaveRegContabCabeYTipoLineaAsientoCompleto(RegContabDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RegContabDetaEN.ClaRegConCab, SqlSelect.Operador.Igual, pObj.ClaveRegContabCabe);
            //xSel.CondicionCV(SqlSelect.Reservada.Y, RegContabDetaEN.CTipLinAsi, SqlSelect.Operador.Igual, ItemGEN.TipoLineaAsiento_Editado);
            xSel.CondicionINx(SqlSelect.Reservada.Y, RegContabDetaEN.CTipLinAsi, "'0','1'");
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        #endregion

    }
}
