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

namespace Datos
{

    public class SaldoBancoAD
    {

        #region Atributos

        private SqlDatos eObjCon = new SqlDatos();
        private List<SaldoBancoEN> eLista = new List<SaldoBancoEN>();
        private SaldoBancoEN eObj = new SaldoBancoEN();
        private string eTabla = "SaldoBanco";
        private string eVista = "VsSaldoBanco";

        #endregion

        #region Metodos privados

        private SaldoBancoEN Objeto(IDataReader iDr)
        {
            SaldoBancoEN xObjEnc = new SaldoBancoEN();
            xObjEnc.ClaveSaldoBanco = iDr[SaldoBancoEN.ClaSalBan].ToString();
            xObjEnc.CodigoEmpresa = iDr[SaldoBancoEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[SaldoBancoEN.NomEmp].ToString();
            xObjEnc.AñoSaldoBanco = iDr[SaldoBancoEN.AñoSalBan].ToString();
            xObjEnc.CodigoCuentaBanco = iDr[SaldoBancoEN.CodCueBan].ToString();
            xObjEnc.DescripcionCuentaBanco = iDr[SaldoBancoEN.DesCueBan].ToString();
            xObjEnc.NumeroCuentaBanco = iDr[SaldoBancoEN.NumCueBan].ToString();
            xObjEnc.CMoneda = iDr[SaldoBancoEN.CMon].ToString();
            xObjEnc.NMoneda = iDr[SaldoBancoEN.NMon].ToString();
            xObjEnc.IngresoSol00 = Convert.ToDecimal(iDr[SaldoBancoEN.IngSol00].ToString());
            xObjEnc.SalidaSol00 = Convert.ToDecimal(iDr[SaldoBancoEN.SalSol00].ToString());
            xObjEnc.SaldoSol00 = Convert.ToDecimal(iDr[SaldoBancoEN.SaldSol00].ToString());
            xObjEnc.IngresoSol01 = Convert.ToDecimal(iDr[SaldoBancoEN.IngSol01].ToString());
            xObjEnc.SalidaSol01 = Convert.ToDecimal(iDr[SaldoBancoEN.SalSol01].ToString());
            xObjEnc.SaldoSol01 = Convert.ToDecimal(iDr[SaldoBancoEN.SaldSol01].ToString());
            xObjEnc.IngresoSol02 = Convert.ToDecimal(iDr[SaldoBancoEN.IngSol02].ToString());
            xObjEnc.SalidaSol02 = Convert.ToDecimal(iDr[SaldoBancoEN.SalSol02].ToString());
            xObjEnc.SaldoSol02 = Convert.ToDecimal(iDr[SaldoBancoEN.SaldSol02].ToString());
            xObjEnc.IngresoSol03 = Convert.ToDecimal(iDr[SaldoBancoEN.IngSol03].ToString());
            xObjEnc.SalidaSol03 = Convert.ToDecimal(iDr[SaldoBancoEN.SalSol03].ToString());
            xObjEnc.SaldoSol03 = Convert.ToDecimal(iDr[SaldoBancoEN.SaldSol03].ToString());
            xObjEnc.IngresoSol04 = Convert.ToDecimal(iDr[SaldoBancoEN.IngSol04].ToString());
            xObjEnc.SalidaSol04 = Convert.ToDecimal(iDr[SaldoBancoEN.SalSol04].ToString());
            xObjEnc.SaldoSol04 = Convert.ToDecimal(iDr[SaldoBancoEN.SaldSol04].ToString());
            xObjEnc.IngresoSol05 = Convert.ToDecimal(iDr[SaldoBancoEN.IngSol05].ToString());
            xObjEnc.SalidaSol05 = Convert.ToDecimal(iDr[SaldoBancoEN.SalSol05].ToString());
            xObjEnc.SaldoSol05 = Convert.ToDecimal(iDr[SaldoBancoEN.SaldSol05].ToString());
            xObjEnc.IngresoSol06 = Convert.ToDecimal(iDr[SaldoBancoEN.IngSol06].ToString());
            xObjEnc.SalidaSol06 = Convert.ToDecimal(iDr[SaldoBancoEN.SalSol06].ToString());
            xObjEnc.SaldoSol06 = Convert.ToDecimal(iDr[SaldoBancoEN.SaldSol06].ToString());
            xObjEnc.IngresoSol07 = Convert.ToDecimal(iDr[SaldoBancoEN.IngSol07].ToString());
            xObjEnc.SalidaSol07 = Convert.ToDecimal(iDr[SaldoBancoEN.SalSol07].ToString());
            xObjEnc.SaldoSol07 = Convert.ToDecimal(iDr[SaldoBancoEN.SaldSol07].ToString());
            xObjEnc.IngresoSol08 = Convert.ToDecimal(iDr[SaldoBancoEN.IngSol08].ToString());
            xObjEnc.SalidaSol08 = Convert.ToDecimal(iDr[SaldoBancoEN.SalSol08].ToString());
            xObjEnc.SaldoSol08 = Convert.ToDecimal(iDr[SaldoBancoEN.SaldSol08].ToString());
            xObjEnc.IngresoSol09 = Convert.ToDecimal(iDr[SaldoBancoEN.IngSol09].ToString());
            xObjEnc.SalidaSol09 = Convert.ToDecimal(iDr[SaldoBancoEN.SalSol09].ToString());
            xObjEnc.SaldoSol09 = Convert.ToDecimal(iDr[SaldoBancoEN.SaldSol09].ToString());
            xObjEnc.IngresoSol10 = Convert.ToDecimal(iDr[SaldoBancoEN.IngSol10].ToString());
            xObjEnc.SalidaSol10 = Convert.ToDecimal(iDr[SaldoBancoEN.SalSol10].ToString());
            xObjEnc.SaldoSol10 = Convert.ToDecimal(iDr[SaldoBancoEN.SaldSol10].ToString());
            xObjEnc.IngresoSol11 = Convert.ToDecimal(iDr[SaldoBancoEN.IngSol11].ToString());
            xObjEnc.SalidaSol11 = Convert.ToDecimal(iDr[SaldoBancoEN.SalSol11].ToString());
            xObjEnc.SaldoSol11 = Convert.ToDecimal(iDr[SaldoBancoEN.SaldSol11].ToString());
            xObjEnc.IngresoSol12 = Convert.ToDecimal(iDr[SaldoBancoEN.IngSol12].ToString());
            xObjEnc.SalidaSol12 = Convert.ToDecimal(iDr[SaldoBancoEN.SalSol12].ToString());
            xObjEnc.SaldoSol12 = Convert.ToDecimal(iDr[SaldoBancoEN.SaldSol12].ToString());
            xObjEnc.IngresoDol00 = Convert.ToDecimal(iDr[SaldoBancoEN.IngDol00].ToString());
            xObjEnc.SalidaDol00 = Convert.ToDecimal(iDr[SaldoBancoEN.SalDol00].ToString());
            xObjEnc.SaldoDol00 = Convert.ToDecimal(iDr[SaldoBancoEN.SaldDol00].ToString());
            xObjEnc.IngresoDol01 = Convert.ToDecimal(iDr[SaldoBancoEN.IngDol01].ToString());
            xObjEnc.SalidaDol01 = Convert.ToDecimal(iDr[SaldoBancoEN.SalDol01].ToString());
            xObjEnc.SaldoDol01 = Convert.ToDecimal(iDr[SaldoBancoEN.SaldDol01].ToString());
            xObjEnc.IngresoDol02 = Convert.ToDecimal(iDr[SaldoBancoEN.IngDol02].ToString());
            xObjEnc.SalidaDol02 = Convert.ToDecimal(iDr[SaldoBancoEN.SalDol02].ToString());
            xObjEnc.SaldoDol02 = Convert.ToDecimal(iDr[SaldoBancoEN.SaldDol02].ToString());
            xObjEnc.IngresoDol03 = Convert.ToDecimal(iDr[SaldoBancoEN.IngDol03].ToString());
            xObjEnc.SalidaDol03 = Convert.ToDecimal(iDr[SaldoBancoEN.SalDol03].ToString());
            xObjEnc.SaldoDol03 = Convert.ToDecimal(iDr[SaldoBancoEN.SaldDol03].ToString());
            xObjEnc.IngresoDol04 = Convert.ToDecimal(iDr[SaldoBancoEN.IngDol04].ToString());
            xObjEnc.SalidaDol04 = Convert.ToDecimal(iDr[SaldoBancoEN.SalDol04].ToString());
            xObjEnc.SaldoDol04 = Convert.ToDecimal(iDr[SaldoBancoEN.SaldDol04].ToString());
            xObjEnc.IngresoDol05 = Convert.ToDecimal(iDr[SaldoBancoEN.IngDol05].ToString());
            xObjEnc.SalidaDol05 = Convert.ToDecimal(iDr[SaldoBancoEN.SalDol05].ToString());
            xObjEnc.SaldoDol05 = Convert.ToDecimal(iDr[SaldoBancoEN.SaldDol05].ToString());
            xObjEnc.IngresoDol06 = Convert.ToDecimal(iDr[SaldoBancoEN.IngDol06].ToString());
            xObjEnc.SalidaDol06 = Convert.ToDecimal(iDr[SaldoBancoEN.SalDol06].ToString());
            xObjEnc.SaldoDol06 = Convert.ToDecimal(iDr[SaldoBancoEN.SaldDol06].ToString());
            xObjEnc.IngresoDol07 = Convert.ToDecimal(iDr[SaldoBancoEN.IngDol07].ToString());
            xObjEnc.SalidaDol07 = Convert.ToDecimal(iDr[SaldoBancoEN.SalDol07].ToString());
            xObjEnc.SaldoDol07 = Convert.ToDecimal(iDr[SaldoBancoEN.SaldDol07].ToString());
            xObjEnc.IngresoDol08 = Convert.ToDecimal(iDr[SaldoBancoEN.IngDol08].ToString());
            xObjEnc.SalidaDol08 = Convert.ToDecimal(iDr[SaldoBancoEN.SalDol08].ToString());
            xObjEnc.SaldoDol08 = Convert.ToDecimal(iDr[SaldoBancoEN.SaldDol08].ToString());
            xObjEnc.IngresoDol09 = Convert.ToDecimal(iDr[SaldoBancoEN.IngDol09].ToString());
            xObjEnc.SalidaDol09 = Convert.ToDecimal(iDr[SaldoBancoEN.SalDol09].ToString());
            xObjEnc.SaldoDol09 = Convert.ToDecimal(iDr[SaldoBancoEN.SaldDol09].ToString());
            xObjEnc.IngresoDol10 = Convert.ToDecimal(iDr[SaldoBancoEN.IngDol10].ToString());
            xObjEnc.SalidaDol10 = Convert.ToDecimal(iDr[SaldoBancoEN.SalDol10].ToString());
            xObjEnc.SaldoDol10 = Convert.ToDecimal(iDr[SaldoBancoEN.SaldDol10].ToString());
            xObjEnc.IngresoDol11 = Convert.ToDecimal(iDr[SaldoBancoEN.IngDol11].ToString());
            xObjEnc.SalidaDol11 = Convert.ToDecimal(iDr[SaldoBancoEN.SalDol11].ToString());
            xObjEnc.SaldoDol11 = Convert.ToDecimal(iDr[SaldoBancoEN.SaldDol11].ToString());
            xObjEnc.IngresoDol12 = Convert.ToDecimal(iDr[SaldoBancoEN.IngDol12].ToString());
            xObjEnc.SalidaDol12 = Convert.ToDecimal(iDr[SaldoBancoEN.SalDol12].ToString());
            xObjEnc.SaldoDol12 = Convert.ToDecimal(iDr[SaldoBancoEN.SaldDol12].ToString());
            xObjEnc.UsuarioAgrega = iDr[SaldoBancoEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[SaldoBancoEN.FecAgr].ToString());
            xObjEnc.UsuarioModifica = iDr[SaldoBancoEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[SaldoBancoEN.FecMod].ToString());
            xObjEnc.ClaveObjeto = xObjEnc.ClaveSaldoBanco;
            return xObjEnc;
        }

        private List<SaldoBancoEN> ListarObjetos(string pScript)
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

        private SaldoBancoEN BuscarObjeto(string pScript)
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

        public void AdicionarSaldoBanco(List<SaldoBancoEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (SaldoBancoEN xObj in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.eTabla);
                xIns.AsignarParametro(SaldoBancoEN.ClaSalBan, xObj.ClaveSaldoBanco);
                xIns.AsignarParametro(SaldoBancoEN.CodEmp, xObj.CodigoEmpresa);
                xIns.AsignarParametro(SaldoBancoEN.AñoSalBan, xObj.AñoSaldoBanco);
                xIns.AsignarParametro(SaldoBancoEN.CodCueBan, xObj.CodigoCuentaBanco);
                xIns.AsignarParametro(SaldoBancoEN.CMon, xObj.CMoneda);
                xIns.AsignarParametro(SaldoBancoEN.IngSol00, xObj.IngresoSol00.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SalSol00, xObj.SalidaSol00.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SaldSol00, xObj.SaldoSol00.ToString());
                xIns.AsignarParametro(SaldoBancoEN.IngSol01, xObj.IngresoSol01.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SalSol01, xObj.SalidaSol01.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SaldSol01, xObj.SaldoSol01.ToString());
                xIns.AsignarParametro(SaldoBancoEN.IngSol02, xObj.IngresoSol02.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SalSol02, xObj.SalidaSol02.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SaldSol02, xObj.SaldoSol02.ToString());
                xIns.AsignarParametro(SaldoBancoEN.IngSol03, xObj.IngresoSol03.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SalSol03, xObj.SalidaSol03.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SaldSol03, xObj.SaldoSol03.ToString());
                xIns.AsignarParametro(SaldoBancoEN.IngSol04, xObj.IngresoSol04.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SalSol04, xObj.SalidaSol04.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SaldSol04, xObj.SaldoSol04.ToString());
                xIns.AsignarParametro(SaldoBancoEN.IngSol05, xObj.IngresoSol05.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SalSol05, xObj.SalidaSol05.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SaldSol05, xObj.SaldoSol05.ToString());
                xIns.AsignarParametro(SaldoBancoEN.IngSol06, xObj.IngresoSol06.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SalSol06, xObj.SalidaSol06.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SaldSol06, xObj.SaldoSol06.ToString());
                xIns.AsignarParametro(SaldoBancoEN.IngSol07, xObj.IngresoSol07.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SalSol07, xObj.SalidaSol07.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SaldSol07, xObj.SaldoSol07.ToString());
                xIns.AsignarParametro(SaldoBancoEN.IngSol08, xObj.IngresoSol08.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SalSol08, xObj.SalidaSol08.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SaldSol08, xObj.SaldoSol08.ToString());
                xIns.AsignarParametro(SaldoBancoEN.IngSol09, xObj.IngresoSol09.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SalSol09, xObj.SalidaSol09.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SaldSol09, xObj.SaldoSol09.ToString());
                xIns.AsignarParametro(SaldoBancoEN.IngSol10, xObj.IngresoSol10.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SalSol10, xObj.SalidaSol10.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SaldSol10, xObj.SaldoSol10.ToString());
                xIns.AsignarParametro(SaldoBancoEN.IngSol11, xObj.IngresoSol11.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SalSol11, xObj.SalidaSol11.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SaldSol11, xObj.SaldoSol11.ToString());
                xIns.AsignarParametro(SaldoBancoEN.IngSol12, xObj.IngresoSol12.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SalSol12, xObj.SalidaSol12.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SaldSol12, xObj.SaldoSol12.ToString());
                xIns.AsignarParametro(SaldoBancoEN.IngDol00, xObj.IngresoDol00.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SalDol00, xObj.SalidaDol00.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SaldDol00, xObj.SaldoDol00.ToString());
                xIns.AsignarParametro(SaldoBancoEN.IngDol01, xObj.IngresoDol01.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SalDol01, xObj.SalidaDol01.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SaldDol01, xObj.SaldoDol01.ToString());
                xIns.AsignarParametro(SaldoBancoEN.IngDol02, xObj.IngresoDol02.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SalDol02, xObj.SalidaDol02.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SaldDol02, xObj.SaldoDol02.ToString());
                xIns.AsignarParametro(SaldoBancoEN.IngDol03, xObj.IngresoDol03.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SalDol03, xObj.SalidaDol03.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SaldDol03, xObj.SaldoDol03.ToString());
                xIns.AsignarParametro(SaldoBancoEN.IngDol04, xObj.IngresoDol04.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SalDol04, xObj.SalidaDol04.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SaldDol04, xObj.SaldoDol04.ToString());
                xIns.AsignarParametro(SaldoBancoEN.IngDol05, xObj.IngresoDol05.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SalDol05, xObj.SalidaDol05.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SaldDol05, xObj.SaldoDol05.ToString());
                xIns.AsignarParametro(SaldoBancoEN.IngDol06, xObj.IngresoDol06.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SalDol06, xObj.SalidaDol06.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SaldDol06, xObj.SaldoDol06.ToString());
                xIns.AsignarParametro(SaldoBancoEN.IngDol07, xObj.IngresoDol07.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SalDol07, xObj.SalidaDol07.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SaldDol07, xObj.SaldoDol07.ToString());
                xIns.AsignarParametro(SaldoBancoEN.IngDol08, xObj.IngresoDol08.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SalDol08, xObj.SalidaDol08.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SaldDol08, xObj.SaldoDol08.ToString());
                xIns.AsignarParametro(SaldoBancoEN.IngDol09, xObj.IngresoDol09.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SalDol09, xObj.SalidaDol09.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SaldDol09, xObj.SaldoDol09.ToString());
                xIns.AsignarParametro(SaldoBancoEN.IngDol10, xObj.IngresoDol10.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SalDol10, xObj.SalidaDol10.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SaldDol10, xObj.SaldoDol10.ToString());
                xIns.AsignarParametro(SaldoBancoEN.IngDol11, xObj.IngresoDol11.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SalDol11, xObj.SalidaDol11.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SaldDol11, xObj.SaldoDol11.ToString());
                xIns.AsignarParametro(SaldoBancoEN.IngDol12, xObj.IngresoDol12.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SalDol12, xObj.SalidaDol12.ToString());
                xIns.AsignarParametro(SaldoBancoEN.SaldDol12, xObj.SaldoDol12.ToString());
                xIns.AsignarParametro(SaldoBancoEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(SaldoBancoEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(SaldoBancoEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(SaldoBancoEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                eObjCon.ComandoTexto(xIns.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void ModificarSaldoBanco(List<SaldoBancoEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (SaldoBancoEN xObj in pLista)
            {
                //armando escript para insertar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.eTabla);
                xUpd.AsignarParametro(SaldoBancoEN.ClaSalBan, xObj.ClaveSaldoBanco);
                xUpd.AsignarParametro(SaldoBancoEN.CodEmp, xObj.CodigoEmpresa);
                xUpd.AsignarParametro(SaldoBancoEN.AñoSalBan, xObj.AñoSaldoBanco);
                xUpd.AsignarParametro(SaldoBancoEN.CodCueBan, xObj.CodigoCuentaBanco);
                xUpd.AsignarParametro(SaldoBancoEN.CMon, xObj.CMoneda);
                xUpd.AsignarParametro(SaldoBancoEN.IngSol00, xObj.IngresoSol00.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SalSol00, xObj.SalidaSol00.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SaldSol00, xObj.SaldoSol00.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.IngSol01, xObj.IngresoSol01.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SalSol01, xObj.SalidaSol01.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SaldSol01, xObj.SaldoSol01.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.IngSol02, xObj.IngresoSol02.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SalSol02, xObj.SalidaSol02.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SaldSol02, xObj.SaldoSol02.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.IngSol03, xObj.IngresoSol03.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SalSol03, xObj.SalidaSol03.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SaldSol03, xObj.SaldoSol03.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.IngSol04, xObj.IngresoSol04.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SalSol04, xObj.SalidaSol04.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SaldSol04, xObj.SaldoSol04.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.IngSol05, xObj.IngresoSol05.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SalSol05, xObj.SalidaSol05.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SaldSol05, xObj.SaldoSol05.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.IngSol06, xObj.IngresoSol06.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SalSol06, xObj.SalidaSol06.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SaldSol06, xObj.SaldoSol06.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.IngSol07, xObj.IngresoSol07.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SalSol07, xObj.SalidaSol07.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SaldSol07, xObj.SaldoSol07.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.IngSol08, xObj.IngresoSol08.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SalSol08, xObj.SalidaSol08.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SaldSol08, xObj.SaldoSol08.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.IngSol09, xObj.IngresoSol09.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SalSol09, xObj.SalidaSol09.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SaldSol09, xObj.SaldoSol09.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.IngSol10, xObj.IngresoSol10.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SalSol10, xObj.SalidaSol10.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SaldSol10, xObj.SaldoSol10.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.IngSol11, xObj.IngresoSol11.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SalSol11, xObj.SalidaSol11.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SaldSol11, xObj.SaldoSol11.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.IngSol12, xObj.IngresoSol12.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SalSol12, xObj.SalidaSol12.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SaldSol12, xObj.SaldoSol12.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.IngDol00, xObj.IngresoDol00.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SalDol00, xObj.SalidaDol00.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SaldDol00, xObj.SaldoDol00.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.IngDol01, xObj.IngresoDol01.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SalDol01, xObj.SalidaDol01.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SaldDol01, xObj.SaldoDol01.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.IngDol02, xObj.IngresoDol02.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SalDol02, xObj.SalidaDol02.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SaldDol02, xObj.SaldoDol02.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.IngDol03, xObj.IngresoDol03.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SalDol03, xObj.SalidaDol03.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SaldDol03, xObj.SaldoDol03.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.IngDol04, xObj.IngresoDol04.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SalDol04, xObj.SalidaDol04.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SaldDol04, xObj.SaldoDol04.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.IngDol05, xObj.IngresoDol05.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SalDol05, xObj.SalidaDol05.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SaldDol05, xObj.SaldoDol05.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.IngDol06, xObj.IngresoDol06.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SalDol06, xObj.SalidaDol06.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SaldDol06, xObj.SaldoDol06.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.IngDol07, xObj.IngresoDol07.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SalDol07, xObj.SalidaDol07.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SaldDol07, xObj.SaldoDol07.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.IngDol08, xObj.IngresoDol08.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SalDol08, xObj.SalidaDol08.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SaldDol08, xObj.SaldoDol08.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.IngDol09, xObj.IngresoDol09.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SalDol09, xObj.SalidaDol09.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SaldDol09, xObj.SaldoDol09.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.IngDol10, xObj.IngresoDol10.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SalDol10, xObj.SalidaDol10.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SaldDol10, xObj.SaldoDol10.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.IngDol11, xObj.IngresoDol11.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SalDol11, xObj.SalidaDol11.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SaldDol11, xObj.SaldoDol11.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.IngDol12, xObj.IngresoDol12.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SalDol12, xObj.SalidaDol12.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.SaldDol12, xObj.SaldoDol12.ToString());
                xUpd.AsignarParametro(SaldoBancoEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(SaldoBancoEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, SaldoBancoEN.ClaSalBan, SqlSelect.Operador.Igual, xObj.ClaveSaldoBanco);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                eObjCon.ComandoTexto(xUpd.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void EliminarSaldoBanco(List<SaldoBancoEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (SaldoBancoEN xObj in pLista)
            {
                //armando escript para insertar
                SqlDelete xDel = new SqlDelete();
                xDel.Tabla(this.eTabla);

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, SaldoBancoEN.ClaSalBan, SqlSelect.Operador.Igual, xObj.ClaveSaldoBanco);
                xDel.CondicionDelete(xSel.ObtenerScript());

                eObjCon.ComandoTexto(xDel.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public List<SaldoBancoEN> ListarSaldoBanco(SaldoBancoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SaldoBancoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public SaldoBancoEN BuscarSaldoBancoXClave(SaldoBancoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SaldoBancoEN.ClaSalBan, SqlSelect.Operador.Igual, pObj.ClaveSaldoBanco);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        #endregion

    }
}
