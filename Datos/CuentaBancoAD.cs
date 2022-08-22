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

    public class CuentaBancoAD
    {

        #region Atributos

        private SqlDatos eObjCon = new SqlDatos();
        private List<CuentaBancoEN> eLista = new List<CuentaBancoEN>();
        private CuentaBancoEN eObj = new CuentaBancoEN();
        private string eTabla = "CuentaBanco";
        private string eVista = "VsCuentaBanco";

        #endregion

        #region Metodos privados

        private CuentaBancoEN Objeto(IDataReader iDr)
        {
            CuentaBancoEN xObjEnc = new CuentaBancoEN();
            xObjEnc.ClaveCuentaBanco = iDr[CuentaBancoEN.ClaCueBan].ToString();
            xObjEnc.CodigoEmpresa = iDr[CuentaBancoEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[CuentaBancoEN.NomEmp].ToString();
            xObjEnc.CodigoCuentaBanco = iDr[CuentaBancoEN.CodCueBan].ToString();
            xObjEnc.DescripcionCuentaBanco = iDr[CuentaBancoEN.DesCueBan].ToString();
            xObjEnc.CMoneda = iDr[CuentaBancoEN.CMon].ToString();
            xObjEnc.NMoneda = iDr[CuentaBancoEN.NMon].ToString();
            xObjEnc.CodigoBanco = iDr[CuentaBancoEN.CodBan].ToString();
            xObjEnc.NombreBanco = iDr[CuentaBancoEN.NomBan].ToString();
            xObjEnc.NumeroCuentaBanco = iDr[CuentaBancoEN.NumCueBan].ToString();
            xObjEnc.CTipo = iDr[CuentaBancoEN.CTip].ToString();
            xObjEnc.NTipo = iDr[CuentaBancoEN.NTip].ToString();
            xObjEnc.SaldoCuentaBanco = Convert.ToDecimal(iDr[CuentaBancoEN.SalCueBan].ToString());
            xObjEnc.COrigenVentanaCreacion = iDr[CuentaBancoEN.COriVenCre].ToString();
            xObjEnc.NOrigenVentanaCreacion = iDr[CuentaBancoEN.NOriVenCre].ToString();
            xObjEnc.CEstadoCuentaBanco = iDr[CuentaBancoEN.CEstCueBan].ToString();
            xObjEnc.NEstadoCuentaBanco = iDr[CuentaBancoEN.NEstCueBan].ToString();
            xObjEnc.UsuarioAgrega = iDr[CuentaBancoEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[CuentaBancoEN.FecAgr].ToString());
            xObjEnc.UsuarioModifica = iDr[CuentaBancoEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[CuentaBancoEN.FecMod].ToString());
            xObjEnc.ClaveObjeto = xObjEnc.ClaveCuentaBanco;
            return xObjEnc;
        }

        private List<CuentaBancoEN> ListarObjetos(string pScript)
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

        private CuentaBancoEN BuscarObjeto(string pScript)
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

        public void AdicionarCuentaBanco(List<CuentaBancoEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (CuentaBancoEN xObj in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.eTabla);
                xIns.AsignarParametro(CuentaBancoEN.ClaCueBan, xObj.ClaveCuentaBanco);
                xIns.AsignarParametro(CuentaBancoEN.CodEmp, xObj.CodigoEmpresa);
                xIns.AsignarParametro(CuentaBancoEN.CodCueBan, xObj.CodigoCuentaBanco);
                xIns.AsignarParametro(CuentaBancoEN.DesCueBan, xObj.DescripcionCuentaBanco);
                xIns.AsignarParametro(CuentaBancoEN.CMon, xObj.CMoneda);
                xIns.AsignarParametro(CuentaBancoEN.CodBan, xObj.CodigoBanco);
                xIns.AsignarParametro(CuentaBancoEN.NumCueBan, xObj.NumeroCuentaBanco);
                xIns.AsignarParametro(CuentaBancoEN.CTip, xObj.CTipo);
                xIns.AsignarParametro(CuentaBancoEN.SalCueBan, xObj.SaldoCuentaBanco.ToString());
                xIns.AsignarParametro(CuentaBancoEN.COriVenCre, xObj.COrigenVentanaCreacion);
                xIns.AsignarParametro(CuentaBancoEN.CEstCueBan, xObj.CEstadoCuentaBanco);
                xIns.AsignarParametro(CuentaBancoEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(CuentaBancoEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(CuentaBancoEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(CuentaBancoEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                eObjCon.ComandoTexto(xIns.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void ModificarCuentaBanco(List<CuentaBancoEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (CuentaBancoEN xObj in pLista)
            {
                //armando escript para insertar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.eTabla);
                xUpd.AsignarParametro(CuentaBancoEN.ClaCueBan, xObj.ClaveCuentaBanco);
                xUpd.AsignarParametro(CuentaBancoEN.CodEmp, xObj.CodigoEmpresa);
                xUpd.AsignarParametro(CuentaBancoEN.CodCueBan, xObj.CodigoCuentaBanco);
                xUpd.AsignarParametro(CuentaBancoEN.DesCueBan, xObj.DescripcionCuentaBanco);
                xUpd.AsignarParametro(CuentaBancoEN.CMon, xObj.CMoneda);
                xUpd.AsignarParametro(CuentaBancoEN.CodBan, xObj.CodigoBanco);
                xUpd.AsignarParametro(CuentaBancoEN.NumCueBan, xObj.NumeroCuentaBanco);
                xUpd.AsignarParametro(CuentaBancoEN.CTip, xObj.CTipo);
                xUpd.AsignarParametro(CuentaBancoEN.SalCueBan, xObj.SaldoCuentaBanco.ToString());
                xUpd.AsignarParametro(CuentaBancoEN.COriVenCre, xObj.COrigenVentanaCreacion);
                xUpd.AsignarParametro(CuentaBancoEN.CEstCueBan, xObj.CEstadoCuentaBanco);
                xUpd.AsignarParametro(CuentaBancoEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(CuentaBancoEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaBancoEN.ClaCueBan, SqlSelect.Operador.Igual, xObj.ClaveCuentaBanco);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                eObjCon.ComandoTexto(xUpd.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void EliminarCuentaBanco(List<CuentaBancoEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (CuentaBancoEN xObj in pLista)
            {
                //armando escript para insertar
                SqlDelete xDel = new SqlDelete();
                xDel.Tabla(this.eTabla);

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaBancoEN.ClaCueBan, SqlSelect.Operador.Igual, xObj.ClaveCuentaBanco);
                xDel.CondicionDelete(xSel.ObtenerScript());

                eObjCon.ComandoTexto(xDel.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public List<CuentaBancoEN> ListarCuentaBanco(CuentaBancoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaBancoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public CuentaBancoEN BuscarCuentaBancoXClave(CuentaBancoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaBancoEN.ClaCueBan, SqlSelect.Operador.Igual, pObj.ClaveCuentaBanco);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        #endregion

    }
}
