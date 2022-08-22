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

    public class CuentaAD
    {

        #region Atributos

        private SqlDatos eObjCon = new SqlDatos();
        private List<CuentaEN> eLista = new List<CuentaEN>();
        private CuentaEN eObj = new CuentaEN();
        private string eTabla = "Cuenta";
        private string eVista = "VsCuenta";

        #endregion

        #region Metodos privados

        private CuentaEN Objeto(IDataReader iDr)
        {
            CuentaEN xObjEnc = new CuentaEN();
            xObjEnc.ClaveCuenta = iDr[CuentaEN.ClaCue].ToString();
            xObjEnc.CodigoEmpresa = iDr[CuentaEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[CuentaEN.NomEmp].ToString();
            xObjEnc.CodigoCuenta = iDr[CuentaEN.CodCue].ToString();
            xObjEnc.DescripcionCuenta = iDr[CuentaEN.DesCue].ToString();
            xObjEnc.NumeroDigitosAnalitica = iDr[CuentaEN.NumDigAna].ToString();
            xObjEnc.CDocumento = iDr[CuentaEN.CDoc].ToString();
            xObjEnc.NDocumento = iDr[CuentaEN.NDoc].ToString();
            xObjEnc.CAuxiliar = iDr[CuentaEN.CAux].ToString();
            xObjEnc.NAuxiliar = iDr[CuentaEN.NAux].ToString();
            xObjEnc.CCentroCosto = iDr[CuentaEN.CCenCos].ToString();
            xObjEnc.NCentroCosto = iDr[CuentaEN.NCenCos].ToString();
            xObjEnc.CAlmacen = iDr[CuentaEN.CAlm].ToString();
            xObjEnc.NAlmacen = iDr[CuentaEN.NAlm].ToString();
            xObjEnc.CArea = iDr[CuentaEN.CAre].ToString();
            xObjEnc.NArea = iDr[CuentaEN.NAre].ToString();
            xObjEnc.CFlujoCaja = iDr[CuentaEN.CFluCaj].ToString();
            xObjEnc.NFlujoCaja = iDr[CuentaEN.NFluCaj].ToString();
            xObjEnc.CAutomatica = iDr[CuentaEN.CAut].ToString();
            xObjEnc.NAutomatica = iDr[CuentaEN.NAut].ToString();
            xObjEnc.CDiferenciaCambio = iDr[CuentaEN.CDifCam].ToString();
            xObjEnc.NDiferenciaCambio = iDr[CuentaEN.NDifCam].ToString();
            xObjEnc.CBanco = iDr[CuentaEN.CBan].ToString();
            xObjEnc.NBanco = iDr[CuentaEN.NBan].ToString();
            xObjEnc.CMoneda = iDr[CuentaEN.CMon].ToString();
            xObjEnc.NMoneda = iDr[CuentaEN.NMon].ToString();
            xObjEnc.CAsientoApertura = iDr[CuentaEN.CAsiApe].ToString();
            xObjEnc.NAsientoApertura = iDr[CuentaEN.NAsiApe].ToString();
            xObjEnc.CAsientoCierre7 = iDr[CuentaEN.CAsiCie7].ToString();
            xObjEnc.NAsientoCierre7 = iDr[CuentaEN.NAsiCie7].ToString();
            xObjEnc.CAsientoCierre9 = iDr[CuentaEN.CAsiCie9].ToString();
            xObjEnc.NAsientoCierre9 = iDr[CuentaEN.NAsiCie9].ToString();
            xObjEnc.CRegistro = iDr[CuentaEN.CReg].ToString();
            xObjEnc.NRegistro = iDr[CuentaEN.NReg].ToString();
            xObjEnc.CodigoCuentaAutomatica1 = iDr[CuentaEN.CodCueAut1].ToString();
            xObjEnc.DescripcionCuentaAutomatica1 = iDr[CuentaEN.DesCueAut1].ToString();
            xObjEnc.CodigoCuentaAutomatica2 = iDr[CuentaEN.CodCueAut2].ToString();
            xObjEnc.DescripcionCuentaAutomatica2 = iDr[CuentaEN.DesCueAut2].ToString();
            xObjEnc.CodigoFormatoContable = iDr[CuentaEN.CodForCon].ToString();
            xObjEnc.DescripcionFormatoContable = iDr[CuentaEN.DesForCon].ToString();
            xObjEnc.COrigenVentanaCreacion = iDr[CuentaEN.COriVenCre].ToString();
            xObjEnc.NOrigenVentanaCreacion = iDr[CuentaEN.NOriVenCre].ToString();
            xObjEnc.CEstadoCuenta = iDr[CuentaEN.CEstCue].ToString();
            xObjEnc.NEstadoCuenta = iDr[CuentaEN.NEstCue].ToString();
            xObjEnc.UsuarioAgrega = iDr[CuentaEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[CuentaEN.FecAgr].ToString());
            xObjEnc.UsuarioModifica = iDr[CuentaEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[CuentaEN.FecMod].ToString());
            xObjEnc.ClaveObjeto = xObjEnc.ClaveCuenta;
            return xObjEnc;
        }

        private List<CuentaEN> ListarObjetos(string pScript)
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

        private CuentaEN BuscarObjeto(string pScript)
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

        public void AdicionarCuenta(List<CuentaEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (CuentaEN xObj in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.eTabla);
                xIns.AsignarParametro(CuentaEN.ClaCue, xObj.ClaveCuenta);
                xIns.AsignarParametro(CuentaEN.CodEmp, xObj.CodigoEmpresa);
                xIns.AsignarParametro(CuentaEN.CodCue, xObj.CodigoCuenta);
                xIns.AsignarParametro(CuentaEN.DesCue, xObj.DescripcionCuenta);
                xIns.AsignarParametro(CuentaEN.NumDigAna, xObj.NumeroDigitosAnalitica);
                xIns.AsignarParametro(CuentaEN.CDoc, xObj.CDocumento);
                xIns.AsignarParametro(CuentaEN.CAux, xObj.CAuxiliar);
                xIns.AsignarParametro(CuentaEN.CCenCos, xObj.CCentroCosto);
                xIns.AsignarParametro(CuentaEN.CAlm, xObj.CAlmacen);
                xIns.AsignarParametro(CuentaEN.CAre, xObj.CArea);
                xIns.AsignarParametro(CuentaEN.CFluCaj, xObj.CFlujoCaja);
                xIns.AsignarParametro(CuentaEN.CAut, xObj.CAutomatica);
                xIns.AsignarParametro(CuentaEN.CDifCam, xObj.CDiferenciaCambio);
                xIns.AsignarParametro(CuentaEN.CBan, xObj.CBanco);
                xIns.AsignarParametro(CuentaEN.CMon, xObj.CMoneda);
                xIns.AsignarParametro(CuentaEN.CAsiApe, xObj.CAsientoApertura);
                xIns.AsignarParametro(CuentaEN.CAsiCie7, xObj.CAsientoCierre7);
                xIns.AsignarParametro(CuentaEN.CAsiCie9, xObj.CAsientoCierre9);
                xIns.AsignarParametro(CuentaEN.CReg, xObj.CRegistro);
                xIns.AsignarParametro(CuentaEN.CodCueAut1, xObj.CodigoCuentaAutomatica1);
                xIns.AsignarParametro(CuentaEN.CodCueAut2, xObj.CodigoCuentaAutomatica2);
                xIns.AsignarParametro(CuentaEN.CodForCon, xObj.CodigoFormatoContable);
                xIns.AsignarParametro(CuentaEN.COriVenCre, xObj.COrigenVentanaCreacion);
                xIns.AsignarParametro(CuentaEN.CEstCue, xObj.CEstadoCuenta);
                xIns.AsignarParametro(CuentaEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(CuentaEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(CuentaEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(CuentaEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                eObjCon.ComandoTexto(xIns.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void ModificarCuenta(List<CuentaEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (CuentaEN xObj in pLista)
            {
                //armando escript para insertar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.eTabla);
                xUpd.AsignarParametro(CuentaEN.ClaCue, xObj.ClaveCuenta);
                xUpd.AsignarParametro(CuentaEN.CodEmp, xObj.CodigoEmpresa);
                xUpd.AsignarParametro(CuentaEN.CodCue, xObj.CodigoCuenta);
                xUpd.AsignarParametro(CuentaEN.DesCue, xObj.DescripcionCuenta);
                xUpd.AsignarParametro(CuentaEN.NumDigAna, xObj.NumeroDigitosAnalitica);
                xUpd.AsignarParametro(CuentaEN.CDoc, xObj.CDocumento);
                xUpd.AsignarParametro(CuentaEN.CAux, xObj.CAuxiliar);
                xUpd.AsignarParametro(CuentaEN.CCenCos, xObj.CCentroCosto);
                xUpd.AsignarParametro(CuentaEN.CAlm, xObj.CAlmacen);
                xUpd.AsignarParametro(CuentaEN.CAre, xObj.CArea);
                xUpd.AsignarParametro(CuentaEN.CFluCaj, xObj.CFlujoCaja);
                xUpd.AsignarParametro(CuentaEN.CAut, xObj.CAutomatica);
                xUpd.AsignarParametro(CuentaEN.CDifCam, xObj.CDiferenciaCambio);
                xUpd.AsignarParametro(CuentaEN.CBan, xObj.CBanco);
                xUpd.AsignarParametro(CuentaEN.CMon, xObj.CMoneda);
                xUpd.AsignarParametro(CuentaEN.CAsiApe, xObj.CAsientoApertura);
                xUpd.AsignarParametro(CuentaEN.CAsiCie7, xObj.CAsientoCierre7);
                xUpd.AsignarParametro(CuentaEN.CAsiCie9, xObj.CAsientoCierre9);
                xUpd.AsignarParametro(CuentaEN.CReg, xObj.CRegistro);
                xUpd.AsignarParametro(CuentaEN.CodCueAut1, xObj.CodigoCuentaAutomatica1);
                xUpd.AsignarParametro(CuentaEN.CodCueAut2, xObj.CodigoCuentaAutomatica2);
                xUpd.AsignarParametro(CuentaEN.CodForCon, xObj.CodigoFormatoContable);
                xUpd.AsignarParametro(CuentaEN.COriVenCre, xObj.COrigenVentanaCreacion);
                xUpd.AsignarParametro(CuentaEN.CEstCue, xObj.CEstadoCuenta);
                xUpd.AsignarParametro(CuentaEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(CuentaEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaEN.ClaCue, SqlSelect.Operador.Igual, xObj.ClaveCuenta);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                eObjCon.ComandoTexto(xUpd.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void EliminarCuenta(List<CuentaEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (CuentaEN xObj in pLista)
            {
                //armando escript para insertar
                SqlDelete xDel = new SqlDelete();
                xDel.Tabla(this.eTabla);

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaEN.ClaCue, SqlSelect.Operador.Igual, xObj.ClaveCuenta);
                xDel.CondicionDelete(xSel.ObtenerScript());

                eObjCon.ComandoTexto(xDel.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public List<CuentaEN> ListarCuenta(CuentaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public CuentaEN BuscarCuentaXClave(CuentaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaEN.ClaCue, SqlSelect.Operador.Igual, pObj.ClaveCuenta);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<CuentaEN> ListarCuentaXNroDigitosYEstado(CuentaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (pObj.NumeroDigitosAnalitica != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, CuentaEN.NumDigAna, SqlSelect.Operador.Igual, pObj.NumeroDigitosAnalitica);
            }
            if (pObj.CEstadoCuenta != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, CuentaEN.CEstCue, SqlSelect.Operador.Igual, pObj.CEstadoCuenta);
            }
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<CuentaEN> ListarCuentaXEmpresaXNroDigitosXEstadoYAnalitica(CuentaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaEN.CodEmp, SqlSelect.Operador.Igual, pObj.CodigoEmpresa);
            if (pObj.NumeroDigitosAnalitica != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, CuentaEN.NumDigAna, SqlSelect.Operador.Igual, pObj.NumeroDigitosAnalitica);
            }
            if (pObj.CEstadoCuenta != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, CuentaEN.CEstCue, SqlSelect.Operador.Igual, pObj.CEstadoCuenta);
            }
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuentaEN.CDoc, SqlSelect.Operador.Diferente, string.Empty);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<CuentaEN> ListarCuentaDiferentesDeOrigenCopiaPcge()
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuentaEN.COriVenCre, SqlSelect.Operador.Diferente, "05");//copia pcge            
            xSel.Ordenar(CuentaEN.CodCue, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<CuentaEN> ListarCuentasDeEmpresa(CuentaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaEN.CodEmp, SqlSelect.Operador.Igual, pObj.CodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<CuentaEN> ListarCuentasCopiaDeEmpresa(CuentaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuentaEN.COriVenCre, SqlSelect.Operador.Igual, "02");//copia empresa
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<CuentaEN> ListarCuentasCopiaDePcge(CuentaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuentaEN.COriVenCre, SqlSelect.Operador.Igual, "05");//copia pcge
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<CuentaEN> ListarCuentasImportadasExcel(CuentaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuentaEN.COriVenCre, SqlSelect.Operador.Igual, "03");//importacion excel
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<CuentaEN> ListarCuentasParaRegistroCompraPV(CuentaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuentaEN.CReg, SqlSelect.Operador.Igual, ItemGEN.Registro_CompraPV);            
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuentaEN.CEstCue, SqlSelect.Operador.Igual, "1");//activo            
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<CuentaEN> ListarCuentasParaRegistroCompraPVMoneda(CuentaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuentaEN.CReg, SqlSelect.Operador.Igual, ItemGEN.Registro_CompraPV);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuentaEN.CMon, SqlSelect.Operador.Igual, Universal.gMonedaCompra);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuentaEN.CEstCue, SqlSelect.Operador.Igual, "1");//activo            
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<CuentaEN> ListarCuentasParaRegistroCompraVV(CuentaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuentaEN.CReg, SqlSelect.Operador.Igual, ItemGEN.Registro_CompraVV);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuentaEN.CEstCue, SqlSelect.Operador.Igual, "1");//activo            
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<CuentaEN> ListarCuentasParaRegistroCompraEspecial(CuentaEN pObj)
        {
            //script manual
            string iScript = string.Empty;

            //armar valor IN(para CRegistro)
            string iValorIN = Cadena.ArmarCadenaParaIN(ItemGEN.Registro_CompraPV, ItemGEN.Registro_CompraVV);

            //armando la consulta
            iScript += "Select * From VsCuenta";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "' And (CRegistro In(" + iValorIN + ")";
            iScript += " Or CodigoCuenta='"+ pObj.CodigoCuenta + "') And CEstadoCuenta='1' ";
            iScript += "Order By " + pObj.Adicionales.CampoOrden;

            //resultado
            return this.ListarObjetos(iScript);            
        }

        #endregion

    }
}
