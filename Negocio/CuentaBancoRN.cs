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
    public class CuentaBancoRN
    {

        public static CuentaBancoEN EnBlanco()
        {
            CuentaBancoEN iObjEN = new CuentaBancoEN();
            return iObjEN;
        }

        public static void AdicionarCuentaBanco(List<CuentaBancoEN> pLista)
        {
            CuentaBancoAD iObjAD = new CuentaBancoAD();
            iObjAD.AdicionarCuentaBanco(pLista);
        }

        public static void AdicionarCuentaBanco(CuentaBancoEN pObj)
        {
            //Asignar parametros
            List<CuentaBancoEN> iLisObj = new List<CuentaBancoEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            CuentaBancoRN.AdicionarCuentaBanco(iLisObj);
        }

        public static void ModificarCuentaBanco(List<CuentaBancoEN> pLista)
        {
            CuentaBancoAD iObjAD = new CuentaBancoAD();
            iObjAD.ModificarCuentaBanco(pLista);
        }

        public static void ModificarCuentaBanco(CuentaBancoEN pObj)
        {
            //Asignar parametros
            List<CuentaBancoEN> iLisObj = new List<CuentaBancoEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            CuentaBancoRN.ModificarCuentaBanco(iLisObj);
        }

        public static void EliminarCuentaBanco(List<CuentaBancoEN> pLista)
        {
            CuentaBancoAD iObjAD = new CuentaBancoAD();
            iObjAD.EliminarCuentaBanco(pLista);
        }

        public static void EliminarCuentaBanco(CuentaBancoEN pObj)
        {
            //Asignar parametros
            List<CuentaBancoEN> iLisObj = new List<CuentaBancoEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            CuentaBancoRN.EliminarCuentaBanco(iLisObj);
        }

        public static List<CuentaBancoEN> ListarCuentaBanco(CuentaBancoEN pObj)
        {
            CuentaBancoAD iObjAD = new CuentaBancoAD();
            return iObjAD.ListarCuentaBanco(pObj);
        }

        public static List<CuentaBancoEN> ListarCuentaBancoPorMoneda(CuentaBancoEN pObj)
        {
            CuentaBancoAD iObjAD = new CuentaBancoAD();
            return iObjAD.ListarCuentaBancoPorMoneda(pObj);
        }

        public static List<CuentaBancoEN> ListarCuentaBanco()
        {
            //asignar parametros
            CuentaBancoEN iObjEN = new CuentaBancoEN();
            iObjEN.Adicionales.CampoOrden = CuentaBancoEN.ClaCueBan;

            //ejecutar metodo
            return CuentaBancoRN.ListarCuentaBanco(iObjEN);
        }

        public static CuentaBancoEN BuscarCuentaBancoXClave(CuentaBancoEN pObj)
        {
            CuentaBancoAD iObjAD = new CuentaBancoAD();
            return iObjAD.BuscarCuentaBancoXClave(pObj);
        }

        public static CuentaBancoEN EsCuentaBancoExistente(CuentaBancoEN pObj)
        {
            //objeto resultado
            CuentaBancoEN iObjEN = new CuentaBancoEN();

            pObj.ClaveCuentaBanco = CuentaBancoRN.ObtenerClaveCuentaBanco(pObj);

            //validar si existe en b.d
            iObjEN = CuentaBancoRN.BuscarCuentaBancoXClave(pObj);
            if (iObjEN.ClaveCuentaBanco == string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El Registro seleccionado no existe";
            }

            //ok  
            return iObjEN;
        }

        public static CuentaBancoEN EsCodigoCuentaBancoDisponible(CuentaBancoEN pObj)
        {
            //objeto resultado
            CuentaBancoEN iObjEN = new CuentaBancoEN();

            //valida cuando esta vacio
            if (pObj.CodigoCuentaBanco == string.Empty) { return iObjEN; }

            //validar si existe
            iObjEN = CuentaBancoRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }

        public static CuentaBancoEN ValidaCuandoCodigoYaExiste(CuentaBancoEN pObj)
        {
            //objeto resultado
            CuentaBancoEN iObjEN = new CuentaBancoEN();

            //validar
            iObjEN = CuentaBancoRN.BuscarCuentaBancoXClave(pObj);
            if (iObjEN.ClaveCuentaBanco != string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "Este codigo ya existe";
            }

            //ok  
            return iObjEN;
        }

        public static string ObtenerValorDeCampo(CuentaBancoEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case CuentaBancoEN.ClaObj: return pObj.ClaveObjeto;
                case CuentaBancoEN.ClaCueBan: return pObj.ClaveCuentaBanco;
                case CuentaBancoEN.CodEmp: return pObj.CodigoEmpresa;
                case CuentaBancoEN.NomEmp: return pObj.NombreEmpresa;
                case CuentaBancoEN.CodCueBan: return pObj.CodigoCuentaBanco;
                case CuentaBancoEN.DesCueBan: return pObj.DescripcionCuentaBanco;
                case CuentaBancoEN.CMon: return pObj.CMoneda;
                case CuentaBancoEN.NMon: return pObj.NMoneda;
                case CuentaBancoEN.CodBan: return pObj.CodigoBanco;
                case CuentaBancoEN.NomBan: return pObj.NombreBanco;
                case CuentaBancoEN.NumCueBan: return pObj.NumeroCuentaBanco;
                case CuentaBancoEN.CTip: return pObj.CTipo;
                case CuentaBancoEN.NTip: return pObj.NTipo;
                case CuentaBancoEN.SalCueBan: return pObj.SaldoCuentaBanco.ToString();
                case CuentaBancoEN.COriVenCre: return pObj.COrigenVentanaCreacion;
                case CuentaBancoEN.NOriVenCre: return pObj.NOrigenVentanaCreacion;
                case CuentaBancoEN.CEstCueBan: return pObj.CEstadoCuentaBanco;
                case CuentaBancoEN.NEstCueBan: return pObj.NEstadoCuentaBanco;
                case CuentaBancoEN.UsuAgr: return pObj.UsuarioAgrega;
                case CuentaBancoEN.FecAgr: return pObj.FechaAgrega.ToString();
                case CuentaBancoEN.UsuMod: return pObj.UsuarioModifica;
                case CuentaBancoEN.FecMod: return pObj.FechaModifica.ToString();

            }

            //retorna
            return iValor;
        }

        public static List<CuentaBancoEN> FiltrarCuentaBancoXTextoEnCualquierPosicion(List<CuentaBancoEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<CuentaBancoEN> iLisRes = new List<CuentaBancoEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (CuentaBancoEN xObj in pLista)
            {
                string iTexto = CuentaBancoRN.ObtenerValorDeCampo(xObj, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xObj);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<CuentaBancoEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<CuentaBancoEN> pLista)
        {
            //lista resultado
            List<CuentaBancoEN> iLisRes = new List<CuentaBancoEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pLista; }

            //filtar la lista
            iLisRes = CuentaBancoRN.FiltrarCuentaBancoXTextoEnCualquierPosicion(pLista, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveCuentaBanco(CuentaBancoEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.CodigoCuentaBanco;

            //retornar
            return iClave;
        }

        public static CuentaBancoEN EsCuentaBancoValido(CuentaBancoEN pObj)
        {
            //objeto resultado
            CuentaBancoEN iObjEN = new CuentaBancoEN();

            //valida cuando esta vacio
            if (pObj.CodigoCuentaBanco == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = CuentaBancoRN.EsCodigoCuentaBancoDisponible(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }

        public static CuentaBancoEN EsCuentaBancoActivoValido(CuentaBancoEN pObj)
        {
            //objeto resultado
            CuentaBancoEN iObjEN = new CuentaBancoEN();

            //valida cuando esta vacio
            if (pObj.CodigoCuentaBanco == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = CuentaBancoRN.EsCuentaBancoExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //valida cuando esta desactivada
            CuentaBancoEN iObjDesEN = CuentaBancoRN.ValidaCuandoEstaDesactivada(iObjEN);
            if (iObjDesEN.Adicionales.EsVerdad == false) { return iObjDesEN; }

            //ok           
            return iObjEN;
        }

        public static CuentaBancoEN ValidaCuandoEstaDesactivada(CuentaBancoEN pObj)
        {
            //objeto resultado
            CuentaBancoEN iObjEN = new CuentaBancoEN();

            //validar                 
            if (pObj.CEstadoCuentaBanco == "0")//desactivado
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El(La) CuentaBanco esta desactivada";
            }

            //ok
            return iObjEN;
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda)
        {
            CuentaBancoAD iObjAD = new CuentaBancoAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            CuentaBancoAD iObjAD = new CuentaBancoAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            CuentaBancoAD iObjAD = new CuentaBancoAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda)
        {
            CuentaBancoAD iObjAD = new CuentaBancoAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            CuentaBancoAD iObjAD = new CuentaBancoAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            CuentaBancoAD iObjAD = new CuentaBancoAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }

        public static string ObtenerNuevoNumeroCuentaBancoAutogenerado(CuentaBancoEN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = CuentaBancoRN.ObtenerMaximoValorEnColumna("CampoDondeBuscar");

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 6);

            //devuelve
            return iNumero;
        }

        public static CuentaBancoEN EsActoAdicionarCuentaBanco(CuentaBancoEN pObj)
        {
            //objeto resultado
            CuentaBancoEN iObjEN = new CuentaBancoEN();

            //ok          
            return iObjEN;
        }

        public static CuentaBancoEN EsActoModificarCuentaBanco(CuentaBancoEN pObj)
        {
            //objeto resultado
            CuentaBancoEN iObjEN = new CuentaBancoEN();

            //valida cuando el codigo no existe
            iObjEN = CuentaBancoRN.EsCuentaBancoExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static CuentaBancoEN EsActoEliminarCuentaBanco(CuentaBancoEN pObj)
        {
            //objeto resultado
            CuentaBancoEN iObjEN = new CuentaBancoEN();

            //valida cuando el codigo no existe
            iObjEN = CuentaBancoRN.EsCuentaBancoExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static CuentaBancoEN BuscarCuentaBanco(string pCampo, string pValor, List<CuentaBancoEN> pLista)
        {
            //objeto resultaddo
            CuentaBancoEN iObjEN = new CuentaBancoEN();

            //recorrer cada objeto
            foreach (CuentaBancoEN xObj in pLista)
            {
                if (CuentaBancoRN.ObtenerValorDeCampo(xObj, pCampo) == pValor)
                {
                    return xObj;
                }
            }

            //devolver
            return iObjEN;
        }

        public static CuentaBancoEN ArmarCuentaBanco(CuentaEN pObj)
        {
            //creamos un objeto en blanco
            CuentaBancoEN iCueBanEN = new CuentaBancoEN();

            //pasamos datos
            iCueBanEN.CodigoEmpresa = pObj.CodigoEmpresa;
            iCueBanEN.CodigoCuentaBanco = pObj.CodigoCuenta;
            iCueBanEN.DescripcionCuentaBanco = pObj.DescripcionCuenta;
            iCueBanEN.CMoneda = pObj.CMoneda;
            iCueBanEN.ClaveCuentaBanco = CuentaBancoRN.ObtenerClaveCuentaBanco(iCueBanEN);

            //devolver
            return iCueBanEN;
        }

        public static void AdicionarCuentaBanco(CuentaEN pObj)
        {
            //creamos la cuenta banco desde su cuenta
            CuentaBancoEN iCueBanEN = CuentaBancoRN.ArmarCuentaBanco(pObj);

            //adicionar
            CuentaBancoRN.AdicionarCuentaBanco(iCueBanEN);
        }

        public static void AccionAdicionarCuentaBanco(CuentaEN pObj)
        {
            //para poder adicionar una cuentabanco desde una cuenta,este debe estar marcado con
            //banco igual a "si"
            if (pObj.CBanco == "1")
            {
                CuentaBancoRN.AdicionarCuentaBanco(pObj);
            }
        }

        public static void AccionModificarCuentaBanco(CuentaEN pObj)
        {
            //para poder adicionar una cuentabanco desde una cuenta,este debe estar marcado con
            //banco igual a "si"
            if (pObj.CBanco == "1")
            {
                //solo si no existe se crea la cuentaBanco
                CuentaBancoEN iCueBanEN = CuentaBancoRN.EsCuentaBancoExistente(pObj);
                if (iCueBanEN.Adicionales.EsVerdad == false)
                {
                    CuentaBancoRN.AdicionarCuentaBanco(pObj);
                }
                else
                {
                    CuentaBancoRN.ModificarCuentaBanco(pObj, iCueBanEN);
                }
            }
            else
            {
                if (pObj.CBanco == "0")
                {
                    CuentaBancoRN.EliminarCuentaBanco(pObj);
                }
            }
        }

        public static void EliminarCuentaBanco(CuentaEN pObj)
        {
            //asignar parametros
            CuentaBancoEN iCueBanEN = new CuentaBancoEN();
            iCueBanEN.ClaveCuentaBanco = pObj.ClaveCuenta;

            //ejecutar metodo
            CuentaBancoRN.EliminarCuentaBanco(iCueBanEN);
        }

        public static CuentaBancoEN EsCuentaBancoExistente(CuentaEN pObj)
        {
            //objeto resultado
            CuentaBancoEN iObjEN = new CuentaBancoEN();

            //validar si existe en b.d
            CuentaBancoEN iCueBanEN = new CuentaBancoEN();
            iCueBanEN.ClaveCuentaBanco = pObj.ClaveCuenta;
            iObjEN = CuentaBancoRN.EsCuentaBancoExistente(iCueBanEN);
            if (iObjEN.ClaveCuentaBanco == string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El Registro seleccionado no existe";
            }

            //ok  
            return iObjEN;
        }

        public static void AccionEliminarCuentaBanco(CuentaEN pObj)
        {
            //para poder eliminar una cuentabanco desde una cuenta,este debe estar marcado con
            //banco igual a "si"
            if (pObj.CBanco == "1")
            {
                CuentaBancoRN.EliminarCuentaBanco(pObj);
            }
        }

        public static List<CuentaBancoEN> ListarCuentasBanco(List<CuentaEN> pLisCue)
        {
            //lista resultado
            List<CuentaBancoEN> iLisRes = new List<CuentaBancoEN>();

            //recorrer cada cuenta
            foreach (CuentaEN xCue in pLisCue)
            {
                if (xCue.CBanco == "1")
                {
                    //creamos un objeto cuentabanco
                    CuentaBancoEN iCueBanEN = CuentaBancoRN.ArmarCuentaBanco(xCue);

                    //adicionamos a la lista resultado
                    iLisRes.Add(iCueBanEN);
                }
            }

            //devolver
            return iLisRes;
        }

        public static void ModificarCuentaBanco(CuentaEN pCue, CuentaBancoEN pCueBan)
        {
            //actualizar datos
            pCueBan.DescripcionCuentaBanco = pCue.DescripcionCuenta;
            pCueBan.CMoneda = pCue.CMoneda;

            //adicionar
            CuentaBancoRN.ModificarCuentaBanco(pCueBan);
        }

    }
}
