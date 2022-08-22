using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ScriptBD;
using Datos;
using Entidades;
using Entidades.Adicionales;
using Comun;
using Datos.Config;

namespace Datos
{

    public class EmpresaAD
    {
        //variables de trabajo
        private SqlDatos xObjCon = new SqlDatos();
        private List<EmpresaEN> xLista = new List<EmpresaEN>();
        private EmpresaEN xObj = new EmpresaEN();
        private string xTabla = "Empresa";
        private string xVista = "VsEmpresa";
        

        #region Metodos privados

        private EmpresaEN Objeto(IDataReader iDr)
        {
            EmpresaEN xObjEnc = new EmpresaEN();
            xObjEnc.CodigoEmpresa = iDr[EmpresaEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[EmpresaEN.NomEmp].ToString();
            xObjEnc.CorreoEmpresa = iDr[EmpresaEN.CorEmp].ToString();
            xObjEnc.RucEmpresa = iDr[EmpresaEN.RucEmp].ToString();
            xObjEnc.DireccionEmpresa = iDr[EmpresaEN.DirEmp].ToString();
            xObjEnc.TelFijoEmpresa = iDr[EmpresaEN.TelFijEmp].ToString();
            xObjEnc.TelCelularEmpresa = iDr[EmpresaEN.TelCelEmp].ToString();
            xObjEnc.NextelEmpresa = iDr[EmpresaEN.NexEmp].ToString();
            xObjEnc.LogoEmpresa = iDr[EmpresaEN.LogEmp].ToString();
            xObjEnc.NumeroDigitosAnalitica = iDr[EmpresaEN.NumDigAna].ToString();
            xObjEnc.CuentaAutomatica2 = iDr[EmpresaEN.CueAut2].ToString();
            xObjEnc.CuentaIgv = iDr[EmpresaEN.CueIgv].ToString();
            xObjEnc.FileNotaCreditoCompra = iDr[EmpresaEN.FilNotCreCom].ToString();
            xObjEnc.FileNotaDebitoCompra = iDr[EmpresaEN.FilNotDebCom].ToString();
            xObjEnc.FileImportacionCompra = iDr[EmpresaEN.FilImpCom].ToString();
            xObjEnc.FileDuaCompra = iDr[EmpresaEN.FilDuaCom].ToString();
            xObjEnc.FilePercepcionCompra = iDr[EmpresaEN.FilPerCom].ToString();
            xObjEnc.CEstadoEmpresa = iDr[EmpresaEN.CEstEmp].ToString();
            xObjEnc.NEstadoEmpresa = iDr[EmpresaEN.NEstEmp].ToString();    
            xObjEnc.UsuarioAgrega = iDr[EmpresaEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[EmpresaEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[EmpresaEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[EmpresaEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.CodigoEmpresa;
            return xObjEnc;
        }
        
        private List<EmpresaEN> ListarObjetos(string pScript)
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
        
        private EmpresaEN BuscarObjeto(string pScript)
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


        public bool ExisteValorEnColumna(string pColumna, string pValor)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumna, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, pColumna, SqlSelect.Operador.Igual, pValor);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }
        
        public void AgregarEmpresa(EmpresaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(EmpresaEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(EmpresaEN.NomEmp, pObj.NombreEmpresa);
            xIns.AsignarParametro(EmpresaEN.CorEmp, pObj.CorreoEmpresa);
            xIns.AsignarParametro(EmpresaEN.RucEmp, pObj.RucEmpresa);
            xIns.AsignarParametro(EmpresaEN.DirEmp, pObj.DireccionEmpresa);
            xIns.AsignarParametro(EmpresaEN.TelFijEmp, pObj.TelFijoEmpresa);
            xIns.AsignarParametro(EmpresaEN.TelCelEmp, pObj.TelCelularEmpresa);
            xIns.AsignarParametro(EmpresaEN.NexEmp, pObj.NextelEmpresa);
            xIns.AsignarParametro(EmpresaEN.LogEmp, pObj.LogoEmpresa);
            xIns.AsignarParametro(EmpresaEN.NumDigAna, pObj.NumeroDigitosAnalitica);
            xIns.AsignarParametro(EmpresaEN.CueAut2, pObj.CuentaAutomatica2);
            xIns.AsignarParametro(EmpresaEN.CueIgv, pObj.CuentaIgv);
            xIns.AsignarParametro(EmpresaEN.FilNotCreCom, pObj.FileNotaCreditoCompra);
            xIns.AsignarParametro(EmpresaEN.FilNotDebCom, pObj.FileNotaDebitoCompra);
            xIns.AsignarParametro(EmpresaEN.FilImpCom, pObj.FileImportacionCompra);
            xIns.AsignarParametro(EmpresaEN.FilDuaCom, pObj.FileDuaCompra);
            xIns.AsignarParametro(EmpresaEN.FilPerCom, pObj.FilePercepcionCompra);
            xIns.AsignarParametro(EmpresaEN.CEstEmp, pObj.CEstadoEmpresa);       
            xIns.AsignarParametro(EmpresaEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(EmpresaEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(EmpresaEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(EmpresaEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarEmpresa(EmpresaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(EmpresaEN.NomEmp, pObj.NombreEmpresa);
            xUpd.AsignarParametro(EmpresaEN.CorEmp, pObj.CorreoEmpresa);
            xUpd.AsignarParametro(EmpresaEN.RucEmp, pObj.RucEmpresa);
            xUpd.AsignarParametro(EmpresaEN.DirEmp, pObj.DireccionEmpresa);
            xUpd.AsignarParametro(EmpresaEN.TelFijEmp, pObj.TelFijoEmpresa);
            xUpd.AsignarParametro(EmpresaEN.TelCelEmp, pObj.TelCelularEmpresa);
            xUpd.AsignarParametro(EmpresaEN.NexEmp, pObj.NextelEmpresa);
            xUpd.AsignarParametro(EmpresaEN.LogEmp, pObj.LogoEmpresa);
            xUpd.AsignarParametro(EmpresaEN.NumDigAna, pObj.NumeroDigitosAnalitica);
            xUpd.AsignarParametro(EmpresaEN.CueAut2, pObj.CuentaAutomatica2);
            xUpd.AsignarParametro(EmpresaEN.CueIgv, pObj.CuentaIgv);
            xUpd.AsignarParametro(EmpresaEN.FilNotCreCom, pObj.FileNotaCreditoCompra);
            xUpd.AsignarParametro(EmpresaEN.FilNotDebCom, pObj.FileNotaDebitoCompra);
            xUpd.AsignarParametro(EmpresaEN.FilImpCom, pObj.FileImportacionCompra);
            xUpd.AsignarParametro(EmpresaEN.FilDuaCom, pObj.FileDuaCompra);
            xUpd.AsignarParametro(EmpresaEN.FilPerCom, pObj.FilePercepcionCompra);
            xUpd.AsignarParametro(EmpresaEN.CEstEmp, pObj.CEstadoEmpresa);           
            xUpd.AsignarParametro(EmpresaEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(EmpresaEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, EmpresaEN.CodEmp, SqlSelect.Operador.Igual, pObj.CodigoEmpresa);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarEmpresa(EmpresaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, EmpresaEN.CodEmp, SqlSelect.Operador.Igual, pObj.CodigoEmpresa);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<EmpresaEN> ListarEmpresas(EmpresaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }
        
        public EmpresaEN BuscarEmpresaXCodigo(EmpresaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, EmpresaEN.CodEmp, SqlSelect.Operador.Igual, pObj.CodigoEmpresa);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<EmpresaEN> ListarEmpresasExceptoLaActual(EmpresaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, EmpresaEN.CodEmp, SqlSelect.Operador.Diferente, pObj.CodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

    }
}
