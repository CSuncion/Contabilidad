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

    public class RegContabCabeAD
    {

        #region Atributos

        private SqlDatos eObjCon = new SqlDatos();
        private List<RegContabCabeEN> eLista = new List<RegContabCabeEN>();
        private RegContabCabeEN eObj = new RegContabCabeEN();
        private string eTabla = "RegContabCabe";
        private string eVista = "VsRegContabCabe";

        #endregion

        #region Metodos privados

        private RegContabCabeEN Objeto(IDataReader iDr)
        {
            RegContabCabeEN xObjEnc = new RegContabCabeEN();
            xObjEnc.ClaveRegContabCabe = iDr[RegContabCabeEN.ClaRegConCab].ToString();
            xObjEnc.CodigoEmpresa = iDr[RegContabCabeEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[RegContabCabeEN.NomEmp].ToString();
            xObjEnc.PeriodoRegContabCabe = iDr[RegContabCabeEN.PerRegConCab].ToString();
            xObjEnc.COrigen = iDr[RegContabCabeEN.COri].ToString();
            xObjEnc.NOrigen = iDr[RegContabCabeEN.NOri].ToString();
            xObjEnc.CFile = iDr[RegContabCabeEN.CFil].ToString();
            xObjEnc.NFile = iDr[RegContabCabeEN.NFil].ToString();
            xObjEnc.CorrelativoRegContabCabe = iDr[RegContabCabeEN.CorRegConCab].ToString();
            xObjEnc.FechaRegContabCabe =Fecha.ObtenerDiaMesAno( iDr[RegContabCabeEN.FecRegConCab].ToString());
            xObjEnc.CodigoAuxiliar = iDr[RegContabCabeEN.CodAux].ToString();
            xObjEnc.DescripcionAuxiliar = iDr[RegContabCabeEN.DesAux].ToString();
            xObjEnc.ApellidoPaternoAuxiliar = iDr[RegContabCabeEN.ApePatAux].ToString();
            xObjEnc.ApellidoMaternoAuxiliar = iDr[RegContabCabeEN.ApeMatAux].ToString();
            xObjEnc.PrimerNombreAuxiliar = iDr[RegContabCabeEN.PriNomAux].ToString();
            xObjEnc.SegundoNombreAuxiliar = iDr[RegContabCabeEN.SegNomAux].ToString();
            xObjEnc.CTipoDocumentoAuxiliar = iDr[RegContabCabeEN.CTipDocAux].ToString();
            xObjEnc.FechaInscripcionSnpAuxiliar = iDr[RegContabCabeEN.FecInsSnpAux].ToString();
            xObjEnc.CModoCompra = iDr[RegContabCabeEN.CModCom].ToString();
            xObjEnc.NModoCompra = iDr[RegContabCabeEN.NModCom].ToString();
            xObjEnc.CTipoCompra = iDr[RegContabCabeEN.CTipCom].ToString();
            xObjEnc.NTipoCompra = iDr[RegContabCabeEN.NTipCom].ToString();
            xObjEnc.CTipoDocumento = iDr[RegContabCabeEN.CTipDoc].ToString();
            xObjEnc.NTipoDocumento = iDr[RegContabCabeEN.NTipDoc].ToString();
            xObjEnc.CAplicaDocumentoRef = iDr[RegContabCabeEN.CAplDocRef].ToString();
            xObjEnc.CTipoNota = iDr[RegContabCabeEN.CTipNot].ToString();
            xObjEnc.SerieDocumento = iDr[RegContabCabeEN.SerDoc].ToString();
            xObjEnc.NumeroDocumento = iDr[RegContabCabeEN.NumDoc].ToString();
            xObjEnc.FechaDocumento = Fecha.ObtenerDiaMesAno(iDr[RegContabCabeEN.FecDoc].ToString());
            xObjEnc.FechaVctoDocumento = Fecha.ObtenerDiaMesAno(iDr[RegContabCabeEN.FecVctDoc].ToString());
            xObjEnc.CMonedaDocumento = iDr[RegContabCabeEN.CMonDoc].ToString();
            xObjEnc.NMonedaDocumento = iDr[RegContabCabeEN.NMonDoc].ToString();
            xObjEnc.CTipoDocumentoRef = iDr[RegContabCabeEN.CTipDocRef].ToString();
            xObjEnc.NTipoDocumentoRef = iDr[RegContabCabeEN.NTipDocRef].ToString();
            xObjEnc.SerieDocumentoRef = iDr[RegContabCabeEN.SerDocRef].ToString();
            xObjEnc.NumeroDocumentoRef = iDr[RegContabCabeEN.NumDocRef].ToString();
            xObjEnc.FechaDocumentoRef = Fecha.ObtenerDiaMesAno(iDr[RegContabCabeEN.FecDocRef].ToString());
            xObjEnc.FechaVctoDocumentoRef = Fecha.ObtenerDiaMesAno(iDr[RegContabCabeEN.FecVctDocRef].ToString());
            xObjEnc.CMonedaDocumentoRef = iDr[RegContabCabeEN.CMonDocRef].ToString();
            xObjEnc.NMonedaDocumentoRef = iDr[RegContabCabeEN.NMonDocRef].ToString();
            xObjEnc.VentaTipoCambio = Convert.ToDecimal(iDr[RegContabCabeEN.VenTipCam].ToString());
            xObjEnc.PorcentajeIgv = Convert.ToDecimal(iDr[RegContabCabeEN.PorIgv].ToString());
            xObjEnc.CAplicaIgv = iDr[RegContabCabeEN.CAplIgv].ToString();
            xObjEnc.NAplicaIgv = iDr[RegContabCabeEN.NAplIgv].ToString();
            xObjEnc.CAplicaInafecto = iDr[RegContabCabeEN.CAplIna].ToString();
            xObjEnc.NAplicaInafecto = iDr[RegContabCabeEN.NAplIna].ToString();
            xObjEnc.ValorVentaRegContabCabe = Convert.ToDecimal(iDr[RegContabCabeEN.ValVenRegConCab].ToString());
            xObjEnc.IgvRegContabCabe = Convert.ToDecimal(iDr[RegContabCabeEN.IgvRegConCab].ToString());
            xObjEnc.ExoneradoRegContabCabe = Convert.ToDecimal(iDr[RegContabCabeEN.ExoRegConCab].ToString());
            xObjEnc.InafectoRegContabCabe = Convert.ToDecimal(iDr[RegContabCabeEN.InaRegConCab].ToString());
            xObjEnc.PrecioVentaRegContabCabe = Convert.ToDecimal(iDr[RegContabCabeEN.PreVenRegConCab].ToString());
            xObjEnc.ValorVentaSolRegContabCabe = Convert.ToDecimal(iDr[RegContabCabeEN.ValVenSolRegConCab].ToString());
            xObjEnc.IgvSolRegContabCabe = Convert.ToDecimal(iDr[RegContabCabeEN.IgvSolRegConCab].ToString());
            xObjEnc.ExoneradoSolRegContabCabe = Convert.ToDecimal(iDr[RegContabCabeEN.ExoSolRegConCab].ToString());
            xObjEnc.InafectoSolRegContabCabe = Convert.ToDecimal(iDr[RegContabCabeEN.InaSolRegConCab].ToString());
            xObjEnc.PrecioVentaSolRegContabCabe = Convert.ToDecimal(iDr[RegContabCabeEN.PreVenSolRegConCab].ToString());
            xObjEnc.GlosaRegContabCabe = iDr[RegContabCabeEN.GloRegConCab].ToString();
            xObjEnc.CAplicaDetraccion = iDr[RegContabCabeEN.CAplDet].ToString();
            xObjEnc.NAplicaDetraccion = iDr[RegContabCabeEN.NAplDet].ToString();
            xObjEnc.NumeroPapeletaDetraccion = iDr[RegContabCabeEN.NumPapDet].ToString();
            xObjEnc.FechaDetraccion = Fecha.ObtenerDiaMesAno(iDr[RegContabCabeEN.FecDet].ToString());
            xObjEnc.CodigoCuenta = iDr[RegContabCabeEN.CodCue].ToString();
            xObjEnc.DescripcionCuenta = iDr[RegContabCabeEN.DesCue].ToString();
            xObjEnc.CMonedaCuenta = iDr[RegContabCabeEN.CMonCue].ToString();
            xObjEnc.NMonedaCuenta = iDr[RegContabCabeEN.NMonCue].ToString();
            xObjEnc.NumeroCuentaBanco = iDr[RegContabCabeEN.NumCueBan].ToString();
            xObjEnc.CAplicaRetencion = iDr[RegContabCabeEN.CAplRet].ToString();
            xObjEnc.NAplicaRetencion = iDr[RegContabCabeEN.NAplRet].ToString();
            xObjEnc.TotalHonorario = Convert.ToDecimal(iDr[RegContabCabeEN.TotHon].ToString());
            xObjEnc.RetencionHonorario = Convert.ToDecimal(iDr[RegContabCabeEN.RetHon].ToString());
            xObjEnc.PagoHonorario = Convert.ToDecimal(iDr[RegContabCabeEN.PagHon].ToString());
            xObjEnc.ImporteRegContabCabe = Convert.ToDecimal(iDr[RegContabCabeEN.ImpRegConCab].ToString());
            xObjEnc.ImporteSolRegContabCabe = Convert.ToDecimal(iDr[RegContabCabeEN.ImpSolRegConCab].ToString());
            xObjEnc.CModoPago = iDr[RegContabCabeEN.CModPag].ToString();
            xObjEnc.NModoPago = iDr[RegContabCabeEN.NModPag].ToString();
            xObjEnc.GiradoPagoRegContabCabe = iDr[RegContabCabeEN.GirPagRegConCab].ToString();
            xObjEnc.CartaRegContabCabe = iDr[RegContabCabeEN.CarRegConCab].ToString();
            xObjEnc.ClaveIngresoRegContabCabe = iDr[RegContabCabeEN.ClaIngRegConCab].ToString();
            xObjEnc.CEstadoRegContabCabe = iDr[RegContabCabeEN.CEstRegConCab].ToString();
            xObjEnc.NEstadoRegContabCabe = iDr[RegContabCabeEN.NEstRegConCab].ToString();
            xObjEnc.UsuarioAgrega = iDr[RegContabCabeEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[RegContabCabeEN.FecAgr].ToString());
            xObjEnc.UsuarioModifica = iDr[RegContabCabeEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[RegContabCabeEN.FecMod].ToString());
            xObjEnc.ClaveObjeto = xObjEnc.ClaveRegContabCabe;
            return xObjEnc;
        }

        private List<RegContabCabeEN> ListarObjetos(string pScript)
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

        private RegContabCabeEN BuscarObjeto(string pScript)
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
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RegContabCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            return this.ObtenerValor(xSel.ObtenerScript());
        }

        public string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.eVista, pColumnaBusqueda);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RegContabCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            return this.ObtenerValor(xSel.ObtenerScript());
        }

        public string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.eVista, pColumnaBusqueda);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RegContabCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion2, SqlSelect.Operador.Igual, pValorCondicion2);
            return this.ObtenerValor(xSel.ObtenerScript());
        }

        public void AdicionarRegContabCabe(List<RegContabCabeEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (RegContabCabeEN xObj in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.eTabla);
                xIns.AsignarParametro(RegContabCabeEN.ClaRegConCab, xObj.ClaveRegContabCabe);
                xIns.AsignarParametro(RegContabCabeEN.CodEmp, xObj.CodigoEmpresa);
                xIns.AsignarParametro(RegContabCabeEN.PerRegConCab, xObj.PeriodoRegContabCabe);
                xIns.AsignarParametro(RegContabCabeEN.COri, xObj.COrigen);
                xIns.AsignarParametro(RegContabCabeEN.CFil, xObj.CFile);
                xIns.AsignarParametro(RegContabCabeEN.CorRegConCab, xObj.CorrelativoRegContabCabe);
                xIns.AsignarParametro(RegContabCabeEN.FecRegConCab, Fecha.ObtenerAnoMesDia(xObj.FechaRegContabCabe));
                xIns.AsignarParametro(RegContabCabeEN.CodAux, xObj.CodigoAuxiliar);
                xIns.AsignarParametro(RegContabCabeEN.CModCom, xObj.CModoCompra);
                xIns.AsignarParametro(RegContabCabeEN.CTipCom, xObj.CTipoCompra);
                xIns.AsignarParametro(RegContabCabeEN.CTipDoc, xObj.CTipoDocumento);
                xIns.AsignarParametro(RegContabCabeEN.SerDoc, xObj.SerieDocumento);
                xIns.AsignarParametro(RegContabCabeEN.NumDoc, xObj.NumeroDocumento);
                xIns.AsignarParametro(RegContabCabeEN.FecDoc, Fecha.ObtenerAnoMesDia(xObj.FechaDocumento));
                xIns.AsignarParametro(RegContabCabeEN.FecVctDoc, Fecha.ObtenerAnoMesDia(xObj.FechaVctoDocumento));
                xIns.AsignarParametro(RegContabCabeEN.CMonDoc, xObj.CMonedaDocumento);
                xIns.AsignarParametro(RegContabCabeEN.CTipDocRef, xObj.CTipoDocumentoRef);
                xIns.AsignarParametro(RegContabCabeEN.SerDocRef, xObj.SerieDocumentoRef);
                xIns.AsignarParametro(RegContabCabeEN.NumDocRef, xObj.NumeroDocumentoRef);
                xIns.AsignarParametro(RegContabCabeEN.FecDocRef, Fecha.ObtenerAnoMesDia(xObj.FechaDocumentoRef));
                xIns.AsignarParametro(RegContabCabeEN.FecVctDocRef, Fecha.ObtenerAnoMesDia(xObj.FechaVctoDocumentoRef));
                xIns.AsignarParametro(RegContabCabeEN.CMonDocRef, xObj.CMonedaDocumentoRef);
                xIns.AsignarParametro(RegContabCabeEN.VenTipCam, xObj.VentaTipoCambio.ToString());
                xIns.AsignarParametro(RegContabCabeEN.PorIgv, xObj.PorcentajeIgv.ToString());
                xIns.AsignarParametro(RegContabCabeEN.CAplIgv, xObj.CAplicaIgv);
                xIns.AsignarParametro(RegContabCabeEN.CAplIna, xObj.CAplicaInafecto);
                xIns.AsignarParametro(RegContabCabeEN.ValVenRegConCab, xObj.ValorVentaRegContabCabe.ToString());
                xIns.AsignarParametro(RegContabCabeEN.IgvRegConCab, xObj.IgvRegContabCabe.ToString());
                xIns.AsignarParametro(RegContabCabeEN.ExoRegConCab, xObj.ExoneradoRegContabCabe.ToString());
                xIns.AsignarParametro(RegContabCabeEN.InaRegConCab, xObj.InafectoRegContabCabe.ToString());
                xIns.AsignarParametro(RegContabCabeEN.PreVenRegConCab, xObj.PrecioVentaRegContabCabe.ToString());
                xIns.AsignarParametro(RegContabCabeEN.ValVenSolRegConCab, xObj.ValorVentaSolRegContabCabe.ToString());
                xIns.AsignarParametro(RegContabCabeEN.IgvSolRegConCab, xObj.IgvSolRegContabCabe.ToString());
                xIns.AsignarParametro(RegContabCabeEN.ExoSolRegConCab, xObj.ExoneradoSolRegContabCabe.ToString());
                xIns.AsignarParametro(RegContabCabeEN.InaSolRegConCab, xObj.InafectoSolRegContabCabe.ToString());
                xIns.AsignarParametro(RegContabCabeEN.PreVenSolRegConCab, xObj.PrecioVentaSolRegContabCabe.ToString());
                xIns.AsignarParametro(RegContabCabeEN.GloRegConCab, xObj.GlosaRegContabCabe);
                xIns.AsignarParametro(RegContabCabeEN.CAplDet, xObj.CAplicaDetraccion);
                xIns.AsignarParametro(RegContabCabeEN.NumPapDet, xObj.NumeroPapeletaDetraccion);
                xIns.AsignarParametro(RegContabCabeEN.FecDet, Fecha.ObtenerAnoMesDia(xObj.FechaDetraccion));
                xIns.AsignarParametro(RegContabCabeEN.CodCue, xObj.CodigoCuenta);
                xIns.AsignarParametro(RegContabCabeEN.CAplRet, xObj.CAplicaRetencion);
                xIns.AsignarParametro(RegContabCabeEN.TotHon, xObj.TotalHonorario.ToString());
                xIns.AsignarParametro(RegContabCabeEN.RetHon, xObj.RetencionHonorario.ToString());
                xIns.AsignarParametro(RegContabCabeEN.PagHon, xObj.PagoHonorario.ToString());
                xIns.AsignarParametro(RegContabCabeEN.ImpRegConCab, xObj.ImporteRegContabCabe.ToString());
                xIns.AsignarParametro(RegContabCabeEN.ImpSolRegConCab, xObj.ImporteSolRegContabCabe.ToString());
                xIns.AsignarParametro(RegContabCabeEN.CModPag, xObj.CModoPago);
                xIns.AsignarParametro(RegContabCabeEN.GirPagRegConCab, xObj.GiradoPagoRegContabCabe);
                xIns.AsignarParametro(RegContabCabeEN.CarRegConCab, xObj.CartaRegContabCabe);
                xIns.AsignarParametro(RegContabCabeEN.ClaIngRegConCab, xObj.ClaveIngresoRegContabCabe);
                xIns.AsignarParametro(RegContabCabeEN.CEstRegConCab, xObj.CEstadoRegContabCabe);
                xIns.AsignarParametro(RegContabCabeEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(RegContabCabeEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(RegContabCabeEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(RegContabCabeEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                eObjCon.ComandoTexto(xIns.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void ModificarRegContabCabe(List<RegContabCabeEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (RegContabCabeEN xObj in pLista)
            {
                //armando escript para insertar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.eTabla);
                xUpd.AsignarParametro(RegContabCabeEN.ClaRegConCab, xObj.ClaveRegContabCabe);
                xUpd.AsignarParametro(RegContabCabeEN.CodEmp, xObj.CodigoEmpresa);
                xUpd.AsignarParametro(RegContabCabeEN.PerRegConCab, xObj.PeriodoRegContabCabe);
                xUpd.AsignarParametro(RegContabCabeEN.COri, xObj.COrigen);
                xUpd.AsignarParametro(RegContabCabeEN.CFil, xObj.CFile);
                xUpd.AsignarParametro(RegContabCabeEN.CorRegConCab, xObj.CorrelativoRegContabCabe);
                xUpd.AsignarParametro(RegContabCabeEN.FecRegConCab, Fecha.ObtenerAnoMesDia(xObj.FechaRegContabCabe));
                xUpd.AsignarParametro(RegContabCabeEN.CodAux, xObj.CodigoAuxiliar);
                xUpd.AsignarParametro(RegContabCabeEN.CModCom, xObj.CModoCompra);
                xUpd.AsignarParametro(RegContabCabeEN.CTipCom, xObj.CTipoCompra);
                xUpd.AsignarParametro(RegContabCabeEN.CTipDoc, xObj.CTipoDocumento);
                xUpd.AsignarParametro(RegContabCabeEN.SerDoc, xObj.SerieDocumento);
                xUpd.AsignarParametro(RegContabCabeEN.NumDoc, xObj.NumeroDocumento);
                xUpd.AsignarParametro(RegContabCabeEN.FecDoc, Fecha.ObtenerAnoMesDia(xObj.FechaDocumento));
                xUpd.AsignarParametro(RegContabCabeEN.FecVctDoc, Fecha.ObtenerAnoMesDia(xObj.FechaVctoDocumento));
                xUpd.AsignarParametro(RegContabCabeEN.CMonDoc, xObj.CMonedaDocumento);
                xUpd.AsignarParametro(RegContabCabeEN.CTipDocRef, xObj.CTipoDocumentoRef);
                xUpd.AsignarParametro(RegContabCabeEN.SerDocRef, xObj.SerieDocumentoRef);
                xUpd.AsignarParametro(RegContabCabeEN.NumDocRef, xObj.NumeroDocumentoRef);
                xUpd.AsignarParametro(RegContabCabeEN.FecDocRef, Fecha.ObtenerAnoMesDia(xObj.FechaDocumentoRef));
                xUpd.AsignarParametro(RegContabCabeEN.FecVctDocRef, Fecha.ObtenerAnoMesDia(xObj.FechaVctoDocumentoRef));
                xUpd.AsignarParametro(RegContabCabeEN.CMonDocRef, xObj.CMonedaDocumentoRef);
                xUpd.AsignarParametro(RegContabCabeEN.VenTipCam, xObj.VentaTipoCambio.ToString());
                xUpd.AsignarParametro(RegContabCabeEN.PorIgv, xObj.PorcentajeIgv.ToString());
                xUpd.AsignarParametro(RegContabCabeEN.CAplIgv, xObj.CAplicaIgv);
                xUpd.AsignarParametro(RegContabCabeEN.CAplIna, xObj.CAplicaInafecto);
                xUpd.AsignarParametro(RegContabCabeEN.ValVenRegConCab, xObj.ValorVentaRegContabCabe.ToString());
                xUpd.AsignarParametro(RegContabCabeEN.IgvRegConCab, xObj.IgvRegContabCabe.ToString());
                xUpd.AsignarParametro(RegContabCabeEN.ExoRegConCab, xObj.ExoneradoRegContabCabe.ToString());
                xUpd.AsignarParametro(RegContabCabeEN.InaRegConCab, xObj.InafectoRegContabCabe.ToString());
                xUpd.AsignarParametro(RegContabCabeEN.PreVenRegConCab, xObj.PrecioVentaRegContabCabe.ToString());
                xUpd.AsignarParametro(RegContabCabeEN.ValVenSolRegConCab, xObj.ValorVentaSolRegContabCabe.ToString());
                xUpd.AsignarParametro(RegContabCabeEN.IgvSolRegConCab, xObj.IgvSolRegContabCabe.ToString());
                xUpd.AsignarParametro(RegContabCabeEN.ExoSolRegConCab, xObj.ExoneradoSolRegContabCabe.ToString());
                xUpd.AsignarParametro(RegContabCabeEN.InaSolRegConCab, xObj.InafectoSolRegContabCabe.ToString());
                xUpd.AsignarParametro(RegContabCabeEN.PreVenSolRegConCab, xObj.PrecioVentaSolRegContabCabe.ToString());
                xUpd.AsignarParametro(RegContabCabeEN.GloRegConCab, xObj.GlosaRegContabCabe);
                xUpd.AsignarParametro(RegContabCabeEN.CAplDet, xObj.CAplicaDetraccion);
                xUpd.AsignarParametro(RegContabCabeEN.NumPapDet, xObj.NumeroPapeletaDetraccion);
                xUpd.AsignarParametro(RegContabCabeEN.FecDet, Fecha.ObtenerAnoMesDia(xObj.FechaDetraccion));
                xUpd.AsignarParametro(RegContabCabeEN.CodCue, xObj.CodigoCuenta);
                xUpd.AsignarParametro(RegContabCabeEN.CAplRet, xObj.CAplicaRetencion);
                xUpd.AsignarParametro(RegContabCabeEN.TotHon, xObj.TotalHonorario.ToString());
                xUpd.AsignarParametro(RegContabCabeEN.RetHon, xObj.RetencionHonorario.ToString());
                xUpd.AsignarParametro(RegContabCabeEN.PagHon, xObj.PagoHonorario.ToString());
                xUpd.AsignarParametro(RegContabCabeEN.ImpRegConCab, xObj.ImporteRegContabCabe.ToString());
                xUpd.AsignarParametro(RegContabCabeEN.ImpSolRegConCab, xObj.ImporteSolRegContabCabe.ToString());
                xUpd.AsignarParametro(RegContabCabeEN.CModPag, xObj.CModoPago);
                xUpd.AsignarParametro(RegContabCabeEN.GirPagRegConCab, xObj.GiradoPagoRegContabCabe);
                xUpd.AsignarParametro(RegContabCabeEN.CarRegConCab, xObj.CartaRegContabCabe);
                xUpd.AsignarParametro(RegContabCabeEN.ClaIngRegConCab, xObj.ClaveIngresoRegContabCabe);
                xUpd.AsignarParametro(RegContabCabeEN.CEstRegConCab, xObj.CEstadoRegContabCabe);
                xUpd.AsignarParametro(RegContabCabeEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(RegContabCabeEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, RegContabCabeEN.ClaRegConCab, SqlSelect.Operador.Igual, xObj.ClaveRegContabCabe);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                eObjCon.ComandoTexto(xUpd.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void EliminarRegContabCabe(List<RegContabCabeEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (RegContabCabeEN xObj in pLista)
            {
                //armando escript para insertar
                SqlDelete xDel = new SqlDelete();
                xDel.Tabla(this.eTabla);

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, RegContabCabeEN.ClaRegConCab, SqlSelect.Operador.Igual, xObj.ClaveRegContabCabe);
                xDel.CondicionDelete(xSel.ObtenerScript());

                eObjCon.ComandoTexto(xDel.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public List<RegContabCabeEN> ListarRegContabCabe(RegContabCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RegContabCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public RegContabCabeEN BuscarRegContabCabeXClave(RegContabCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RegContabCabeEN.ClaRegConCab, SqlSelect.Operador.Igual, pObj.ClaveRegContabCabe);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<RegContabCabeEN> ListarRegContabCabeXPeriodoYOrigen(RegContabCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RegContabCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RegContabCabeEN.PerRegConCab, SqlSelect.Operador.Igual, pObj.PeriodoRegContabCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RegContabCabeEN.COri, SqlSelect.Operador.Igual, pObj.COrigen);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public RegContabCabeEN BuscarRegContabCabeXDocumento(RegContabCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RegContabCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RegContabCabeEN.CodAux, SqlSelect.Operador.Igual, pObj.CodigoAuxiliar);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RegContabCabeEN.CTipDoc, SqlSelect.Operador.Igual, pObj.CTipoDocumento);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RegContabCabeEN.SerDoc, SqlSelect.Operador.Igual, pObj.SerieDocumento);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RegContabCabeEN.NumDoc, SqlSelect.Operador.Igual, pObj.NumeroDocumento);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }


        #endregion

    }
}
