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
    public class SaldoContableRN
    {

        public static SaldoContableEN EnBlanco()
        {
            SaldoContableEN iObjEN = new SaldoContableEN();
            return iObjEN;
        }

        public static void AdicionarSaldoContable(List<SaldoContableEN> pLista)
        {
            SaldoContableAD iObjAD = new SaldoContableAD();
            iObjAD.AdicionarSaldoContable(pLista);
        }

        public static void AdicionarSaldoContable(SaldoContableEN pObj)
        {
            //Asignar parametros
            List<SaldoContableEN> iLisObj = new List<SaldoContableEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            SaldoContableRN.AdicionarSaldoContable(iLisObj);
        }

        public static void ModificarSaldoContable(List<SaldoContableEN> pLista)
        {
            SaldoContableAD iObjAD = new SaldoContableAD();
            iObjAD.ModificarSaldoContable(pLista);
        }

        public static void ModificarSaldoContable(SaldoContableEN pObj)
        {
            //Asignar parametros
            List<SaldoContableEN> iLisObj = new List<SaldoContableEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            SaldoContableRN.ModificarSaldoContable(iLisObj);
        }

        public static void EliminarSaldoContable(List<SaldoContableEN> pLista)
        {
            SaldoContableAD iObjAD = new SaldoContableAD();
            iObjAD.EliminarSaldoContable(pLista);
        }

        public static void EliminarSaldoContable(SaldoContableEN pObj)
        {
            //Asignar parametros
            List<SaldoContableEN> iLisObj = new List<SaldoContableEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            SaldoContableRN.EliminarSaldoContable(iLisObj);
        }

        public static List<SaldoContableEN> ListarSaldoContable(SaldoContableEN pObj)
        {
            SaldoContableAD iObjAD = new SaldoContableAD();
            return iObjAD.ListarSaldoContable(pObj);
        }

        public static List<SaldoContableEN> ListarSaldoContable()
        {
            //asignar parametros
            SaldoContableEN iObjEN = new SaldoContableEN();
            iObjEN.Adicionales.CampoOrden = SaldoContableEN.ClaSalCon;

            //ejecutar metodo
            return SaldoContableRN.ListarSaldoContable(iObjEN);
        }

        public static SaldoContableEN BuscarSaldoContableXClave(SaldoContableEN pObj)
        {
            SaldoContableAD iObjAD = new SaldoContableAD();
            return iObjAD.BuscarSaldoContableXClave(pObj);
        }

        public static SaldoContableEN EsSaldoContableExistente(SaldoContableEN pObj)
        {
            //objeto resultado
            SaldoContableEN iObjEN = new SaldoContableEN();

            //validar si existe en b.d
            iObjEN = SaldoContableRN.BuscarSaldoContableXClave(pObj);
            if (iObjEN.ClaveSaldoContable == string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El Registro seleccionado no existe";
            }

            //ok  
            return iObjEN;
        }

        public static SaldoContableEN EsCodigoSaldoContableDisponible(SaldoContableEN pObj)
        {
            //objeto resultado
            SaldoContableEN iObjEN = new SaldoContableEN();

            //valida cuando esta vacio
            if (pObj.AñoSaldoContable == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CodigoCuenta == string.Empty) { return iObjEN; }

            //validar si existe
            iObjEN = SaldoContableRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }

        public static SaldoContableEN ValidaCuandoCodigoYaExiste(SaldoContableEN pObj)
        {
            //objeto resultado
            SaldoContableEN iObjEN = new SaldoContableEN();

            //validar
            iObjEN = SaldoContableRN.BuscarSaldoContableXClave(pObj);
            if (iObjEN.ClaveSaldoContable != string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "Este codigo ya existe";
            }

            //ok  
            return iObjEN;
        }

        public static string ObtenerValorDeCampo(SaldoContableEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case SaldoContableEN.ClaObj: return pObj.ClaveObjeto;
                case SaldoContableEN.ClaSalCon: return pObj.ClaveSaldoContable;
                case SaldoContableEN.CodEmp: return pObj.CodigoEmpresa;
                case SaldoContableEN.NomEmp: return pObj.NombreEmpresa;
                case SaldoContableEN.AñoSalCon: return pObj.AñoSaldoContable;
                case SaldoContableEN.CodCue: return pObj.CodigoCuenta;
                case SaldoContableEN.DesCue: return pObj.DescripcionCuenta;
                case SaldoContableEN.NumDigAna: return pObj.NumeroDigitosAnalitica;
                case SaldoContableEN.CodForCon: return pObj.CodigoFormatoContable;
                case SaldoContableEN.DesForCon: return pObj.DescripcionFormatoContable;
                case SaldoContableEN.DebSol00: return pObj.DebeSol00.ToString();
                case SaldoContableEN.HabSol00: return pObj.HaberSol00.ToString();
                case SaldoContableEN.DebSol01: return pObj.DebeSol01.ToString();
                case SaldoContableEN.HabSol01: return pObj.HaberSol01.ToString();
                case SaldoContableEN.DebSol02: return pObj.DebeSol02.ToString();
                case SaldoContableEN.HabSol02: return pObj.HaberSol02.ToString();
                case SaldoContableEN.DebSol03: return pObj.DebeSol03.ToString();
                case SaldoContableEN.HabSol03: return pObj.HaberSol03.ToString();
                case SaldoContableEN.DebSol04: return pObj.DebeSol04.ToString();
                case SaldoContableEN.HabSol04: return pObj.HaberSol04.ToString();
                case SaldoContableEN.DebSol05: return pObj.DebeSol05.ToString();
                case SaldoContableEN.HabSol05: return pObj.HaberSol05.ToString();
                case SaldoContableEN.DebSol06: return pObj.DebeSol06.ToString();
                case SaldoContableEN.HabSol06: return pObj.HaberSol06.ToString();
                case SaldoContableEN.DebSol07: return pObj.DebeSol07.ToString();
                case SaldoContableEN.HabSol07: return pObj.HaberSol07.ToString();
                case SaldoContableEN.DebSol08: return pObj.DebeSol08.ToString();
                case SaldoContableEN.HabSol08: return pObj.HaberSol08.ToString();
                case SaldoContableEN.DebSol09: return pObj.DebeSol09.ToString();
                case SaldoContableEN.HabSol09: return pObj.HaberSol09.ToString();
                case SaldoContableEN.DebSol10: return pObj.DebeSol10.ToString();
                case SaldoContableEN.HabSol10: return pObj.HaberSol10.ToString();
                case SaldoContableEN.DebSol11: return pObj.DebeSol11.ToString();
                case SaldoContableEN.HabSol11: return pObj.HaberSol11.ToString();
                case SaldoContableEN.DebSol12: return pObj.DebeSol12.ToString();
                case SaldoContableEN.HabSol12: return pObj.HaberSol12.ToString();
                case SaldoContableEN.DebSol13: return pObj.DebeSol13.ToString();
                case SaldoContableEN.HabSol13: return pObj.HaberSol13.ToString();
                case SaldoContableEN.DebDol00: return pObj.DebeDol00.ToString();
                case SaldoContableEN.HabDol00: return pObj.HaberDol00.ToString();
                case SaldoContableEN.DebDol01: return pObj.DebeDol01.ToString();
                case SaldoContableEN.HabDol01: return pObj.HaberDol01.ToString();
                case SaldoContableEN.DebDol02: return pObj.DebeDol02.ToString();
                case SaldoContableEN.HabDol02: return pObj.HaberDol02.ToString();
                case SaldoContableEN.DebDol03: return pObj.DebeDol03.ToString();
                case SaldoContableEN.HabDol03: return pObj.HaberDol03.ToString();
                case SaldoContableEN.DebDol04: return pObj.DebeDol04.ToString();
                case SaldoContableEN.HabDol04: return pObj.HaberDol04.ToString();
                case SaldoContableEN.DebDol05: return pObj.DebeDol05.ToString();
                case SaldoContableEN.HabDol05: return pObj.HaberDol05.ToString();
                case SaldoContableEN.DebDol06: return pObj.DebeDol06.ToString();
                case SaldoContableEN.HabDol06: return pObj.HaberDol06.ToString();
                case SaldoContableEN.DebDol07: return pObj.DebeDol07.ToString();
                case SaldoContableEN.HabDol07: return pObj.HaberDol07.ToString();
                case SaldoContableEN.DebDol08: return pObj.DebeDol08.ToString();
                case SaldoContableEN.HabDol08: return pObj.HaberDol08.ToString();
                case SaldoContableEN.DebDol09: return pObj.DebeDol09.ToString();
                case SaldoContableEN.HabDol09: return pObj.HaberDol09.ToString();
                case SaldoContableEN.DebDol10: return pObj.DebeDol10.ToString();
                case SaldoContableEN.HabDol10: return pObj.HaberDol10.ToString();
                case SaldoContableEN.DebDol11: return pObj.DebeDol11.ToString();
                case SaldoContableEN.HabDol11: return pObj.HaberDol11.ToString();
                case SaldoContableEN.DebDol12: return pObj.DebeDol12.ToString();
                case SaldoContableEN.HabDol12: return pObj.HaberDol12.ToString();
                case SaldoContableEN.DebDol13: return pObj.DebeDol13.ToString();
                case SaldoContableEN.HabDol13: return pObj.HaberDol13.ToString();
                case SaldoContableEN.UsuAgr: return pObj.UsuarioAgrega;
                case SaldoContableEN.FecAgr: return pObj.FechaAgrega.ToString();
                case SaldoContableEN.UsuMod: return pObj.UsuarioModifica;
                case SaldoContableEN.FecMod: return pObj.FechaModifica;

            }

            //retorna
            return iValor;
        }

        public static List<SaldoContableEN> FiltrarSaldoContableXTextoEnCualquierPosicion(List<SaldoContableEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<SaldoContableEN> iLisRes = new List<SaldoContableEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (SaldoContableEN xObj in pLista)
            {
                string iTexto = SaldoContableRN.ObtenerValorDeCampo(xObj, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xObj);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<SaldoContableEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<SaldoContableEN> pLista)
        {
            //lista resultado
            List<SaldoContableEN> iLisRes = new List<SaldoContableEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pLista; }

            //filtar la lista
            iLisRes = SaldoContableRN.FiltrarSaldoContableXTextoEnCualquierPosicion(pLista, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveSaldoContable(SaldoContableEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.AñoSaldoContable + "-";
            iClave += pObj.CodigoCuenta;

            //retornar
            return iClave;
        }

        public static SaldoContableEN EsSaldoContableValido(SaldoContableEN pObj)
        {
            //objeto resultado
            SaldoContableEN iObjEN = new SaldoContableEN();

            //valida cuando esta vacio
            if (pObj.AñoSaldoContable == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CodigoCuenta == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = SaldoContableRN.EsSaldoContableExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }
             
        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda)
        {
            SaldoContableAD iObjAD = new SaldoContableAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SaldoContableAD iObjAD = new SaldoContableAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            SaldoContableAD iObjAD = new SaldoContableAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda)
        {
            SaldoContableAD iObjAD = new SaldoContableAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SaldoContableAD iObjAD = new SaldoContableAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            SaldoContableAD iObjAD = new SaldoContableAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }

        public static string ObtenerNuevoNumeroSaldoContableAutogenerado(SaldoContableEN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = SaldoContableRN.ObtenerMaximoValorEnColumna("CampoDondeBuscar");

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 6);

            //devuelve
            return iNumero;
        }

        public static SaldoContableEN EsActoAdicionarSaldoContable(SaldoContableEN pObj)
        {
            //objeto resultado
            SaldoContableEN iObjEN = new SaldoContableEN();

            //ok          
            return iObjEN;
        }

        public static SaldoContableEN EsActoModificarSaldoContable(SaldoContableEN pObj)
        {
            //objeto resultado
            SaldoContableEN iObjEN = new SaldoContableEN();

            //valida cuando el codigo no existe
            iObjEN = SaldoContableRN.EsSaldoContableExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static SaldoContableEN EsActoEliminarSaldoContable(SaldoContableEN pObj)
        {
            //objeto resultado
            SaldoContableEN iObjEN = new SaldoContableEN();

            //valida cuando el codigo no existe
            iObjEN = SaldoContableRN.EsSaldoContableExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static SaldoContableEN BuscarSaldoContable(string pCampo, string pValor, List<SaldoContableEN> pLista)
        {
            //objeto resultaddo
            SaldoContableEN iObjEN = new SaldoContableEN();

            //recorrer cada objeto
            foreach (SaldoContableEN xObj in pLista)
            {
                if (SaldoContableRN.ObtenerValorDeCampo(xObj, pCampo) == pValor)
                {
                    return xObj;
                }
            }

            //devolver
            return iObjEN;
        }


    }
}
