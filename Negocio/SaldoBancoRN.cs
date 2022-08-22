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
    public class SaldoBancoRN
    {

        public static SaldoBancoEN EnBlanco()
        {
            SaldoBancoEN iObjEN = new SaldoBancoEN();
            return iObjEN;
        }

        public static void AdicionarSaldoBanco(List<SaldoBancoEN> pLista)
        {
            SaldoBancoAD iObjAD = new SaldoBancoAD();
            iObjAD.AdicionarSaldoBanco(pLista);
        }

        public static void AdicionarSaldoBanco(SaldoBancoEN pObj)
        {
            //Asignar parametros
            List<SaldoBancoEN> iLisObj = new List<SaldoBancoEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            SaldoBancoRN.AdicionarSaldoBanco(iLisObj);
        }

        public static void ModificarSaldoBanco(List<SaldoBancoEN> pLista)
        {
            SaldoBancoAD iObjAD = new SaldoBancoAD();
            iObjAD.ModificarSaldoBanco(pLista);
        }

        public static void ModificarSaldoBanco(SaldoBancoEN pObj)
        {
            //Asignar parametros
            List<SaldoBancoEN> iLisObj = new List<SaldoBancoEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            SaldoBancoRN.ModificarSaldoBanco(iLisObj);
        }

        public static void EliminarSaldoBanco(List<SaldoBancoEN> pLista)
        {
            SaldoBancoAD iObjAD = new SaldoBancoAD();
            iObjAD.EliminarSaldoBanco(pLista);
        }

        public static void EliminarSaldoBanco(SaldoBancoEN pObj)
        {
            //Asignar parametros
            List<SaldoBancoEN> iLisObj = new List<SaldoBancoEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            SaldoBancoRN.EliminarSaldoBanco(iLisObj);
        }

        public static List<SaldoBancoEN> ListarSaldoBanco(SaldoBancoEN pObj)
        {
            SaldoBancoAD iObjAD = new SaldoBancoAD();
            return iObjAD.ListarSaldoBanco(pObj);
        }

        public static List<SaldoBancoEN> ListarSaldoBanco()
        {
            //asignar parametros
            SaldoBancoEN iObjEN = new SaldoBancoEN();
            iObjEN.Adicionales.CampoOrden = SaldoBancoEN.ClaSalBan;

            //ejecutar metodo
            return SaldoBancoRN.ListarSaldoBanco(iObjEN);
        }

        public static SaldoBancoEN BuscarSaldoBancoXClave(SaldoBancoEN pObj)
        {
            SaldoBancoAD iObjAD = new SaldoBancoAD();
            return iObjAD.BuscarSaldoBancoXClave(pObj);
        }

        public static SaldoBancoEN EsSaldoBancoExistente(SaldoBancoEN pObj)
        {
            //objeto resultado
            SaldoBancoEN iObjEN = new SaldoBancoEN();

            //validar si existe en b.d
            iObjEN = SaldoBancoRN.BuscarSaldoBancoXClave(pObj);
            if (iObjEN.ClaveSaldoBanco == string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El Registro seleccionado no existe";
            }

            //ok  
            return iObjEN;
        }

        public static SaldoBancoEN EsCodigoSaldoBancoDisponible(SaldoBancoEN pObj)
        {
            //objeto resultado
            SaldoBancoEN iObjEN = new SaldoBancoEN();

            //valida cuando esta vacio
            if (pObj.AñoSaldoBanco == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CodigoCuentaBanco == string.Empty) { return iObjEN; }

            //validar si existe
            iObjEN = SaldoBancoRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }

        public static SaldoBancoEN ValidaCuandoCodigoYaExiste(SaldoBancoEN pObj)
        {
            //objeto resultado
            SaldoBancoEN iObjEN = new SaldoBancoEN();

            //validar
            iObjEN = SaldoBancoRN.BuscarSaldoBancoXClave(pObj);
            if (iObjEN.ClaveSaldoBanco != string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "Este codigo ya existe";
            }

            //ok  
            return iObjEN;
        }

        public static string ObtenerValorDeCampo(SaldoBancoEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case SaldoBancoEN.ClaObj: return pObj.ClaveObjeto;
                case SaldoBancoEN.ClaSalBan: return pObj.ClaveSaldoBanco;
                case SaldoBancoEN.CodEmp: return pObj.CodigoEmpresa;
                case SaldoBancoEN.NomEmp: return pObj.NombreEmpresa;
                case SaldoBancoEN.AñoSalBan: return pObj.AñoSaldoBanco;
                case SaldoBancoEN.CodCueBan: return pObj.CodigoCuentaBanco;
                case SaldoBancoEN.DesCueBan: return pObj.DescripcionCuentaBanco;
                case SaldoBancoEN.NumCueBan: return pObj.NumeroCuentaBanco;
                case SaldoBancoEN.CMon: return pObj.CMoneda;
                case SaldoBancoEN.NMon: return pObj.NMoneda;
                case SaldoBancoEN.IngSol00: return pObj.IngresoSol00.ToString();
                case SaldoBancoEN.SalSol00: return pObj.SalidaSol00.ToString();
                case SaldoBancoEN.SaldSol00: return pObj.SaldoSol00.ToString();
                case SaldoBancoEN.IngSol01: return pObj.IngresoSol01.ToString();
                case SaldoBancoEN.SalSol01: return pObj.SalidaSol01.ToString();
                case SaldoBancoEN.SaldSol01: return pObj.SaldoSol01.ToString();
                case SaldoBancoEN.IngSol02: return pObj.IngresoSol02.ToString();
                case SaldoBancoEN.SalSol02: return pObj.SalidaSol02.ToString();
                case SaldoBancoEN.SaldSol02: return pObj.SaldoSol02.ToString();
                case SaldoBancoEN.IngSol03: return pObj.IngresoSol03.ToString();
                case SaldoBancoEN.SalSol03: return pObj.SalidaSol03.ToString();
                case SaldoBancoEN.SaldSol03: return pObj.SaldoSol03.ToString();
                case SaldoBancoEN.IngSol04: return pObj.IngresoSol04.ToString();
                case SaldoBancoEN.SalSol04: return pObj.SalidaSol04.ToString();
                case SaldoBancoEN.SaldSol04: return pObj.SaldoSol04.ToString();
                case SaldoBancoEN.IngSol05: return pObj.IngresoSol05.ToString();
                case SaldoBancoEN.SalSol05: return pObj.SalidaSol05.ToString();
                case SaldoBancoEN.SaldSol05: return pObj.SaldoSol05.ToString();
                case SaldoBancoEN.IngSol06: return pObj.IngresoSol06.ToString();
                case SaldoBancoEN.SalSol06: return pObj.SalidaSol06.ToString();
                case SaldoBancoEN.SaldSol06: return pObj.SaldoSol06.ToString();
                case SaldoBancoEN.IngSol07: return pObj.IngresoSol07.ToString();
                case SaldoBancoEN.SalSol07: return pObj.SalidaSol07.ToString();
                case SaldoBancoEN.SaldSol07: return pObj.SaldoSol07.ToString();
                case SaldoBancoEN.IngSol08: return pObj.IngresoSol08.ToString();
                case SaldoBancoEN.SalSol08: return pObj.SalidaSol08.ToString();
                case SaldoBancoEN.SaldSol08: return pObj.SaldoSol08.ToString();
                case SaldoBancoEN.IngSol09: return pObj.IngresoSol09.ToString();
                case SaldoBancoEN.SalSol09: return pObj.SalidaSol09.ToString();
                case SaldoBancoEN.SaldSol09: return pObj.SaldoSol09.ToString();
                case SaldoBancoEN.IngSol10: return pObj.IngresoSol10.ToString();
                case SaldoBancoEN.SalSol10: return pObj.SalidaSol10.ToString();
                case SaldoBancoEN.SaldSol10: return pObj.SaldoSol10.ToString();
                case SaldoBancoEN.IngSol11: return pObj.IngresoSol11.ToString();
                case SaldoBancoEN.SalSol11: return pObj.SalidaSol11.ToString();
                case SaldoBancoEN.SaldSol11: return pObj.SaldoSol11.ToString();
                case SaldoBancoEN.IngSol12: return pObj.IngresoSol12.ToString();
                case SaldoBancoEN.SalSol12: return pObj.SalidaSol12.ToString();
                case SaldoBancoEN.SaldSol12: return pObj.SaldoSol12.ToString();
                case SaldoBancoEN.IngDol00: return pObj.IngresoDol00.ToString();
                case SaldoBancoEN.SalDol00: return pObj.SalidaDol00.ToString();
                case SaldoBancoEN.SaldDol00: return pObj.SaldoDol00.ToString();
                case SaldoBancoEN.IngDol01: return pObj.IngresoDol01.ToString();
                case SaldoBancoEN.SalDol01: return pObj.SalidaDol01.ToString();
                case SaldoBancoEN.SaldDol01: return pObj.SaldoDol01.ToString();
                case SaldoBancoEN.IngDol02: return pObj.IngresoDol02.ToString();
                case SaldoBancoEN.SalDol02: return pObj.SalidaDol02.ToString();
                case SaldoBancoEN.SaldDol02: return pObj.SaldoDol02.ToString();
                case SaldoBancoEN.IngDol03: return pObj.IngresoDol03.ToString();
                case SaldoBancoEN.SalDol03: return pObj.SalidaDol03.ToString();
                case SaldoBancoEN.SaldDol03: return pObj.SaldoDol03.ToString();
                case SaldoBancoEN.IngDol04: return pObj.IngresoDol04.ToString();
                case SaldoBancoEN.SalDol04: return pObj.SalidaDol04.ToString();
                case SaldoBancoEN.SaldDol04: return pObj.SaldoDol04.ToString();
                case SaldoBancoEN.IngDol05: return pObj.IngresoDol05.ToString();
                case SaldoBancoEN.SalDol05: return pObj.SalidaDol05.ToString();
                case SaldoBancoEN.SaldDol05: return pObj.SaldoDol05.ToString();
                case SaldoBancoEN.IngDol06: return pObj.IngresoDol06.ToString();
                case SaldoBancoEN.SalDol06: return pObj.SalidaDol06.ToString();
                case SaldoBancoEN.SaldDol06: return pObj.SaldoDol06.ToString();
                case SaldoBancoEN.IngDol07: return pObj.IngresoDol07.ToString();
                case SaldoBancoEN.SalDol07: return pObj.SalidaDol07.ToString();
                case SaldoBancoEN.SaldDol07: return pObj.SaldoDol07.ToString();
                case SaldoBancoEN.IngDol08: return pObj.IngresoDol08.ToString();
                case SaldoBancoEN.SalDol08: return pObj.SalidaDol08.ToString();
                case SaldoBancoEN.SaldDol08: return pObj.SaldoDol08.ToString();
                case SaldoBancoEN.IngDol09: return pObj.IngresoDol09.ToString();
                case SaldoBancoEN.SalDol09: return pObj.SalidaDol09.ToString();
                case SaldoBancoEN.SaldDol09: return pObj.SaldoDol09.ToString();
                case SaldoBancoEN.IngDol10: return pObj.IngresoDol10.ToString();
                case SaldoBancoEN.SalDol10: return pObj.SalidaDol10.ToString();
                case SaldoBancoEN.SaldDol10: return pObj.SaldoDol10.ToString();
                case SaldoBancoEN.IngDol11: return pObj.IngresoDol11.ToString();
                case SaldoBancoEN.SalDol11: return pObj.SalidaDol11.ToString();
                case SaldoBancoEN.SaldDol11: return pObj.SaldoDol11.ToString();
                case SaldoBancoEN.IngDol12: return pObj.IngresoDol12.ToString();
                case SaldoBancoEN.SalDol12: return pObj.SalidaDol12.ToString();
                case SaldoBancoEN.SaldDol12: return pObj.SaldoDol12.ToString();
                case SaldoBancoEN.UsuAgr: return pObj.UsuarioAgrega;
                case SaldoBancoEN.FecAgr: return pObj.FechaAgrega.ToString();
                case SaldoBancoEN.UsuMod: return pObj.UsuarioModifica;
                case SaldoBancoEN.FecMod: return pObj.FechaModifica.ToString();

            }

            //retorna
            return iValor;
        }

        public static List<SaldoBancoEN> FiltrarSaldoBancoXTextoEnCualquierPosicion(List<SaldoBancoEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<SaldoBancoEN> iLisRes = new List<SaldoBancoEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (SaldoBancoEN xObj in pLista)
            {
                string iTexto = SaldoBancoRN.ObtenerValorDeCampo(xObj, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xObj);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<SaldoBancoEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<SaldoBancoEN> pLista)
        {
            //lista resultado
            List<SaldoBancoEN> iLisRes = new List<SaldoBancoEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pLista; }

            //filtar la lista
            iLisRes = SaldoBancoRN.FiltrarSaldoBancoXTextoEnCualquierPosicion(pLista, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveSaldoBanco(SaldoBancoEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.AñoSaldoBanco + "-";
            iClave += pObj.CodigoCuentaBanco;

            //retornar
            return iClave;
        }

        public static SaldoBancoEN EsSaldoBancoValido(SaldoBancoEN pObj)
        {
            //objeto resultado
            SaldoBancoEN iObjEN = new SaldoBancoEN();

            //valida cuando esta vacio
            if (pObj.AñoSaldoBanco == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CodigoCuentaBanco == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = SaldoBancoRN.EsSaldoBancoExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda)
        {
            SaldoBancoAD iObjAD = new SaldoBancoAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SaldoBancoAD iObjAD = new SaldoBancoAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            SaldoBancoAD iObjAD = new SaldoBancoAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda)
        {
            SaldoBancoAD iObjAD = new SaldoBancoAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SaldoBancoAD iObjAD = new SaldoBancoAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            SaldoBancoAD iObjAD = new SaldoBancoAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }

        public static string ObtenerNuevoNumeroSaldoBancoAutogenerado(SaldoBancoEN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = SaldoBancoRN.ObtenerMaximoValorEnColumna("CampoDondeBuscar");

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 6);

            //devuelve
            return iNumero;
        }

        public static SaldoBancoEN EsActoAdicionarSaldoBanco(SaldoBancoEN pObj)
        {
            //objeto resultado
            SaldoBancoEN iObjEN = new SaldoBancoEN();

            //ok          
            return iObjEN;
        }

        public static SaldoBancoEN EsActoModificarSaldoBanco(SaldoBancoEN pObj)
        {
            //objeto resultado
            SaldoBancoEN iObjEN = new SaldoBancoEN();

            //valida cuando el codigo no existe
            iObjEN = SaldoBancoRN.EsSaldoBancoExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static SaldoBancoEN EsActoEliminarSaldoBanco(SaldoBancoEN pObj)
        {
            //objeto resultado
            SaldoBancoEN iObjEN = new SaldoBancoEN();

            //valida cuando el codigo no existe
            iObjEN = SaldoBancoRN.EsSaldoBancoExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static SaldoBancoEN BuscarSaldoBanco(string pCampo, string pValor, List<SaldoBancoEN> pLista)
        {
            //objeto resultaddo
            SaldoBancoEN iObjEN = new SaldoBancoEN();

            //recorrer cada objeto
            foreach (SaldoBancoEN xObj in pLista)
            {
                if (SaldoBancoRN.ObtenerValorDeCampo(xObj, pCampo) == pValor)
                {
                    return xObj;
                }
            }

            //devolver
            return iObjEN;
        }


    }
}
