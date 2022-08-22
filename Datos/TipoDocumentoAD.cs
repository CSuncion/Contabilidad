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

    public class TipoDocumentoAD
    {

        #region Atributos

        private SqlDatos eObjCon = new SqlDatos();
        private List<TipoDocumentoEN> eLista = new List<TipoDocumentoEN>();
        private TipoDocumentoEN eObj = new TipoDocumentoEN();
        private string eTabla = "TipoDocumento";
        private string eVista = "VsTipoDocumento";

        #endregion

        #region Metodos privados

        private TipoDocumentoEN Objeto(IDataReader iDr)
        {
            TipoDocumentoEN xObjEnc = new TipoDocumentoEN();
            xObjEnc.CodigoTipoDocumento = iDr[TipoDocumentoEN.CodTipDoc].ToString();
            xObjEnc.DescripcionTipoDocumento = iDr[TipoDocumentoEN.DesTipDoc].ToString();
            xObjEnc.CAplicaEnRegistro = iDr[TipoDocumentoEN.CAplEnReg].ToString();
            xObjEnc.NAplicaEnRegistro = iDr[TipoDocumentoEN.NAplEnReg].ToString();
            xObjEnc.CAplicaDocumentoRef = iDr[TipoDocumentoEN.CAplDocRef].ToString();
            xObjEnc.NAplicaDocumentoRef = iDr[TipoDocumentoEN.NAplDocRef].ToString();
            xObjEnc.CTipoNota = iDr[TipoDocumentoEN.CTipNot].ToString();
            xObjEnc.NTipoNota = iDr[TipoDocumentoEN.NTipNot].ToString();
            xObjEnc.CEstadoTipoDocumento = iDr[TipoDocumentoEN.CEstTipDoc].ToString();
            xObjEnc.NEstadoTipoDocumento = iDr[TipoDocumentoEN.NEstTipDoc].ToString();
            xObjEnc.UsuarioAgrega = iDr[TipoDocumentoEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[TipoDocumentoEN.FecAgr].ToString());
            xObjEnc.UsuarioModifica = iDr[TipoDocumentoEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[TipoDocumentoEN.FecMod].ToString());
            xObjEnc.ClaveObjeto = xObjEnc.CodigoTipoDocumento;
            return xObjEnc;
        }

        private List<TipoDocumentoEN> ListarObjetos(string pScript)
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

        private TipoDocumentoEN BuscarObjeto(string pScript)
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

        public void AdicionarTipoDocumento(List<TipoDocumentoEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (TipoDocumentoEN xObj in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.eTabla);
                xIns.AsignarParametro(TipoDocumentoEN.CodTipDoc, xObj.CodigoTipoDocumento);
                xIns.AsignarParametro(TipoDocumentoEN.DesTipDoc, xObj.DescripcionTipoDocumento);
                xIns.AsignarParametro(TipoDocumentoEN.CAplEnReg, xObj.CAplicaEnRegistro);
                xIns.AsignarParametro(TipoDocumentoEN.CAplDocRef, xObj.CAplicaDocumentoRef);
                xIns.AsignarParametro(TipoDocumentoEN.CTipNot, xObj.CTipoNota);
                xIns.AsignarParametro(TipoDocumentoEN.CEstTipDoc, xObj.CEstadoTipoDocumento);
                xIns.AsignarParametro(TipoDocumentoEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(TipoDocumentoEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(TipoDocumentoEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(TipoDocumentoEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                eObjCon.ComandoTexto(xIns.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void ModificarTipoDocumento(List<TipoDocumentoEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (TipoDocumentoEN xObj in pLista)
            {
                //armando escript para insertar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.eTabla);
                xUpd.AsignarParametro(TipoDocumentoEN.CodTipDoc, xObj.CodigoTipoDocumento);
                xUpd.AsignarParametro(TipoDocumentoEN.DesTipDoc, xObj.DescripcionTipoDocumento);
                xUpd.AsignarParametro(TipoDocumentoEN.CAplEnReg, xObj.CAplicaEnRegistro);
                xUpd.AsignarParametro(TipoDocumentoEN.CAplDocRef, xObj.CAplicaDocumentoRef);
                xUpd.AsignarParametro(TipoDocumentoEN.CTipNot, xObj.CTipoNota);
                xUpd.AsignarParametro(TipoDocumentoEN.CEstTipDoc, xObj.CEstadoTipoDocumento);
                xUpd.AsignarParametro(TipoDocumentoEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(TipoDocumentoEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, TipoDocumentoEN.CodTipDoc, SqlSelect.Operador.Igual, xObj.CodigoTipoDocumento);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                eObjCon.ComandoTexto(xUpd.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void EliminarTipoDocumento(List<TipoDocumentoEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (TipoDocumentoEN xObj in pLista)
            {
                //armando escript para insertar
                SqlDelete xDel = new SqlDelete();
                xDel.Tabla(this.eTabla);

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, TipoDocumentoEN.CodTipDoc, SqlSelect.Operador.Igual, xObj.CodigoTipoDocumento);
                xDel.CondicionDelete(xSel.ObtenerScript());

                eObjCon.ComandoTexto(xDel.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public List<TipoDocumentoEN> ListarTipoDocumento(TipoDocumentoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);           
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public TipoDocumentoEN BuscarTipoDocumentoXClave(TipoDocumentoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, TipoDocumentoEN.CodTipDoc, SqlSelect.Operador.Igual, pObj.CodigoTipoDocumento);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<TipoDocumentoEN> ListarTipoDocumentoParaComprasActivo(TipoDocumentoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionINx(SqlSelect.Reservada.Cuando, TipoDocumentoEN.CAplEnReg, "'0','2'");
            xSel.CondicionINx(SqlSelect.Reservada.Y, TipoDocumentoEN.CEstTipDoc, "1");
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        #endregion

    }
}
