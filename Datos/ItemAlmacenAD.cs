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

    public class ItemAlmacenAD
    {

        #region Atributos

        private SqlDatos eObjCon = new SqlDatos();
        private List<ItemAlmacenEN> eLista = new List<ItemAlmacenEN>();
        private ItemAlmacenEN eObj = new ItemAlmacenEN();
        private string eTabla = "ItemAlmacen";
        private string eVista = "VsItemAlmacen";

        #endregion

        #region Metodos privados

        private ItemAlmacenEN Objeto(IDataReader iDr)
        {
            ItemAlmacenEN xObjEnc = new ItemAlmacenEN();
            xObjEnc.ClaveItemAlmacen = iDr[ItemAlmacenEN.ClaIteAlm].ToString();
            xObjEnc.CodigoEmpresa = iDr[ItemAlmacenEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[ItemAlmacenEN.NomEmp].ToString();
            xObjEnc.CodigoAlmacen = iDr[ItemAlmacenEN.CodAlm].ToString();
            xObjEnc.DescripcionAlmacen = iDr[ItemAlmacenEN.DesAlm].ToString();
            xObjEnc.CodigoItemAlmacen = iDr[ItemAlmacenEN.CodIteAlm].ToString();
            xObjEnc.DescripcionItemAlmacen = iDr[ItemAlmacenEN.DesIteAlm].ToString();
            xObjEnc.CUnidadMedida = iDr[ItemAlmacenEN.CUniMed].ToString();
            xObjEnc.NUnidadMedida = iDr[ItemAlmacenEN.NUniMed].ToString();
            xObjEnc.COrigenVentanaCreacion = iDr[ItemAlmacenEN.COriVenCre].ToString();
            xObjEnc.NOrigenVentanaCreacion = iDr[ItemAlmacenEN.NOriVenCre].ToString();
            xObjEnc.CEstadoItemAlmacen = iDr[ItemAlmacenEN.CEstIteAlm].ToString();
            xObjEnc.NEstadoItemAlmacen = iDr[ItemAlmacenEN.NEstIteAlm].ToString();
            xObjEnc.UsuarioAgrega = iDr[ItemAlmacenEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[ItemAlmacenEN.FecAgr].ToString());
            xObjEnc.UsuarioModifica = iDr[ItemAlmacenEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[ItemAlmacenEN.FecMod].ToString());
            xObjEnc.ClaveObjeto = xObjEnc.ClaveItemAlmacen;
            return xObjEnc;
        }

        private List<ItemAlmacenEN> ListarObjetos(string pScript)
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

        private ItemAlmacenEN BuscarObjeto(string pScript)
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

        public void AdicionarItemAlmacen(List<ItemAlmacenEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (ItemAlmacenEN xObj in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.eTabla);
                xIns.AsignarParametro(ItemAlmacenEN.ClaIteAlm, xObj.ClaveItemAlmacen);
                xIns.AsignarParametro(ItemAlmacenEN.CodEmp, xObj.CodigoEmpresa);
                xIns.AsignarParametro(ItemAlmacenEN.CodAlm, xObj.CodigoAlmacen);
                xIns.AsignarParametro(ItemAlmacenEN.CodIteAlm, xObj.CodigoItemAlmacen);
                xIns.AsignarParametro(ItemAlmacenEN.DesIteAlm, xObj.DescripcionItemAlmacen);
                xIns.AsignarParametro(ItemAlmacenEN.CUniMed, xObj.CUnidadMedida);
                xIns.AsignarParametro(ItemAlmacenEN.COriVenCre, xObj.COrigenVentanaCreacion);
                xIns.AsignarParametro(ItemAlmacenEN.CEstIteAlm, xObj.CEstadoItemAlmacen);
                xIns.AsignarParametro(ItemAlmacenEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(ItemAlmacenEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(ItemAlmacenEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(ItemAlmacenEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                eObjCon.ComandoTexto(xIns.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void ModificarItemAlmacen(List<ItemAlmacenEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (ItemAlmacenEN xObj in pLista)
            {
                //armando escript para insertar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.eTabla);
                xUpd.AsignarParametro(ItemAlmacenEN.ClaIteAlm, xObj.ClaveItemAlmacen);
                xUpd.AsignarParametro(ItemAlmacenEN.CodEmp, xObj.CodigoEmpresa);
                xUpd.AsignarParametro(ItemAlmacenEN.CodAlm, xObj.CodigoAlmacen);
                xUpd.AsignarParametro(ItemAlmacenEN.CodIteAlm, xObj.CodigoItemAlmacen);
                xUpd.AsignarParametro(ItemAlmacenEN.DesIteAlm, xObj.DescripcionItemAlmacen);
                xUpd.AsignarParametro(ItemAlmacenEN.CUniMed, xObj.CUnidadMedida);
                xUpd.AsignarParametro(ItemAlmacenEN.COriVenCre, xObj.COrigenVentanaCreacion);
                xUpd.AsignarParametro(ItemAlmacenEN.CEstIteAlm, xObj.CEstadoItemAlmacen);
                xUpd.AsignarParametro(ItemAlmacenEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(ItemAlmacenEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemAlmacenEN.ClaIteAlm, SqlSelect.Operador.Igual, xObj.ClaveItemAlmacen);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                eObjCon.ComandoTexto(xUpd.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void EliminarItemAlmacen(List<ItemAlmacenEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (ItemAlmacenEN xObj in pLista)
            {
                //armando escript para insertar
                SqlDelete xDel = new SqlDelete();
                xDel.Tabla(this.eTabla);

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemAlmacenEN.ClaIteAlm, SqlSelect.Operador.Igual, xObj.ClaveItemAlmacen);
                xDel.CondicionDelete(xSel.ObtenerScript());

                eObjCon.ComandoTexto(xDel.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public List<ItemAlmacenEN> ListarItemAlmacen(ItemAlmacenEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemAlmacenEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public ItemAlmacenEN BuscarItemAlmacenXClave(ItemAlmacenEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemAlmacenEN.ClaIteAlm, SqlSelect.Operador.Igual, pObj.ClaveItemAlmacen);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<ItemAlmacenEN> ListarItemAlmacenDeEmpresa(ItemAlmacenEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemAlmacenEN.CodEmp, SqlSelect.Operador.Igual, pObj.CodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ItemAlmacenEN> ListarItemAlmacenCopiaParaEliminar()
        {
            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Select * From VsItemAlmacen";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "' And COrigenVentanaCreacion='02'";
            iScript += " And CodigoItemAlmacen not in(select distinct(CodigoItemAlmacen) from RegConCabe where CodigoEmpresa='";
            iScript += Universal.gCodigoEmpresa + "')";

            //resultado
            return this.ListarObjetos(iScript);
        }

        public List<ItemAlmacenEN> ListarItemAlmacenActivos(ItemAlmacenEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemAlmacenEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ItemAlmacenEN.CEstIteAlm, SqlSelect.Operador.Igual, "1");
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ItemAlmacenEN> ListarItemAlmacenActivosDeAlmacen(ItemAlmacenEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemAlmacenEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ItemAlmacenEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ItemAlmacenEN.CEstIteAlm, SqlSelect.Operador.Igual, "1");
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }


        #endregion

    }
}
