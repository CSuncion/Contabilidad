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

    public class FormatoContableAD
    {

        #region Atributos

        private SqlDatos eObjCon = new SqlDatos();
        private List<FormatoContableEN> eLista = new List<FormatoContableEN>();
        private FormatoContableEN eObj = new FormatoContableEN();
        private string eTabla = "FormatoContable";
        private string eVista = "VsFormatoContable";

        #endregion

        #region Metodos privados

        private FormatoContableEN Objeto(IDataReader iDr)
        {
            FormatoContableEN xObjEnc = new FormatoContableEN();
            xObjEnc.ClaveFormatoContable = iDr[FormatoContableEN.ClaForCon].ToString();
            xObjEnc.CodigoEmpresa = iDr[FormatoContableEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[FormatoContableEN.NomEmp].ToString();
            xObjEnc.CodigoFormatoContable = iDr[FormatoContableEN.CodForCon].ToString();
            xObjEnc.DescripcionFormatoContable = iDr[FormatoContableEN.DesForCon].ToString();
            xObjEnc.DescripcionAlternaFormatoContable = iDr[FormatoContableEN.DesAltForCon].ToString();
            xObjEnc.CGrupo = iDr[FormatoContableEN.CGru].ToString();
            xObjEnc.NGrupo = iDr[FormatoContableEN.NGru].ToString();
            xObjEnc.CNaturaleza = iDr[FormatoContableEN.CNat].ToString();
            xObjEnc.NNaturaleza = iDr[FormatoContableEN.NNat].ToString();
            xObjEnc.COrigenVentanaCreacion = iDr[FormatoContableEN.COriVenCre].ToString();
            xObjEnc.NOrigenVentanaCreacion = iDr[FormatoContableEN.NOriVenCre].ToString();
            xObjEnc.CEstadoFormatoContable = iDr[FormatoContableEN.CEstForCon].ToString();
            xObjEnc.NEstadoFormatoContable = iDr[FormatoContableEN.NEstForCon].ToString();
            xObjEnc.UsuarioAgrega = iDr[FormatoContableEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[FormatoContableEN.FecAgr].ToString());
            xObjEnc.UsuarioModifica = iDr[FormatoContableEN.UsuMod].ToString();
            xObjEnc.FechaModifica = iDr[FormatoContableEN.FecMod].ToString();
            xObjEnc.ClaveObjeto = xObjEnc.ClaveFormatoContable;
            return xObjEnc;
        }

        private List<FormatoContableEN> ListarObjetos(string pScript)
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

        private FormatoContableEN BuscarObjeto(string pScript)
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

        public void AdicionarFormatoContable(List<FormatoContableEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (FormatoContableEN xObj in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.eTabla);
                xIns.AsignarParametro(FormatoContableEN.ClaForCon, xObj.ClaveFormatoContable);
                xIns.AsignarParametro(FormatoContableEN.CodEmp, xObj.CodigoEmpresa);
                xIns.AsignarParametro(FormatoContableEN.CodForCon, xObj.CodigoFormatoContable);
                xIns.AsignarParametro(FormatoContableEN.DesForCon, xObj.DescripcionFormatoContable);
                xIns.AsignarParametro(FormatoContableEN.DesAltForCon, xObj.DescripcionAlternaFormatoContable);
                xIns.AsignarParametro(FormatoContableEN.CGru, xObj.CGrupo);
                xIns.AsignarParametro(FormatoContableEN.CNat, xObj.CNaturaleza);
                xIns.AsignarParametro(FormatoContableEN.COriVenCre, xObj.COrigenVentanaCreacion);
                xIns.AsignarParametro(FormatoContableEN.CEstForCon, xObj.CEstadoFormatoContable);
                xIns.AsignarParametro(FormatoContableEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(FormatoContableEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(FormatoContableEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(FormatoContableEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                eObjCon.ComandoTexto(xIns.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void ModificarFormatoContable(List<FormatoContableEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (FormatoContableEN xObj in pLista)
            {
                //armando escript para insertar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.eTabla);
                xUpd.AsignarParametro(FormatoContableEN.ClaForCon, xObj.ClaveFormatoContable);
                xUpd.AsignarParametro(FormatoContableEN.CodEmp, xObj.CodigoEmpresa);
                xUpd.AsignarParametro(FormatoContableEN.CodForCon, xObj.CodigoFormatoContable);
                xUpd.AsignarParametro(FormatoContableEN.DesForCon, xObj.DescripcionFormatoContable);
                xUpd.AsignarParametro(FormatoContableEN.DesAltForCon, xObj.DescripcionAlternaFormatoContable);
                xUpd.AsignarParametro(FormatoContableEN.CGru, xObj.CGrupo);
                xUpd.AsignarParametro(FormatoContableEN.CNat, xObj.CNaturaleza);
                xUpd.AsignarParametro(FormatoContableEN.COriVenCre, xObj.COrigenVentanaCreacion);
                xUpd.AsignarParametro(FormatoContableEN.CEstForCon, xObj.CEstadoFormatoContable);
                xUpd.AsignarParametro(FormatoContableEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(FormatoContableEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormatoContableEN.ClaForCon, SqlSelect.Operador.Igual, xObj.ClaveFormatoContable);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                eObjCon.ComandoTexto(xUpd.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void EliminarFormatoContable(List<FormatoContableEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (FormatoContableEN xObj in pLista)
            {
                //armando escript para insertar
                SqlDelete xDel = new SqlDelete();
                xDel.Tabla(this.eTabla);

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormatoContableEN.ClaForCon, SqlSelect.Operador.Igual, xObj.ClaveFormatoContable);
                xDel.CondicionDelete(xSel.ObtenerScript());

                eObjCon.ComandoTexto(xDel.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void EliminarFormatoContablesCopia()
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.eTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormatoContableEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, FormatoContableEN.COriVenCre, SqlSelect.Operador.Igual, "02");//copia
            xDel.CondicionDelete(xSel.ObtenerScript());

            eObjCon.ComandoTexto(xDel.ObtenerScript());
            eObjCon.EjecutarSinResultado();
            eObjCon.Desconectar();
        }

        public void EliminarFormatoContablesImportacion()
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.eTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormatoContableEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, FormatoContableEN.COriVenCre, SqlSelect.Operador.Igual, "03");//importacion excel
            xDel.CondicionDelete(xSel.ObtenerScript());

            eObjCon.ComandoTexto(xDel.ObtenerScript());
            eObjCon.EjecutarSinResultado();
            eObjCon.Desconectar();
        }

        public List<FormatoContableEN> ListarFormatoContable(FormatoContableEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormatoContableEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public FormatoContableEN BuscarFormatoContableXClave(FormatoContableEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormatoContableEN.ClaForCon, SqlSelect.Operador.Igual, pObj.ClaveFormatoContable);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<FormatoContableEN> ListarFormatoContableXEstado(FormatoContableEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormatoContableEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (pObj.CEstadoFormatoContable != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, FormatoContableEN.CEstForCon, SqlSelect.Operador.Igual, pObj.CEstadoFormatoContable);
            }
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<FormatoContableEN> ListarFormatoContablesDeEmpresa(FormatoContableEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormatoContableEN.CodEmp, SqlSelect.Operador.Igual, pObj.CodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<FormatoContableEN> ListarFormatoContablesCopia(FormatoContableEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormatoContableEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, FormatoContableEN.COriVenCre, SqlSelect.Operador.Igual, "02");//copia
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<FormatoContableEN> ListarFormatoContablesImportados(FormatoContableEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormatoContableEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, FormatoContableEN.COriVenCre, SqlSelect.Operador.Igual, "03");//importacion excel
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<FormatoContableEN> ListarFormatoContablesCopiaParaEliminar()
        {
            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Select * From VsFormatoContable";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "' And COrigenVentanaCreacion='02'";
            iScript += " And CodigoFormatoContable not in(select distinct(CodigoFormatoContable) from Cuenta where CodigoEmpresa='";
            iScript += Universal.gCodigoEmpresa + "')";
           
            //resultado
            return this.ListarObjetos(iScript);
        }

        public List<FormatoContableEN> ListarFormatoContablesImportadosParaEliminar()
        {
            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Select * From VsFormatoContable";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "' And COrigenVentanaCreacion='03'";
            iScript += " And CodigoFormatoContable not in(select distinct(CodigoFormatoContable) from Cuenta where CodigoEmpresa='";
            iScript += Universal.gCodigoEmpresa + "')";

            //resultado
            return this.ListarObjetos(iScript);
        }

        #endregion

    }
}
