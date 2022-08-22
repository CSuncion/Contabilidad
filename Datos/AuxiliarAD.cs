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

    public class AuxiliarAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<AuxiliarEN> xLista = new List<AuxiliarEN>();
        private AuxiliarEN xObj = new AuxiliarEN();
        private string xTabla = "Auxiliar";
        private string xVista = "VsAuxiliar";

        #endregion
        
        #region Metodos privados

        private AuxiliarEN Objeto(IDataReader iDr)
        {
            AuxiliarEN xObjEnc = new AuxiliarEN();
            xObjEnc.ClaveAuxiliar = iDr[AuxiliarEN.ClaAux].ToString();
            xObjEnc.CodigoEmpresa = iDr[AuxiliarEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[AuxiliarEN.NomEmp].ToString();
            xObjEnc.CodigoAuxiliar = iDr[AuxiliarEN.CodAux].ToString();
            xObjEnc.ApellidoPaternoAuxiliar = iDr[AuxiliarEN.ApePatAux].ToString();
            xObjEnc.ApellidoMaternoAuxiliar = iDr[AuxiliarEN.ApeMatAux].ToString();
            xObjEnc.PrimerNombreAuxiliar = iDr[AuxiliarEN.PriNomAux].ToString();
            xObjEnc.SegundoNombreAuxiliar = iDr[AuxiliarEN.SegNomAux].ToString();
            xObjEnc.DescripcionAuxiliar = iDr[AuxiliarEN.DesAux].ToString();
            xObjEnc.DireccionAuxiliar = iDr[AuxiliarEN.DirAux].ToString();
            xObjEnc.TelefonoAuxiliar = iDr[AuxiliarEN.TelAux].ToString();
            xObjEnc.CelularAuxiliar = iDr[AuxiliarEN.CelAux].ToString();
            xObjEnc.CorreoAuxiliar = iDr[AuxiliarEN.CorAux].ToString();
            xObjEnc.ReferenciaAuxiliar = iDr[AuxiliarEN.RefAux].ToString();
            xObjEnc.CClaseAuxiliar = iDr[AuxiliarEN.CClaAux].ToString();
            xObjEnc.NClaseAuxiliar = iDr[AuxiliarEN.NClaAux].ToString();
            xObjEnc.CTipoAuxiliar = iDr[AuxiliarEN.CTipAux].ToString();
            xObjEnc.NTipoAuxiliar = iDr[AuxiliarEN.NTipAux].ToString();
            xObjEnc.CTipoDocumentoAuxiliar = iDr[AuxiliarEN.CTipDocAux].ToString();
            xObjEnc.NTipoDocumentoAuxiliar = iDr[AuxiliarEN.NTipDocAux].ToString();
            xObjEnc.CPaisNoDomiciliadoAuxiliar = iDr[AuxiliarEN.CPaiNoDomAux].ToString();
            xObjEnc.NPaisNoDomiciliadoAuxiliar = iDr[AuxiliarEN.NPaiNoDomAux].ToString();
            xObjEnc.FechaInscripcionSnpAuxiliar = iDr[AuxiliarEN.FecInsSnpAux].ToString();
            xObjEnc.COrigenVentanaCreacion = iDr[AuxiliarEN.COriVenCre].ToString();
            xObjEnc.NOrigenVentanaCreacion = iDr[AuxiliarEN.NOriVenCre].ToString();
            xObjEnc.CEstadoAuxiliar = iDr[AuxiliarEN.CEstAux].ToString();
            xObjEnc.NEstadoAuxiliar = iDr[AuxiliarEN.NEstAux].ToString();
            xObjEnc.UsuarioAgrega = iDr[AuxiliarEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[AuxiliarEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[AuxiliarEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[AuxiliarEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveAuxiliar;
            return xObjEnc;
        }
        
        private List<AuxiliarEN> ListarObjetos(string pScript)
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
        
        private AuxiliarEN BuscarObjeto(string pScript)
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
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, AuxiliarEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public void AgregarAuxiliar(AuxiliarEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(AuxiliarEN.ClaAux, pObj.ClaveAuxiliar);
            xIns.AsignarParametro(AuxiliarEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(AuxiliarEN.CodAux, pObj.CodigoAuxiliar);
            xIns.AsignarParametro(AuxiliarEN.ApePatAux, pObj.ApellidoPaternoAuxiliar);
            xIns.AsignarParametro(AuxiliarEN.ApeMatAux, pObj.ApellidoMaternoAuxiliar);
            xIns.AsignarParametro(AuxiliarEN.PriNomAux, pObj.PrimerNombreAuxiliar);
            xIns.AsignarParametro(AuxiliarEN.SegNomAux, pObj.SegundoNombreAuxiliar);
            xIns.AsignarParametro(AuxiliarEN.DesAux, pObj.DescripcionAuxiliar);
            xIns.AsignarParametro(AuxiliarEN.DirAux, pObj.DireccionAuxiliar);
            xIns.AsignarParametro(AuxiliarEN.TelAux, pObj.TelefonoAuxiliar);
            xIns.AsignarParametro(AuxiliarEN.CelAux, pObj.CelularAuxiliar);
            xIns.AsignarParametro(AuxiliarEN.CorAux, pObj.CorreoAuxiliar);
            xIns.AsignarParametro(AuxiliarEN.RefAux, pObj.ReferenciaAuxiliar);
            xIns.AsignarParametro(AuxiliarEN.CClaAux, pObj.CClaseAuxiliar);
            xIns.AsignarParametro(AuxiliarEN.CTipAux, pObj.CTipoAuxiliar);
            xIns.AsignarParametro(AuxiliarEN.CTipDocAux, pObj.CTipoDocumentoAuxiliar);
            xIns.AsignarParametro(AuxiliarEN.CPaiNoDomAux, pObj.CPaisNoDomiciliadoAuxiliar);
            xIns.AsignarParametro(AuxiliarEN.FecInsSnpAux, pObj.FechaInscripcionSnpAuxiliar);
            xIns.AsignarParametro(AuxiliarEN.COriVenCre, pObj.COrigenVentanaCreacion);
            xIns.AsignarParametro(AuxiliarEN.CEstAux, pObj.CEstadoAuxiliar);       
            xIns.AsignarParametro(AuxiliarEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(AuxiliarEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(AuxiliarEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(AuxiliarEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AgregarAuxiliar(List< AuxiliarEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);

            //recorrer cada objeto
            foreach (AuxiliarEN xAux in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(AuxiliarEN.ClaAux, xAux.ClaveAuxiliar);
                xIns.AsignarParametro(AuxiliarEN.CodEmp, xAux.CodigoEmpresa);
                xIns.AsignarParametro(AuxiliarEN.CodAux, xAux.CodigoAuxiliar);
                xIns.AsignarParametro(AuxiliarEN.ApePatAux, xAux.ApellidoPaternoAuxiliar);
                xIns.AsignarParametro(AuxiliarEN.ApeMatAux, xAux.ApellidoMaternoAuxiliar);
                xIns.AsignarParametro(AuxiliarEN.PriNomAux, xAux.PrimerNombreAuxiliar);
                xIns.AsignarParametro(AuxiliarEN.SegNomAux, xAux.SegundoNombreAuxiliar);
                xIns.AsignarParametro(AuxiliarEN.DesAux, xAux.DescripcionAuxiliar);
                xIns.AsignarParametro(AuxiliarEN.DirAux, xAux.DireccionAuxiliar);
                xIns.AsignarParametro(AuxiliarEN.TelAux, xAux.TelefonoAuxiliar);
                xIns.AsignarParametro(AuxiliarEN.CelAux, xAux.CelularAuxiliar);
                xIns.AsignarParametro(AuxiliarEN.CorAux, xAux.CorreoAuxiliar);
                xIns.AsignarParametro(AuxiliarEN.RefAux, xAux.ReferenciaAuxiliar);
                xIns.AsignarParametro(AuxiliarEN.CClaAux, xAux.CClaseAuxiliar);
                xIns.AsignarParametro(AuxiliarEN.CTipAux, xAux.CTipoAuxiliar);
                xIns.AsignarParametro(AuxiliarEN.CTipDocAux, xAux.CTipoDocumentoAuxiliar);
                xIns.AsignarParametro(AuxiliarEN.CPaiNoDomAux, xAux.CPaisNoDomiciliadoAuxiliar);
                xIns.AsignarParametro(AuxiliarEN.FecInsSnpAux, xAux.FechaInscripcionSnpAuxiliar);
                xIns.AsignarParametro(AuxiliarEN.COriVenCre, xAux.COrigenVentanaCreacion);
                xIns.AsignarParametro(AuxiliarEN.CEstAux, xAux.CEstadoAuxiliar);
                xIns.AsignarParametro(AuxiliarEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(AuxiliarEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(AuxiliarEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(AuxiliarEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
            
            xObjCon.Desconectar();
        }

        public void ModificarAuxiliar(AuxiliarEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(AuxiliarEN.ApePatAux, pObj.ApellidoPaternoAuxiliar);
            xUpd.AsignarParametro(AuxiliarEN.ApeMatAux, pObj.ApellidoMaternoAuxiliar);
            xUpd.AsignarParametro(AuxiliarEN.PriNomAux, pObj.PrimerNombreAuxiliar);
            xUpd.AsignarParametro(AuxiliarEN.SegNomAux, pObj.SegundoNombreAuxiliar);
            xUpd.AsignarParametro(AuxiliarEN.DesAux, pObj.DescripcionAuxiliar);
            xUpd.AsignarParametro(AuxiliarEN.DirAux, pObj.DireccionAuxiliar);
            xUpd.AsignarParametro(AuxiliarEN.TelAux, pObj.TelefonoAuxiliar);
            xUpd.AsignarParametro(AuxiliarEN.CelAux, pObj.CelularAuxiliar);
            xUpd.AsignarParametro(AuxiliarEN.CorAux, pObj.CorreoAuxiliar);
            xUpd.AsignarParametro(AuxiliarEN.RefAux, pObj.ReferenciaAuxiliar);
            xUpd.AsignarParametro(AuxiliarEN.CTipAux, pObj.CTipoAuxiliar);
            xUpd.AsignarParametro(AuxiliarEN.CTipDocAux, pObj.CTipoDocumentoAuxiliar);
            xUpd.AsignarParametro(AuxiliarEN.CPaiNoDomAux, pObj.CPaisNoDomiciliadoAuxiliar);
            xUpd.AsignarParametro(AuxiliarEN.FecInsSnpAux, pObj.FechaInscripcionSnpAuxiliar);
            xUpd.AsignarParametro(AuxiliarEN.CEstAux, pObj.CEstadoAuxiliar);
            xUpd.AsignarParametro(AuxiliarEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(AuxiliarEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, AuxiliarEN.ClaAux, SqlSelect.Operador.Igual, pObj.ClaveAuxiliar);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarAuxiliar(AuxiliarEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, AuxiliarEN.ClaAux, SqlSelect.Operador.Igual, pObj.ClaveAuxiliar);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarAuxiliaresCopia()
        {
            xObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, AuxiliarEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, AuxiliarEN.COriVenCre, SqlSelect.Operador.Igual, "02");//copia
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarAuxiliaresImportacion()
        {
            xObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, AuxiliarEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, AuxiliarEN.COriVenCre, SqlSelect.Operador.Igual, "03");//importacion excel
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<AuxiliarEN> ListarAuxiliares(AuxiliarEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, AuxiliarEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public AuxiliarEN BuscarAuxiliarXClave(AuxiliarEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, AuxiliarEN.ClaAux, SqlSelect.Operador.Igual, pObj.ClaveAuxiliar);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<AuxiliarEN> ListarProveedores(AuxiliarEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, AuxiliarEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionINx(SqlSelect.Reservada.Y, AuxiliarEN.CTipAux, "'1','2'");
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<AuxiliarEN> ListarClientes(AuxiliarEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, AuxiliarEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionINx(SqlSelect.Reservada.Y, AuxiliarEN.CTipAux, "'0','2'");
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<AuxiliarEN> ListarAuxiliarsDeEmpresa(AuxiliarEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, AuxiliarEN.CodEmp, SqlSelect.Operador.Igual, pObj.CodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<AuxiliarEN> ListarAuxiliaresCopia(AuxiliarEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, AuxiliarEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, AuxiliarEN.COriVenCre, SqlSelect.Operador.Igual, "02");//copia
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<AuxiliarEN> ListarAuxiliaresImportados(AuxiliarEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, AuxiliarEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, AuxiliarEN.COriVenCre, SqlSelect.Operador.Igual, "03");//importacion excel
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<AuxiliarEN> ListarProveedoresActivos(AuxiliarEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, AuxiliarEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionINx(SqlSelect.Reservada.Y, AuxiliarEN.CTipAux, "'1','2','3'");
            xSel.CondicionCV(SqlSelect.Reservada.Y, AuxiliarEN.CEstAux, SqlSelect.Operador.Igual, "1");//activos
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<AuxiliarEN> ListarClientesActivos(AuxiliarEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, AuxiliarEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionINx(SqlSelect.Reservada.Y, AuxiliarEN.CTipAux, "'0','2','3'");
            xSel.CondicionCV(SqlSelect.Reservada.Y, AuxiliarEN.CEstAux, SqlSelect.Operador.Igual, "1");//activos            
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }
        #endregion

    }
}
