using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Datos;
using Comun;
using Entidades.Adicionales;
using System.Windows.Forms;

namespace Negocio
{
    public class CuentaRN
    {

        public static CuentaEN EnBlanco()
        {
            CuentaEN iObjEN = new CuentaEN();
            return iObjEN;
        }

        public static void AdicionarCuenta(List<CuentaEN> pLista)
        {
            CuentaAD iObjAD = new CuentaAD();
            iObjAD.AdicionarCuenta(pLista);
        }

        public static void AdicionarCuenta(CuentaEN pObj)
        {
            //Asignar parametros
            List<CuentaEN> iLisObj = new List<CuentaEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            CuentaRN.AdicionarCuenta(iLisObj);
        }

        public static void ModificarCuenta(List<CuentaEN> pLista)
        {
            CuentaAD iObjAD = new CuentaAD();
            iObjAD.ModificarCuenta(pLista);
        }

        public static void ModificarCuenta(CuentaEN pObj)
        {
            //Asignar parametros
            List<CuentaEN> iLisObj = new List<CuentaEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            CuentaRN.ModificarCuenta(iLisObj);
        }

        public static void EliminarCuenta(List<CuentaEN> pLista)
        {
            CuentaAD iObjAD = new CuentaAD();
            iObjAD.EliminarCuenta(pLista);
        }

        public static void EliminarCuenta(CuentaEN pObj)
        {
            //Asignar parametros
            List<CuentaEN> iLisObj = new List<CuentaEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            CuentaRN.EliminarCuenta(iLisObj);
        }

        public static void EliminarCuentas()
        {
            //traer a todas las cuentas de la empresa
            List<CuentaEN> iLisCue = CuentaRN.ListarCuenta();

            //eliminar
            CuentaRN.EliminarCuenta(iLisCue);
        }

        public static List<CuentaEN> ListarCuenta(CuentaEN pObj)
        {
            CuentaAD iObjAD = new CuentaAD();
            return iObjAD.ListarCuenta(pObj);
        }

        public static List<CuentaEN> ListarCuenta()
        {
            //asignar parametros
            CuentaEN iObjEN = new CuentaEN();
            iObjEN.Adicionales.CampoOrden = CuentaEN.ClaCue;

            //ejecutar metodo
            return CuentaRN.ListarCuenta(iObjEN);
        }

        public static CuentaEN BuscarCuentaXClave(CuentaEN pObj)
        {
            CuentaAD iObjAD = new CuentaAD();
            return iObjAD.BuscarCuentaXClave(pObj);
        }

        public static CuentaEN EsCuentaExistente(CuentaEN pObj)
        {
            //objeto resultado
            CuentaEN iObjEN = new CuentaEN();

            //validar si existe en b.d
            pObj.ClaveCuenta = CuentaRN.ObtenerClaveCuenta(pObj);
            iObjEN = CuentaRN.BuscarCuentaXClave(pObj);
            if (iObjEN.ClaveCuenta == string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El Registro seleccionado no existe";
            }

            //ok  
            return iObjEN;
        }

        public static CuentaEN EsCodigoCuentaDisponible(CuentaEN pObj)
        {
            //objeto resultado
            CuentaEN iObjEN = new CuentaEN();

            //valida cuando esta vacio
            if (pObj.CodigoCuenta == string.Empty) { return iObjEN; }

            //validar si existe
            iObjEN = CuentaRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }

        public static CuentaEN ValidaCuandoCodigoYaExiste(CuentaEN pObj)
        {
            //objeto resultado
            CuentaEN iObjEN = new CuentaEN();

            //validar
            iObjEN = CuentaRN.BuscarCuentaXClave(pObj);
            if (iObjEN.ClaveCuenta != string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "Este codigo ya existe";
            }

            //ok  
            return iObjEN;
        }

        public static string ObtenerValorDeCampo(CuentaEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case CuentaEN.ClaObj: return pObj.ClaveObjeto;
                case CuentaEN.ClaCue: return pObj.ClaveCuenta;
                case CuentaEN.CodEmp: return pObj.CodigoEmpresa;
                case CuentaEN.NomEmp: return pObj.NombreEmpresa;
                case CuentaEN.CodCue: return pObj.CodigoCuenta;
                case CuentaEN.DesCue: return pObj.DescripcionCuenta;
                case CuentaEN.NumDigAna: return pObj.NumeroDigitosAnalitica;
                case CuentaEN.CDoc: return pObj.CDocumento;
                case CuentaEN.NDoc: return pObj.NDocumento;
                case CuentaEN.CAux: return pObj.CAuxiliar;
                case CuentaEN.NAux: return pObj.NAuxiliar;
                case CuentaEN.CCenCos: return pObj.CCentroCosto;
                case CuentaEN.NCenCos: return pObj.NCentroCosto;
                case CuentaEN.CAlm: return pObj.CAlmacen;
                case CuentaEN.NAlm: return pObj.NAlmacen;
                case CuentaEN.CAre: return pObj.CArea;
                case CuentaEN.NAre: return pObj.NArea;
                case CuentaEN.CFluCaj: return pObj.CFlujoCaja;
                case CuentaEN.NFluCaj: return pObj.NFlujoCaja;
                case CuentaEN.CAut: return pObj.CAutomatica;
                case CuentaEN.NAut: return pObj.NAutomatica;
                case CuentaEN.CDifCam: return pObj.CDiferenciaCambio;
                case CuentaEN.NDifCam: return pObj.NDiferenciaCambio;
                case CuentaEN.CBan: return pObj.CBanco;
                case CuentaEN.NBan: return pObj.NBanco;
                case CuentaEN.CMon: return pObj.CMoneda;
                case CuentaEN.NMon: return pObj.NMoneda;
                case CuentaEN.CAsiApe: return pObj.CAsientoApertura;
                case CuentaEN.NAsiApe: return pObj.NAsientoApertura;
                case CuentaEN.CAsiCie7: return pObj.CAsientoCierre7;
                case CuentaEN.NAsiCie7: return pObj.NAsientoCierre7;
                case CuentaEN.CAsiCie9: return pObj.CAsientoCierre9;
                case CuentaEN.NAsiCie9: return pObj.NAsientoCierre9;
                case CuentaEN.CodCueAut1: return pObj.CodigoCuentaAutomatica1;
                case CuentaEN.DesCueAut1: return pObj.DescripcionCuentaAutomatica1;
                case CuentaEN.CodCueAut2: return pObj.CodigoCuentaAutomatica2;
                case CuentaEN.DesCueAut2: return pObj.DescripcionCuentaAutomatica2;
                case CuentaEN.CodForCon: return pObj.CodigoFormatoContable;
                case CuentaEN.DesForCon: return pObj.DescripcionFormatoContable;
                case CuentaEN.COriVenCre: return pObj.COrigenVentanaCreacion;
                case CuentaEN.NOriVenCre: return pObj.NOrigenVentanaCreacion;
                case CuentaEN.CEstCue: return pObj.CEstadoCuenta;
                case CuentaEN.NEstCue: return pObj.NEstadoCuenta;
                case CuentaEN.UsuAgr: return pObj.UsuarioAgrega;
                case CuentaEN.FecAgr: return pObj.FechaAgrega.ToString();
                case CuentaEN.UsuMod: return pObj.UsuarioModifica;
                case CuentaEN.FecMod: return pObj.FechaModifica.ToString();

            }

            //retorna
            return iValor;
        }

        public static List<CuentaEN> FiltrarCuentaXTextoEnCualquierPosicion(List<CuentaEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<CuentaEN> iLisRes = new List<CuentaEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (CuentaEN xObj in pLista)
            {
                string iTexto = ObjetoG.ObtenerTexto<CuentaEN>(xObj, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xObj);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<CuentaEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<CuentaEN> pLista)
        {
            //lista resultado
            List<CuentaEN> iLisRes = new List<CuentaEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pLista; }

            //filtar la lista
            iLisRes = CuentaRN.FiltrarCuentaXTextoEnCualquierPosicion(pLista, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveCuenta(CuentaEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.CodigoCuenta;

            //retornar
            return iClave;
        }

        public static CuentaEN EsCuentaValido(CuentaEN pObj)
        {
            //objeto resultado
            CuentaEN iObjEN = new CuentaEN();

            //valida cuando esta vacio
            if (pObj.CodigoCuenta == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = CuentaRN.EsCuentaExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }

        public static CuentaEN EsCuentaActivoValido(CuentaEN pObj)
        {
            //objeto resultado
            CuentaEN iObjEN = new CuentaEN();

            //valida cuando esta vacio
            if (pObj.CodigoCuenta == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = CuentaRN.EsCuentaExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //valida cuando esta desactivada
            CuentaEN iObjDesEN = CuentaRN.ValidaCuandoEstaDesactivada(iObjEN);
            if (iObjDesEN.Adicionales.EsVerdad == false) { return iObjDesEN; }

            //ok           
            return iObjEN;
        }

        public static CuentaEN ValidaCuandoEstaDesactivada(CuentaEN pObj)
        {
            //objeto resultado
            CuentaEN iObjEN = new CuentaEN();

            //validar                 
            if (pObj.CEstadoCuenta == "0")//desactivado
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El(La) Cuenta esta desactivada";
            }

            //ok
            return iObjEN;
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda)
        {
            CuentaAD iObjAD = new CuentaAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            CuentaAD iObjAD = new CuentaAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            CuentaAD iObjAD = new CuentaAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda)
        {
            CuentaAD iObjAD = new CuentaAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            CuentaAD iObjAD = new CuentaAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            CuentaAD iObjAD = new CuentaAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }

        public static string ObtenerNuevoNumeroCuentaAutogenerado(CuentaEN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = CuentaRN.ObtenerMaximoValorEnColumna("CampoDondeBuscar");

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 6);

            //devuelve
            return iNumero;
        }

        public static CuentaEN EsActoAdicionarCuenta(CuentaEN pObj)
        {
            //objeto resultado
            CuentaEN iObjEN = new CuentaEN();

            //ok          
            return iObjEN;
        }

        public static CuentaEN EsActoModificarCuenta(CuentaEN pObj)
        {
            //objeto resultado
            CuentaEN iObjEN = new CuentaEN();

            //valida cuando el codigo no existe
            iObjEN = CuentaRN.EsCuentaExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static CuentaEN EsActoEliminarCuenta(CuentaEN pObj)
        {
            //objeto resultado
            CuentaEN iObjEN = new CuentaEN();

            //valida cuando el codigo no existe
            iObjEN = CuentaRN.EsCuentaExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static CuentaEN BuscarCuenta(string pCampo, string pValor, List<CuentaEN> pLista)
        {
            //objeto resultaddo
            CuentaEN iObjEN = new CuentaEN();

            //recorrer cada objeto
            foreach (CuentaEN xObj in pLista)
            {
                if (CuentaRN.ObtenerValorDeCampo(xObj, pCampo) == pValor)
                {
                    return xObj;
                }
            }

            //devolver
            return iObjEN;
        }

        public static int ObtenerIndiceHabilitaXLongitudCodigoCuenta(string pCodigoCuenta, string pNumeroDigitosAnalitica)
        {
            //valor resultado
            int iValor = 0;

            //obtener indice
            string iLongitudCodigoCuenta = pCodigoCuenta.Trim().Length.ToString();
            if (iLongitudCodigoCuenta == "2")
            {
                iValor = 1;
            }
            else
            {
                if (iLongitudCodigoCuenta == pNumeroDigitosAnalitica)
                {
                    iValor = 2;
                }
                else
                {
                    iValor = 0;
                }
            }

            //devolver
            return iValor;
        }

        public static CuentaEN BuscarCuentaXCodigo(string pCodigoCuenta)
        {
            //asignar parametros
            CuentaEN iCueEN = new CuentaEN();
            iCueEN.CodigoCuenta = pCodigoCuenta;
            iCueEN.ClaveCuenta = CuentaRN.ObtenerClaveCuenta(iCueEN);

            //ejecutar metodo
            return CuentaRN.BuscarCuentaXClave(iCueEN);
        }

        public static List<CuentaEN> ListarCuentaXNroDigitosYEstado(CuentaEN pObj)
        {
            CuentaAD iObjAD = new CuentaAD();
            return iObjAD.ListarCuentaXNroDigitosYEstado(pObj);
        }

        public static List<CuentaEN> ListarCuentaAnalitica(CuentaEN pObj)
        {
            //asignar parametros
            CuentaEN iCueEN = new CuentaEN();
            iCueEN.NumeroDigitosAnalitica = EmpresaRN.BuscarEmpresaDeAcceso().NumeroDigitosAnalitica;
            iCueEN.CEstadoCuenta = string.Empty;
            iCueEN.Adicionales.CampoOrden = pObj.Adicionales.CampoOrden;

            //ejecutar metodo
            return CuentaRN.ListarCuentaXNroDigitosYEstado(iCueEN);
        }

        public static List<CuentaEN> ListarCuentaAnalitica()
        {
            //asignar parametros
            CuentaEN iCueEN = new CuentaEN();
            iCueEN.Adicionales.CampoOrden = CuentaEN.CodCue;

            //ejecutar metodo
            return CuentaRN.ListarCuentaAnalitica(iCueEN);
        }

        public static List<CuentaEN> ListarCuentaAnaliticaActivas(CuentaEN pObj)
        {
            //asignar parametros
            CuentaEN iCueEN = new CuentaEN();
            iCueEN.NumeroDigitosAnalitica = EmpresaRN.BuscarEmpresaDeAcceso().NumeroDigitosAnalitica;
            iCueEN.CEstadoCuenta = "1";//activos
            iCueEN.Adicionales.CampoOrden = pObj.Adicionales.CampoOrden;

            //ejecutar metodo
            return CuentaRN.ListarCuentaXNroDigitosYEstado(iCueEN);
        }

        public static CuentaEN EsCuentaActivoValido(CuentaEN pObj, string pCodigoCuentaExcepcion)
        {
            //objeto resultado
            CuentaEN iObjEN = new CuentaEN();

            //valida cuando esta vacio
            if (pObj.CodigoCuenta == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = CuentaRN.EsCuentaExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //valida cuando esta desactivada
            CuentaEN iObjDesEN = CuentaRN.ValidaCuandoEstaDesactivada(iObjEN);
            if (iObjDesEN.Adicionales.EsVerdad == false) { return iObjDesEN; }

            //valida cuando la cuenta de excepcion esta vacia
            if (pCodigoCuentaExcepcion == string.Empty) { return iObjEN; }

            //valida cuando son la misma cuenta
            CuentaEN iObjIgu = CuentaRN.ValidaCuandoSonLaMismaCuenta(iObjEN.CodigoCuenta, pCodigoCuentaExcepcion);
            if (iObjIgu.Adicionales.EsVerdad == false) { return iObjIgu; }

            //ok           
            return iObjEN;
        }

        public static CuentaEN ValidaCuandoSonLaMismaCuenta(string pCodigoCuenta1, string pCodigoCuenta2)
        {
            //objeto resultado
            CuentaEN iObjEN = new CuentaEN();

            //validar                 
            if (pCodigoCuenta1 == pCodigoCuenta2)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El(La) Cuenta " + pCodigoCuenta2 + " ya esta registrada";
            }

            //ok
            return iObjEN;
        }

        public static List<CuentaEN> ListarCuentaAnaliticaActivas(CuentaEN pObj, string pCodigoCuentaExcepcion)
        {
            //lista resultado
            List<CuentaEN> iLisRes = new List<CuentaEN>();

            //traer todas las cuentas analiticas activas
            List<CuentaEN> iLisCueAnaAct = CuentaRN.ListarCuentaAnaliticaActivas(pObj);

            //recorrer cada objeto
            foreach (CuentaEN xCue in iLisCueAnaAct)
            {
                if (xCue.CodigoCuenta != pCodigoCuentaExcepcion)
                {
                    iLisRes.Add(xCue);
                }
            }

            //devolver
            return iLisRes;
        }

        public static int ObtenerMaximaLongitudCodigoCuenta()
        {
            //valor resultado
            int iValor = 11;

            //traer el numero de digitos analitica
            int iNumeroDigitosAnalitica = Conversion.AInt(EmpresaRN.BuscarEmpresaDeAcceso().NumeroDigitosAnalitica, 0);

            //compara
            if (iValor >= iNumeroDigitosAnalitica)
            {
                iValor = iNumeroDigitosAnalitica;
            }

            //devolver
            return iValor;
        }

        public static List<CuentaEN> ListarCuentaXEmpresaXNroDigitosXEstadoYAnalitica(CuentaEN pObj)
        {
            CuentaAD iObjAD = new CuentaAD();
            return iObjAD.ListarCuentaXEmpresaXNroDigitosXEstadoYAnalitica(pObj);
        }

        public static CuentaEN EsActoAdicionarCopiaPcge()
        {
            //objeto resultado
            CuentaEN iObjEN = new CuentaEN();

            //valida cuando ya se registraron cuentas
            iObjEN = CuentaRN.ValidaCuandoNoHayCuentasPcgeParaCopiar();
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static CuentaEN ValidaCuandoHayCuentas()
        {
            //objeto resultado
            CuentaEN iObjEN = new CuentaEN();

            //validar                 
            List<CuentaEN> iLisCue = CuentaRN.ListarCuenta();
            if (iLisCue.Count != 0)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "Para hacer esta copia , no debe existir ninguna cuenta registrada";
            }

            //ok
            return iObjEN;
        }

        public static CuentaEN ValidaCuandoNoHayCuentasPcgeParaCopiar()
        {
            //objeto resultado
            CuentaEN iObjEN = new CuentaEN();

            //validar                 
            List<CuentaEN> iLisCue = CuentaRN.ListarCuentasParaCopiaPcge();
            if (iLisCue.Count == 0)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "No hay cuentas Pcge para copiar";
            }

            //ok
            return iObjEN;
        }

        public static void CopiarPcge()
        {
            //listar las nuevas cuentas desde Pcge
            List<CuentaEN> iLisCueNue = CuentaRN.ListarCuentasParaCopiaPcge();

            //adicionar
            CuentaRN.AdicionarCuenta(iLisCueNue);
        }

        public static CuentaEN CrearCuentaDesdePcge(PcgeEN pObj)
        {
            //objeto resultado
            CuentaEN iCueEN = new CuentaEN();
            iCueEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iCueEN.CodigoCuenta = pObj.CodigoPcge;
            iCueEN.DescripcionCuenta = pObj.DescripcionPcge;
            iCueEN.NumeroDigitosAnalitica = iCueEN.CodigoCuenta.Length.ToString();
            iCueEN.ClaveCuenta = CuentaRN.ObtenerClaveCuenta(iCueEN);
            iCueEN.COrigenVentanaCreacion = "05";//copia pcge

            //si es de 2 digitos
            if (iCueEN.NumeroDigitosAnalitica == "2")
            {
                iCueEN.CAsientoApertura = "0";
                iCueEN.CAsientoCierre7 = "0";
                iCueEN.CAsientoCierre9 = "0";
            }

            //devolver
            return iCueEN;
        }

        public static List<CuentaEN> ListarNuevasCuentasDesdePcge()
        {
            //lista resultado
            List<CuentaEN> iLisRes = new List<CuentaEN>();

            //traer todas las cuentas pcge
            List<PcgeEN> iLisCuePcge = PcgeRN.ListarPcge();

            //recorrer cada objeto pcge
            foreach (PcgeEN xPcge in iLisCuePcge)
            {
                CuentaEN iCueEN = CuentaRN.CrearCuentaDesdePcge(xPcge);
                iLisRes.Add(iCueEN);
            }

            //devolver
            return iLisRes;
        }

        public static CuentaEN EsActoEliminarCopiaPcge()
        {
            //objeto resultado
            CuentaEN iObjEN = new CuentaEN();

            //valida cuando ya se registraron cuentas
            iObjEN = CuentaRN.ValidaCuandoNoHayCuentasCopiaPcge();
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static CuentaEN ValidaCuandoHayCuentasDeOrigenDiferenteACopiaPcge()
        {
            //objeto resultado
            CuentaEN iObjEN = new CuentaEN();

            //validar                 
            List<CuentaEN> iLisCue = CuentaRN.ListarCuentaDiferentesDeOrigenCopiaPcge();
            if (iLisCue.Count != 0)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "Para eliminar esta copia , no debe existir ninguna cuenta registrada manualmente";
            }

            //ok
            return iObjEN;
        }

        public static CuentaEN ValidaCuandoNoHayCuentasCopiaPcge()
        {
            //objeto resultado
            CuentaEN iObjEN = new CuentaEN();

            //validar                 
            List<CuentaEN> iLisCue = CuentaRN.ListarCuentasCopiaDePcge();
            if (iLisCue.Count == 0)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "No hay cuentas copiadas desde el Pcge";
            }

            //ok
            return iObjEN;
        }

        public static List<CuentaEN> ListarCuentaDiferentesDeOrigenCopiaPcge()
        {
            CuentaAD iObjAD = new CuentaAD();
            return iObjAD.ListarCuentaDiferentesDeOrigenCopiaPcge();
        }

        public static List<CuentaEN> ListarCuentasParaCopiarAEmpresa(string pCodigoEmpresaCopia, string pCodigoEmpresaGuarda)
        {
            //lista resultado
            List<CuentaEN> iLisRes = new List<CuentaEN>();

            //listar los Cuentas de la empresa de donde se quiere copiar
            CuentaEN iCueEN = new CuentaEN();
            iCueEN.CodigoEmpresa = pCodigoEmpresaCopia;
            iCueEN.Adicionales.CampoOrden = CuentaEN.CodCue;
            List<CuentaEN> iLisCueCop = CuentaRN.ListarCuentasDeEmpresa(iCueEN);

            //listar lasCuentas de la empresa a donde se quiere copiar
            iCueEN.CodigoEmpresa = pCodigoEmpresaGuarda;
            List<CuentaEN> iLisCueGua = CuentaRN.ListarCuentasDeEmpresa(iCueEN);

            //obtener las Cuentas que tiene la lista iLisCueCop que no esten en iLisCueGua
            iLisRes = CuentaRN.ObtenerDiferenciaAMenosB(iLisCueCop, iLisCueGua);

            //devolver
            return iLisRes;
        }

        public static List<CuentaEN> ListarCuentasDeEmpresa(CuentaEN pObj)
        {
            CuentaAD iPerAD = new CuentaAD();
            return iPerAD.ListarCuentasDeEmpresa(pObj);
        }

        public static List<CuentaEN> ObtenerDiferenciaAMenosB(List<CuentaEN> pLisCueA, List<CuentaEN> pLisCueB)
        {
            //lista resultado
            List<CuentaEN> iLisRes = new List<CuentaEN>();

            //recorrer cada objeto
            foreach (CuentaEN xCueA in pLisCueA)
            {
                //flag de encontrado
                int iEncontrado = 0;

                //recorre cada objeto
                foreach (CuentaEN xCueB in pLisCueB)
                {
                    if (xCueA.CodigoCuenta == xCueB.CodigoCuenta)
                    {
                        iEncontrado = 1;
                    }
                }

                //si no se encontro se agrega a la lista resultado
                if (iEncontrado == 0)
                {
                    iLisRes.Add(xCueA);
                }
            }

            //devolver
            return iLisRes;
        }

        public static void ModificarVerdadFalsoCuenta(CuentaEN pObj, List<CuentaEN> pLista)
        {
            //lista actualizada
            List<CuentaEN> iLisCue = new List<CuentaEN>();

            //buscamos el objeto en la lista pLista
            foreach (CuentaEN xCue in pLista)
            {
                if (xCue.ClaveCuenta == pObj.ClaveCuenta)
                {
                    xCue.VerdadFalso = pObj.VerdadFalso;
                }
                iLisCue.Add(xCue);
            }

            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisCue);
        }

        public static CuentaEN HayObjetosMarcados(List<CuentaEN> pLista)
        {
            //objeto resultado
            CuentaEN iCueEN = new CuentaEN();

            //sacar las cuotas solo marcadas
            List<CuentaEN> iLisCueMar = CuentaRN.ListarCuentasSoloMarcadas(pLista);

            //si la lista esta vacia entonces no hay marcados
            if (iLisCueMar.Count == 0)
            {
                iCueEN.Adicionales.EsVerdad = false;
                iCueEN.Adicionales.Mensaje = "No hay Cuentas marcadas, no se puede realizar la operacion";
            }

            //ok           
            return iCueEN;
        }

        public static List<CuentaEN> ListarCuentasSoloMarcadas(List<CuentaEN> pLista)
        {
            //lista resultado
            List<CuentaEN> iLisRes = new List<CuentaEN>();

            //la lista tiene objetos para agregar y otros no, por eso solo
            //hay que sacar los chequeados
            foreach (CuentaEN xCue in pLista)
            {
                if (xCue.VerdadFalso == true)
                {
                    iLisRes.Add(xCue);
                }
            }
            return iLisRes;
        }

        public static void AdicionarCuentasPorCopia(string pCodigoEmpresaGuarda, List<CuentaEN> pLisCueMar, List<CuentaEN> pLisCueVal)
        {
            //lista de Cuentas para adicionar
            List<CuentaEN> iLisCueAdi = new List<CuentaEN>();
            List<CuentaBancoEN> iLisCueBanAdi = new List<CuentaBancoEN>();

            //recorrer cada objeto
            foreach (CuentaEN xCue in pLisCueMar)
            {
                //para poder adicionar al objeto xAux, este debe existir en la lista de
                //Cuentas que son validas a grabar en bd(pLisAuxVal)
                bool iExiste = CuentaRN.ExisteClaveCuentaEnLista(xCue.ClaveCuenta, pLisCueVal);
                if (iExiste == false) { continue; }

                //modificar datos
                xCue.CodigoEmpresa = pCodigoEmpresaGuarda;
                xCue.ClaveCuenta = CuentaRN.ObtenerClaveCuenta(xCue);
                xCue.COrigenVentanaCreacion = "02";//Ventana copia empresa

                //agregar a la lista resultado
                iLisCueAdi.Add(xCue);

                //si es cuenta bancaria, entonces creamos un objeto cuenta banco
                if (xCue.CBanco == "1")
                {
                    //obtener su cuenta bancaria apartir de la cuenta
                    CuentaBancoEN iCueBanEN = CuentaBancoRN.ArmarCuentaBanco(xCue);

                    //adicionamos a la lista resultados
                    iLisCueBanAdi.Add(iCueBanEN);
                }
            }

            //luego adicionamos todas las cuentas en bd
            CuentaRN.AdicionarCuenta(iLisCueAdi);

            //adicionamos todas las cuentas bancarias en bd
            CuentaBancoRN.AdicionarCuentaBanco(iLisCueBanAdi);
        }

        public static bool ExisteClaveCuentaEnLista(string pClaveCuenta, List<CuentaEN> pLista)
        {
            //recorrer cada objeto
            foreach (CuentaEN xCue in pLista)
            {
                if (pClaveCuenta == xCue.ClaveCuenta)
                {
                    return true;
                }
            }

            //devolver
            return false;
        }

        public static void MarcarTodos(List<CuentaEN> pLista, bool pVerdadFalso)
        {
            //lista actualizada
            List<CuentaEN> iLisCue = new List<CuentaEN>();

            //buscamos el objeto en la lista pLista
            foreach (CuentaEN xExi in pLista)
            {
                xExi.VerdadFalso = pVerdadFalso;
                iLisCue.Add(xExi);
            }

            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisCue);
        }

        public static CuentaEN EsActoEliminarCopiaDeEmpresa()
        {
            //objeto resultado
            CuentaEN iObjEN = new CuentaEN();

            //valida cuando no hay cuentas copia
            iObjEN = CuentaRN.ValidaCuandoNoHayCuentasCopiaDeEmpresa();
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }



            //ok          
            return iObjEN;
        }

        public static CuentaEN ValidaCuandoNoHayCuentasCopiaDeEmpresa()
        {
            //objeto resultado
            CuentaEN iCueEN = new CuentaEN();

            //validar
            bool iHayValor = CuentaRN.ExisteValorEnColumna(CuentaEN.COriVenCre, "02", CuentaEN.CodEmp, Universal.gCodigoEmpresa);
            if (iHayValor == false)
            {
                iCueEN.Adicionales.EsVerdad = false;
                iCueEN.Adicionales.Mensaje = "No hay Cuentas copiadas en esta empresa";
            }

            //ok
            return iCueEN;
        }

        public static List<CuentaEN> ListarCuentasCopiaDeEmpresa(CuentaEN pObj)
        {
            CuentaAD iObjAD = new CuentaAD();
            return iObjAD.ListarCuentasCopiaDeEmpresa(pObj);
        }

        public static List<CuentaEN> ListarCuentasCopiaDeEmpresa()
        {
            //asignar parametros
            CuentaEN iCueEN = new CuentaEN();
            iCueEN.Adicionales.CampoOrden = CuentaEN.CodCue;

            //ejecutar metodo
            return CuentaRN.ListarCuentasCopiaDeEmpresa(iCueEN);
        }

        public static List<CuentaEN> ListarCuentasCopiaDeEmpresaParaEliminar()
        {
            return CuentaRN.ListarCuentasCopiaDeEmpresa();//xxxxxxxxxxxxx
        }

        public static void EliminarCuentasCopiaDeEmpresa()
        {
            //listar las cuentas que se pueden eliminar
            List<CuentaEN> iLisCue = CuentaRN.ListarCuentasCopiaDeEmpresaParaEliminar();

            //listar las cuentas bancos que hay en las cuentas
            List<CuentaBancoEN> iLisCueBan = CuentaBancoRN.ListarCuentasBanco(iLisCue);

            //eliminar cuentas
            CuentaRN.EliminarCuenta(iLisCue);

            //eliminar cuentas banco
            CuentaBancoRN.EliminarCuentaBanco(iLisCueBan);
        }

        public static List<CuentaEN> ListarCuentasParaCopiaPcge()
        {
            //lista resultado
            List<CuentaEN> iLisRes = new List<CuentaEN>();

            //transformar todas las cuentas Pcge a cuentas
            List<CuentaEN> iLisCuePcge = CuentaRN.ListarNuevasCuentasDesdePcge();

            //traer a las cuentas que ya estan registradas en la empresa
            List<CuentaEN> iLisCueReg = CuentaRN.ListarCuenta();

            //sacar solo las cuentas pcge de las cuentas registradas
            iLisRes = CuentaRN.ObtenerDiferenciaAMenosB(iLisCuePcge, iLisCueReg);

            //devolver
            return iLisRes;
        }

        public static List<CuentaEN> ListarCuentasCopiaDePcge(CuentaEN pObj)
        {
            CuentaAD iObjAD = new CuentaAD();
            return iObjAD.ListarCuentasCopiaDePcge(pObj);
        }

        public static List<CuentaEN> ListarCuentasCopiaDePcge()
        {
            //asignar parametros
            CuentaEN iCueEN = new CuentaEN();
            iCueEN.Adicionales.CampoOrden = CuentaEN.CodCue;

            //ejecutar metodo
            return CuentaRN.ListarCuentasCopiaDePcge(iCueEN);
        }

        public static void EliminarCuentasCopiaDePcge()
        {
            //listar las cuentas que se pueden eliminar
            List<CuentaEN> iLisCue = CuentaRN.ListarCuentasCopiaDePcge();

            //eliminar cuentas
            CuentaRN.EliminarCuenta(iLisCue);
        }

        public static List<string> ListarCodigosCuentas()
        {
            //asignar parametros
            List<CuentaEN> iLisCue = CuentaRN.ListarCuenta();

            //ejecutar metodo
            return CuentaRN.ListarDatosCampo(CuentaEN.CodCue, iLisCue);
        }

        public static List<string> ListarCodigosCuentasAnaliticas()
        {
            //asignar parametros
            List<CuentaEN> iLisCue = CuentaRN.ListarCuentaAnalitica();

            //ejecutar metodo
            return CuentaRN.ListarDatosCampo(CuentaEN.CodCue, iLisCue);
        }

        public static List<string> ListarDatosCampo(string pNombreCampo, List<CuentaEN> pListaCuentas)
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //recorrer cada objeto
            foreach (CuentaEN xCue in pListaCuentas)
            {
                iLisRes.Add(CuentaRN.ObtenerValorDeCampo(xCue, pNombreCampo));
            }

            //devolver
            return iLisRes;
        }

        public static void ActualizarCuentasDeImportacionExcelParaGrabar(List<CuentaEN> pListaCuentasExcel)
        {
            //traer el numero de digitos analitica de la empresa
            int iNumeroDigitosAnalitica = EmpresaRN.ObtenerNumeroDigitosAnaliticaEmpresaDeAcceso();

            //recorrer cada cuenta
            foreach (CuentaEN xCue in pListaCuentasExcel)
            {
                //obtener el numero de digitos de la cuenta
                int iNumeroDigitosCuenta = xCue.CodigoCuenta.Trim().Length;

                //segun longitud
                if (iNumeroDigitosCuenta == 2)
                {
                    CuentaRN.ActualizarCuenta2DigitosImportacionExcelParaGrabar(xCue);
                }
                else
                {
                    if (iNumeroDigitosCuenta == iNumeroDigitosAnalitica)
                    {
                        CuentaRN.ActualizarCuentaAnaliticaImportacionExcelParaGrabar(xCue);
                    }
                    else
                    {
                        CuentaRN.ActualizarCuentaNormalImportacionExcelParaGrabar(xCue);
                    }
                }
            }
        }

        public static void ActualizarCuenta2DigitosImportacionExcelParaGrabar(CuentaEN pCue)
        {
            //limpiando datos
            pCue.CDocumento = string.Empty;
            pCue.CAuxiliar = string.Empty;
            pCue.CCentroCosto = string.Empty;
            pCue.CAlmacen = string.Empty;
            pCue.CArea = string.Empty;
            pCue.CFlujoCaja = string.Empty;
            pCue.CAutomatica = string.Empty;
            pCue.CDiferenciaCambio = string.Empty;
            pCue.CBanco = string.Empty;
            pCue.CMoneda = string.Empty;
            pCue.CodigoCuentaAutomatica1 = string.Empty;
            pCue.CodigoCuentaAutomatica2 = string.Empty;
            pCue.CodigoFormatoContable = string.Empty;
        }

        public static void ActualizarCuentaAnaliticaImportacionExcelParaGrabar(CuentaEN pCue)
        {
            //limpiando datos
            pCue.CAsientoApertura = string.Empty;
            pCue.CAsientoCierre7 = string.Empty;
            pCue.CAsientoCierre9 = string.Empty;
            pCue.CDiferenciaCambio = Cadena.CompararDosValores(pCue.CMoneda, "0", string.Empty, pCue.CDiferenciaCambio);
        }

        public static void ActualizarCuentaNormalImportacionExcelParaGrabar(CuentaEN pCue)
        {
            //limpiando datos
            pCue.CDocumento = string.Empty;
            pCue.CAuxiliar = string.Empty;
            pCue.CCentroCosto = string.Empty;
            pCue.CAlmacen = string.Empty;
            pCue.CArea = string.Empty;
            pCue.CFlujoCaja = string.Empty;
            pCue.CAutomatica = string.Empty;
            pCue.CDiferenciaCambio = string.Empty;
            pCue.CBanco = string.Empty;
            pCue.CMoneda = string.Empty;
            pCue.CAsientoApertura = string.Empty;
            pCue.CAsientoCierre7 = string.Empty;
            pCue.CAsientoCierre9 = string.Empty;
            pCue.CodigoCuentaAutomatica1 = string.Empty;
            pCue.CodigoCuentaAutomatica2 = string.Empty;
            pCue.CodigoFormatoContable = string.Empty;
        }

        public static void AdicionarCuentasPorImportacionExcel(List<CuentaEN> pLista)
        {
            //lista de Cuentas para adicionar
            List<CuentaEN> iLisCueAdi = new List<CuentaEN>();
            List<CuentaBancoEN> iLisCueBanAdi = new List<CuentaBancoEN>();

            //traer todas las cuentas de la empresa actual
            List<CuentaEN> iLisCueEmp = CuentaRN.ListarCuenta();

            //recorrer cada objeto
            foreach (CuentaEN xCue in pLista)
            {
                //para poder adicionar al objeto xAux, este no debe existir en la lista de
                //Cuentas que son validas a grabar en bd
                bool iExiste = CuentaRN.ExisteClaveCuentaEnLista(xCue.ClaveCuenta, iLisCueEmp);
                if (iExiste == true) { continue; }

                //agregar a la lista resultado
                iLisCueAdi.Add(xCue);

                //si es cuenta bancaria, entonces creamos un objeto cuenta banco
                if (xCue.CBanco == "1")
                {
                    //obtener su cuenta bancaria apartir de la cuenta
                    CuentaBancoEN iCueBanEN = CuentaBancoRN.ArmarCuentaBanco(xCue);

                    //adicionamos a la lista resultados
                    iLisCueBanAdi.Add(iCueBanEN);
                }
            }

            //luego adicionamos todas las cuentas en bd
            CuentaRN.AdicionarCuenta(iLisCueAdi);

            //adicionamos todas las cuentas bancarias en bd
            CuentaBancoRN.AdicionarCuentaBanco(iLisCueBanAdi);
        }

        public static CuentaEN EsActoEliminarImportacionExcel()
        {
            //objeto resultado
            CuentaEN iObjEN = new CuentaEN();

            //valida cuando no hay cuentas copia
            iObjEN = CuentaRN.ValidaCuandoNoHayCuentasImportadasDeExcel();
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }



            //ok          
            return iObjEN;
        }

        public static CuentaEN ValidaCuandoNoHayCuentasImportadasDeExcel()
        {
            //objeto resultado
            CuentaEN iCueEN = new CuentaEN();

            //validar
            bool iHayValor = CuentaRN.ExisteValorEnColumna(CuentaEN.COriVenCre, "03", CuentaEN.CodEmp, Universal.gCodigoEmpresa);
            if (iHayValor == false)
            {
                iCueEN.Adicionales.EsVerdad = false;
                iCueEN.Adicionales.Mensaje = "No hay Cuentas importadas de excel en esta empresa";
            }

            //ok
            return iCueEN;
        }

        public static void EliminarCuentasImportadasExcel()
        {
            //listar las cuentas que se pueden eliminar
            List<CuentaEN> iLisCue = CuentaRN.ListarCuentasImportadasExcelParaEliminar();

            //listar las cuentas bancos que hay en las cuentas
            List<CuentaBancoEN> iLisCueBan = CuentaBancoRN.ListarCuentasBanco(iLisCue);

            //eliminar cuentas
            CuentaRN.EliminarCuenta(iLisCue);

            //eliminar cuentas banco
            CuentaBancoRN.EliminarCuentaBanco(iLisCueBan);
        }

        public static List<CuentaEN> ListarCuentasImportadasExcel(CuentaEN pObj)
        {
            CuentaAD iObjAD = new CuentaAD();
            return iObjAD.ListarCuentasImportadasExcel(pObj);
        }

        public static List<CuentaEN> ListarCuentasImportadasExcel()
        {
            //asignar parametros
            CuentaEN iCueEN = new CuentaEN();
            iCueEN.Adicionales.CampoOrden = CuentaEN.CodCue;

            //ejecutar metodo
            return CuentaRN.ListarCuentasImportadasExcel(iCueEN);
        }

        public static List<CuentaEN> ListarCuentasImportadasExcelParaEliminar()
        {
            return CuentaRN.ListarCuentasImportadasExcel();//xxxxxxxxxxxxx
        }

        public static List<CuentaEN> ListarCuentasParaRegistroCompraPV(CuentaEN pObj)
        {
            CuentaAD iObjAD = new CuentaAD();
            return iObjAD.ListarCuentasParaRegistroCompraPV(pObj);
        }

        public static List<CuentaEN> ListarCuentasParaRegistroCompraPVMoneda(CuentaEN pObj)
        {
            CuentaAD iObjAD = new CuentaAD();
            return iObjAD.ListarCuentasParaRegistroCompraPVMoneda(pObj);
        }

        public static CuentaEN EsCuentaParaRegistroCompraPVValido(CuentaEN pObj)
        {
            //objeto resultado
            CuentaEN iObjEN = new CuentaEN();

            //valida cuando esta vacio
            if (pObj.CodigoCuenta == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = CuentaRN.EsCuentaExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //valida cuando esta desactivada
            CuentaEN iObjComEN = CuentaRN.ValidaCuandoNoEsParaRegistroCompraPV(iObjEN);
            if (iObjComEN.Adicionales.EsVerdad == false) { return iObjComEN; }

            //valida cuando esta desactivada
            CuentaEN iObjDesEN = CuentaRN.ValidaCuandoEstaDesactivada(iObjEN);
            if (iObjDesEN.Adicionales.EsVerdad == false) { return iObjDesEN; }

            //ok           
            return iObjEN;
        }

        public static CuentaEN ValidaCuandoNoEsParaRegistroCompraPV(CuentaEN pObj)
        {
            //objeto resultado
            CuentaEN iObjEN = new CuentaEN();

            //validar                 
            if (pObj.CRegistro != "0")//compra
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El(La) Cuenta no es para compras PV";
            }

            //ok
            return iObjEN;
        }

        public static List<CuentaEN> ListarCuentasParaRegistroCompraVV(CuentaEN pObj)
        {
            CuentaAD iObjAD = new CuentaAD();
            return iObjAD.ListarCuentasParaRegistroCompraVV(pObj);
        }

        public static CuentaEN EsCuentaParaRegistroCompraVVValido(CuentaEN pObj)
        {
            //objeto resultado
            CuentaEN iObjEN = new CuentaEN();

            //valida cuando esta vacio
            if (pObj.CodigoCuenta == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = CuentaRN.EsCuentaExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //valida cuando esta desactivada
            CuentaEN iObjComEN = CuentaRN.ValidaCuandoNoEsParaRegistroCompraVV(iObjEN);
            if (iObjComEN.Adicionales.EsVerdad == false) { return iObjComEN; }

            //valida cuando esta desactivada
            CuentaEN iObjDesEN = CuentaRN.ValidaCuandoEstaDesactivada(iObjEN);
            if (iObjDesEN.Adicionales.EsVerdad == false) { return iObjDesEN; }

            //ok           
            return iObjEN;
        }

        public static CuentaEN ValidaCuandoNoEsParaRegistroCompraVV(CuentaEN pObj)
        {
            //objeto resultado
            CuentaEN iObjEN = new CuentaEN();

            //validar                 
            if (pObj.CRegistro != "1")//compra
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El(La) Cuenta no es para compras VV";
            }

            //ok
            return iObjEN;
        }

        public static CuentaEN ObtenerCuentaIGVDeEmpresaAcceso()
        {
            //traer a la empresa de acceso
            EmpresaEN iEmpEN = EmpresaRN.BuscarEmpresaDeAcceso();

            //traer a la cuenta igv
            CuentaEN iCueEN = BuscarCuentaXCodigo(iEmpEN.CuentaIgv);

            //devolver
            return iCueEN;
        }

        public static List<CuentaEN> ListarCuentasParaRegistroCompraEspecial(CuentaEN pObj)
        {
            //asignar parametros
            CuentaEN iCueEN = new CuentaEN();
            iCueEN.CodigoCuenta = CuentaRN.ObtenerCuentaIGVDeEmpresaAcceso().CodigoCuenta;
            iCueEN.Adicionales.CampoOrden = pObj.Adicionales.CampoOrden;

            //ejecutar metodo
            CuentaAD iObjAD = new CuentaAD();
            return iObjAD.ListarCuentasParaRegistroCompraEspecial(iCueEN);
        }

        public static List<CuentaEN> ListarCuentasParaRegistroCompraEspecial()
        {
            //asignar parametros
            CuentaEN iCueEN = new CuentaEN();            
            iCueEN.Adicionales.CampoOrden = CuentaEN.CodCue;

            //ejecutar metodo            
            return ListarCuentasParaRegistroCompraEspecial(iCueEN);
        }

        public static List<CuentaEN> ListarCuentasParaRegistroCompraDetalle(CuentaEN pObj, string pTipoCompra)
        {
            //segun tipo compra
            if (pTipoCompra == ItemGEN.TipoCompra_Normal)
            {
                return ListarCuentasParaRegistroCompraVV(pObj);
            }
            else
            {
                return ListarCuentasParaRegistroCompraEspecial(pObj);
            }
        }

        public static CuentaEN EsCuentaParaRegistroCompraEspecialValido(CuentaEN pObj)
        {
            //objeto resultado
            CuentaEN iObjEN = new CuentaEN();
            
            //valida cuando esta vacio
            if (pObj.CodigoCuenta == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = CuentaRN.EsCuentaExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //valida cuando esta desactivada
            CuentaEN iObjComEN = CuentaRN.ValidaCuandoNoEsParaRegistroCompraEspecial(iObjEN);
            if (iObjComEN.Adicionales.EsVerdad == false) { return iObjComEN; }

            //valida cuando esta desactivada
            CuentaEN iObjDesEN = CuentaRN.ValidaCuandoEstaDesactivada(iObjEN);
            if (iObjDesEN.Adicionales.EsVerdad == false) { return iObjDesEN; }

            //ok           
            return iObjEN;
        }

        public static CuentaEN ValidaCuandoNoEsParaRegistroCompraEspecial(CuentaEN pObj)
        {
            //objeto resultado
            CuentaEN iObjEN = new CuentaEN();

            //validar     
            List<CuentaEN> iLisCueComEsp = ListarCuentasParaRegistroCompraEspecial();
            bool iExiste = ListaG.Existe<CuentaEN>(iLisCueComEsp, CuentaEN.CodCue, pObj.CodigoCuenta);
            if (iExiste == false)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El(La) Cuenta no es para compra especial";
            }

            //ok
            return iObjEN;
        }

        public static CuentaEN EsCuentaParaRegistroCompraDetalleValido(CuentaEN pObj, string pTipoCompra)
        {
            if (pTipoCompra == ItemGEN.TipoCompra_Normal)
            {
                return EsCuentaParaRegistroCompraVVValido(pObj);
            }
            else
            {
                return EsCuentaParaRegistroCompraEspecialValido(pObj);
            }
        }

    }
}
