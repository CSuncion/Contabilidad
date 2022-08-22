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

    public class SaldoContableAD
    {

        #region Atributos

        private SqlDatos eObjCon = new SqlDatos();
        private List<SaldoContableEN> eLista = new List<SaldoContableEN>();
        private SaldoContableEN eObj = new SaldoContableEN();
        private string eTabla = "SaldoContable";
        private string eVista = "VsSaldoContable";

        #endregion

        #region Metodos privados

        private SaldoContableEN Objeto(IDataReader iDr)
        {
            SaldoContableEN xObjEnc = new SaldoContableEN();
            xObjEnc.ClaveSaldoContable = iDr[SaldoContableEN.ClaSalCon].ToString();
            xObjEnc.CodigoEmpresa = iDr[SaldoContableEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[SaldoContableEN.NomEmp].ToString();
            xObjEnc.AñoSaldoContable = iDr[SaldoContableEN.AñoSalCon].ToString();
            xObjEnc.CodigoCuenta = iDr[SaldoContableEN.CodCue].ToString();
            xObjEnc.DescripcionCuenta = iDr[SaldoContableEN.DesCue].ToString();
            xObjEnc.NumeroDigitosAnalitica = iDr[SaldoContableEN.NumDigAna].ToString();
            xObjEnc.CodigoFormatoContable = iDr[SaldoContableEN.CodForCon].ToString();
            xObjEnc.DescripcionFormatoContable = iDr[SaldoContableEN.DesForCon].ToString();
            xObjEnc.DebeSol00 = Convert.ToDecimal(iDr[SaldoContableEN.DebSol00].ToString());
            xObjEnc.HaberSol00 = Convert.ToDecimal(iDr[SaldoContableEN.HabSol00].ToString());
            xObjEnc.DebeSol01 = Convert.ToDecimal(iDr[SaldoContableEN.DebSol01].ToString());
            xObjEnc.HaberSol01 = Convert.ToDecimal(iDr[SaldoContableEN.HabSol01].ToString());
            xObjEnc.DebeSol02 = Convert.ToDecimal(iDr[SaldoContableEN.DebSol02].ToString());
            xObjEnc.HaberSol02 = Convert.ToDecimal(iDr[SaldoContableEN.HabSol02].ToString());
            xObjEnc.DebeSol03 = Convert.ToDecimal(iDr[SaldoContableEN.DebSol03].ToString());
            xObjEnc.HaberSol03 = Convert.ToDecimal(iDr[SaldoContableEN.HabSol03].ToString());
            xObjEnc.DebeSol04 = Convert.ToDecimal(iDr[SaldoContableEN.DebSol04].ToString());
            xObjEnc.HaberSol04 = Convert.ToDecimal(iDr[SaldoContableEN.HabSol04].ToString());
            xObjEnc.DebeSol05 = Convert.ToDecimal(iDr[SaldoContableEN.DebSol05].ToString());
            xObjEnc.HaberSol05 = Convert.ToDecimal(iDr[SaldoContableEN.HabSol05].ToString());
            xObjEnc.DebeSol06 = Convert.ToDecimal(iDr[SaldoContableEN.DebSol06].ToString());
            xObjEnc.HaberSol06 = Convert.ToDecimal(iDr[SaldoContableEN.HabSol06].ToString());
            xObjEnc.DebeSol07 = Convert.ToDecimal(iDr[SaldoContableEN.DebSol07].ToString());
            xObjEnc.HaberSol07 = Convert.ToDecimal(iDr[SaldoContableEN.HabSol07].ToString());
            xObjEnc.DebeSol08 = Convert.ToDecimal(iDr[SaldoContableEN.DebSol08].ToString());
            xObjEnc.HaberSol08 = Convert.ToDecimal(iDr[SaldoContableEN.HabSol08].ToString());
            xObjEnc.DebeSol09 = Convert.ToDecimal(iDr[SaldoContableEN.DebSol09].ToString());
            xObjEnc.HaberSol09 = Convert.ToDecimal(iDr[SaldoContableEN.HabSol09].ToString());
            xObjEnc.DebeSol10 = Convert.ToDecimal(iDr[SaldoContableEN.DebSol10].ToString());
            xObjEnc.HaberSol10 = Convert.ToDecimal(iDr[SaldoContableEN.HabSol10].ToString());
            xObjEnc.DebeSol11 = Convert.ToDecimal(iDr[SaldoContableEN.DebSol11].ToString());
            xObjEnc.HaberSol11 = Convert.ToDecimal(iDr[SaldoContableEN.HabSol11].ToString());
            xObjEnc.DebeSol12 = Convert.ToDecimal(iDr[SaldoContableEN.DebSol12].ToString());
            xObjEnc.HaberSol12 = Convert.ToDecimal(iDr[SaldoContableEN.HabSol12].ToString());
            xObjEnc.DebeSol13 = Convert.ToDecimal(iDr[SaldoContableEN.DebSol13].ToString());
            xObjEnc.HaberSol13 = Convert.ToDecimal(iDr[SaldoContableEN.HabSol13].ToString());
            xObjEnc.DebeDol00 = Convert.ToDecimal(iDr[SaldoContableEN.DebDol00].ToString());
            xObjEnc.HaberDol00 = Convert.ToDecimal(iDr[SaldoContableEN.HabDol00].ToString());
            xObjEnc.DebeDol01 = Convert.ToDecimal(iDr[SaldoContableEN.DebDol01].ToString());
            xObjEnc.HaberDol01 = Convert.ToDecimal(iDr[SaldoContableEN.HabDol01].ToString());
            xObjEnc.DebeDol02 = Convert.ToDecimal(iDr[SaldoContableEN.DebDol02].ToString());
            xObjEnc.HaberDol02 = Convert.ToDecimal(iDr[SaldoContableEN.HabDol02].ToString());
            xObjEnc.DebeDol03 = Convert.ToDecimal(iDr[SaldoContableEN.DebDol03].ToString());
            xObjEnc.HaberDol03 = Convert.ToDecimal(iDr[SaldoContableEN.HabDol03].ToString());
            xObjEnc.DebeDol04 = Convert.ToDecimal(iDr[SaldoContableEN.DebDol04].ToString());
            xObjEnc.HaberDol04 = Convert.ToDecimal(iDr[SaldoContableEN.HabDol04].ToString());
            xObjEnc.DebeDol05 = Convert.ToDecimal(iDr[SaldoContableEN.DebDol05].ToString());
            xObjEnc.HaberDol05 = Convert.ToDecimal(iDr[SaldoContableEN.HabDol05].ToString());
            xObjEnc.DebeDol06 = Convert.ToDecimal(iDr[SaldoContableEN.DebDol06].ToString());
            xObjEnc.HaberDol06 = Convert.ToDecimal(iDr[SaldoContableEN.HabDol06].ToString());
            xObjEnc.DebeDol07 = Convert.ToDecimal(iDr[SaldoContableEN.DebDol07].ToString());
            xObjEnc.HaberDol07 = Convert.ToDecimal(iDr[SaldoContableEN.HabDol07].ToString());
            xObjEnc.DebeDol08 = Convert.ToDecimal(iDr[SaldoContableEN.DebDol08].ToString());
            xObjEnc.HaberDol08 = Convert.ToDecimal(iDr[SaldoContableEN.HabDol08].ToString());
            xObjEnc.DebeDol09 = Convert.ToDecimal(iDr[SaldoContableEN.DebDol09].ToString());
            xObjEnc.HaberDol09 = Convert.ToDecimal(iDr[SaldoContableEN.HabDol09].ToString());
            xObjEnc.DebeDol10 = Convert.ToDecimal(iDr[SaldoContableEN.DebDol10].ToString());
            xObjEnc.HaberDol10 = Convert.ToDecimal(iDr[SaldoContableEN.HabDol10].ToString());
            xObjEnc.DebeDol11 = Convert.ToDecimal(iDr[SaldoContableEN.DebDol11].ToString());
            xObjEnc.HaberDol11 = Convert.ToDecimal(iDr[SaldoContableEN.HabDol11].ToString());
            xObjEnc.DebeDol12 = Convert.ToDecimal(iDr[SaldoContableEN.DebDol12].ToString());
            xObjEnc.HaberDol12 = Convert.ToDecimal(iDr[SaldoContableEN.HabDol12].ToString());
            xObjEnc.DebeDol13 = Convert.ToDecimal(iDr[SaldoContableEN.DebDol13].ToString());
            xObjEnc.HaberDol13 = Convert.ToDecimal(iDr[SaldoContableEN.HabDol13].ToString());
            xObjEnc.UsuarioAgrega = iDr[SaldoContableEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[SaldoContableEN.FecAgr].ToString());
            xObjEnc.UsuarioModifica = iDr[SaldoContableEN.UsuMod].ToString();
            xObjEnc.FechaModifica = iDr[SaldoContableEN.FecMod].ToString();
            xObjEnc.ClaveObjeto = xObjEnc.ClaveSaldoContable;
            return xObjEnc;
        }

        private List<SaldoContableEN> ListarObjetos(string pScript)
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

        private SaldoContableEN BuscarObjeto(string pScript)
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

        public void AdicionarSaldoContable(List<SaldoContableEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (SaldoContableEN xObj in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.eTabla);
                xIns.AsignarParametro(SaldoContableEN.ClaSalCon, xObj.ClaveSaldoContable);
                xIns.AsignarParametro(SaldoContableEN.CodEmp, xObj.CodigoEmpresa);
                xIns.AsignarParametro(SaldoContableEN.AñoSalCon, xObj.AñoSaldoContable);
                xIns.AsignarParametro(SaldoContableEN.CodCue, xObj.CodigoCuenta);
                xIns.AsignarParametro(SaldoContableEN.DebSol00, xObj.DebeSol00.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabSol00, xObj.HaberSol00.ToString());
                xIns.AsignarParametro(SaldoContableEN.DebSol01, xObj.DebeSol01.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabSol01, xObj.HaberSol01.ToString());
                xIns.AsignarParametro(SaldoContableEN.DebSol02, xObj.DebeSol02.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabSol02, xObj.HaberSol02.ToString());
                xIns.AsignarParametro(SaldoContableEN.DebSol03, xObj.DebeSol03.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabSol03, xObj.HaberSol03.ToString());
                xIns.AsignarParametro(SaldoContableEN.DebSol04, xObj.DebeSol04.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabSol04, xObj.HaberSol04.ToString());
                xIns.AsignarParametro(SaldoContableEN.DebSol05, xObj.DebeSol05.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabSol05, xObj.HaberSol05.ToString());
                xIns.AsignarParametro(SaldoContableEN.DebSol06, xObj.DebeSol06.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabSol06, xObj.HaberSol06.ToString());
                xIns.AsignarParametro(SaldoContableEN.DebSol07, xObj.DebeSol07.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabSol07, xObj.HaberSol07.ToString());
                xIns.AsignarParametro(SaldoContableEN.DebSol08, xObj.DebeSol08.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabSol08, xObj.HaberSol08.ToString());
                xIns.AsignarParametro(SaldoContableEN.DebSol09, xObj.DebeSol09.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabSol09, xObj.HaberSol09.ToString());
                xIns.AsignarParametro(SaldoContableEN.DebSol10, xObj.DebeSol10.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabSol10, xObj.HaberSol10.ToString());
                xIns.AsignarParametro(SaldoContableEN.DebSol11, xObj.DebeSol11.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabSol11, xObj.HaberSol11.ToString());
                xIns.AsignarParametro(SaldoContableEN.DebSol12, xObj.DebeSol12.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabSol12, xObj.HaberSol12.ToString());
                xIns.AsignarParametro(SaldoContableEN.DebSol13, xObj.DebeSol13.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabSol13, xObj.HaberSol13.ToString());
                xIns.AsignarParametro(SaldoContableEN.DebDol00, xObj.DebeDol00.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabDol00, xObj.HaberDol00.ToString());
                xIns.AsignarParametro(SaldoContableEN.DebDol01, xObj.DebeDol01.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabDol01, xObj.HaberDol01.ToString());
                xIns.AsignarParametro(SaldoContableEN.DebDol02, xObj.DebeDol02.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabDol02, xObj.HaberDol02.ToString());
                xIns.AsignarParametro(SaldoContableEN.DebDol03, xObj.DebeDol03.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabDol03, xObj.HaberDol03.ToString());
                xIns.AsignarParametro(SaldoContableEN.DebDol04, xObj.DebeDol04.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabDol04, xObj.HaberDol04.ToString());
                xIns.AsignarParametro(SaldoContableEN.DebDol05, xObj.DebeDol05.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabDol05, xObj.HaberDol05.ToString());
                xIns.AsignarParametro(SaldoContableEN.DebDol06, xObj.DebeDol06.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabDol06, xObj.HaberDol06.ToString());
                xIns.AsignarParametro(SaldoContableEN.DebDol07, xObj.DebeDol07.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabDol07, xObj.HaberDol07.ToString());
                xIns.AsignarParametro(SaldoContableEN.DebDol08, xObj.DebeDol08.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabDol08, xObj.HaberDol08.ToString());
                xIns.AsignarParametro(SaldoContableEN.DebDol09, xObj.DebeDol09.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabDol09, xObj.HaberDol09.ToString());
                xIns.AsignarParametro(SaldoContableEN.DebDol10, xObj.DebeDol10.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabDol10, xObj.HaberDol10.ToString());
                xIns.AsignarParametro(SaldoContableEN.DebDol11, xObj.DebeDol11.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabDol11, xObj.HaberDol11.ToString());
                xIns.AsignarParametro(SaldoContableEN.DebDol12, xObj.DebeDol12.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabDol12, xObj.HaberDol12.ToString());
                xIns.AsignarParametro(SaldoContableEN.DebDol13, xObj.DebeDol13.ToString());
                xIns.AsignarParametro(SaldoContableEN.HabDol13, xObj.HaberDol13.ToString());
                xIns.AsignarParametro(SaldoContableEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(SaldoContableEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(SaldoContableEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(SaldoContableEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                eObjCon.ComandoTexto(xIns.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void ModificarSaldoContable(List<SaldoContableEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (SaldoContableEN xObj in pLista)
            {
                //armando escript para insertar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.eTabla);
                xUpd.AsignarParametro(SaldoContableEN.ClaSalCon, xObj.ClaveSaldoContable);
                xUpd.AsignarParametro(SaldoContableEN.CodEmp, xObj.CodigoEmpresa);
                xUpd.AsignarParametro(SaldoContableEN.AñoSalCon, xObj.AñoSaldoContable);
                xUpd.AsignarParametro(SaldoContableEN.CodCue, xObj.CodigoCuenta);
                xUpd.AsignarParametro(SaldoContableEN.DebSol00, xObj.DebeSol00.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabSol00, xObj.HaberSol00.ToString());
                xUpd.AsignarParametro(SaldoContableEN.DebSol01, xObj.DebeSol01.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabSol01, xObj.HaberSol01.ToString());
                xUpd.AsignarParametro(SaldoContableEN.DebSol02, xObj.DebeSol02.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabSol02, xObj.HaberSol02.ToString());
                xUpd.AsignarParametro(SaldoContableEN.DebSol03, xObj.DebeSol03.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabSol03, xObj.HaberSol03.ToString());
                xUpd.AsignarParametro(SaldoContableEN.DebSol04, xObj.DebeSol04.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabSol04, xObj.HaberSol04.ToString());
                xUpd.AsignarParametro(SaldoContableEN.DebSol05, xObj.DebeSol05.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabSol05, xObj.HaberSol05.ToString());
                xUpd.AsignarParametro(SaldoContableEN.DebSol06, xObj.DebeSol06.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabSol06, xObj.HaberSol06.ToString());
                xUpd.AsignarParametro(SaldoContableEN.DebSol07, xObj.DebeSol07.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabSol07, xObj.HaberSol07.ToString());
                xUpd.AsignarParametro(SaldoContableEN.DebSol08, xObj.DebeSol08.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabSol08, xObj.HaberSol08.ToString());
                xUpd.AsignarParametro(SaldoContableEN.DebSol09, xObj.DebeSol09.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabSol09, xObj.HaberSol09.ToString());
                xUpd.AsignarParametro(SaldoContableEN.DebSol10, xObj.DebeSol10.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabSol10, xObj.HaberSol10.ToString());
                xUpd.AsignarParametro(SaldoContableEN.DebSol11, xObj.DebeSol11.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabSol11, xObj.HaberSol11.ToString());
                xUpd.AsignarParametro(SaldoContableEN.DebSol12, xObj.DebeSol12.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabSol12, xObj.HaberSol12.ToString());
                xUpd.AsignarParametro(SaldoContableEN.DebSol13, xObj.DebeSol13.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabSol13, xObj.HaberSol13.ToString());
                xUpd.AsignarParametro(SaldoContableEN.DebDol00, xObj.DebeDol00.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabDol00, xObj.HaberDol00.ToString());
                xUpd.AsignarParametro(SaldoContableEN.DebDol01, xObj.DebeDol01.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabDol01, xObj.HaberDol01.ToString());
                xUpd.AsignarParametro(SaldoContableEN.DebDol02, xObj.DebeDol02.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabDol02, xObj.HaberDol02.ToString());
                xUpd.AsignarParametro(SaldoContableEN.DebDol03, xObj.DebeDol03.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabDol03, xObj.HaberDol03.ToString());
                xUpd.AsignarParametro(SaldoContableEN.DebDol04, xObj.DebeDol04.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabDol04, xObj.HaberDol04.ToString());
                xUpd.AsignarParametro(SaldoContableEN.DebDol05, xObj.DebeDol05.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabDol05, xObj.HaberDol05.ToString());
                xUpd.AsignarParametro(SaldoContableEN.DebDol06, xObj.DebeDol06.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabDol06, xObj.HaberDol06.ToString());
                xUpd.AsignarParametro(SaldoContableEN.DebDol07, xObj.DebeDol07.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabDol07, xObj.HaberDol07.ToString());
                xUpd.AsignarParametro(SaldoContableEN.DebDol08, xObj.DebeDol08.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabDol08, xObj.HaberDol08.ToString());
                xUpd.AsignarParametro(SaldoContableEN.DebDol09, xObj.DebeDol09.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabDol09, xObj.HaberDol09.ToString());
                xUpd.AsignarParametro(SaldoContableEN.DebDol10, xObj.DebeDol10.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabDol10, xObj.HaberDol10.ToString());
                xUpd.AsignarParametro(SaldoContableEN.DebDol11, xObj.DebeDol11.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabDol11, xObj.HaberDol11.ToString());
                xUpd.AsignarParametro(SaldoContableEN.DebDol12, xObj.DebeDol12.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabDol12, xObj.HaberDol12.ToString());
                xUpd.AsignarParametro(SaldoContableEN.DebDol13, xObj.DebeDol13.ToString());
                xUpd.AsignarParametro(SaldoContableEN.HabDol13, xObj.HaberDol13.ToString());
                xUpd.AsignarParametro(SaldoContableEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(SaldoContableEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, SaldoContableEN.ClaSalCon, SqlSelect.Operador.Igual, xObj.ClaveSaldoContable);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                eObjCon.ComandoTexto(xUpd.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void EliminarSaldoContable(List<SaldoContableEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (SaldoContableEN xObj in pLista)
            {
                //armando escript para insertar
                SqlDelete xDel = new SqlDelete();
                xDel.Tabla(this.eTabla);

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, SaldoContableEN.ClaSalCon, SqlSelect.Operador.Igual, xObj.ClaveSaldoContable);
                xDel.CondicionDelete(xSel.ObtenerScript());

                eObjCon.ComandoTexto(xDel.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public List<SaldoContableEN> ListarSaldoContable(SaldoContableEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SaldoContableEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public SaldoContableEN BuscarSaldoContableXClave(SaldoContableEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SaldoContableEN.ClaSalCon, SqlSelect.Operador.Igual, pObj.ClaveSaldoContable);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        #endregion

    }
}
